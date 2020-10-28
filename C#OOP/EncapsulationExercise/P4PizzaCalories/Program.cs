using System;

namespace P4PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dough Tip500 Chewy 100
            Dough dough = new Dough("White", "Chewy", 100);
            Console.WriteLine($"{dough.CallPerGram:F2}");

            //Topping meat 30

            //Topping tp = new Topping("Meat", 500);
            //Console.WriteLine($"{tp.CalsPerGram} ");


        }
    }
}
