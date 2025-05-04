using System;
// for iterable data structures
using System.Collections.Generic;
using System.Net.Mime;

namespace Myapp{
    class TodoItem{
        public string Content { get; set; }
        public string Time_created {get; set;}

        public TodoItem(string content, string time_created){
            Content = content;
            Time_created = time_created;
        }

        // internal method to show details of this todo item
        public string showDetails(){
            return $"Task : {Content} --- Time Created {Time_created}";
        }
    }
    
    internal class Program{
        static void listTask(List<TodoItem> taskList){
            Console.WriteLine("Showing all task");
            // loops to every item in the taskList and display all its contents
            for(int i=0; i <= taskList.Count - 1; ++i){
                // string taskDetails = taskList[i].Content;
                // string taskTimeCreated = taskList[i].Time_created;
                // Console.WriteLine($"{i} Task : {taskDetails} created at time : {taskTimeCreated}");
                Console.WriteLine(taskList[i].showDetails()); 
            }
            // foreach(TodoItem item in taskList){
            //     string taskDetails = item.Content;
            //     string taskTimeCreated = item.Time_created;
            //     Console.WriteLine($"Task : {taskDetails} created at time : {taskTimeCreated}");
            // }
        }
        // creates a new task and then append that to the task container
        static void addTask(List<TodoItem> taskList){
            Console.WriteLine("Creating a new Task");
            Console.WriteLine("Enter new task : ");
            string task = Console.ReadLine() ?? "Un-named task";
            // getting the current time
            string time_created = Convert.ToString(DateTime.Now);
            // making an instance of the todoItem class
            TodoItem todoItem = new TodoItem(task, time_created);
            taskList.Add(todoItem);
            Console.WriteLine($"New task {todoItem.Content} is succesfully added to task list");

        }
        static void Menu(){
            // TODO 11 : THIS MENU IS NOT FUNCTIONAL
            Console.WriteLine("Choose an action if none is provided, defaulting to 0");
            Console.WriteLine("Select 1 : Create New Tasks");
            Console.WriteLine("Select 2 : To View Tasks");
            Console.WriteLine("Select 3 : To Edit Tasks");
            Console.WriteLine("Select 4 : To Finished a  Task");

            string userChoice = Console.ReadLine() ?? "0";
            // convert userChoice to string unnecesarry but we can the language more with this
            try{
                int userChoiceNum = int.Parse(userChoice);
                // input feedback
                Console.WriteLine($"You have selected {userChoiceNum}");
            }
            catch(FormatException){
                Console.WriteLine("Invalid Choice, Please select only from the provided prompt");
            }

        }
        // main method
        static void Main(string[] args){
            List<TodoItem> TaskList = new List<TodoItem>();
            // load main menu
            Menu();
            addTask(TaskList);
            addTask(TaskList);
            listTask(TaskList);
            Console.WriteLine($"Current count of the tasklist contianer is {TaskList.Count}");
        }
    }
}