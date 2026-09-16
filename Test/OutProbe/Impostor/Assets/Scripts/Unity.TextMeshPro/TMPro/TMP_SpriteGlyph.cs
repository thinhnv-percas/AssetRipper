using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000082")]
	public class TMP_SpriteGlyph : Glyph
	{
		[Token(Token = "0x4000435")]
		[FieldOffset(Offset = "0x48")]
		public Sprite sprite;

		[Token(Token = "0x6000439")]
		[Address(RVA = "0x160CC8C", Offset = "0x160CC8C", Length = "0x8")]
		public TMP_SpriteGlyph()
		{
		}

		[Token(Token = "0x600043A")]
		[Address(RVA = "0x160CFFC", Offset = "0x160CFFC", Length = "0xBC")]
		public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex)
		{
		}

		[Token(Token = "0x600043B")]
		[Address(RVA = "0x160D0B8", Offset = "0x160D0B8", Length = "0xC4")]
		public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex, Sprite sprite)
		{
		}
	}
}
