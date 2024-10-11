using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingFKToExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseMuscleGroupId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fec0c30-6460-46c8-adcd-c62ed3e875f5", "AQAAAAIAAYagAAAAEOTGiOM5gJOBx8wHbB7rlh7plxNgXg/ujxxriiuHF5pLm7Q9EZG+Fmvd3JXp77nkpw==", "577d70c6-7bdd-41d8-ab98-ee55f076e4a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "728de00b-8660-4f60-912c-acdfa447764a", "AQAAAAIAAYagAAAAECNR5BogccEMF3pYmkMdBaD2tR7HKNrgWnu/x6SINIGjaHEVW6xoG9+WdixrNptDYA==", "a6016ace-c9ea-458c-aa22-5e4b0166069a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseMuscleGroupId",
                table: "Exercises");

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
        }
    }
}
