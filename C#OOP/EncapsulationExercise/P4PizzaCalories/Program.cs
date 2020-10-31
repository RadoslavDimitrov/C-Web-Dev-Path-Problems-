using System;

namespace P4PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaName = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] doughInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Pizza pizza = new Pizza(pizzaName[1]);
                Dough dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
                pizza.Dought = dough;

                string topping = Console.ReadLine();

                while (topping != "END")
                {
                    string[] currTopping = topping.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Topping top = new Topping(currTopping[1], double.Parse(currTopping[2]));

                    pizza.AddTopping(top);

                    topping = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

            }
            
        }
    }
}
