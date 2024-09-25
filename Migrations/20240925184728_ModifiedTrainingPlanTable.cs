using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedTrainingPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "TrainingPlans",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Repeats",
                table: "TrainingPlans",
                newName: "Units");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TrainingPlans",
                newName: "IsCompleted");

            migrationBuilder.AddColumn<string>(
                name: "BreakTime",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseUnitIds",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitAmount",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "511c3ee8-2eb4-48f6-ac3c-2bb2eeaa575c", "AQAAAAIAAYagAAAAEG9QCp6d0IBJoQo4fzHSunmXBeZaNAkYrdtFbcylcMxgVu1ZQ8lEwGf5NArc/vKvyQ==", "47a78f99-08e5-410f-a407-8f334a1fe583" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f85b67c4-6135-4770-b795-1dbb9dd70ac3", "AQAAAAIAAYagAAAAENceE+wPDhZkS7/HJXQSIxkkYz70T3Qb/CGoPIbgMQpxRpqnOh5Q93RkFALcxbdpjg==", "e6d51822-fdfe-4ade-8cd0-b3f1fbca0af1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakTime",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "ExerciseUnitIds",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "UnitAmount",
                table: "TrainingPlans");

            migrationBuilder.RenameColumn(
                name: "Units",
                table: "TrainingPlans",
                newName: "Repeats");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "TrainingPlans",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TrainingPlans",
                newName: "StartDate");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b52113c7-502f-42ca-97c5-ff056a2fb88e", "AQAAAAIAAYagAAAAEJ995f78cZhyJWBA4aJ4cLFLwIIL/UmYOMyUFskDdLVX8W6OW9cCqMRhXvqmv2lZaw==", "d1b9f9b0-a080-4abe-a49d-9f6c04f067b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ac426c5-6c91-458a-9cf8-0c4691778740", "AQAAAAIAAYagAAAAEPXMlH8aa2h3W6Arq+o06keZAlIiauVrzo3Bh40OaEFxgZj2VsY9qVb0qujEWoMLqA==", "6cb60de0-b3c3-4433-9fcb-85177d6a0493" });
        }
    }
}
