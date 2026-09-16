using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000015")]
	public enum CloudMoolahMode
	{
		[Token(Token = "0x400001B")]
		Production = 0,
		[Token(Token = "0x400001C")]
		AlwaysSucceed = 1,
		[Token(Token = "0x400001D")]
		AlwaysFailed = 2
	}
}
