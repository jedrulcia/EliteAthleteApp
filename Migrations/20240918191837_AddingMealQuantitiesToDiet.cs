using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingMealQuantitiesToDiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealQuantities",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "969a6d9c-27e5-4714-9abc-82661a4ca7d3", "AQAAAAIAAYagAAAAEFBenb2uqZKaqvEQ/7CJFZQWf1LJYedGgXjMO7zK4MGrEwMqW2wT1LSZdzlvns/aDg==", "ae3f8d8d-1146-448f-a28f-c8080cffcbb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ffbd160-2874-4aa5-9f22-fafb4ebb01a2", "AQAAAAIAAYagAAAAEOo0t9P+i43D/82uRdty9FiBrX4wqzs9Y51Ar49wVyA8jcWmADDmqFETroEuPuFQ7g==", "6ee078e8-4d7a-478b-a81a-7e0f2fbc5971" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealQuantities",
                table: "Diets");

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
    }
}
