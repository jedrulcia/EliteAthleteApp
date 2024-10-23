using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingExerciseDetailsLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseIds",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Indices",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "RestTimes",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "TrainingPlanPhaseIds",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "TrainingPlans");

            migrationBuilder.RenameColumn(
                name: "Weights",
                table: "TrainingPlans",
                newName: "TrainingPlanExerciseDetailIds");

            migrationBuilder.CreateTable(
                name: "TrainingPlanExerciseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    TrainingPlanPhaseId = table.Column<int>(type: "int", nullable: true),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanExerciseDetails", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f577fa85-77ae-426e-97ea-1a5ca4b32efc", "AQAAAAIAAYagAAAAEDyMhBjgqLPTgtKxS1c4EQyniUwGvOgBjbcKqyhG74jqqXCVEkvoYhOCHlSJ9kYgNw==", "1c7f6a5c-8b0a-43d9-8a1e-3d411648fe0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d322487-1d0d-44e2-a7b3-041ff6ebb704", "AQAAAAIAAYagAAAAEAUDT3hWdI9X0wXaCYUmQ9n6yDal8V57sOrYMfkTriyo9a6rZM7yZ/560xYqdMThVQ==", "d0332594-b4b4-4829-8d28-072d6eb64657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7d762e0-bb39-416f-a9ab-3838168e209a", "AQAAAAIAAYagAAAAEAbSetgwf4XkAHDc0aqb5RorWFOZ7yHvR8qQJ1bnsq2NhhGdNfUZureOos2J/mvzJA==", "4d54d22d-269f-4db9-8ba3-e6dd0534678a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7cb25fd-c798-4d36-9d8d-898ad7f1f007", "AQAAAAIAAYagAAAAEDXu4fVz8Apux9EyE3bsMscHNkw6xu1F+jRqYgFghyi4kqRFo28Vr5VsHuxVuuX7dg==", "1ef8d78e-6a83-40f2-adde-56d8e4d264b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "935eb316-f530-4946-9cd8-710c5b54dc70", "AQAAAAIAAYagAAAAEEG19w8CsKdSHTiajDhH20XTY40yeXP4EoqZ4k1RtEx7lNaPI1ClBlL1cnDlLC7zqA==", "9287a34f-2379-40bf-a3ec-e61b877eec7c" });

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "Trapezius" },
                    { 17, "Adductors" },
                    { 18, "Abductors" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanExerciseDetails");

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.RenameColumn(
                name: "TrainingPlanExerciseDetailIds",
                table: "TrainingPlans",
                newName: "Weights");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseIds",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indices",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestTimes",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sets",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingPlanPhaseIds",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Units",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc53b09e-23d5-4f1e-abb1-445d2c528226", "AQAAAAIAAYagAAAAEIIVnFsOlaWH4k6omVTOFYIRn+X0lRwusdVaR0ZR3upoghdpeCYEz9RytlEbStAixQ==", "3fe223ae-39c9-47e1-ba56-95e04df1643f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "859c76a6-7756-4197-bfce-fb1554ad0336", "AQAAAAIAAYagAAAAEKyGoro0mMkk34GGlzY6yMNauT0sRimbhe18JO9/Uba/B48Rxv08CJQXw5FMpVX+TQ==", "3939c3ee-266f-4cb5-8cb6-6846c9809eac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12d241d3-46a8-4778-93eb-cec9b4475364", "AQAAAAIAAYagAAAAEF5W110felwSUrR1idV6eoWknvlFXMut3nf0A/mNWed7t8xM+X6kFagWHDySZak1wg==", "1691d81e-85a0-4fb0-9597-1ac22d8cbec0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b080838-eabb-472f-89ed-a5d1df18ebc9", "AQAAAAIAAYagAAAAEJzt9wp+YfV+oXzhI8ulNjLUss0I/gdxeJzk86bHt6Six8kTbw3piOHr8pQ10NCpvw==", "a2865e05-8b18-480c-846d-96338c008014" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb62d402-a2da-4af8-9096-71e2343e776b", "AQAAAAIAAYagAAAAEEG0ImmyojymQDSTiUM5TIsQqdGat75HQD8OT638UqWTvNCE5Bwr/H24xVAKLr4QDQ==", "c6403a95-e9e2-4f06-9ebd-7472a5ee697c" });
        }
    }
}
