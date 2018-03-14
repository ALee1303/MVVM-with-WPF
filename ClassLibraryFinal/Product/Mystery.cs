using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.Product
{
    public class Mystery : Product
    {
        public Mystery()
        {
            Name = "Mystery Bundle";
            ShortDescription = "5 random LP";
            Price = 9.99;
            ShippingWeight = 50;
            TaxRate = 0.20;
        }
    }
}
