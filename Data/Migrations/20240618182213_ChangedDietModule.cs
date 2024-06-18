using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDietModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kcal = table.Column<int>(type: "int", nullable: true),
                    Protein = table.Column<int>(type: "int", nullable: true),
                    Fat = table.Column<int>(type: "int", nullable: true),
                    Carbs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_Meals_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Diets_Meals_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Diets_Meals_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Diets_Meals_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Diets_Meals_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServingSize = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2896c0b3-b070-47f6-80c1-2c25a654912d", "AQAAAAIAAYagAAAAEPA8CKShq/viSyvrmSnoZfo+iYBVYcguSQEEI8ain31t4aOG0kTxZmsuW/TWoGCZ8g==", "73ce84d6-6904-459f-8798-27b612fb339c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82e939bd-0c7d-424b-a0cd-0d415a120a29", "AQAAAAIAAYagAAAAEG9AcUgzE1Viv2oOZqLKwlzqcNDDSKxbsU1nG8jnjRBaYF+jYxF+9LRX/xFsV5IiUA==", "e55a2928-96a3-4140-998b-228b9ba27980" });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_BreakfastId",
                table: "Diets",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_DinnerId",
                table: "Diets",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_LunchId",
                table: "Diets",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_SecondBreakfastId",
                table: "Diets",
                column: "SecondBreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_SnackId",
                table: "Diets",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MealId",
                table: "Ingredients",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.CreateTable(
                name: "TrainingPlanVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseFirstId = table.Column<int>(type: "int", nullable: false),
                    ExerciseFourthId = table.Column<int>(type: "int", nullable: false),
                    ExerciseSecondId = table.Column<int>(type: "int", nullable: false),
                    ExerciseThirdId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedirectToAdmin = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseFirstId",
                        column: x => x.ExerciseFirstId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseFourthId",
                        column: x => x.ExerciseFourthId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseSecondId",
                        column: x => x.ExerciseSecondId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseThirdId",
                        column: x => x.ExerciseThirdId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9baa65f-ae7c-45ec-8860-38397f7a907c", "AQAAAAIAAYagAAAAEDLKLUvWLu9ysh5ULHnoFbu17gi1sU4Fh4CRLHyT7CVrfUuYsSl1T53hYTZkvVeTSw==", "d96ef97e-ae1f-4f9d-8f79-bd51172c7a47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b2fa971-349f-4291-8184-50ea5138299a", "AQAAAAIAAYagAAAAEP06pusEkEJrIrFXiSQ1YwUjrwXk8+oXBwE9w7+wOpSsGmrP5tniNFLaJ4e7dOgQfg==", "f7c378f4-e8f8-446b-92f0-ea52666ef2b5" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanVM_ExerciseFirstId",
                table: "TrainingPlanVM",
                column: "ExerciseFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanVM_ExerciseFourthId",
                table: "TrainingPlanVM",
                column: "ExerciseFourthId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanVM_ExerciseSecondId",
                table: "TrainingPlanVM",
                column: "ExerciseSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanVM_ExerciseThirdId",
                table: "TrainingPlanVM",
                column: "ExerciseThirdId");
        }
    }
}
