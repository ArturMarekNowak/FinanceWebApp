using System;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
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

        public virtual DbSet<Currency> Currencies { get; set; }
       
        public virtual DbSet<Price> Prices { get; set; }
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
 #pragma warning disable 612, 618
             modelBuilder
                 .HasAnnotation("ProductVersion", "6.0.2")
                 .HasAnnotation("Relational:MaxIdentifierLength", 63);
 
             NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);
 
             modelBuilder.Entity("WebApp.Models.Currency", b =>
                 {
                     b.Property<int>("CurrencyId")
                         .ValueGeneratedOnAdd()
                         .HasColumnType("integer");
 
                     NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CurrencyId"));
 
                     b.Property<string>("Description")
                         .IsRequired()
                         .HasColumnType("text");
 
                     b.Property<string>("DisplaySymbol")
                         .IsRequired()
                         .HasColumnType("text");
 
                     b.Property<string>("Symbol")
                         .IsRequired()
                         .HasColumnType("text");
 
                     b.HasKey("CurrencyId");
 
                     b.ToTable("Currencies");
                 });
 
             modelBuilder.Entity("WebApp.Models.Price", b =>
                 {
                     b.Property<int>("PriceId")
                         .ValueGeneratedOnAdd()
                         .HasColumnType("integer");
 
                     NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PriceId"));
 
                     b.Property<decimal>("ClosingPrice")
                         .HasColumnType("numeric");
 
                     b.Property<int>("CurrencyId")
                         .HasColumnType("integer");
 
                     b.Property<decimal>("HighestPrice")
                         .HasColumnType("numeric");
 
                     b.Property<decimal>("LowestPrice")
                         .HasColumnType("numeric");
 
                     b.Property<decimal>("OpeningPrice")
                         .HasColumnType("numeric");
 
                     b.Property<long>("TimeStamp")
                         .HasColumnType("bigint");
 
                     b.Property<double>("Volume")
                         .HasColumnType("double precision");
 
                     b.HasKey("PriceId");
 
                     b.HasIndex("CurrencyId");
 
                     b.ToTable("Prices");
                 });
 
             modelBuilder.Entity("WebApp.Models.Price", b =>
                 {
                     b.HasOne("WebApp.Models.Currency", "Currency")
                         .WithMany("Prices")
                         .HasForeignKey("CurrencyId")
                         .OnDelete(DeleteBehavior.Cascade)
                         .IsRequired();
 
                     b.Navigation("Currency");
                 });
 
             modelBuilder.Entity("WebApp.Models.Currency", b =>
                 {
                     b.Navigation("Prices");
                 });
 #pragma warning restore 612, 618
            
            OnModelCreatingPartial(modelBuilder);
        }
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
