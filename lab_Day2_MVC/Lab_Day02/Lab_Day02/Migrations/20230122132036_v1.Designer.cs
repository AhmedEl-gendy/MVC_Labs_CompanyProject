// <auto-generated />
using System;
using Lab_Day02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabDay02.Migrations
{
    [DbContext(typeof(MVC_DbContext))]
    [Migration("20230122132036_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab_Day02.Models.Department", b =>
                {
                    b.Property<int>("DeptNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptNum"));

                    b.Property<string>("DeptName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ManagerHiredate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ManagerSSN")
                        .HasColumnType("int");

                    b.HasKey("DeptNum");

                    b.HasIndex("ManagerSSN");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Lab_Day02.Models.Dependent", b =>
                {
                    b.Property<int>("EmpSSN")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("DependName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DependBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DependSex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Relationship")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmpSSN", "DependName");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("Lab_Day02.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentNum")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SupervisorID")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("DepartmentNum");

                    b.HasIndex("SupervisorID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Lab_Day02.Models.Location", b =>
                {
                    b.Property<int>("DeptNum")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Loc")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("DeptNum", "Loc");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Lab_Day02.Models.Project", b =>
                {
                    b.Property<int>("ProjectNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectNumber"));

                    b.Property<int>("DeptNum")
                        .HasColumnType("int");

                    b.Property<string>("ProjectLocation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProjectNumber");

                    b.HasIndex("DeptNum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Lab_Day02.Models.WorkOn", b =>
                {
                    b.Property<int>("EmpSSN")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ProjectNum")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("WorksHours")
                        .HasColumnType("int");

                    b.HasKey("EmpSSN", "ProjectNum");

                    b.HasIndex("ProjectNum");

                    b.ToTable("WorksOn");
                });

            modelBuilder.Entity("Lab_Day02.Models.Department", b =>
                {
                    b.HasOne("Lab_Day02.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerSSN");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Lab_Day02.Models.Dependent", b =>
                {
                    b.HasOne("Lab_Day02.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("EmpSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Lab_Day02.Models.Employee", b =>
                {
                    b.HasOne("Lab_Day02.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentNum");

                    b.HasOne("Lab_Day02.Models.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID");

                    b.Navigation("Department");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("Lab_Day02.Models.Location", b =>
                {
                    b.HasOne("Lab_Day02.Models.Department", "Department")
                        .WithMany("Locations")
                        .HasForeignKey("DeptNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Lab_Day02.Models.Project", b =>
                {
                    b.HasOne("Lab_Day02.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DeptNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Lab_Day02.Models.WorkOn", b =>
                {
                    b.HasOne("Lab_Day02.Models.Employee", "Employee")
                        .WithMany("WorksOn")
                        .HasForeignKey("EmpSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab_Day02.Models.Project", "Project")
                        .WithMany("WorksOn")
                        .HasForeignKey("ProjectNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Lab_Day02.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Locations");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Lab_Day02.Models.Employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("WorksOn");
                });

            modelBuilder.Entity("Lab_Day02.Models.Project", b =>
                {
                    b.Navigation("WorksOn");
                });
#pragma warning restore 612, 618
        }
    }
}
