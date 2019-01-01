using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selinium_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            NUnitTestClass obj = new NUnitTestClass();

            Thread t1 = new Thread(() =>
            {

                obj.FireFoxBrowser();
            Thread.Sleep(10000);
            });
            Thread t2 = new Thread(() =>
            {
                obj.ChromeBrowser();
                Thread.Sleep(10000);
            });
            Thread t3 = new Thread(p =>
            {
                obj.InternetExplorer();
                Thread.Sleep(10000);
            });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();


        }
    }
}
