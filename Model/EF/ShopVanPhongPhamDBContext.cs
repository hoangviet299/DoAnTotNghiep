using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class ShopVanPhongPhamDBContext : DbContext
    {
        public ShopVanPhongPhamDBContext()
            : base("name=ShopVanPhongPhamDBContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<footer> footers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<orderDetail> orderDetails { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.category)
                .WillCascadeOnDelete();

            modelBuilder.Entity<customer>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<footer>()
                .Property(e => e.id_footer)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.MenuType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<order>()
                .HasMany(e => e.orderDetails)
                .WithOptional(e => e.order)
                .WillCascadeOnDelete();

            modelBuilder.Entity<orderDetail>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .HasMany(e => e.orderDetails)
                .WithOptional(e => e.product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<supplier>()
                .HasMany(e => e.products)
                .WithOptional(e => e.supplier)
                .HasForeignKey(e => e.id_supplies)
                .WillCascadeOnDelete();
        }
    }
}
