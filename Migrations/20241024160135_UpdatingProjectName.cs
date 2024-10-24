using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EliteAthleteApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingProjectName : Migration
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
                    DateOfBith = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DieticianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MealQuantities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseCategoryId = table.Column<int>(type: "int", nullable: true),
                    ExerciseMuscleGroupId = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetAsPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientCategoryId = table.Column<int>(type: "int", nullable: true),
                    DieticianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proteins = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrates = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fats = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fibres = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SuggestedPortion = table.Column<int>(type: "int", nullable: true),
                    SetAsPublic = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DieticianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngredientQuantities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetAsPublic = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingModuleORMs",
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
                    table.PrimaryKey("PK_TrainingModuleORMs", x => x.Id);
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
                    { "543bced5-375b-5291-0a59-1dc59923d1b2", null, "Dietician", "DIETICIAN" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b3", null, "Coach", "COACH" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b4", null, "Full", "FULL" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CoachId", "ConcurrencyStamp", "DateOfBith", "DieticianId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "654bced5-375b-5291-0a59-1dc59923d1b0", 0, null, "aa2857f4-dd1f-4810-8033-d61bda0329d2", null, null, "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHIczegLQFX1vkdNw3ZUATNW55EKt2ifP9hcBw/dqkQbpwcoSCGw+ypq2GTo+AT4lg==", null, false, "c13f6934-b2ff-4e88-ae72-572a335f7977", false, "admin@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b1", 0, null, "729d277f-6ed7-4180-b5bd-5e5455e3715b", null, null, "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGH+eWBTB+8sdL+UR0YSJkfSPfu5grswjZPaaXc7vUvd4R0TcnAIlctNId7/HOz1BA==", null, false, "2f835f05-6002-4550-b09e-6e253908d643", false, "user@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b2", 0, null, "7cc7d42e-0b48-4daf-910c-89356b0d0cf3", null, null, "dietician@localhost.com", true, "System", "Dietician", false, null, "DIETICIAN@LOCALHOST.COM", "DIETICIAN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFUsEhZo4Km9czHYXebdrHnF4QrfWiaWGiWZvlfRaE6vKd2xSo4D8UxK+URq4Z93WQ==", null, false, "8cb76a81-cd51-4a85-96e8-fd80da94d5b4", false, "dietician@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b3", 0, null, "1f02d08c-1f63-46cc-8657-8e17e79f9900", null, null, "coach@localhost.com", true, "System", "Coach", false, null, "COACH@LOCALHOST.COM", "COACH@LOCALHOST.COM", "AQAAAAIAAYagAAAAEE//KNhoaeyG7CeRPboeiRNKmofuJvS3XXwIcYKdliyI6tr5D8BhU3H0ynAcupo1Mg==", null, false, "45d41aa9-e093-441a-8ced-2e24b3637470", false, "coach@localhost.com" },
                    { "654bced5-375b-5291-0a59-1dc59923d1b4", 0, null, "c01e6f13-8c8e-4004-b390-2fcedb38b1d5", null, null, "full@localhost.com", true, "System", "Full", false, null, "FULL@LOCALHOST.COM", "FULL@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHOScnKGS9NaUkXbkWQhNt1mE1hfjs5MWd0iP5Ku9LomWQY3OfTJS1DULrT8agqqug==", null, false, "49f7f30c-0998-4d60-8a72-9af9688914e2", false, "full@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseCategories",
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
                table: "ExerciseMuscleGroups",
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
                table: "IngredientCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " " },
                    { 2, "Meats" },
                    { 3, "Dairy" },
                    { 4, "Vegetables" },
                    { 5, "Fruits" },
                    { 6, "Grains" },
                    { 7, "Seafood" },
                    { 8, "Fats and Oils" },
                    { 9, "Nuts and Seeds" },
                    { 10, "Herbs and Spices" },
                    { 11, "Legumes" },
                    { 12, "Baked Goods" },
                    { 13, "Pasta and Noodles" },
                    { 14, "Snacks" },
                    { 15, "Sweets" },
                    { 16, "Supplements" }
                });

            migrationBuilder.InsertData(
                table: "MealCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " " },
                    { 2, "Vegetarian" },
                    { 3, "Vegan" },
                    { 4, "Gluten-Free" },
                    { 5, "Low-Calorie" },
                    { 6, "High-Protein" },
                    { 7, "Low-Carb" },
                    { 8, "Paleo" },
                    { 9, "Ketogenic" },
                    { 10, "Dairy-Free" },
                    { 11, "Sugar-Free" },
                    { 12, "Raw" },
                    { 13, "With Superfoods" },
                    { 14, "Diet-Friendly" },
                    { 15, "Functional" },
                    { 16, "Allergen-Free" }
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
                    { "543bced5-375b-5291-0a59-1dc59923d1b2", "654bced5-375b-5291-0a59-1dc59923d1b2" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b3", "654bced5-375b-5291-0a59-1dc59923d1b3" },
                    { "543bced5-375b-5291-0a59-1dc59923d1b4", "654bced5-375b-5291-0a59-1dc59923d1b4" }
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
                name: "Diets");

            migrationBuilder.DropTable(
                name: "ExerciseCategories");

            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroups");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "IngredientCategories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "MealCategories");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "TrainingModuleORMs");

            migrationBuilder.DropTable(
                name: "TrainingModules");

            migrationBuilder.DropTable(
                name: "TrainingPlanExerciseDetails");

            migrationBuilder.DropTable(
                name: "TrainingPlanPhases");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
