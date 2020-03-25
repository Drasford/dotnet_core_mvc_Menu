using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Models.ViewModels
{
    public class SupplyListAndSupplyViewModel
    {
        public Supply Supply { get; set; }
        public List<Supply> Supplies { get; set; }

        public List<SelectListItem> Ingredients { get; set; }
        public string PostIngredient { get; set; }
    }
}
