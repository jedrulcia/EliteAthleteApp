using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingSetAsPublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DieticianId",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SetAsPublic",
                table: "Ingredients",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5decb441-7a90-494f-b7b5-3bfbc3620ae0", "AQAAAAIAAYagAAAAEA1Yk2dK2WblIsMS4jIdUSCrq/Ypi/lydGkCPnx7TDyqJObY5RWQOhpPUDgAM69pTQ==", "a9520576-7a4a-4ff6-a236-871acad1fff9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc4f4aa5-a84e-401d-a597-570dae8af686", "AQAAAAIAAYagAAAAEEaxs1Tkm87fieVzxixfjpX6d358iArsX5m8yN1U72NkhflU4BHrtffQ7QpXb0oWEw==", "f9a0b9b9-0c4f-4593-b5f4-b9c0ed13f799" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DieticianId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "SetAsPublic",
                table: "Ingredients");

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
    }
}
