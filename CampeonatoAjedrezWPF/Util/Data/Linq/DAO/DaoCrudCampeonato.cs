using Data.Linq.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.DAO
{
    public class DaoCrudCampeonato<T> : IDaoCrudLinq<T, DB>
    {
        public override List<T> consulta()
        {
            var x = (from T algo in BD.GetTable(typeof(T)) select algo).ToList<T>();
            return x;
        }

        public override void inserta(T obj)
        {
            try
            {
                Type ti = typeof(T);
                ITable tabla = BD.GetTable(ti);
                tabla.InsertOnSubmit(obj);
                commit();
            }
            catch (SqlException sql)
            {

                Type tipo = typeof(T);
                //throw new DaoException(sql, tipo);
                throw sql;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void inserta(List<T> lista)
        {
            try
            {
                Type ti = typeof(T);
                ITable tabla = BD.GetTable(ti);
                tabla.InsertAllOnSubmit(lista);
                commit();
            }
            catch (SqlException sql)
            {

                Type tipo = typeof(T);
                //throw new DaoException(sql, tipo);
                throw sql;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override void modifica(T obj)
        {
            throw new NotImplementedException();
        }

        public override void borra(T obj)
        {
            try
            {
                Type ti = typeof(T);
                ITable tabla = BD.GetTable(ti);
                tabla.DeleteOnSubmit(obj); commit();
            }
            catch (SqlException sql)
            {

                Type tipo = typeof(T);
                //throw new DaoException(sql, tipo);
                throw sql;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override void borraTodo()
        {
            throw new NotImplementedException();
        }

        public override void commit()
        {
            try
            {
                BD.SubmitChanges();
            }
            catch (SqlException sql)
            {

                Type tipo = typeof(T);
                //throw new DaoException(sql, tipo);
                throw sql;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
