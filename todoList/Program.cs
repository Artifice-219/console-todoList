using System;
using System.Collections.Generic;

namespace MyApp
{
    class Task{
        public string Content { get; set;}
        public string Time_created { get; set; }

        public Task(string content, string time_created){
            Content = content;
            Time_created = time_created;
        }

        public void ShowTask(){
            Console.WriteLine($"Task : {Content}, Time created {Time_created}");
        }
    };

    internal class Program
    {
        static void createTask(){
        Console.WriteLine("Enter New Task");
        // TODO 7 : Replace this approach instead of checking for null, just check if the user
        //entered a null value and re-prompt
        string taskContent = Console.ReadLine() ?? "Un-named Task";
        // timestamp automatically created
        string timeCreated = Convert.ToString(DateTime.Now);
        Task newTask = new Task(taskContent,timeCreated );
    }

        static void Main(string[] args)
        {
            createTask();

            
        }
    }
}