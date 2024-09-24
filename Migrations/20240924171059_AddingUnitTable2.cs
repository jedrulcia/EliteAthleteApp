using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingUnitTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.CreateTable(
                name: "ExerciseUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseUnit", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c94b737-ad0e-4279-a40b-81fbddbb2557", "AQAAAAIAAYagAAAAEButASgTjiJYujG9yzLPA6vwkeWIZJUjzxqTTFUYq+SB21hyK2/7z0rzremFMuMkqQ==", "56da670e-598e-4788-ab88-4e537f803a58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f90c6bfb-8727-465d-bdae-c8d690b63cf5", "AQAAAAIAAYagAAAAEIJ+XAQJaJhnk0Z9twMmedGMH3q0wblvdWbxWg1kFvVF/sZdlGrQNRyOqAXbqZWKAQ==", "bee1ca63-5828-414c-ba0c-7d8ae72edd09" });

            migrationBuilder.InsertData(
                table: "ExerciseUnit",
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
                name: "ExerciseUnit");

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
    }
}
