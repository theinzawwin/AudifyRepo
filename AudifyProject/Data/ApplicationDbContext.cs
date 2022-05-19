using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudifyProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AudifyProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
ApplicationRole, string, IdentityUserClaim<string>,
ApplicationUserRole, IdentityUserLogin<string>,
IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
           /* builder.Entity<Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            });
           */
        }
        public DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<AuthorFollower> AuthorFollowers { get; set; }
        public virtual DbSet<FavoriteItem> FavoriteItems { get; set; }
        public virtual DbSet<ReadingHistory> ReadingHistories { get; set; }
    }
}
