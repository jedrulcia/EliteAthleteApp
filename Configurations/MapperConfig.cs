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
			CreateMap<Exercise, TrainingPlanExerciseVM>().ReverseMap();
			CreateMap<Exercise, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanAdminVM>().ReverseMap();
			CreateMap<TrainingPlanVM, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanCreateVM>()
			.ForMember(dest => dest.Weight, opt => opt.Ignore())
			.ForMember(dest => dest.Sets, opt => opt.Ignore())
			.ForMember(dest => dest.Repeats, opt => opt.Ignore())
			.ForMember(dest => dest.Index, opt => opt.Ignore());
			CreateMap<TrainingPlanCreateVM, TrainingPlan>()
			.ForMember(dest => dest.Weight, opt => opt.Ignore())
			.ForMember(dest => dest.Sets, opt => opt.Ignore())
			.ForMember(dest => dest.Repeats, opt => opt.Ignore())
			.ForMember(dest => dest.Index, opt => opt.Ignore());

			CreateMap<Meal, MealVM>().ReverseMap();
			CreateMap<Meal, MealCreateVM>().ReverseMap();
			CreateMap<MealCreateVM, Ingredient>()
				.ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.IngredientName))
				.ForMember(dest => dest.ServingSize, opt => opt.MapFrom(src => src.IngredientServingSize))
				.ForMember(dest => dest.Id, opt => opt.Ignore());
			CreateMap<Ingredient, MealCreateVM>();
			CreateMap<Ingredient, IngredientVM>().ReverseMap();

			CreateMap<Diet, DietVM>().ReverseMap();
			CreateMap<DietVM, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietMealVM>().ReverseMap();
			CreateMap<Meal, DietMealVM>().ReverseMap();

		}
	}
}
