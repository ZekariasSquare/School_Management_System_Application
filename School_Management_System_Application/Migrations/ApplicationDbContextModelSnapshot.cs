﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School_Management_System_Application.Data;

namespace School_Management_System_Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("School_Management_System_Application.Models.Admin", b =>
                {
                    b.Property<int>("AId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.HasKey("AId");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Annoucement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Annoucement_Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("Annoucement_Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Annoucement Description");

                    b.Property<string>("Annoucements")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Annoucement");

                    b.HasKey("Id");

                    b.ToTable("Annoucements");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Class", b =>
                {
                    b.Property<long>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Class Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Class Name");

                    b.HasKey("ClassId");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Complain")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Annoucement");

                    b.Property<DateTime>("Posted_Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("Student_Id")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Student ID");

                    b.HasKey("Id");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Course", b =>
                {
                    b.Property<long>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("bigint")
                        .HasColumnName("Course Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Course Name");

                    b.Property<int>("Credit_hour")
                        .HasColumnType("int")
                        .HasColumnName("Credit Hour");

                    b.HasKey("CourseId");

                    b.HasIndex("ClassId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Fees", b =>
                {
                    b.Property<long>("FeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint")
                        .HasColumnName("Amount");

                    b.Property<long?>("ClassID")
                        .HasColumnType("bigint");

                    b.HasKey("FeeID");

                    b.HasIndex("ClassID");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Grade", b =>
                {
                    b.Property<long?>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Grade Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Grd")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Grade Value");

                    b.Property<long?>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("OutOfMarks")
                        .HasColumnType("int")
                        .HasColumnName("Out Of Mark");

                    b.Property<string>("PassOrFail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Valuation");

                    b.Property<int>("Roll_No")
                        .HasColumnType("int")
                        .HasColumnName("Roll Number");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int")
                        .HasColumnName("Total Mark");

                    b.Property<string>("studentId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("First name");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Last Name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Password");

                    b.HasKey("ParentId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date Of Birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("First Name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Last Name");

                    b.Property<long>("Phone_No")
                        .HasColumnType("bigint")
                        .HasColumnName("Phone_No");

                    b.Property<long>("Roll_No")
                        .HasColumnType("bigint")
                        .HasColumnName("Roll No");

                    b.Property<string>("Student_ID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Student Id");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.StudentAttendance", b =>
                {
                    b.Property<long>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Attendance Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<long?>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<int>("roll_no")
                        .HasColumnType("int")
                        .HasColumnName("Roll Number");

                    b.HasKey("AttendanceId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentAttendances");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("bigint")
                        .HasColumnName("Teacher Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Phone_no")
                        .HasColumnType("float")
                        .HasColumnName("phone Number");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("First name");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Gender");

                    b.Property<string>("lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.TeacherCourse", b =>
                {
                    b.Property<long>("TcId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TeacherID")
                        .HasColumnType("bigint");

                    b.HasKey("TcId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherID");

                    b.ToTable("TeacherCourses");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Course", b =>
                {
                    b.HasOne("School_Management_System_Application.Models.Class", "Class")
                        .WithMany("Courses")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK__students__ClassId__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Class");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Fees", b =>
                {
                    b.HasOne("School_Management_System_Application.Models.Class", "Class")
                        .WithMany("Fees")
                        .HasForeignKey("ClassID")
                        .HasConstraintName("FK__class__Attendance__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Class");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Grade", b =>
                {
                    b.HasOne("School_Management_System_Application.Models.Class", "classes")
                        .WithMany("Grades")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK__class__grade__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("School_Management_System_Application.Models.Course", "course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__course__grade__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("School_Management_System_Application.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK__student__grade__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("classes");

                    b.Navigation("course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Student", b =>
                {
                    b.HasOne("School_Management_System_Application.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK__studentsid__ClassId__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Class");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.StudentAttendance", b =>
                {
                    b.HasOne("School_Management_System_Application.Models.Class", "Class")
                        .WithMany("StudentAttendances")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK__class__Attendance__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("School_Management_System_Application.Models.Course", "Course")
                        .WithMany("StudentAttendances")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__course__Attendance__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Class");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.TeacherCourse", b =>
                {
                    b.HasOne("School_Management_System_Application.Models.Class", "Class")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK__class__teachercourse__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("School_Management_System_Application.Models.Course", "Course")
                        .WithMany("TeacherCourse")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__course__teachercourse__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("School_Management_System_Application.Models.Teacher", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("TeacherID")
                        .HasConstraintName("FK__teacher__teachercourse__15502E78")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Class");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Class", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Fees");

                    b.Navigation("Grades");

                    b.Navigation("StudentAttendances");

                    b.Navigation("Students");

                    b.Navigation("TeacherCourses");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Course", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("StudentAttendances");

                    b.Navigation("TeacherCourse");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("School_Management_System_Application.Models.Teacher", b =>
                {
                    b.Navigation("TeacherCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
