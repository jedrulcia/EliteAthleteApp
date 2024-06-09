using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedExerciseNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa5bc181-a9b4-43bb-9e59-e5dd10232186", "AQAAAAIAAYagAAAAECb4jqQha9oif8hx/QV8Mv4WWOnHfl1Hmies1ca7KWWNu3pULHTgeAdreuIVzRz8yw==", "46b8b453-0dcf-4175-8115-2452af7a0747" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34cfde48-d26e-49e0-91e4-2010d421c15a", "AQAAAAIAAYagAAAAEPP3wIaOdrS44kh7AMikFWdPO/OTN5yVBd77FyYg0+6EiDrBUPMIpTbj/kR7fA3C4A==", "60a10c0d-a9a4-4100-9aee-0f9f8a74d134" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exercises");

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
    }
}
