using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedTrainingPlanTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TrainingPlans",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c83bfad8-1276-417b-9734-fb1a8f6939ed", "AQAAAAIAAYagAAAAEGOGvIvdRWdZQ3ixL+VzHeF62Va2gt5A1BapK0t3TgX+rF1TW1WeT0aQLit26n6FOw==", "e231d27e-5727-48a2-b29f-31dab105492c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f09f966-b3b3-4097-80af-deb23244afe8", "AQAAAAIAAYagAAAAENR68lBg5BUAP8LvbA+fc3u0SZWWauWj8orxaK9qrhdUVwckBNjmEF1aTwVz1OUinw==", "df2dc43d-28b8-45b3-a81b-c1876411d3ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TrainingPlans");

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
    }
}
