using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaDeJugadores.Web.EF
{
    public partial class sistema_de_jugadoresContext : DbContext
    {
        public sistema_de_jugadoresContext()
        {
        }

        public sistema_de_jugadoresContext(DbContextOptions<sistema_de_jugadoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Jugador> Jugadors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IJ5MHT8;Database=sistema_de_jugadores;Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipo");

                entity.Property(e => e.EquipoId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.ToTable("Jugador");

                entity.Property(e => e.JugadorId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Jugadors)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jugador__EquipoI__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
