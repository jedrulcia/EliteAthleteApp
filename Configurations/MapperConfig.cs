using AutoMapper;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Exercise, ExerciseVM>().ReverseMap();
            CreateMap<TrainingPlan, TrainingPlanVM>().ReverseMap();
            CreateMap<User, UserListVM>().ReverseMap();
            CreateMap<TrainingPlan, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlanVM, TrainingPlanCreateVM>().ReverseMap();
            CreateMap<Exercise, TrainingPlanExerciseVM>().ReverseMap();
            CreateMap<TrainingPlan, TrainingPlanAdminVM>().ReverseMap();
            CreateMap<Meal, MealVM>().ReverseMap();
            CreateMap<Meal, MealCreateVM>().ReverseMap();
            CreateMap<MealCreateVM, Ingredient>()
                .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.IngredientName))
                .ForMember(dest => dest.ServingSize, opt => opt.MapFrom(src => src.IngredientServingSize))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Ingredient, MealCreateVM>();
            CreateMap<Ingredient,  IngredientVM>().ReverseMap();
        }
    }
}
