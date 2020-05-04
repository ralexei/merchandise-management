namespace MerchandiseManager.Application.Interfaces.Models.Filtering
{
	public interface IPaginatable
	{
		public int? Page { get; }
		public int? PageSize { get; }
	}
}
