using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExistingDb.Models.Scaffold
{
    public partial class ZoomShoesDbContext : DbContext
    {
        public ZoomShoesDbContext()
        {
        }

        public ZoomShoesDbContext(DbContextOptions<ZoomShoesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Fittings> Fittings { get; set; }
        public virtual DbSet<SalesCampaigns> SalesCampaigns { get; set; }
        public virtual DbSet<ShoeCategoryJunction> ShoeCategoryJunction { get; set; }
        public virtual DbSet<Shoes> Shoes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {

        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-B53DF3Q\\SQLEXPRESS;Initial Catalog=ZoomShoesDb;Trusted_Connection=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.Property(e => e.HighlightColor).IsRequired();

                entity.Property(e => e.MainColor).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Fittings>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SalesCampaigns>(entity =>
            {
                entity.HasIndex(e => e.ShoeId)
                    .IsUnique();

                entity.Property(e => e.LaunchDate).HasColumnType("date");

                entity.HasOne(d => d.Shoe)
                    .WithOne(p => p.SalesCampaigns)
                    .HasForeignKey<SalesCampaigns>(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesCampaigns");
            });

            modelBuilder.Entity<ShoeCategoryJunction>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ShoeCategoryJunction)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__ShoeCateg__Categ__412EB0B6");

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.ShoeCategoryJunction)
                    .HasForeignKey(d => d.ShoeId)
                    .HasConstraintName("FK__ShoeCateg__ShoeI__403A8C7D");
            });

            modelBuilder.Entity<Shoes>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shoes_Colors");

                entity.HasOne(d => d.Fitting)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.FittingId)
                    .HasConstraintName("FK_Shoes_Fittings");
            });
        }
    }
}
