using System;
// for iterable data structures
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace Myapp{
    class TodoItem{
        // this index will be used to identify the current task for modifications
        public int index {get; set;}
        public string Content { get; set; }
        public string Time_created {get; set;}

        public TodoItem(string content, string time_created){
            Content = content;
            Time_created = time_created;
        }

        // internal method to show details of this todo item
        public string showDetails(){
            return $"Task {index} : {Content} --- Time Created {Time_created}";
        }
    }
    
    internal class Program{
        static void markAsDone(List<TodoItem> taskList){
            listTask(taskList);
            Console.WriteLine("Select which task index to marked as 'Done'");
            string input = Console.ReadLine() ?? "0";
            int userChoice;
            if(int.TryParse(input, out userChoice)){
                // successfull parsing
                Console.WriteLine($"Index : {userChoice} selected");
            }
            else{
                // if un succesfull parsing go back to main menu
                Console.WriteLine("Invalid Input. Redirecting to main menu");
                // call main menu after this line
            }
            // delete the selected task in the taskList
            taskList.RemoveAt(userChoice);
            // redisplay all task for use confirmation
            listTask(taskList);
            
        }
        static void editTask(List<TodoItem> taskList){
            // shows all task and then ask which task to edit
            listTask(taskList);
            Console.WriteLine();
            Console.WriteLine("Select which task index to edit. If no index is provided will defualt to zero");
            string input = Console.ReadLine() ?? "0";
            int userChoice;
            if(int.TryParse(input, out userChoice)){
                // successfull parsing
                Console.WriteLine($"Index : {userChoice} selected");
            }
            else{
                // if un succesfull parsing go back to main menu
                Console.WriteLine("Invalid Input. Redirecting to main menu");
                // call main menu after this line
            }
            // start editing the selected task:
            Console.WriteLine("Editting task : ......");
            Console.WriteLine();
            Console.WriteLine("Enter new task's details");
            string newTaskDetails = Console.ReadLine() ?? " ";
            string newTaskCreationDate = Convert.ToString(DateTime.Now);
            // show the uneditied task details and ask for confirmation
            Console.WriteLine("Current Task : ");
            Console.WriteLine($"Task : {taskList[userChoice].Content}");
            Console.WriteLine($"Created at : {taskList[userChoice].Time_created}");
            Console.WriteLine("Will be changed to : >>>>>>>> ");
            Console.WriteLine();
            Console.WriteLine($"Task : {newTaskDetails}");
            Console.WriteLine($"Time Created : {newTaskCreationDate}");
            Console.WriteLine("Press y to confirm else press any key to cancel");
            // reading the user input's keypress
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            if(key.KeyChar == 'y'){
                taskList[userChoice].Content = newTaskDetails;
                taskList[userChoice].Time_created = newTaskCreationDate;
                Console.WriteLine("Task succesfully editted");
                listTask(taskList);
                Console.WriteLine();
                Menu();
            }
            else{
                Console.WriteLine("Action cancelled by user");
                Menu();
            }

        }
        static void viewTask(List<TodoItem> taskList){
            // shows all of the task and then ask for which task to display
            listTask(taskList);
            Console.WriteLine();
            Console.WriteLine("Select which task index to view. If no index is provided will default to zero");
            string input = Console.ReadLine() ?? "0";
            // cast input as int
            int userChoice;
            if(int.TryParse(input, out userChoice)){
                // succesfull parsing
                Console.WriteLine($"Index : {userChoice} selected");
            }
            else{
                // if the parsing was unsuccessfull just go back to main menu ?
                // this might prove idiotic in the long run
                Console.WriteLine("Invalid input.");
            }
            Console.WriteLine($"Showing details for task indexed at : {userChoice}");
            Console.WriteLine($"Task Details : {taskList[userChoice].Content}");
            Console.WriteLine($"Created : {taskList[userChoice].Time_created}");
        }
        static void listTask(List<TodoItem> taskList){
            Console.WriteLine("Showing all task");
            // loops to every item in the taskList and display all its contents
            for(int i=0; i <= taskList.Count - 1; ++i){
                // set the index
                taskList[i].index = i;
                Console.WriteLine(taskList[i].showDetails()); 
            }
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
            // some builtin values, delete afterwards
            TodoItem todoItem1 = new TodoItem("get laundry", "12-12-12");
            TodoItem todoItem2 = new TodoItem("feed the fish", "12-13-12");
            TodoItem todoItem3 = new TodoItem("Watch Movie", "12-14-12");
            TodoItem todoItem4 = new TodoItem("Water the Plants", "12-15-12");
            TaskList.Add(todoItem1);
            TaskList.Add(todoItem2);
            TaskList.Add(todoItem3);
            TaskList.Add(todoItem4);
            // load main menu
            Menu();
            listTask(TaskList);
            viewTask(TaskList);
            editTask(TaskList);
            markAsDone(TaskList);
        }
    }
}