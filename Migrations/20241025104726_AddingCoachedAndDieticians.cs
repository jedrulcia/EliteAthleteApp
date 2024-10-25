using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingCoachedAndDieticians : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b0", "f320104d-bbf1-4877-a183-9a0b5b1cf2fb", "654bced5-375b-5291-0a59-1dc59923d1b0", "AQAAAAIAAYagAAAAECPW7d8qg74wxXWbE0HykX4AoSEEUBmHHNDnC9BXoJ5bUWlFq6cFmeqXvFC08O8Trg==", "8688657a-d455-4770-9abc-84191ab450e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b0", "ae5b64be-fb1b-4a0c-a7c0-485ddbf71739", "654bced5-375b-5291-0a59-1dc59923d1b0", "AQAAAAIAAYagAAAAEElsHSwOQXdGbsRgIu0hiVMLL2A5pSPYoSx56f90GN2sK17z4agHOd+l5U301aEj7w==", "d1f6148b-8302-4a77-9738-b0bbb04642c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b4", "628e593f-1193-4356-80d3-f8294b2e2e29", "654bced5-375b-5291-0a59-1dc59923d1b2", "AQAAAAIAAYagAAAAEHku8/Ke3IV6rRsnPW/XTHl+pQqcFxOP6IXoCQTPGrliSufaxE3BueszegorTCKTVg==", "e7bbdfef-3286-4d29-b91a-827ebb9dbfb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b3", "4da88086-4eba-443c-9fa8-61daa8c076ab", "654bced5-375b-5291-0a59-1dc59923d1b4", "AQAAAAIAAYagAAAAEBzNHqrHyYrzmBvpcCn6i078mzhEql54PaPsdzthlCynQhKurlq697ad75RrLJR8ZA==", "a3369f7c-d8b2-40a2-9c51-c2b7c916a4c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654bced5-375b-5291-0a59-1dc59923d1b4", "68017741-40a1-4411-84c2-c2cda2f45240", "654bced5-375b-5291-0a59-1dc59923d1b4", "AQAAAAIAAYagAAAAEC4HS+50mcNCfQVwfGsLc6jXT59N2ZOMddQByCOr+6w7ypvByds1lmwMG4seeh+bOg==", "5e1b759a-831a-4428-9429-4b6626286894" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "aa2857f4-dd1f-4810-8033-d61bda0329d2", null, "AQAAAAIAAYagAAAAEHIczegLQFX1vkdNw3ZUATNW55EKt2ifP9hcBw/dqkQbpwcoSCGw+ypq2GTo+AT4lg==", "c13f6934-b2ff-4e88-ae72-572a335f7977" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "729d277f-6ed7-4180-b5bd-5e5455e3715b", null, "AQAAAAIAAYagAAAAEGH+eWBTB+8sdL+UR0YSJkfSPfu5grswjZPaaXc7vUvd4R0TcnAIlctNId7/HOz1BA==", "2f835f05-6002-4550-b09e-6e253908d643" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b2",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "7cc7d42e-0b48-4daf-910c-89356b0d0cf3", null, "AQAAAAIAAYagAAAAEFUsEhZo4Km9czHYXebdrHnF4QrfWiaWGiWZvlfRaE6vKd2xSo4D8UxK+URq4Z93WQ==", "8cb76a81-cd51-4a85-96e8-fd80da94d5b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b3",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "1f02d08c-1f63-46cc-8657-8e17e79f9900", null, "AQAAAAIAAYagAAAAEE//KNhoaeyG7CeRPboeiRNKmofuJvS3XXwIcYKdliyI6tr5D8BhU3H0ynAcupo1Mg==", "45d41aa9-e093-441a-8ced-2e24b3637470" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b4",
                columns: new[] { "CoachId", "ConcurrencyStamp", "DieticianId", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "c01e6f13-8c8e-4004-b390-2fcedb38b1d5", null, "AQAAAAIAAYagAAAAEHOScnKGS9NaUkXbkWQhNt1mE1hfjs5MWd0iP5Ku9LomWQY3OfTJS1DULrT8agqqug==", "49f7f30c-0998-4d60-8a72-9af9688914e2" });
        }
    }
}
