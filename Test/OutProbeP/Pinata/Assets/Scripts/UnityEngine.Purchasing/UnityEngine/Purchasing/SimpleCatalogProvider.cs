using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000019")]
	internal class SimpleCatalogProvider : ICatalogProvider
	{
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x10")]
		private Action<Action<HashSet<ProductDefinition>>> m_Func;

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x160F1D8", Offset = "0x160F1D8", Length = "0x2C")]
		internal SimpleCatalogProvider(Action<Action<HashSet<ProductDefinition>>> func)
		{
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x1610BAC", Offset = "0x1610BAC", Length = "0x74")]
		public void FetchProducts(Action<HashSet<ProductDefinition>> callback)
		{
		}
	}
}
