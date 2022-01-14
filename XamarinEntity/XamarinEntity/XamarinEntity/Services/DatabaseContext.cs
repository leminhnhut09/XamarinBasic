using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;
using XamarinEntity.Helpers;
using XamarinEntity.Models;

namespace XamarinEntity.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DatabaseContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Filename={Constant.DBPath}");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // primary key
        //    // 1
        //    modelBuilder.Entity<Student>().HasKey(t => t.Id);
        //    // n
        //    modelBuilder.Entity<Student>().HasKey(t => new { t.Id, t.Birthday });

        //    // required
        //    modelBuilder.Entity<Student>().Property(t => t.Name).IsRequired();

        //    // add data

        //}
    }
}
