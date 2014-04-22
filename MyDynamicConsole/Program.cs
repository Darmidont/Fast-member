using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDynamicProvider;

namespace MyDynamicConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dnv = new MyDynamic();
            dnv.Test();
            Console.WriteLine("end a program");
            Console.ReadLine();
        }
    }
}
