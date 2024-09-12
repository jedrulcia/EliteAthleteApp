using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDietTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Diets_DietId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_DietId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "MealIds",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a7ddaee-0f3f-4b64-9305-3edfb05e1b84", "AQAAAAIAAYagAAAAEACoG3/NrRRHV14/TlQqWSZhFn/inh8FbHIWCo94qLmdz9pnXC3juZxK6ujY/7+O4A==", "8a10bea8-df78-465e-90f9-b3be49e66c7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01026c49-89e6-495a-955d-15605588ddb2", "AQAAAAIAAYagAAAAEGZl9BcQLjywPbzy0qmPUzElhiSJkcn+Yj8ZCVbPLVmGzC1jY9yEYyck1/5EBefKYQ==", "a3314e01-ef50-44db-ac75-b189e54028fa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealIds",
                table: "Diets");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25db788a-1e90-4ed0-a487-58acedf2ac22", "AQAAAAIAAYagAAAAEBzt8A3tu+9A34gLkJI3gnhCeK8uC4R1z5SDU8u9n/EeJ5B9jX7hQdWRiPd9g+EIqg==", "9ac5c06a-297f-4d86-a2b8-1cf0a24dbffd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61e2728a-b071-4408-bf9b-55ff479cfcf2", "AQAAAAIAAYagAAAAENGSTiPfh48+JBVA6c9Lp8UZokorz6zCZ/oIAbBVmT0yZa2vgR2o5reouZwIB4SQIA==", "1ad71679-ff3e-48d5-b3e9-e74b6ecfea1a" });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_DietId",
                table: "Meals",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Diets_DietId",
                table: "Meals",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id");
        }
    }
}
