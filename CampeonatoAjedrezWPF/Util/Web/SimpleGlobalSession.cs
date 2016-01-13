using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public class SimpleGlobalSession : IGlobalSession
    {
        private IWebClient _web;
        private static SimpleGlobalSession current;
        private string _id;
        private string _usuario;
        private string _pass;

        public IWebClient Web
        {
            get
            {
                return _web;
            }

            set
            {
                _web = value;
            }
        }
        public string id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                    throw new Exception("Sesion no Iniciada");
                else
                    return _id;
            }

            set
            {
                _id = value;
            }
        }
        public string usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }
        public string pass
        {
            get
            {
                return _pass;
            }

            set
            {
                _pass = value;
            }
        }

        public SimpleGlobalSession(IWebClient _web)
        {
            current = new SimpleGlobalSession();
            current.Web = _web;
            this.Web = _web;
        }
        private SimpleGlobalSession() { }

        public void login(string usr, string pass)
        {
            try
            {
                usuario = usr;
                this.pass = pass;
                CrendencialBasic basic = new CrendencialBasic() { User = usr, Pass = pass };
                current.Web.Credencial = basic;
                var task = Web.GetAsync<dynamic>("api/securityapi", "application/json");
                task.Wait();
                var salida = task.Result;
                id = salida.Id as string;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void logout()
        {
            try
            {
                CrendencialBasic basic = new CrendencialBasic() { User = this.usuario, Pass = this.pass };
                Web.Credencial = basic;
                var task = Web.DeleteAsync<String>("api/securityapi?idSession=" + this.id, "application/json");
                task.Wait();
                this.id = null;
                this.usuario = null;
                this.pass = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool checkConnection()
        {
            try
            {
                CrendencialBasic basic = new CrendencialBasic() { User = usuario, Pass = pass };
                Web.Credencial = basic;
                var task = Web.GetAsync<String>("api/securityapi?idSession=" + id, "application/json");
                task.Wait();
                return task.Result == id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool checkConnection(string i, string us, string pa)
        {
            try
            {
                usuario = us;
                this.pass = pa;
                id = i;
                CrendencialBasic basic = new CrendencialBasic() { User = us, Pass = pa };
                Web.Credencial = basic;
                var task = Web.GetAsync<String>("api/securityapi?idSession=" + id, "application/json");
                task.Wait();
                return task.Result == id;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}