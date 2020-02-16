using MerchandiseManager.Administrator.WPF.Dialogs.Products;
using MerchandiseManager.Administrator.WPF.Interfaces;
using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Products;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class ProductsPageViewModel : BaseDialogViewModel
	{
		public ObservableCollection<Product> Products { get; set; }

		private readonly IProductsService productsService;
		private readonly IDialogService dialogService;

		public ICommand PageLoadedCommand { get; set; }
		public ICommand AddProductCommand { get; set; }

		public ProductsPageViewModel(IProductsService productsService, IDialogService dialogService)
		{
			this.productsService = productsService;
			this.dialogService = dialogService;

			AddProductCommand = new RelayCommand(OpenProductCreationDialog);
			//PageLoadedCommand = new RelayCommand(async () => await PageLoaded());

			LoadData();
		}

		private void OpenProductCreationDialog()
		{
			var result = dialogService.ShowDialog<AddProductDialogWindow, AddProductDialogViewModel>();

			if (result.DialogResult == true)
				Products.Add(result.ResultInfo.CreatedProduct);
		}

		private async void LoadData()
		{
			Products = new ObservableCollection<Product>((await productsService.GetProducts()).Data);
		}
	}
}
