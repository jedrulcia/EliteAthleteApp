using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class RemovedKcalFromIngredientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kcal",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a21b6e1d-afd9-4dbd-b57c-1856bb2b9b50", "AQAAAAIAAYagAAAAEEBtYGWPXXJpnGG5scaSawGKtv2vTCCMV1iDi6Z5HZSLPGw/ILNn/hDF9LZ1aEgzEA==", "6243f8bc-a689-4c2f-ada0-9f11f8ad8f6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6504f68a-7d40-4205-a622-1f0a47f19828", "AQAAAAIAAYagAAAAEJW6p1+AyW5XInygOscdoooAbghaie567HO4SNs0scwJpTNWgMuZdaMnxTfcdlEoWg==", "b5159606-2a66-4a70-8f62-27584537cf10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kcal",
                table: "Ingredients",
                type: "int",
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
    }
}
