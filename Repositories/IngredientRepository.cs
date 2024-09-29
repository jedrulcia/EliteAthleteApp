﻿using AutoMapper;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Ingredient;

namespace TrainingPlanApp.Web.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public IngredientRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

		// GETS THE LIST OF ALL INGREDIENTS WITH COUNTED CALORIES.
		public async Task<List<IngredientVM>> GetIngredientVM()
		{
			var ingredientVM = mapper.Map<List<IngredientVM>>(await GetAllAsync());
			for (var i = 0; i < ingredientVM.Count; i++)
			{
				ingredientVM[i].Kcal = Convert.ToInt16(ingredientVM[i].Proteins * 4 + ingredientVM[i].Carbohydrates * 4 + ingredientVM[i].Fats * 9);
			}
			return ingredientVM;
		}

		// GETS A LIST OF SPECIFIC INGREDIENTS BASED ON PROVIDED INGREDIENT IDs.
		public async Task<List<IngredientVM?>?> GetListOfIngredients(List<int?>? ingredientIds)
		{
			List<IngredientVM> ingredients = new List<IngredientVM>();
			foreach (int id in ingredientIds)
			{
				var ingredientVM = mapper.Map<IngredientVM>(await GetAsync(id));
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
			ingredientVM.Kcal = (Convert.ToInt16(ingredientVM.Proteins * 4 + ingredientVM.Carbohydrates * 4 + ingredientVM.Fats * 9));

			return ingredientVM;
		}

		// CREATES A NEW DATABASE ENTITY IN THE INGREDIENT TABLE.
		public async Task CreateIngredient(IngredientVM ingredientVM)
		{
			var ingredient = mapper.Map<Ingredient>(ingredientVM);
			await AddAsync(ingredient);
		}

		// EDITS THE NAME AND MACROS OF THE SPECIFIED INGREDIENT.
		public async Task EditIngredient(IngredientVM ingredientVM)
		{
			var ingredient = mapper.Map<Ingredient>(ingredientVM);
			await UpdateAsync(ingredient);
		}
    }
}
