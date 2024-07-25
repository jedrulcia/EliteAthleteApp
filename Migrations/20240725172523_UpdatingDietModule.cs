using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDietModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a64579fd-0067-4c67-bcbb-5235c19894fe", "AQAAAAIAAYagAAAAELtSvzj6jWTQ1gv+0rLmCMVCAbjisr/pqaWgMRERXdtDvWi2aAINeEgfvziOQYfvmA==", "1a6f636e-174b-4e70-9c73-3260a297304d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6d659d6-1cce-45dc-b265-fb4f94d42539", "AQAAAAIAAYagAAAAEFV9dY0E5yszN8q93hmyhcA1H7HVwNrLkmuAzks0ApkHGtwCz7BUVBJJ58IJZvReog==", "7810d45e-6e04-4bb8-84dc-2011760ab9a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddec17a8-bcc3-42ef-a00d-5290968f819a", "AQAAAAIAAYagAAAAEIfvlh65p5LlKEaWaJWT5IOFzLgXaA9PMyfVHZCP7bp0SsPuKKntuCwTgrFefm4wVg==", "f1b27c98-aced-475c-a765-2aa99f860cdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6e937d9-b3a7-4715-856b-8fa24e576fcf", "AQAAAAIAAYagAAAAEDBUd0iAzuSqrZCw36ews+9qDYQGhx8fNSoJ6ha1E4GrutE1k0YHiYTwbjDEmuj0aQ==", "545ccdfa-7efb-4253-8670-2ffa19d8c002" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MealId",
                table: "Ingredients",
                column: "MealId");
        }
    }
}
