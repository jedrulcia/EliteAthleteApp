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

			builder.ApplyConfiguration(new TrainingExerciseCategorySeedConfiguration());
			builder.ApplyConfiguration(new TrainingExerciseMuscleGroupSeedConfiguration());

			builder.ApplyConfiguration(new TrainingPlanPhaseSeedConfiguration());

			base.OnModelCreating(builder);
		}

		public DbSet<UserBodyAnalysis> UserBodyAnalysis { get; set; }
		public DbSet<UserBodyMeasurements> UserBodyMeasurements { get; set; }
		public DbSet<UserMedicalTest> UserMedicalTests { get; set; }

		public DbSet<TrainingExercise> TrainingExercises { get; set; }
		public DbSet<TrainingExerciseCategory> TrainingExerciseCategories { get; set; }
		public DbSet<TrainingExerciseMuscleGroup> TrainingExerciseMuscleGroups { get; set; }
		public DbSet<TrainingExerciseMedia> TrainingExerciseMedias { get; set; }

		public DbSet<TrainingPlan> TrainingPlans { get; set; }
		public DbSet<TrainingPlanPhase> TrainingPlanPhases { get; set; }
		public DbSet<TrainingPlanExerciseDetail> TrainingPlanExerciseDetails { get; set; }

		public DbSet<TrainingModule> TrainingModules { get; set; }
		public DbSet<TrainingOrm> TrainingOrms { get; set; }
	}
}
