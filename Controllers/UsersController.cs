using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Constants;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.User;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EliteAthleteApp.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;

		public UsersController(UserManager<User> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
		}

		// GET: Users/Index
		public ActionResult Index()
		{
			var userListVM = mapper.Map<List<UserVM>>(userManager.Users.ToList());
			return View(userListVM);
		}

		// GET: Users/Index/Panel
		public async Task <IActionResult> Panel(string? userId)
        {
            if (userId == null)
            {
                return View (mapper.Map<UserVM>(await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)));
			}
            return View(mapper.Map<UserVM>(await userManager.FindByIdAsync(userId)));
        }

        // GET: UsersController/Details
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
