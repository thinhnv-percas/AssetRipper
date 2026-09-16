using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000017")]
	public enum ValidateReceiptState
	{
		[Token(Token = "0x400001F")]
		ValidateSucceed = 0,
		[Token(Token = "0x4000020")]
		ValidateFailed = 1,
		[Token(Token = "0x4000021")]
		NotKnown = 2
	}
}
