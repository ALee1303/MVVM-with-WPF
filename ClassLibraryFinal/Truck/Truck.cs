using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class Truck : MotorVehicle
    {
        public Truck()
        {
            name = "Truck";
            TopSpeed = 65;
            MaxDistancePerRefuel = 200;
            MaxWeight = 1000;
        }
    }
}