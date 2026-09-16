using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x200000A")]
	public enum LogLevel
	{
		[Token(Token = "0x4000015")]
		Verbose = 0,
		[Token(Token = "0x4000016")]
		Debug = 1,
		[Token(Token = "0x4000017")]
		Info = 2,
		[Token(Token = "0x4000018")]
		Warning = 3,
		[Token(Token = "0x4000019")]
		Error = 4,
		[Token(Token = "0x400001A")]
		Assert = 5
	}
}
