using System;
using Cpp2ILInjected;
using UnityEngine.TextCore;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000023")]
	public class TMP_Character : TMP_TextElement
	{
		[Token(Token = "0x6000121")]
		[Address(RVA = "0x15CFF0C", Offset = "0x15CFF0C", Length = "0x28")]
		public TMP_Character()
		{
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0x15CFF34", Offset = "0x15CFF34", Length = "0x54")]
		public TMP_Character(uint unicode, Glyph glyph)
		{
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0x15CFF88", Offset = "0x15CFF88", Length = "0x60")]
		public TMP_Character(uint unicode, TMP_FontAsset fontAsset, Glyph glyph)
		{
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0x15CFFE8", Offset = "0x15CFFE8", Length = "0x40")]
		internal TMP_Character(uint unicode, uint glyphIndex)
		{
		}
	}
}
