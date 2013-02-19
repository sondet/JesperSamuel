using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelloLibrary;
using NewspaperLibrary;
using WebLibrary;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            testWebLibrary();
            //testCompetition();
            //testNewspaper();
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
            //string input = Console.ReadLine();
            //Newspaper n1 = new Newspaper(input);
            NewspaperConnection connection = new NewspaperConnection();
            //connection.SearchNewspaperForKeywords(n1, new Competition(false,new string[0],new string[0]));
            List<Newspaper> nn = Newspaper.CreateNewspapersFromFile("Newspapersss.txt");
            if (nn == null) return;
            foreach (Newspaper news in nn)
            {
                Console.WriteLine(news);
            }
        }

        private static void testCompetition()
        {
            List<Competition> c = Competition.CreateFromFile("Competition.txt");
            Console.WriteLine(c[0]);
            Console.WriteLine(c[1]);
        }

        private static void testWebLibrary()
        {
            SiteSearcher searcher = new SiteSearcher();
            //string s = searcher.stripHtmlTags("");
            //Console.WriteLine(s);
            //return;
            WebSite ws = new WebSite("www.di.se");
            try
            {
                //Console.WriteLine(ws.RawContent);
                Console.WriteLine(ws.Uri.AbsoluteUri);
                ws.DownloadRawContent();
                //Console.WriteLine(ws.RawContent);
                SiteSearchResult result = searcher.SearchSiteForWord(ws, "Aktier");
                Console.WriteLine(result.Occurences);
                searcher.WriteToFile();
                foreach (Match match in result.Matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR IN TEST:\n" + e.Message);
            }

            List<Uri> uris = new List<Uri>();
            List<string> c = searcher.GetLinksFromSite(ws);
            foreach (string url in c)
            {
                Uri u = null;
                try
                {
                    bool b = Uri.TryCreate(url, UriKind.Absolute, out u);
                    if (b == false)
                        continue;
                }
                catch (UriFormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (u != null)
                    {
                        if (ws.Uri.IsBaseOf(u))
                        {
                        uris.Add(u);
                        Console.WriteLine(u.AbsoluteUri);
                        }
                    }
                }
            }
            Console.WriteLine(uris.Count);
            

            
        }
    }
}
