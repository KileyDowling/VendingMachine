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
            string suserOneDeposit;
            string selectItem;
            string smoreCoins;

            double userOneDeposit = 0;
            double moreCoins;

            //initiate new vending machine
            VendingMachine vendingUnlimited = new VendingMachine(0);

            Console.WriteLine("Welcome to Vending Unlimited. We are happy to meet your all of your vending needs.");

            //request deposit
           while (userOneDeposit == 0)
           { 
            //accept initial deposit
               Console.WriteLine("Please submit your coins");
            suserOneDeposit = Console.ReadLine();

            //convert initial deposit to double
            userOneDeposit = (Convert.ToDouble(suserOneDeposit));

            //checks if userOneDeposit is negative; sets it back to 0 if it is
            if (userOneDeposit < 0)
            {
                Console.WriteLine("Error. Deposit cannot be a negative number. Please try again");
                userOneDeposit = 0;
            }
            
               //sets deposit to cents
            userOneDeposit *= .01;
            
           }
           
            //adds userOneDeposit if amount is greater than 0; otherwise resets deposit amount to 0
            vendingUnlimited.DepositCoin(userOneDeposit);

            //if initial deposit is greater than 0
            while (userOneDeposit > 0)
            {
                //let user know how much they deposited, provide user opportunitiy to insert more coins, make a purchase, or get a refund
                Console.WriteLine("You deposited $" + userOneDeposit + ". Please deposit more coins. Or select an item to purchase (gum, chips, soda). Or enter 'cancel' at any time for a refund");

                smoreCoins = Console.ReadLine();
                if (smoreCoins == "cancel" || smoreCoins == "refund")
                {
                    vendingUnlimited.GetRefund();
                    userOneDeposit = 0;
                }

                else if (smoreCoins == "gum" || smoreCoins == "soda" || smoreCoins == "chips")
                {
                    vendingUnlimited.Selection(smoreCoins);
                    userOneDeposit = 0;
                }

                else
                {
                    moreCoins = Convert.ToDouble(smoreCoins);
                    moreCoins *= .01;
                    while (userOneDeposit > 0 && moreCoins >= 0)
                    {
                        moreCoins += userOneDeposit;

                        vendingUnlimited.AcceptMoreCoins(moreCoins);

                        //request item to be purchase
                        Console.WriteLine("What item would you like to purchase today? We have chips, soda, or gum.  You can also request a refund by entering 'cancel' or enter 'cost' to view a list of all options offered and their cost.");
                        selectItem = Console.ReadLine();
                        Console.WriteLine("You selected " + selectItem);

                        //review selection, determine if user deposited enough money
                        if (selectItem == "cost")
                        {
                            vendingUnlimited.GetCost();
                            Console.WriteLine("Please select one of these options");
                            selectItem = Console.ReadLine();
                            vendingUnlimited.Selection(selectItem);
                            userOneDeposit = 0;
                        }
                        else
                        {
                            vendingUnlimited.Selection(selectItem);
                            userOneDeposit = 0;
                        }
                    }
                }
              }
            Console.Write("Thank you for using Vending Unlimited. Good-Bye!");

                Console.ReadLine();
            }
        }
    }