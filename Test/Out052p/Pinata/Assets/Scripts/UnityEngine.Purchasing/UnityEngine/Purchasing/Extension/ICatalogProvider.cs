using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000022")]
	public interface ICatalogProvider
	{
		[Token(Token = "0x60000A6")]
		void FetchProducts(Action<HashSet<ProductDefinition>> callback);
	}
}
