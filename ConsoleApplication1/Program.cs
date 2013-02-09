using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelloLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("sha ere final lr?");
            string svar = Console.ReadLine().ToLower();
            bool b;
            string[] artists;
            string[] songTitles;
            string line;
            System.IO.StreamReader txt = new System.IO.StreamReader(@"\Songs.txt");
            while ((line = txt.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

            b = (svar == "ja" || svar.Substring(0, 2) == "ye") ? true : false;
            Competition c = new Competition(b);
            Console.WriteLine(c.IsFinal.ToString());
            Console.ReadLine();
        }
    }
}
