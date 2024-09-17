using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
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
                values: new object[] { "c93a33a6-bc73-4de3-8578-b425346d7b98", "AQAAAAIAAYagAAAAEBQHwnHKK59EROn5S9UJ3aDlgakRBs2jrDp9GdZkEkxjwlOjOa8MM0bVAb+P9tkeAw==", "82d13971-cc88-4118-af34-6e94edb6db07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94651e1c-b5a5-4394-b034-6b8344cade6e", "AQAAAAIAAYagAAAAELEtWpuIGQ6vCw+iFiJIyLH2hQHjSDTCzmzQfOLYS37WPwoUjx+GbOE7vIT5IDKWzg==", "d7b58613-80ae-48b6-ad7d-3ecf3f17367d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a7ddaee-0f3f-4b64-9305-3edfb05e1b84", "AQAAAAIAAYagAAAAEACoG3/NrRRHV14/TlQqWSZhFn/inh8FbHIWCo94qLmdz9pnXC3juZxK6ujY/7+O4A==", "8a10bea8-df78-465e-90f9-b3be49e66c7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01026c49-89e6-495a-955d-15605588ddb2", "AQAAAAIAAYagAAAAEGZl9BcQLjywPbzy0qmPUzElhiSJkcn+Yj8ZCVbPLVmGzC1jY9yEYyck1/5EBefKYQ==", "a3314e01-ef50-44db-ac75-b189e54028fa" });
        }
    }
}
