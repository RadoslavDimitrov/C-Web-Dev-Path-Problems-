using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double Cubics = 3000;
        private const int MinHp = 250;
        private const int MaxHp = 450;
        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, Cubics, MinHp, MaxHp)
        {
        }
    }
}
