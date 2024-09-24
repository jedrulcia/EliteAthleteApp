using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseCategoryId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f60635d-ae57-41d9-86d5-073210de46b0", "AQAAAAIAAYagAAAAEOreHwvu1qk0su5nH13uFG95zynk8rTRKpJ7pBZU4MSJ94a8uKEr6FNJbcAiqKE0Ag==", "13f2c19e-dc5a-4c4d-8cc0-a2c406e61f82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cd3b3c0-e771-43ac-82be-8238c4e45d0e", "AQAAAAIAAYagAAAAEG/pRFPArYWXCSXQgpkcbcbfiKxMTPhbBNq/Z67fmSRjawLxNpkVbcu5jYfvBexkXQ==", "38ad564c-30de-42ae-a7f1-e0f78d7976d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseCategoryId",
                table: "Exercises");

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
        }
    }
}
