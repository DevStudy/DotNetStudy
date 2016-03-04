using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSource
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCompanyEventSource.Log.Startup();
            Console.WriteLine("Starting up");

            MyCompanyEventSource.Log.DBQueryStart("Select * from MYTable");
            var url = "http://localhost";
            for (int i = 0; i < 10; i++)
            {
                MyCompanyEventSource.Log.PageStart(i, url);
                MyCompanyEventSource.Log.Mark(i);
                MyCompanyEventSource.Log.PageStop(i);
            }
            MyCompanyEventSource.Log.DBQueryStop();
            MyCompanyEventSource.Log.LogColor(MyColor.Blue);

            MyCompanyEventSource.Log.Failure("This is a failure 1");
            MyCompanyEventSource.Log.Failure("This is a failure 2");
            MyCompanyEventSource.Log.Failure("This is a failure 3");

            Console.Read();
        }
    }
}
