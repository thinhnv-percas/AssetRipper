using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000050")]
	public enum FontStyles
	{
		[Token(Token = "0x40002E4")]
		Normal = 0,
		[Token(Token = "0x40002E5")]
		Bold = 1,
		[Token(Token = "0x40002E6")]
		Italic = 2,
		[Token(Token = "0x40002E7")]
		Underline = 4,
		[Token(Token = "0x40002E8")]
		LowerCase = 8,
		[Token(Token = "0x40002E9")]
		UpperCase = 0x10,
		[Token(Token = "0x40002EA")]
		SmallCaps = 0x20,
		[Token(Token = "0x40002EB")]
		Strikethrough = 0x40,
		[Token(Token = "0x40002EC")]
		Superscript = 0x80,
		[Token(Token = "0x40002ED")]
		Subscript = 0x100,
		[Token(Token = "0x40002EE")]
		Highlight = 0x200
	}
}
