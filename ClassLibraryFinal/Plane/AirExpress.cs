using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class AirExpress : DeliveryService
    {
        public AirExpress(IShippingVehicle vehicle) : base(vehicle)
        {
            name = "Air Express";
            costPerRefuel = 2000;
            shippingRate = .15;
        }
    }
}