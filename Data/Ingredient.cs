﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public int? Proteins { get; set; }
		public int? Carbohydrates { get; set; }
		public int? Fats { get; set; }
	}
}
