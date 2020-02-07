using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Grades.Data
{
    public partial class SchoolGradesContext : DbContext
    {
        public SchoolGradesContext()
        {
        }

        public SchoolGradesContext(DbContextOptions<SchoolGradesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolGradesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasIndex(e => e.StudentUserId)
                    .HasName("IX_FK_StudentGrade");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("IX_FK_SubjectGrade");

                entity.Property(e => e.Assessment).IsRequired();

                entity.Property(e => e.AssessmentDate).HasColumnType("datetime");

                entity.HasOne(d => d.StudentUser)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectGrade");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.TeacherUserId)
                    .HasName("IX_FK_TeacherStudent");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageName).IsRequired();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TeacherUser)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TeacherUserId)
                    .HasConstraintName("FK_TeacherStudent");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Students)
                    .HasForeignKey<Student>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_diameterUsers");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Teachers)
                    .HasForeignKey<Teacher>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teachers_diameterUsers");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C49914F6E");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('password')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
