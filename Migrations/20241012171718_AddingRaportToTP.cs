using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingRaportToTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Raport",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc53b09e-23d5-4f1e-abb1-445d2c528226", "AQAAAAIAAYagAAAAEIIVnFsOlaWH4k6omVTOFYIRn+X0lRwusdVaR0ZR3upoghdpeCYEz9RytlEbStAixQ==", "3fe223ae-39c9-47e1-ba56-95e04df1643f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "859c76a6-7756-4197-bfce-fb1554ad0336", "AQAAAAIAAYagAAAAEKyGoro0mMkk34GGlzY6yMNauT0sRimbhe18JO9/Uba/B48Rxv08CJQXw5FMpVX+TQ==", "3939c3ee-266f-4cb5-8cb6-6846c9809eac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12d241d3-46a8-4778-93eb-cec9b4475364", "AQAAAAIAAYagAAAAEF5W110felwSUrR1idV6eoWknvlFXMut3nf0A/mNWed7t8xM+X6kFagWHDySZak1wg==", "1691d81e-85a0-4fb0-9597-1ac22d8cbec0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b080838-eabb-472f-89ed-a5d1df18ebc9", "AQAAAAIAAYagAAAAEJzt9wp+YfV+oXzhI8ulNjLUss0I/gdxeJzk86bHt6Six8kTbw3piOHr8pQ10NCpvw==", "a2865e05-8b18-480c-846d-96338c008014" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb62d402-a2da-4af8-9096-71e2343e776b", "AQAAAAIAAYagAAAAEEG0ImmyojymQDSTiUM5TIsQqdGat75HQD8OT638UqWTvNCE5Bwr/H24xVAKLr4QDQ==", "c6403a95-e9e2-4f06-9ebd-7472a5ee697c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raport",
                table: "TrainingPlans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "490b1e12-9ac6-4021-b15d-2db228167574", "AQAAAAIAAYagAAAAEOT+oUrp8Cn0Ntm2xgIQPRX3wrs397ICXdlZtxfH9qxdIpJbZN0ERtkQLLR1f8OrfQ==", "bcf93fd8-bfe7-4cbd-adf2-deee9b25c2de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e7b7649-5765-4aec-9713-c6c2c2f4834b", "AQAAAAIAAYagAAAAECeiq2/OfdCtxlNG+zCwIEdFSZ29AoQhvw8pfRmWhGaNCN+bAspcxbZl4AI3UkQ7Dg==", "a3aff0db-4a9c-4427-bd66-4726a662c157" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5dc36e0-3350-4a46-922d-24789fb214bd", "AQAAAAIAAYagAAAAEKHe2EHjg7J9FnU43b4QeidJgNJ0D8Mrj3rhJi/mEHZ7P+Gi7VCWm214g/oqrugbPA==", "00cfe83c-a321-4fb4-b7f8-96355a7c7ffe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feff277c-8dec-4bbb-a63b-0f81daf93f59", "AQAAAAIAAYagAAAAEJlmjX7iJO7kbknnIm6aqDjWJhGQJ+MCB9cVxSFdvlJeVV+w4YQ7BV6LukAmwOdibA==", "451862c3-e095-4dfe-b9b8-77334ff4146d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "102275f0-12e6-4d09-ba16-e7824dea906b", "AQAAAAIAAYagAAAAEPTmYJddIrr8w/+2nlPQrN1OgFNVDARAVmFJQb2rTtCaGcJsiT5rU38vgN+K8C3kkA==", "933ee46e-cfde-4b80-bad1-e10b5c2c0fd9" });
        }
    }
}
