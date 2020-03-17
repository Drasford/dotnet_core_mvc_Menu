using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework_Menu_MVC_Core.Helpers;
using Homework_Menu_MVC_Core.Models;
using Homework_Menu_MVC_Core.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework_Menu_MVC_Core.Controllers
{
    [Route("menu")]
    public class MenuController : Controller
    {
        // GET: Menu
        [Route("meals")]
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new MealWithMealTypesViewModel
            {
                meals = MealHelper.GetAllMeals(),
            };
            return View("Meals",viewModel);
        }


        [Route("{mealType}/meals")]
        [HttpGet]
        [LoggerActionFilter(mealType = "mealType")]
        public ActionResult Details(string mealType)
        {

            var viewModel = new MealWithMealTypesViewModel
            {
                meals = MealHelper.GetAllMeals().Where(m => m.MealType.Equals(mealType)).ToList()
            };

            return View("Meals", viewModel);
        }

        // GET: Menu/Create
        [Route("create")]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new MealWithMealTypesViewModel
            {
                MealTypes = MealHelper.GetAllMealTypes(),
                Ingredients = MealHelper.GetAllIngredients().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList(),
                PostIngredients = new List<string>()
            };
            return View("CreateMealForm",viewModel);
        }

        // POST: Menu/Create
        [Route("create")]
        [HttpPost]
        public ActionResult CreatePost(IFormCollection arg, MealWithMealTypesViewModel PostMeal)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create");

            var ingredientNums = PostMeal.PostIngredients;
            var queryReadyIngredients = ingredientNums.Select(x => int.Parse(x));
            var query = from num in queryReadyIngredients
                        join Ingredient in PostMeal.AllIngredientsFromViewModel on num equals Ingredient.Id
                        select new { Id = Ingredient.Id, Name = Ingredient.Name };
            var lista = query.ToList();
            List<Ingredient> queryIngredients = new List<Ingredient>();
            var counter = 0;
            foreach (var item in lista)
            {
               Ingredient i = new Ingredient(lista.Skip(counter).First().Id,lista.Skip(counter).First().Name);
                queryIngredients.Add(i);
                counter++;
            }

            PostMeal.meal.Ingredients = queryIngredients;
            PostMeal.meal.MealType = arg["Type"].ToString();                       
            MealHelper.AddMeal(PostMeal.meal);


            return RedirectToAction("Index");
        }


        // POST: Menu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {

                MealHelper.DeleteMeal(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Neche moci delitate ovo");
            }
        }
    }
}