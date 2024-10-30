using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddinExerciseMediaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "TrainingExercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseMediaId",
                table: "TrainingExercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingExerciseMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrlFirst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrlSecond = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrlThird = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExerciseMedias", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80f4536d-6730-4cd1-977f-20e748190d3c", "AQAAAAIAAYagAAAAEOy0rS5QRGvopOZfK5MEiQhboJFCyz8V1OUborn2Ig135mDIoKVtWYGZQ9GUD9FC5Q==", "9a56458f-e990-4125-b22d-9efd8c82859f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "679d371b-f387-46e8-b5a7-95d01739e84e", "AQAAAAIAAYagAAAAEMPIGYtVPoZ+zfJ9rlVIIHodPzSkfK5J5r0f6gTbwb62JmlTZuaobGWzYhd4W76V6A==", "a8f8388d-5cac-447a-8685-c5ea1bf892dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5757cb39-0257-463c-bb35-c63d9bf56366", "AQAAAAIAAYagAAAAEK9qHcQzWW5V0bwOgG9asoCHN+j7NgclklgBX+ng/ca1jhx8dO5kGiL4Wr3FEwjoDg==", "cd1b93d8-7400-4ec6-a228-d1d3d2d95390" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingExerciseMedias");

            migrationBuilder.DropColumn(
                name: "ExerciseMediaId",
                table: "TrainingExercises");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "TrainingExercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57e1c4d6-4a25-4ec8-aa5e-0cc4b1b3a28c", "AQAAAAIAAYagAAAAEAEfAH9MKODIeAxbZf/8FY1hNreTkMvrL5PPG4HrNMU1voxMf88brQ6uxNFkkfUhnA==", "2c3c79e8-cdf6-42bd-af4d-52dd9263caeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4bfe3d3-c608-45c8-a282-29d59d84d596", "AQAAAAIAAYagAAAAEFcagudRPYJKn/F3/tOWU0VrSxgCBAMH33wFVsdUPZNKMlVVQEVx22djxcvK73t5ng==", "070dd298-1cbb-4a40-b8c1-71416146d381" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "813d9cec-a6a6-4a66-8ba4-57b3f75f2130", "AQAAAAIAAYagAAAAEAAetGRMkQdw16mAubYbQQWVvCD/VJ//VVVuYzbApPrilgvonulJZPMSBaQo4nI+cQ==", "2f8e7f76-6a1e-48eb-9e8e-607760f8a0ea" });
        }
    }
}
