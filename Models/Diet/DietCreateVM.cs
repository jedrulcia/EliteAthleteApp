﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Diet
{
    public class DietCreateVM
    {
        // IDs
        public int? Id { get; set; }
        [Display(Name = "Athlete")]
        public string? UserId { get; set; }

        // STRINGS etc.
        [Display(Name = "Diet name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        // OTHER
        public bool RedirectToAdmin { get; set; }
    }
}