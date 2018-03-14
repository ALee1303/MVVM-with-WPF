using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public abstract class DeliveryService : IDeliveryService
    {
        protected string name;
        public string Name => name;

        protected double costPerRefuel;
        public double CostPerRefuel { get => costPerRefuel; protected set => costPerRefuel = value; }
        // to be multiplied to weight at ShippingService
        protected double shippingRate;
        public double ShippingRate => shippingRate;

        protected IShippingVehicle shippingVehicle;
        public IShippingVehicle ShippingVehicle { get => shippingVehicle; protected set => shippingVehicle = value; }


        public DeliveryService(IShippingVehicle vehicle)
        {
            this.shippingVehicle = vehicle;
        }
    }
}