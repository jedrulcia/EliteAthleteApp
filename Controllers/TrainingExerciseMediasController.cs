using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	public class TrainingExerciseMediasController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
