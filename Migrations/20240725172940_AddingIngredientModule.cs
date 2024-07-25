using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingIngredientModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kcal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proteins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carbohydrates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fats = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c093775f-4788-4af2-b100-65ee45ec93c5", "AQAAAAIAAYagAAAAENfimRvpu3cL2Dp56OyaEH8TKpMzj4+L8tZ1clZLnGczl3W1bzGPT+K8pTtsnipkaQ==", "2930f857-64f2-4051-b6a5-a8dbba3b5bf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac508a1d-1d3d-4045-a9a6-06949e51926a", "AQAAAAIAAYagAAAAELQnKNeMDTZwJNP6jCwRP8Fp9Mt5pZULq+YEt7dlwK0/kfx2GxfzZjUJhuwjW4ldkA==", "d0e96cd5-6eb1-4545-9d4e-80cf5989ff1b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63cc8336-550a-4811-ae76-c2abe05c0a6e", "AQAAAAIAAYagAAAAELBUHap98Kgxkzn9WWGNw18GKn9U44sxeia/+RxxCHLh630FmsDZ3+pSpmLDtPlvow==", "319fdbcd-5c02-41a3-82ae-2636344be89a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c40bb2-a4d9-4354-8ebe-8719f19f8f59", "AQAAAAIAAYagAAAAENiAIgeH3cUx0kEV0zoTDj46iZQNWWbthOiZPpyimVo18Uz/kxFCkOiw42t0kpNmmg==", "76f5dcdd-5a95-432c-a8f8-c8e72d54006b" });
        }
    }
}
