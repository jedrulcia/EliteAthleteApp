using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingUrlToMeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e825463b-7152-4366-90a7-7f3873ad7370", "AQAAAAIAAYagAAAAEO1z9qI6hxgNfhYm0Oip8UGZNFeSsj14WS0jGsl+tBBDmPB1ECTjyM6wzwvAyVIKtw==", "395bd794-cf94-4e0b-ac26-0b9ab232d93c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd184e35-55ea-4e56-82ca-2a81c5717dcb", "AQAAAAIAAYagAAAAECrNDQo3JuG5wzWwD2vndXhBKipcBYrR6HqAwzjGTiV661hyvSoRJd9/89hz8pKr1g==", "448adc87-0163-4123-b5f8-ce5ad55946d2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Meals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be70217d-cfde-4a71-90f6-5ca956ac4f52", "AQAAAAIAAYagAAAAEF1NJv3nftYVnf1Qlj1f/1X1xpDAG5orvPsqRojx42l9F6OAIaiVPSEavh3rvLbvwQ==", "aad83215-6330-463d-95fc-74e62a0b75cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9774661-2f07-4c2a-afda-20c94d6e4b46", "AQAAAAIAAYagAAAAEInMuggnweEQ4vQYNo1fVwQxToVsUnMoOij/duPq3f2VSleu0OaxdtGqV5EZ0KVkCQ==", "baaa9148-e6af-4e91-8ebb-e95247d3d703" });
        }
    }
}
