using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddinguserSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserSubscriptionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateExerciseLimit = table.Column<int>(type: "int", nullable: false),
                    AthleteLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserSubscriptionId" },
                values: new object[] { "4310709a-1fcd-4633-a71e-c3901eea6bd8", "AQAAAAIAAYagAAAAEOFgKjpw/5bL6HFj/GS7GXDN/oi5t13x/EWHNMCaiZ8xsxKGKIcdxJMTBWAczxIjgA==", "452af9e9-ceeb-4b88-a33f-ee38438c768e", 4 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "CoachId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserSubscriptionId" },
                values: new object[] { null, "c8c51f70-3bc1-4aca-9ad9-746302d793e6", "AQAAAAIAAYagAAAAENuotjqqaeQ+dnKXl1dwcTNlxsS12PD1zZdsUHgyGh5m1dF5lK+FxQsJz0u8xFx9nA==", "49554d23-9a37-444d-afce-ba53b69a392d", 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "CoachId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserSubscriptionId" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b2", "35fb2b92-f7b3-42f0-b4f5-c6e3af640ec0", "AQAAAAIAAYagAAAAEFdsCJiwkIC9sGTMQf7vA66ObxF733KWBODMHEroLxNYKU1YR3LtD1SLWJIzHE0UvQ==", "a7233be8-cfc5-4062-8e9f-06c1a4cf0a53", 3 });

            migrationBuilder.InsertData(
                table: "UserSubscriptions",
                columns: new[] { "Id", "AthleteLimit", "Name", "PrivateExerciseLimit" },
                values: new object[,]
                {
                    { 1, 0, "Athlete", 0 },
                    { 2, 3, "Free", 5 },
                    { 3, 10, "Basic", 20 },
                    { 4, 200, "Premium", 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "UserSubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eed8878-2e96-482c-be3b-b1587027a6dc", "AQAAAAIAAYagAAAAEFzfCl2txqN3f4xIyZISVseJGkqX7cfmBTqqx/jciEi7Q170glP6AA4faIWW3PSiOQ==", "2096bcac-8e26-40b8-ae32-cf3acd223649" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "CoachId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b0", "5485afaa-5df9-4891-8b47-b3df30a5b39b", "AQAAAAIAAYagAAAAEGR6z+oVMsxdVmwZlSw3sRyAryKU+6tAGGIUvsZ1J0QMM9qTFEJkha8QYI/j2EXHdg==", "79400491-ab33-4967-a126-3c6cfd05cbb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "CoachId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b0", "07c8dfbe-025e-407a-a761-e34d2d2f6ba3", "AQAAAAIAAYagAAAAEMt6Z8quJCT3dAd7VZJpMVKWrP+w5uzI5ywkqUqSS10lZE0syiqdwLu3su5AH07A2A==", "db1dded7-6584-40d1-8889-de9e072a0f69" });
        }
    }
}
