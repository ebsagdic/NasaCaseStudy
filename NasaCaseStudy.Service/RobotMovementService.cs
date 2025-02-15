using NasaCaseStudy.Core.Entity;
using NasaCaseStudy.Core.Interface;
using NasaCaseStudy.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaCaseStudy.Service
{
    public class RobotMovementService : BaseRobotMovementService, IRobotMovementService
    {
        public void ProcessMovement(Robot robot, MarsSurface surface, string commands)
        {
            foreach (var command in commands)
            {
                if (command == 'L')
                {
                    TurnLeft(robot);
                }
                else if (command == 'R')
                {
                    TurnRight(robot);
                }
                else if (command == 'M')
                {
                    Move(robot, surface);
                }
            }
        }
    }
}
