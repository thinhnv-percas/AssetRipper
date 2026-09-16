using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[Token(Token = "0x2000003")]
	public enum CVarType
	{
		[Token(Token = "0x4000002")]
		Boolean = 0,
		[Token(Token = "0x4000003")]
		Integer = 1,
		[Token(Token = "0x4000004")]
		Float = 2,
		[Token(Token = "0x4000005")]
		String = 3
	}
}
