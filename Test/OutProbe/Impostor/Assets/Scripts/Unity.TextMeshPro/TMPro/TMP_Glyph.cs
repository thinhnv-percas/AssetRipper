using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000041")]
	public class TMP_Glyph : TMP_TextElement_Legacy
	{
		[Token(Token = "0x6000239")]
		[Address(RVA = "0x15DE5B4", Offset = "0x15DE5B4", Length = "0x7C")]
		public static TMP_Glyph Clone(TMP_Glyph source)
		{
			return null;
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0x15DE630", Offset = "0x15DE630", Length = "0x8")]
		public TMP_Glyph()
		{
		}
	}
}
