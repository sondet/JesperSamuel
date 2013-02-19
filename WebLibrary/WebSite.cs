using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace WebLibrary
{   
    /// <summary>
    /// A class representing a website
    /// </summary>
    public class WebSite
    {
        /// <summary>
        /// Uri of the <seealso cref="WebSite"/>
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Raw HTML content of the WebSite
        /// </summary>
        public string RawContent { get; private set; }

        /// <summary>
        /// Raw HTML content of the WebSite in a StreamReader.
        /// Returns null if RawContent is null or error when creating stream
        /// </summary>
        public StreamReader RawContentStreamReader {
            get
            {
                if (string.IsNullOrWhiteSpace(this.RawContent))
                    return null;
                MemoryStream stream = null;
                try
                {
                    byte[] bytes = Encoding.Default.GetBytes(this.RawContent);
                    stream = new MemoryStream(bytes);
                }
                catch (Exception)
                {
                    return null;
                }
                if (stream != null)
                    return new StreamReader(stream);
                return null;
            }
        }

        /// <summary>
        /// The request sent by DownloadRawContent method
        /// </summary>
        public HttpWebRequest HttpWebRequest { get; private set; }

        /// <summary>
        /// The respone gotten by DownLoadRawContent method
        /// </summary>
        public HttpWebResponse HttpWebResponse { get; private set; }

        private WebSite()
        {
            RawContent = "";
        }
        /// <summary>
        /// Creates a WebSite object, TODO: throw exceptions when failed to create URI
        /// </summary>
        /// <param name="url"></param>
        public WebSite(string url)
            :this()
        {
            try
            {
                if (!url.Contains("://"))
                    url = "http://" + url;

                Uri u;
                bool result = Uri.TryCreate(url, UriKind.Absolute, out u);

                if (!result)
                    throw new ArgumentException("Could not create Uri");

                if (!(u.Scheme == Uri.UriSchemeHttp || u.Scheme == Uri.UriSchemeHttps))
                    throw new ArgumentException("Not a http or https URI");
                Uri = u;
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

        /// <summary>
        /// Creates a WebSite object, TODO: throw exceptions when failed to create URI
        /// </summary>
        /// <param name="url"></param>
        public WebSite(Uri url)
            :this()
        {
            try
            {
                if (!(url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps))
                    throw new ArgumentException("Not a http or https URI");
                Uri = url;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Tries to download raw HTML from the WebSite URI and then sets
        /// RawContent, HttpWebRequest and HttpWebResponse properties.
        /// </summary>
        public void DownloadRawContent()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                request = HttpWebRequest.CreateHttp(Uri.AbsoluteUri);
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string rawHtml = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(rawHtml))
                        RawContent = rawHtml;
                    reader.Close();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (request != null)
                    this.HttpWebRequest = request;
                if (response != null)
                    this.HttpWebResponse = response;
            }
        }

    }
}
