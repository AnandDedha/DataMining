namespace MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<StudentLocation> StudentLocations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsName> StudentsNames { get; set; }
        public virtual DbSet<V_Students> V_Students { get; set; }
        public virtual DbSet<viewStudentsInCourses> viewStudentsInCourses { get; set; }

        public virtual DbSet<viewStudentsEnrolled> viewStudentsEnrolled { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.StudentCourses)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.StudentLocations)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.EmailAddresses)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentCourses)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentLocations)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
