using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDWebFetchService
{
    /// <summary>
    /// This class is used to hold information sent out
    /// to Android. It can represent information about
    /// an attraction or information about a guide.
    /// </summary>
    public class WebFragment
    {
        /// <summary>
        /// Get/set the fragment url.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Get/set the fragment description.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Get/set the fragment html content.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Parameter-less constructor to allow serialization.
        /// </summary>
        public WebFragment()
        {
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        /// <param name="url">Fragment url.</param>
        /// <param name="description">Fragment description.</param>
        /// <param name="content">Fragment content.</param>
        public WebFragment(string url, string description, string content)
        {
            this.url = url;
            this.description = description;
            this.content = content;
        }
    }
}