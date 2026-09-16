using System;
using Cpp2ILInjected;
using UnityEngine.TextCore;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200000D")]
	public class TMP_Character : TMP_TextElement
	{
		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x91C1E8", Offset = "0x91C1E8", Length = "0x34")]
		public TMP_Character()
		{
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x91C21C", Offset = "0x91C21C", Length = "0x64")]
		public TMP_Character(uint unicode, Glyph glyph)
		{
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x91C280", Offset = "0x91C280", Length = "0x4C")]
		internal TMP_Character(uint unicode, uint glyphIndex)
		{
		}
	}
}
