using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AcceptInvite1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedInvite",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "NewCoachId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "NewCoachId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32bb2c8f-021b-43b5-ba92-cc2168d7302d", null, "AQAAAAIAAYagAAAAECUd7eAc/eqvDPHFLWbA7UoVy6li2tsZuMNh6sa1n9yBksJVC+CwAUHr6H3OJwBBmA==", "bfd4ed39-b360-4e78-a003-367d5b201a54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "NewCoachId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e37814da-6715-44ec-947e-4e9732792bab", null, "AQAAAAIAAYagAAAAEBobYYEJp1srUDAFrEp+weRz9cFGm/Rb6BrtAEdUe1H3oAYKRv7sOf/h6fnnPqAUYg==", "97e55180-aa10-477c-ab74-078ee5c1d308" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "NewCoachId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7679bab0-2189-4d1c-a86c-30bed052d32a", null, "AQAAAAIAAYagAAAAEPeyhjtJGk8ihOLqtihsnS+UmOHWpYFgNQxJanF2tlDP3Ht+ksg2wLjH0ej4YUAaHg==", "f2e9d716-23b6-468e-af7d-39e26f36b51a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewCoachId",
                table: "AspNetUsers");

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
    }
}
