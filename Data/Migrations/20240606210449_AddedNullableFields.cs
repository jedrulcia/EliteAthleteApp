using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableFields : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseThirdId",
                table: "TrainingPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseSecondId",
                table: "TrainingPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseFourthId",
                table: "TrainingPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseFirstId",
                table: "TrainingPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OverallNumberOfSets",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MainExerciseNumberOfRepeats",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalExerciseNumberOfRepeats",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseThirdId",
                table: "TrainingPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseSecondId",
                table: "TrainingPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseFourthId",
                table: "TrainingPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseFirstId",
                table: "TrainingPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OverallNumberOfSets",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainExerciseNumberOfRepeats",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalExerciseNumberOfRepeats",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseFirstId",
                table: "TrainingPlans",
                column: "ExerciseFirstId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseFourthId",
                table: "TrainingPlans",
                column: "ExerciseFourthId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseSecondId",
                table: "TrainingPlans",
                column: "ExerciseSecondId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Exercises_ExerciseThirdId",
                table: "TrainingPlans",
                column: "ExerciseThirdId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
