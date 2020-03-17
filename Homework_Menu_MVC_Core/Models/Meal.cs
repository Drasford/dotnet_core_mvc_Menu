using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Models
{
    public class Meal
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
      
        public List<Ingredient> Ingredients { get; set; }
    
        public string ?MealType { get; set; }
        public bool IsVegetarian { get; set; }


    }
}
