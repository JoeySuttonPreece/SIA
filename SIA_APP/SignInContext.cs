using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIA_APP.Models;

namespace SIA_APP
{
    public class SignInContext : DbContext
    {
        public SignInContext(DbContextOptions<SignInContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasKey(e => new { e.ClassID });

            modelBuilder.Entity<Class>()
                .HasOne(a => a.Cluster)
                .WithMany(b => b.Classes);


            modelBuilder.Entity<Cluster>()
                .HasKey(e => new { e.ClusterID });


            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.ClassID, e.Barcode });

            modelBuilder.Entity<Enrollment>()
                .HasOne(a => a.Student)
                .WithMany(b => b.Enrollments);

            modelBuilder.Entity<Enrollment>()
                .HasOne(a => a.Class)
                .WithMany(b => b.Enrollments);


            modelBuilder.Entity<Label>()
                .HasKey(e => new { e.ClassID, e.Name });

            modelBuilder.Entity<Label>()
                .HasOne(a => a.Class)
                .WithMany(b => b.Labels);


            modelBuilder.Entity<Scan>()
                .HasKey(e => new { e.ClassID, e.Barcode, e.Time });

            modelBuilder.Entity<Scan>()
                .HasOne(a => a.Class)
                .WithMany(b => b.Scans);

            modelBuilder.Entity<Scan>()
                .HasOne(a => a.Student)
                .WithMany(b => b.Scans);


            modelBuilder.Entity<Student>()
                .HasKey(e => new { e.Barcode });


            modelBuilder.Entity<Unit>()
                .HasKey(e => new { e.ClusterID, e.Code });

            modelBuilder.Entity<Unit>()
                .HasOne(a => a.Cluster)
                .WithMany(b => b.Units);
        }

        public DbSet<Class> Class { get; set; }
        public DbSet<Cluster> Cluster { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<Scan> Scan { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Unit> Unit { get; set; }
    }
}
