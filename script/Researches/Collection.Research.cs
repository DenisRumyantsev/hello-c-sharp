using System;

namespace Research
{
    class Collection < T >
    {
        private T[] arr = new T[100];

        // public T this[int i] { get { return arr[i]; } set { arr[i] = value; } }

        // public T this[int i] { get => arr[i]; set => arr[i] = value; }

        public T this[int i] => arr[i];
        private int next = 0;
        public void Add(T value) { if (next >= arr.Length) throw new IndexOutOfRangeException($"This collection can hold only {arr.Length} elements."); arr[next++] = value; }
    }

    class CollectionResearch
    {
        public static void Research()
        {
            var cllctn = new Collection < string > ();
            // cllctn[0] = "Hello, World!";
            cllctn.Add("Hello, World!");
            Console.WriteLine(cllctn[0]);
        }
    }
}
