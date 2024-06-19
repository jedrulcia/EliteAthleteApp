using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionToMeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c395c298-5b87-4e8f-b6d2-8786c7780f54", "AQAAAAIAAYagAAAAEBu/7OtFoFV2ACY+hVZ2vuJbrfmvRy7BSRUbUdlVniiGgCc/cruyMFeRcDBp/vwSzA==", "76d32130-d839-48f2-8dca-98821f2d984a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8928c97e-d873-434b-a6e1-0e8742d06425", "AQAAAAIAAYagAAAAEAAQBRndQIXqcjlYcfgtsNjwoQ2Kduk8QRszkb3PEvl4xmAO2TwUzTLefvAsqUg2Zw==", "290f7241-c843-44bc-99b2-b54c11d3ddb4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Meals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397c24da-8136-4871-ae2e-61b22ea4b892", "AQAAAAIAAYagAAAAEK2pCYwf4x7SNBXiKj/X1wUKs9InvmgEnxI2D/+622VQT+sjv13Qo9PSAQcViFDN/g==", "8aec876b-3013-4e5a-bf9d-76db57b9ffd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee1c58e3-f277-4ca7-84c3-3c49261170e7", "AQAAAAIAAYagAAAAEDjRpZvgE9EWL11b+lpt4ugqheUU01zL3wfByts11ASt4tKw7dIWZyKSeUjduviCEA==", "3f81719f-9ba0-446c-9399-6dc1a770d203" });
        }
    }
}
