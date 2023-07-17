using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TvShowWebAPI.Authentication
{
    public class ApplicationUser : IdentityUser
    {

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public string DbPath { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // var folder = Environment.SpecialFolder.LocalApplicationData;
            // var path = Environment.GetFolderPath(folder);
            // DbPath = System.IO.Path.Join(path, "database.db");
        }
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite($"Data Source={DbPath}");


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}


