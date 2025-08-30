namespace SuggestionApp.ViewModels
{
    public class DashboardViewModel
    {
        public int DepartmentCount { get; set; }
        public List<string> DepartmentManagers { get; set; }
        public int ManagerRoleCount { get; set; }
        public int TotalSuggestions { get; set; }
        public int AcceptedSuggestions { get; set; }
        public int RejectedSuggestions { get; set; }

        public int PendingSuggestions { get; set; }
    }
}
