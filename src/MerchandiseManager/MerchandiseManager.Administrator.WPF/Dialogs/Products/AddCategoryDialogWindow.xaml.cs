﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MerchandiseManager.Administrator.WPF.Dialogs.Products
{
	/// <summary>
	/// Interaction logic for AddCategoryDialogWindow.xaml
	/// </summary>
	public partial class AddCategoryDialogWindow : Window
	{
		public AddCategoryDialogWindow()
		{
			InitializeComponent();
		}

		private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{

		}
	}
}
