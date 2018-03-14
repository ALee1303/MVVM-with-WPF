using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public interface IShippingService
    {
        IDeliveryService DeliveryService { get; set; }
        string DeliveryName { get; }
        IShippingLocation ShippingLocation { get; set; }
        List<IProduct> Products { get; }

        uint ShippingDistance { get; }
        uint NumRefuels { get; }
        uint ShippingRate { get; }
        double ProductsCost { get; }
        double ProductsWeight { get; }
        double ShippingCost { get; }

        void AddProduct(IProduct toAdd);
        void RemoveProduct(IProduct toRemove);
        void EmptyProducts();

        void ChangeDestination(uint newZip);
    }

}