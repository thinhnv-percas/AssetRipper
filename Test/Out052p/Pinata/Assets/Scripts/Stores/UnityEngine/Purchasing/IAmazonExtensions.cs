using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000012")]
	public interface IAmazonExtensions : IStoreExtension
	{
		[Token(Token = "0x17000010")]
		string amazonUserId
		{
			[Token(Token = "0x6000041")]
			get;
		}
	}
}
