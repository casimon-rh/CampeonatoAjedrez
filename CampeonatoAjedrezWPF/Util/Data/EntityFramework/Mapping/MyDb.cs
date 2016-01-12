using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
using System.Data.Entity;

namespace Data.EntityFramework.Mapping
{
    public partial class MyDb : DbContext
    {
        public MyDb()
            : base("name=MyDb")
        {
        }
        public virtual DbSet<Alojamiento> Alojamiento { get; set; }
        public virtual DbSet<Arbitro> Arbitro { get; set; }
        public virtual DbSet<Campeonato> Campeonato { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<Partida> Partida { get; set; }
        public virtual DbSet<PartidaJugador> PartidaJugador { get; set; }
        public virtual DbSet<Telefono> Telefono { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localidad>().
                HasMany(e => e.Participantes)
                .WithRequired(e => e.localidad)
                .HasForeignKey(e => e.idlocalidad);

            modelBuilder.Entity<Campeonato>()
                .HasMany(e => e.Historial)
                .WithRequired(e => e.Campeonato)
                .HasForeignKey(e => e.idcampeonato);

            modelBuilder.Entity<Participante>()
                .HasMany(e => e.Alojados)
                .WithRequired(e => e.Participante)
                .HasForeignKey(e => e.id_participante);

            modelBuilder.Entity<Participante>()
                .HasMany(e => e.Historial)
                .WithRequired(e => e.Participante)
                .HasForeignKey(e => e.id_participante);
            modelBuilder.Entity<Participante>()
                .HasOptional(e => e.Jugador)
                .WithOptionalPrincipal();

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Alojados)
                .WithRequired(e => e.Hotel)
                .HasForeignKey(e => e.id_hotel);
        }
    }
}
