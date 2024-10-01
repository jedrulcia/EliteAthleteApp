using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCoachIdToTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoachId",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22e339c3-9a76-4bb0-8c3e-276b5a2d4d7a", "AQAAAAIAAYagAAAAEE2fh0LqVX2r1RRFCsccOJBUdszBd1U01MmOxhEgxvTs5jVMK7v4E5ScgAfQKu8Sow==", "84d0e791-2498-4ca4-b422-1b66a854acf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4179ec1d-9566-4ee2-a938-9ddbf465ced5", "AQAAAAIAAYagAAAAEAmpI4QgGzLhMjnoO9/9/JlQCTkZPPMGOFbtAisW6O57Wuu9WXtXRChY/03Xqvkn0Q==", "7daa13fe-7f55-4990-b221-21221993e489" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "TrainingPlans");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f85d0f0-6c4e-46b1-9691-3c3cd4cb82ab", "AQAAAAIAAYagAAAAEMMmA2YjWkXNp8YYFs7R3LJF9XJpB4lTe/0HxfFr/bQgqaOgpyX11yzc8yE0kKMIvg==", "87eb1358-90d7-4ea3-9560-595a59f1cf1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8a42cc4-fb3d-4295-b175-4374b5e7b607", "AQAAAAIAAYagAAAAELnf9+Yj5Rn2E8ESDjXijJe1j9DkZjTCaHDgB/bg7ARQ2facP1s/dLxXlJV6yNoMWw==", "84e89ce2-fa77-4613-b205-2503b645ab07" });
        }
    }
}
