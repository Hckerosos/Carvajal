using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Carvajal.Datos.Models
{
    public partial class DbVuelosContext : DbContext
    {
        public DbVuelosContext()
        {
        }

        public DbVuelosContext(DbContextOptions<DbVuelosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VueloEstado> VueloEstados { get; set; }
        public virtual DbSet<VueloSalida> VueloSalida { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLOCAL; DataBase=DbVuelos; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<VueloEstado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Vuelo_Es__FBB0EDC14D64295F");

                entity.ToTable("Vuelo_Estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VueloSalida>(entity =>
            {
                entity.HasKey(e => e.IdSalida)
                    .HasName("PK__Vuelo_Sa__5D69EC7269E827CA");

                entity.ToTable("Vuelo_Salida");

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Origen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salida)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.VueloSalida)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vuelo_Sal__IdEst__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
