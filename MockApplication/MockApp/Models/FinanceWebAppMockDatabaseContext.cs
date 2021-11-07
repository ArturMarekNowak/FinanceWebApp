using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MockApp.Models
{
    public partial class FinanceWebAppMockDatabaseContext : DbContext
    {
        public FinanceWebAppMockDatabaseContext()
        {
        }

        public FinanceWebAppMockDatabaseContext(DbContextOptions<FinanceWebAppMockDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Datasource=FinanceWebAppMockDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.Acronym, "IX_Companies_Acronym")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId, "IX_Companies_CompanyId")
                    .IsUnique();

                entity.HasIndex(e => e.FullName, "IX_Companies_FullName")
                    .IsUnique();

                entity.Property(e => e.Acronym).IsRequired();

                entity.Property(e => e.FullName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
