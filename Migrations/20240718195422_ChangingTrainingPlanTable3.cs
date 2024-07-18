using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTrainingPlanTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Index",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2de05eaa-e3f6-4879-9e47-2cba407124c6", "AQAAAAIAAYagAAAAEBw4HwQTLV0b+u16/hhsdXKrrdBwladlIQb/y1ysOBZipyu6xYsv2OP/sre4ztbNxA==", "4f4d35f5-edc8-4374-a167-e477328a12e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9e0d4cb-77ca-4b8f-bead-91fb2e75ca71", "AQAAAAIAAYagAAAAEH7+QVJWDuXYWR475P9KJdZrb/rsru+ummPC02zVcv3eNB0/CmxrUXvfvbfoAx3Atg==", "2b4429a5-e785-46fe-ac42-3af80777065b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "TrainingPlans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5068ef7-aac1-4424-aa88-0c0f3eb7f848", "AQAAAAIAAYagAAAAEAWQtfE+LlfA9z9gNTC1HZR3eu6XwL6ROrPhsqOAqn+8j/vWeNsMPbnTsNMs481gOA==", "79da8be0-6d2f-4dfd-b261-66fc80e52ae1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28c6ef46-bd4c-4b6c-bb29-16e9ecdd9736", "AQAAAAIAAYagAAAAED8cBcZEkd9tB7w0pCX0nhtUkHVmJ/LnPjUVAFgLOJBNaoY47pw3HdXxLUxuUvZPcA==", "10b077ed-52ee-4eb6-86d3-a027b590aee2" });
        }
    }
}
