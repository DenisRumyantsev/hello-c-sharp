using System;

namespace Research
{
    class OldItem
    {
        public string Name;
        public int X;
        public int Y;

        public OldItem(string name, int x, int y) { Name = name; X = x; Y = y; }

        public static explicit operator OldItem(NewItem NI) => new OldItem(NI.Name, NI.X, NI.Y);
    }

    class NewItem
    {
        public string Name;
        public int X;
        public int Y;
        public int Z;

        public NewItem(string name, int x, int y, int z) { Name = name; X = x; Y = y; Z = z; }

        public static implicit operator NewItem(OldItem OI) => new NewItem(OI.Name, OI.X, OI.Y, 0);
    }

    class ConversionResearch
    {
        public static void Research()
        {
            int a = 123;
            float b = a;
            double c = b;
            var d = (float)c;
            var e = (int)d; // Possible OverflowException

            // Persona per = new Persona();
            // Employee emp = (Employee)per; // Possible InvalidCastException

            string str = "456";
            int num = int.Parse(str); // = int.TryParse(str);

            byte[] bytes = { 3, 5, 2, 8, 1, 9, 7, 5 };
            Int64 val = BitConverter.ToInt64(bytes, 0);

            NewItem NI_1_ = new NewItem("First New Item", 12, 34, 56);
            OldItem OI_1_ = (OldItem)NI_1_;

            OldItem OI_2_ = new OldItem("Second Old Item", 78, 90);
            NewItem NI_2_ = OI_2_;
        }
    }
}
