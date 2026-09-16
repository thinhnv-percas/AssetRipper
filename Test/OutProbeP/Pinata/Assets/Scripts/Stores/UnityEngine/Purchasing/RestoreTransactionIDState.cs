using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000018")]
	public enum RestoreTransactionIDState
	{
		[Token(Token = "0x4000023")]
		NoTransactionRestore = 0,
		[Token(Token = "0x4000024")]
		RestoreSucceed = 1,
		[Token(Token = "0x4000025")]
		RestoreFailed = 2,
		[Token(Token = "0x4000026")]
		NotKnown = 3
	}
}
