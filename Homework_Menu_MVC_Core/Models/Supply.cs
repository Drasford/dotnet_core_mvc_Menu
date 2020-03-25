using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
    }
}
