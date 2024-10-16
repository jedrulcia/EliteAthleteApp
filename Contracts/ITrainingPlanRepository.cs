﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Contracts
{
	public interface ITrainingPlanRepository : IGenericRepository<TrainingPlan>
	{
		// GETS A LIST OF SPECIFIC USER TRAINING PLANS BASED ON PROVIDED TRAINING PLAN IDs.
		Task<TrainingPlanIndexVM> GetTrainingPlanIndexVMAsync(List<int> trainingPlanIds);

		// GETS THE TRAINING PLAN DETAILS VIEW MODEL FOR THE SPECIFIED TRAINING PLAN.
		Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVMAsync(TrainingPlan trainingPlan);

		// GETS THE TRAINING PLAN MANAGE EXERCISES VIEW MODEL FOR THE SPECIFIED TRAINING PLAN ID.
		Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVMAsync(int? id);

		Task<TrainingPlanCopyVM> GetTrainingPlanCopyVMAsync(int? copyFromId, List<int> trainingPlanIds);

		Task<TrainingPlanChangeStatusVM> GetTrainingPlanChangeStatusVMAsync(int id);

		// CREATES A NEW DATABASE ENTITY IN THE TRAINING PLAN TABLE AND RETURNS THE NEW ID.
		Task<int> CreateTrainingPlanAsync(TrainingPlanCreateVM model);

		// ADDS AN EXERCISE TO THE SPECIFIED TRAINING PLAN.
		Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlanAsync(TrainingPlanAddExerciseVM trainingPlanCreateVM);

		// EDIT AN EXERCISE IN SPECIFIED TRAINING PLAN.
		Task<TrainingPlanManageExercisesVM> EditExerciseInTrainingPlanAsync(TrainingPlanAddExerciseVM trainingPlanCreateVM, int? index);

		// REMOVES AN EXERCISE FROM THE SPECIFIED TRAINING PLAN BASED ON TRAINING PLAN ID AND EXERCISE INDEX.
		Task RemoveExerciseFromTrainingPlanAsync(int id, int index);

		// CHANGES THE STATUS OF THE TRAINING PLAN (ACTIVE/NOT ACTIVE).
		Task CompleteTrainingPlanAsync(int trainingPlanId, string raport);

		// COPIES A TRAINING PLAN TO ANOTHER TRAINING PLAN WITHIN THE SAME MODULE.
		Task CopyTrainingPlanAsync(int copyFromId, int copyToId);

		// GENERATES TRAINING MODULE IN PDF
		Task<byte[]> GetTrainingModulePDFAsync(List<int> trainingPlanIds);
	}
}
