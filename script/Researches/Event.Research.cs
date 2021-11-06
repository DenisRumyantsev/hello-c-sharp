using System;

namespace Research
{
    class Args
    {
        public Args(string msg, int sum) { Msg = msg; Sum = sum; }
        public string Msg { get; }
        public int Sum { get; }
    }

    class Account
    {
        public delegate void Handler_1_(string msg);
        public delegate void Handler_2_(object sender, Args e);
        private event Handler_1_ Event_A_;
        public event Handler_1_ Event_B_
        {
            add { Event_A_ += value; Console.WriteLine($"  # {value.Method.Name} added"); }
            remove { Event_A_ -= value; Console.WriteLine($"  # {value.Method.Name} removed"); }
        }
        public event Handler_2_ Event_C_;
        public Account(int sum) { Sum = sum; }
        public int Sum { get; private set; }
        public void Put(int sum) { int s = Sum; Sum += sum; string msg = $"{s} + {sum} = {Sum}"; Event_A_?.Invoke(msg); Event_C_?.Invoke(this, new Args(msg, sum)); }
        public void Take(int sum)
        {
            if (Sum >= sum) { int s = Sum; Sum -= sum; string msg = $"{s} - {sum} = {Sum}"; Event_A_?.Invoke(msg); Event_C_?.Invoke(this, new Args(msg, sum)); }
            else { string msg = $"{Sum} < {sum}! Not enough!"; Event_A_?.Invoke(msg); Event_C_?.Invoke(this, new Args(msg, sum)); }
        }
        public void PrintSum() { Console.WriteLine($"Account Sum: {Sum}\n"); }
    }

    class EventResearch
    {
        public static void Research()
        {
            Account X = new Account(100);
            X.Event_C_ += Msg;
            X.Event_B_ += delegate (string mes) { Console.WriteLine($"  % Anonimous >>> {mes}"); };
            X.Event_B_ += (string mes) => Console.WriteLine($"  % Lambda >>> {mes}");
            X.Event_B_ += BlueMsg;
            X.Put(20);
            X.PrintSum();
            X.Event_B_ -= BlueMsg;
            X.Event_B_ += new Account.Handler_1_(RedMsg);
            X.Take(70);
            X.PrintSum();
            X.Take(180);
            X.PrintSum();
        }

        private static void Msg(object sender, Args e) { Console.WriteLine($"  & Sum: {e.Sum}\n  & Msg: {e.Msg}"); }
        private static void BlueMsg(string message) { Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(message); Console.ResetColor(); }
        private static void RedMsg(string message) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(message); Console.ResetColor(); }
    }
}
