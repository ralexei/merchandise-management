using MerchandiseManager.Administrator.WPF.Interfaces;
using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Interfaces.Utils;
using MerchandiseManager.Administrator.WPF.Services;
using MerchandiseManager.Administrator.WPF.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Utils;
using MerchandiseManager.Administrator.WPF.ViewModels;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Storages;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MerchandiseManager.Administrator.WPF.DI
{
	public static class IoC
	{
		/// <summary>
		/// The Kernel of the IoC
		/// </summary>
		public static IKernel Kernel { get; private set; } = new StandardKernel();

		public static T Get<T>()
		{
			return Kernel.Get<T>();
		}

		public static void Setup()
		{
			BindViewModels();
			BindServices();
		}

		private static void BindServices()
		{
			Kernel.Bind<IDialogService>().To<DialogService>().InTransientScope();
			Kernel.Bind<IApiConnector>().To<ApiConnector>().InTransientScope();
			Kernel.Bind<IAuthService>().To<AuthService>().InTransientScope();
			Kernel.Bind<IStoragesService>().To<StoragesService>().InTransientScope();
			Kernel.Bind<IProductsService>().To<ProductsService>().InTransientScope();
			Kernel.Bind<ICategoriesService>().To<CategoriesService>().InTransientScope();
		}

		private static void BindViewModels()
		{
			// Window ViewModels
			Kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();

			// Pages ViewModels
			Kernel.Bind<HomePageViewModel>().ToSelf().InTransientScope();
			Kernel.Bind<StoragesPageViewModel>().ToSelf().InTransientScope();
			Kernel.Bind<ProductsPageViewModel>().ToSelf().InTransientScope();

			// Dialog pages ViewModels
			Kernel.Bind<AddStorageDialogViewModel>().ToSelf().InTransientScope();
			Kernel.Bind<AddProductDialogViewModel>().ToSelf().InTransientScope();
			Kernel.Bind<EditProductViewModel>().ToSelf().InTransientScope();
			Kernel.Bind<AddCategoryDialogViewModel>().ToSelf().InTransientScope();
			Kernel.Bind<AddBarcodeDialogViewModel>().ToSelf().InTransientScope();
		}
	}
}
