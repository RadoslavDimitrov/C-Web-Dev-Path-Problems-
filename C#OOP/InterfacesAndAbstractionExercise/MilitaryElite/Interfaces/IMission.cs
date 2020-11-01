using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }

        void CompleteMission();
    }
}
