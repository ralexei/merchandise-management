using MerchandiseManager.Administrator.WPF.Models.Enums;
using MerchandiseManager.Administrator.WPF.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace MerchandiseManager.Administrator.WPF.ValueConverters
{
	public class AddEditDialogPageValueConverter : BaseValueConverter<AddEditDialogPageValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch((ApplicationPagesEnum)value)
			{

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
