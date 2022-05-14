namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private SortedDictionary<int, IEnemy> items;

        public Legion()
        {
            this.items = new SortedDictionary<int, IEnemy>();
        }
        public int Size => this.items.Count;

        public bool Contains(IEnemy enemy)
        {
            if (this.items.ContainsKey(enemy.AttackSpeed))
            {
                return true;
            }

            return false;
        }

        public void Create(IEnemy enemy)
        {
            if (!this.items.ContainsKey(enemy.AttackSpeed))
            {
                this.items.Add(enemy.AttackSpeed, enemy);
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            if (this.items.ContainsKey(speed))
            {
                return this.items[speed];
            }

            return null;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var result = new List<IEnemy>();

            foreach (var item in this.items)
            {
                if(item.Key < speed)
                {
                    result.Add(item.Value);
                }

                if(item.Key > speed)
                {
                    break;
                }
            }

            return result;
        }

        public IEnemy GetFastest()
        {
            IEnemy reuslt = null;

            foreach (var item in this.items)
            {
                reuslt = item.Value;
                break;
            }

            return reuslt;
        }

        public IEnemy[] GetOrderedByHealth()
        {
            throw new NotImplementedException();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            throw new NotImplementedException();
        }

        public IEnemy GetSlowest()
        {
            throw new NotImplementedException();
        }

        public void ShootFastest()
        {
            
        }

        public void ShootSlowest()
        {
            throw new NotImplementedException();
        }
    }
}
