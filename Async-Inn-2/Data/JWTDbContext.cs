using JWT_D.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT_D.Data
{
    public class JWTDbContext : IdentityDbContext<ApplicationUser>
    {
        public JWTDbContext(DbContextOptions Options) : base(Options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Stock>().HasData(

                new Stock() { ID = 1, Name = "Stock-1" },
                new Stock() { ID = 2, Name = "Stock-2" },
                new Stock() { ID = 3, Name = "Stock-3" }


                );

            SeedRole(modelBuilder, "Client", "create", "update", "delete");
            SeedRole(modelBuilder, "Manager", "create", "update");
            SeedRole(modelBuilder, "Agent", "create", "update", "delete");

        }


        private int id = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Go through the permissions list and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
             new IdentityRoleClaim<string>
             {
                 Id = id++,
                 RoleId = role.Id,
                 ClaimType = "permissions",
                 ClaimValue = permission
             }
            );
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }

        public DbSet<Stock> Stocks { get; set; }

    }
}