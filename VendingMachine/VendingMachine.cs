using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine
    {
        private double _depositedAmount;
        public double additionalCoins = 0;
        public double newCoin = 0;

        public string selectedItem = "";
        public string sadditionalCoins = "";
        public string snewCoin = "";
        public string sinsertedCoins = "";

        //constructor that intializes the vending machine with an initial deposit 
        public VendingMachine(double initialDeposit)
        {
            _depositedAmount = initialDeposit;
        }

        //deposit amount
        public void DepositCoin (double coinAmount)
        {
            if (coinAmount < 0)
            {
                // machine does not accept negative input
                Console.WriteLine("Error, deposit cannot be a negative number. Please submit your coins. depositcoinmoethod");
                coinAmount = 0;
                _depositedAmount = coinAmount;
            }

            else
            {
                //add coins to initial deposit
                _depositedAmount += coinAmount;
            }
        }

        //accept additional coins
        public void AcceptMoreCoins (double additionalCoins)
        {
            _depositedAmount = additionalCoins;
            if (additionalCoins < 0)
            {
                Console.WriteLine("Error, deposit cannot be a negative number.  AMC");
                additionalCoins = 0;
            }

            while (_depositedAmount < .50)
            {
                System.Console.WriteLine("You currently have $" + _depositedAmount + ". Please insert more coins. AMC");
                snewCoin = Console.ReadLine();
                newCoin = Convert.ToDouble(snewCoin);

                if (newCoin >= 0)
                {
                    additionalCoins += (newCoin * .01);
                    _depositedAmount = additionalCoins;
                    newCoin = 0;
                }

            }
            Console.Write("You deposited $" + _depositedAmount + ". ");
        }

        public void Selection(string selectedItem)
        {
             switch (selectedItem)
             {
                 case "chips":
                   GetFood();
                    break;
   
                case "soda":
                    GetDrink();
                    break;


                case "gum":
                    GetCandy();
                    break;

                 case "cancel":
                    GetRefund();
                    break;

                 case "refund":
                    GetRefund();
                    break;

                 default:
                    Console.WriteLine("Invalid selection. We don't offer what you entered");
                    GetRefund();
                    break;
               }
        }

        public void GetFood()
        {
            if (_depositedAmount >= 1.25)
            {
                double changeAmount = _depositedAmount - 1.25;
                Console.Write("Your deposit was $" + _depositedAmount + ". That will get you chips (at a price of $1.25)! Your change is $" + changeAmount + ".");
                _depositedAmount = 0;
            }

            else
            {
                Console.WriteLine("Unforunately, that is not enough to purchase food. You will need to insert more coins");
                InsertMoreCoins();
            }
        }

        public void GetDrink()
        {
           
            if(_depositedAmount >= .75)
            {
                double changeAmount = _depositedAmount - .75;
                Console.Write("Your deposit was $" + _depositedAmount + ". That will get you a soda (at a price of  $.75)! Your change is $" + changeAmount + ".");
                _depositedAmount = 0;
            }

            else
            {
                Console.WriteLine("Unforunately, that is not enough to purchase a drink. You will need to insert more coins");
                InsertMoreCoins();
            }
        }

        public void GetCandy()
        {
            if (_depositedAmount >= .50)
            {
                double changeAmount = _depositedAmount - .50;
                Console.Write("Your deposit was $" + _depositedAmount + ". That will get you gum (at a price of $.50)! Your change is $" + changeAmount + ".");
                _depositedAmount = 0;
            }

            else
            {
                Console.WriteLine("Unforunately, that is not enough to purchase gum. You will need to insert more coins");
                InsertMoreCoins();
            }
        }


        public void GetRefund()
        {
            double refundAmount = _depositedAmount;
            Console.WriteLine("You were refunded $" + refundAmount);
            _depositedAmount = 0;
        }

       
        public void GetCost()
        {
            Console.WriteLine("We offer the best prices around!");

            FoodItems chips = new FoodItems();
            chips.Name = "O'Lay";
            chips.Price = 1.25;
            Console.WriteLine("Chips (" + chips.Name + "): $" + chips.Price);

            FoodItems soda = new FoodItems();
            soda.Name = "Coke";
            soda.Price = .75;
            Console.WriteLine("Soda (" + soda.Name + "): $" + soda.Price);

            FoodItems gum = new FoodItems();
            gum.Name = "Orbit";
            gum.Price = .50;
            Console.WriteLine("Gum (" + gum.Name + "): $" + gum.Price);
        }

        //if a user does not provide enough coins to make a purchase, they should be able to insert more
        public void InsertMoreCoins ()
        {
            sinsertedCoins = Console.ReadLine();
            _depositedAmount = _depositedAmount + (Convert.ToDouble(sinsertedCoins) * .01);

            while (_depositedAmount < .5)
            {
                System.Console.WriteLine("You currently have $" + _depositedAmount + ". Please insert more coins. IMC");
                snewCoin = Console.ReadLine();
                newCoin = Convert.ToDouble(snewCoin);
                newCoin *= .01;
                _depositedAmount += newCoin;
            }

            Console.WriteLine("You currently have $" + _depositedAmount + ". Please make a selection. Enter 'cost' to see a list of available items and their cost");

            selectedItem = Console.ReadLine();
            if (selectedItem == "cost")
            {
                GetCost();
                selectedItem = Console.ReadLine();
                Selection(selectedItem);
            }

            else
            {
                Selection(selectedItem);
            }
        }
    }
}
