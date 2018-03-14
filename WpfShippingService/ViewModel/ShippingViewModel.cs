using ClassLibraryFinal;
using ClassLibraryFinal.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfShippingService.Model;

namespace WpfShippingService.ViewModel
{
    class ShippingViewModel : BaseViewModel
    {
        #region Property and Fields
        /** Main Shipping Related */
        private IShippingService shippingService;

        /** Delivery Service Related */
        /* Provides Delivery Service through Ninject*/
        private IServiceProvider serviceProvider;
        public IDeliveryService DeliveryService => shippingService.DeliveryService;
        /* List of Delivery Service to Select from */
        private ObservableCollection<IDeliveryService> serviceList;
        public ObservableCollection<IDeliveryService> ServiceList { get => serviceList; set => serviceList = value; }
        private IDeliveryService serviceSelected;
        public IDeliveryService ServiceSelected
        {
            get => serviceSelected;
            set
            {
                if (serviceSelected != value)
                {
                    serviceSelected = value;
                    OnServiceSelectedChange();
                }
            }
        }
        public uint ShippingRate => shippingService.ShippingRate;

        /** Shipping Location Related */
        /* Only changed when */
        public uint StartZipCode => shippingService.ShippingLocation.StartZipCode;
        /* provided by user input */
        private uint destinationZipCode;
        public uint DestinationZipCode
        {
            get => destinationZipCode;
            set
            {
                if (destinationZipCode != value)
                {
                    destinationZipCode = value;
                    RaisePropertyChangedEvent();
                    OnDestinationChange();
                }
            }
        }
        /* Calculated Travel Distance: Invoked by destinationZipCode when it's changed */
        public uint ShippingDistance => shippingService.ShippingDistance;

        /** Product Related */
        /* available product */
        private ObservableCollection<IProduct> productList;
        public ObservableCollection<IProduct> ProductList => productList;
        private IProduct productSelected;
        public IProduct ProductSelected
        {
            get => productSelected;
            set
            {
                if (productSelected != value)
                {
                    productSelected = value;
                    RaisePropertyChangedEvent();
                }
            }
        }
        /* Products to buy */
        public ObservableCollection<IProduct> SelectedProducts => new ObservableCollection<IProduct>(shippingService.Products);
        public double ProductsWeight => shippingService.ProductsWeight;

        /** Properties for displaying price */
        public double ProductsCost => shippingService.ProductsCost;
        public double ShippingCost => shippingService.ShippingCost;
        public double TotalCost => ProductsCost + ShippingCost;

        /** Result of deliveries stored and displayed in ListView */
        private ObservableCollection<IShippingService> processedOrders;
        public ObservableCollection<IShippingService> ProcessedOrders => processedOrders;
        #endregion

        #region Commands for Event Handling
        public ICommand AddCommand { get; set; }
        public ICommand EmptyCommand { get; set; }
        public ICommand DestinationChangeCommand { get; set; }
        public ICommand DeliverCommand { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public ShippingViewModel()
        {
            // set default shipping service and its delivery service to UnclesTruck
            shippingService = (IShippingService)new ShippingServiceProvider().GetService(typeof(IShippingService));
            // Grabs service provider for ninjection
            serviceProvider = new DeliveryServiceProvider();
            // create list of selectable delivery service
            serviceList = new ObservableCollection<IDeliveryService>()
            {
                (IDeliveryService)serviceProvider.GetService(typeof(UnclesTruck)),
                (IDeliveryService)serviceProvider.GetService(typeof(AirExpress)),
                (IDeliveryService)serviceProvider.GetService(typeof(SnailService))
            };
            /** Field itialization */
            // starting zipcode always same:60605
            // set to 60805 from Initial
            DestinationZipCode = shippingService.ShippingLocation.DestinationZipCode;
            // list of produts available for purchase
            productList = new ObservableCollection<IProduct>()
            {
                new DSOTM(),
                new Rumors(),
                new SFTD(),
                new WhiteAlbum(),
                new Mystery()
            };
            processedOrders = new ObservableCollection<IShippingService>();

            /** Set Up Commands */
            AddCommand = new BasicCommand(OnAddClick);
            EmptyCommand = new BasicCommand(OnEmptyClick);
            DeliverCommand = new BasicCommand(OnDeliveryProcess);
        }

        #region Member Functions for Event Handling
        /// <summary>
        /// When Combo Box Selection Changes, get new Delivery Service
        /// </summary>
        protected void OnServiceSelectedChange()
        {
            shippingService.DeliveryService = getRequestedDeliveryService();
            RaisePropertyChangedEvent("ShippingRate");
            RaisePropertyChangedEvent("ShippingCost");
            RaisePropertyChangedEvent("DeliveryService");
            RaisePropertyChangedEvent("TotalCost");
        }
        protected IDeliveryService getRequestedDeliveryService()
        {
            return (IDeliveryService)serviceProvider.GetService(serviceSelected.GetType());
        }

        /// <summary>
        /// when new zip code is inserted, show the new distance calculated
        /// </summary>
        protected void OnDestinationChange()
        {
            shippingService.ChangeDestination(destinationZipCode);
            RaisePropertyChangedEvent("ShippingDistance");
            RaisePropertyChangedEvent("ShippingCost");
            RaisePropertyChangedEvent("TotalCost");
        }

        /// <summary>
        /// Members for changing the Products selected
        /// </summary>
        protected void OnAddClick()
        {
            var product = from p in ProductList
                          where p.Name == productSelected.Name
                          select p;
            shippingService.AddProduct(product.First());
            OnProductsChange();
        }
        protected void OnEmptyClick()
        {
            shippingService.EmptyProducts();
            OnProductsChange();
        }
        /// <summary>
        /// TODO: Mouse click to delete product from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnProductSelect(object sender, RoutedEventArgs e)
        {
            IProduct toDelete = ((sender as ListBox).SelectedItem as IProduct);
            var product = from p in ProductList
                          where p.Name == toDelete.Name
                          select p;
            shippingService.RemoveProduct(product.First());
            OnProductsChange();
        }
        /// <summary>
        /// Send all required Event Notice when Products change
        /// </summary>
        private void OnProductsChange()
        {
            RaisePropertyChangedEvent("SelectedProducts");
            RaisePropertyChangedEvent("ProductsCost");
            RaisePropertyChangedEvent("ProductsWeight");
            RaisePropertyChangedEvent("TotalCost");
        }
        protected void OnDeliveryProcess()
        {
            IShippingService processedOrder = new ProcessedOrder(shippingService);
            processedOrders.Add(processedOrder);
            RaisePropertyChangedEvent("ProcessedOrders");
            OnDestinationChange();
        }
        #endregion
    }


}
