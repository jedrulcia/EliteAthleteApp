using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingMuscleGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroups", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5d28812-d84c-4f12-95a4-862a9b5ae6fb", "AQAAAAIAAYagAAAAEKnppAKhWv+2dWyNyoZDmeOEDTngTdWGMy1lMpKzzU6FkgjDehkpzcQET94rNm0tUw==", "854c41f3-b5da-42f8-96e8-622d3de9b819" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc337e5-6a51-47a3-91ca-e7813c453e90", "AQAAAAIAAYagAAAAEDwWYVPPp+1CYeCe8Z3ry8DOD++ls8EnXN9r2wPLYEAfrKuu1dfDejouG125QAtCFQ==", "19a9403b-c96c-479b-9a32-4209434e7269" });

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " " },
                    { 2, "Neck" },
                    { 3, "Shoulders" },
                    { 4, "Chest" },
                    { 5, "Core" },
                    { 6, "Biceps" },
                    { 7, "Triceps" },
                    { 8, "Forearms/Wrist" },
                    { 9, "Back" },
                    { 11, "Glutes" },
                    { 12, "Lower Back" },
                    { 13, "Quadriceps" },
                    { 14, "Hamstrings" },
                    { 15, "Calves" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e825463b-7152-4366-90a7-7f3873ad7370", "AQAAAAIAAYagAAAAEO1z9qI6hxgNfhYm0Oip8UGZNFeSsj14WS0jGsl+tBBDmPB1ECTjyM6wzwvAyVIKtw==", "395bd794-cf94-4e0b-ac26-0b9ab232d93c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd184e35-55ea-4e56-82ca-2a81c5717dcb", "AQAAAAIAAYagAAAAECrNDQo3JuG5wzWwD2vndXhBKipcBYrR6HqAwzjGTiV661hyvSoRJd9/89hz8pKr1g==", "448adc87-0163-4123-b5f8-ce5ad55946d2" });
        }
    }
}
