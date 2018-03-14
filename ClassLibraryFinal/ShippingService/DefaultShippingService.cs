using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class DefaultShippingService : IShippingService
    {
        #region Fields
        public IDeliveryService DeliveryService { get; set; }
        public string DeliveryName => DeliveryService.Name;
        public IShippingLocation ShippingLocation { get; set; }
        public List<IProduct> Products { get; protected set; }
        /// percentage added per weight
        #endregion

        #region Getter Property
        public uint ShippingDistance => getShippingDistance();
        public uint NumRefuels => getNumRefuels();
        /// returns shipping rate as percentage for display
        public uint ShippingRate => (uint)DeliveryService.ShippingRate * 100;
        public double ProductsCost => getProductsCost();
        public double ProductsWeight => getProductsWeight();
        public double ShippingCost => getShippingCost();
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Service"></param>
        /// <param name="Products"></param>
        /// <param name="Location"></param>
        public DefaultShippingService(IDeliveryService Service, List<IProduct> Products, IShippingLocation Location)
        {
            this.ShippingLocation = Location;
            this.DeliveryService = Service;
            this.Products = Products;
        }

        #region Members for Products List
        public void AddProduct(IProduct toAdd)
        {
            Products.Add(toAdd);
        }
        public void RemoveProduct(IProduct toRemove)
        {
            Products.Remove(toRemove);
        }
        public void EmptyProducts()
        {
            Products.Clear();
        }
        #endregion

        #region Public Members
        public void ChangeDestination(uint newZip)
        {
            ShippingLocation.DestinationZipCode = newZip;
        }
        #endregion

        #region Private Members for Property
        private uint getShippingDistance()
        {
            //terrible way to determine distance insn't real (TODO: Fix to real calculation)
            return (uint)Math.Abs((int)this.ShippingLocation.DestinationZipCode - this.ShippingLocation.StartZipCode);
        }
        private uint getNumRefuels()
        {
            return ShippingDistance / this.DeliveryService.ShippingVehicle.MaxDistancePerRefuel;
        }
        private double getProductsCost()
        {
            return Products.Sum(product => product.Price + (product.Price * product.TaxRate));
        }
        private double getProductsWeight()
        {
            return Products.Sum(product => product.ShippingWeight);
        }
        private double getShippingCost()
        {
            double measuredCost = NumRefuels * DeliveryService.CostPerRefuel + ProductsWeight * DeliveryService.ShippingRate;
            // more money if too heavy
            if (ProductsWeight > DeliveryService.ShippingVehicle.MaxWeight)
                measuredCost += (ProductsWeight * DeliveryService.ShippingRate);
            return measuredCost;
        }
        #endregion
    }
}