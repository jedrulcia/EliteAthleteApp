using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DieticianId",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c500f9e-b43c-427d-ac22-8c6e36310b7d", "AQAAAAIAAYagAAAAELWiyT9NtWGS4Lr6o3zSo5WOhfo//9bDQdiqdF3uotZx0hv3YwYRRTEhjbG96mxT1g==", "ff37dded-5b73-41fe-9532-c5544d1fef8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55716eb6-b7ef-4283-85d5-bd4584ed6e47", "AQAAAAIAAYagAAAAEGHqE/P5YqOdcY2r8FsoaoZYXLtLssGzQTlyry02F7PwDnLojzrkae9jV1VGvuxwGA==", "60d9b128-7e7e-487e-9376-6adcd1017c93" });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, " " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "DieticianId",
                table: "Meals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5decb441-7a90-494f-b7b5-3bfbc3620ae0", "AQAAAAIAAYagAAAAEA1Yk2dK2WblIsMS4jIdUSCrq/Ypi/lydGkCPnx7TDyqJObY5RWQOhpPUDgAM69pTQ==", "a9520576-7a4a-4ff6-a236-871acad1fff9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc4f4aa5-a84e-401d-a597-570dae8af686", "AQAAAAIAAYagAAAAEEaxs1Tkm87fieVzxixfjpX6d358iArsX5m8yN1U72NkhflU4BHrtffQ7QpXb0oWEw==", "f9a0b9b9-0c4f-4593-b5f4-b9c0ed13f799" });
        }
    }
}
