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
            const string  _EXIT = "B";

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

                    //while validInput, allow user to continue
                    if (vendingUnlimited.validInput == true)
                    {
                        Console.Write("Your current deposit amount is ${0}, would you like to make a purchase? ", vendingUnlimited.currentDepositAmount());

                        userInput = Console.ReadLine();
                        userInput = userInput.ToUpper();
                        while (userInput == "YES")
                        {
                            Console.Write("\nWhat would you like to purchase? You can enter 'cost' to see our prices or 'cancel' to get a refund:  ");

                            //accept user's purchase request
                            string purchaseRequest = Console.ReadLine();
                            purchaseRequest = purchaseRequest.ToUpper();

                            if (purchaseRequest == "COST")
                            {
                                vendingUnlimited.GetCost();
                                //allow user to make a purchase after viewing prices
                                acceptCoins = true;
                            }

                            else
                            {
                                vendingUnlimited.Selection(purchaseRequest);

                                //if validInput is false, end program
                                if (vendingUnlimited.validInput == false)
                                {
                                   string refundMsg = vendingUnlimited.GetRefund();
                                   Console.WriteLine(refundMsg);
                                    userInput = "";
                                    acceptCoins = false;
                                }
                                else
                                {
                                    if (purchaseRequest == "CANCEL")
                                    {
                                        //provide refund and return to main selection menu
                                        string refundMsg = vendingUnlimited.GetRefund();
                                        Console.WriteLine(refundMsg);
                                        acceptCoins = false;
                                    }

                                    else if (vendingUnlimited.InsertMoreCoins == true)
                                    {
                                        Console.Write("\nYour deposit was ${0}. ", vendingUnlimited.currentDepositAmount());
                                        Console.WriteLine("You did not submit enough coins to purchase {0}. Please see below for a list of prices. \n", purchaseRequest.ToLower());
                                        vendingUnlimited.GetCost();
                                        //resets to false to allow another validation check once more coins have been submitted
                                        vendingUnlimited.InsertMoreCoins = false;
                                    }
                                    //if user did not request a refund and inserted enough coins to make a purchase, provide purchased item and change
                                    else if (vendingUnlimited.currentDepositAmount() != 0)
                                    {
                                        Console.WriteLine("That will get you {0}! Your change is ${1}.", purchaseRequest.ToLower(), vendingUnlimited.currentDepositAmount());
                                        //returns to main selection menu
                                        acceptCoins = false;
                                    }
                                    //exits loops
                                    userInput = "";
                                }
                            }
                        }
                }
                }
                
                System.Console.WriteLine("\n----------------------\n\nWould you like to make another purchase? Please enter one of the following options: \nA. Continue. \nB. Exit");

                data = System.Console.ReadLine();
                data = data.ToUpper();

                if (data == _EXIT)
                {
                    Console.Write("Thank you for using Vending Unlimited. Good-Bye!");
                }
                else
                {
                    //allow user to insert coins and possibly make a purchase
                    acceptCoins = true;
                }
            }
            Console.ReadLine();
        }
    }
}