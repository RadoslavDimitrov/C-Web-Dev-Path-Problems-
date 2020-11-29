using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        public SerializationInfo ExceptionMessage { get; private set; }
        protected IList<IRobot> Robots { get;}


        public virtual void DoService(IRobot robot, int procedureTime)
        {
            // TODO procedureTime
            if(robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            foreach (var item in Robots)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
