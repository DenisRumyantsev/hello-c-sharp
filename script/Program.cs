
// =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====

// class Abc
// {
//     public Abc() { }
//     public Abc(int v) { }
//
//     public void Method_1_(int i) { }
//
//     public void Method_2_(string str) { }
// }
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         Abc xyz = new Abc();
//
//         xyz.Method_1_("argument", 7, null); // compiler error
// // error CS1501: No overload for method 'Method_1_' takes 3 arguments
// // The build failed. Fix the build errors and run again.
//
//         dynamic ijk = new Abc();
//
//         ijk.Method_2_("argument", 7, null); // run-time exception
// // Unhandled exception. Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: No overload for method 'Method_2_' takes 3 arguments
//
//         ijk.Method_3_("argument", 7, null); // does not exist :: no compiler error
// // Unhandled exception. Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: 'Abc' does not contain a definition for 'Method_3_'
//     }
// }

// dynamic d = 1;
// var testSum = d + 3; // dynamic
// System.Console.WriteLine(testSum);
// var testInstance = new Abc(d); // Abc
//
// dynamic d1 = 7;
// dynamic d2 = "string";
// dynamic d3 = System.DateTime.Today;
// dynamic d4 = System.Diagnostics.Process.GetProcesses();
//
// int i = d1;
// string str = d2;
// DateTime dt = d3;
// System.Diagnostics.Process[] procs = d4;
//
// xyz.Method_2_("string"); // valid
// xyz.Method_2_(d2); // valid
// xyz.Method_2_(7); // compiler error
//
// xyz.Method_2_(d1);  // no compiler error (xyz is not dynamic)
// // run-time exception is raised because the run-time type of d1 is int

// =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====

// using System;
// using System.Threading.Tasks;
//
// class Program
// {
//     public static void Test_0()
//     {
//         var t = Task.Factory.StartNew(
//             () =>
//             {
//                 Console.WriteLine("Start");
//
//                 return Task.Factory.StartNew(
//                     () => { Task.Delay(5000).Wait(); Console.WriteLine("Done"); }
//                 );
//             }
//         );
//
//         t.Wait(); Console.WriteLine("All done");
//     }
//
//     public static async Task Test_1()
//     {
//         await Task.Factory.StartNew(
//             async () => { Console.WriteLine("Start"); await Task.Delay(5000); Console.WriteLine("Done"); }
//         ).Unwrap();
//
//         Console.WriteLine("All done");
//     }
//
//     public static async Task Test_2()
//     {
//         await Task.Run(
//             async () => { Console.WriteLine("Start"); await Task.Delay(5000); Console.WriteLine("Done"); }
//         );
//
//         Console.WriteLine("All done");
//     }
//
//     static async Task Main(string[] args)
//     {
//         // Test_0();
//         // await Test_1();
//         await Test_2();
//     }
// }

// =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====

// using System;

// namespace script
// {
//     class Collection < T >
//     {
//         private T[] arr = new T[100];

//         // public T this[int i] { get { return arr[i]; } set { arr[i] = value; } }

//         // public T this[int i] { get => arr[i]; set => arr[i] = value; }

//         public T this[int i] => arr[i];
//         private int next = 0;
//         public void Add(T value) { if (next >= arr.Length) throw new IndexOutOfRangeException($"This collection can hold only {arr.Length} elements."); arr[next++] = value; }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             var cllctn = new Collection < string > ();
//             // cllctn[0] = "Hello, World!";
//             cllctn.Add("Hello, World!");
//             Console.WriteLine(cllctn[0]);
//         }
//     }
// }

// =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====

// using System;

// namespace script
// {
//     class Args
//     {
//         public Args(string msg, int sum) { Msg = msg; Sum = sum; }
//         public string Msg { get; }
//         public int Sum { get; }
//     }

//     class Account
//     {
//         public delegate void Handler_1(string msg);
//         public delegate void Handler_2(object sender, Args e);
//         private event Handler_1 _N;
//         public event Handler_1 N_1
//         {
//             add { _N += value; Console.WriteLine($"  # {value.Method.Name} added"); }
//             remove { _N -= value; Console.WriteLine($"  # {value.Method.Name} removed"); }
//         }
//         public event Handler_2 N_2;
//         public Account(int sum) { Sum = sum; }
//         public int Sum { get; private set; }
//         public void Put(int sum) { int s = Sum; Sum += sum; string msg = $"{s} + {sum} = {Sum}"; _N?.Invoke(msg); N_2?.Invoke(this, new Args(msg, sum)); }
//         public void Take(int sum)
//         {
//             if (Sum >= sum) { int s = Sum; Sum -= sum; string msg = $"{s} - {sum} = {Sum}"; _N?.Invoke(msg); N_2?.Invoke(this, new Args(msg, sum)); }
//             else { string msg = $"{Sum} < {sum}! Not enough!"; _N?.Invoke(msg); N_2?.Invoke(this, new Args(msg, sum)); }
//         }
//         public void PrintSum() { Console.WriteLine($"Account Sum: {Sum}\n"); }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Account X = new Account(100);
//             X.N_2 += Msg;
//             X.N_1 += delegate (string mes) { Console.WriteLine($"  % Anonimous >>> {mes}"); };
//             X.N_1 += (string mes) => Console.WriteLine($"  % Lambda >>> {mes}");
//             X.N_1 += BlueMsg;
//             X.Put(20);
//             X.PrintSum();
//             X.N_1 -= BlueMsg;
//             X.N_1 += new Account.Handler_1(RedMsg);
//             X.Take(70);
//             X.PrintSum();
//             X.Take(180);
//             X.PrintSum();
//         }

//         private static void Msg(object sender, Args e) { Console.WriteLine($"  & Sum: {e.Sum}\n  & Msg: {e.Msg}"); }
//         private static void BlueMsg(string message) { Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(message); Console.ResetColor(); }
//         private static void RedMsg(string message) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(message); Console.ResetColor(); }
//     }
// }

// =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====

using System;

namespace script
{
    public delegate void Del();
    public delegate void DelNum(int num);

    class Program
    {
        public void Caller_1_() { Console.WriteLine("This is Caller 1 function..."); }
        public static void Caller_2_() { Console.WriteLine("This is Caller 2 function..."); }

        static void Main()
        {
            // Program.Main();

            Program p = new Program();

            List<Del> dlgt = new List<Del>()
            {
                new Del(p.Caller_1_),
                new Del(Caller_2_),
                new Del(
                    delegate { Console.WriteLine("This is Caller 3 function..."); }
                ),
                new Del(
                    () => { Console.WriteLine("This is Caller 4 function..."); }
                )
            };

            List<DelNum> dlgtNum = new List<DelNum>()
            {
                new DelNum(
                    delegate(int num) { Console.WriteLine($"This is Caller 5 function with {num} argument..."); }
                ),
                new DelNum(
                    (int num) => { Console.WriteLine($"This is Caller 6 function with {num} argument..."); }
                )
            };

            dlgt[0]();
            dlgt[1]();
            dlgt[2]();
            dlgt[3]();

            dlgtNum[0](5);
            dlgtNum[1](6);

            Del MultiDelegate0123 = dlgt[0] + dlgt[1] + dlgt[2] + dlgt[3];
            MultiDelegate0123();

            DelNum MultiDelegate56 = dlgtNum[0] + dlgtNum[1]; // Multi Cast Idea
            MultiDelegate56(7);
        }
    }
}

// =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====   =====
