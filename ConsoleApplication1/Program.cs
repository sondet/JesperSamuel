﻿using System;
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
            //if (svar == "ja" || svar.Substring(0,2) == "ye")
            //{
            //    b = true;
            //}
            //else
            //{
            //    b = false;
            //}

            b = (svar == "ja" || svar.Substring(0, 2) == "ye") ? true : false;
            Competition c = new Competition(b);
            Console.WriteLine(c.IsFinal.ToString());
            Console.ReadLine();
        }
    }
}
