using FontAwesome5;
using MerchandiseManager.Administrator.WPF.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF
{
	public class MenuStorage
	{
		public static MenuItem Menu =
			new MenuItem("Администрация", EFontAwesomeIcon.Solid_UserTie, new List<MenuItem>
			{
				new MenuItem("Главная", EFontAwesomeIcon.Solid_Home).AssociatePage(ApplicationPagesEnum.Home),
				new MenuItem("Товары", EFontAwesomeIcon.Solid_Boxes).AssociatePage(ApplicationPagesEnum.Products),
				new MenuItem("Склады", EFontAwesomeIcon.Solid_Warehouse).AssociatePage(ApplicationPagesEnum.Storages),
				new MenuItem("Накладные", EFontAwesomeIcon.Regular_Folder, new List<MenuItem>
				{
					new MenuItem("Товарные накладные", EFontAwesomeIcon.Regular_FileAlt).AssociatePage(ApplicationPagesEnum.ProductDeliveryNotes)
				}).AssociatePage(ApplicationPagesEnum.ProductDeliveryNotes)
			}).AssociatePage(ApplicationPagesEnum.Home);
	}
}