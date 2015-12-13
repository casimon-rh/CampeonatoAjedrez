using System.Collections.Generic;
using Data.Linq.Mapping;

namespace Data.Interfaz
{
    public interface IParticipanteDAO
    {
        DB data { get; set; }

        List<Arbitro> getListaArbitros();
        List<Jugador> getListaJugador();
        Participante getParticipante(int id);
        bool isArbitro(Participante p);
        bool isJugador(Participante p);
    }
}