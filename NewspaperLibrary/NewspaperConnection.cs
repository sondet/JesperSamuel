using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NewspaperLibrary
{
    public class NewspaperConnection
    {
    }

    public class Newspaper
    {
        private static readonly string sHttpPattern = "^(http://)?(www" + Regex.Escape(".") + ")?[A-Za-z]+" + Regex.Escape(".") + "[A-Za-z]+";
        private static readonly Regex sHttpRgx = new Regex(sHttpPattern);

        private Uri mUri;
        public Uri Uri
        {
            get { return mUri; }
            set { mUri = value; }
        }

        private string mName;
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public Newspaper(string urlString)
        {
            if (urlString == null) throw new ArgumentNullException();
            if (urlString.Length < 4) throw new ArgumentException();
            if (sHttpRgx.IsMatch(urlString))
            {

                if (!urlString.Substring(0, 4).Contains("http"))
                {
                    if (!urlString.Substring(0, 4).Contains("www.")) urlString = "www." + urlString;
                    urlString = "http://" + urlString;
                }
                
                mUri = new Uri(urlString);
                Console.WriteLine(urlString);
            }
            else
            {
                Console.WriteLine(String.Format("Fel format: {0}", urlString));
            }  
        }
        
    }
}

