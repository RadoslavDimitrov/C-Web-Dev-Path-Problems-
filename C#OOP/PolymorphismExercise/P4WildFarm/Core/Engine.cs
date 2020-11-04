using P4WildFarm.Factories;
using P4WildFarm.Models.Animals;
using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Core
{
    public class Engine
    {
        private List<Animal> animalList;
        private AnimalFactory animalFactory;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animalList = new List<Animal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }

                try
                {
                    string[] animalInput = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Animal animal = animalFactory.CreateAnimal(animalInput);
                    animalList.Add(animal);

                    string[] foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Food food = foodFactory.CreateFood(foodInput);

                    animal.ProduceSound();
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
            }

            foreach (var animal in animalList)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
