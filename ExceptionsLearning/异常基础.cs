using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ExceptionsLearning
{
    class 异常基础
    {
        public static void 常见异常()
        {
            throw new NotImplementedException();
            //参数异常
            throw new ArgumentException();
            throw new ArgumentNullException();
            throw new ArgumentOutOfRangeException();
            //IO异常
            throw new DirectoryNotFoundException();
            throw new FileNotFoundException();
            //不正确操作
            throw new InvalidOperationException();
        }
        public static void 异常信息()
        {
            Exception exception = new Exception("信息");
            Console.WriteLine(exception.Message);
            exception.Data.Add(1,2);
            Console.WriteLine(exception.Data[1]);
            //似乎是被捕捉到的异常才有信息
            Console.WriteLine(exception.StackTrace);
            try
            {
                throw exception;
            }
            catch (Exception)
            {
                //捕获当前异常发生所经历的方法的名称和签名 
                Console.WriteLine(exception.StackTrace);
                //捕获引发当前异常的方法
                Console.WriteLine(exception.TargetSite);
            }
            //手动设置
            Console.WriteLine(exception.HelpLink);
            //捕获或设置导致错误的应用程序或对象的名称
            Console.WriteLine(exception.Source);
        }
    }
}
