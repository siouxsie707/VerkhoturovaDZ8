using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum ProjectStatus
    {
        Project,
        InProgress,
        Closed
    }

    public class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Initiator { get; set; }
        public string TeamLead { get; set; }
        public ProjectStatus Status { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();

        public Project(string description, DateTime deadline, string initiator, string teamLead)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            TeamLead = teamLead;
            Status = ProjectStatus.Project;
        }

        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Project)
            {
                Tasks.Add(task);
            }
        }

        public void StartProject()
        {
            Status = ProjectStatus.InProgress;
        }

        public bool IsClosed()
        {
            foreach (Task task in Tasks)
            {
                if (task.Status != TaskStatus.Completed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}