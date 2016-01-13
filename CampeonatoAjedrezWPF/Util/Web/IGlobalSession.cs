using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public interface IGlobalSession
    {
        string id { get; set; }
        string usuario { get; set; }
        string pass { get; set; }
        IWebClient Web { get; set; }
        void login(string usr, string pass);
        void logout();
        bool checkConnection();
        bool checkConnection(string us, string pa, string i);
    }
}
