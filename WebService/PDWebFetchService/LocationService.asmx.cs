using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;

namespace PDWebFetchService
{
    /// <summary>
    /// This web service retrieves information about tourist attraction and their
    /// guides from PameDiakopes.gr by using html-scraping.
    /// </summary>
    [WebService(Namespace = "http://pamediakopes.gr/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class LocationService : System.Web.Services.WebService
    {

        private const int CACHE_DURATION = 15 * 60;

        /// <summary>
        /// Returns a list of tourist attractions in Greece.
        /// </summary>
        /// <returns>List with web fragment info for the attractions.</returns>
        [WebMethod(CacheDuration = CACHE_DURATION)]
        public List<WebFragment> GetLocations()
        {
            return Util.ParseFragment(Util.GetWebContent("http://www.pamediakopes.gr/travel-guides"),
                "<h2>Ταξιδιωτικοί Οδηγοί για προορισμούς στην Ελλάδα</h2>",
                "<h2>Ακτοπλοΐα</h2>",
                "<li>", "</li>", "<span>", "</span>");
        }

        /// <summary>
        /// Returns a list of guides for a tourist attraction.
        /// </summary>
        /// <param name="url">Attraction url.</param>
        /// <returns>List of web gragments for the attraction guides.</returns>
        [WebMethod(CacheDuration = CACHE_DURATION)]
        public List<WebFragment> GetGuides(string url)
        {
            return Util.ParseFragment(Util.GetWebContent(url), 
                "<h2>Ταξιδιωτικός Οδηγός</h2>",
                "</div>",
                "<a ",
                "<br/>",
                ">", "</a>");
        }

        /// <summary>
        /// Returns the description of an attraction.
        /// </summary>
        /// <param name="url">Attraction url.</param>
        /// <returns>Attraction description.</returns>
        [WebMethod(CacheDuration = CACHE_DURATION)]
        public String GetAttractionDescription(string url)
        {
            string descr = Util.ParseFragment(Util.GetWebContent(url),
                "<div class=\"boxcontent\">",
                "</div>");

            if (descr.IndexOf("<br") > 0)
            {
                return descr.Substring(0, descr.IndexOf("<br"));
            }
            else
            {
                return descr;
            }
        }

        /// <summary>
        /// Returns an html content for an attraction guide,
        /// suitable for display to Android.
        /// </summary>
        /// <param name="url">Guide to attraction.</param>
        /// <returns>Html guide content.</returns>
        [WebMethod(CacheDuration = CACHE_DURATION)]
        public String GetGuideContent(string url)
        {
            string content = Util.ParseGuide(Util.GetWebContent(url));
            return content.Replace("src=\"/template/", "src=\"http://www.pamediakopes.gr/template/");
        }
    }
}
