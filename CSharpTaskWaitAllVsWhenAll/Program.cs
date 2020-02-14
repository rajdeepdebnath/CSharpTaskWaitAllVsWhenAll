using System;
using System.Threading.Tasks;

namespace CSharpTaskWaitAllVsWhenAll
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Task.Delay(3000).GetAwaiter().GetResult();
            Console.WriteLine("some other work...");
        }

        static async Task Test()
        {
            var t1 = Task.Run(async () => {
                await Task.Delay(2000);
                Console.WriteLine("task 1"); 
            });
            var t2 = Task.Run(() => Console.WriteLine("task 2"));
            var t3 = Task.Run(() => Console.WriteLine("task 3"));

            Task.WaitAll(new Task[] { t1, t2, t3 });

            
        }
    }
}
