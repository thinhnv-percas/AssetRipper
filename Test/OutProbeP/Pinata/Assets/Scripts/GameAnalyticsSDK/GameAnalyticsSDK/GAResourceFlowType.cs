using Cpp2ILInjected;

namespace GameAnalyticsSDK
{
	[Token(Token = "0x2000004")]
	public enum GAResourceFlowType
	{
		[Token(Token = "0x400000E")]
		Undefined = 0,
		[Token(Token = "0x400000F")]
		Source = 1,
		[Token(Token = "0x4000010")]
		Sink = 2
	}
}
