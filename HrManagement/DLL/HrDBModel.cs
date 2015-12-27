namespace HrManagement.DLL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HrDBModel : DbContext
    {
        public HrDBModel()
            : base("name=HRMDBModel")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.House_Road)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.PoliceStation)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.PostOffice)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Institute)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.PassingYear)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Board)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DOB)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.NID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<JobType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserType)
                .WillCascadeOnDelete(false);
        }
    }
}
