using MilitaryElite.Enums;
using System;


namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }

    }
}
