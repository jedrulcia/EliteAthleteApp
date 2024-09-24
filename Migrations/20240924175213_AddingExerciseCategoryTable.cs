using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingExerciseCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af2954c2-d597-49d6-bf6b-017743e7402b", "AQAAAAIAAYagAAAAEBlogeVt/wADFr0EBGvN/Zp57kXhZcax7riMjvKvsj2pJhQo767d3G2jE+0dCDifjw==", "19dd8088-e7e6-4e05-a70b-bbb0e5c93da0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2f9f857-c598-42e9-b2fa-03fa38727690", "AQAAAAIAAYagAAAAEPRc89LXhSm8be4T/NnhPVgMyncgiq9zB561alR+Ot/kwgSwpXUYTsf2C8jrCJl3+A==", "da71c53b-6368-4a25-80ce-318229f94c50" });

            migrationBuilder.InsertData(
                table: "ExerciseCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conditioning" },
                    { 2, "Strength" },
                    { 3, "Mobility" },
                    { 4, "Stretching" },
                    { 5, "Plyometrics" },
                    { 6, "Dynamics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseCategory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c94b737-ad0e-4279-a40b-81fbddbb2557", "AQAAAAIAAYagAAAAEButASgTjiJYujG9yzLPA6vwkeWIZJUjzxqTTFUYq+SB21hyK2/7z0rzremFMuMkqQ==", "56da670e-598e-4788-ab88-4e537f803a58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f90c6bfb-8727-465d-bdae-c8d690b63cf5", "AQAAAAIAAYagAAAAEIJ+XAQJaJhnk0Z9twMmedGMH3q0wblvdWbxWg1kFvVF/sZdlGrQNRyOqAXbqZWKAQ==", "bee1ca63-5828-414c-ba0c-7d8ae72edd09" });
        }
    }
}
