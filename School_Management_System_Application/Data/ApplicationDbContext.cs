using Microsoft.EntityFrameworkCore;
using School_Management_System_Application.Models;

namespace School_Management_System_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
             
        }


        public virtual DbSet<Admin> admins { get; set; }
        public virtual DbSet<Class> classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherCourse> TeacherCourses { get; set; }
        public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }

        public virtual DbSet<Annoucement> Annoucements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DARKSIDE;Database=School_Management_System_Application;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.password)
                .HasColumnName("password")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId)
                .HasColumnName("Class Id")
                .IsRequired();
                entity.Property(e => e.ClassName)
                .HasColumnName("Class Name")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            });


            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                .HasColumnName("Course Id")
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.CourseName)
                .HasColumnName("Course Name")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.Credit_hour)
                .HasColumnName("Credit Hour")
                .IsRequired();

                entity.HasOne(d => d.Class)
                     .WithMany(s => s.Courses)
                     .HasForeignKey(d => d.ClassId)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__students__ClassId__15502E78");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("ID")
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.Student_ID)
                .HasColumnName("Student Id")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.FirstName)
               .HasColumnName("First Name")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
                entity.Property(e => e.LastName)
               .HasColumnName("Last Name")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
                entity.Property(e => e.Gender)
               .HasColumnName("Gender")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
                entity.Property(e => e.Phone_No)
                .HasColumnName("Phone_No")
                .IsRequired();
                entity.Property(e => e.Roll_No)
               .HasColumnName("Roll No")
               .IsRequired();
                entity.Property(e => e.DOB)
              .HasColumnName("Date Of Birth")
              .IsRequired();
                entity.Property(e => e.username)
               .HasColumnName("username")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
                entity.Property(e => e.password)
              .HasColumnName("password")
              .HasMaxLength(50)
              .IsRequired()
              .IsUnicode(false);
                entity.Property(e => e.Email)
              .HasColumnName("Email")
              .HasMaxLength(50)
              .IsRequired()
              .IsUnicode(false);
                entity.HasOne(d => d.Class)
                     .WithMany(s => s.Students)
                     .HasForeignKey(d => d.ClassId)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__studentsid__ClassId__15502E78");
            });


            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Teacher Id")
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.username)
                .HasColumnName("username")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.password)
                .HasColumnName("password")
                .IsRequired();
                entity.Property(e => e.fname)
                .HasColumnName("First name")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.lname)
                .HasColumnName("last name")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.gender)
                .HasColumnName("Gender")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.Phone_no)
                .HasColumnName("phone Number");
                entity.Property(e => e.email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            });


            modelBuilder.Entity<TeacherCourse>(entity =>
            {
                entity.Property(e => e.TcId)
                .HasColumnName("Id")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasOne(d => d.Class)
                     .WithMany(s => s.TeacherCourses)
                     .HasForeignKey(d => d.ClassId)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__class__teachercourse__15502E78");
                entity.HasOne(d => d.Course)
                      .WithMany(s => s.TeacherCourse)
                      .HasForeignKey(d => d.CourseId)
                      .OnDelete(DeleteBehavior.SetNull)
                      .HasConstraintName("FK__course__teachercourse__15502E78");
                entity.HasOne(d => d.Teacher)
                    .WithMany(s => s.TeacherCourses)
                    .HasForeignKey(d => d.TeacherID)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__teacher__teachercourse__15502E78");
            });


            modelBuilder.Entity<StudentAttendance>(entity =>
            {
                entity.Property(e => e.AttendanceId)
                .HasColumnName("Attendance Id")
                .IsRequired();
                entity.Property(e => e.roll_no)
               .HasColumnName("Roll Number")
               .IsRequired();
                entity.Property(e => e.AttendanceDate)
               .HasColumnName("Date")
               .IsRequired();
                entity.HasOne(d => d.Class)
                     .WithMany(s => s.StudentAttendances)
                     .HasForeignKey(d => d.ClassId)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__class__Attendance__15502E78");
                entity.HasOne(d => d.Course)
                      .WithMany(s => s.StudentAttendances)
                      .HasForeignKey(d => d.CourseId)
                      .OnDelete(DeleteBehavior.SetNull)
                      .HasConstraintName("FK__course__Attendance__15502E78");
            });


            modelBuilder.Entity<Fees>(entity =>
            {
                entity.Property(e => e.FeeID)
                .HasColumnName("ID")
                .IsRequired();
                entity.Property(e => e.Amount)
               .HasColumnName("Amount")
               .IsRequired();
                entity.HasOne(d => d.Class)
                     .WithMany(s => s.Fees)
                     .HasForeignKey(d => d.ClassID)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__class__Attendance__15502E78");
            });



            modelBuilder.Entity<Parent>(entity =>
            {
                entity.Property(e => e.ParentId)
                .HasColumnName("Id")
                .IsRequired();
                entity.Property(e => e.FName)
               .HasColumnName("First name")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
                entity.Property(e => e.LName)
               .HasColumnName("Last Name")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
                entity.Property(e => e.password)
               .HasColumnName("Password")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
                entity.Property(e => e.Email)
               .HasColumnName("Email")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);

            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId)
                .HasColumnName("Grade Id")
                .IsRequired();
                entity.Property(e => e.Roll_No)
                .HasColumnName("Roll Number");
                entity.Property(e => e.OutOfMarks)
                .HasColumnName("Out Of Mark");
                entity.Property(e => e.TotalMarks)
                .HasColumnName("Total Mark");
                entity.Property(e => e.Grd)
                .HasColumnName("Grade Value");
                entity.Property(e => e.PassOrFail)
                .HasColumnName("Valuation")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.HasOne(d => d.classes)
                     .WithMany(s => s.Grades)
                     .HasForeignKey(d => d.ClassId)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__class__grade__15502E78");

                entity.HasOne(d => d.course)
                     .WithMany(s => s.Grades)
                     .HasForeignKey(d => d.CourseId)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__course__grade__15502E78");

                entity.HasOne(d => d.Student)
                     .WithMany(s => s.Grades)
                     .HasForeignKey(d => d.Id)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK__student__grade__15502E78");

               
            });

            modelBuilder.Entity<Annoucement>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();
                entity.Property(e => e.Annoucement_Description)
                .HasColumnName("Annoucement Description")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.Annoucement_Date)
                .HasColumnName("Date")
                .IsRequired();
                 entity.Property(e => e.Annoucements)
                .HasColumnName("Annoucement")
                .HasMaxLength(300)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();
                entity.Property(e => e.Student_Id)
                .HasColumnName("Student ID")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                entity.Property(e => e.Posted_Date)
               .HasColumnName("Date")
               .IsRequired();
                entity.Property(e => e.Complain)
                .HasColumnName("Annoucement")
                .HasMaxLength(300)
                .IsRequired()
                .IsUnicode(false);
            });


        }

    }
}
