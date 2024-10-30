using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangingLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrlFirst",
                table: "TrainingExerciseMedias");

            migrationBuilder.DropColumn(
                name: "ImageUrlSecond",
                table: "TrainingExerciseMedias");

            migrationBuilder.RenameColumn(
                name: "ImageUrlThird",
                table: "TrainingExerciseMedias",
                newName: "ImageUrls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d33d6340-6826-466e-8b98-10d82d24cffd", "AQAAAAIAAYagAAAAED62HoVOfBnPf93MF0cInyxdzjGR8yHLiT/CKib8Iz5wFmM+JSVClFHeyKD19DsQjw==", "15989755-4628-4cbf-b558-db6eaa906120" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d851be0-1b5e-4f01-b053-f7475b753ff1", "AQAAAAIAAYagAAAAEFbxeJCz5BWYSPnD/tYULGKSsUUnhwCWa1Q0ulDl7IWzdKnqmD0csTh05mVMY3V9gg==", "842b6532-6c92-4a91-ac4b-96fc5d2002d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "763bbfcb-a3c8-4c38-93f2-4bc48e0a9398", "AQAAAAIAAYagAAAAEKt+aSIhhZzKa6FMvnfYKX9+2A1Qn3nNKdgC4PCvYVNZQ9+GZ/+qwSuPOF0d52pk+g==", "2e94e4b7-7cec-4c13-87de-c4c25b5cbbd3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "TrainingExerciseMedias",
                newName: "ImageUrlThird");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrlFirst",
                table: "TrainingExerciseMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrlSecond",
                table: "TrainingExerciseMedias",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
