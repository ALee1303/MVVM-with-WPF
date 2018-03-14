using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.Product
{
    public class WhiteAlbum : Product
    {
        public WhiteAlbum()
        {
            Name = "White Album(1968)";
            ShortDescription = "Working Condition";
            Price = 29.99;
            ShippingWeight = 10;
            TaxRate = 0.20;
        }
    }
}
