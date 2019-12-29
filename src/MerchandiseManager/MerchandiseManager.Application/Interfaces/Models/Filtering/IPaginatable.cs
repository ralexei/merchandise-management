namespace MerchandiseManager.Application.Interfaces.Models.Filtering
{
	public interface IPaginatable
	{
		public int? Start { get; }
		public int? Limit { get; }
	}
}
