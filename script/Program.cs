﻿
using Research;

CollectionResearch.Research();

// EventResearch.Research();

// DelegateResearch.Research();

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
