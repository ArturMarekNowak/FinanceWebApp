using System;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

#nullable disable

namespace WebApp.Data
{
    public class AppDatabaseContext : DbContext
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Filename=../AppDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.CompanyId, "IX_Companies_CompanyId")
                    .IsUnique();

                entity.Property(e => e.Acronym).IsRequired();

                entity.Property(e => e.FullName).IsRequired();
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new {e.CompanyId, e.PriceId});

                entity.Property(e => e.Value).HasColumnName("Price").ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.TimeStamp).IsRequired();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}