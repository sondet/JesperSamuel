using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using MelloLibrary;

namespace NewspaperLibrary
{
    public delegate void SearchCompleteEventHandler();

    public class NewspaperConnection
    {
        private WebClient mClient;

        public List<Newspaper> Newspapers { get; set; }


        public NewspaperConnection()
        {
            mClient = new WebClient();
        }

        public void SearchNewspaperForKeywords(Newspaper paper, Competition competition)
        {
            string paperStr = mClient.DownloadString(paper.Uri.ToString());
            Console.WriteLine(paperStr);
        }


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

        /// <summary>
        /// Constructor - Creates a Newspaper object from an url. Will throw exception
        /// </summary>
        /// <param name="urlString"></param>
        public Newspaper(string urlString)
        {
            try
            {
                urlString = checkUrlString(urlString);
                mUri = new Uri(urlString);
                mName = getNameFromUrl(urlString);
            }
            catch (Exception e)
            {
                mUri = null;
                mName = null;
                throw e;
            }
        }

        /// <summary>
        /// Method to check if the string is a valid URL. If the string is valid but not on standard form
        /// it will convert it. Throws exceptions if wrong format or invalid string.
        /// </summary>
        /// <remarks>Standard form: http://www.url.se</remarks>
        /// <param name="urlString">Standard form: http://www.url.se</param>
        /// <returns>Url string on standard form</returns>
        private string checkUrlString(string urlString)
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
                Console.WriteLine(urlString);
                return urlString;    
            }
            else
            {
                Console.WriteLine(String.Format("Fel format: {0}", urlString));
                throw new ArgumentException("Incorrect format for url");
            }
        }

        /// <summary>
        /// To be used after <see cref="TNewspaper.checkUrlString"/> has been used on the string if it is not on standard form.
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        private string getNameFromUrl(string urlString)
        {
            if (!sHttpRgx.IsMatch(urlString)) throw new ArgumentException("Not on standard form");
            string noHttp = urlString.Substring(11);
            string[] split = noHttp.Split(new char[1]{'.'});
            if (split[0].Length < 2) throw new ArgumentException("URL too short");
            string name = char.ToUpper(split[0][0]) + split[0].Substring(1);
            Console.WriteLine(name);
            return name;
        }

        public static List<Newspaper> CreateNewspapersFromFile(string filePath)
        {
            List<Newspaper> papers = new List<Newspaper>();
            //StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\Newspapers.txt"
            return papers;
        }
        
    }
}

