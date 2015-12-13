using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.DAO
{
    /// <summary>
    /// Clase Abstracta que implementa IDaoCrud utilizando Linq.
    /// Sea T la tabla y P la Base de Datos que implementa IContexto
    /// </summary>
    public abstract class IDaoCrudLinq<T, P> : IDaoCrud<T> where P : IContexto
    {
        private List<string> _errores;
        /// <summary>
        /// Lista de los errores cachados en la operacion (Pensada para reportes)
        /// </summary>
        public List<string> Errores
        {
            get { return _errores; }
            set { _errores = value; }
        }
        private P _BD;
        ///<summary>
        ///La base de Datos
        ///</summary>
        public P BD
        {
            get { return _BD; }
            set { _BD = value; }
        }
        public abstract List<T> consulta();
        public abstract void inserta(T obj);
        public abstract void inserta(List<T> lista);
        /// <summary>
        /// No está correctamente implementada para linq :c
        /// </summary>
        /// <param name="obj">El objeto a modificar</param>
        public abstract void modifica(T obj);
        public abstract void borra(T obj);
        public abstract void borraTodo();
        public abstract void commit();

        public IContexto getContexto()
        {
            return BD;
        }


        public void restartConnection(string cn)
        {
            BD = (P)BD.reload(cn);
        }
    }
}
