using Data.Interfaz;
using Data.Linq.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.DAO
{
    public class ParticipanteDAO : IParticipanteDAO
    {
        public DB data { get; set; }

        public Participante getParticipante(int id)
        {
            try
            {
                return data.Participante.Select(x => x).Where(x => x.id_participante == id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Arbitro> getListaArbitros()
        {
            try
            {
                return data.Arbitro.Select(x => x).ToList();// new Arbitro() { idarbitro = x.idarbitroparticipante = getParticipante(x.idarbitro) }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Jugador> getListaJugador()
        {
            try
            {
                return data.Jugador.Select(x => x).ToList();// new Jugador() { idjugador = x.idjugador, nivel = x.nivel, participante = getParticipante(x.idjugador) }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool isArbitro( Participante p)
        {
            return (getListaArbitros().Where(x => x.idarbitro == p.id_participante).Any());
        }

        public bool isJugador(Participante p)
        {
            return (getListaJugador().Where(x => x.idjugador== p.id_participante).Any());
        }
    }
}
