using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class RenamingUnitTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseUnit");

            migrationBuilder.CreateTable(
                name: "ExerciseUnitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseUnitType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17668386-d100-40e1-9558-757b63e8f71f", "AQAAAAIAAYagAAAAED0cFP+E4wmHnpkn+Lr/Qb6pjAK1krd7zCFB6E7PhjQxqPSOoIhsN4y5yICMLUh+VA==", "fb2599e6-0b48-46b3-98bd-c79fe93875bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fedfaa5c-f181-4c60-9367-b208a97b1d35", "AQAAAAIAAYagAAAAEE1MwKn/KBDV6WuUTqTdGcUjdzVCmestTg8ZTBAgtqGSDTTiTBB/mEjbXq8o3FqAHw==", "4feb4eb3-bb6d-455c-bae6-0d7f6519827b" });

            migrationBuilder.InsertData(
                table: "ExerciseUnitType",
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
                name: "ExerciseUnitType");

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
                values: new object[] { "9988c144-195e-44fe-a661-6791597ab2db", "AQAAAAIAAYagAAAAEOpZT2wc1HLMrgV8IyywmaPlqeQOZLqu4aB9HtJ9X7SwEMbgVZqL4leRW6jutEh1nw==", "7b890cca-1ca7-4070-afde-c64db4fb3205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b716551b-2896-42c4-b0c2-06321ea6d8c5", "AQAAAAIAAYagAAAAEI+AmorkNDiA6vp0Feu2qmlSZFgRIG7yw1oq+ffL7xh2lqiDcb1Cub1nMJ4E0zzB4Q==", "b75af258-d5c1-4e5b-9162-fade5bc21c3b" });

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
    }
}
