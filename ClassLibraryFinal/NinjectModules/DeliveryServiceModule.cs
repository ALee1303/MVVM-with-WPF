using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.NinjectModules
{
    class DeliveryServiceModule : NinjectModule
    {
        public DeliveryServiceModule()
        { }

        public override void Load()
        {
            this.Bind<IShippingVehicle>().To<Truck>().WhenInjectedInto<UnclesTruck>().InSingletonScope();
            this.Bind<IShippingVehicle>().To<Plane>().WhenInjectedInto<AirExpress>().InSingletonScope();
            this.Bind<IShippingVehicle>().To<ShippingSnail>().WhenInjectedInto<SnailService>().InSingletonScope();
        }
    }
}
