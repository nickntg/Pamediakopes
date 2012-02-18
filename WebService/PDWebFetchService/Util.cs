using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace PDWebFetchService
{
    /// <summary>
    /// This class contains utility methods used
    /// by the web service, mostly dealing with
    /// stripping content from an html page.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Returns the content of a url.
        /// </summary>
        /// <param name="url">Url to retrieve.</param>
        /// <returns>Url content.</returns>
        public static string GetWebContent(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)" +
                                               " (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 2.0.50727)";
                return System.Text.Encoding.UTF8.GetString(client.DownloadData(url));
            }
        }

        /// <summary>
        /// Parses the content of a guide to extract
        /// what we want to display on Android about
        /// this guide.
        /// </summary>
        /// <param name="content">Original guide content.</param>
        /// <returns>Final guide content.</returns>
        public static String ParseGuide(string content)
        {
            // The object of the stripping is to keep only guide
            // information and some style info, but remove the
            // rest before returning it to the caller.
            content = RemoveContent(content, "<!-- Header -->", "<div id=\"NetvolutionPageContent\">");
            try
            {
                content = RemoveContent(content, "<div id=\"bookhotel\">", "</body>");
            }
            catch
            {
                content = RemoveContent(content, "<div id=\"hotelsNavigationMenu\">", "</body>");
            }
            return content;
        }

        /// <summary>
        /// Parses the content of a page to remove
        /// everything that does not reside between
        /// two tags. Useful to extract the description
        /// of an attraction.
        /// </summary>
        /// <param name="content">Original page content.</param>
        /// <param name="startSentinel">Starting tag.</param>
        /// <param name="endSentinel">Ending tag.</param>
        /// <returns>Information between tags.</returns>
        public static String ParseFragment(string content,
            string startSentinel,
            string endSentinel)
        {
            return Parse(content, startSentinel, endSentinel);
        }

        /// <summary>
        /// Parses the content of a page in order to
        /// create a list of web fragment instnaces.
        /// </summary>
        /// <param name="content">Original page content.</param>
        /// <param name="startSentinel">Starting sentinel that signals the
        /// beginning of the info to extract.</param>
        /// <param name="endSentinel">Ending sentinel that signals the end
        /// of the info to extract.</param>
        /// <param name="recordStartSentinel">Starting sentinel that signals
        /// the beginning of information that should be in a single web
        /// fragment.</param>
        /// <param name="recordEndSentinel">Ent sentinel that signals the end
        /// of information that should be in a single web fragment.</param>
        /// <param name="startTag">Tag marking the beginning of information
        /// of the web fragment.</param>
        /// <param name="endTag">Tag marking the end of information of the
        /// web fragment.</param>
        /// <returns>List with parsed web fragments.</returns>
        public static List<WebFragment> ParseFragment(string content,
            string startSentinel,
            string endSentinel,
            string recordStartSentinel,
            string recordEndSentinel,
            string startTag,
            string endTag)
        {
            List<WebFragment> list = new List<WebFragment>();

            int startPos = content.IndexOf(startSentinel), endPos = content.IndexOf(endSentinel, startPos);

            string searchable = content.Substring(startPos, endPos-startPos);

            int lPos = searchable.IndexOf(recordStartSentinel), rPos = 0;
            while (lPos > 0)
            {
                lPos += recordStartSentinel.Length;
                rPos = searchable.IndexOf(recordEndSentinel, lPos);
                string parseable = searchable.Substring(lPos, rPos - lPos);
                list.Add(new WebFragment(ParseHref(parseable),
                    Parse(parseable, startTag, endTag),
                    string.Empty));

                lPos = searchable.IndexOf(recordStartSentinel, rPos);
            }

            return list;
        }

        // Get the url contained in the content.
        private static string ParseHref(string content)
        {
            return Parse(content, "href=\"", "\">");
        }

        // Parse a content based on starting and ending tags.
        private static string Parse(string content, string starting, string ending)
        {
            int l = content.IndexOf(starting);
            int r = content.IndexOf(ending, l);
            return content.Substring(l + starting.Length, r - l - starting.Length);
        }

        // Removes content based on starting and ending tags.
        private static string RemoveContent(string content, string starting, string ending)
        {
            int l = content.IndexOf(starting);
            int r = content.IndexOf(ending, l);
            return content.Remove(l, r - l);
        }
    }
}