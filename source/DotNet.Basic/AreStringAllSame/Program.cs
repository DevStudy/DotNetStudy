using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AreStringAllSame
{
    /// <summary>
    /// 所有的字符串的内存位都相同？
    /// </summary>
    unsafe class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("所有的字符串的内存位都相同？");

            Console.WriteLine("同一程序域的情况：");
            var a = "test";
            var b = "test";

            fixed (char* ap = a)
            {
               Console.WriteLine((ulong)ap);
            }
            fixed (char* ap = b)
            {
                Console.WriteLine((ulong)ap);
            }

            Console.Read();
        }
    }
}
