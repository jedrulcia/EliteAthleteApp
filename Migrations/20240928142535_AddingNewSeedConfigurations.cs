using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewSeedConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientCategoryId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientUnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUnitTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba1bcbfd-a2bb-4b15-a9df-b8da32de85a2", "AQAAAAIAAYagAAAAEOxh5apI6kmbAtnGSf3Ba15zLMLTwFPElDPhc8a1e/m+T4hq8Emxnu9Ds8AYrFCJ7Q==", "e2b55d5e-d8d2-4d56-bbff-28ad12d04a81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b79c02ae-cff7-4517-80ed-85b62e840ea4", "AQAAAAIAAYagAAAAEDc6O9aEQpVvfyqpMVLenzPQ4xDRYHpSXoF5B2oQaGmwkJxW1LLbwjc6VGh2mj7Pnw==", "d351e4a4-f542-4f88-a10e-e6c72827b86e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientCategories");

            migrationBuilder.DropTable(
                name: "IngredientUnitTypes");

            migrationBuilder.DropColumn(
                name: "IngredientCategoryId",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63acd25a-0de0-419a-a825-35f0af01961f", "AQAAAAIAAYagAAAAEIiHOkfdQzhtxraCw3ZqU2EIjX8AEQApMRYAuU3EFd+Y6RCwxpFp4IH8gW1+sKUI4w==", "db9941aa-519d-427b-9ff0-9f068b7a23fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8180c1a7-d321-4f9a-874d-ae1324198ee3", "AQAAAAIAAYagAAAAEJILOHtG2UDG1sTPLKecIflh6+8DzcNaGAv77DmopKkgqsNHudSgG71ycf5PrA8RAQ==", "d3b7a936-74e4-4918-a73c-cdc3fc3bb112" });
        }
    }
}
