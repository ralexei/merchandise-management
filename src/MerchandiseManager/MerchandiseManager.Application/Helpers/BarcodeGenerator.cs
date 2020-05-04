namespace MerchandiseManager.Application.Helpers
{
	public static class BarcodeGenerator
	{
		public static string Generate(int categoryFId, int productFId, int userFId)
		{
			return "M" + userFId.ToString() + categoryFId.ToString("D4") + productFId.ToString("D4");
		}
	}
}
