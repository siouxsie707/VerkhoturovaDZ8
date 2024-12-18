using System;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            taskManager.Run();
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}