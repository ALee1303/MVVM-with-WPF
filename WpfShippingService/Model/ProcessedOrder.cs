using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFinal;

namespace WpfShippingService.Model
{
    internal class ProcessedOrder : DefaultShippingService
    {
        public ProcessedOrder(IDeliveryService Service, List<IProduct> Products, IShippingLocation Location) 
            : base(Service, Products, Location)
        {
            this.DeliveryService = Service;
            this.Products = Products;
            this.ShippingLocation = Location;
        }
        public ProcessedOrder(IShippingService order)
            : this(order.DeliveryService, order.Products, order.ShippingLocation)
        { }
    }
}
