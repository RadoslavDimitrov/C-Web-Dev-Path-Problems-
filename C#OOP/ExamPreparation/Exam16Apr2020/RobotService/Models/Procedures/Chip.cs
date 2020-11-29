using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                string message = string.Format(ExceptionMessages.AlreadyChipped, robot.Name);
                throw new ArgumentException(message);
            }

      
            robot.Happiness -= 5;
            robot.IsChipped = true;
            this.Robots.Add(robot);
        }
    }
}
