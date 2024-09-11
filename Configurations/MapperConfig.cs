using AutoMapper;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<User, UserListVM>().ReverseMap();

			CreateMap<Exercise, ExerciseVM>().ReverseMap();

			CreateMap<TrainingPlan, TrainingPlanVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanAdminVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanManageExercisesVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanDetailsVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanActiveVM>().ReverseMap();

			CreateMap<Ingredient, IngredientVM>().ReverseMap();

			CreateMap<Meal, MealVM>().ReverseMap();
			CreateMap<Meal, MealCreateVM>().ReverseMap();
			CreateMap<Meal, MealManageIngredientsVM>().ReverseMap();
			CreateMap<Meal, MealDetailsVM>().ReverseMap();

			CreateMap<Diet, DietVM>().ReverseMap();
			CreateMap<DietVM, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietMealVM>().ReverseMap();
			CreateMap<Meal, DietMealVM>().ReverseMap();

		}
	}
}
