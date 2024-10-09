using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SetAsPublic",
                table: "Meals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5639099-1e69-40da-8b97-53a5b831157d", "AQAAAAIAAYagAAAAEBNbQtk/Dvw99VuRePOgdL8HZasgsOwKqE9ZZ+NLq+PVh1KDTlByGTWF4jCI9QkmjA==", "0999cac1-b9a3-4ccc-b6a3-43ce706acaca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e874840-c5e8-49ed-8990-223806574af5", "AQAAAAIAAYagAAAAEC4stfe8dtlOqp/L7qJB0g3qLjktxKabShXL9HHGW5rbFbHoW086US5IVfZ6EpFh9w==", "771fa703-1efe-4bdf-9e46-1be551e6c4e2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetAsPublic",
                table: "Meals");

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
        }
    }
}
