using Cpp2ILInjected;

namespace GameAnalyticsSDK
{
	[Token(Token = "0x2000003")]
	public enum GAProgressionStatus
	{
		[Token(Token = "0x4000009")]
		Undefined = 0,
		[Token(Token = "0x400000A")]
		Start = 1,
		[Token(Token = "0x400000B")]
		Complete = 2,
		[Token(Token = "0x400000C")]
		Fail = 3
	}
}
