using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseCategory",
                table: "ExerciseCategory");

            migrationBuilder.RenameTable(
                name: "ExerciseCategory",
                newName: "ExerciseCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseCategories",
                table: "ExerciseCategories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "475e3856-365f-46e8-97c3-fc26313000b7", "AQAAAAIAAYagAAAAEOoMzELjR8L6NBrb+m5njJWytlzILV+zNLEuYKxUpvZIZwSlDLTu9WFHUAUTEFVBdw==", "f65716b3-a4f0-44dc-82ff-d255ffed214f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cdd5d8a-a828-486c-a800-cbc74b6357f2", "AQAAAAIAAYagAAAAEHD7z1pEggCBn5YOFs07FGDbX/RF9R+c7ZjUz/d4MSz0lLHU0C25JcPlheh6HL9+Xw==", "becef6fa-a989-4478-b8c8-1f762b068ae8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseCategories",
                table: "ExerciseCategories");

            migrationBuilder.RenameTable(
                name: "ExerciseCategories",
                newName: "ExerciseCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseCategory",
                table: "ExerciseCategory",
                column: "Id");

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
    }
}
