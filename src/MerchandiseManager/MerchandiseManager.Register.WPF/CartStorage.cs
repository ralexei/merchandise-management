using MerchandiseManager.Register.WPF.Models.Common;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Register.WPF
{
	public class CartStorage
	{
		private static readonly Lazy<CartStorage> lazy = new Lazy<CartStorage>(() => new CartStorage());

		public static CartStorage Instance { get { return lazy.Value; } }

		private Dictionary<Guid, CartProduct> CartProducts = new Dictionary<Guid, CartProduct>();

		public bool Empty
		{
			get => CartProducts.Count == 0;
		}

		private CartStorage()
		{
		}

		public void AddToCart(Product product)
		{
			if (CartProducts.ContainsKey(product.Id))
				CartProducts[product.Id].AddToAmount();
			else
				CartProducts[product.Id] = new CartProduct(product);
		}

		public void ClearCart()
			=> CartProducts.Clear();

		public List<CartProduct> GetCartProducts()
			=> 
			CartProducts.Values.ToList();

		public void RemoveFromCart(Guid productId)
		{
			if (CartProducts.ContainsKey(productId))
			{
				CartProducts[productId].DecreaseAmount();
		
				if (CartProducts[productId].Amount <= 0)
					CartProducts.Remove(productId);
			}
		}
	}
}
