using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Meals",
                newName: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "IngredientIds",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b2c0242-8cc2-4288-851f-e465935f80cf", "AQAAAAIAAYagAAAAEOg1xQelzshELLQ718v1z8z0Rf4ltE0cEPtIOuJD/qJ4vAEB0pI0NQpMdnlCPIIfDA==", "898da8da-dafb-4784-95d7-cba2bd5f5c6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e38379f-2618-4387-9b7e-cd9560a35cc2", "AQAAAAIAAYagAAAAELQyc4UPumSHXgJOhia7JuPpHUH34a+elFMQjP/zBZtMd8go74I2NZrqvnTDBmPXbg==", "9a8c311e-c200-4f03-9297-d9bf3ffd1b36" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientIds",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "Recipe",
                table: "Meals",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc1689a0-917f-4a69-8e63-d08220139f0d", "AQAAAAIAAYagAAAAEDDNllGclf+H3zgG58lZeAm49lriqBT2TPQitnUZwiMc6pLFaAWnfgJ5YR/4p6gMyQ==", "f5c65c52-4cd9-4337-a3dd-e48e132ac0aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f721e073-29ae-4ae8-b9f5-0dac535f8902", "AQAAAAIAAYagAAAAENMMDjU9MkwsBMQsUUTvUrP3e5YUBNq1e5JTlYaGTR4ASbTF+HpsBgFVMJZSLLmDRg==", "d174de52-ca7b-48a2-993e-d62bc2095945" });
        }
    }
}
