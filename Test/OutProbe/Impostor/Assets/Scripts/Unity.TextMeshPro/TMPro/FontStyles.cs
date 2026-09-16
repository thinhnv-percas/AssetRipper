using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Flags]
	[Token(Token = "0x2000091")]
	public enum FontStyles
	{
		[Token(Token = "0x40004AB")]
		Normal = 0,
		[Token(Token = "0x40004AC")]
		Bold = 1,
		[Token(Token = "0x40004AD")]
		Italic = 2,
		[Token(Token = "0x40004AE")]
		Underline = 4,
		[Token(Token = "0x40004AF")]
		LowerCase = 8,
		[Token(Token = "0x40004B0")]
		UpperCase = 0x10,
		[Token(Token = "0x40004B1")]
		SmallCaps = 0x20,
		[Token(Token = "0x40004B2")]
		Strikethrough = 0x40,
		[Token(Token = "0x40004B3")]
		Superscript = 0x80,
		[Token(Token = "0x40004B4")]
		Subscript = 0x100,
		[Token(Token = "0x40004B5")]
		Highlight = 0x200
	}
}
