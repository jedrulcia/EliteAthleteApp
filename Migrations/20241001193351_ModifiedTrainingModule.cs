using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedTrainingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TrainingModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TrainingModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15a639da-5ce6-45a7-9318-8cb7a98b8acd", "AQAAAAIAAYagAAAAEAnpNjMOSFwi1JfqeDTozrluWbbqh06mRyXHBLkmdB3nq1FKjxOX2OWf2VLS14JhRw==", "16654db2-eb2e-46ec-b063-b22ef2659efb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43cf9a89-d92a-4585-ad29-7788d6d9f82f", "AQAAAAIAAYagAAAAEOF3CcPp5JsiLfaQacrwtby82qwdtWSC57LXhseFrTZhMROYTTSl9/1QMUgHiCCWXQ==", "2937c224-2b0e-44d8-98cb-f2ed1523410b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TrainingModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TrainingModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22e339c3-9a76-4bb0-8c3e-276b5a2d4d7a", "AQAAAAIAAYagAAAAEE2fh0LqVX2r1RRFCsccOJBUdszBd1U01MmOxhEgxvTs5jVMK7v4E5ScgAfQKu8Sow==", "84d0e791-2498-4ca4-b422-1b66a854acf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4179ec1d-9566-4ee2-a938-9ddbf465ced5", "AQAAAAIAAYagAAAAEAmpI4QgGzLhMjnoO9/9/JlQCTkZPPMGOFbtAisW6O57Wuu9WXtXRChY/03Xqvkn0Q==", "7daa13fe-7f55-4990-b221-21221993e489" });
        }
    }
}
