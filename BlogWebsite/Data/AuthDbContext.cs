using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) 
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed Roles (user, admin, Superadmin)
            var AdminRoleId = "51374b31-9d34-46f9-b963-dd0cbf0a625c";
            var SuperAdminRoleId = "7108258c-b9f6-4d23-ad40-dfe8d39a9324";
            var UserRoleId = "8e8fe2b3-3bc2-4843-9070-511c6ab52b73";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = AdminRoleId,
                    ConcurrencyStamp = AdminRoleId
                },
                 new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = SuperAdminRoleId,
                    ConcurrencyStamp = SuperAdminRoleId
                },

                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "User",
                     Id = UserRoleId,
                     ConcurrencyStamp = UserRoleId
                 }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //Seed SuperAdminUser

            var superAdminId = "6a51fcc3-81fc-4dba-87f6-6e3549783229";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blogspace.com",
                Email = "superadmin@blogspace.com",
                NormalizedEmail = "superadmin@blogspace.com".ToUpper(),
                NormalizedUserName = "superadmin@blogspace.com".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add all roles to superadmin user

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = SuperAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId= UserRoleId, 
                    UserId = superAdminId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
