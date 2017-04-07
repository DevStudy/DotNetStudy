using System;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Lambda.MicTest
{

    [TestFixture()]
    public class Example1
    {

        [Test]
        public void Run1()
        {
            var s = new Sample() {Name = "temp", Age = 15};
            var ps = s.GetType().GetProperties();
            foreach (var info in ps)
            {
                Console.WriteLine($"{info.Name}:{info.GetValue(s)}");
            }


            Console.WriteLine("ok");
        }


    }


    class Sample
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void Put()
        {
            Console.WriteLine("test");
        }
    }
}