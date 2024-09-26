using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingFKtoTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsEmpty",
                table: "TrainingPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingModuleId",
                table: "TrainingPlans",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9988c144-195e-44fe-a661-6791597ab2db", "AQAAAAIAAYagAAAAEOpZT2wc1HLMrgV8IyywmaPlqeQOZLqu4aB9HtJ9X7SwEMbgVZqL4leRW6jutEh1nw==", "7b890cca-1ca7-4070-afde-c64db4fb3205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b716551b-2896-42c4-b0c2-06321ea6d8c5", "AQAAAAIAAYagAAAAEI+AmorkNDiA6vp0Feu2qmlSZFgRIG7yw1oq+ffL7xh2lqiDcb1Cub1nMJ4E0zzB4Q==", "b75af258-d5c1-4e5b-9162-fade5bc21c3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingModuleId",
                table: "TrainingPlans");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmpty",
                table: "TrainingPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5555cf0-b080-4bbc-992e-10d4ba917db5", "AQAAAAIAAYagAAAAEDCUrgrs6E7xNHIeqwaXpm+5uZsDltUk7REYBucRtwf/KAg/vzl/PbhiUZgjufFfzA==", "e82ea751-d88f-4759-b5d7-5cb0ca21b0a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1da9ec75-3c0a-49aa-a5c7-70180c68b655", "AQAAAAIAAYagAAAAEPDmKSKDEMVb9kJN1N8dsXeE5zUuqEN6Xf/KSbChA0dPH4cQaoCH39IGfe6TzRAnRA==", "cf71ae87-5aac-470c-b602-147ad357fcaf" });
        }
    }
}
