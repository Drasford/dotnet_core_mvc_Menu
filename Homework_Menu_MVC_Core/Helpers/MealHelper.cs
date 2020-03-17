using Homework_Menu_MVC_Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Homework_Menu_MVC_Core.Helpers
{
    public static class MealHelper
    {

        public static List<Meal> GetAllMeals()
        {
            List<Meal> meals = new List<Meal>();
            using (StreamReader sr = new StreamReader("./Data/Meals.json"))
            {
                string json = sr.ReadToEnd();
                meals = JsonConvert.DeserializeObject<List<Meal>>(json);
            }
            return meals;
        }

        public static List<MealType> GetAllMealTypes()
        {
            List<MealType> mealTypes = new List<MealType>();

            using (StreamReader sr = new StreamReader("./Data/MealTypes.json"))
            {
                string json = sr.ReadToEnd();
                mealTypes = JsonConvert.DeserializeObject<List<MealType>>(json);
            }
            return mealTypes;
        }

        public static List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (StreamReader sr = new StreamReader("./Data/Ingredients.json"))
            {
                string json = sr.ReadToEnd();
                ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(json);
            }
            return ingredients;

        }

        public static void AddMeal(Meal meal)
        {
            var allMeals = GetAllMeals();
            if (allMeals.Any(e => e.Name == meal.Name))
            {
                throw new Exception();
            }
            allMeals.Add(meal);
            JsonSerializer serializer = new JsonSerializer();
           
            using (StreamWriter sw = new StreamWriter("./Data/Meals.json"))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, allMeals);
                }
            }
        }

        public static void DeleteMeal(string mealName)
        {
            List<Meal> allMeals = GetAllMeals();
            var meal = allMeals.Where(m => m.Name.Equals(mealName)).FirstOrDefault();
            allMeals.Remove(meal);

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter("./Data/Meals.json"))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, allMeals);
                }
            }

        }

        public static void Log(Logger log)
        {
            List<Logger> logs = new List<Logger>();
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader r = new StreamReader("./Data/Logger.json"))
            {
                string json = r.ReadToEnd();
                logs = JsonConvert.DeserializeObject<List<Logger>>(json);
            }
            logs.Add(log);

            using (StreamWriter sw = new StreamWriter("./Data/Logger.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, logs);
                }
            }
        }
    }
}
