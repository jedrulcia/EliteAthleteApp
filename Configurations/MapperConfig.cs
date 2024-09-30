using AutoMapper;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;
using TrainingPlanApp.Web.Models.Diet;
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.Ingredient;
using TrainingPlanApp.Web.Models.Meal;
using TrainingPlanApp.Web.Models.TrainingModule;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			// USER MODULE MAPPING
			CreateMap<User, UserVM>().ReverseMap();

			// EXERCISE MODULE MAPPING
			CreateMap<Exercise, ExerciseVM>().ReverseMap();
			CreateMap<Exercise, ExerciseIndexVM>().ReverseMap();
			CreateMap<Exercise, ExerciseDetailsVM>().ReverseMap();
			CreateMap<Exercise, ExerciseCreateVM>().ReverseMap();

			CreateMap<ExerciseCategory, ExerciseCategoryVM>().ReverseMap();
			CreateMap<ExerciseUnitType, ExerciseUnitTypeVM>().ReverseMap();

			// TRAINING MODULE MODULE MAPPING
			CreateMap<TrainingModule, TrainingModuleIndexVM>().ReverseMap();
			CreateMap<TrainingModule, TrainingModuleCreateVM>().ReverseMap();

			// TRAINING PLAN MODULE MAPPING
            CreateMap<TrainingPlan, TrainingPlanIndexVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanManageExercisesVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanDetailsVM>().ReverseMap();

			// INGREDIENT MODULE MAPPING
			CreateMap<Ingredient, IngredientIndexVM>().ReverseMap();
			CreateMap<Ingredient, IngredientCreateVM>().ReverseMap();

			CreateMap<IngredientCategory, IngredientCategoryVM>().ReverseMap();

			// MEAL MODULE MAPPING
			CreateMap<Meal, MealIndexVM>().ReverseMap();
			CreateMap<Meal, MealCreateVM>().ReverseMap();
			CreateMap<Meal, MealManageIngredientsVM>().ReverseMap();
			CreateMap<Meal, MealDetailsVM>().ReverseMap();

			// DIET MODULE MAPPING
			CreateMap<Diet, DietIndexVM>().ReverseMap();
			CreateMap<Diet, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietManageMealsVM>().ReverseMap();
		}
	}
}
