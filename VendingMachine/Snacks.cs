using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Snacks
    {
        public Snacks()
        {
            items = new List<FoodItems>();

        }

        public void AddFoodItems(string Name, double Price)
        {
            FoodItems item = new FoodItems();
            item.Name = Name;
            item.Price = Price;
            items.Add(item);
        }


        public List<FoodItems> items;


       



    }
}
