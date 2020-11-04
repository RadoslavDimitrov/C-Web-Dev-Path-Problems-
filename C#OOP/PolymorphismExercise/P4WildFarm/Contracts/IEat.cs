using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Contracts
{
    public interface IEat
    {
        void Eat(Food food);
    }
}
