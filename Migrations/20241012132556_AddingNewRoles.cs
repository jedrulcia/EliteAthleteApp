using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "543bced5-375b-5291-0a59-1dc59923d1b2", null, "Dietician", "DIETICIAN" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b3", null, "Coach", "COACH" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b4", null, "Full", "FULL" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBith", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "654bced5-375b-5291-0a59-1dc59923d1b2", 0, "6842a97a-266c-466f-962a-0b1b01e9cef3", null, "dietician@localhost.com", true, "System", "Dietician", false, null, "DIETICIAN@LOCALHOST.COM", "DIETICIAN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEnoCV39KjATxU4+2MZRylcAUqW4k/5R0rRpQm+j9oDBQkixARZpUFZMLB7Mju3XoA==", null, false, "c239465a-00fb-4bf3-b5ab-bf7a84fb423f", false, "dietician@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b3", 0, "2183478d-dcb5-45ce-bdcc-a9946f7b4847", null, "coach@localhost.com", true, "System", "Coach", false, null, "COACH@LOCALHOST.COM", "COACH@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMnUulYIMh/sON31qlJYM3pikV+iSxYuWBGe0qj+FpE6ViS/PM+JWHVjqLrs2D4H3Q==", null, false, "08d610b8-c668-4019-bc2e-4de6507697d0", false, "coach@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b4", 0, "f14e7625-f108-41c8-b45e-716b632e3f11", null, "full@localhost.com", true, "System", "Full", false, null, "FULL@LOCALHOST.COM", "FULL@LOCALHOST.COM", "AQAAAAIAAYagAAAAECpNupIYynQ7MUpAgM7S9Qe2/n4i1WQhxdftUDRKCkrZzMBZI+21f0I8kabcqFMECA==", null, false, "fc593705-f73d-4cd5-bdc7-d2b6a8ec1a0c", false, "full@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Supplements" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "543bced5-375b-5291-0a59-1dc59923d1b2", "654bced5-375b-5291-0a59-1dc59923d1b2" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b3", "654bced5-375b-5291-0a59-1dc59923d1b3" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b4", "654bced5-375b-5291-0a59-1dc59923d1b4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "543bced5-375b-5291-0a59-1dc59923d1b2", "654bced5-375b-5291-0a59-1dc59923d1b2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "543bced5-375b-5291-0a59-1dc59923d1b3", "654bced5-375b-5291-0a59-1dc59923d1b3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "543bced5-375b-5291-0a59-1dc59923d1b4", "654bced5-375b-5291-0a59-1dc59923d1b4" });

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543bced5-375b-5291-0a59-1dc59923d1b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543bced5-375b-5291-0a59-1dc59923d1b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543bced5-375b-5291-0a59-1dc59923d1b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91b114ac-c13e-446a-9888-aa5ec1920908", "AQAAAAIAAYagAAAAEKtuJjnfE6m8HvWRY3tN6J9h7xTByIowNk3ID9www4ZU1V8EqKoazNmHAtTLiawcQg==", "b385b59e-ee9b-4334-925c-dac3408a26a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a9bd06e-0685-4747-a567-53bc11bd9e89", "AQAAAAIAAYagAAAAEE4XiM8ShkZ9PFvlNNlgFGybqpjtDr/nZz+KGe+aL+Ny73qH2e0qHblKryaRRAWMhg==", "3701870a-e85f-47de-8b4b-9024b8b99aaf" });
        }
    }
}
