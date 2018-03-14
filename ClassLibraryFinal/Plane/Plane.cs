using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class Plane : MotorVehicle
    {
        public Plane()
        {
            name = "Plane";
            TopSpeed = 200;
            MaxDistancePerRefuel = 5000;
            MaxWeight = 1000;
        }
    }
}