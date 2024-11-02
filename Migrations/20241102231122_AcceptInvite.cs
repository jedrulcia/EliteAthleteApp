using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AcceptInvite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptedInvite",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "AcceptedInvite", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "5c210b12-51ce-4504-b1ba-b18cfe56f99e", "AQAAAAIAAYagAAAAEHw3fr2oeIHBOnZX1akmN5aTXvt2/lkp9hfYmavHIWA5yyiA8xHrNz4zCw7N0Vzlkg==", "39e4276e-b0a0-45f1-9bab-3e414a8360f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "AcceptedInvite", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "6eb641a1-51a3-4112-a25b-476ef53be397", "AQAAAAIAAYagAAAAENfZZSPtqhBIP+22fVK1dIOZq/7DrjlHfFJKq+JvMtypqtIjT4wZLHRnsu5KV6IOPw==", "bbd415ab-1fd2-4292-b68e-ef94012280ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "AcceptedInvite", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "184cacdd-7986-415a-b757-b38f5ca4ecee", "AQAAAAIAAYagAAAAEKOmThRDbZ5U4/dgrLaH4jd5trCvdGebk4GaLWCUM66YbhZLHyyJwMpt5LF83l2tfQ==", "57d1c713-01b5-45ad-be9e-5eab89324641" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedInvite",
                table: "AspNetUsers");

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
    }
}
