using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApp.Models
{
    public partial class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext()
        {
        }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("data source=../AppDatabase.db");
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

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.PriceId });

                entity.Property(e => e.TimeStamp).IsRequired();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("NUMERIC");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "IX_Users_Email")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_Users_UserId")
                    .IsUnique();

                entity.Property(e => e.CreatedAccount).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastActive).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.Salt).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
