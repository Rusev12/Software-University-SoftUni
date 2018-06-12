using System;
using System.Threading;

namespace EvenNumbersThread
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var events = new Thread(() => PrintEvenNumbers(start, end));
            events.Start();
            events.Join();
            Console.WriteLine("Thread finished work");
        }

        public static void PrintEvenNumbers(int start , int end)
        {
            for (int i = start; i < end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
