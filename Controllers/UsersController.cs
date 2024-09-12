using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Constants;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UsersController(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var userListVM = mapper.Map<List<UserListVM>>(userManager.Users.ToList());
            return View(userListVM);
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
