namespace QSembedTester
{
    public class  EmbeddableVisualInfo
    {
        public string Title { get; set; }
        public string DashboardId { get; set; }
        public string SheetId { get; set; }
        public string VisualId { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
