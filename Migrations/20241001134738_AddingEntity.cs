using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "968d1d39-ffe9-438a-a313-fe868a7fd78c", "AQAAAAIAAYagAAAAEHoSZm//WQdVrKKliTP0/LXgSrjDnm5Y3cQ/qHGWwvdcAo7QzOveKc2HJzqXeAt/nA==", "2652afd8-21e6-4009-9223-fa204436f10a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff8ce08f-eca8-4241-873d-c733f829a657", "AQAAAAIAAYagAAAAEIdsMmrGtwwCl9AWt/yysWRynU4P+suiDvMbjdWm5OLxCPEgMXdAkrOfcCfJ/UliTA==", "8f77cbac-0391-4d1e-8ea5-4f80305981a4" });

            migrationBuilder.InsertData(
                table: "ExerciseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, " " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 7);

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
    }
}
