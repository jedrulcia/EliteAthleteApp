using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "SetAsPublic",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71843537-0f29-4875-b36e-ae7f2373b13a", "AQAAAAIAAYagAAAAEEi7OKNcJv1elOc3+ZqEAgriWW6lZzc24D4sGm0Xg3/CA0Va5AI/p36uXiqtai3YFw==", "1ade28ca-c08e-4cce-a580-e9b964373105" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ecda7ea-fd38-441b-b922-f00b288a86f8", "AQAAAAIAAYagAAAAEG/KOntuIz0X17cAWdmxVDGRj/PHvevGvAtzYEATnhlLOlSl2NAzsqvESuuNK6mHoA==", "d7285dcb-6322-43a4-8c0d-72c5b7a598ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "SetAsPublic",
                table: "Exercises",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd664394-6359-4c4d-a555-721df6bc3f0b", "AQAAAAIAAYagAAAAEOnnhhPp/TTuFZvt1UarHfB7ybtoOlR/mS8XpdBQ89qanxdBdFVFUTkG5ce2YC6NyA==", "65b99236-337e-4e2d-9c9e-2518004adb26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84fd657c-b469-4f96-8d57-e0e83c6e04aa", "AQAAAAIAAYagAAAAEOHcXCvsgusmLZZSoJV6PKwJTMCvTxPO28IRlGry+gVIAaHQ41TjBqzDO4vxXZYbDg==", "c42e9b01-3d00-4e17-948c-82527b36d238" });
        }
    }
}
