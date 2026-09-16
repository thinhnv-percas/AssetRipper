using Cpp2ILInjected;

namespace UnityEngine.UDP.Analytics
{
	[Token(Token = "0x2000028")]
	public enum AnalyticsResult
	{
		[Token(Token = "0x400007E")]
		kOk = 0,
		[Token(Token = "0x400007F")]
		kError = 1,
		[Token(Token = "0x4000080")]
		kNotInitialized = 2,
		[Token(Token = "0x4000081")]
		kInvalidData = 3
	}
}
