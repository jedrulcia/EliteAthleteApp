using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnToMealsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientQuantities",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbd19402-9606-4a21-882a-42d62b72f301", "AQAAAAIAAYagAAAAEBpSEkjsxZDiP+fKXE+nsPV2Ft/CwzbLHs2/NP/xBpJRG62jGyPtfoVgeWxCaQsccA==", "46f2d312-9174-491f-8caa-509318162ee5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce3bf524-40e9-4d14-b80a-f5f81bbd5dd9", "AQAAAAIAAYagAAAAEOTMd+opMKqebvrZHmKcwAt4oS8QU0LFBcYsEMOp2oU9iXeW0zCqXnyHG/NDmRpmLA==", "68ff5223-3361-497a-9e00-f62d9f1043ad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientQuantities",
                table: "Meals");

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
    }
}
