using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Data;
using AutoMapper;
using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Controllers
{
	public class ChatController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;

		public ChatController(UserManager<User> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
		}

		public async Task <IActionResult> Chat()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return View(mapper.Map<UserVM>(user));
		}
	}
}
