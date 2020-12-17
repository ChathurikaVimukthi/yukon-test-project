using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YukonTest.Domain.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Absents",
                columns: table => new
                {
                    AbsentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherID = table.Column<int>(nullable: false),
                    AbsentDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absents", x => x.AbsentID);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DayName = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayID);
                });

            migrationBuilder.CreateTable(
                name: "PeriodByDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DayID = table.Column<int>(nullable: false),
                    PeriodID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: false),
                    TeacherID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodByDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    PeriodID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeriodName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.PeriodID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    SubjectID = table.Column<int>(nullable: false),
                    Leave = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absents");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "PeriodByDays");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
