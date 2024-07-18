using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTrainingPlanTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10db8c54-6401-41f5-8a72-48239a782dc8", "AQAAAAIAAYagAAAAEEigbzRrDsr5CFSKlfOjz/dKMafpZdd3q5PWJTbymp0POPa1LZHyhmQjrMlLn/oWuA==", "ae17085c-d92e-41cb-984e-7095cae75907" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f79abc01-b8f2-4b92-bd3b-8866e52cacb5", "AQAAAAIAAYagAAAAENYEFXokH/gYpmoMeZbnUSMOjMgYuwW+gBXzKHKFVYwlrgJsyE+YErv97fkW+tFk5g==", "950f1c63-e6cd-4192-aa0a-77c07a7e3c44" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2de05eaa-e3f6-4879-9e47-2cba407124c6", "AQAAAAIAAYagAAAAEBw4HwQTLV0b+u16/hhsdXKrrdBwladlIQb/y1ysOBZipyu6xYsv2OP/sre4ztbNxA==", "4f4d35f5-edc8-4374-a167-e477328a12e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9e0d4cb-77ca-4b8f-bead-91fb2e75ca71", "AQAAAAIAAYagAAAAEH7+QVJWDuXYWR475P9KJdZrb/rsru+ummPC02zVcv3eNB0/CmxrUXvfvbfoAx3Atg==", "2b4429a5-e785-46fe-ac42-3af80777065b" });
        }
    }
}
