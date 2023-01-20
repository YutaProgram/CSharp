using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Reflection;

namespace HttpConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 sample = new Class1();
            //sample.GetTest();
            sample.PostTest();

            Console.ReadLine();
        }
    }
}
