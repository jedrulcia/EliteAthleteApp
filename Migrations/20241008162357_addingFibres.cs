using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class addingFibres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fibres",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cf7107d-e195-43b2-b021-3780abc852ca", "AQAAAAIAAYagAAAAEJsJwjk8nRaOMtgoJq0q4RwC+23DYbUWNmvCNxLY9boGa3wIZDmBra6CDvvcii4Ufg==", "a91480be-f015-4e05-9f7b-118e67b16862" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31a63e02-1072-48ea-b449-33edae4d7cec", "AQAAAAIAAYagAAAAEJhEZQTiBSByNUWY6cTA+ERAqcMkNzrJbaz4J1CGo+5O3OCnpsgksHxRkNJ7eubSFw==", "1299fa76-2cbb-41a3-9a59-cb913d0e7e09" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fibres",
                table: "Ingredients");

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
    }
}
