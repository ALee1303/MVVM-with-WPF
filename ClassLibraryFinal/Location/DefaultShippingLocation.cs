using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal
{
    class DefaultShippingLocation : ShippingLocation
    {
        public DefaultShippingLocation()
        {
            this.StartZipCode = 60605;
            this.DestinationZipCode = 60805;
        }
    }
}
