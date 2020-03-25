using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework_Menu_MVC_Core.Helpers;
using Homework_Menu_MVC_Core.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework_Menu_MVC_Core.Controllers
{
    public class SupplyController : Controller
    {
        // GET: Supply
        public ActionResult Index()
        {
            var viewModel = new SupplyListAndSupplyViewModel
            {
                Supplies = SupplyHelper.GetAllSupplies()
            };

            return View("Supply",viewModel);
        }

        // GET: Supply/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new SupplyListAndSupplyViewModel
            {
                Supply = SupplyHelper.GetAllSupplies().Where(x => x.Id.Equals(id)).FirstOrDefault()
            };
            return View(viewModel);
        }

        // GET: Supply/Create
        public ActionResult Create()
        {
            var viewModel = new SupplyListAndSupplyViewModel
            {
                Ingredients = MealHelper.GetAllIngredients().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList()
            };
           
            return View(viewModel);
        }

        // POST: Supply/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplyListAndSupplyViewModel PostSupply)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create");

            var ingredientNum = int.Parse(PostSupply.PostIngredient);
            var selectedIngredient = MealHelper.GetAllIngredients().Where(x => x.Id == ingredientNum).FirstOrDefault();
            PostSupply.Supply.Ingredient = selectedIngredient;

            PostSupply.Supply.Id = SupplyHelper.GetSupplyNextId();

            SupplyHelper.AddSupply(PostSupply.Supply);

            return RedirectToAction("Index");

        }

        // GET: Supply/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = new SupplyListAndSupplyViewModel
            {
                Supply = SupplyHelper.GetAllSupplies().Where(x => x.Id == id).FirstOrDefault(),
                Ingredients = MealHelper.GetAllIngredients().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList()
            };
            return View(viewModel);
        }

        // POST: Supply/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int editId, SupplyListAndSupplyViewModel PostSupply)
        {
            if (!ModelState.IsValid) return RedirectToAction("Edit");

            var ingredientNum = int.Parse(PostSupply.PostIngredient);
            var selectedIngredient = MealHelper.GetAllIngredients().Where(x => x.Id == ingredientNum).FirstOrDefault();
            PostSupply.Supply.Ingredient = selectedIngredient;

            SupplyHelper.UpdateSupply(editId,PostSupply.Supply);

            return RedirectToAction("Index");

        }


        // POST: Supply/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {

            try
            { 
                SupplyHelper.DeleteSupply(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Neche moci delitate ovo");
            }
        }
    }
}