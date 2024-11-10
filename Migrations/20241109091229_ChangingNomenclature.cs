using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangingNomenclature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SquatORM",
                table: "TrainingOrms",
                newName: "SquatOrm");

            migrationBuilder.RenameColumn(
                name: "OverheadPressORM",
                table: "TrainingOrms",
                newName: "OverheadPressOrm");

            migrationBuilder.RenameColumn(
                name: "DeadliftORM",
                table: "TrainingOrms",
                newName: "DeadliftOrm");

            migrationBuilder.RenameColumn(
                name: "BenchPressORM",
                table: "TrainingOrms",
                newName: "BenchPressOrm");

            migrationBuilder.AlterColumn<string>(
                name: "Sets",
                table: "TrainingPlanExerciseDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f0d66ad-e005-4107-bdbf-5484871f4aff", "1b0", "AQAAAAIAAYagAAAAEJc9EmPGLTOaiWHCJpPa3Zd5XI/Eur4mdhrzsOt+oL9XL3TKEbkQk7uZiH8m72N0MQ==", "5785b013-ee76-4e6d-ab5a-d24230199e92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca2bba27-dfe5-478f-b9ee-a6a5b788f81b", "1b1", "AQAAAAIAAYagAAAAEGkmV+q2Ee3xEurTY6Dv9JFw2Oe+eU44R8PuuyTZDF9bsNdXw+uwcE7TGX3IPoLhVw==", "b952830d-6a53-4944-bd40-0c0f671ff320" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp", "UserSubscriptionId" },
                values: new object[] { "4839d2f9-0ffb-4292-ab8d-4984e00c865f", "1b2", "AQAAAAIAAYagAAAAEFzQvOcPj7SjS2SGHcAV/f+JzTfXAbhWoS+Qyp54fdmsAaFdvvVo9qkRu2aYCeU4xg==", "dce8bd77-c23b-4377-8f92-b3fa2f530462", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SquatOrm",
                table: "TrainingOrms",
                newName: "SquatORM");

            migrationBuilder.RenameColumn(
                name: "OverheadPressOrm",
                table: "TrainingOrms",
                newName: "OverheadPressORM");

            migrationBuilder.RenameColumn(
                name: "DeadliftOrm",
                table: "TrainingOrms",
                newName: "DeadliftORM");

            migrationBuilder.RenameColumn(
                name: "BenchPressOrm",
                table: "TrainingOrms",
                newName: "BenchPressORM");

            migrationBuilder.AlterColumn<int>(
                name: "Sets",
                table: "TrainingPlanExerciseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4310709a-1fcd-4633-a71e-c3901eea6bd8", null, "AQAAAAIAAYagAAAAEOFgKjpw/5bL6HFj/GS7GXDN/oi5t13x/EWHNMCaiZ8xsxKGKIcdxJMTBWAczxIjgA==", "452af9e9-ceeb-4b88-a33f-ee38438c768e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8c51f70-3bc1-4aca-9ad9-746302d793e6", null, "AQAAAAIAAYagAAAAENuotjqqaeQ+dnKXl1dwcTNlxsS12PD1zZdsUHgyGh5m1dF5lK+FxQsJz0u8xFx9nA==", "49554d23-9a37-444d-afce-ba53b69a392d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "InviteCode", "PasswordHash", "SecurityStamp", "UserSubscriptionId" },
                values: new object[] { "35fb2b92-f7b3-42f0-b4f5-c6e3af640ec0", null, "AQAAAAIAAYagAAAAEFdsCJiwkIC9sGTMQf7vA66ObxF733KWBODMHEroLxNYKU1YR3LtD1SLWJIzHE0UvQ==", "a7233be8-cfc5-4062-8e9f-06c1a4cf0a53", 3 });
        }
    }
}
