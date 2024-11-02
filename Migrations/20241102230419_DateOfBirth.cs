using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class DateOfBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBith",
                table: "AspNetUsers",
                newName: "DateOfBirth");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6ae743a-e301-4336-bde5-3ae102f50b57", "AQAAAAIAAYagAAAAEINpRTB+mfPMr75hbVQ/tGXjpfRFrHvaFo5iwkXmsmhA1LfuTz536HEnBPZ3qRcv3w==", "31661984-8fcd-4335-b55a-44097b8d7d8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "792263e4-8305-4667-b066-843255c4f942", "AQAAAAIAAYagAAAAEMql1zVNAndJValghR5dflKheu2k8kDwh4+KrMDKinwqLvU3Ewix9vbUhAl4BvYYMQ==", "c056d196-bf58-43a3-a6a1-0760790507e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "865afac3-79bc-4a56-ab75-158756b3c892", "AQAAAAIAAYagAAAAECDODRm3CnGUmrGdySYYWl1Vts/m0FXFWoi+QGSeR6/FVWgV2xDVZoG75y82ymxrnA==", "5ccec8d5-9696-41f4-9a36-d712d8499a79" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "AspNetUsers",
                newName: "DateOfBith");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41a29ce1-9284-421d-bab3-521adf9dd7d1", "AQAAAAIAAYagAAAAEELF3Tcy/jmdFwLNoZUmegtmhzX7peN2JcbTl7Sl8zGWbea114nf89TBIVuVBogGuw==", "23d4ab2e-26f1-4fbf-a614-ffbcfcc6c168" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eec4b1fa-02b5-4073-90e8-a95ce2241e4e", "AQAAAAIAAYagAAAAEHBv22lveXbFcs1RfTIv+iACx35f/SJuPbUO1lYM5m27hv+r9QN6g8/xiZ7lYrK8+w==", "90af8a44-70a9-4d67-9030-9698c3536e5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6096052c-bf4a-470e-afdd-da6bf75cfaa9", "AQAAAAIAAYagAAAAEMLXNKYAsS+/65KuFDlPtgv1sjW0v1Xcxw9sh/9qqgYJQUWNOyYaSEnN18pq6Y5kdQ==", "2b415265-10dc-4dc0-a342-ef5343b112e4" });
        }
    }
}
