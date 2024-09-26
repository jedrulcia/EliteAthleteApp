using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTPandTMtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingPlans");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingModules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fef669e-1d0c-4e51-a6fd-2d9902dd1b84", "AQAAAAIAAYagAAAAEBu8Gp7eFEUjhnJMcbKn9fpd8k6nVfqAorMqO6MXlNLdujtNwRBj788DSN2JDOjlVw==", "5b59f3fc-12fb-4770-8744-1601c5ec8e71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cc3b387-236a-4dd0-94cb-31489b7e9586", "AQAAAAIAAYagAAAAEEvhe/Xiw6VXFO4rvQvTOg+N9N8wGtby4I2b8BVyWN1f19JlKh7tJU9pE30Dv8QQ2w==", "d2cc315c-7d2e-46c6-be3d-11146d0058dd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingModules");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fe6c7d4-08a8-40b9-b753-be4aa7177a64", "AQAAAAIAAYagAAAAEKWtC/NJfsQAn+8OuZQZ7eUSdrrTxnl0yItoSI/nZzUZ+Zt+gX083RMoh9onmOTznA==", "610870e6-5a75-4eb9-92f2-ea87b1969cfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29774240-2b2a-4da0-9eba-2381c84f8892", "AQAAAAIAAYagAAAAEJCWcBRi0MNKCS6x7vqzilp9yRNkqQ5meGqi6xxdGKp/KXN5HIh2sZYWJ78r7HOYGQ==", "51c3f206-8a17-4d38-9d42-83b64e437e31" });
        }
    }
}
