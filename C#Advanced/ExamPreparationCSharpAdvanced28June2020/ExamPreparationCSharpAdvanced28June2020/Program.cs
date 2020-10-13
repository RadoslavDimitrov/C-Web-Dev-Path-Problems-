using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparationCSharpAdvanced28June2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffect = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] bombCasings = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            //first bombEf with last bombCas

            //•	Datura Bombs: 40
            //•	Cherry Bombs: 60
            //•	Smoke Decoy Bombs: 120
            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoy = 0;

            bool isBagFull = false;

            Queue<int> bombEff = new Queue<int>(bombEffect);
            Stack<int> bombCas = new Stack<int>(bombCasings);

            while (true)
            {
                if (bombEff.Count == 0 || bombCas.Count == 0)
                {
                    break;
                }

                var result = bombEff.Peek() + bombCas.Peek();
                CheckForBombMaterial(ref daturaBombs, ref cherryBombs, ref smokeDecoy, bombEff, bombCas, result);

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoy >= 3)
                {
                    isBagFull = true;
                    break;
                }

            }

            PrintBag(isBagFull);
            PrintSeparateBombBags(bombEff, bombCas);
            PrintBombsAlphabeticly(daturaBombs, cherryBombs, smokeDecoy);
        }

        private static void CheckForBombMaterial(ref int daturaBombs, ref int cherryBombs, ref int smokeDecoy, Queue<int> bombEff, Stack<int> bombCas, int result)
        {
            if (result == 40)
            {
                daturaBombs++;
                bombEff.Dequeue();
                bombCas.Pop();
            }
            else if (result == 60)
            {
                cherryBombs++;
                bombEff.Dequeue();
                bombCas.Pop();
            }
            else if (result == 120)
            {
                smokeDecoy++;
                bombEff.Dequeue();
                bombCas.Pop();
            }
            else
            {
                int currNum = bombCas.Pop() - 5;
                bombCas.Push(currNum);
            }
        }

        private static void PrintBombsAlphabeticly(int daturaBombs, int cherryBombs, int smokeDecoy)
        {
            Dictionary<string, int> bombBag = new Dictionary<string, int>();

            bombBag.Add("Datura Bombs", daturaBombs);
            bombBag.Add("Cherry Bombs", cherryBombs);
            bombBag.Add("Smoke Decoy Bombs", smokeDecoy);

            bombBag = bombBag.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in bombBag)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void PrintSeparateBombBags(Queue<int> bombEff, Stack<int> bombCas)
        {
            if (bombEff.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEff)}");
            }

            if (bombCas.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCas)}");
            }
        }

        private static void PrintBag(bool isBagFull)
        {
            if (isBagFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
        }
    }
}
