using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public interface ICredencial
    {
        void setCredencial(HttpClient httpClient);
        void setCredencial(HttpWebRequest httpRequest);
    }
    public class CrendencialBasic : ICredencial
    {
        public String User { get; set; }
        public String Pass { get; set; }

        public String Base64
        {
            get
            {
                return Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(this.User + ":" + this.Pass));
            }
        }

        public void setCredencial(HttpClient httpClient)
        {

            httpClient.DefaultRequestHeaders.Remove(HttpRequestHeader.Authorization.ToString());
            httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), string.Format(
               "Basic {0}", Base64));
        }


        public void setCredencial(HttpWebRequest httpRequest)
        {
            httpRequest.Headers.Add(HttpRequestHeader.Authorization.ToString(), string.Format(
               "Basic {0}", Base64));
        }
    }
    public class CurrentSession
    {
        public String id { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
    }
}
