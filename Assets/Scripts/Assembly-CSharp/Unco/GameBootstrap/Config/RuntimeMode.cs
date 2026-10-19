using Cpp2ILInjected;

namespace Unco.GameBootstrap.Config
{
	[Token(Token = "0x20007E6")]
	public enum RuntimeMode
	{
		[Token(Token = "0x4001A68")]
		FastPlay = 0,
		[Token(Token = "0x4001A69")]
		Development = 1,
		[Token(Token = "0x4001A6A")]
		Production = 2
	}
}
