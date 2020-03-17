using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Helpers
{
    public class LoggerActionFilter : ActionFilterAttribute
    {
        public string mealType { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey(mealType))
            {
                var type = context.ActionArguments[mealType] as string;
                string time = DateTime.Now.ToString("HH:mm:ss tt");
                MealHelper.Log(new Logger(type, time));
            }
           
        }
    }
}
