using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedTrainingPlanTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TrainingPlans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ac2dab-d8a7-48e2-9d7f-262e6879a48f", "AQAAAAIAAYagAAAAEPXfhix8h43wtBkMI8eQOajEVHicmM3iUHsQykGncWJmeTVEc/oFenSvIEcuzAnfow==", "e081c1d1-4213-4537-8d3c-a1af0cee40bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c07c7b8-90a4-43fc-bd67-5a345f3cea2e", "AQAAAAIAAYagAAAAEC17L9LHGbSvpLpZ2NxaGLM3u/VmqNX6fMmwvYQSfLbgCyG+tv0jAJgcyencmeCpog==", "423f2584-4323-44a9-8976-18230981151f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TrainingPlans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c138e8c-4e24-4e7a-a016-e75598796d58", "AQAAAAIAAYagAAAAENTFie/syy1AuHPKnrnsB05pWoxdIEKXRDTVF5Q5rApjk3H36YEhtoBplyKZlTAQLg==", "1fb72b31-00f4-4bb8-828c-d197055b0912" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3172045-0ebf-4baf-ae04-4aaa086a6ab4", "AQAAAAIAAYagAAAAEHl09FaP2qsD5fs4t/6rcsAiVOKKNFtUB2DBxtIysCNCkYlt32bkYfe8FsnTedN53w==", "af7927ac-ae53-4027-8ef7-d6cc9cbdd1be" });
        }
    }
}
