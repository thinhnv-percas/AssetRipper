using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000023")]
	public interface IPurchasingBinder
	{
		[Token(Token = "0x60000A7")]
		void RegisterStore(string name, IStore a);

		[Token(Token = "0x60000A8")]
		void RegisterExtension<T>(T instance) where T : IStoreExtension;

		[Token(Token = "0x60000A9")]
		void RegisterConfiguration<T>(T instance) where T : IStoreConfiguration;

		[Token(Token = "0x60000AA")]
		void SetCatalogProvider(ICatalogProvider provider);

		[Token(Token = "0x60000AB")]
		void SetCatalogProviderFunction(Action<Action<HashSet<ProductDefinition>>> func);
	}
}
