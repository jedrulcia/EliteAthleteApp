using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Controllers;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
    public class TrainingPlanIndexVM
    {
        public string UserId { get; set; }
        public string? CoachId { get; set; }
        public int? TrainingModuleId { get; set; }
        public List<TrainingPlanVM> TrainingPlanVMs { get; set; }
        public TrainingPlanDetailsVM TrainingPlanDetailsVM { get; set; }
    }
}
