
#region Usings
using System;
using ILVirtualization.Core;
using Runtime;
#endregion

namespace ILVirtualization.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "[ CursedLand ILVirtualization v1 ]";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(88, 28);
            Console.SetBufferSize(88, 9001);
            Console.WriteLine(@"

              ___ _ __   ___     _             _ _         _   _          
             |_ _| |\ \ / (_)_ _| |_ _  _ __ _| (_)_____ _| |_(_)___ _ _  
              | || |_\ V /| | '_|  _| || / _` | | |_ / _` |  _| / _ \ ' \ 
             |___|____\_/ |_|_|  \__|\_,_\__,_|_|_/__\__,_|\__|_\___/_||_|
                                                              

");
            Console.ResetColor();
            if (args.Length <= 0) {
                Console.Write("[CLand-CLI DIR]: ");
                (args = new string[1])[0] = Console.ReadLine();
            }

            new Context(args[0], new ConsoleLogger())
                .Execute()
                .Write();

           // Console.ReadKey();
        }
    }
}