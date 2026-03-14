namespace EmployeeProjectManagementSystem.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }

        public List<EmployeeProject> EmployeeProjects { get; set; }
    }
}