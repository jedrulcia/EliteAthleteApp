using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTrainingPlanTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TrainingPlans_TrainingPlanId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingPlanId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TrainingPlanId",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Exercises",
                table: "TrainingPlans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5068ef7-aac1-4424-aa88-0c0f3eb7f848", "AQAAAAIAAYagAAAAEAWQtfE+LlfA9z9gNTC1HZR3eu6XwL6ROrPhsqOAqn+8j/vWeNsMPbnTsNMs481gOA==", "79da8be0-6d2f-4dfd-b261-66fc80e52ae1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28c6ef46-bd4c-4b6c-bb29-16e9ecdd9736", "AQAAAAIAAYagAAAAED8cBcZEkd9tB7w0pCX0nhtUkHVmJ/LnPjUVAFgLOJBNaoY47pw3HdXxLUxuUvZPcA==", "10b077ed-52ee-4eb6-86d3-a027b590aee2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exercises",
                table: "TrainingPlans");

            migrationBuilder.AddColumn<int>(
                name: "TrainingPlanId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0a1cfec-d9b0-4d0a-8731-a201ed2d234c", "AQAAAAIAAYagAAAAEFxxaTQQNvJrWeAKFStwWxy46cVIp+CfRk7BF8GBfrSsJqVLZx3piECHRRAs3MA7qQ==", "07761812-1084-4270-bef1-35739c64e50d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c58f36c-cbb8-4557-aecf-9ba1b603f728", "AQAAAAIAAYagAAAAEAlwUqdtK19CAv4VMYbpz061Ebu+htfEDKfnICoIlc6MrgqFaFE2e/SSViDDC+SzQg==", "a1333278-b636-48d4-a175-a9183b313120" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingPlanId",
                table: "Exercises",
                column: "TrainingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TrainingPlans_TrainingPlanId",
                table: "Exercises",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id");
        }
    }
}
