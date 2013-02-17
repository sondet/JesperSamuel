using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] asdf = Directory.GetCurrentDirectory().Split('\\');
            Console.WriteLine(asdf[asdf.GetUpperBound(0)]);
            Console.ReadLine();


        }
    }
}
