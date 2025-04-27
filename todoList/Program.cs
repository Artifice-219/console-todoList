using System;
// for iterable data structures
using System.Collections.Generic;
using System.Net.Mime;

namespace Myapp{
    class todoItem{
        public string Content { get; set; }
        public string Time_created {get; set;}

        public todoItem(string content, string time_created){
            Content = content;
            Time_created = time_created;
        }

        // internal method to show details of this todo item
        public void showDetails(){
            Console.WriteLine($"Task : : {Content} , Time Created {Time_created}");
        }
    }
}
// using System;
// using System.Collections.Generic;

// namespace MyApp
// {

//     internal class Program
//     {
//         // array to store all task
//            List<Task> taskList = new List<Task>();

//         static void createTask(List<Task> taskList){
//         Console.WriteLine("Enter New Task");
//         // TODO 7 : Replace this approach instead of checking for null, just check if the user
//         //entered a null value and re-prompt
//         string taskContent = Console.ReadLine() ?? "Un-named Task";
//         // timestamp automatically created
//         string timeCreated = Convert.ToString(DateTime.Now);
//         Task newTask = new Task(taskContent,timeCreated );
//         // add the newly created task to the taskList
//         taskList.Add(newTask);
//     }

//         static void Main(string[] args)
//         {
//             createTask();

            
//         }
//     }
// }