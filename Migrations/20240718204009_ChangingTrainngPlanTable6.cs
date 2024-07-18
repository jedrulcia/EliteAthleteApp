using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlanApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTrainngPlanTable6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Exercises",
                table: "TrainingPlans",
                newName: "ExerciseIds");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "227d7e3c-a26f-4c89-a638-d21d0c56ad6b", "AQAAAAIAAYagAAAAEIIruG9wdpnqb2BkQBw+FAiR36IbgRY6wNtebgyEziO2yXIemfA3Y/GBu13rM2Iiaw==", "d074699d-8eb4-4d34-98f5-2c4f9bdb489c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "458be6c4-1617-4a2f-9f29-c35a6bbcc379", "AQAAAAIAAYagAAAAEJvx4ogJqtmD4WmUAfUmps4YmVMfQV0m0DSJe7LiD/r/ouNOzmxTsI9dUYjC50mnMg==", "dcadfb5c-fe94-4422-8922-6bb566acf1df" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExerciseIds",
                table: "TrainingPlans",
                newName: "Exercises");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10db8c54-6401-41f5-8a72-48239a782dc8", "AQAAAAIAAYagAAAAEEigbzRrDsr5CFSKlfOjz/dKMafpZdd3q5PWJTbymp0POPa1LZHyhmQjrMlLn/oWuA==", "ae17085c-d92e-41cb-984e-7095cae75907" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f79abc01-b8f2-4b92-bd3b-8866e52cacb5", "AQAAAAIAAYagAAAAENYEFXokH/gYpmoMeZbnUSMOjMgYuwW+gBXzKHKFVYwlrgJsyE+YErv97fkW+tFk5g==", "950f1c63-e6cd-4192-aa0a-77c07a7e3c44" });
        }
    }
}
