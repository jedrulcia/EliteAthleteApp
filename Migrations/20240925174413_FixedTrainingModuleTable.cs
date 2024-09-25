using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixedTrainingModuleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_TrainingModules_TrainingModuleId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_TrainingModuleId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "TrainingModuleId",
                table: "TrainingPlans");

            migrationBuilder.AddColumn<string>(
                name: "TrainingPlanIds",
                table: "TrainingModules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9395f7b-b128-46ef-a618-ab75c0a51b6c", "AQAAAAIAAYagAAAAEGwonWn+mzFTJVxihm8ItC1DlzvhAfvctbiHT+ixQTTZAZNIDjZdMHI241E+3vg3Kw==", "03068e9c-db7d-4e25-a143-60b9c5614792" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0046fc74-84af-4dc1-b83b-f72767d1cf88", "AQAAAAIAAYagAAAAEF4OzfQ/QCo9OzlvedC7RdR95BfTNDFzQTblA4vhvSl57JaWsKRblw35ssfVnNreEg==", "4bcd6e35-daae-46ea-98fb-bc8ec7b1b1f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingPlanIds",
                table: "TrainingModules");

            migrationBuilder.AddColumn<int>(
                name: "TrainingModuleId",
                table: "TrainingPlans",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca2667f-1fda-4cb1-95a5-1e2aa04dbca5", "AQAAAAIAAYagAAAAEN+eHmZKNWj+4895ixFwFCSBJklQMcwS2Qncpiy+e106kYbDDQpqorKn5VUk6JQdYw==", "375b6745-312a-48a7-ae73-9146ccf284d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "036bb713-b338-445e-a374-85fb109dcc66", "AQAAAAIAAYagAAAAECrPhyIuaU0Cmpc7gSB+tLXEkHj5GlG6JHYHCjvTWc0nFzhJ3czRwlp1tNiu9hmdTg==", "11959d48-5ea6-40e6-b08c-d950f25a3836" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_TrainingModuleId",
                table: "TrainingPlans",
                column: "TrainingModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_TrainingModules_TrainingModuleId",
                table: "TrainingPlans",
                column: "TrainingModuleId",
                principalTable: "TrainingModules",
                principalColumn: "Id");
        }
    }
}
