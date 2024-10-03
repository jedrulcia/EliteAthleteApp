using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class RemovingColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repeats",
                table: "TrainingPlans");

            migrationBuilder.RenameColumn(
                name: "UnitTypes",
                table: "TrainingPlans",
                newName: "Units");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c8a2606-3f62-4819-84ee-04e7fff16f07", "AQAAAAIAAYagAAAAEAHkBfa/KMFMMesXGO9kHLfYuiefWEsxgClghVHHRtfOH4Wymrit2LO7kn9y8z6Ksg==", "3ec01113-ad9b-4289-b32a-ae109113695f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9180a3a2-fb74-4c4b-b1da-38b2eecf1f7f", "AQAAAAIAAYagAAAAEHDvYC8Q0ujPIpeXYNTg4t4lRdm7CakHA8XaDd5B1jo1q3MCWyYUZUD9g11Y3wLo6Q==", "fcfe5c1c-d533-4303-ad2b-04a28c8dbfde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Units",
                table: "TrainingPlans",
                newName: "UnitTypes");

            migrationBuilder.AddColumn<string>(
                name: "Repeats",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
