using Amazon.QuickSight;
using Amazon.QuickSight.Model;
using System.Text.RegularExpressions;

namespace QSembedTester
{
    public partial class Form1 : Form
    {
        const string baseName = "QSembedTester";
        const string accountId = "485226539202";
        AmazonQuickSightClient qs = new AmazonQuickSightClient();
        List<DashboardSummary> dashboardList = new List<DashboardSummary>();
        List<EmbeddableVisualInfo> embeddableVisuals = new List<EmbeddableVisualInfo>();
        public Form1()
        {
            InitializeComponent();
        }
        private void SetName(string Status = null)
        {
            if (Status == null)
                this.Text = baseName;
            else
                this.Text = $"{baseName} - {Status}";
        }
        private async void LoadDashboards(object sender, EventArgs e)
        {
            dashboards.Items.Clear();
            int count = 0;
            string nextToken = null;
            try
            {
                do
                {
                    count++;
                    SetName($"Loading Dashboards ({count})...");
                    var request = new ListDashboardsRequest
                    {
                        AwsAccountId = accountId,
                        NextToken = nextToken
                    };
                    var response = await qs.ListDashboardsAsync(request);
                    foreach (var dashboard in response.DashboardSummaryList)
                    {
                        dashboardList.Add(dashboard);
                        //dashboards.Items.Add(dashboard);
                    }
                    nextToken = response.NextToken;
                } while (!string.IsNullOrEmpty(nextToken));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboards: " + ex.Message);
            }
            dashboardList.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            foreach (var dashboard in dashboardList)
            {
                dashboards.Items.Add(dashboard);
            }
            SetName($"{dashboardList.Count:#,##0} Dashboards Loaded");
        }
        private async void DashboardSelected(object sender, EventArgs e)
        {
            embeddableVisuals.Clear();
            var selectedItem = (DashboardSummary)dashboards.SelectedItem!;
            SetName(selectedItem.Name);
            var dDef = await qs.DescribeDashboardDefinitionAsync(new DescribeDashboardDefinitionRequest
            {
                AwsAccountId = accountId,
                DashboardId = selectedItem.DashboardId
            });
            foreach (var sheet in dDef.Definition.Sheets)
            {
                foreach (var visual in sheet.Visuals)
                {
                    if (visual is Visual visualDef)
                    {
                        string title = visualDef.GetVisualTitle();
                        if (title == null)
                            continue;
                        embeddableVisuals.Add(new EmbeddableVisualInfo
                        {
                            Title = visualDef.GetVisualTitle(),
                            DashboardId = selectedItem.DashboardId,
                            SheetId = sheet.SheetId,
                            VisualId = visualDef.VisualId()
                        });
                    }
                }
            }
            visualList.Items.Clear();
            if (embeddableVisuals.Count > 0)
            {
                embeddableVisuals.ForEach(v => visualList.Items.Add(v));
                SetName($"{embeddableVisuals.Count:#,##0} Visuals Found");
            }
            else
            {
                SetName("No Visuals Found");
            }
        }
        private void PerformSearch(object sender, EventArgs e)
        {
            dashboards.Items.Clear();
            if (tSearchDashboards.Text.Length > 0)
            {
                Regex rxSearch = new Regex(tSearchDashboards.Text, RegexOptions.IgnoreCase);
                dashboardList.Where(d => rxSearch.IsMatch(d.Name)).ToList().ForEach(d => dashboards.Items.Add(d.Name));
            }
            else
            {
                dashboardList.ForEach(d => dashboards.Items.Add(d));
            }
            SetName($"{dashboards.Items.Count:#,##0} Dashboards Found");
        }
        private async void SelectedVisual(object sender, EventArgs e)
        {
            var selectedItem = (EmbeddableVisualInfo)visualList.SelectedItem!;
            if (selectedItem == null)
                return;
            SetName($"Visual: {selectedItem.Title}");
            await qs.GenerateEmbedUrlForRegisteredUserAsync(new GenerateEmbedUrlForRegisteredUserRequest
            {
                AwsAccountId = accountId,
                SessionLifetimeInMinutes = 30,
                UserArn = $"arn:aws:quicksight:us-east-1:{accountId}:user/{tNamespace.Text}/{tUser.Text}",
                ExperienceConfiguration = new RegisteredUserEmbeddingExperienceConfiguration
                {
                    DashboardVisual = new RegisteredUserDashboardVisualEmbeddingConfiguration
                    {
                        InitialDashboardVisualId = new DashboardVisualId
                        {
                            DashboardId = selectedItem.DashboardId,
                            SheetId = selectedItem.SheetId,
                            VisualId = selectedItem.VisualId
                        }
                    }
                }
            }).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    var embedUrl = task.Result.EmbedUrl;
                    outputText.Invoke(() =>
                    {
                        outputText.AppendText($"{selectedItem.Title}:\n");
                        outputText.AppendText($"Embed URL: {embedUrl}\n\n");
                    });
                }
                else
                {
                    this.Invoke(() => MessageBox.Show("Error generating embed URL: " + task.Exception?.Message));
                }
            });
        }
        private void OpenDashboard(object sender, LinkClickedEventArgs e)
        {
            try
            {
                var url = e.LinkText;
                if (!string.IsNullOrWhiteSpace(url))
                {
                    // .NET Core/.NET 5+ cross-platform way to open a URL in the default browser
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }
    }
}
