using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000087")]
	public interface ITizenStoreConfiguration : IStoreConfiguration
	{
		[Token(Token = "0x6000230")]
		void SetGroupId(string group);
	}
}
