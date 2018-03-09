
namespace TAFProject.Models
{

    public class Enums
    {
        public enum Notifications
        {
            Positive, Negative
        }
        public enum IssueType  //Models
        {
            Default, Task, ChangeRequest
        }
        public enum IssueStatus
        {
            Default, New, NeedInfo, Assigned, Closed
        }
        public enum IssuePriority
        {
            Default, Lowest, Low, Medium, High, Highest
        }
    }
}
