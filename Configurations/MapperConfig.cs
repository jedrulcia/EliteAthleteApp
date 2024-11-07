using AutoMapper;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingExercise;
using EliteAthleteApp.Models.TrainingModule;
using EliteAthleteApp.Models.TrainingOrm;
using EliteAthleteApp.Models.TrainingPlan;
using EliteAthleteApp.Models.User;
using EliteAthleteApp.Models.UserBodyAnalysis;
using EliteAthleteApp.Models.UserBodyMeasurements;
using EliteAthleteApp.Models.UserMedicalTest;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Configurations
{
    public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			// USER MODULE MAPPING
			CreateMap<User, UserVM>().ReverseMap();
			CreateMap<User, UserInfoVM>().ReverseMap();

			CreateMap<UserChat, UserChatVM>().ReverseMap();

			CreateMap<UserBodyAnalysis, UserBodyAnalysisVM>().ReverseMap();
			CreateMap<UserBodyAnalysis, UserBodyAnalysisCreateVM>().ReverseMap();
			CreateMap<UserBodyAnalysis, UserBodyAnalysisDeleteVM>().ReverseMap();

			CreateMap<UserMedicalTest, UserMedicalTestVM>().ReverseMap();
			CreateMap<UserMedicalTest, UserMedicalTestCreateVM>().ReverseMap();
			CreateMap<UserMedicalTest, UserMedicalTestDeleteVM>().ReverseMap();

			CreateMap<UserBodyMeasurements, UserBodyMeasurementsVM>().ReverseMap();
			CreateMap<UserBodyMeasurements, UserBodyMeasurementsCreateVM>().ReverseMap();
			CreateMap<UserBodyMeasurements, UserBodyMeasurementsDeleteVM>().ReverseMap();

			// TRAINING EXERCISE MAPPING
			CreateMap<TrainingExercise, TrainingExerciseVM>().ReverseMap();
			CreateMap<TrainingExercise, TrainingExerciseIndexVM>().ReverseMap();
			CreateMap<TrainingExercise, TrainingExerciseCreateVM>().ReverseMap();
			CreateMap<TrainingExercise, TrainingExerciseDeleteVM>().ReverseMap();

			CreateMap<TrainingExerciseMedia, TrainingExerciseMediaVM>().ReverseMap();
			CreateMap<TrainingExerciseMedia, TrainingExerciseMediaCreateVM>().ReverseMap();

			CreateMap<TrainingExerciseCategory, TrainingExerciseCategoryVM>().ReverseMap();
			CreateMap<TrainingExerciseMuscleGroup, TrainingExerciseMuscleGroupVM>().ReverseMap();

			// TRAINING PLAN MAPPING
			CreateMap<TrainingPlan, TrainingPlanVM>().ReverseMap();
            CreateMap<TrainingPlan, TrainingPlanIndexVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanManageExercisesVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanDetailsVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanChangeStatusVM>().ReverseMap();

			CreateMap<TrainingPlanPhase, TrainingPlanPhaseVM>().ReverseMap();
			CreateMap<TrainingPlanExerciseDetail, TrainingPlanExerciseDetailVM>().ReverseMap();
			CreateMap<TrainingPlanExerciseDetail, TrainingPlanAddExerciseVM>().ReverseMap();

			// TRAINING MODULE MAPPING
			CreateMap<TrainingModule, TrainingModuleVM>().ReverseMap();
			CreateMap<TrainingModule, TrainingModuleCreateVM>().ReverseMap();
			CreateMap<TrainingModule, TrainingModuleDeleteVM>().ReverseMap();


			// TRAINING ORM MAPPING
			CreateMap<TrainingOrm, TrainingOrmVM>().ReverseMap();
			CreateMap<TrainingOrm, TrainingOrmCreateVM>().ReverseMap();
			CreateMap<TrainingOrm, TrainingOrmDeleteVM>().ReverseMap();

/*			// INGREDIENT MODULE MAPPING
			CreateMap<Ingredient, IngredientVM>().ReverseMap();
			CreateMap<Ingredient, IngredientIndexVM>().ReverseMap();
			CreateMap<Ingredient, IngredientCreateVM>().ReverseMap();

			CreateMap<IngredientCategory, IngredientCategoryVM>().ReverseMap();

			// MEAL MODULE MAPPING
			CreateMap<Meal, MealVM>().ReverseMap();
			CreateMap<Meal, MealIndexVM>().ReverseMap();
			CreateMap<Meal, MealCreateVM>().ReverseMap();
			CreateMap<Meal, MealManageIngredientsVM>().ReverseMap();

			CreateMap<MealCategory, MealCategoryVM>().ReverseMap();

			// DIET MODULE MAPPING
			CreateMap<Diet, DietIndexVM>().ReverseMap();
			CreateMap<Diet, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietManageMealsVM>().ReverseMap();*/
		}
	}
}
