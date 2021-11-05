using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLearning
{
    class 异常高级
    {
        public static void 内部异常()
        {
            try
            {
                try
                {
                    var num = int.Parse("abc");
                }
                catch (Exception inner)
                {
                    try
                    {
                        var openLog = File.Open("DoesNotExist", FileMode.Open);
                    }
                    catch
                    {
                        throw new FileNotFoundException("OutterException", inner);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}由于{e.InnerException?.Message}");
            }
        }
        public static void 自定义异常()
        {
            
        }
        /// <summary>
        /// ApplicationException 表示是用户而非系统定义的异常
        /// </summary>
        class NothingException : ApplicationException
        {

        }
    }
}
