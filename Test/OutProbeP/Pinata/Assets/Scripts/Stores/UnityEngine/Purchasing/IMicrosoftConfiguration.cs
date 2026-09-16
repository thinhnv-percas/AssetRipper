using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000083")]
	public interface IMicrosoftConfiguration : IStoreConfiguration
	{
		[Token(Token = "0x17000058")]
		bool useMockBillingSystem
		{
			[Token(Token = "0x6000221")]
			set;
		}
	}
}
