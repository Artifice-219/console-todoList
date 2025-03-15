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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Im on my first C# application");
        }
    }
}