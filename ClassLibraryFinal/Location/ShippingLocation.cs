using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal
{
    abstract class ShippingLocation : IShippingLocation
    {
        /** Newly spawned when changed */
        public uint StartZipCode { get; protected set; }

        public uint DestinationZipCode { get; set; }
    }
}
