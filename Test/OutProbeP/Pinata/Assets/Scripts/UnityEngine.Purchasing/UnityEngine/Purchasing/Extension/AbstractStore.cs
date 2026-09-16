using System.Collections.ObjectModel;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000021")]
	public abstract class AbstractStore : IStore
	{
		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x160E094", Offset = "0x160E094", Length = "0x8")]
		protected AbstractStore()
		{
		}

		[Token(Token = "0x60000A2")]
		public abstract void Initialize(IStoreCallback callback);

		[Token(Token = "0x60000A3")]
		public abstract void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products);

		[Token(Token = "0x60000A4")]
		public abstract void Purchase(ProductDefinition product, string developerPayload);

		[Token(Token = "0x60000A5")]
		public abstract void FinishTransaction(ProductDefinition product, string transactionId);
	}
}
