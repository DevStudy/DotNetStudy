using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lambda
{
    [TestFixture]
    class FirstLambda
    {

        /*
         
         Lambda 表达式是一种可用于创建委托或表达式目录树类型的匿名函数。
         通过使用 lambda 表达式，可以写入可作为参数传递或作为函数调用值返回的本地函数。 
         Lambda 表达式对于编写 LINQ 查询表达式特别有用。

            若要创建 Lambda 表达式，需要在 Lambda 运算符 => 左侧指定输入参数（如果有），然后在另一侧输入表达式或语句块。
            例如，lambda 表达式 x => x * x 指定名为 x 的参数并返回 x 的平方值。 如下面的示例所示，你可以将此表达式分配给委托类型：
         
         
         */


        delegate int del(int i);


        [Test]
        public void Example1()
        {
            del myDelegate = x => x * x;
            int j = myDelegate(5); //j = 25  
            Assert.AreEqual(j,25);
        }

        /// <summary>
        /// 若要创建表达式目录树类型
        /// </summary>
        [Test]
        public void Example2()
        {
            Expression<del> myET = x => x * x;//=> 运算符具有与赋值运算符 (=) 相同的优先级并且是右结合运算（参见“运算符”文章的“结合性”部分）。
            var t = myET.Compile();
            var j = t.Invoke(5);
            Assert.AreEqual(j,25);
            
        }


    }
}
