using System;

namespace TaskManager
{
    public enum TaskStatus
    {
        Assigned,
        InProgress,
        UnderReview,
        Completed
    }

    public class Task
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Initiator { get; set; }
        public string Executor { get; set; }
        public TaskStatus Status { get; set; }
        public Report TaskReport { get; set; }

        public Task(string description, DateTime deadline, string initiator)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Status = TaskStatus.Assigned;
        }

        public void StartWork(string executor)
        {
            Executor = executor;
            Status = TaskStatus.InProgress;
        }

        public void DelegateTask(string newExecutor)
        {
            Executor = newExecutor;
        }

        public void RejectTask()
        {
            Executor = null;
            Status = TaskStatus.Assigned;
        }

        public void SubmitReport(string reportText)
        {
            TaskReport = new Report(reportText, DateTime.Now, Executor);
            Status = TaskStatus.UnderReview;
        }
    }
}