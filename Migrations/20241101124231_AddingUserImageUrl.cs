using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34b278fd-26de-4b3f-9bb7-0eea254d41c3", null, "AQAAAAIAAYagAAAAEGNCLQZBrurXwaH/ej1BAbPyLvd9yPQSDUOLp/0HTkwj3g4fs4rWBTWB1BBLAxap7Q==", "ee502a7d-6fb3-40ab-8e47-93e3541bb501" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da0c0a62-e5f2-400a-add2-11a11c187ce7", null, "AQAAAAIAAYagAAAAEL9IRt6nXDwyVIMsD1TRAP3xIjbr7YTUmd7L9h10NGmyO5HxNQ+uOh4egjCTmphscg==", "1fee53bf-8759-40d8-9ef4-0aac3b3a7452" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e89c7ae0-58e4-46fc-83dc-1fc8ea531bf9", null, "AQAAAAIAAYagAAAAEIWhSYLOs7Tkpz+t8oOHI4jeTgaYigb4ecXtBIyYt4hZ1pSpGeuOq7pgYxvyTwhIGQ==", "9002e2a7-2e71-42ef-83fa-41210b62fed6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e3708a6-2fba-4a86-93a5-79818d213c9f", "AQAAAAIAAYagAAAAEFMowPcl3PF5OV5ycIF1PddPVuR86lH0GQUJomr20iGipw5na6kWOCqmLWbbeHm1WQ==", "9f69970a-88a1-42a9-84e3-9e765a51200e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f719cd2-b3da-457f-8b2a-9d311a8b8f4c", "AQAAAAIAAYagAAAAEH1WzmyUjC6VAKBgTnk8BASrpVYIFHEQq8bWjFVAfLhs50ooxlSPRpjRbfkyHhVE+w==", "ab6b096a-d633-4d02-b870-23d81f4b6860" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2ae2345-d5e0-41d6-9aa5-97544bcc1b29", "AQAAAAIAAYagAAAAECW8qWLoBFnua6Zdc1fRa2uq0ff06oPbHHSnKipPTb1DhFmXtxpblt8Td7OsBfwUug==", "8e146d7c-6c9b-41ce-b37b-1e8fcd0d944e" });
        }
    }
}
