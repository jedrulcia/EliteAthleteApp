using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3149e403-a9e6-4ca4-955d-df7354bff831", "AQAAAAIAAYagAAAAEGG0XxK02R3vnehhWuwWeqHZ854jm2b7222LK7v5749yfEFOSUQqPXWu9qELwWIbpQ==", "98217414-f2c1-424f-90ba-78bd1e7aff8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68aab611-ada4-4dcc-8b80-c9297abf3bd6", "AQAAAAIAAYagAAAAEPgj8msz5PjyEbTaU9zMcHMnBufn5heqyf660m/sbXPWkFTTzMXNCheuMgIOYsscCA==", "47de71f8-57c6-41fb-8e4e-bef72335ce2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0684d409-5328-46a5-b3ad-6b299f985c93", "AQAAAAIAAYagAAAAEJgXwyBTXDcuC8/s7Go2TlT4KRXer/on1+wlRWPTMGuBSk9r8QDwF8NJxZzKGBZ8Eg==", "70253e61-3b74-46f8-85fe-69248cbc0e16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1dfe16b-b128-40c3-9715-0126adde8cf4", "AQAAAAIAAYagAAAAEAKS5KuX0CeP2p4V3CbW4DEsMkPjB6wxdCRf5CClBuOYTyjBqh6qc4HH8kqd7qhbUQ==", "9b949958-623d-411d-a449-d67403bf482a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10e40899-5648-4a06-bb7a-3acc6af48ad2", "AQAAAAIAAYagAAAAED0ZP59ynqxQAlnI5mPXBcBoptqn2jQX9LHk0bhAxh/uJ8adoRnGxVZaubLpVj+Opw==", "9e34ae66-0a5b-4457-8979-510ce70ac4f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f320104d-bbf1-4877-a183-9a0b5b1cf2fb", "AQAAAAIAAYagAAAAECPW7d8qg74wxXWbE0HykX4AoSEEUBmHHNDnC9BXoJ5bUWlFq6cFmeqXvFC08O8Trg==", "8688657a-d455-4770-9abc-84191ab450e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae5b64be-fb1b-4a0c-a7c0-485ddbf71739", "AQAAAAIAAYagAAAAEElsHSwOQXdGbsRgIu0hiVMLL2A5pSPYoSx56f90GN2sK17z4agHOd+l5U301aEj7w==", "d1f6148b-8302-4a77-9738-b0bbb04642c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628e593f-1193-4356-80d3-f8294b2e2e29", "AQAAAAIAAYagAAAAEHku8/Ke3IV6rRsnPW/XTHl+pQqcFxOP6IXoCQTPGrliSufaxE3BueszegorTCKTVg==", "e7bbdfef-3286-4d29-b91a-827ebb9dbfb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4da88086-4eba-443c-9fa8-61daa8c076ab", "AQAAAAIAAYagAAAAEBzNHqrHyYrzmBvpcCn6i078mzhEql54PaPsdzthlCynQhKurlq697ad75RrLJR8ZA==", "a3369f7c-d8b2-40a2-9c51-c2b7c916a4c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68017741-40a1-4411-84c2-c2cda2f45240", "AQAAAAIAAYagAAAAEC4HS+50mcNCfQVwfGsLc6jXT59N2ZOMddQByCOr+6w7ypvByds1lmwMG4seeh+bOg==", "5e1b759a-831a-4428-9429-4b6626286894" });
        }
    }
}
