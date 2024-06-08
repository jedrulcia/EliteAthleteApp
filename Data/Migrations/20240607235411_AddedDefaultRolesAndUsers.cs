using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "543bced5-375b-5291-0a59-1dc59923d1b0", null, "Administrator", "ADMINISTRATOR" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b1", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBith", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "654bced5-375b-5291-0a59-1dc59923d1b0", 0, "1c138e8c-4e24-4e7a-a016-e75598796d58", null, "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAENTFie/syy1AuHPKnrnsB05pWoxdIEKXRDTVF5Q5rApjk3H36YEhtoBplyKZlTAQLg==", null, false, "1fb72b31-00f4-4bb8-828c-d197055b0912", false, "admin@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b1", 0, "a3172045-0ebf-4baf-ae04-4aaa086a6ab4", null, "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHl09FaP2qsD5fs4t/6rcsAiVOKKNFtUB2DBxtIysCNCkYlt32bkYfe8FsnTedN53w==", null, false, "af7927ac-ae53-4027-8ef7-d6cc9cbdd1be", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "543bced5-375b-5291-0a59-1dc59923d1b0", "654bced5-375b-5291-0a59-1dc59923d1b0" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b1", "654bced5-375b-5291-0a59-1dc59923d1b1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "543bced5-375b-5291-0a59-1dc59923d1b0", "654bced5-375b-5291-0a59-1dc59923d1b0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "543bced5-375b-5291-0a59-1dc59923d1b1", "654bced5-375b-5291-0a59-1dc59923d1b1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543bced5-375b-5291-0a59-1dc59923d1b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543bced5-375b-5291-0a59-1dc59923d1b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1");
        }
    }
}
