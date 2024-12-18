using System;

namespace TaskManager
{
    public class Report
    {
        public string ReportText { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Executor { get; set; }

        public Report(string reportText, DateTime completionDate, string executor)
        {
            ReportText = reportText;
            CompletionDate = completionDate;
            Executor = executor;
        }
    }
}