using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Fix6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitAmount",
                table: "TrainingPlans",
                newName: "UnitAmounts");

            migrationBuilder.RenameColumn(
                name: "ExerciseUnitIds",
                table: "TrainingPlans",
                newName: "ExerciseUnitTypeIds");

            migrationBuilder.RenameColumn(
                name: "BreakTime",
                table: "TrainingPlans",
                newName: "BreakTimes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63acd25a-0de0-419a-a825-35f0af01961f", "AQAAAAIAAYagAAAAEIiHOkfdQzhtxraCw3ZqU2EIjX8AEQApMRYAuU3EFd+Y6RCwxpFp4IH8gW1+sKUI4w==", "db9941aa-519d-427b-9ff0-9f068b7a23fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8180c1a7-d321-4f9a-874d-ae1324198ee3", "AQAAAAIAAYagAAAAEJILOHtG2UDG1sTPLKecIflh6+8DzcNaGAv77DmopKkgqsNHudSgG71ycf5PrA8RAQ==", "d3b7a936-74e4-4918-a73c-cdc3fc3bb112" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitAmounts",
                table: "TrainingPlans",
                newName: "UnitAmount");

            migrationBuilder.RenameColumn(
                name: "ExerciseUnitTypeIds",
                table: "TrainingPlans",
                newName: "ExerciseUnitIds");

            migrationBuilder.RenameColumn(
                name: "BreakTimes",
                table: "TrainingPlans",
                newName: "BreakTime");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f528a52-591b-4b99-9522-55937bac0767", "AQAAAAIAAYagAAAAEC1CGNeYhA8Y//gvSIXmSOSu0NQO92u5w74inRJ/cYAX+gD+ZKEZU0J6udnYd7TOSA==", "6bdb50a0-1687-4cfc-a19c-693dd6a74b65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50844129-c061-4d81-b7eb-8d10e37d2d55", "AQAAAAIAAYagAAAAEK0RkJCwCe9PHMPoYYH0L2Pwlh8PHirmEcNI1sBZWraTufvbNu1oSG1npGUiYdVs4g==", "f911a50a-afd8-4e61-a120-a0d3da55ac20" });
        }
    }
}
