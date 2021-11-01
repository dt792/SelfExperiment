using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessLearning
{
    class 重定向输出
    {
        public static void 同步方式()
        {
            Process process = new Process();//创建进程对象    
            ProcessStartInfo startInfo = new ProcessStartInfo(@"E:\C# Learnings\SelfExperiment\ProcessLearning\ConsoleApp\bin\Debug\net5.0\ConsoleApp.exe", "arg1"); // 括号里是(程序名,参数)
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            process.Start();
            Console.WriteLine(process.StandardOutput.ReadLine());
            Console.WriteLine(process.StandardOutput.ReadLine());
            Console.WriteLine(process.StandardOutput.ReadLine());
            process.StandardInput.WriteLine("info");
            Console.WriteLine(process.StandardOutput.ReadLine());
            process.StandardInput.WriteLine("quit");
            Console.WriteLine(process.StandardOutput.ReadLine());
            Thread.Sleep(10000);
        }
        public static void 异步方式()
        {
            void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                Console.WriteLine(e.Data);
            }
            Process process = new Process();//创建进程对象    
            ProcessStartInfo startInfo = new ProcessStartInfo(@"E:\C# Learnings\SelfExperiment\ProcessLearning\ConsoleApp\bin\Debug\net5.0\ConsoleApp.exe", "arg1"); // 括号里是(程序名,参数)
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            process.Start();

            process.BeginOutputReadLine();
            process.OutputDataReceived += Process_OutputDataReceived;

            process.StandardInput.WriteLine("info");
            process.StandardInput.WriteLine("quit");
            Thread.Sleep(10000);
        }
    }
}
