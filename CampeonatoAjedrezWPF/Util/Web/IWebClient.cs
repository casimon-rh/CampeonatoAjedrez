using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public interface IWebClient
    {
        ICredencial Credencial { get; set; }
        Task<T> PutAsync<T>(String accion, String type, IDictionary<string, object> Data = null);
        Task<T> PostAsync<T>(String accion, String type, IDictionary<string, object> Data = null);
        Task<T> GetAsync<T>(String accion, String type);
        Task<T> DeleteAsync<T>(String accion, String type);
        Task<HttpResponseMessage> PutAsyncFile(String accion, IDictionary<string, string> data, string paramFile, string file);
        IWebClient Clone();
    }
}
