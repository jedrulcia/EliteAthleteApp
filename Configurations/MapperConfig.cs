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
        }
    }
}
