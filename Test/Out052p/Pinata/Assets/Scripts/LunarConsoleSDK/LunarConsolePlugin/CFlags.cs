using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[Token(Token = "0x2000006")]
	public enum CFlags
	{
		[Token(Token = "0x400000D")]
		None = 0,
		[Token(Token = "0x400000E")]
		Hidden = 2,
		[Token(Token = "0x400000F")]
		NoArchive = 4
	}
}
