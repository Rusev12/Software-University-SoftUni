using System;

namespace E01_GenericBoxOfString
{
    public class Startup
    {
        public static void Main()
        {
            var numberOfInputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputLines; i++)
            {
                var element = Console.ReadLine();
                var box = new Box<string>(element);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
