using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsEmptyToTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmpty",
                table: "TrainingPlans",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5555cf0-b080-4bbc-992e-10d4ba917db5", "AQAAAAIAAYagAAAAEDCUrgrs6E7xNHIeqwaXpm+5uZsDltUk7REYBucRtwf/KAg/vzl/PbhiUZgjufFfzA==", "e82ea751-d88f-4759-b5d7-5cb0ca21b0a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1da9ec75-3c0a-49aa-a5c7-70180c68b655", "AQAAAAIAAYagAAAAEPDmKSKDEMVb9kJN1N8dsXeE5zUuqEN6Xf/KSbChA0dPH4cQaoCH39IGfe6TzRAnRA==", "cf71ae87-5aac-470c-b602-147ad357fcaf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmpty",
                table: "TrainingPlans");

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
    }
}
