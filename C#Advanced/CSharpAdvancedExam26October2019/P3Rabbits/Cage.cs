using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>(capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public  int Count { get => this.data.Count;}

        public void Add(Rabbit rabbit) //adds an entity to the data if there is room for it
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name) //removes a rabbit by given name, if such exists, and returns bool
        {
            var removedBunny = this.data.FirstOrDefault(x => x.Name == name);
            if (removedBunny != null)
            {
                this.data = this.data.Where(x => x.Name != name).ToList();
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species) //removes all rabbits by given species
        {
            this.data = this.data.Where(x => x.Species != species).ToList();
        }

        public Rabbit SellRabbit(string name) //sell(set its Available property to false without removing it from the collection)
                                              // the first rabbit with the given name, also return the rabbit
        {
            var currRabbit = this.data.FirstOrDefault(x => x.Name == name);
            currRabbit.Available = false;
            return currRabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species) //sells(set their Available property to false
                                                             //without removing them from the collection)
                                                             //and returns all rabbits from that species as an array
        {
            Rabbit[] bunnyArr = data.Where(x => x.Species == species).ToArray();
            for (int i = 0; i < bunnyArr.Length; i++)
            {
                bunnyArr[i].Available = false;
            }

            return bunnyArr;
        }

        public string Report() //including only not sold rabbits
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (Rabbit bunny in this.data.Where(x => x.Available == true))
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
