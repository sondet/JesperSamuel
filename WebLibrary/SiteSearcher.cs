using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace WebLibrary
{
    /// <summary>
    /// Class that searches a site for keywords
    /// </summary>
    public class SiteSearcher
    {
        private string _RawHTML; //Temporära bara!
        private string _StrippedHTML;

        public SiteSearcher()
        {

        }

        public SiteSearchResult SearchSiteForWord(WebSite webSite, string word)
        {
            if (webSite == null) throw new ArgumentNullException("webSite");
            if (webSite == null) throw new ArgumentNullException("word");

            string rawHtml = webSite.RawContent;
            if (string.IsNullOrWhiteSpace(rawHtml))
                throw new ArgumentException("WebSite object had no raw content");
            _RawHTML = rawHtml;

            rawHtml = stripHtmlTags(rawHtml);
            //Console.WriteLine(rawHtml);
            _StrippedHTML = rawHtml;

            Regex rgx = new Regex(word + "[^\\b]?", RegexOptions.IgnoreCase); //Kolla till rgx!

            MatchCollection matches = rgx.Matches(rawHtml);
            if (matches.Count > 0)
            {
                return new SiteSearchResult(webSite, word) { Occurences = matches.Count, Matches = matches};
            }
            return new SiteSearchResult(webSite, word) { Occurences = 0 };
        }

        public MatchCollection GetLinksFromSite(WebSite webSite)
        {
            if (webSite == null) throw new ArgumentNullException("webSite");

            string rawHtml = webSite.RawContent;
            if (string.IsNullOrWhiteSpace(rawHtml))
                throw new ArgumentException("WebSite object had no raw content");

            Regex rgx = new Regex("<a href=\"[^\\\"]+");
            MatchCollection matches = rgx.Matches(rawHtml);
            return matches;

        }

        public string stripHtmlTags(string s)
        {
            StringBuilder builder = new StringBuilder();
            bool insideTag = false;
            bool insideScript = false;

            //s = "<html><div>Hejsan</div></html><script>if x<0 do something </script>";
            int i = 0;
            int length = s.Length;

            while (i < length)
            {
                char c = s[i];
                if (insideScript)
                {
                    if (i + 1 < length)
                    {
                        if (c.Equals('<') && s[i + 1].Equals('/'))
                        {
                            insideScript = false;
                            insideTag = true;
                        }
                        i++;
                        continue;
                    }
                    else
                        break;
                }
                if (c.Equals('<') && insideTag == false)
                {
                    insideTag = true;
                    if (i + 2 < length)
                    {
                        if (s[i + 1].Equals('s') && s[i + 2].Equals('c'))
                            insideScript = true;
                        else
                            insideScript = false;
                    }
                    i++;
                    continue;
                }
                else if (c.Equals('>') && insideTag == true)
                {
                    insideTag = false;
                    i++;
                    continue;
                }

                if (!(insideTag))
                    builder.Append(c.ToString());
                i++;
            }
            return builder.ToString();
        }

        public void WriteToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    writer.Write(_RawHTML);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                using (StreamWriter writer = new StreamWriter("stripped.txt"))
                {
                    writer.Write(_StrippedHTML);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }

    public class SiteSearchResult
    {
        public WebSite WebSiteSearched { get; set; }

        public string Word { get; set; }

        public int Occurences { get; set; }

        public MatchCollection Matches { get; set; }

        public SiteSearchResult(WebSite siteSearched, string forWord)
        {
            this.WebSiteSearched = siteSearched;
            this.Word = forWord;
        }
    }
}
