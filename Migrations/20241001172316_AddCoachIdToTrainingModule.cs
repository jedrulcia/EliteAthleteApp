using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCoachIdToTrainingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoachId",
                table: "TrainingModules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f85d0f0-6c4e-46b1-9691-3c3cd4cb82ab", "AQAAAAIAAYagAAAAEMMmA2YjWkXNp8YYFs7R3LJF9XJpB4lTe/0HxfFr/bQgqaOgpyX11yzc8yE0kKMIvg==", "87eb1358-90d7-4ea3-9560-595a59f1cf1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8a42cc4-fb3d-4295-b175-4374b5e7b607", "AQAAAAIAAYagAAAAELnf9+Yj5Rn2E8ESDjXijJe1j9DkZjTCaHDgB/bg7ARQ2facP1s/dLxXlJV6yNoMWw==", "84e89ce2-fa77-4613-b205-2503b645ab07" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "TrainingModules");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71843537-0f29-4875-b36e-ae7f2373b13a", "AQAAAAIAAYagAAAAEEi7OKNcJv1elOc3+ZqEAgriWW6lZzc24D4sGm0Xg3/CA0Va5AI/p36uXiqtai3YFw==", "1ade28ca-c08e-4cce-a580-e9b964373105" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ecda7ea-fd38-441b-b922-f00b288a86f8", "AQAAAAIAAYagAAAAEG/KOntuIz0X17cAWdmxVDGRj/PHvevGvAtzYEATnhlLOlSl2NAzsqvESuuNK6mHoA==", "d7285dcb-6322-43a4-8c0d-72c5b7a598ff" });
        }
    }
}
