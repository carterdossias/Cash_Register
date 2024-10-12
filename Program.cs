using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

namespace Cash_Register;

class Program
{



    static void ProcessOneCustomer()
    {
        List<decimal> totalPrice = new List<decimal>();
        decimal subtotal = 00.00m; //Total of all items purchased before tax
        int itemsPurchased = 0; //number of items purchased
        decimal salesTax = 00.00m; //ouput of subtotal * sales tax percent
        decimal SalesTaxPercent = .0615m; //the sales tax percent 
        decimal total = 00.00m; //the total the customer must pay (subtotal + salestax)
        decimal cashBack = 00.00m; //the amount of cashback the customer will get after paying
        Console.WriteLine("Hello! Welcome to the cash register program.");
        totalPrice = GetPrice(); //Gets a list of all items to be purchased theough GetPrice Method
        foreach (decimal price in totalPrice) //adds all of the items
        {
            subtotal += price;
            itemsPurchased++;
        }

        salesTax = Decimal.Round((subtotal * SalesTaxPercent), 2, MidpointRounding.AwayFromZero); //calculates sales tax
        Console.WriteLine($"The total number of purchased items is {itemsPurchased}");
        Console.WriteLine($"The subtotal is ${subtotal}. The sales tax is ${salesTax}");
        total = subtotal + salesTax; // calculates the total the customer pays
        Console.WriteLine($"The  total amount due is ${total}");
        cashBack = getCashBack(total); //Gets the amount of cashback to the customer with the input of the original total
        getChange(cashBack); //tells the clerk the bills / currencies to give as cash back
        Console.WriteLine("Thank you for using the cash register program. Have a good day!");

    }

    static List<decimal> GetPrice()
    {
        decimal price = 00.00m;
        int testIfLooped = 0;
        List<decimal> getPriceTotal = new List<decimal>();
        string inputPrice;
        do //loops for all items purchased and ends when the user hits enter
        {
            if (testIfLooped == 0) //Checks to see if its the first time looping and prints the first time message
            {
                Console.Write("Enter Item Price (e.g.,1.99): ");
            }
            else
            {
                Console.Write("Enter Item Price (e.g.,1.99) or press return key if done: ");
            }
            inputPrice = Console.ReadLine();
            if (inputPrice == "" && testIfLooped != 0) //breaks out of the loop if \n
            {
                break;
            }
            else if (decimal.TryParse(inputPrice, out price) == true) //checks if the input is a decimal and adds the item to the list
            {
                price = decimal.Parse(inputPrice);
                getPriceTotal.Add(price);
            }
            else //if not a decimal this will ask the user to input a correct price
            {
                Console.WriteLine($"The input string {inputPrice} was not in a correct format \nPlease enter a valid price (ex. 1.50)");
            }
            testIfLooped++; //helps tset if we've looped before

        } while (true);

        return getPriceTotal; //returns the final list

    }

    static void getChange(decimal cashBack)
    {
        double[] currencies = { 20, 10, 5, 1, 0.25, 0.10, 0.05, 0.01 };
        string[] endings = { "$20 bill(s)", "$10 bill(s)", "$5 bill(s)", "$1 bill(s)", "quarter(s)", "dime(s)", "nickel(s)", "penny(ies)" };

        double changeAmount = (double)cashBack; //converts the cashBack to a double
        do //each if / else if checks if the current changeAmount is big enough to be divisible by the current currency, and if so it will loop until it isnt anymore and print out how many times it was divisible
        {
            if (changeAmount >= currencies[0])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[0];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount >= currencies[0]);
                Console.WriteLine($"{count} {endings[0]}");
            }

            else if (changeAmount >= currencies[1])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[1];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount >= currencies[1]);
                Console.WriteLine($"{count} {endings[1]}");
            }
            else if (changeAmount >= currencies[2])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[2];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount >= currencies[2]);
                Console.WriteLine($"{count} {endings[2]}");
            }
            else if (changeAmount >= currencies[3])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[3];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount >= currencies[3]);
                Console.WriteLine($"{count} {endings[3]}");
            }
            else if (changeAmount >= currencies[4])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[4];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount >= currencies[4]);
                Console.WriteLine($"{count} {endings[4]}");
            }
            else if (changeAmount >= currencies[5])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[5];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount >= currencies[5]);
                Console.WriteLine($"{count} {endings[5]}");
            }
            else if (changeAmount >= currencies[6])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[6];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount >= currencies[6]);
                Console.WriteLine($"{count} {endings[6]}");
            }
            else if (changeAmount >= currencies[7])
            {
                int count = 0;
                do
                {
                    changeAmount -= currencies[7];
                    changeAmount = Math.Round(changeAmount, 2);
                    count++;
                } while (changeAmount > 0);
                Console.WriteLine($"{count} {endings[7]}");
            }

        } while (changeAmount > 0);


    }
    static decimal getCashBack(decimal total)
    {
        decimal customerCash = 00.00m;
        decimal cashBacktoCust = 00.00m;
        string cashinput;
        Console.Write("How much cash did the customer give you: ");
        do
        {
            cashinput = Console.ReadLine();
            if (decimal.TryParse(cashinput, out customerCash) == true) //checks to see if the amount entered is a decimal
            {
                customerCash = decimal.Parse(cashinput);
                if (customerCash >= total)
                {
                    cashBacktoCust = customerCash - total;
                    break;
                }
                else
                {
                    Console.WriteLine("The customer did not give enough cash to meet the total.");
                }
            }

            Console.Write("Please enter a valid cash amount from the customer: "); //incase there was nothing valid entered

        } while (true);
        Console.WriteLine($"The amount of change to be given back is ${cashBacktoCust}");
        return cashBacktoCust; // returns the amount the customer should get back
    }
    static void Main(string[] args)
    {
        ProcessOneCustomer();
    }
}
