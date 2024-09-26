using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Fix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseUnitType",
                table: "ExerciseUnitType");

            migrationBuilder.RenameTable(
                name: "ExerciseUnitType",
                newName: "ExerciseUnitTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseUnitTypes",
                table: "ExerciseUnitTypes",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseUnitTypes",
                table: "ExerciseUnitTypes");

            migrationBuilder.RenameTable(
                name: "ExerciseUnitTypes",
                newName: "ExerciseUnitType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseUnitType",
                table: "ExerciseUnitType",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17668386-d100-40e1-9558-757b63e8f71f", "AQAAAAIAAYagAAAAED0cFP+E4wmHnpkn+Lr/Qb6pjAK1krd7zCFB6E7PhjQxqPSOoIhsN4y5yICMLUh+VA==", "fb2599e6-0b48-46b3-98bd-c79fe93875bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fedfaa5c-f181-4c60-9367-b208a97b1d35", "AQAAAAIAAYagAAAAEE1MwKn/KBDV6WuUTqTdGcUjdzVCmestTg8ZTBAgtqGSDTTiTBB/mEjbXq8o3FqAHw==", "4feb4eb3-bb6d-455c-bae6-0d7f6519827b" });
        }
    }
}
