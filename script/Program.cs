//
// using Research;
//
// DynamicResearch.Research();
//
// await ThreadingResearch.Research();
//
// CollectionResearch.Research();
//
// EventResearch.Research();
//
// DelegateResearch.Research();


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var listObj = new List < int > { 1, 2, 3 }; // index based generic collection (arraylist)
            Console.WriteLine($"List First Value: {listObj[0]}"); // Displaying list value using index

            Dictionary < int, string > objDic = new Dictionary < int, string > { { 1, "abc" }, { 2, "ijk" }, { 3, "xyz" } }; // Key based generic Collection (Dictionary)
            Console.WriteLine($"Dictionary Value: {objDic[1]}"); // Displaying Dictionary value using Key

            var objStack = new Stack < int > (new[] { 1, 2, 3 }); // Priority based Generic Collection (Stack)
            Console.WriteLine($"First Get Value from Stack: {objStack.Pop()}"); // Display first value from Stack

            var objQueue = new Queue < int > (listObj); // Priority based Generic Collection (Queues)
            Console.WriteLine($"First Get Value from Queue: {objQueue.Dequeue()}"); // Display first value from Stack

            Console.WriteLine();

            var empList = new List < Employee >
            {
                new Employee(1001, "Denis", "Ivanovo"),
                new Employee(1002, "Alice", "WonderLand")
            }; // Creating generic List with Employee records
            foreach(Employee emp in empList) emp.Print(); // Displaying employee records from list collection
        }

        public class Employee
        {
            public Employee(int id, string name, string address) { ID = id; Name = name; Address = address; }
            public int ID;
            public string Name;
            public string Address;
            public void Print() { Console.WriteLine($"\nEmployee info:\n  ID: {ID}\n  Name: {Name}\n  Address: {Address}"); }
        }
    }
}
