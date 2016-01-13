using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web;

namespace Data.Api.DAO
{
    public class IDaoCrudApi<T> : IDaoCrud<T> where T : IEntidad
    {

        private IGlobalSession Sesion;

        public IDaoCrudApi(IGlobalSession s)
        {
            this.Sesion = s;
        }

        public void borra(T obj)
        {
            try
            {
                IEntidad o = obj as IEntidad;
                var a = Sesion.Web.DeleteAsync<T>("api/" + o.NombreTabla + "Api/" + o.llavePrimaria, "application/json");
                a.Wait();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void borraTodo()
        {
            throw new NotImplementedException();
        }

        public void commit()
        {
            
        }

        public List<T> consulta()
        {
            try
            {
                var a = Sesion.Web.GetAsync<List<T>>("api/" + (default(T)).NombreTabla + "Api/" ,"application/json");
                a.Wait();
                return a.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IContexto getContexto()
        {
            throw new NotImplementedException();
        }

        public void inserta(List<T> lista)
        {
            try
            {
                foreach (IEntidad o in lista)
                {
                    IDictionary<string, object> dic = new Dictionary<string, object>() { { o.NombreTabla, o } };
                    var a = Sesion.Web.PostAsync<T>("api/" + o.NombreTabla + "Api/", "application/json", dic);
                    a.Wait();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void inserta(T obj)
        {
            try
            {
                IDictionary<string, object> dic = new Dictionary<string, object>() { { obj.NombreTabla, obj } };
                var a = Sesion.Web.PostAsync<T>("api/" + obj.NombreTabla + "Api/", "application/json", dic);
                a.Wait();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void modifica(T obj)
        {
            try
            {
                IDictionary<string, object> dic = new Dictionary<string, object>() { { obj.NombreTabla, obj } };
                var a = Sesion.Web.PutAsync<T>("api/" + obj.NombreTabla + "Api/"+obj.llavePrimaria, "application/json", dic);
                a.Wait();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void restartConnection(string cn)
        {
            throw new NotImplementedException();
        }
    }
}
