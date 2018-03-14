using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public interface IDeliveryService
    {
        string Name { get; }
        double CostPerRefuel { get; }
        double ShippingRate { get; }
        IShippingVehicle ShippingVehicle { get; }
    }
}