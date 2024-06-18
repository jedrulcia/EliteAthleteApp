using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingDietModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingPlanVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExerciseFirstId = table.Column<int>(type: "int", nullable: false),
                    ExerciseSecondId = table.Column<int>(type: "int", nullable: false),
                    ExerciseThirdId = table.Column<int>(type: "int", nullable: false),
                    ExerciseFourthId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    RedirectToAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseFirstId",
                        column: x => x.ExerciseFirstId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseFourthId",
                        column: x => x.ExerciseFourthId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseSecondId",
                        column: x => x.ExerciseSecondId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingPlanVM_Exercises_ExerciseThirdId",
                        column: x => x.ExerciseThirdId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanVM");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c83bfad8-1276-417b-9734-fb1a8f6939ed", "AQAAAAIAAYagAAAAEGOGvIvdRWdZQ3ixL+VzHeF62Va2gt5A1BapK0t3TgX+rF1TW1WeT0aQLit26n6FOw==", "e231d27e-5727-48a2-b29f-31dab105492c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f09f966-b3b3-4097-80af-deb23244afe8", "AQAAAAIAAYagAAAAENR68lBg5BUAP8LvbA+fc3u0SZWWauWj8orxaK9qrhdUVwckBNjmEF1aTwVz1OUinw==", "df2dc43d-28b8-45b3-a81b-c1876411d3ff" });
        }
    }
}
