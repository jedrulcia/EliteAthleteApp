﻿using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models.Exercise
{
    public class ExerciseIndexVM
	{
		public string CoachId { get; set; }
		public List<ExerciseVM> ExerciseVMs { get; set; }
    }
}
