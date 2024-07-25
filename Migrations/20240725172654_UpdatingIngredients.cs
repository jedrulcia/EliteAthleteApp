using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63cc8336-550a-4811-ae76-c2abe05c0a6e", "AQAAAAIAAYagAAAAELBUHap98Kgxkzn9WWGNw18GKn9U44sxeia/+RxxCHLh630FmsDZ3+pSpmLDtPlvow==", "319fdbcd-5c02-41a3-82ae-2636344be89a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c40bb2-a4d9-4354-8ebe-8719f19f8f59", "AQAAAAIAAYagAAAAENiAIgeH3cUx0kEV0zoTDj46iZQNWWbthOiZPpyimVo18Uz/kxFCkOiw42t0kpNmmg==", "76f5dcdd-5a95-432c-a8f8-c8e72d54006b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a64579fd-0067-4c67-bcbb-5235c19894fe", "AQAAAAIAAYagAAAAELtSvzj6jWTQ1gv+0rLmCMVCAbjisr/pqaWgMRERXdtDvWi2aAINeEgfvziOQYfvmA==", "1a6f636e-174b-4e70-9c73-3260a297304d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6d659d6-1cce-45dc-b265-fb4f94d42539", "AQAAAAIAAYagAAAAEFV9dY0E5yszN8q93hmyhcA1H7HVwNrLkmuAzks0ApkHGtwCz7BUVBJJ58IJZvReog==", "7810d45e-6e04-4bb8-84dc-2011760ab9a8" });
        }
    }
}
