using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200002C")]
	public interface ISamsungAppsConfiguration : IStoreConfiguration
	{
		[Token(Token = "0x60000A6")]
		void SetMode(SamsungAppsMode mode);
	}
}
