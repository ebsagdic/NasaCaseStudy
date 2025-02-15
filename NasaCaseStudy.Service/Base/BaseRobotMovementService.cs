using NasaCaseStudy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaCaseStudy.Service.Base
{
    public abstract class BaseRobotMovementService
    {
        protected virtual void TurnLeft(Robot robot)
        {
            if (robot.Direction == 'N')
            {
                robot.Direction = 'W';
            }
            else if (robot.Direction == 'W')
            {
                robot.Direction = 'S';
            }
            else if (robot.Direction == 'S')
            {
                robot.Direction = 'E';
            }
            else if (robot.Direction == 'E')
            {
                robot.Direction = 'N';
            }
        }
        protected virtual void TurnRight(Robot robot)
        {
            if (robot.Direction == 'N')
            {
                robot.Direction = 'E';
            }
            else if (robot.Direction == 'E')
            {
                robot.Direction = 'S';
            }
            else if (robot.Direction == 'S')
            {
                robot.Direction = 'W';
            }
            else if (robot.Direction == 'W')
            {
                robot.Direction = 'N';
            }
        }
        protected virtual void Move(Robot robot, MarsSurface surface)
        {
            switch (robot.Direction)
            {
                case 'N': if (robot.Y < surface.MaxY) robot.Y++; break;
                case 'S': if (robot.Y > 0) robot.Y--; break;
                case 'E': if (robot.X < surface.MaxX) robot.X++; break;
                case 'W': if (robot.X > 0) robot.X--; break;
            }
        }
    }
}
