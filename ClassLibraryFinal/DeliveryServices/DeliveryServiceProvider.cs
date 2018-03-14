using ClassLibraryFinal.NinjectModules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal
{
    public class DeliveryServiceProvider : IServiceProvider
    {
        IKernel kernel;

        public DeliveryServiceProvider()
        {
            kernel = new StandardKernel(new DeliveryServiceModule());
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UnclesTruck))
                return kernel.Get<UnclesTruck>();
            else if (serviceType == typeof(AirExpress))
                return kernel.Get<AirExpress>();
            else if (serviceType == typeof(SnailService))
                return kernel.Get<SnailService>();
            else
                return null;
        }
    }
}
