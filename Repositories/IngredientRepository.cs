using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Ingredient;

namespace TrainingPlanApp.Web.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;

		public IngredientRepository(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
		}

		// GETS THE LIST OF ALL INGREDIENTS WITH COUNTED CALORIES.
		public async Task<IngredientIndexVM> GetIngredientIndexVM()
		{
			var dietician = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var ingredients = await GetAllAsync();

			var ingredientVMs = mapper.Map<List<IngredientVM>>(ingredients);

			for (var i = 0; i < ingredients.Count; i++)
			{
				ingredientVMs[i].Kcal = Convert.ToInt16(ingredientVMs[i].Proteins * 4 + ingredientVMs[i].Carbohydrates * 4 + ingredientVMs[i].Fats * 9);
				ingredientVMs[i].IngredientCategory = mapper.Map<IngredientCategoryVM>(await context.Set<IngredientCategory>().FindAsync(ingredientVMs[i].IngredientCategoryId));
			}


			IngredientIndexVM ingredientIndexVM = new IngredientIndexVM
			{
				IngredientVMs = ingredientVMs,
				DieticianId = dietician.Id,
				IngredientCreateVM = new IngredientCreateVM
				{
					DieticianId = dietician.Id,
					AvailableCategories = new SelectList(context.IngredientCategories.OrderBy(e => e.Name), "Id", "Name")
				}
			};

			return ingredientIndexVM;
		}

		// GETS A LIST OF SPECIFIC INGREDIENTS BASED ON PROVIDED INGREDIENT IDs.
		public async Task<List<IngredientIndexVM?>?> GetListOfIngredients(List<int?>? ingredientIds)
		{
			List<IngredientIndexVM> ingredients = new List<IngredientIndexVM>();
			foreach (int id in ingredientIds)
			{
				var ingredientVM = mapper.Map<IngredientIndexVM>(await GetAsync(id));
				ingredients.Add(ingredientVM);
			}
			return ingredients;
		}

		// COUNTS THE MACROS (NUTRIENTS) OF THE SPECIFIED INGREDIENT BASED ON QUANTITY.
		public async Task<IngredientVM?> GetMacrosOfIngredient(int? id, int ingredientQuantity)
		{
			var ingredientVM = mapper.Map<IngredientVM>(await GetAsync(id));

			decimal ingredientMultiplier = ingredientQuantity / (decimal)100.00;
			ingredientVM.Proteins = Math.Round(ingredientVM.Proteins * ingredientMultiplier, 1);
			ingredientVM.Carbohydrates = Math.Round(ingredientVM.Carbohydrates * ingredientMultiplier, 1);
			ingredientVM.Fats = Math.Round(ingredientVM.Fats * ingredientMultiplier, 1);
			ingredientVM.Fibres = Math.Round(ingredientVM.Fibres * ingredientMultiplier, 1);
			ingredientVM.Kcal = (Convert.ToInt16(ingredientVM.Proteins * 4 + ingredientVM.Carbohydrates * 4 + ingredientVM.Fats * 9));

			return ingredientVM;
		}

		// CREATES A NEW DATABASE ENTITY IN THE INGREDIENT TABLE.
		public async Task CreateIngredient(IngredientCreateVM ingredientCreateVM)
		{
			var ingredient = mapper.Map<Ingredient>(ingredientCreateVM);
			await AddAsync(ingredient);
		}

		// EDITS THE NAME AND MACROS OF THE SPECIFIED INGREDIENT.
		public async Task EditIngredient(IngredientCreateVM ingredientCreateVM)
		{
			var ingredient = mapper.Map<Ingredient>(ingredientCreateVM);
			await UpdateAsync(ingredient);
		}

	}
}
