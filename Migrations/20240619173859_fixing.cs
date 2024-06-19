using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class fixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealCreateVMId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MealCreateVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kcal = table.Column<int>(type: "int", nullable: true),
                    Protein = table.Column<int>(type: "int", nullable: true),
                    Fat = table.Column<int>(type: "int", nullable: true),
                    Carbs = table.Column<int>(type: "int", nullable: true),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngredientServingSize = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCreateVM", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acd4b6a3-3926-43a3-8094-dd13bdeeb7d5", "AQAAAAIAAYagAAAAEAR7GhFnA9m9zMUcN3Cyl2gYGojSL/APgmW1vtD/0IU5imjz6NsvWiR59U6RcRK+Dw==", "ebcd9e97-e260-4e21-b7fd-f53b99a10725" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b989947-df16-47af-891d-377e5e2c773e", "AQAAAAIAAYagAAAAECHx2liRzAghwo6Z5oswxYiGKb48zf/GlFLzC7de6T93ItVVmjnwpylHKnPujSxhcQ==", "cab1428b-6456-4219-a4c8-215baa6555f9" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MealCreateVMId",
                table: "Ingredients",
                column: "MealCreateVMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_MealCreateVM_MealCreateVMId",
                table: "Ingredients",
                column: "MealCreateVMId",
                principalTable: "MealCreateVM",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_MealCreateVM_MealCreateVMId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "MealCreateVM");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MealCreateVMId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MealCreateVMId",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7f9b77d-da1d-43e3-94d3-d1d1b832d5fa", "AQAAAAIAAYagAAAAEJ4GF4Tyd0Tsb1YJFx7L7eLRldpO2enc1EKvtU3nJEZnj8jIGa7KlO3IJU0H09/9jQ==", "4ce68aab-78b1-4b91-b4bf-45ec90d22e5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "add291ec-2732-45b7-91e4-314fa01f447f", "AQAAAAIAAYagAAAAEL/gA06AGQcTskH0jBA9djbdAKI77yv3N5nJjTZ6Zcm+s0o2vgdRbzMbB/I6GAGmAA==", "ff890824-f95c-4ce8-b87d-a60d65eb0836" });
        }
    }
}
