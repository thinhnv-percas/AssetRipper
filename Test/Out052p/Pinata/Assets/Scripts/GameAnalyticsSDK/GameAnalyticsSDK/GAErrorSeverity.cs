using Cpp2ILInjected;

namespace GameAnalyticsSDK
{
	[Token(Token = "0x2000002")]
	public enum GAErrorSeverity
	{
		[Token(Token = "0x4000002")]
		Undefined = 0,
		[Token(Token = "0x4000003")]
		Debug = 1,
		[Token(Token = "0x4000004")]
		Info = 2,
		[Token(Token = "0x4000005")]
		Warning = 3,
		[Token(Token = "0x4000006")]
		Error = 4,
		[Token(Token = "0x4000007")]
		Critical = 5
	}
}
