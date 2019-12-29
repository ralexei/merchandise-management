using System;
using System.Security.Cryptography;
using System.Text;

namespace MerchandiseManager.Utility.Crypto.Hashers
{
	public static class Md5Hasher
	{
		/// <summary>
		/// Generates a hash of a given string
		/// </summary>
		/// <param name="key">string to hash</param>
		/// <returns>MD5 hash of the given string</returns>
		public static string Generate(string key)
		{
			using (var md5Encryptor = MD5.Create())
			{
				return BitConverter.ToString(md5Encryptor.ComputeHash(Encoding.UTF8.GetBytes(key))).Replace("-", "");
			}
		}

		public static byte[] GenerateBytes(string key)
		{
			using (var md5Encryptor = MD5.Create())
			{
				return md5Encryptor.ComputeHash(Encoding.UTF8.GetBytes(key));
			}
		}

		/// <summary>
		/// Generate an input independent "random" hash, based on ticks
		/// </summary>
		/// <returns>random MD5 hash</returns>
		public static string Generate()
		{
			return Generate(DateTime.UtcNow.Ticks.ToString());
		}
	}
}
