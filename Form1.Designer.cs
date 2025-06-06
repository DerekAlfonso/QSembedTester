namespace QSembedTester
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            tSearchDashboards = new TextBox();
            dashboards = new ListBox();
            splitContainer2 = new SplitContainer();
            tUser = new TextBox();
            lUser = new Label();
            tNamespace = new TextBox();
            lNamespace = new Label();
            visualList = new ListBox();
            outputText = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tSearchDashboards);
            splitContainer1.Panel1.Controls.Add(dashboards);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // tSearchDashboards
            // 
            tSearchDashboards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tSearchDashboards.Location = new Point(3, 3);
            tSearchDashboards.Name = "tSearchDashboards";
            tSearchDashboards.Size = new Size(260, 23);
            tSearchDashboards.TabIndex = 1;
            tSearchDashboards.TextChanged += PerformSearch;
            // 
            // dashboards
            // 
            dashboards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dashboards.DisplayMember = "Name";
            dashboards.FormattingEnabled = true;
            dashboards.ItemHeight = 15;
            dashboards.Location = new Point(0, 30);
            dashboards.Name = "dashboards";
            dashboards.Size = new Size(266, 409);
            dashboards.TabIndex = 0;
            dashboards.SelectedIndexChanged += DashboardSelected;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tUser);
            splitContainer2.Panel1.Controls.Add(lUser);
            splitContainer2.Panel1.Controls.Add(tNamespace);
            splitContainer2.Panel1.Controls.Add(lNamespace);
            splitContainer2.Panel1.Controls.Add(visualList);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(outputText);
            splitContainer2.Size = new Size(530, 450);
            splitContainer2.SplitterDistance = 197;
            splitContainer2.TabIndex = 0;
            // 
            // tUser
            // 
            tUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tUser.Location = new Point(42, 24);
            tUser.Name = "tUser";
            tUser.Size = new Size(152, 23);
            tUser.TabIndex = 4;
            tUser.Text = "SSO-FullAdmin/dalfonso@anterratech.com";
            // 
            // lUser
            // 
            lUser.AutoSize = true;
            lUser.Location = new Point(3, 27);
            lUser.Name = "lUser";
            lUser.Size = new Size(33, 15);
            lUser.TabIndex = 3;
            lUser.Text = "User:";
            // 
            // tNamespace
            // 
            tNamespace.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tNamespace.Location = new Point(81, -2);
            tNamespace.Name = "tNamespace";
            tNamespace.Size = new Size(113, 23);
            tNamespace.TabIndex = 2;
            tNamespace.Text = "default";
            // 
            // lNamespace
            // 
            lNamespace.AutoSize = true;
            lNamespace.Location = new Point(3, 1);
            lNamespace.Name = "lNamespace";
            lNamespace.Size = new Size(72, 15);
            lNamespace.TabIndex = 1;
            lNamespace.Text = "Namespace:";
            // 
            // visualList
            // 
            visualList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            visualList.FormattingEnabled = true;
            visualList.ItemHeight = 15;
            visualList.Location = new Point(0, 45);
            visualList.Name = "visualList";
            visualList.Size = new Size(197, 394);
            visualList.TabIndex = 0;
            visualList.SelectedIndexChanged += SelectedVisual;
            // 
            // outputText
            // 
            outputText.Dock = DockStyle.Fill;
            outputText.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            outputText.Location = new Point(0, 0);
            outputText.Name = "outputText";
            outputText.ReadOnly = true;
            outputText.Size = new Size(329, 450);
            outputText.TabIndex = 0;
            outputText.Text = "";
            outputText.LinkClicked += OpenDashboard;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "QS Embed Tester";
            Load += LoadDashboards;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox dashboards;
        private TextBox tSearchDashboards;
        private SplitContainer splitContainer2;
        private ListBox visualList;
        private RichTextBox outputText;
        private TextBox tUser;
        private Label lUser;
        private TextBox tNamespace;
        private Label lNamespace;
    }
}
