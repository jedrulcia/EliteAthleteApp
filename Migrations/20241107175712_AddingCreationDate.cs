using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserMedicalTests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserChats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CoachId",
                table: "UserChats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserBodyMeasurements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserBodyAnalysis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TrainingOrms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eed8878-2e96-482c-be3b-b1587027a6dc", "Admin", "System", "AQAAAAIAAYagAAAAEFzfCl2txqN3f4xIyZISVseJGkqX7cfmBTqqx/jciEi7Q170glP6AA4faIWW3PSiOQ==", "2096bcac-8e26-40b8-ae32-cf3acd223649" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5485afaa-5df9-4891-8b47-b3df30a5b39b", "User", "System", "AQAAAAIAAYagAAAAEGR6z+oVMsxdVmwZlSw3sRyAryKU+6tAGGIUvsZ1J0QMM9qTFEJkha8QYI/j2EXHdg==", "79400491-ab33-4967-a126-3c6cfd05cbb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07c8dfbe-025e-407a-a761-e34d2d2f6ba3", "Coach", "System", "AQAAAAIAAYagAAAAEMt6Z8quJCT3dAd7VZJpMVKWrP+w5uzI5ywkqUqSS10lZE0syiqdwLu3su5AH07A2A==", "db1dded7-6584-40d1-8889-de9e072a0f69" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserMedicalTests");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserBodyMeasurements");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserBodyAnalysis");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TrainingOrms");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserChats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoachId",
                table: "UserChats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2240b01d-cd48-4523-bdd0-c48fd8ea98c5", "System", "Admin", "AQAAAAIAAYagAAAAEAUlm73dJ+i0ZXfr9Kr9U1yQjG9u9fF1jOiW761/yHQKo6UaLvw4kmbjOFr7FnwNbg==", "e26f87ab-6120-44f2-8c6e-79b7d11b36f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83c9e872-e948-43da-b58b-fdcb94fcfffe", "System", "User", "AQAAAAIAAYagAAAAEIaySqcj89RlWh0fBMb5sMDLt3J+VnB6wqLHoc4GpL6Q5d2ssu1fpPi4KbN9NVJ6IQ==", "be84acba-e4b6-4705-8bd1-01cb77d5ddf1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9c52e60-aa04-4e84-a3e2-83fed8c53233", "System", "Coach", "AQAAAAIAAYagAAAAEM8o+s+j8wOBVnL1M7q+UPrxsZ0+OrxKktMGHGHPCN/KzN5Pg/mytYj5Q6xpXaTCjQ==", "48a30ba4-3ef2-430d-9eb4-aa99a548886d" });
        }
    }
}
