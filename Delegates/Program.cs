using Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//Delegates are essentially references to methods. They act like pointers to functions, allowing you to store and pass the address of a method as a variable.
namespace LinqIAndDelegates.Delegates
{
    //FLEXIBILITY
    /*
    delegate int MyDelegate(int x, int y);
    public class Delegates
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }


        public static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate(Add);
            int result = del(5, 6);
            Console.WriteLine(result);

            MyDelegate del1 = new MyDelegate(Subtract);
            result = del1(8, 6);
            Console.WriteLine(result);
        }
    }
    */

    /*
    //Encapsulation of Behavior:
    using System;

    delegate void Logger(string message);
    
    class LoggerService
    {
        public static void LogToFile(string message)
        {
            // Code to log message to a file
            Console.WriteLine($"Logging message to file: {message}");
        }
    }

    class UserManager
    {
        // Method that performs user registration
        public static void RegisterUser(string username)
        {
            // Logic for registering user

            // Log registration event
            Logger log = LoggerService.LogToFile;  //      Logger log = new Logger(LoggerService.LogToFile);
            log($"User {username} registered successfully.");
        }
    }
    public class HelloWorld
    {
        public static void Main(string[] args)
        {
            UserManager.RegisterUser("John Doe");
        }
    }

    */




    /*
    //function pass


    delegate void Callback();

    // LongRunningTask class simulating a long-running task
    class LongRunningTask
    {
        public void Start(Callback callback)
        {
            // Simulate a long-running task
            System.Threading.Thread.Sleep(2000);

            // Invoke the callback method when the task is completed
            callback?.Invoke();
        }
    }

    class Program
    {
        public static void Main()
        {
            LongRunningTask task = new LongRunningTask();

            // Start the long-running task and pass a callback method
            task.Start(TaskCompletedCallback);
        }

        static void TaskCompletedCallback()
        {
            Console.WriteLine("Task completed!");
        }
    }
    
    */




    //function passing in delegates
    /* 

     // Delegate definition
     delegate void MyDelegate(int x, int y);

     class Program
     {
         static void Main()
         {
             // Create an instance of the class containing the method to be passed
             Calculator calculator = new Calculator();

             // Pass the method as a delegate parameter
             PerformOperation(calculator.Add, 5, 3);
             PerformOperation(calculator.Subtract, 10, 4);
         }

         // Method that accepts a delegate as a parameter
         static void PerformOperation(MyDelegate operation, int a, int b)
         {
             // Invoke the delegate, passing the parameters
             operation(a, b);
         }
     }

     // Class containing methods to be passed as delegates
     class Calculator
     {
         // Method to add two numbers
         public void Add(int x, int y)
         {
             Console.WriteLine($"Result of addition: {x + y}");
         }

         // Method to subtract two numbers
         public void Subtract(int x, int y)
         {
             Console.WriteLine($"Result of subtraction: {x - y}");
         }
     }

    */

    /*
    //Event Handling
    using System;

    // Declare delegate for the event handler
    delegate void EventHandler(object sender, EventArgs e);

    // Publisher class
    class Publisher
    {
        // Declare the event
        public event EventHandler MyEvent;

        // Method to raise the event
        public void RaiseEvent()
        {
            // Check if there are any subscribers
            if (MyEvent != null)
            {
                // Raise the event by invoking the delegate
                MyEvent(this, EventArgs.Empty);
            }
        }
    }

    // Subscriber class
    class Subscriber
    {
        // Event handler method
        public void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Event handled by Subscriber");
        }
    }

    class Program
    {
        static void Main()
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();

            // Subscribe to the event
            publisher.MyEvent += subscriber.HandleEvent;

            // Raise the event
            publisher.RaiseEvent();

            Console.ReadLine();
        }
    }
      //So, delegates enable the Publisher to raise events without knowing anything about the subscribers, and they allow subscribers to handle events without knowing anything about the Publisher. This promotes decoupling and flexibility in the code architecture.
    */

    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            Action<Photo> filterHandler = filters.ApplyFilters;
            filterHandler += filters.ApplyBrightness;
            filterHandler += RemoveRedEyeFilter;

            processor.process("photo.jpg", filterHandler);
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveREdEye");
        }
    }
}
