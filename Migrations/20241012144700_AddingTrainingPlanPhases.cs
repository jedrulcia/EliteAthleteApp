using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingTrainingPlanPhases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingPlanPhases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanPhases", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cc279af-54c5-4a43-91e1-8751323d93cb", "AQAAAAIAAYagAAAAEEQHvCWAkld6DpqNq7IczG9XAzymu1tqKDAZr8iBEQfQbtABDXgXnNzUrKnP5aQPZw==", "0685bf27-bb46-4be0-bbc0-b326516b7c98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8d2a765-a474-483d-b4b3-0b64db6d9bdb", "AQAAAAIAAYagAAAAEAZnGDqJDrlFOSmH/5tH53Rfdkg7Lp4dJ2Go+7cmHlz2sOk7El1iqqVMmzPkrv2cFw==", "9f2c8bc8-0d1c-4ed6-b4cc-57b8297bacba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf544336-0afe-49e9-854c-9165c1dc9233", "AQAAAAIAAYagAAAAEA1D5ojJ596ar720pAW2B4/XPBpiYkdzHuVH+24+eDBlw9Gfox5D6Inhr3Ym5e2e5Q==", "489b62b4-ecd9-4ee3-8c6a-bb370f6b20f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39c16a9a-c7e1-4c94-b74d-b22c71d7830f", "AQAAAAIAAYagAAAAEKc4YOQOciWVdrwWmawFIkRzP1bGSznF+4Copy9VNJqAOiHt7PBquXLwmfNkWJFjHA==", "5661b25b-bc21-4be7-b187-b4877c4191e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "468b583b-59bf-4caa-8dc6-7ba561529ef6", "AQAAAAIAAYagAAAAEBa7/683p/ysWUcESX/5bxFrA3JsIw5AdKvq3TkN8m1tfCa1Zt8mw3kq9RrBdqq4Xw==", "bf38387e-6270-4191-b281-b022795a65ba" });

            migrationBuilder.InsertData(
                table: "TrainingPlanPhases",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " " },
                    { 2, "Warm-up" },
                    { 3, "Mobility" },
                    { 4, "Strength Training" },
                    { 5, "Core Training" },
                    { 6, "Cardio/Conditioning" },
                    { 7, "Cool Down" },
                    { 8, "Stretching" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanPhases");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95c0007f-85ee-4f68-8994-8e1c36e70c91", "AQAAAAIAAYagAAAAEOMCBT5rF38YslrFuUX92+/IeswHMys5b1WeAiEGawnWlx5pSwkMY8p9Stk7N/nizg==", "de19dc2d-2acf-4597-8f62-b54dd3cbf946" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "828657bf-b0b2-4946-ac22-514a454e977b", "AQAAAAIAAYagAAAAEO4pi6ehZz3P8ENLFgjS8MYxjFZuVRGza2LLugQrbOPKmikLI8zbBF5uawWwJBDgDw==", "fab59f76-2880-42ee-aa51-3eb6f6cc5d45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6842a97a-266c-466f-962a-0b1b01e9cef3", "AQAAAAIAAYagAAAAEEnoCV39KjATxU4+2MZRylcAUqW4k/5R0rRpQm+j9oDBQkixARZpUFZMLB7Mju3XoA==", "c239465a-00fb-4bf3-b5ab-bf7a84fb423f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2183478d-dcb5-45ce-bdcc-a9946f7b4847", "AQAAAAIAAYagAAAAEMnUulYIMh/sON31qlJYM3pikV+iSxYuWBGe0qj+FpE6ViS/PM+JWHVjqLrs2D4H3Q==", "08d610b8-c668-4019-bc2e-4de6507697d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f14e7625-f108-41c8-b45e-716b632e3f11", "AQAAAAIAAYagAAAAECpNupIYynQ7MUpAgM7S9Qe2/n4i1WQhxdftUDRKCkrZzMBZI+21f0I8kabcqFMECA==", "fc593705-f73d-4cd5-bdc7-d2b6a8ec1a0c" });
        }
    }
}
