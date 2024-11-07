using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingChat2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CharUrl",
                table: "UserChats",
                newName: "ChatUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2240b01d-cd48-4523-bdd0-c48fd8ea98c5", "AQAAAAIAAYagAAAAEAUlm73dJ+i0ZXfr9Kr9U1yQjG9u9fF1jOiW761/yHQKo6UaLvw4kmbjOFr7FnwNbg==", "e26f87ab-6120-44f2-8c6e-79b7d11b36f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83c9e872-e948-43da-b58b-fdcb94fcfffe", "AQAAAAIAAYagAAAAEIaySqcj89RlWh0fBMb5sMDLt3J+VnB6wqLHoc4GpL6Q5d2ssu1fpPi4KbN9NVJ6IQ==", "be84acba-e4b6-4705-8bd1-01cb77d5ddf1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9c52e60-aa04-4e84-a3e2-83fed8c53233", "AQAAAAIAAYagAAAAEM8o+s+j8wOBVnL1M7q+UPrxsZ0+OrxKktMGHGHPCN/KzN5Pg/mytYj5Q6xpXaTCjQ==", "48a30ba4-3ef2-430d-9eb4-aa99a548886d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChatUrl",
                table: "UserChats",
                newName: "CharUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19915cc2-ce3e-476b-ba41-dcd245839c9f", "AQAAAAIAAYagAAAAEAAFjVH7OqxEoFrjTIyaamsOkrSjGYSBxZj0hiiK+wf7WZut821HbOkCiCxN7BHRXw==", "ae691667-cd5b-4e6f-88f9-5820e6a0d12d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72b88e3a-9f8b-40c4-8ae2-0622b2b065e4", "AQAAAAIAAYagAAAAEAVD+2rZkzGGPOsxV+Fc3aaTx9Syyfj9gOapBfhjUw1T4jGXrT2CjsUxMmvrwH8Wcg==", "25a6cc1a-59a3-48f5-94bf-9c26a026a225" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd905b60-df1e-439e-81f5-744f129a511e", "AQAAAAIAAYagAAAAEEEdWzSuLOC8n4jJWyafzQrFd1FoV/g4lpnUGUb4Qaa+cV4sdz8+21viXZaFq4kupg==", "1861eb5e-45eb-42a8-9691-9667cf606444" });
        }
    }
}
