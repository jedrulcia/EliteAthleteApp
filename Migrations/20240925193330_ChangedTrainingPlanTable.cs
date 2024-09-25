using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTrainingPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fe6c7d4-08a8-40b9-b753-be4aa7177a64", "AQAAAAIAAYagAAAAEKWtC/NJfsQAn+8OuZQZ7eUSdrrTxnl0yItoSI/nZzUZ+Zt+gX083RMoh9onmOTznA==", "610870e6-5a75-4eb9-92f2-ea87b1969cfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29774240-2b2a-4da0-9eba-2381c84f8892", "AQAAAAIAAYagAAAAEJCWcBRi0MNKCS6x7vqzilp9yRNkqQ5meGqi6xxdGKp/KXN5HIh2sZYWJ78r7HOYGQ==", "51c3f206-8a17-4d38-9d42-83b64e437e31" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "511c3ee8-2eb4-48f6-ac3c-2bb2eeaa575c", "AQAAAAIAAYagAAAAEG9QCp6d0IBJoQo4fzHSunmXBeZaNAkYrdtFbcylcMxgVu1ZQ8lEwGf5NArc/vKvyQ==", "47a78f99-08e5-410f-a407-8f334a1fe583" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f85b67c4-6135-4770-b795-1dbb9dd70ac3", "AQAAAAIAAYagAAAAENceE+wPDhZkS7/HJXQSIxkkYz70T3Qb/CGoPIbgMQpxRpqnOh5Q93RkFALcxbdpjg==", "e6d51822-fdfe-4ade-8cd0-b3f1fbca0af1" });
        }
    }
}
