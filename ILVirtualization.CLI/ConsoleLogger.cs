
using ILVirtualization.Core;
using System;

namespace ILVirtualization.CLI
{
    public class ConsoleLogger : ILogger
    {
        public void Debug(string m)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("CLand-CLI ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("DBG");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(m);
        }

        public void Info(string m)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("CLand-CLI ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("INF");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(m);
        }

        public void Warn(string m)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("CLand-CLI ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("WRN");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(m);
        }
    }
}