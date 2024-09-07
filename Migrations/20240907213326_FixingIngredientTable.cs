using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixingIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Proteins",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kcal",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fats",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carbohydrates",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc1689a0-917f-4a69-8e63-d08220139f0d", "AQAAAAIAAYagAAAAEDDNllGclf+H3zgG58lZeAm49lriqBT2TPQitnUZwiMc6pLFaAWnfgJ5YR/4p6gMyQ==", "f5c65c52-4cd9-4337-a3dd-e48e132ac0aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f721e073-29ae-4ae8-b9f5-0dac535f8902", "AQAAAAIAAYagAAAAENMMDjU9MkwsBMQsUUTvUrP3e5YUBNq1e5JTlYaGTR4ASbTF+HpsBgFVMJZSLLmDRg==", "d174de52-ca7b-48a2-993e-d62bc2095945" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Proteins",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kcal",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fats",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carbohydrates",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c093775f-4788-4af2-b100-65ee45ec93c5", "AQAAAAIAAYagAAAAENfimRvpu3cL2Dp56OyaEH8TKpMzj4+L8tZ1clZLnGczl3W1bzGPT+K8pTtsnipkaQ==", "2930f857-64f2-4051-b6a5-a8dbba3b5bf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac508a1d-1d3d-4045-a9a6-06949e51926a", "AQAAAAIAAYagAAAAELQnKNeMDTZwJNP6jCwRP8Fp9Mt5pZULq+YEt7dlwK0/kfx2GxfzZjUJhuwjW4ldkA==", "d0e96cd5-6eb1-4545-9d4e-80cf5989ff1b" });
        }
    }
}
