#nullable disable

using Commerce.Shared.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Commerce.Shared.Models.ProductManagement;

namespace Commerce.Server.Data
{
    public class CommerceContext : ApiAuthorizationDbContext<CommerceUser>
    {
        public CommerceContext(
            DbContextOptions<CommerceContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<CommerceUser>(b =>
            {
                b.ToTable("CommerceUser");
                b.HasOne(x => x.Country).WithMany(x => x.CommerceUsers).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("Tokens");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");


            builder.Entity<Company>()
                    .HasOne(x => x.Country)
                    .WithMany(x => x.Companies)
                    .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Member>(b =>
            {
                b.HasOne(x => x.Company).WithMany(x => x.Members).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.CommerceUser).WithMany(x => x.Members).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Location>()
                    .HasOne(x => x.Company)
                    .WithMany(x => x.Locations)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UnitOfMeasure>()
                    .HasOne(x => x.Company)
                    .WithMany(x => x.UnitOfMeasures)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>(b =>
            {
                b.HasOne(x => x.SubGroup).WithMany(x => x.Products).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Company).WithMany(x => x.Products).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.BaseUOM).WithMany(x => x.ProductBases).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.SalesUOM).WithMany(x => x.ProductPurchases).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.PurchaseUOM).WithMany(x => x.ProductSales).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.TransferUOM).WithMany(x => x.ProductTransfers).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Variant>()
                    .HasOne(x => x.Product)
                    .WithMany(x => x.Variants)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>()
                    .HasOne(x => x.Company)
                    .WithMany(x => x.Categories)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Group>()
                    .HasOne(x => x.Category)
                    .WithMany(x => x.Groups)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubGroup>()
                    .HasOne(x => x.Group)
                    .WithMany(x => x.SubGroups)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Customer>()
                    .HasOne(x => x.Company)
                    .WithMany(x => x.Customers)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Supplier>()
                    .HasOne(x => x.Company)
                    .WithMany(x => x.Suppliers)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SalesPrice>()
                    .HasOne(x => x.Variant)
                    .WithMany(x => x.SalesPrices)
                    .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<PurchaseHeader>(b =>
            {
                b.HasOne(x => x.Supplier).WithMany(x => x.PurchaseHeaders).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Location).WithMany(x => x.PurchaseHeaders).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PurchaseReturnHeader>(b =>
            {
                b.HasOne(x => x.Supplier).WithMany(x => x.PurchaseReturnHeaders).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Location).WithMany(x => x.PurchaseReturnHeaders).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SalesHeader>(b =>
            {
                b.HasOne(x => x.Customer).WithMany(x => x.SalesHeaders).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Location).WithMany(x => x.SalesHeaders).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SalesReturnHeader>(b =>
            {
                b.HasOne(x => x.Customer).WithMany(x => x.SalesReturnHeaders).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Location).WithMany(x => x.SalesReturnHeaders).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TransferHeader>(b =>
            {
                b.HasOne(x => x.FromLocation).WithMany(x => x.FromTransferHeaders).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.ToLocation).WithMany(x => x.ToTransferHeaders).OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<PurchaseLine>(b =>
            {
                b.HasOne(x => x.PurchaseHeader).WithMany(x => x.PurchaseLines).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Product).WithMany(x => x.PurchaseLines).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PurchaseReturnLine>(b =>
            {
                b.HasOne(x => x.PurchaseReturnHeader).WithMany(x => x.PurchaseReturnLines).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Product).WithMany(x => x.PurchaseReturnLines).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SalesLine>(b =>
            {
                b.HasOne(x => x.SalesHeader).WithMany(x => x.SalesLines).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Product).WithMany(x => x.SalesLines).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SalesReturnLine>(b =>
            {
                b.HasOne(x => x.SalesReturnHeader).WithMany(x => x.SalesReturnLines).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Product).WithMany(x => x.SalesReturnLines).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TransferLine>(b =>
            {
                b.HasOne(x => x.TransferHeader).WithMany(x => x.TransferLines).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Product).WithMany(x => x.TransferLines).OnDelete(DeleteBehavior.Restrict);
            });



        }


        public DbSet<Category> Category { get; set; }
        public DbSet<CommerceUser> CommerceUser { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<PurchaseHeader> PurchaseHeader { get; set; }
        public DbSet<PurchaseLine> PurchaseLine { get; set; }
        public DbSet<PurchaseReturnHeader> PurchaseReturnHeader { get; set; }
        public DbSet<PurchaseReturnLine> PurchaseReturnLine { get; set; }
        public DbSet<SalesHeader> SalesHeader { get; set; }
        public DbSet<SalesLine> SalesLine { get; set; }
        public DbSet<SalesReturnHeader> SalesReturnHeader { get; set; }
        public DbSet<SalesReturnLine> SalesReturnLine{ get; set; }
        public DbSet<SubGroup> SubGroup { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public DbSet<Variant> Variant { get; set; }
        public DbSet<Commerce.Shared.Models.ProductManagement.SalesPrice> SalesPrice { get; set; }
    }
}