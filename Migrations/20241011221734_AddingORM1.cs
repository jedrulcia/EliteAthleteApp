using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingORM1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingModuleORMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenchPressORM = table.Column<int>(type: "int", nullable: true),
                    OverheadPressORM = table.Column<int>(type: "int", nullable: true),
                    DeadliftORM = table.Column<int>(type: "int", nullable: true),
                    SquatORM = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingModuleORMs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91b114ac-c13e-446a-9888-aa5ec1920908", "AQAAAAIAAYagAAAAEKtuJjnfE6m8HvWRY3tN6J9h7xTByIowNk3ID9www4ZU1V8EqKoazNmHAtTLiawcQg==", "b385b59e-ee9b-4334-925c-dac3408a26a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a9bd06e-0685-4747-a567-53bc11bd9e89", "AQAAAAIAAYagAAAAEE4XiM8ShkZ9PFvlNNlgFGybqpjtDr/nZz+KGe+aL+Ny73qH2e0qHblKryaRRAWMhg==", "3701870a-e85f-47de-8b4b-9024b8b99aaf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingModuleORMs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64709ad6-2338-4114-b14b-dfb005c8eee3", "AQAAAAIAAYagAAAAEDV/i3d6RGwEZ2ijwel8/avfGzLwLriC54De88BY8OLIzEY5W5prM1uUn6q+kLnXaw==", "d5487be2-0b40-4ea1-ba55-6e49d372ddbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2e82718-c9b4-4638-9765-b94ef44d2c3c", "AQAAAAIAAYagAAAAEPOEcGMaoK1NOAf8xW8IwxE91XcQXip87O8Nd06dDJSIEPoXphkX0bQCX8ZYYkluZQ==", "fa7d3bb0-89c5-4c65-afbb-1894d51065e8" });
        }
    }
}
