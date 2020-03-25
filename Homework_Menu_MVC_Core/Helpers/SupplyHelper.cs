using Homework_Menu_MVC_Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Helpers
{
    public static class SupplyHelper
    {

        public static List<Supply> GetAllSupplies()
        {
            List<Supply> supplies = new List<Supply>();
            using (StreamReader sr = new StreamReader("./Data/Supply.json"))
            {
                string json = sr.ReadToEnd();
                supplies = JsonConvert.DeserializeObject<List<Supply>>(json);
            }
            var validSupplies = supplies.Where(x => x.Quantity > 0).ToList();
            return validSupplies;
        }

        public static int GetSupplyNextId()
        {
            return GetAllSupplies().Count;
        }

        public static void AddSupply(Supply supply)
        {
            var allSupplies = GetAllSupplies();
            if (allSupplies.Any(e => e.Ingredient.Name == supply.Ingredient.Name))
            {
                var duplikat = allSupplies.Where(x => x.Ingredient.Name == supply.Ingredient.Name).FirstOrDefault();
                duplikat.Quantity += supply.Quantity;
                duplikat.ExpirationDate = supply.ExpirationDate;
            }
            else
            {
                allSupplies.Add(supply);
            }
           
            
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter("./Data/Supply.json"))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, allSupplies);
                }
            }
        }


        public static void UpdateSupply(int id, Supply supply)
        {
            var allSupplies = GetAllSupplies();
            var editedSupply = allSupplies.Where(x => x.Id == id).FirstOrDefault();
            allSupplies[allSupplies.IndexOf(editedSupply)] = supply; 

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter("./Data/Supply.json"))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, allSupplies);
                }
            }

        }

        public static void DeleteSupply(string supplyIngredientName)
        {
            List<Supply> allSupplies = GetAllSupplies();
            var supply = allSupplies.Where(x => x.Ingredient.Name.Equals(supplyIngredientName)).FirstOrDefault();
            allSupplies.Remove(supply);

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter("./Data/Supply.json"))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, allSupplies);
                }
            }

        }
    }
}
