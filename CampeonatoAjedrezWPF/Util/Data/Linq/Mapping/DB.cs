using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace Data.Linq.Mapping
{
    public class DB : DataContext, IContexto
    {
        public Table<Alojamiento> Alojamiento;
        public Table<Arbitro> Arbitro;
        public Table<Campeonato> Campeonato;
        public Table<Historial> Historial;
        public Table<Hotel> Hotel;
        public Table<Jugador> Jugador;
        public Table<Localidad> Localidad;
        public Table<Participante> Participante;
        public Table<Partida> Partida;
        public Table<PartidaJugador> PartidaJugador;
        public Table<Telefono> Telefono;

        public DB(string ConnString) : base(new MySql.Data.MySqlClient.MySqlConnection(ConnString)) { }

        public void beginTransaction()
        {

            if (this.Connection.State == ConnectionState.Closed)
                this.Connection.Open();
            this.Transaction = this.Connection.BeginTransaction();
        }

        public void commitTransaction()
        {
            this.Transaction.Commit();
        }

        public DbConnection getConexion()
        {
            return this.Connection;
        }

        public void Refresh()
        {
            var a = this.GetChangeSet().Updates;
            foreach (var b in a)
            {
                this.Refresh(RefreshMode.OverwriteCurrentValues, b);
            }
            var c = this.GetChangeSet().Inserts;
            foreach (var d in c)
            {
                this.GetTable(d.GetType()).DeleteOnSubmit(d);
            }
        }

        public IContexto reload(string cn)
        {
            return new DB(cn);
        }

        public void rollbackTransaction()
        {
            this.Transaction.Rollback();
        }
    }
}
