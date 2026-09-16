using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000046")]
	public class KerningPair
	{
		[FormerlySerializedAs("AscII_Left")]
		[SerializeField]
		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x10")]
		private uint m_FirstGlyph;

		[SerializeField]
		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0x14")]
		private GlyphValueRecord_Legacy m_FirstGlyphAdjustments;

		[FormerlySerializedAs("AscII_Right")]
		[SerializeField]
		[Token(Token = "0x400021A")]
		[FieldOffset(Offset = "0x24")]
		private uint m_SecondGlyph;

		[SerializeField]
		[Token(Token = "0x400021B")]
		[FieldOffset(Offset = "0x28")]
		private GlyphValueRecord_Legacy m_SecondGlyphAdjustments;

		[FormerlySerializedAs("XadvanceOffset")]
		[Token(Token = "0x400021C")]
		[FieldOffset(Offset = "0x38")]
		public float xOffset;

		[Token(Token = "0x400021D")]
		internal static KerningPair empty;

		[SerializeField]
		[Token(Token = "0x400021E")]
		[FieldOffset(Offset = "0x3C")]
		private bool m_IgnoreSpacingAdjustments;

		[Token(Token = "0x17000065")]
		public uint firstGlyph
		{
			[Token(Token = "0x600023F")]
			[Address(RVA = "0x15DE790", Offset = "0x15DE790", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x6000240")]
			[Address(RVA = "0x15DE798", Offset = "0x15DE798", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000066")]
		public GlyphValueRecord_Legacy firstGlyphAdjustments
		{
			[Token(Token = "0x6000241")]
			[Address(RVA = "0x15DE7A0", Offset = "0x15DE7A0", Length = "0xC")]
			get
			{
				return default(GlyphValueRecord_Legacy);
			}
		}

		[Token(Token = "0x17000067")]
		public uint secondGlyph
		{
			[Token(Token = "0x6000242")]
			[Address(RVA = "0x15DE7AC", Offset = "0x15DE7AC", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x6000243")]
			[Address(RVA = "0x15DE7B4", Offset = "0x15DE7B4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000068")]
		public GlyphValueRecord_Legacy secondGlyphAdjustments
		{
			[Token(Token = "0x6000244")]
			[Address(RVA = "0x15DE7BC", Offset = "0x15DE7BC", Length = "0xC")]
			get
			{
				return default(GlyphValueRecord_Legacy);
			}
		}

		[Token(Token = "0x17000069")]
		public bool ignoreSpacingAdjustments
		{
			[Token(Token = "0x6000245")]
			[Address(RVA = "0x15DE7C8", Offset = "0x15DE7C8", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0x15DE7D0", Offset = "0x15DE7D0", Length = "0x24")]
		public KerningPair()
		{
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0x15DE7F4", Offset = "0x15DE7F4", Length = "0x40")]
		public KerningPair(uint left, uint right, float offset)
		{
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0x15DE834", Offset = "0x15DE834", Length = "0x80")]
		public KerningPair(uint firstGlyph, GlyphValueRecord_Legacy firstGlyphAdjustments, uint secondGlyph, GlyphValueRecord_Legacy secondGlyphAdjustments)
		{
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0x15DE8B4", Offset = "0x15DE8B4", Length = "0xC")]
		internal void ConvertLegacyKerningData()
		{
		}
	}
}
