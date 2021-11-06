using System;
using System.Threading.Tasks;

namespace Research
{
    class ThreadingResearch
    {
        public static void Test_0()
        {
            var t = Task.Factory.StartNew(
                () =>
                {
                    Console.WriteLine("Start");

                    return Task.Factory.StartNew(
                        () =>
                        {
                            Task.Delay(5000).Wait();
                            Console.WriteLine("Done");
                        }
                    );
                }
            );

            t.Wait();
            Console.WriteLine("All done");
        }

        public static async Task Test_1()
        {
            await Task.Factory.StartNew(
                async () =>
                {
                    Console.WriteLine("Start");
                    await Task.Delay(5000);
                    Console.WriteLine("Done");
                }
            ).Unwrap();

            Console.WriteLine("All done");
        }

        public static async Task Test_2()
        {
            await Task.Run(
                async () =>
                {
                    Console.WriteLine("Start");
                    await Task.Delay(5000);
                    Console.WriteLine("Done");
                }
            );

            Console.WriteLine("All done");
        }

        public static async Task Research()
        {
            // Test_0();
            // await Test_1();
            await Test_2();
        }
    }
}
