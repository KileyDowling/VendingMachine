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
        private double _depCoins = 0;
        public double additionalCoins = 0;
        public double newCoin = 0;

        public string selectedItem = "";
        public string sadditionalCoins = "";
        public string snewCoin = "";
        public string sinsertedCoins = "";
        public bool InsertMoreCoins = false;
        public bool validInput = true;


        //constructor that intializes the vending machine with an initial deposit 
        public VendingMachine(int initialDeposit)
        {
            _depositedAmount = initialDeposit;
        }

        //deposit coins
        public void DepositCoin(string coinAmount)
        {
                    //check user deposit and assign to coin amount
                    switch (coinAmount)
                    {
                        case "1":
                            _depCoins = .05;
                            break;
                        case "2":
                            _depCoins = .10;

                            break;
                        case "3":
                            _depCoins = .25;

                            break;
                        case "4":
                            _depCoins = 1;
                            break;

                        default:
                            validInput = false;
                            break;
                    }

                    //add coins to initial deposit
                    _depositedAmount += _depCoins;
                }

        //get current deposit amount at any point in time
        public double currentDepositAmount() 
        {
            return _depositedAmount;
        }
            
        //allow selection of item from vending machine
        public void Selection(string selectedItem)
        {
             switch (selectedItem.ToUpper())
             {
                 case "CHIPS":
                   GetFood();
                    break;
   
                case "SODA":
                    GetDrink();
                    break;

                case "GUM":
                    GetCandy();
                    break;

                 case "CANCEL":
                    GetRefund();
                    break;

                 default:
                    validInput = false;
                    break;
               }
        }

        public void GetFood()
        {
             double changeAmount = _depositedAmount - 1.25;

            if(changeAmount >= 0)
            {
                _depositedAmount = changeAmount;
            }
            else
            {
                //if deposited amount is not enough to cover price of item, allow user to insert more coins.
                InsertMoreCoins = true;
            }
        }

        public void GetDrink()
        {
            if(_depositedAmount >= .75)
            {
                double changeAmount = _depositedAmount - .75;
                _depositedAmount = changeAmount;
            }

            else
            {
                //if deposited amount is not enough to cover price of item, allow user to insert more coins.
                InsertMoreCoins = true;
            }
        }

        public void GetCandy()
        {
            if (_depositedAmount >= .50)
            {
                double changeAmount = _depositedAmount - .5;
                _depositedAmount = changeAmount;
            }

            else
            {
                //if deposited amount is not enough to cover price of item, allow user to insert more coins.
                InsertMoreCoins = true;
            }
        }


        public string GetRefund()
        {
            //let user know they received a full refund and reset deposit amount
            string refundMsg = "You received a full refund!";
            resetDepositAmount();
            return refundMsg;
        }

        public void resetDepositAmount()
        {
            //set deposit amount back to 0
            _depositedAmount = 0;
        }
       
        public void GetCost()
        {
            Console.WriteLine("\nWe offer the best prices around!");

            FoodItems chips = new FoodItems();
            chips.Name = "O'Lay";
            chips.Price = 1.25;
            Console.WriteLine("Chips ({0}): ${1}", chips.Name, chips.Price);

            FoodItems soda = new FoodItems();
            soda.Name = "Coke";
            soda.Price = .75;
            Console.WriteLine("Soda ({0}): ${1}", soda.Name, soda.Price);

            FoodItems gum = new FoodItems();
            gum.Name = "Orbit";
            gum.Price = .50;
            Console.WriteLine("Gum ({0}): ${1}", gum.Name, gum.Price);

            Console.WriteLine("---");
        }       
    }
}
