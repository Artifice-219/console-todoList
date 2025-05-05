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
            //TODO 14 : THE SHOWING OF THE TASK INDEX WILL BE DUPLICATED HERE WHEN CALLING LISTTASK()
            return $"Task {index} : {Content} --- Time Created {Time_created}";
        }
    }
    
    internal class Program{
       static void markAsDone(List<TodoItem> taskList)
{
    // Define ANSI escape codes for styling
    const string headerColor = "\x1b[32m"; // Green
    const string promptColor = "\x1b[33m"; // Yellow
    const string successColor = "\x1b[36m"; // Cyan
    const string errorColor = "\x1b[31m"; // Red
    const string resetColor = "\x1b[0m";
    const string  infoColor = "\x1b[32m";
    const string separator = "--------------------------------------------------";

    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine(headerColor + "             Mark Task as Done             " + resetColor);
    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine();

    listTask(taskList); // Display the list of tasks

    Console.WriteLine();
    Console.Write(promptColor + "Select the index of the task to mark as 'Done': " + resetColor);
    string input = Console.ReadLine() ?? "0";

    if (int.TryParse(input, out int userChoice))
    {
        Console.WriteLine(infoColor + $"Index: {userChoice} selected." + resetColor);
        if (userChoice >= 0 && userChoice < taskList.Count)
        {
            string taskContent = taskList[userChoice].Content; // Store task content for confirmation
            taskList.RemoveAt(userChoice);
            Console.WriteLine(successColor + $"Task '{taskContent}' marked as done and removed." + resetColor);
            Console.WriteLine("\n" + separator + "\n");
            listTask(taskList); // Redisplay the updated task list
            Console.WriteLine("\n" + separator + "\n");
        }
        else
        {
            Console.WriteLine(errorColor + $"Error: Invalid index '{userChoice}'. Please select a valid index from the list." + resetColor + "\n");
        }
    }
    else
    {
        Console.WriteLine(errorColor + $"Error: Invalid input '{input}'. Redirecting to main menu." + resetColor + "\n");
    }
    Console.Clear();
    Menu(taskList);
}
       static void editTask(List<TodoItem> taskList)
{
    // Define ANSI escape codes for styling
    const string headerColor = "\x1b[32m"; // Green
    const string promptColor = "\x1b[33m"; // Yellow
    const string infoColor = "\x1b[36m"; // Cyan
    const string errorColor = "\x1b[31m"; // Red
    const string confirmationColor = "\x1b[34m"; // Blue
    const string resetColor = "\x1b[0m";
    const string successColor = "\x1b[32m";
    const string separator = "--------------------------------------------------";

    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine(headerColor + "               Edit Task Details              " + resetColor);
    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine();

    listTask(taskList); // Display the list of tasks

    Console.WriteLine();
    Console.Write(promptColor + "Select which task index to edit (default is 0): " + resetColor);
    string input = Console.ReadLine() ?? "0";

    int userChoice = 0; // Initialize with the default value

    if (int.TryParse(input, out userChoice))
    {
        Console.WriteLine(infoColor + $"Index: {userChoice} selected." + resetColor);
        if (userChoice >= 0 && userChoice < taskList.Count)
        {
            Console.WriteLine(separator);
            //TODO 15 : replace the task index with the actul content of the task instead of the selected index
            Console.WriteLine(infoColor + $"Editing task at index: {userChoice}" + resetColor);
            Console.WriteLine();

            Console.Write(promptColor + "Enter new task details: " + resetColor);
            string newTaskDetails = Console.ReadLine() ?? " ";
            string newTaskCreationDate = Convert.ToString(DateTime.Now);

            Console.WriteLine(separator);
            Console.WriteLine(infoColor + "Current Task: " + resetColor);
            Console.WriteLine(infoColor + $"  Task: {taskList[userChoice].Content}" + resetColor);
            Console.WriteLine(infoColor + $"  Created at: {taskList[userChoice].Time_created}" + resetColor);
            Console.WriteLine(confirmationColor + "Will be changed to: >>>>>>>> " + resetColor);
            Console.WriteLine();
            Console.WriteLine(infoColor + $"  Task: {newTaskDetails}" + resetColor);
            Console.WriteLine(infoColor + $"  Time Created: {newTaskCreationDate}" + resetColor);
            Console.WriteLine(separator);

            Console.Write(promptColor + "Press " + confirmationColor + "y" + resetColor + " to confirm, or any other key to cancel: ");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.KeyChar == 'y' || key.KeyChar == 'Y')
            {
                taskList[userChoice].Content = newTaskDetails;
                taskList[userChoice].Time_created = newTaskCreationDate;
                Console.WriteLine(successColor + "\nTask successfully edited." + resetColor);
                listTask(taskList);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(infoColor + "\nEdit action cancelled by user." + resetColor);
            }
            Console.WriteLine(separator + "\n");
            Menu(taskList);
        }
        else
        {
            Console.WriteLine(errorColor + $"Error: Invalid index '{userChoice}'. Please select a valid index from the list." + resetColor + "\n");
            Console.Clear();
            Menu(taskList); // Go back to menu on invalid index
        }
    }
    else
    {
        Console.WriteLine(errorColor + $"Error: Invalid input '{input}'. Redirecting to main menu." + resetColor + "\n");
        Console.Clear();
        Menu(taskList); // Go back to menu on invalid input
    }
}
        static void viewTask(List<TodoItem> taskList)
{
    // Define ANSI escape codes for styling
    const string headerColor = "\x1b[32m"; // Green
    const string promptColor = "\x1b[33m"; // Yellow
    const string infoColor = "\x1b[36m"; // Cyan
    const string errorColor = "\x1b[31m"; // Red
    const string resetColor = "\x1b[0m";
    const string separator = "--------------------------------------------------";

    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine(headerColor + "               View Task Details              " + resetColor);
    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine();

    listTask(taskList); // Display the list of tasks

    Console.WriteLine();
    Console.Write(promptColor + "Select which task index to view (default is 0): " + resetColor);
    string input = Console.ReadLine() ?? "0";

    int userChoice = 0; // Initialize with the default value

    if (int.TryParse(input, out userChoice))
    {
        Console.WriteLine(infoColor + $"Index: {userChoice} selected." + resetColor);
        if (userChoice >= 0 && userChoice < taskList.Count)
        {
            Console.WriteLine(separator);
            Console.WriteLine(infoColor + $"Showing details for task at index: {userChoice}" + resetColor);
            Console.WriteLine(infoColor + $"Task Details: {taskList[userChoice].Content}" + resetColor);
            Console.WriteLine(infoColor + $"Created: {taskList[userChoice].Time_created}" + resetColor);
            Console.WriteLine(separator + "\n");
        }
        else
        {
            Console.WriteLine(errorColor + $"Error: Invalid index '{userChoice}'. Please select a valid index from the list." + resetColor + "\n");
        }
    }
    else
    {
        Console.WriteLine(errorColor + $"Error: Invalid input '{input}'. Please enter a valid number." + resetColor + "\n");
    }
    Menu(taskList);
}
    static void listTask(List<TodoItem> taskList){
        // Define ANSI escape codes for styling
        const string headerColor = "\x1b[32m"; // Green
        const string indexColor = "\x1b[33m"; // Yellow
        const string detailColor = "\x1b[36m"; // Cyan
        const string resetColor = "\x1b[0m";
        const string separator = "--------------------------------------------------";

        Console.WriteLine(headerColor + separator + resetColor);
        Console.WriteLine(headerColor + "                 Current Tasks                  " + resetColor);
        Console.WriteLine(headerColor + separator + resetColor);
        Console.WriteLine();

        if (taskList.Count == 0)
        {
            Console.WriteLine(detailColor + "No tasks in the list." + resetColor + "\n");
            return;
        }

        // Loops through each item in the taskList and displays its contents
        for (int i = 0; i < taskList.Count; ++i)
        {
            // Set the index
            taskList[i].index = i;
            Console.WriteLine($"{indexColor}Task [{i}]:{resetColor} {taskList[i].showDetails()}");
        }
        Console.WriteLine("\n" + separator + "\n");
    }
        // creates a new task and then append that to the task container
        static void addTask(List<TodoItem> taskList)
{
    // Define ANSI escape codes for styling
    const string headerColor = "\x1b[32m"; // Green
    const string promptColor = "\x1b[33m"; // Yellow
    const string successColor = "\x1b[36m"; // Cyan
    const string resetColor = "\x1b[0m";
    const string separator = "--------------------------------------------------";

    // clear the console first before displaying anything
    Console.Clear();
    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine(headerColor + "           Creating a New Task           " + resetColor);
    Console.WriteLine(headerColor + separator + resetColor);
    Console.WriteLine();

    Console.Write(promptColor + "Enter new task: " + resetColor);
    string task = Console.ReadLine() ?? "Un-named task";

    // getting the current time
    string time_created = Convert.ToString(DateTime.Now);

    // making an instance of the todoItem class
    TodoItem todoItem = new TodoItem(task, time_created);
    taskList.Add(todoItem);

    Console.WriteLine(successColor + $"New task '{todoItem.Content}' is successfully added to the task list." + resetColor);
    Console.WriteLine(separator + "\n");
    // after successfully adding a task call the main menu once again
    Menu(taskList);
}
    static void Menu(List<TodoItem> TaskList){
        // Define some ANSI escape codes for styling
        const string separator = "--------------------------------------------------";
        const string headerColor = "\x1b[32m"; // Green
        const string instructionColor = "\x1b[33m"; // Yellow
        const string choiceColor = "\x1b[36m"; // Cyan
        const string resetColor = "\x1b[0m";

        Console.WriteLine(headerColor + separator + resetColor);
        Console.WriteLine(headerColor + "               Task Manager Menu               " + resetColor);
        Console.WriteLine(headerColor + separator + resetColor);
        Console.WriteLine();
        Console.WriteLine(instructionColor + "Choose an action (if none is provided, defaulting to 0):" + resetColor);
        Console.WriteLine($"{choiceColor}Select 1:{resetColor} Create New Tasks");
        Console.WriteLine($"{choiceColor}Select 2:{resetColor} View Tasks");
        Console.WriteLine($"{choiceColor}Select 3:{resetColor} Edit Tasks");
        Console.WriteLine($"{choiceColor}Select 4:{resetColor} Finish a Task");
        Console.WriteLine(separator);
        Console.Write("Enter your choice: "); // Changed WriteLine to Write to keep input on the same line

        string userChoice = Console.ReadLine() ?? "0";

        Console.WriteLine(separator); // Add separator after input

        try
        {
            int userChoiceNum = int.Parse(userChoice);
            Console.WriteLine($"You have selected: {headerColor}{userChoiceNum}{resetColor}"); // Styled feedback


            switch(userChoiceNum){
                    case 1 :
                        addTask(TaskList);
                    break;
                    case 2 :
                        viewTask(TaskList);
                    break;
                    case 3 :
                        editTask(TaskList);
                    break;
                    case 4 : 
                        markAsDone(TaskList);
                    break;
                } 
        }
        catch (FormatException)
        {
            Console.WriteLine($"Invalid Choice: {instructionColor}{userChoice}{resetColor}. Please select only from the provided prompt.");
        }

     Console.WriteLine(separator + "\n"); // Add a final separator and newline for better spacing
     Console.Clear();
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
            Menu(TaskList);
        }
    }
}