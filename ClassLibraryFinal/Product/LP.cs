using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.Product
{
    public abstract class Product : IProduct
    {
        public string Name { get; protected set; }
        public string ShortDescription { get; protected set; }
        public double Price { get; protected set; }
        public double ShippingWeight { get; protected set; }
        public double TaxRate { get; protected set; }
    }
}
