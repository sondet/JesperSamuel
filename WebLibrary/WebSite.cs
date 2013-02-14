using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebLibrary
{   
    /// <summary>
    /// A class representing a website
    /// </summary>
    public class WebSite
    {
        private Uri _Uri;
        
        /// <summary>
        /// Uri of the <seealso cref="WebSite"/>
        /// </summary>
        public Uri Uri { get { return _Uri; } }
        
        public WebSite(string url)
        {
            try
            {
                if (!url.Contains("://"))
                    url = "http://" + url;

                //Använd regex att kontrollera
                Uri u;
                bool result = Uri.TryCreate(url, UriKind.Absolute, out u);

                if (!result)
                    throw new ArgumentException("Could not create Uri");

                if (!(u.Scheme == Uri.UriSchemeHttp || u.Scheme == Uri.UriSchemeHttps))
                    throw new ArgumentException("Not a http or https URI");
                _Uri = u;
            }
            catch (UriFormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
