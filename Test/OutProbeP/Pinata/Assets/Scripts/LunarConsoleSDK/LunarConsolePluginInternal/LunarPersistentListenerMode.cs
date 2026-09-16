using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000021")]
	public enum LunarPersistentListenerMode
	{
		[Token(Token = "0x4000063")]
		Void = 0,
		[Token(Token = "0x4000064")]
		Bool = 1,
		[Token(Token = "0x4000065")]
		Int = 2,
		[Token(Token = "0x4000066")]
		Float = 3,
		[Token(Token = "0x4000067")]
		String = 4,
		[Token(Token = "0x4000068")]
		Object = 5
	}
}
