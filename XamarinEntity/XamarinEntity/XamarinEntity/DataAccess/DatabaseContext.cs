using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XamarinEntity.Helpers;
using XamarinEntity.Models;

namespace XamarinEntity.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }


        public DatabaseContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("DBPath" + Constant.DBPath);
            optionsBuilder
                .UseSqlite($"Filename={Constant.DBPath}");
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var entities = (from entry in ChangeTracker.Entries()
        //                    where entry.State == EntityState.Modified || entry.State == EntityState.Added
        //                    select entry.Entity);

        //    var validationResults = new List<ValidationResult>();
        //    foreach (var entity in entities)
        //    {
        //        if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
        //        {
        //            // throw new ValidationException() or do whatever you want
        //        }
        //    }
        //    return base.SaveChangesAsync(cancellationToken);   
        //}

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
