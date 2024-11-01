using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifyingExerciseMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "TrainingExerciseMedias");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "TrainingExercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e3708a6-2fba-4a86-93a5-79818d213c9f", "AQAAAAIAAYagAAAAEFMowPcl3PF5OV5ycIF1PddPVuR86lH0GQUJomr20iGipw5na6kWOCqmLWbbeHm1WQ==", "9f69970a-88a1-42a9-84e3-9e765a51200e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f719cd2-b3da-457f-8b2a-9d311a8b8f4c", "AQAAAAIAAYagAAAAEH1WzmyUjC6VAKBgTnk8BASrpVYIFHEQq8bWjFVAfLhs50ooxlSPRpjRbfkyHhVE+w==", "ab6b096a-d633-4d02-b870-23d81f4b6860" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2ae2345-d5e0-41d6-9aa5-97544bcc1b29", "AQAAAAIAAYagAAAAECW8qWLoBFnua6Zdc1fRa2uq0ff06oPbHHSnKipPTb1DhFmXtxpblt8Td7OsBfwUug==", "8e146d7c-6c9b-41ce-b37b-1e8fcd0d944e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "TrainingExercises");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "TrainingExerciseMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d33d6340-6826-466e-8b98-10d82d24cffd", "AQAAAAIAAYagAAAAED62HoVOfBnPf93MF0cInyxdzjGR8yHLiT/CKib8Iz5wFmM+JSVClFHeyKD19DsQjw==", "15989755-4628-4cbf-b558-db6eaa906120" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d851be0-1b5e-4f01-b053-f7475b753ff1", "AQAAAAIAAYagAAAAEFbxeJCz5BWYSPnD/tYULGKSsUUnhwCWa1Q0ulDl7IWzdKnqmD0csTh05mVMY3V9gg==", "842b6532-6c92-4a91-ac4b-96fc5d2002d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "763bbfcb-a3c8-4c38-93f2-4bc48e0a9398", "AQAAAAIAAYagAAAAEKt+aSIhhZzKa6FMvnfYKX9+2A1Qn3nNKdgC4PCvYVNZQ9+GZ/+qwSuPOF0d52pk+g==", "2e94e4b7-7cec-4c13-87de-c4c25b5cbbd3" });
        }
    }
}
