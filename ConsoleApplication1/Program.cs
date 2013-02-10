using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelloLibrary;
using NewspaperLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            testNewspaper();
            //Console.WriteLine("sha ere final lr?");
            //string svar = Console.ReadLine().ToLower();
            //bool b;
            //string[] artists;
            //string[] songTitles;
            //string line;
            //System.IO.StreamReader txt = new System.IO.StreamReader(@"\Songs.txt");
            //while ((line = txt.ReadLine()) != null)
            //{
            //    Console.WriteLine(line);
            //}

            //b = (svar == "ja" || svar.Substring(0, 2) == "ye") ? true : false;
            //Competition c = new Competition(b);
            //Console.WriteLine(c.IsFinal.ToString());
            Console.ReadLine();
        }

        private static void testNewspaper()
        {
            string s = "http://www.aftonbladet.se";
            Newspaper n = new Newspaper(s);
            Console.WriteLine("url:");
            string input = Console.ReadLine();
            Newspaper n1 = new Newspaper(input);
            NewspaperConnection connection = new NewspaperConnection();
            //connection.SearchNewspaperForKeywords(n1, new Competition(false,new string[0],new string[0]));
            List<Newspaper> nn = Newspaper.CreateNewspapersFromFile("Newspapers.txt");
            foreach (Newspaper news in nn)
            {
                Console.WriteLine(news);
            }
        }
    }
}
