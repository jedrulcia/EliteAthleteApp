using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingIngredientTypesToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Proteins",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Fats",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Carbohydrates",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20458d0e-7b6c-4acd-96d2-7932172aea0e", "AQAAAAIAAYagAAAAEBwiwAE5nCIHpJ2NVwNtFtHqS2srzKa836A9OCr/2txVxKo/eE7PyKGmkA/9CWVKww==", "6bcace68-ac00-4489-9b92-6937b276bff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15cac3b2-022e-4849-bfda-a5554a16e47c", "AQAAAAIAAYagAAAAEMlzSjrU9CwISjBV4MUTeXbATk/WOckjzdxMPbh2IobKNFS+HHK0zBCGBiwPFSLIvQ==", "ca7b63fa-6f48-4b12-803d-e08696058b88" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Proteins",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fats",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carbohydrates",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a21b6e1d-afd9-4dbd-b57c-1856bb2b9b50", "AQAAAAIAAYagAAAAEEBtYGWPXXJpnGG5scaSawGKtv2vTCCMV1iDi6Z5HZSLPGw/ILNn/hDF9LZ1aEgzEA==", "6243f8bc-a689-4c2f-ada0-9f11f8ad8f6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6504f68a-7d40-4205-a622-1f0a47f19828", "AQAAAAIAAYagAAAAEJW6p1+AyW5XInygOscdoooAbghaie567HO4SNs0scwJpTNWgMuZdaMnxTfcdlEoWg==", "b5159606-2a66-4a70-8f62-27584537cf10" });
        }
    }
}
