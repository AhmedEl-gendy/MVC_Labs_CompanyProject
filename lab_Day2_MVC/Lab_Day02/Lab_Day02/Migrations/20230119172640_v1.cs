using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabDay02.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManagerSSN = table.Column<int>(type: "int", nullable: true),
                    ManagerHiredate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptNum);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true),
                    SupervisorID = table.Column<int>(type: "int", nullable: true),
                    DepartmentNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentNum",
                        column: x => x.DepartmentNum,
                        principalTable: "Departments",
                        principalColumn: "DeptNum");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    DeptNum = table.Column<int>(type: "int", nullable: false),
                    Loc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => new { x.DeptNum, x.Loc });
                    table.ForeignKey(
                        name: "FK_Locations_Departments_DeptNum",
                        column: x => x.DeptNum,
                        principalTable: "Departments",
                        principalColumn: "DeptNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProjectLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeptNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectNumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DeptNum",
                        column: x => x.DeptNum,
                        principalTable: "Departments",
                        principalColumn: "DeptNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    EmpSSN = table.Column<int>(type: "int", nullable: false),
                    DependID = table.Column<int>(type: "int", nullable: false),
                    DependName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DependSex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DependBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.EmpSSN, x.DependID });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_SSN",
                        column: x => x.SSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "WorksOn",
                columns: table => new
                {
                    EmpSSN = table.Column<int>(type: "int", nullable: false),
                    ProjectNum = table.Column<int>(type: "int", nullable: false),
                    WorksHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOn", x => new { x.EmpSSN, x.ProjectNum });
                    table.ForeignKey(
                        name: "FK_WorksOn_Employees_EmpSSN",
                        column: x => x.EmpSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksOn_Projects_ProjectNum",
                        column: x => x.ProjectNum,
                        principalTable: "Projects",
                        principalColumn: "ProjectNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerSSN",
                table: "Departments",
                column: "ManagerSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_SSN",
                table: "Dependents",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentNum",
                table: "Employees",
                column: "DepartmentNum");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupervisorID",
                table: "Employees",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeptNum",
                table: "Projects",
                column: "DeptNum");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOn_ProjectNum",
                table: "WorksOn",
                column: "ProjectNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ManagerSSN",
                table: "Departments",
                column: "ManagerSSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ManagerSSN",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "WorksOn");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
