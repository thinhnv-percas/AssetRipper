using Cpp2ILInjected;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x2000005")]
	public enum AllIn1ShaderPropertyType
	{
		[Token(Token = "0x4000009")]
		Color = 0,
		[Token(Token = "0x400000A")]
		Vector = 1,
		[Token(Token = "0x400000B")]
		Float = 2,
		[Token(Token = "0x400000C")]
		Range = 3,
		[Token(Token = "0x400000D")]
		Texture = 4,
		[Token(Token = "0x400000E")]
		Int = 5
	}
}
