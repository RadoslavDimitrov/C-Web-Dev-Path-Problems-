using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int FireRate = 10;
        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if(this.BulletsCount >= FireRate)
            {
                this.BulletsCount -= FireRate;
                return FireRate;
            }

            return 0;
        }
    }
}
