using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TvShowWebAPI.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public string DbPath { get; }
        public DbSet<EpisodesWatched> EpisodesWatched { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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
            // builder.Entity<ApplicationUser>()
            // .HasMany(e => e.WatchedEpisodes)
            // .HasForeignKey(e => e.episodeId)
            // .IsRequired();
            //builder.Entity<ApplicationUser>()
            //.HasMany(e => e.WatchedEpisodes)
            //.WithOne(e => e.User);

            base.OnModelCreating(builder);
        }
    }
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}


