using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class SnailService : DeliveryService
    {
        public SnailService(IShippingVehicle vehicle) : base(vehicle)
        {
            name = "Snail Service";
            costPerRefuel = 2;
            this.shippingRate = 0.0;
        }
    }
}