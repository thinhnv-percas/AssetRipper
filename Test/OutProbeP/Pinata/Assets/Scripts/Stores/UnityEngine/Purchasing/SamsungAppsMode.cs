using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200002F")]
	public enum SamsungAppsMode
	{
		[Token(Token = "0x4000090")]
		Production = 0,
		[Token(Token = "0x4000091")]
		AlwaysSucceed = 1,
		[Token(Token = "0x4000092")]
		AlwaysFail = 2
	}
}
