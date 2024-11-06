using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0a10896-b0b3-44ff-8d02-8de9b8e4702e", "AQAAAAIAAYagAAAAEIipUPUiqtxmEcRl/s0t0OVqCMxwUkS8V51B0Dm0EMjyA6NXBvXVdNIXxLv53h1X/Q==", "b57cd55c-8dcf-4e21-834c-5fed3c85f963" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45c5436a-02b3-4276-b72d-0f3c72829536", "AQAAAAIAAYagAAAAEIx5c3n8h/Ggwc9pw14co2tpTabVxi2aPOWZOMr5ctjGCpWcL4m7spkz0O4mJAwxjA==", "07376558-c943-47ac-be49-1ca4c26519ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "467c212d-5301-4fb2-8791-f42161c43fb0", "AQAAAAIAAYagAAAAELBaMGTmg1Jn0b50PjeHtWvjDVimYS+KNdI5LfvM/Jbgurve6v6yWPuDyOOSsvgOuQ==", "6bd5a1a6-595e-4284-88f0-b451e47fe25c" });
        }
    }
}
