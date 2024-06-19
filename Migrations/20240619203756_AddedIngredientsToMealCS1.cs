/*using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedIngredientsToMealCS1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kcal = table.Column<int>(type: "int", nullable: true),
                    Protein = table.Column<int>(type: "int", nullable: true),
                    Fat = table.Column<int>(type: "int", nullable: true),
                    Carbs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServingSize = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397c24da-8136-4871-ae2e-61b22ea4b892", "AQAAAAIAAYagAAAAEK2pCYwf4x7SNBXiKj/X1wUKs9InvmgEnxI2D/+622VQT+sjv13Qo9PSAQcViFDN/g==", "8aec876b-3013-4e5a-bf9d-76db57b9ffd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee1c58e3-f277-4ca7-84c3-3c49261170e7", "AQAAAAIAAYagAAAAEDjRpZvgE9EWL11b+lpt4ugqheUU01zL3wfByts11ASt4tKw7dIWZyKSeUjduviCEA==", "3f81719f-9ba0-446c-9399-6dc1a770d203" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0bed8db-4b0b-4396-9647-d5ef9483e26c", "AQAAAAIAAYagAAAAEBvku7KlsxwibaqpndxH5+zOmrAuWdUzV5HGhA03cmDWxxWtk040dgxbwzFo9TYqzw==", "03c494ae-c50d-491b-b24b-3e9fffeb8797" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d3c74d2-6bac-4b78-a1ba-ca5d4981c8d3", "AQAAAAIAAYagAAAAEMgrqzZFEPijAgGsoaeDRK9h57WQtB6zySuAiFMTKi8+y8Yy8RFBZXRaRrvp7LF2Vw==", "7300658f-a64a-4e17-ad76-f40d224ad46b" });
        }
    }
}
*/