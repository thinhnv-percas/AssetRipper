using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200001B")]
	public class TMP_Glyph : TMP_TextElement_Legacy
	{
		[Token(Token = "0x600018E")]
		[Address(RVA = "0x927DCC", Offset = "0x927DCC", Length = "0xB8")]
		public static TMP_Glyph Clone(TMP_Glyph source)
		{
			return null;
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0x927E84", Offset = "0x927E84", Length = "0x104")]
		public TMP_Glyph()
		{
		}
	}
}
