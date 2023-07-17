using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

// public class TVShowContext : DbContext
// {
//     public DbSet<UserModel> User { get; set; }

//     public string DbPath { get; }

//     public TVShowContext()
//     {
//         var folder = Environment.SpecialFolder.LocalApplicationData;
//         var path = Environment.GetFolderPath(folder);
//         DbPath = System.IO.Path.Join(path, "database.db");
//     }

//     // The following configures EF to create a Sqlite database file in the
//     // special "local" folder for your platform.
//     protected override void OnConfiguring(DbContextOptionsBuilder options)
//         => options.UseSqlite($"Data Source={DbPath}");
// }