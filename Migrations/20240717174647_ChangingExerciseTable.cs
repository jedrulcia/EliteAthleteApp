using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalExerciseName",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "AdditionalExerciseNumberOfRepeats",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "AdditionalExerciseVideoLink",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MainExerciseName",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MainExerciseNumberOfRepeats",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "OverallNumberOfSets",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "MainExerciseVideoLink",
                table: "Exercises",
                newName: "VideoLink");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38733a14-dc66-4dd6-be73-9caf9a85d05d", "AQAAAAIAAYagAAAAEAE2Gq26bu6rw9TMg+P5HP+cjVaOfEiSX1OyvI8XqHdJC+0tno77SI4etiHyDniHQg==", "d68bed2f-54af-4067-9320-73037e27e903" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18f98540-7c84-44c2-81de-6c2bca68678b", "AQAAAAIAAYagAAAAELpa2eZeoxPDq3qqmMpFo+ZmA1heVK+ZejHh662EVHJjuDalwpYOOO/yQkaj3XB9hw==", "0b268527-45cd-4de8-8b04-4df52d46992f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "Exercises",
                newName: "MainExerciseVideoLink");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalExerciseName",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalExerciseNumberOfRepeats",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalExerciseVideoLink",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainExerciseName",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainExerciseNumberOfRepeats",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverallNumberOfSets",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c395c298-5b87-4e8f-b6d2-8786c7780f54", "AQAAAAIAAYagAAAAEBu/7OtFoFV2ACY+hVZ2vuJbrfmvRy7BSRUbUdlVniiGgCc/cruyMFeRcDBp/vwSzA==", "76d32130-d839-48f2-8dca-98821f2d984a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8928c97e-d873-434b-a6e1-0e8742d06425", "AQAAAAIAAYagAAAAEAAQBRndQIXqcjlYcfgtsNjwoQ2Kduk8QRszkb3PEvl4xmAO2TwUzTLefvAsqUg2Zw==", "290f7241-c843-44bc-99b2-b54c11d3ddb4" });
        }
    }
}
