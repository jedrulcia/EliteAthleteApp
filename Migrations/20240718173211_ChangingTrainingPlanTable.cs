using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTrainingPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseFirstId",
                table: "TrainingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseFourthId",
                table: "TrainingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseSecondId",
                table: "TrainingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseThirdId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_ExerciseFirstId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_ExerciseFourthId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_ExerciseSecondId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_ExerciseThirdId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "ExerciseFirstId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "ExerciseFourthId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "ExerciseSecondId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "ExerciseThirdId",
                table: "TrainingPlans");

            migrationBuilder.AddColumn<string>(
                name: "Repeats",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sets",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingPlanId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0a1cfec-d9b0-4d0a-8731-a201ed2d234c", "AQAAAAIAAYagAAAAEFxxaTQQNvJrWeAKFStwWxy46cVIp+CfRk7BF8GBfrSsJqVLZx3piECHRRAs3MA7qQ==", "07761812-1084-4270-bef1-35739c64e50d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c58f36c-cbb8-4557-aecf-9ba1b603f728", "AQAAAAIAAYagAAAAEAlwUqdtK19CAv4VMYbpz061Ebu+htfEDKfnICoIlc6MrgqFaFE2e/SSViDDC+SzQg==", "a1333278-b636-48d4-a175-a9183b313120" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingPlanId",
                table: "Exercises",
                column: "TrainingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TrainingPlans_TrainingPlanId",
                table: "Exercises",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TrainingPlans_TrainingPlanId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingPlanId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Repeats",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "TrainingPlanId",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseFirstId",
                table: "TrainingPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseFourthId",
                table: "TrainingPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseSecondId",
                table: "TrainingPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseThirdId",
                table: "TrainingPlans",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_ExerciseFirstId",
                table: "TrainingPlans",
                column: "ExerciseFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_ExerciseFourthId",
                table: "TrainingPlans",
                column: "ExerciseFourthId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_ExerciseSecondId",
                table: "TrainingPlans",
                column: "ExerciseSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_ExerciseThirdId",
                table: "TrainingPlans",
                column: "ExerciseThirdId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseFirstId",
                table: "TrainingPlans",
                column: "ExerciseFirstId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseFourthId",
                table: "TrainingPlans",
                column: "ExerciseFourthId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseSecondId",
                table: "TrainingPlans",
                column: "ExerciseSecondId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseThirdId",
                table: "TrainingPlans",
                column: "ExerciseThirdId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
