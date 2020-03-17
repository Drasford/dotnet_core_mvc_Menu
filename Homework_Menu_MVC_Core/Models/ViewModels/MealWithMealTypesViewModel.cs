using Homework_Menu_MVC_Core.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Models.ViewModels
{
    public class MealWithMealTypesViewModel
    {
        public Meal meal { get; set; }
        public List<Meal> meals { get; set; }
        public List<MealType> MealTypes { get; set; }
        public List<SelectListItem> Ingredients { get; set; }


        public List<string> PostIngredients { get; set; }
        public string PostMealType { get; set; }
        public List<Ingredient> AllIngredientsFromViewModel = MealHelper.GetAllIngredients();
    }
}
