using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class ChaningNomenclature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "UserMedicalTests",
                newName: "FileUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "UserBodyAnalysis",
                newName: "FileUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da81f3d6-1653-4147-b357-cba5069eac64", "AQAAAAIAAYagAAAAEKhyyrgR+XeDCedCM40O86r2C9YUvdyCowGaRUQuVOZ2NARoEGumm9oOht8soydZCw==", "d673ecbe-a698-40b9-9f7a-a3f7565ec050" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20d151e8-ae6a-4734-a69c-39a2df54f1ea", "AQAAAAIAAYagAAAAEPzst17pL4MPJhalv65ZF4DEdNllLii9lvJrPFoXg9Ewk/iBRqcDp6Olt0cHu8sXSw==", "08e176b6-b645-44a4-9655-2bf962e3422d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2a8e3d6-b1b2-4638-8c47-860310a731e9", "AQAAAAIAAYagAAAAEJxjMmeDbiQV91VPIUpWiNG2qhc9zio8eEPHwZgPFG0mXrAH0cJC2ImLxHgTMHgKeQ==", "86f3070e-0022-49e9-b2fc-c4d98ad1fd80" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "UserMedicalTests",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "UserBodyAnalysis",
                newName: "ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9091b39c-5b16-4cb1-9497-b7cf2bac6585", "AQAAAAIAAYagAAAAEK0pdEeBGQzM8kBaLs/fO622Ps8adeDW4+8SbjQy5oas24hTNCaJJ/88oeKsz7Judw==", "0288e5af-a57a-4ec4-a3c6-946c58a49629" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60c567e6-a7fc-4db4-bb54-dad3dc61cee6", "AQAAAAIAAYagAAAAEDgGH8uHqs97HtZ7YzSXwcBNMEbULnsfnemOA89T++shxWM6fLsOi33/RORF2MoUvA==", "70001bb6-f68b-4142-ab24-1eb82995b32f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "057b9140-5bb8-48e6-a1fd-2c681dc0c0a0", "AQAAAAIAAYagAAAAECkOL3Z/Wg9g9zcoURLCXEhwgwX+b5bH78jc2MHuZDza6QndQx8llxueZuPapb6FVw==", "cb2ea85b-4b5e-40e6-9298-866e44ff9bde" });
        }
    }
}
