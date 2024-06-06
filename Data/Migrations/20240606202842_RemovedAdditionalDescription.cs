using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAdditionalDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalExerciseDescription",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "MainExerciseDescription",
                table: "Exercises",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Exercises",
                newName: "MainExerciseDescription");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalExerciseDescription",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
