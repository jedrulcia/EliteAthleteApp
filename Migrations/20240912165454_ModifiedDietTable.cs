using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20458d0e-7b6c-4acd-96d2-7932172aea0e", "AQAAAAIAAYagAAAAEBwiwAE5nCIHpJ2NVwNtFtHqS2srzKa836A9OCr/2txVxKo/eE7PyKGmkA/9CWVKww==", "6bcace68-ac00-4489-9b92-6937b276bff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15cac3b2-022e-4849-bfda-a5554a16e47c", "AQAAAAIAAYagAAAAEMlzSjrU9CwISjBV4MUTeXbATk/WOckjzdxMPbh2IobKNFS+HHK0zBCGBiwPFSLIvQ==", "ca7b63fa-6f48-4b12-803d-e08696058b88" });
        }
    }
}
