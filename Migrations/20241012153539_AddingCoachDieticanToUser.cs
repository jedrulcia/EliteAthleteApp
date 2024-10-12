using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingCoachDieticanToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoachId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DieticianId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "490b1e12-9ac6-4021-b15d-2db228167574", null, "AQAAAAIAAYagAAAAEOT+oUrp8Cn0Ntm2xgIQPRX3wrs397ICXdlZtxfH9qxdIpJbZN0ERtkQLLR1f8OrfQ==", "bcf93fd8-bfe7-4cbd-adf2-deee9b25c2de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "9e7b7649-5765-4aec-9713-c6c2c2f4834b", null, "AQAAAAIAAYagAAAAECeiq2/OfdCtxlNG+zCwIEdFSZ29AoQhvw8pfRmWhGaNCN+bAspcxbZl4AI3UkQ7Dg==", "a3aff0db-4a9c-4427-bd66-4726a662c157" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "e5dc36e0-3350-4a46-922d-24789fb214bd", null, "AQAAAAIAAYagAAAAEKHe2EHjg7J9FnU43b4QeidJgNJ0D8Mrj3rhJi/mEHZ7P+Gi7VCWm214g/oqrugbPA==", "00cfe83c-a321-4fb4-b7f8-96355a7c7ffe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "feff277c-8dec-4bbb-a63b-0f81daf93f59", null, "AQAAAAIAAYagAAAAEJlmjX7iJO7kbknnIm6aqDjWJhGQJ+MCB9cVxSFdvlJeVV+w4YQ7BV6LukAmwOdibA==", "451862c3-e095-4dfe-b9b8-77334ff4146d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "102275f0-12e6-4d09-ba16-e7824dea906b", null, "AQAAAAIAAYagAAAAEPTmYJddIrr8w/+2nlPQrN1OgFNVDARAVmFJQb2rTtCaGcJsiT5rU38vgN+K8C3kkA==", "933ee46e-cfde-4b80-bad1-e10b5c2c0fd9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DieticianId",
                table: "AspNetUsers");

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
    }
}
