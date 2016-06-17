using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WcfService3
{
    public class NF
    {
        
        public string weburl;
        public string url_string()
        {
            return this.weburl;
        }
    }
    
    public class Service1 : IService1
    {
        public string[] NewsFocus(string[] topics)
        {
            // create Object and request 
            WebClient client = new WebClient();
            string tempString = null;
            string req = "http://content.guardianapis.com/search?q=";

            //Total no of strings as topic search 
            for (int i = 0; i < topics.Length; i++)
            {
                tempString += topics[i] + " ";
            }
      
            //adds topics and API Key for Guardian Content API 
            req += tempString;
            req += "&api-key=v4wdh6aevqj34q48d4pww2tp";

            //Gets the JSON response and JSON Parsing 
            string response = client.DownloadString(req);
            dynamic parsed = JObject.Parse(response);
            
            //No of Page Count for creating demo array for No of URLs
            int count = parsed.response.pageSize;

            NF[] demo = new NF[count];
            for (int i = 0; i < count; i++)
            {
                demo[i] = new NF();
                demo[i].weburl = Convert.ToString(parsed["response"]["results"][i]["webUrl"]);
            }

            string[] str = new string[count];

            for (int i = 0; i < count; i++)
            {
                str[i] = demo[i].url_string();
            }

            return str;
        }
    }
}
