using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000012")]
	public enum AdjustLogLevel
	{
		[Token(Token = "0x400005F")]
		Verbose = 1,
		[Token(Token = "0x4000060")]
		Debug = 2,
		[Token(Token = "0x4000061")]
		Info = 3,
		[Token(Token = "0x4000062")]
		Warn = 4,
		[Token(Token = "0x4000063")]
		Error = 5,
		[Token(Token = "0x4000064")]
		Assert = 6,
		[Token(Token = "0x4000065")]
		Suppress = 7
	}
}
