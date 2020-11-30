using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int FireRate = 1;
        public Pistol(string name, int bulletsCount) 
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
