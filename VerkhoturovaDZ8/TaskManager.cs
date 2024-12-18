using System;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskManager
    {
        private Project project;

        public void Run()
        {
            SetupProject();
            ManageTasks();
            DisplayProjectStatus();
        }

        private void SetupProject()
        {
            project = new Project("Разработка приложения", DateTime.Now.AddMonths(1), "Клиент", "Тимлид");
            Program.DisplayMessage("Проект создан.");

            AddTasks();
            project.StartProject();
        }

        private void AddTasks()
        {
            project.AddTask(new Task("Разработка интерфейса", DateTime.Now.AddDays(10), "Клиент"));
            project.AddTask(new Task("Создание базы данных", DateTime.Now.AddDays(15), "Клиент"));
            project.AddTask(new Task("Написание документации", DateTime.Now.AddDays(20), "Клиент"));
            Program.DisplayMessage("Задачи добавлены к проекту.");
        }

        private void ManageTasks()
        {
            foreach (var task in project.Tasks)
            {
                string executor = "Исполнитель " + (project.Tasks.IndexOf(task) + 1);
                task.StartWork(executor);
                task.SubmitReport($"Работа по задаче '{task.Description}' выполнена.");
                Program.DisplayMessage($"Задача '{task.Description}' выполнена исполнителем '{executor}'.");

                // Завершение задачи
                task.Status = TaskStatus.Completed;
            }
        }

        private void DisplayProjectStatus()
        {
            if (project.IsClosed())
            {
                project.Status = ProjectStatus.Closed;
                Program.DisplayMessage("Проект закрыт.");
            }
            else
            {
                Program.DisplayMessage("Проект все еще в процессе выполнения.");
            }

            Program.DisplayMessage($"Статус проекта: {project.Status}");
        }
    }
}