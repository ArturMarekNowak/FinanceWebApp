using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApp.Models;

#nullable disable

namespace WebApp.Database
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

        public virtual DbSet<AppUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:/Users/artur/OneDrive/Desktop/SqliteRestReact/WebApp/AppDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(e => e.UserId);
                
                entity.HasIndex(e => e.Email, "IX_User_Email")
                    .IsUnique();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.Salt).IsRequired();
                
                entity.Property(e => e.CreatedAccount).IsRequired();

                entity.Property(e => e.LastActive).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
