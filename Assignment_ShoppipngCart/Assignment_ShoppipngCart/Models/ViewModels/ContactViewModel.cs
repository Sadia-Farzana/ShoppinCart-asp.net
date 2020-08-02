using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_ShoppipngCart.Models.ViewModels
{
    
        public class ContactViewModel
        {
            public string Email { get { return "info@halloweenstore.com"; } }
            public string Phone { get { return "1-800-123-4567"; } }
            public string Fax { get { return "1-800-890-1234"; } }
            public string Address { get { return "1234 Main Street, Anytown, USA"; } }
            public List<string> SocialMediaUrls
            {
                get
                {
                    List<string> urls = new List<string>();
                    urls.Add("http://www.facebook.com/halloweenstore");
                    urls.Add("http://www.twitter.com/halloweenstore");
                    return urls;
                }
            }
        }
    
}