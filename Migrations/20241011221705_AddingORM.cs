using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingORM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64709ad6-2338-4114-b14b-dfb005c8eee3", "AQAAAAIAAYagAAAAEDV/i3d6RGwEZ2ijwel8/avfGzLwLriC54De88BY8OLIzEY5W5prM1uUn6q+kLnXaw==", "d5487be2-0b40-4ea1-ba55-6e49d372ddbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2e82718-c9b4-4638-9765-b94ef44d2c3c", "AQAAAAIAAYagAAAAEPOEcGMaoK1NOAf8xW8IwxE91XcQXip87O8Nd06dDJSIEPoXphkX0bQCX8ZYYkluZQ==", "fa7d3bb0-89c5-4c65-afbb-1894d51065e8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fec0c30-6460-46c8-adcd-c62ed3e875f5", "AQAAAAIAAYagAAAAEOTGiOM5gJOBx8wHbB7rlh7plxNgXg/ujxxriiuHF5pLm7Q9EZG+Fmvd3JXp77nkpw==", "577d70c6-7bdd-41d8-ab98-ee55f076e4a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "728de00b-8660-4f60-912c-acdfa447764a", "AQAAAAIAAYagAAAAECNR5BogccEMF3pYmkMdBaD2tR7HKNrgWnu/x6SINIGjaHEVW6xoG9+WdixrNptDYA==", "a6016ace-c9ea-458c-aa22-5e4b0166069a" });
        }
    }
}
