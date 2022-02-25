using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp
{
    public partial class FinanceWebAppDatabaseContext : DbContext
    {
        public FinanceWebAppDatabaseContext()
        {
        }

        public FinanceWebAppDatabaseContext(DbContextOptions<FinanceWebAppDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=FinanceWebAppDatabase;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Acronym).HasColumnType("character varying");

                entity.Property(e => e.FullName).HasColumnType("character varying");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasComment("User identication number")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAccount)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.LastActive)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.PasswordHash).HasColumnType("character varying");

                entity.Property(e => e.Salt).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
