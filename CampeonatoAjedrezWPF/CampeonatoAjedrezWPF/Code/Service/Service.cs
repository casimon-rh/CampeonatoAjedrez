using Data.Interfaz;
using Data.Linq.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAjedrezWPF
{
    public static class Service
    {
        private static IParticipanteDAO daoParticipante;
        private static DaoDictionary diccionario;

        public static IParticipanteDAO getdaoParticipante()
        {
            try
            {
                if (daoParticipante == null)
                {
                    daoParticipante = Spring.Context.Support.ContextRegistry.GetContext().GetObject("DaoParticipantes") as IParticipanteDAO;
                }
                return daoParticipante;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DaoDictionary getdaoDiccionario()
        {
            try
            {
                if (diccionario == null)
                {
                    diccionario = Spring.Context.Support.ContextRegistry.GetContext().GetObject("DiccionarioCRUD") as DaoDictionary;
                }
                return diccionario;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
