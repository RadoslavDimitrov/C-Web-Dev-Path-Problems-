using System;
using System.Collections.Generic;

namespace P3ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            string[] productInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            
            try
            {
                AddPersons(personInput, personList);
                AddProducts(productInfo, productList);

                string command = Console.ReadLine();


                while (command != "END")
                {
                    string[] currCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = currCommand[0];
                    string productName = currCommand[1];

                    var currPerson = personList.Find(x => x.Name == personName);
                    var currProduct = productList.Find(x => x.Name == productName);

                    if (currPerson.Money >= currProduct.Cost)
                    {
                        currPerson.Money -= currProduct.Cost;
                        currPerson.AddProduct(currProduct);
                        Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{currPerson.Name} can't afford {currProduct.Name}");
                    }

                    command = Console.ReadLine();

                }

                foreach (var person in personList)
                {
                    if (person.bagOfProducts.Count > 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.bagOfProducts)}");

                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }

                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

            }
            
        }

        private static void AddProducts(string[] productInfo, List<Product> productList)
        {
            for (int i = 0; i < productInfo.Length; i++)
            {
                string[] currProduct = productInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string currName;
                decimal currCost;

                if (currProduct.Length > 1)
                {
                    currName = currProduct[0];
                    currCost = decimal.Parse(currProduct[1]);
                }
                else
                {
                    currName = null;
                    currCost = decimal.Parse(currProduct[0]);
                }

                var productToAdd = new Product(currName, currCost);
                productList.Add(productToAdd);

            }
        }

        private static void AddPersons(string[] personInput, List<Person> personList)
        {
            for (int i = 0; i < personInput.Length; i++)
            {
                string[] currPerson = personInput[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string currName;
                decimal currMoney;

                if (currPerson.Length > 1)
                {
                    currName = currPerson[0];
                    currMoney = decimal.Parse(currPerson[1]);
                }
                else
                {
                    currName = null;
                    currMoney = decimal.Parse(currPerson[0]);
                }



                var currPersonToAdd = new Person(currName, currMoney);
                personList.Add(currPersonToAdd);
            }
        }
    }
}
