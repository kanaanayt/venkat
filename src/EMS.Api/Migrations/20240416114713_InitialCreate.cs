using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhotoPath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "IT" },
                    { 3, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "Gender", "JoinDate", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 1, "johnsmith@gmail.com", "Harry", 0, new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "images/harry.png" },
                    { 2, 2, "marysutherland@gmail.com", "Mary", 1, new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sutherland", "images/mary.png" },
                    { 3, 3, "samfallon@gmail.com", "Sam", 2, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallon", "images/sam.png" },
                    { 4, 3, "finharrington@gmail.com", "Fin", 0, new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harrington", "images/harry.png" },
                    { 5, 2, "maxsnipe@gmail.com", "Max", 0, new DateTime(2017, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snipe", "images/max.png" },
                    { 6, 1, "wesleykemp@gmail.com", "Wesley", 0, new DateTime(2015, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kemp", "images/wesley.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
