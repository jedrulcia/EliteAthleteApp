using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrainingModuleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingModuleId",
                table: "TrainingPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingModules", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca2667f-1fda-4cb1-95a5-1e2aa04dbca5", "AQAAAAIAAYagAAAAEN+eHmZKNWj+4895ixFwFCSBJklQMcwS2Qncpiy+e106kYbDDQpqorKn5VUk6JQdYw==", "375b6745-312a-48a7-ae73-9146ccf284d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "036bb713-b338-445e-a374-85fb109dcc66", "AQAAAAIAAYagAAAAECrPhyIuaU0Cmpc7gSB+tLXEkHj5GlG6JHYHCjvTWc0nFzhJ3czRwlp1tNiu9hmdTg==", "11959d48-5ea6-40e6-b08c-d950f25a3836" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_TrainingModuleId",
                table: "TrainingPlans",
                column: "TrainingModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_TrainingModules_TrainingModuleId",
                table: "TrainingPlans",
                column: "TrainingModuleId",
                principalTable: "TrainingModules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_TrainingModules_TrainingModuleId",
                table: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "TrainingModules");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_TrainingModuleId",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "TrainingModuleId",
                table: "TrainingPlans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "475e3856-365f-46e8-97c3-fc26313000b7", "AQAAAAIAAYagAAAAEOoMzELjR8L6NBrb+m5njJWytlzILV+zNLEuYKxUpvZIZwSlDLTu9WFHUAUTEFVBdw==", "f65716b3-a4f0-44dc-82ff-d255ffed214f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cdd5d8a-a828-486c-a800-cbc74b6357f2", "AQAAAAIAAYagAAAAEHD7z1pEggCBn5YOFs07FGDbX/RF9R+c7ZjUz/d4MSz0lLHU0C25JcPlheh6HL9+Xw==", "becef6fa-a989-4478-b8c8-1f762b068ae8" });
        }
    }
}
