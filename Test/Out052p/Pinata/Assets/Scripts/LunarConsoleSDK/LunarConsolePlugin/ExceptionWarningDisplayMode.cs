using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[Token(Token = "0x2000011")]
	public enum ExceptionWarningDisplayMode
	{
		[Token(Token = "0x4000027")]
		None = 0,
		[Token(Token = "0x4000028")]
		Errors = 1,
		[Token(Token = "0x4000029")]
		Exceptions = 2,
		[Token(Token = "0x400002A")]
		All = 3
	}
}
