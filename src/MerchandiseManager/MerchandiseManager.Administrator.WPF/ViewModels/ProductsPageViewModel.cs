﻿using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.Dialogs.Products;
using MerchandiseManager.Administrator.WPF.Interfaces;
using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Products;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class ProductsPageViewModel : BaseDialogViewModel
	{
		public ObservableCollection<Product> Products { get; set; }
		public ProductsSearchModel SearchModel { get; set; }


		private readonly IProductsService productsService;
		private readonly IDialogService dialogService;


		public ICommand SearchCommand { get; set; }
		public ICommand AddProductCommand { get; set; }
		public ICommand OpenProductForEditCommand { get; set; }

		public ProductsPageViewModel(IProductsService productsService, IDialogService dialogService)
		{
			this.productsService = productsService;
			this.dialogService = dialogService;

			SearchModel = new ProductsSearchModel()
			{
				ProductNameContains = ""
			};
			AddProductCommand = new RelayCommand(OpenProductCreationDialog);
			OpenProductForEditCommand = new RelayParameterizedCommand((product) => EditProduct(product as Product));
			SearchCommand = new RelayCommand(Search);

			LoadData();
		}

		private void Search()
		{
			LoadData();
		}

		public void EditProduct(Product product)
		{
			try
			{
				if (product != null)
				{
					var vm = IoC.Get<EditProductViewModel>();

					vm.InitProductData(product);

					var editDialog = dialogService.ShowDialog<ViewProductDialogWindow, EditProductViewModel>(Application.Current.MainWindow, vm);

					if (editDialog.DialogResult == true)
					{
						//Products.Add(editDialog.ResultInfo.EditedProduct);
					}
				}
			}
			catch { }
		}

		private void OpenProductCreationDialog()
		{
			var result = dialogService.ShowDialog<AddProductDialogWindow, AddProductDialogViewModel>();

			if (result.DialogResult == true)
				Products.Add(result.ResultInfo.CreatedProduct);
		}

		private async void LoadData()
		{
			Products = new ObservableCollection<Product>((await productsService.GetProducts(SearchModel)).Data);
		}
	}
}
