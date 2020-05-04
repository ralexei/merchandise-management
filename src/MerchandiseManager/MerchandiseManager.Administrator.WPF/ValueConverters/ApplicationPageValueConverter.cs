using MerchandiseManager.Administrator.WPF.Models.Enums;
using MerchandiseManager.Administrator.WPF.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace MerchandiseManager.Administrator.WPF.ValueConverters
{
	public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch((ApplicationPagesEnum)value)
			{

				case ApplicationPagesEnum.Home:
					return new HomePage();
				case ApplicationPagesEnum.Storages:
					return new StoragesPage();
				case ApplicationPagesEnum.Products:
					return new ProductsPage();
				case ApplicationPagesEnum.ProductDeliveryNotes:
					return new DeliveryNotesListPage();
				default:
					Debugger.Break();
					return null;
			}
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
