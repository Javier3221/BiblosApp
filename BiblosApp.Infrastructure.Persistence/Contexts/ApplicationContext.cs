using BiblosApp.Core.Domain.Common;
using BiblosApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BiblosApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntidadBaseAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreado = DateTime.Now;
                        entry.Entity.CreadoPor = "BiblosApp Developer Team";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Libro> Libro { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tablas

            modelBuilder.Entity<Libro>()
                .ToTable("Libro");

            modelBuilder.Entity<Autor>()
                .ToTable("Autor");

            #endregion

            #region Llaves Primarias

            modelBuilder.Entity<Libro>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Autor>()
                .HasKey(k => k.Id);

            #endregion

            #region Relaciones

            modelBuilder.Entity<Autor>()
                .HasMany<Libro>(g => g.Libros)
                .WithOne(s => s.Autor)
                .HasForeignKey(k => k.Id_autor)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
