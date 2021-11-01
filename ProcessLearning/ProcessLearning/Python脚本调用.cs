using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessLearning
{
    class Python脚本调用
    {
        public static void 例子()
        {
            string pythonPath = @"E:\C# Learnings\SelfExperiment\ProcessLearning\PythonApplication1\env\Scripts\python.exe";
            string scriptPath = @"E:\C# Learnings\SelfExperiment\ProcessLearning\PythonApplication1\PythonApplication1.py";
            Process process = new Process();//创建进程对象
            ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath,$"\"{scriptPath}\"" ); // 路径包含空格时要另外用双引号
            process.StartInfo = startInfo;
            startInfo.CreateNoWindow = false;
            process.Start();
        }
        public static void 耗时脚本()
        {
            string pythonPath = @"E:\C# Learnings\SelfExperiment\ProcessLearning\PythonApplication1\env\Scripts\python.exe";
            string scriptPath = @"E:\C# Learnings\SelfExperiment\ProcessLearning\PythonApplication1\LongTime.py";
            Process process = new Process();//创建进程对象
            ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath, $"\"{scriptPath}\""); // 路径包含空格时要另外用双引号
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            process.Start();
            Console.WriteLine(process.StandardOutput.ReadLineAsync().Result);
            Console.WriteLine(process.StandardOutput.ReadLineAsync().Result);
            Thread.Sleep(13000);
        }
    }
}
