﻿using AutoMapper;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models;
using EliteAthleteApp.Models.Diet;
using EliteAthleteApp.Models.Exercise;
using EliteAthleteApp.Models.Ingredient;
using EliteAthleteApp.Models.Meal;
using EliteAthleteApp.Models.TrainingModule;
using EliteAthleteApp.Models.TrainingPlan;

namespace EliteAthleteApp.Configurations
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
			CreateMap<Exercise, ExerciseCreateVM>().ReverseMap();
			CreateMap<Exercise, ExerciseDeleteVM>().ReverseMap();

			CreateMap<ExerciseCategory, ExerciseCategoryVM>().ReverseMap();
			CreateMap<ExerciseMuscleGroup, ExerciseMuscleGroupVM>().ReverseMap();

			// TRAINING PLAN MODULE MAPPING
			CreateMap<TrainingPlan, TrainingPlanVM>().ReverseMap();
            CreateMap<TrainingPlan, TrainingPlanIndexVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanManageExercisesVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanDetailsVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanChangeStatusVM>().ReverseMap();

			CreateMap<TrainingPlanPhase, TrainingPlanPhaseVM>().ReverseMap();
			CreateMap<TrainingPlanExerciseDetail, TrainingPlanExerciseDetailVM>().ReverseMap();
			CreateMap<TrainingPlanExerciseDetail, TrainingPlanAddExerciseVM>().ReverseMap();

			// TRAINING MODULE MODULE MAPPING
			CreateMap<TrainingModule, TrainingModuleVM>().ReverseMap();
			CreateMap<TrainingModule, TrainingModuleIndexVM>().ReverseMap();
			CreateMap<TrainingModule, TrainingModuleCreateVM>().ReverseMap();

			CreateMap<TrainingModuleORM, TrainingModuleORMVM>().ReverseMap();

			// INGREDIENT MODULE MAPPING
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
			CreateMap<Diet, DietManageMealsVM>().ReverseMap();
		}
	}
}
