using System;
using System.Collections.Generic;

namespace Research
{
    public delegate void Del();
    public delegate void DelNum(int num);

    public class DelegateResearch
    {
        public void Caller_1_() { Console.WriteLine("This is Caller 1 function..."); }
        public static void Caller_2_() { Console.WriteLine("This is Caller 2 function..."); }

        public static void Research()
        {
            var DR = new DelegateResearch();

            List<Del> dlgt = new List<Del>()
            {
                new Del(DR.Caller_1_),
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
