using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Models
{
	public class DialogWindowResult<T> where T : BaseDialogViewModel
	{
		public bool? DialogResult { get; set; }
		public T ResultInfo { get; set; }
	}
}
