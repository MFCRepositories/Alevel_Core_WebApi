using Core.Entity.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsess.Concrete.EntityFramework.Context
{
    public class AlevelDbContext : DbContext
    {
        public AlevelDbContext(DbContextOptions<AlevelDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserOperationClaimsMap());
            modelBuilder.ApplyConfiguration(new OrderDetailsMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public DbSet<Logs> Logs { get; set; }
    }
    public class OrderDetailsMap
        : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder
                 .HasKey(x => new { x.OrderId, x.ProductId });
            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);
            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);
        }
    }
    public class UserOperationClaimsMap
        : IEntityTypeConfiguration<UserOperationClaims>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaims> builder)
        {
            builder
                 .HasKey(x => new { x.UserId, x.OperationClaimId });
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserOperationClaims)
                .HasForeignKey(x => x.UserId);
            builder
                .HasOne(x => x.OperationClaims)
                .WithMany(x => x.UserOperationClaims)
                .HasForeignKey(x => x.OperationClaimId);
        }
    }
}
