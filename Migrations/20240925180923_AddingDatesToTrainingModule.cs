using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingDatesToTrainingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TrainingModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TrainingModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b52113c7-502f-42ca-97c5-ff056a2fb88e", "AQAAAAIAAYagAAAAEJ995f78cZhyJWBA4aJ4cLFLwIIL/UmYOMyUFskDdLVX8W6OW9cCqMRhXvqmv2lZaw==", "d1b9f9b0-a080-4abe-a49d-9f6c04f067b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ac426c5-6c91-458a-9cf8-0c4691778740", "AQAAAAIAAYagAAAAEPXMlH8aa2h3W6Arq+o06keZAlIiauVrzo3Bh40OaEFxgZj2VsY9qVb0qujEWoMLqA==", "6cb60de0-b3c3-4433-9fcb-85177d6a0493" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TrainingModules");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TrainingModules");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9395f7b-b128-46ef-a618-ab75c0a51b6c", "AQAAAAIAAYagAAAAEGwonWn+mzFTJVxihm8ItC1DlzvhAfvctbiHT+ixQTTZAZNIDjZdMHI241E+3vg3Kw==", "03068e9c-db7d-4e25-a143-60b9c5614792" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0046fc74-84af-4dc1-b83b-f72767d1cf88", "AQAAAAIAAYagAAAAEF4OzfQ/QCo9OzlvedC7RdR95BfTNDFzQTblA4vhvSl57JaWsKRblw35ssfVnNreEg==", "4bcd6e35-daae-46ea-98fb-bc8ec7b1b1f4" });
        }
    }
}
