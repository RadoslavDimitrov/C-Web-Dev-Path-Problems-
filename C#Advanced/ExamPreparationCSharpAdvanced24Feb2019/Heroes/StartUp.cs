using System;

namespace Heroes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HeroRepository repository = new HeroRepository();

            Item item = new Item(23, 35, 48);

            Console.WriteLine(item);

            Hero hero = new Hero("Hero name", 24, item);

            Console.WriteLine(hero);

            repository.Add(hero);

            repository.Remove("Hero name");

            Item secondItem = new Item(100, 20, 13);
            Hero secondHero = new Hero("Second Hero Name", 125, secondItem);

            repository.Add(hero);
            repository.Add(secondHero);

            Hero heroStrength = repository.GetHeroWithHighestStrength();
            Hero heroAbility = repository.GetHeroWithHighestAbility();
            Hero heroIntelligence = repository.GetHeroWithHighestIntelligence();

            Console.WriteLine(repository.Count);

            Console.WriteLine(repository);
        }
    }
}
