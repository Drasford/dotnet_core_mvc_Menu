using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Models.ViewModels
{
    public class CreateMealViewModel
    {
        [Required]
        [MaxLength(150, ErrorMessage = "Name can't be over 150 characters")]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Meals can't be free :)")]
        public float Price { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        public string MealType { get; set; }
        public bool IsVegetarian { get; set; }

        public List<MealType> mealTypes { get; set; }
        public List<SelectListItem> SelecListIngredients { get; set; }
    }
}
