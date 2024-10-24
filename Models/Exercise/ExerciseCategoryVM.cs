﻿using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.Exercise
{
    public class ExerciseCategoryVM
    {
        // IDs
        public int Id { get; set; }

        // STRINGS etc.
        [Display(Name="Exercise Category")]
        [Required]
        public string Name { get; set; }
    }
}
