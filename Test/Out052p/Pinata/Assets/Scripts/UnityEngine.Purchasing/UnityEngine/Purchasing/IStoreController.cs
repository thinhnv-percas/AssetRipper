using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000007")]
	public interface IStoreController
	{
		[Token(Token = "0x17000004")]
		ProductCollection products
		{
			[Token(Token = "0x6000017")]
			get;
		}

		[Token(Token = "0x6000018")]
		void InitiatePurchase(Product product, string payload);

		[Token(Token = "0x6000019")]
		void InitiatePurchase(Product product);

		[Token(Token = "0x600001A")]
		void InitiatePurchase(string productId);
	}
}
