using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIngredientUnitTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientUnitTypes");

            migrationBuilder.AddColumn<int>(
                name: "SuggestedPortion",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "921b087f-0454-4dcd-9fb2-797425766cee", "AQAAAAIAAYagAAAAEIqZJNpRccUaOYdg7L0YTFji9pjGL0p0vbac2N/j5UWW+ulQznYeWdNT1casZKF1FA==", "ded2b2fe-c802-482c-9321-19d39cf74704" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8de5f68-5f02-42eb-a764-023cb19ee766", "AQAAAAIAAYagAAAAENgvpMqNenJ3ePiQ326NFn2ZMLc3aUyk2QrmwkoRcp1VROqJrppAUEh9j9mlgyTSpA==", "51284461-d303-4a2b-a215-143aa454372b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuggestedPortion",
                table: "Ingredients");

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
    }
}
