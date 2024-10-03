using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTypeOfWeights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b292597-f14a-483a-9c94-f42a8fd74863", "AQAAAAIAAYagAAAAEKVgvNSIHPljlqA+cRCRym62pgw3P/5F7wcObphyrdxLrX0dovXKLV7djUc1SzxTIg==", "11faec06-42a2-432d-8361-2b377e177781" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54631f73-919e-4b47-945e-c0ca158c48b9", "AQAAAAIAAYagAAAAEAGs5Q6sCCtXcrsPVAxq1Xg0bx1FdtTK7VOgzps8ZRNlXwD2yRZ276cJWQuJchYXkg==", "f15a2ea7-13eb-4a83-9d03-895623e4e619" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15a639da-5ce6-45a7-9318-8cb7a98b8acd", "AQAAAAIAAYagAAAAEAnpNjMOSFwi1JfqeDTozrluWbbqh06mRyXHBLkmdB3nq1FKjxOX2OWf2VLS14JhRw==", "16654db2-eb2e-46ec-b063-b22ef2659efb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43cf9a89-d92a-4585-ad29-7788d6d9f82f", "AQAAAAIAAYagAAAAEOF3CcPp5JsiLfaQacrwtby82qwdtWSC57LXhseFrTZhMROYTTSl9/1QMUgHiCCWXQ==", "2937c224-2b0e-44d8-98cb-f2ed1523410b" });

        }
    }
}
