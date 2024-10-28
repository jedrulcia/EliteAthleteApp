using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseMuscleGroups",
                table: "ExerciseMuscleGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseCategories",
                table: "ExerciseCategories");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "TrainingExercises");

            migrationBuilder.RenameTable(
                name: "ExerciseMuscleGroups",
                newName: "TrainingExerciseMuscleGroups");

            migrationBuilder.RenameTable(
                name: "ExerciseCategories",
                newName: "TrainingExerciseCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExerciseMuscleGroups",
                table: "TrainingExerciseMuscleGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExerciseCategories",
                table: "TrainingExerciseCategories",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExerciseMuscleGroups",
                table: "TrainingExerciseMuscleGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExerciseCategories",
                table: "TrainingExerciseCategories");

            migrationBuilder.RenameTable(
                name: "TrainingExercises",
                newName: "Exercises");

            migrationBuilder.RenameTable(
                name: "TrainingExerciseMuscleGroups",
                newName: "ExerciseMuscleGroups");

            migrationBuilder.RenameTable(
                name: "TrainingExerciseCategories",
                newName: "ExerciseCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseMuscleGroups",
                table: "ExerciseMuscleGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseCategories",
                table: "ExerciseCategories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7b44d33-d842-4c4e-a5ab-baf8f024e0a5", "AQAAAAIAAYagAAAAEDV9PYTWlUTVfMBhGKUzgQV6hpv0SzsPKIzsE7SD3uvG0wC7xL0e+LfNR5CxHrUoCg==", "523fc6e9-4d07-41e4-b9b2-dfa3820bb474" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebf886a9-ec0a-4c07-a5c6-5eeb42388401", "AQAAAAIAAYagAAAAELqS3kLr2b6w6hVQx4p3XZcCIp7Hu+3XJ4OgcOIWn3c+t9S4B8amuaNQ0jsGyIGAkA==", "73183961-3c3b-49dc-a7c8-1535d2c6e9a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be771aa7-2c7f-428f-b310-1887bccfbce8", "AQAAAAIAAYagAAAAEKJ2z8xF5TXtw4dL3IVkHk/CEmAhUzal/0ubE3vuoQwsiRBAf2pL+3Jw1MQU5bIFtQ==", "82c8409f-0711-4273-8554-c5911eaed05f" });
        }
    }
}
