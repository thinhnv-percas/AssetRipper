using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000016")]
	public interface IMoolahConfiguration : IStoreConfiguration
	{
		[Token(Token = "0x17000013")]
		string appKey
		{
			[Token(Token = "0x6000048")]
			set;
		}

		[Token(Token = "0x17000014")]
		string hashKey
		{
			[Token(Token = "0x6000049")]
			set;
		}

		[Token(Token = "0x600004A")]
		void SetMode(CloudMoolahMode mode);
	}
}
