using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangedExercisesModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoachId",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd56e973-d5ae-43ef-942f-6082be3ab374", "AQAAAAIAAYagAAAAEBOwjgh2Pm0YXlS1f2BziF5Mg1sOsiS2ZXiD7DhjlCxKJvhvis4YWc0Pygfp2zEC9A==", "b43ba69a-08f3-482b-96af-de00804628ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "553b91c1-07c4-4ac5-892e-e2f2aaa5dbc5", "AQAAAAIAAYagAAAAEJqTYak1/h/dpqJ7Lju1Plceg6Vnt5s71dVMeU/2Ct3Jf5u6zaBTxnXdhfiT8bYw7A==", "5e78632e-a450-4111-a46e-3bc08134f06f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Exercises");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c44f30ad-4abf-4ee6-bd8b-d0f17b7423bf", "AQAAAAIAAYagAAAAEIBRR3ubcADtdC9ItWF/Q2ztRUc9zEHglD+aaSuK5K7S0cmlCkMTLqcgxpKSEgbqCw==", "234634ae-73ab-4cd4-8a8b-23df5dbc1f89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac9fba12-d418-4c51-9204-47679e113f37", "AQAAAAIAAYagAAAAEKf7LGcCTJibpItDrVvL0Fc1K0FdmiFjWcWf/Pbn65wkd1PWkpbzYkf7tFo14ltk7g==", "034287df-cbff-42ba-aa8d-38b259c62f35" });
        }
    }
}
