using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000041")]
	public class TMP_SpriteGlyph : Glyph
	{
		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0x40")]
		public Sprite sprite;

		[Token(Token = "0x600034A")]
		[Address(RVA = "0x93DC94", Offset = "0x93DC94", Length = "0x8")]
		public TMP_SpriteGlyph()
		{
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0x93DF10", Offset = "0x93DF10", Length = "0xC0")]
		public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex)
		{
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0x93DFD0", Offset = "0x93DFD0", Length = "0xD0")]
		public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex, Sprite sprite)
		{
		}
	}
}
