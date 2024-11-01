using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingMoreUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBodyAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    FatPercentage = table.Column<int>(type: "int", nullable: true),
                    MusclePercentage = table.Column<int>(type: "int", nullable: true),
                    WaterPercentage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBodyAnalysis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Chest = table.Column<int>(type: "int", nullable: true),
                    Arms = table.Column<int>(type: "int", nullable: true),
                    Waist = table.Column<int>(type: "int", nullable: true),
                    Thighs = table.Column<int>(type: "int", nullable: true),
                    Hips = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBodyMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMedicalTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMedicalTests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9091b39c-5b16-4cb1-9497-b7cf2bac6585", "AQAAAAIAAYagAAAAEK0pdEeBGQzM8kBaLs/fO622Ps8adeDW4+8SbjQy5oas24hTNCaJJ/88oeKsz7Judw==", "0288e5af-a57a-4ec4-a3c6-946c58a49629" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60c567e6-a7fc-4db4-bb54-dad3dc61cee6", "AQAAAAIAAYagAAAAEDgGH8uHqs97HtZ7YzSXwcBNMEbULnsfnemOA89T++shxWM6fLsOi33/RORF2MoUvA==", "70001bb6-f68b-4142-ab24-1eb82995b32f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "057b9140-5bb8-48e6-a1fd-2c681dc0c0a0", "AQAAAAIAAYagAAAAECkOL3Z/Wg9g9zcoURLCXEhwgwX+b5bH78jc2MHuZDza6QndQx8llxueZuPapb6FVw==", "cb2ea85b-4b5e-40e6-9298-866e44ff9bde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBodyAnalysis");

            migrationBuilder.DropTable(
                name: "UserBodyMeasurements");

            migrationBuilder.DropTable(
                name: "UserMedicalTests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34b278fd-26de-4b3f-9bb7-0eea254d41c3", "AQAAAAIAAYagAAAAEGNCLQZBrurXwaH/ej1BAbPyLvd9yPQSDUOLp/0HTkwj3g4fs4rWBTWB1BBLAxap7Q==", "ee502a7d-6fb3-40ab-8e47-93e3541bb501" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da0c0a62-e5f2-400a-add2-11a11c187ce7", "AQAAAAIAAYagAAAAEL9IRt6nXDwyVIMsD1TRAP3xIjbr7YTUmd7L9h10NGmyO5HxNQ+uOh4egjCTmphscg==", "1fee53bf-8759-40d8-9ef4-0aac3b3a7452" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e89c7ae0-58e4-46fc-83dc-1fc8ea531bf9", "AQAAAAIAAYagAAAAEIWhSYLOs7Tkpz+t8oOHI4jeTgaYigb4ecXtBIyYt4hZ1pSpGeuOq7pgYxvyTwhIGQ==", "9002e2a7-2e71-42ef-83fa-41210b62fed6" });
        }
    }
}
