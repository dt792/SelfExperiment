using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLearning
{
    class EXE调用
    {
        public static void 实例化创建()
        {
            Process process = new Process();//创建进程对象    
            ProcessStartInfo startInfo = new ProcessStartInfo(@"E:\C# Learnings\SelfExperiment\ProcessLearning\ConsoleApp\bin\Debug\net5.0\ConsoleApp.exe", "arg1"); // 括号里是(程序名,参数)
            process.StartInfo = startInfo;
            startInfo.CreateNoWindow = false;
            process.Start();
        }
        public static void 静态创建()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"E:\C# Learnings\SelfExperiment\ProcessLearning\ConsoleApp\bin\Debug\net5.0\ConsoleApp.exe", "arg1"); // 括号里是(程序名,参数)
            Process process= Process.Start(startInfo);
        }
    }
}
