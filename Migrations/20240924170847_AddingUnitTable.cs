using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingUnitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "802f2189-04e6-4ff1-b444-85ef9842f035", "AQAAAAIAAYagAAAAEBMWWxDynWh8VxDgpdAb7Qjq9cab9cwmwZfzZ+lmxGG2nMk/mx9ndWX4Ex7kWgM4YA==", "b60a1942-5881-4a71-9a00-64325dc28fe1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfd19691-5aa4-4f42-a9fd-71fdaa565b04", "AQAAAAIAAYagAAAAENE2ux+HBM86O7lMPNDhgc2u4YaXklZMKsLQteXybVPe/MJD4XBjM5OmlNRyimjG4A==", "9619a39d-d84e-4402-a4fb-e39293567915" });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Reps" },
                    { 2, "Time" },
                    { 3, "Distance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "969a6d9c-27e5-4714-9abc-82661a4ca7d3", "AQAAAAIAAYagAAAAEFBenb2uqZKaqvEQ/7CJFZQWf1LJYedGgXjMO7zK4MGrEwMqW2wT1LSZdzlvns/aDg==", "ae3f8d8d-1146-448f-a28f-c8080cffcbb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ffbd160-2874-4aa5-9f22-fafb4ebb01a2", "AQAAAAIAAYagAAAAEOo0t9P+i43D/82uRdty9FiBrX4wqzs9Y51Ar49wVyA8jcWmADDmqFETroEuPuFQ7g==", "6ee078e8-4d7a-478b-a81a-7e0f2fbc5971" });
        }
    }
}
