using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.Dialogs;
using MerchandiseManager.Administrator.WPF.Dialogs.Products;
using MerchandiseManager.Administrator.WPF.Interfaces;
using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Categories;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Products;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products
{
	public class AddProductDialogViewModel : BaseDialogViewModel
	{
		private readonly IProductsService productsService;
		private readonly ICategoriesService categoriesService;
		private readonly IDialogService dialogService;

		public string ProductName { get; set; }
		public string ProductDescription { get; set; }

		public decimal? RetailSellPrice { get; set; }
		public decimal? WholesaleSellPrice { get; set; }
		public decimal? BuyPrice { get; set; }
		
		public Guid? CategoryId { get; set; }

		public ObservableCollection<Category> Categories { get; set; }
		public ObservableCollection<string> Barcodes { get; set; } = new ObservableCollection<string>();

		public ICommand AddBarcodeCommand { get; set; }
		public ICommand CreateProductCommand { get; set; }
		public ICommand OpenAddCategoryDialogCommand { get; set; }
		public ICommand CategorySelectedCommand { get; set; }

		public Product CreatedProduct { get; set; }

		public AddProductDialogViewModel(
			IProductsService productsService,
			ICategoriesService categoriesService,
			IDialogService dialogService)
		{
			AddBarcodeCommand = new RelayCommand(OpenBarcodeCreationDialog);
			CreateProductCommand = new RelayCommand(async () => await CreateProduct());
			OpenAddCategoryDialogCommand = new RelayCommand(OpenAddCategoryDialog);
			CategorySelectedCommand = new RelayParameterizedCommand((selectedCategory) => SelectCategory(selectedCategory));

			this.productsService = productsService;
			this.categoriesService = categoriesService;
			this.dialogService = dialogService;

			LoadCategories();
		}

		public void DeleteBarcode(string barcode)
		{
			var barcodeToRemove = Barcodes.First(f => f == barcode);

			Barcodes.Remove(barcodeToRemove);
		}

		public void ViewBarcode(string rawBarcode)
		{
			var barcodeViewerViewModel = IoC.Get<ViewBarcodeViewModel>();

			barcodeViewerViewModel.RawBarcode = rawBarcode;

			var dialog = dialogService.ShowDialog<ViewBarcodeDialog, ViewBarcodeViewModel>(Window, barcodeViewerViewModel);
		}

		private void SelectCategory(object selectedCategory)
		{
			CategoryId = ((Category)selectedCategory).Id;
		}

		private void OpenBarcodeCreationDialog()
		{
			var addBarcodeDialog = dialogService.ShowDialog<AddBarcodeDialog, AddBarcodeDialogViewModel>(Window);

			if (addBarcodeDialog.DialogResult == true)
				Barcodes.Add(addBarcodeDialog.ResultInfo.RawBarcode);
		}

		private void OpenAddCategoryDialog()
		{
			var dialog = dialogService.ShowDialog<AddCategoryDialogWindow, AddCategoryDialogViewModel>(Window);

			if (dialog.DialogResult == true)
				Categories.Add(dialog.ResultInfo.CreatedCategory);
		}

		private async void LoadCategories()
		{
			Categories = new ObservableCollection<Category>((await categoriesService.GetCategories()).Data);
		}

		private async Task CreateProduct()
		{
			try
			{
				CreatedProduct = await productsService.CreateProduct(this);

				Window.DialogResult = true;
			}
			catch (Exception ex)
			{ }
		}
	}
}
