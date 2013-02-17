using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace WebLibrary
{
    /// <summary>
    /// Class that searches a site for keywords
    /// </summary>
    public class SiteSearcher
    {
        

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

            Regex rgx = new Regex(word);

            MatchCollection matches = rgx.Matches(rawHtml);
            if (matches.Count > 0)
            {
                return new SiteSearchResult(webSite,word) {Occurences = matches.Count};
            }
            return new SiteSearchResult(webSite,word) {Occurences = 0};
        }

    public class SiteSearchResult
    {
        public WebSite WebSiteSearched { get; set; }

        public string Word { get; set; }

        public int Occurences { get; set; }

        public SiteSearchResult(WebSite siteSearched, string forWord)
        {
            this.WebSiteSearched = siteSearched;
            this.Word = forWord;
        }
    }

}
