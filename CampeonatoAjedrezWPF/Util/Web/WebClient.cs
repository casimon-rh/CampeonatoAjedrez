using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public class WebClient : IWebClient
    {

        public String URL { get; set; }
        public ICredencial Credencial { get; set; }
        public HttpClient Client { get; set; }

        private HttpContent getData(IDictionary<string, object> Data)
        {
            String jsonObject;
            dynamic obj = new System.Dynamic.ExpandoObject();
            foreach (var aux in Data)
                (obj as IDictionary<string, Object>).Add(aux.Key, aux.Value);

            jsonObject = JsonConvert.SerializeObject(obj);
            return new StringContent(jsonObject);
        }

        private void setHeaders(String type)
        {
            Client = new HttpClient();
            if (Credencial != null)
                Credencial.setCredencial(Client);
            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Clear();

            if (!String.IsNullOrEmpty(type))
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(type));

        }

        public async Task<HttpResponseMessage> PutAsyncFile(String accion, IDictionary<string, string> data, string paramFile, string file)
        {

            if (File.Exists(file))
            {
                setHeaders("");

                var auxFileNameAux = file.Split(@"\".ToArray());
                var fileName = "";

                if (auxFileNameAux.Length > 0)
                    fileName = auxFileNameAux[auxFileNameAux.Length - 1];
                else
                    fileName = file;

                var multiPart = new MultipartFormDataContent();
                var boundary = multiPart.Headers.ContentType.Parameters.First(x => x.Name == "boundary");
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);

                foreach (var value in data)
                    multiPart.Add(new StringContent(value.Value), value.Key);

                boundary.Value = boundary.Value.Replace("\"", "");

                var sc = new StreamContent(fs);
                sc.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                sc.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "upload",
                    FileName = fileName
                };

                var filenameHeader = sc.Headers.ContentDisposition.Parameters.First(x => x.Name == "filename");
                if (!filenameHeader.Value.StartsWith("\""))
                {
                    filenameHeader.Value = string.Format("\"{0}\"", filenameHeader.Value);
                }
                multiPart.Add(sc);



                return await Client.PostAsync(accion, multiPart);

            }
            else
                return null;

        }

        public async Task<T> PutAsync<T>(String accion, String type, IDictionary<string, object> Data = null)
        {
            HttpContent content = null;
            setHeaders(type);
            if (Data != null)
                content = getData(Data);
            HttpResponseMessage response = await Client.PutAsync(accion, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return Task.Factory.StartNew(() => response.readAsync<T>()).Result;
            else
                throw new Exception("");

        }

        public async Task<T> PostAsync<T>(String accion, String type, IDictionary<string, object> Data = null)
        {
            HttpContent content = null;
            setHeaders(type);
            if (Data != null)
                content = getData(Data);

            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue(type);
            HttpResponseMessage response = await Client.PostAsync(accion, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return Task.Factory.StartNew(() => response.readAsync<T>()).Result;
            else
                throw new Exception("");
        }

        public async Task<T> DeleteAsync<T>(String accion, String type)
        {
            setHeaders(type);
            HttpResponseMessage response = await Client.DeleteAsync(accion).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return Task.Factory.StartNew(() => response.readAsync<T>()).Result;
            else
                throw new Exception(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> GetAsync<T>(String accion, String type)
        {
            setHeaders(type);
            HttpResponseMessage response = await Client.GetAsync(accion).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return Task.Factory.StartNew(() => response.readAsync<T>()).Result;
            else
                throw new Exception("");
        }

        /// <summary>
        /// Writes multi part HTTP POST request. Author : Farhan Ghumra
        /// </summary>
        private void WriteMultipartForm(Stream s, string boundary, IDictionary<string, string> data, string fileName, string fileContentType, byte[] fileData)
        {
            /// The first boundary
            byte[] boundarybytes = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
            /// the last boundary.
            byte[] trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "–-\r\n");
            /// the form data, properly formatted
            string formdataTemplate = "Content-Dis-data; name=\"{0}\"\r\n\r\n{1}";
            /// the form-data file upload, properly formatted
            string fileheaderTemplate = "Content-Dis-data; name=\"{0}\"; filename=\"{1}\";\r\nContent-Type: {2}\r\n\r\n";

            /// Added to track if we need a CRLF or not.
            bool bNeedsCRLF = false;

            if (data != null)
            {
                foreach (string key in data.Keys)
                {
                    /// if we need to drop a CRLF, do that.
                    if (bNeedsCRLF)
                        WriteToStream(s, "\r\n");

                    /// Write the boundary.
                    WriteToStream(s, boundarybytes);

                    /// Write the key.
                    WriteToStream(s, string.Format(formdataTemplate, key, data[key]));
                    bNeedsCRLF = true;
                }
            }

            /// If we don't have keys, we don't need a crlf.
            if (bNeedsCRLF)
                WriteToStream(s, "\r\n");

            WriteToStream(s, boundarybytes);
            WriteToStream(s, string.Format(fileheaderTemplate, "file", fileName, fileContentType));
            /// Write the file data to the stream.
            WriteToStream(s, fileData);
            WriteToStream(s, trailer);
        }

        /// <summary>
        /// Writes string to stream. Author : Farhan Ghumra
        /// </summary>
        private void WriteToStream(Stream s, string txt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(txt);
            s.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Writes byte array to stream. Author : Farhan Ghumra
        /// </summary>
        private void WriteToStream(Stream s, byte[] bytes)
        {
            s.Write(bytes, 0, bytes.Length);
        }

        public IWebClient Clone()
        {
            return this.MemberwiseClone() as WebClient;
        }
    }


    public static class WebClientExtesions
    {
        public static T readAsync<T>(this HttpResponseMessage response)
        {
            var task = response.Content.ReadAsStringAsync();
            String valor = "";
            task.Wait();
            valor = task.Result;
            return JsonConvert.DeserializeObject<T>(valor);
        }
    }
}
