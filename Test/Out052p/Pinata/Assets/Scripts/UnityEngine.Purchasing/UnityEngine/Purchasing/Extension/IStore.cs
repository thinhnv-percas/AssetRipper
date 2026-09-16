using System.Collections.ObjectModel;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000025")]
	public interface IStore
	{
		[Token(Token = "0x60000AD")]
		void Initialize(IStoreCallback callback);

		[Token(Token = "0x60000AE")]
		void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products);

		[Token(Token = "0x60000AF")]
		void Purchase(ProductDefinition product, string developerPayload);

		[Token(Token = "0x60000B0")]
		void FinishTransaction(ProductDefinition product, string transactionId);
	}
}
