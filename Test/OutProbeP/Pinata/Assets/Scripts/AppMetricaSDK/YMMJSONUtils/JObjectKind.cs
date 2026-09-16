using Cpp2ILInjected;

namespace YMMJSONUtils
{
	[Token(Token = "0x200001A")]
	public enum JObjectKind
	{
		[Token(Token = "0x400003E")]
		Object = 0,
		[Token(Token = "0x400003F")]
		Array = 1,
		[Token(Token = "0x4000040")]
		String = 2,
		[Token(Token = "0x4000041")]
		Number = 3,
		[Token(Token = "0x4000042")]
		Boolean = 4,
		[Token(Token = "0x4000043")]
		Null = 5
	}
}
