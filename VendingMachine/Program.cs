using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            const string _EXIT = "exit";

            string data = "";

            string userInput;
            bool acceptCoins = true;


            while (data != _EXIT)
            {
              Console.Write("Welcome to Vending Unlimited. We are happy to meet your all of your vending needs. ");

                //initiate new vending machine
                VendingMachine vendingUnlimited = new VendingMachine(0);


                //create master loop for program
                while (acceptCoins)
                {
                    //accept initial deposit
                    Console.WriteLine("Please submit your coins. \n 1: Nickel \n 2: Dime \n 3: Quarter \n 4: Dollar");
                    userInput = Console.ReadLine();

                    //check if deposit is valid, add or reset deposit amount
                    vendingUnlimited.DepositCoin(userInput);

                    Console.WriteLine("Your current deposit amount is ${0}, would you like to make a purchase?", vendingUnlimited.currentDepositAmount());

                    userInput = Console.ReadLine();
                    userInput = userInput.ToUpper();
                    while (userInput == "YES")
                    {    
                        Console.WriteLine("What would you like to purchase? You can enter 'cost' to see our prices or 'cancel' to get a refund");
                        string purchaseRequest = Console.ReadLine();

                        if (purchaseRequest == "cost")
                        {
                            vendingUnlimited.GetCost();
                            userInput = "";
                            acceptCoins = false;
                        }
                        else
                        {
                            vendingUnlimited.Selection(purchaseRequest);
                            userInput = "";
                            acceptCoins = false;
                        }
                    }
             
                }
                
                System.Console.WriteLine("\n----------------------\nWould you like to make another purchase? Please enter one of the following options: \nContinue. \nExit");

                data = System.Console.ReadLine();

                if (data == _EXIT)
                {
                    Console.Write("Thank you for using Vending Unlimited. Good-Bye!");
                }
                else
                {
                    acceptCoins = true;
                }
            }

            Console.ReadLine();

        }

    }
}