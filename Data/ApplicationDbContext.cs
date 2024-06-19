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
            base.OnModelCreating(builder);
			builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());

            builder.Entity<Ingredient>()
                .HasOne(i => i.Meal)
                .WithMany(m => m.Ingredients)
                .HasForeignKey(i => i.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        public DbSet<Exercise> Exercises {  get; set; }
		public DbSet<TrainingPlan> TrainingPlans { get; set; }
		public DbSet<Diet> Diets { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Meal> Meals { get; set; }
	}
}
