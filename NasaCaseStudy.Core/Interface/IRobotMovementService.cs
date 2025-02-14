using NasaCaseStudy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaCaseStudy.Core.Interface
{
    public interface IRobotMovementService
    {
        void ProcessMovement(Robot robot, MarsSurface surface, string commands);
    }
}
