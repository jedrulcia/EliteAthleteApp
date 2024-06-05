using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedExerciseandTrainingPlanTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainExerciseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainExerciseVideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainExerciseNumberOfRepeats = table.Column<int>(type: "int", nullable: false),
                    RPE = table.Column<int>(type: "int", nullable: true),
                    AdditionalExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalExerciseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalExerciseVideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalExerciseNumberOfRepeats = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    OverallNumberOfSets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseFirstId = table.Column<int>(type: "int", nullable: false),
                    ExerciseSecondId = table.Column<int>(type: "int", nullable: false),
                    ExerciseThirdId = table.Column<int>(type: "int", nullable: false),
                    ExerciseFourthId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_Exercises_ExerciseFirstId",
                        column: x => x.ExerciseFirstId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_Exercises_ExerciseFourthId",
                        column: x => x.ExerciseFourthId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_Exercises_ExerciseSecondId",
                        column: x => x.ExerciseSecondId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_Exercises_ExerciseThirdId",
                        column: x => x.ExerciseThirdId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}
