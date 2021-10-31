using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApp
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
                optionsBuilder.UseNpgsql(
                    "Host=127.0.0.1;Database=FinanceWebAppDatabase;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Acronym).HasColumnType("character varying");

                entity.Property(e => e.FullName).HasColumnType("character varying");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new {e.CompanyId, e.PriceId})
                    .HasName("Prices_pkey");

                entity.HasIndex(e => e.CompanyId, "fki_CompanyId");

                entity.Property(e => e.PriceId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.TimeStamp).HasColumnType("character varying");

                entity.Property(e => e.Value).HasColumnType("character varying");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prices_CompanyId_fkey");
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

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}