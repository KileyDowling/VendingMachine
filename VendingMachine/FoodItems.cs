using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class FoodItems
    {
        public string Name { get; set; }

        public double Price 
        {
            get { return _price; }
            set
            {
                if (value > 0)
                    _price = value;
            }
        
        }

        private double _price;
    }
}
