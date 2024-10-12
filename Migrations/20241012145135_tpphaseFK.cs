using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class tpphaseFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingPlanPhaseIds",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edbb58c5-2a5d-4c9d-9971-d4198de411a1", "AQAAAAIAAYagAAAAEKwKTGsMBW404w0ik22veJmKgBXqt8/XOuXZLFYJZHLyX+RqJ7v59XLVHq0Qruj28w==", "dbbcde48-2fc4-4019-913e-e3179c139b49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5713d5e6-eb32-4934-a880-82d98b83967c", "AQAAAAIAAYagAAAAEL1hp99sl8W9n83BFp7d6+IilUtQfm5omk05ztjRznIZA1Nshyja+5Z7eKvkb1RDtg==", "cdd940d8-7877-462a-aa67-db52faabc570" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdf496ea-0573-4992-8a8b-2854bdf97777", "AQAAAAIAAYagAAAAEKSkZIn8dOkN+p+RvQ+cBVz6h8ScgCogQ9slCPZgyRJcPSCXHKYs7XL/A+IBniAlHQ==", "5a600a19-8b4d-4d9a-9e8a-00168ad753b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bdc962d-be25-4196-8218-d4828787fe69", "AQAAAAIAAYagAAAAEFqfDKJtP1rNV6a9UJ9RuUUiotHv4aO/vT8fbf37nt+JQT5aAxUELuUUhK+kLtETJA==", "f154a4c1-166e-4604-bfda-81c94dbc6842" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "278692e2-e6f9-48eb-aca8-17a24260b7d4", "AQAAAAIAAYagAAAAEJ4VIeRWt80qklfjDcQJo1dhFwIzSUsldWQjffaJgaGzm4ce3y+qVwSvL4JO47q71A==", "ecea3b43-101f-4cfb-9fc4-fa6f51daeacd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingPlanPhaseIds",
                table: "TrainingPlans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cc279af-54c5-4a43-91e1-8751323d93cb", "AQAAAAIAAYagAAAAEEQHvCWAkld6DpqNq7IczG9XAzymu1tqKDAZr8iBEQfQbtABDXgXnNzUrKnP5aQPZw==", "0685bf27-bb46-4be0-bbc0-b326516b7c98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8d2a765-a474-483d-b4b3-0b64db6d9bdb", "AQAAAAIAAYagAAAAEAZnGDqJDrlFOSmH/5tH53Rfdkg7Lp4dJ2Go+7cmHlz2sOk7El1iqqVMmzPkrv2cFw==", "9f2c8bc8-0d1c-4ed6-b4cc-57b8297bacba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf544336-0afe-49e9-854c-9165c1dc9233", "AQAAAAIAAYagAAAAEA1D5ojJ596ar720pAW2B4/XPBpiYkdzHuVH+24+eDBlw9Gfox5D6Inhr3Ym5e2e5Q==", "489b62b4-ecd9-4ee3-8c6a-bb370f6b20f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39c16a9a-c7e1-4c94-b74d-b22c71d7830f", "AQAAAAIAAYagAAAAEKc4YOQOciWVdrwWmawFIkRzP1bGSznF+4Copy9VNJqAOiHt7PBquXLwmfNkWJFjHA==", "5661b25b-bc21-4be7-b187-b4877c4191e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "468b583b-59bf-4caa-8dc6-7ba561529ef6", "AQAAAAIAAYagAAAAEBa7/683p/ysWUcESX/5bxFrA3JsIw5AdKvq3TkN8m1tfCa1Zt8mw3kq9RrBdqq4Xw==", "bf38387e-6270-4191-b281-b022795a65ba" });
        }
    }
}
