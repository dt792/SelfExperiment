using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("程序开始");
            Console.WriteLine("已传入参数");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
            while (true)
            {
                var command= Console.ReadLine();
                switch (command)
                {
                    case "quit": { Console.WriteLine("程序结束"); return; }
                    case "info": Console.WriteLine("- info"); break;
                    default:
                        break;
                }
            }
        }
    }
}
