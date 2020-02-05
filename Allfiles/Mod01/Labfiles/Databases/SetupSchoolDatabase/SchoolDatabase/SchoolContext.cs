using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SchoolDatabase
{
    public class SchoolContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=SchoolCore;trusted_connection=true";

        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.DateOfBirth).HasColumnType("date");
                entity.Property(s => s.FirstName).HasMaxLength(50);
                entity.Property(s => s.LastName).HasMaxLength(50);

                entity.HasOne(s => s.Teacher)
                   .WithMany(p => p.Students)
                   .HasForeignKey(d => d.ClassId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(t => t.FirstName).HasMaxLength(50);
                entity.Property(t => t.LastName).HasMaxLength(50);
                entity.Property(t => t.Class).HasMaxLength(2);
            });

            InitData(modelBuilder);
        }

        private void InitData(ModelBuilder modelBuilder)
        {
            var teachers = new List<Teacher>()
            {
                new Teacher { Id = 1, FirstName = "Esther", LastName="Valle", Class="3C"},
                new Teacher { Id = 2, FirstName = "David", LastName = "Waite", Class="4B"},
                new Teacher {Id = 3, FirstName = "Belinda", LastName = "Newman", Class="2A"}
            };
            var students = new List<Student>()
            {
                new Student {Id = 1, FirstName = "Kevin", LastName="Liu", DateOfBirth=new DateTime(2005, 10, 10), ClassId = 1},
                new Student {Id = 2, FirstName = "Martin", LastName="Weber", DateOfBirth=new DateTime(2005, 09, 07), ClassId = 1},
                new Student {Id = 3, FirstName = "George", LastName="Li", DateOfBirth=new DateTime(2005, 08, 10), ClassId = 1},
                new Student {Id = 4, FirstName = "Lisa", LastName="Miller", DateOfBirth=new DateTime(2005, 05, 04), ClassId = 1},
                new Student {Id = 5, FirstName = "Run", LastName="Liu", DateOfBirth=new DateTime(2005, 10, 23), ClassId = 1},
                new Student {Id = 6, FirstName = "Sean", LastName="Stewart", DateOfBirth=new DateTime(2003, 10, 18), ClassId = 2},
                new Student {Id = 7, FirstName = "Olinda", LastName="Turner", DateOfBirth=new DateTime(2003, 05, 17), ClassId = 2},
                new Student {Id = 8, FirstName = "Jon", LastName="Orton", DateOfBirth=new DateTime(2002, 10, 08), ClassId = 2},
                new Student {Id = 9, FirstName = "Toby", LastName="Nixon", DateOfBirth=new DateTime(2002, 12, 15), ClassId = 2},
                new Student {Id = 10, FirstName = "Daniela", LastName="Guinot", DateOfBirth=new DateTime(2001, 08, 01), ClassId = 2},
                new Student {Id = 11, FirstName = "Vijay", LastName="Sundaram", DateOfBirth=new DateTime(2007, 02, 03), ClassId = 3},
                new Student {Id = 12, FirstName = "Eric", LastName="Gruber", DateOfBirth=new DateTime(2007, 05, 26), ClassId = 3},
                new Student {Id = 13, FirstName = "Chris", LastName="Meyer", DateOfBirth=new DateTime(2006, 05, 09), ClassId = 3},
                new Student {Id = 14, FirstName = "Yuhong", LastName="Li", DateOfBirth=new DateTime(2007, 05, 28), ClassId = 3},
                new Student {Id = 15, FirstName = "Yan", LastName="Li", DateOfBirth=new DateTime(2007, 03, 31), ClassId = 3},
            };

            modelBuilder.Entity<Teacher>().HasData(teachers);

            modelBuilder.Entity<Student>().HasData(students);
        }

        public DbSet<Student> Students { get; set; } = default!;

        public DbSet<Teacher> Teachers { get; set; } = default!;
    }
}
