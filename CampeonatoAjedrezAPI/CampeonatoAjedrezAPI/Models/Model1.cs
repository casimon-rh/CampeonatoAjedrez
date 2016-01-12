namespace CampeonatoAjedrezAPI.Areas
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DB")
        {
        }

        public virtual DbSet<ARBITRO> ARBITRO { get; set; }
        public virtual DbSet<CAMPEONATO_ANTERIOR> CAMPEONATO_ANTERIOR { get; set; }
        public virtual DbSet<HOTEL> HOTEL { get; set; }
        public virtual DbSet<HOTEL_TELEFONO> HOTEL_TELEFONO { get; set; }
        public virtual DbSet<JUGADOR> JUGADOR { get; set; }
        public virtual DbSet<LOCALIDAD> LOCALIDAD { get; set; }
        public virtual DbSet<PARTICIPANTE> PARTICIPANTE { get; set; }
        public virtual DbSet<PARTIDA> PARTIDA { get; set; }
        public virtual DbSet<CAMPEONATO_ANTERIOR_PARTICIPANTE> CAMPEONATO_ANTERIOR_PARTICIPANTE { get; set; }
        public virtual DbSet<HOTEL_PARTICIPANTE> HOTEL_PARTICIPANTE { get; set; }
        public virtual DbSet<PARTIDA_JUGADOR> PARTIDA_JUGADOR { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARBITRO>()
                .HasMany(e => e.PARTIDA)
                .WithRequired(e => e.ARBITRO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAMPEONATO_ANTERIOR>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.NOMBREHOTEL)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.DIRNUM)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.DIRCALLE)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL>()
                .Property(e => e.DIRCP)
                .IsUnicode(false);

            modelBuilder.Entity<HOTEL_TELEFONO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<LOCALIDAD>()
                .Property(e => e.NOMLOCALIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<LOCALIDAD>()
                .HasMany(e => e.PARTICIPANTE)
                .WithRequired(e => e.LOCALIDAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PARTICIPANTE>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PARTICIPANTE>()
                .Property(e => e.APPATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<PARTICIPANTE>()
                .Property(e => e.APMATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<PARTICIPANTE>()
                .HasOptional(e => e.ARBITRO)
                .WithRequired(e => e.PARTICIPANTE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PARTICIPANTE>()
                .HasOptional(e => e.JUGADOR)
                .WithRequired(e => e.PARTICIPANTE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CAMPEONATO_ANTERIOR_PARTICIPANTE>()
                .Property(e => e.TIPO)
                .IsUnicode(false);
        }
    }
}
