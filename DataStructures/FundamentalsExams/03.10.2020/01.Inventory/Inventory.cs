namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IHolder
    {
        private List<IWeapon> items;

        public Inventory()
        {
            this.items = new List<IWeapon>();
        }

        public int Capacity => this.items.Count;

        public void Add(IWeapon weapon)
        {
            this.items.Add(weapon);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return this.items.Contains(weapon);
        }

        public void EmptyArsenal(Category category)
        {
            foreach (var item in this.items)
            {
                if(item.Category == category)
                {
                    item.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            var currWeap = CheckValidItem(weapon);

            if (currWeap.Ammunition >= ammunition)
            {
                currWeap.Ammunition -= ammunition;
                return true;
            }

            return false;
        }

        private IWeapon CheckValidItem(IWeapon weapon)
        {
            if (!this.items.Contains(weapon))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            var currWeap = this.items.IndexOf(weapon);

            return this.items[currWeap];
        }

        public IWeapon GetById(int id)
        {
            IWeapon weapon = null;

            foreach (var item in this.items)
            {
                if(item.Id == id)
                {
                    weapon = item;
                }
            }

            return weapon;
        }

        public IEnumerator GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            var currWeap = this.CheckValidItem(weapon);

            currWeap.Ammunition += ammunition;
            if (currWeap.Ammunition > currWeap.MaxCapacity)
            {
                currWeap.Ammunition = currWeap.MaxCapacity;
            }

            return currWeap.Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            var currWeap = this.CheckValidItem(this.GetById(id));

            var currIndex = this.items.IndexOf(currWeap);
            
            this.items.RemoveAt(currIndex);

            return currWeap;
        }

        public int RemoveHeavy()
        {
            var result = 0;
            var count = this.items.Count();

            for (int i = 0; i < count; i++)
            {
                if(this.items[i].Category == Category.Heavy)
                {
                    result++;
                }
            }

            this.items.RemoveAll(x => x.Category == Category.Heavy);

            return result;
        }

        public List<IWeapon> RetrieveAll()
        {
            List<IWeapon> result;

            result = this.items.ToList();

            return result;
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var result = new List<IWeapon>();

            int lowIndex = (int)lower;
            int upIndex = (int)upper;

            foreach (var item in this.items)
            {
                if((int)item.Category >= lowIndex && (int)item.Category <= upIndex)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var firstWeap = this.CheckValidItem(firstWeapon);
            var secondWeap = this.CheckValidItem(secondWeapon);

            int firstIndex = this.items.IndexOf(firstWeap);
            int secondIndex = this.items.IndexOf(secondWeap);

            var tempWeap = firstWeap;
            this.items[firstIndex] = secondWeap;
            this.items[secondIndex] = tempWeap;
        }
    }
}
