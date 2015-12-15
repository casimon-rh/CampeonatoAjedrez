using Data.Interfaz;
using Data.Linq.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAjedrezWPF.Logic
{
    public class CatalogoHotel : ICatalogos<Hotel>
    {
        public IDaoCrud<Hotel> dao { get; set; }
        
        
        public void inserta(Hotel aux)
        {
            try
            {
                dao.inserta(aux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Hotel> getAll()
        {
            try
            {
                return dao.consulta();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void borrar(Hotel aux)
        {
            try
            {
                dao.borra(aux);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void update()
        {

            try
            {
                dao.commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void refresh()
        {
            try
            {
                dao.getContexto().Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
