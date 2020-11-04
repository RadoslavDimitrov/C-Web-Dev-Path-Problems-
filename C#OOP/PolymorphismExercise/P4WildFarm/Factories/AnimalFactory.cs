using P4WildFarm.Models.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] arg)
        {
            string animalType = arg[0];
            string name = arg[1];
            double weight = double.Parse(arg[2]);

            Animal animal = null;

            switch (animalType.ToLower())
            {
                case "owl":
                    return animal = new Owl(name, weight, double.Parse(arg[3]));
                case "hen":
                    return animal = new Hen(name, weight, double.Parse(arg[3]));
                case "mouse":
                    return animal = new Mouse(name, weight, arg[3]);
                case "dog":
                    return animal = new Dog(name, weight, arg[3]);
                case "cat":
                    return animal = new Cat(name, weight, arg[3], arg[4]);
                case "tiger":
                    return animal = new Tiger(name, weight, arg[3], arg[4]);
                default:
                    return animal;
            }
        }
    }
}
