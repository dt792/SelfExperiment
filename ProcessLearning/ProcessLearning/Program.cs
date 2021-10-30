using System;
using System.Diagnostics;

namespace ProcessLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();//创建进程对象    
            ProcessStartInfo startInfo = new ProcessStartInfo(@"E:\C# Learnings\SelfExperiment\ProcessLearning\ConsoleApp\bin\Debug\net5.0\ConsoleApp.exe", "arg1"); // 括号里是(程序名,参数)
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            Console.WriteLine(process.StandardOutput.ReadLine());
            Console.WriteLine(process.StandardOutput.ReadLine());
            Console.WriteLine(process.StandardOutput.ReadLine());
            process.StandardInput.WriteLine("info");
            Console.WriteLine(process.StandardOutput.ReadLine());
            process.StandardInput.WriteLine("quit");
            Console.WriteLine(process.StandardOutput.ReadLine());
        }
    }
}
