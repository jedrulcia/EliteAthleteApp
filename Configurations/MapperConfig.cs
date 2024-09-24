﻿using AutoMapper;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			// User module mapping
			CreateMap<User, UserVM>().ReverseMap();

			// Exercise module mapping
			CreateMap<Exercise, ExerciseIndexVM>().ReverseMap();

			CreateMap<ExerciseCategory, ExerciseCategoryVM>().ReverseMap();

			// Training Plan module mapping
            CreateMap<TrainingPlan, TrainingPlanIndexVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanManageExercisesVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanDetailsVM>().ReverseMap();

			// Ingredient module mapping
            CreateMap<Ingredient, IngredientVM>().ReverseMap();

			// Meal module mapping
            CreateMap<Meal, MealIndexVM>().ReverseMap();
			CreateMap<Meal, MealCreateVM>().ReverseMap();
			CreateMap<Meal, MealManageIngredientsVM>().ReverseMap();
			CreateMap<Meal, MealDetailsVM>().ReverseMap();

            // Diet module mapping
            CreateMap<Diet, DietIndexVM>().ReverseMap();
			CreateMap<Diet, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietManageMealsVM>().ReverseMap();
		}
	}
}
