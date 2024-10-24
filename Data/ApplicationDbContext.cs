using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using EliteAthleteApp.Configurations.Entities;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models;

namespace EliteAthleteApp.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new RoleSeedConfiguration());
			builder.ApplyConfiguration(new UserSeedConfiguration());
			builder.ApplyConfiguration(new UserRoleSeedConfiguration());

			builder.ApplyConfiguration(new ExerciseCategorySeedConfiguration());
			builder.ApplyConfiguration(new ExerciseMuscleGroupSeedConfiguration());

			builder.ApplyConfiguration(new TrainingPlanPhaseSeedConfiguration());

			builder.ApplyConfiguration(new IngredientCategorySeedConfiguration());
			builder.ApplyConfiguration(new MealCategorySeedConfiguration());

			base.OnModelCreating(builder);
		}

		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
		public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }

		public DbSet<TrainingPlan> TrainingPlans { get; set; }
		public DbSet<TrainingPlanPhase> TrainingPlanPhases { get; set; }
		public DbSet<TrainingPlanExerciseDetail> TrainingPlanExerciseDetails { get; set; }

		public DbSet<TrainingModule> TrainingModules { get; set; }
		public DbSet<TrainingModuleORM> TrainingModuleORMs { get; set; }

		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<IngredientCategory> IngredientCategories { get; set; }

		public DbSet<MealCategory> MealCategories { get; set; }

		public DbSet<Diet> Diets { get; set; }
		public DbSet<Meal> Meals { get; set; }
	}
}
