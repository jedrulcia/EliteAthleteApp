using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TrainingPlanApp.Web.Configurations.Entities;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Data
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

			builder.ApplyConfiguration(new ExerciseUnitTypeSeedConfiguration());
			builder.ApplyConfiguration(new ExerciseCategorySeedConfiguration());

			builder.ApplyConfiguration(new IngredientCategorySeedConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Exercise> Exercises {  get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
		public DbSet<ExerciseUnitType> ExerciseUnitTypes {  get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
		public DbSet<Diet> Diets { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<IngredientCategory> IngredientCategories { get; set; }
		public DbSet<Meal> Meals { get; set; }
		public DbSet<TrainingModule> TrainingModules { get; set; }
    }
}
