using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double Cubics = 5000;
        private const int MinHp = 400;
        private const int MaxHp = 600;
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, Cubics, MinHp, MaxHp)
        {
        }
    }
}
