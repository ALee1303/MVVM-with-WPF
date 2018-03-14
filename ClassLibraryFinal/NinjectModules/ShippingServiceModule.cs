using Moq;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.NinjectModules
{
    public class ShippingServiceModule : NinjectModule
    {
       
        public ShippingServiceModule()
        {
            
        }

        public override void Load()
        {
            this.Bind<IShippingService>().To<DefaultShippingService>();
            this.Bind<IDeliveryService>().To<UnclesTruck>().WhenInjectedInto<DefaultShippingService>();
            this.Bind<IShippingVehicle>().To<Truck>().WhenInjectedInto<UnclesTruck>().InSingletonScope();
            this.Bind<IShippingLocation>().To<DefaultShippingLocation>().WhenInjectedInto<DefaultShippingService>().InSingletonScope();
        }
    }
}
