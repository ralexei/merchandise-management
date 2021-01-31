using MerchandiseManager.Register.WPF.Models.Common;
using MerchandiseManager.Register.WPF.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace MerchandiseManager.Register.WPF.Utils.ValueConverters
{
	public class StoragesListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var storages = (List<StorageViewModel>)value;
			var storagesNames = storages
				.Select(s => s.StorageType == StorageTypes.Store ? s.Name : "Склад")
				.Distinct();

			return string.Join(", ", storagesNames.ToArray());
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return new List<StorageViewModel>();
		}
	}
}
