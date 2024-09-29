using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInIngredientDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c44f30ad-4abf-4ee6-bd8b-d0f17b7423bf", "AQAAAAIAAYagAAAAEIBRR3ubcADtdC9ItWF/Q2ztRUc9zEHglD+aaSuK5K7S0cmlCkMTLqcgxpKSEgbqCw==", "234634ae-73ab-4cd4-8a8b-23df5dbc1f89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac9fba12-d418-4c51-9204-47679e113f37", "AQAAAAIAAYagAAAAEKf7LGcCTJibpItDrVvL0Fc1K0FdmiFjWcWf/Pbn65wkd1PWkpbzYkf7tFo14ltk7g==", "034287df-cbff-42ba-aa8d-38b259c62f35" });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meats" },
                    { 2, "Dairy" },
                    { 3, "Vegetables" },
                    { 4, "Fruits" },
                    { 5, "Grains" },
                    { 6, "Seafood" },
                    { 7, "Fats and Oils" },
                    { 8, "Nuts and Seeds" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 8);

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
    }
}
