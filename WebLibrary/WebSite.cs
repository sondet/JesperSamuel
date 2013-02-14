using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary
{   
    /// <summary>
    /// A class representing a website
    /// </summary>
    class WebSite
    {
        private Uri _Uri;
        /// <summary>
        /// Uri of the <seealso cref="WebSite"/>
        /// </summary>
        public Uri Uri { get { return _Uri; } }
        
        public WebSite(string uri)
        {
            try
            {
                _Uri = new Uri(uri);
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
