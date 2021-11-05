using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLearning
{
    class 异常捕捉
    {
        public static void 基本流程()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("已捕捉异常");
                //如果此处 throw 则相等于 return 甚至后续的 finally 都不会执行
                //throw;
            }
            //无论catch中如何处理都会执行finally
            finally
            {
                Console.WriteLine("最终处理");
            }
            Console.WriteLine("本来的流程？");
        }
        public static void 多个catch()
        {
            try
            {
                throw new NotImplementedException("未实现");
            }
            //当捕获多个异常时,若两个catch块的异常类存在继承关系,则要先捕获派生类的异常,再捕获基类的异常.
            //如果上一个catch捕捉下面能捕捉的 则报错 -编译器的检查
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"通用异常处理中捕捉：{ex.Message}");
            //}
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"未实现中捕捉：{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"通用异常处理中捕捉：{ex.Message}");
            }
            //相等于 if(exception is NotImplementedException ex)
            //else if(exception is Exception ex)
        }
    }
}
