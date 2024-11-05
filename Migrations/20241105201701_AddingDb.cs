using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InviteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewCoachId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExerciseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExerciseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExerciseMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExerciseMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExerciseMuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExerciseMuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseCategoryId = table.Column<int>(type: "int", nullable: true),
                    ExerciseMuscleGroupId = table.Column<int>(type: "int", nullable: true),
                    ExerciseMediaId = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetAsPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingPlanIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingOrms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenchPressORM = table.Column<int>(type: "int", nullable: true),
                    OverheadPressORM = table.Column<int>(type: "int", nullable: true),
                    DeadliftORM = table.Column<int>(type: "int", nullable: true),
                    SquatORM = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingOrms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlanExerciseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    TrainingPlanPhaseId = table.Column<int>(type: "int", nullable: true),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanExerciseDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlanPhases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanPhases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingModuleId = table.Column<int>(type: "int", nullable: true),
                    TrainingPlanExerciseDetailIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Raport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBodyAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    FatPercentage = table.Column<int>(type: "int", nullable: true),
                    MusclePercentage = table.Column<int>(type: "int", nullable: true),
                    WaterPercentage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBodyAnalysis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Chest = table.Column<int>(type: "int", nullable: true),
                    Arms = table.Column<int>(type: "int", nullable: true),
                    Waist = table.Column<int>(type: "int", nullable: true),
                    Thighs = table.Column<int>(type: "int", nullable: true),
                    Hips = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBodyMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMedicalTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMedicalTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "543bced5-375b-5291-0a59-1dc59923d1b0", null, "Administrator", "ADMINISTRATOR" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b1", null, "User", "USER" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b2", null, "Coach", "COACH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CoachId", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "InviteCode", "LastName", "LockoutEnabled", "LockoutEnd", "NewCoachId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "654bced5-375b-5291-0a59-1dc59923d1b0", 0, "654bced5-375b-5291-0a59-1dc59923d1b0", "c0a10896-b0b3-44ff-8d02-8de9b8e4702e", null, "admin@localhost.com", true, "System", null, null, "Admin", false, null, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIipUPUiqtxmEcRl/s0t0OVqCMxwUkS8V51B0Dm0EMjyA6NXBvXVdNIXxLv53h1X/Q==", null, false, "b57cd55c-8dcf-4e21-834c-5fed3c85f963", false, "admin@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b1", 0, "654bced5-375b-5291-0a59-1dc59923d1b0", "45c5436a-02b3-4276-b72d-0f3c72829536", null, "user@localhost.com", true, "System", null, null, "User", false, null, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIx5c3n8h/Ggwc9pw14co2tpTabVxi2aPOWZOMr5ctjGCpWcL4m7spkz0O4mJAwxjA==", null, false, "07376558-c943-47ac-be49-1ca4c26519ac", false, "user@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b2", 0, "654bced5-375b-5291-0a59-1dc59923d1b0", "467c212d-5301-4fb2-8791-f42161c43fb0", null, "coach@localhost.com", true, "System", null, null, "Coach", false, null, null, "COACH@LOCALHOST.COM", "COACH@LOCALHOST.COM", "AQAAAAIAAYagAAAAELBaMGTmg1Jn0b50PjeHtWvjDVimYS+KNdI5LfvM/Jbgurve6v6yWPuDyOOSsvgOuQ==", null, false, "6bd5a1a6-595e-4284-88f0-b451e47fe25c", false, "coach@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "TrainingExerciseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conditioning" },
                    { 2, "Strength" },
                    { 3, "Mobility" },
                    { 4, "Stretching" },
                    { 5, "Plyometrics" },
                    { 6, "Dynamics" },
                    { 7, " " }
                });

            migrationBuilder.InsertData(
                table: "TrainingExerciseMuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " " },
                    { 2, "Neck" },
                    { 3, "Shoulders" },
                    { 4, "Chest" },
                    { 5, "Core" },
                    { 6, "Biceps" },
                    { 7, "Triceps" },
                    { 8, "Forearms/Wrist" },
                    { 9, "Back" },
                    { 11, "Glutes" },
                    { 12, "Lower Back" },
                    { 13, "Quadriceps" },
                    { 14, "Hamstrings" },
                    { 15, "Calves" },
                    { 16, "Trapezius" },
                    { 17, "Adductors" },
                    { 18, "Abductors" }
                });

            migrationBuilder.InsertData(
                table: "TrainingPlanPhases",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " " },
                    { 2, "Warm-up" },
                    { 3, "Mobility" },
                    { 4, "Strength Training" },
                    { 5, "Core Training" },
                    { 6, "Cardio/Conditioning" },
                    { 7, "Cool Down" },
                    { 8, "Stretching" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "543bced5-375b-5291-0a59-1dc59923d1b0", "654bced5-375b-5291-0a59-1dc59923d1b0" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b1", "654bced5-375b-5291-0a59-1dc59923d1b1" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b2", "654bced5-375b-5291-0a59-1dc59923d1b2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TrainingExerciseCategories");

            migrationBuilder.DropTable(
                name: "TrainingExerciseMedias");

            migrationBuilder.DropTable(
                name: "TrainingExerciseMuscleGroups");

            migrationBuilder.DropTable(
                name: "TrainingExercises");

            migrationBuilder.DropTable(
                name: "TrainingModules");

            migrationBuilder.DropTable(
                name: "TrainingOrms");

            migrationBuilder.DropTable(
                name: "TrainingPlanExerciseDetails");

            migrationBuilder.DropTable(
                name: "TrainingPlanPhases");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "UserBodyAnalysis");

            migrationBuilder.DropTable(
                name: "UserBodyMeasurements");

            migrationBuilder.DropTable(
                name: "UserMedicalTests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
