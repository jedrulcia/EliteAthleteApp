using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class SmallUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5af11608-cf7f-4684-99ec-753300120d00", null, "AQAAAAIAAYagAAAAEIasK/JJG7fr6SVpeg7UFINUP0/OYHb8Ik0VefpNMG4BHlOjW5gtAwxdqR2hw8/4Ug==", "1ca50dfc-6cc8-4d13-8ff1-d1db66839f2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8505d6b-d057-47e1-8b16-4ca3b350d6dd", null, "AQAAAAIAAYagAAAAELgxQ0A4/LZAofXC0uN4U9xgfVDwqdrRCa8NCvVYomWklJYaAiyLmq0iWttsdYL2VQ==", "61d2a6b0-4ae9-46fd-bd2b-52777fa72d06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aca3b167-20ac-41a2-ac5d-3cd3a75f9b65", null, "AQAAAAIAAYagAAAAEEufwanAYTqehCCrTb0zCi7CsgF3AQu1EKzgTCBWIkXBzPXpd+7q8sS6+3BXkJ5JzA==", "9d9f62aa-ba80-4310-afe9-43672550005f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f0d66ad-e005-4107-bdbf-5484871f4aff", null, "AQAAAAIAAYagAAAAEJc9EmPGLTOaiWHCJpPa3Zd5XI/Eur4mdhrzsOt+oL9XL3TKEbkQk7uZiH8m72N0MQ==", "5785b013-ee76-4e6d-ab5a-d24230199e92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca2bba27-dfe5-478f-b9ee-a6a5b788f81b", null, "AQAAAAIAAYagAAAAEGkmV+q2Ee3xEurTY6Dv9JFw2Oe+eU44R8PuuyTZDF9bsNdXw+uwcE7TGX3IPoLhVw==", "b952830d-6a53-4944-bd40-0c0f671ff320" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4839d2f9-0ffb-4292-ab8d-4984e00c865f", null, "AQAAAAIAAYagAAAAEFzQvOcPj7SjS2SGHcAV/f+JzTfXAbhWoS+Qyp54fdmsAaFdvvVo9qkRu2aYCeU4xg==", "dce8bd77-c23b-4377-8f92-b3fa2f530462" });
        }
    }
}
