using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedInviteCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InviteCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41a29ce1-9284-421d-bab3-521adf9dd7d1", null, "AQAAAAIAAYagAAAAEELF3Tcy/jmdFwLNoZUmegtmhzX7peN2JcbTl7Sl8zGWbea114nf89TBIVuVBogGuw==", "23d4ab2e-26f1-4fbf-a614-ffbcfcc6c168" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eec4b1fa-02b5-4073-90e8-a95ce2241e4e", null, "AQAAAAIAAYagAAAAEHBv22lveXbFcs1RfTIv+iACx35f/SJuPbUO1lYM5m27hv+r9QN6g8/xiZ7lYrK8+w==", "90af8a44-70a9-4d67-9030-9698c3536e5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6096052c-bf4a-470e-afdd-da6bf75cfaa9", null, "AQAAAAIAAYagAAAAEMLXNKYAsS+/65KuFDlPtgv1sjW0v1Xcxw9sh/9qqgYJQUWNOyYaSEnN18pq6Y5kdQ==", "2b415265-10dc-4dc0-a342-ef5343b112e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InviteCode",
                table: "AspNetUsers");

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
    }
}
