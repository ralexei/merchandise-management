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
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products
{
	public class EditProductViewModel : BaseDialogViewModel
	{
		private readonly IProductsService productsService;
		private readonly ICategoriesService categoriesService;
		private readonly IDialogService dialogService;

		#region Public Properties
		public Guid Id { get; set; }
		
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }

		public decimal? RetailSellPrice { get; set; }
		public decimal? WholesaleSellPrice { get; set; }
		public decimal? BuyPrice { get; set; }

		public Guid? CategoryId { get; set; }

		public Category CurrentCategory { get; set; }
		public ObservableCollection<Category> Categories { get; set; }
		public ObservableCollection<string> Barcodes { get; set; } = new ObservableCollection<string>();
		#endregion

		#region Commands
		public ICommand AddBarcodeCommand { get; set; }
		public ICommand SaveProductCommand { get; set; }
		public ICommand OpenAddCategoryDialogCommand { get; set; }
		public ICommand CategorySelectedCommand { get; set; }
		#endregion

		public Product EditedProduct { get; set; }

		public EditProductViewModel(
			IProductsService productsService,
			ICategoriesService categoriesService,
			IDialogService dialogService)
		{
			AddBarcodeCommand = new RelayCommand(OpenBarcodeCreationDialog);
			SaveProductCommand = new RelayCommand(async () => await SaveProduct());
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

			dialogService.ShowDialog<ViewBarcodeDialog, ViewBarcodeViewModel>(Window, barcodeViewerViewModel);
		}

		public void InitProductData(Product product)
		{
			Id = product.Id;
			ProductName = product.ProductName;
			ProductDescription = product.ProductDescription;
			CategoryId = product.CategoryId; //TODO
			Barcodes = new ObservableCollection<string>(product.Barcodes);
			BuyPrice = product.BuyPrice;
			RetailSellPrice = product.RetailSellPrice;
			WholesaleSellPrice = product.WholesaleSellPrice;
		}

		/// <summary>
		/// Implementation for command of category selection
		/// </summary>
		/// <param name="selectedCategory"></param>
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

		/// <summary>
		/// Opens a dialog with form for category creation
		/// </summary>
		private void OpenAddCategoryDialog()
		{
			var dialog = dialogService.ShowDialog<AddCategoryDialogWindow, AddCategoryDialogViewModel>(Window);

			if (dialog.DialogResult == true)
				Categories.Add(dialog.ResultInfo.CreatedCategory);
		}

		/// <summary>
		/// Loads initial categories
		/// </summary>
		private async void LoadCategories()
		{
			Categories = new ObservableCollection<Category>((await categoriesService.GetCategories()).Data);

			if (Categories != null && CategoryId.HasValue)
			{
				CurrentCategory = FindSelectedCategory();

				//Categories[0].IsSelected = true;
				//Categories[0].IsExpanded = true;

				if (CurrentCategory != null)
				{
					CurrentCategory.IsExpanded = true;
					CurrentCategory.IsSelected = true;
				}
			}
		}

		/// <summary>
		/// POST request to the API to save product changes
		/// </summary>
		/// <returns></returns>
		private async Task SaveProduct()
		{
			try
			{
				EditedProduct = await productsService.EditProduct(this);

				Window.DialogResult = true;
			}
			catch (Exception ex)
			{ }
		}

		private Category FindSelectedCategory()
		{
			foreach (var category in Categories)
			{
				var foundCategory = FindRecursively(CategoryId.Value, category);

				if (foundCategory != null)
					return foundCategory;
			}

			return null;
		}

		private Category FindRecursively(Guid categoryId, Category root)
		{
			if (root.Id == categoryId)
				return root;

			foreach (var category in root.Children)
			{
				if (category.Id == categoryId)
					return category;
				else
				{
					category.IsExpanded = true;

					return FindRecursively(categoryId, category);
				}
			}

			return null;
		}
	}
}
