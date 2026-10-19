using Cpp2ILInjected;

namespace Reflex.Enums
{
	[Token(Token = "0x2000032")]
	public enum Lifetime
	{
		[Token(Token = "0x4000042")]
		Singleton = 0,
		[Token(Token = "0x4000043")]
		Transient = 1,
		[Token(Token = "0x4000044")]
		Scoped = 2
	}
}
