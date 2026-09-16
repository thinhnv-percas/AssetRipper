using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000011")]
	public interface IAmazonConfiguration : IStoreConfiguration
	{
		[Token(Token = "0x6000040")]
		void WriteSandboxJSON(HashSet<ProductDefinition> products);
	}
}
