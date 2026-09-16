using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000020")]
	public class KerningPair
	{
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x74879C", Offset = "0x74879C")]
		[SerializeField]
		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x10")]
		private uint m_FirstGlyph;

		[SerializeField]
		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x14")]
		private GlyphValueRecord_Legacy m_FirstGlyphAdjustments;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7487F8", Offset = "0x7487F8")]
		[SerializeField]
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x24")]
		private uint m_SecondGlyph;

		[SerializeField]
		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x28")]
		private GlyphValueRecord_Legacy m_SecondGlyphAdjustments;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x748854", Offset = "0x748854")]
		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x38")]
		public float xOffset;

		[Token(Token = "0x400010C")]
		internal static KerningPair empty;

		[SerializeField]
		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x3C")]
		private bool m_IgnoreSpacingAdjustments;

		[Token(Token = "0x17000048")]
		public uint firstGlyph
		{
			[Token(Token = "0x6000194")]
			[Address(RVA = "0x917D10", Offset = "0x917D10", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x6000195")]
			[Address(RVA = "0x917D18", Offset = "0x917D18", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000049")]
		public GlyphValueRecord_Legacy firstGlyphAdjustments
		{
			[Token(Token = "0x6000196")]
			[Address(RVA = "0x917D20", Offset = "0x917D20", Length = "0xC")]
			get
			{
				return default(GlyphValueRecord_Legacy);
			}
		}

		[Token(Token = "0x1700004A")]
		public uint secondGlyph
		{
			[Token(Token = "0x6000197")]
			[Address(RVA = "0x917D2C", Offset = "0x917D2C", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x6000198")]
			[Address(RVA = "0x917D34", Offset = "0x917D34", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700004B")]
		public GlyphValueRecord_Legacy secondGlyphAdjustments
		{
			[Token(Token = "0x6000199")]
			[Address(RVA = "0x917D3C", Offset = "0x917D3C", Length = "0xC")]
			get
			{
				return default(GlyphValueRecord_Legacy);
			}
		}

		[Token(Token = "0x1700004C")]
		public bool ignoreSpacingAdjustments
		{
			[Token(Token = "0x600019A")]
			[Address(RVA = "0x917D48", Offset = "0x917D48", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0x917D50", Offset = "0x917D50", Length = "0x30")]
		public KerningPair()
		{
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0x917D80", Offset = "0x917D80", Length = "0x4C")]
		public KerningPair(uint left, uint right, float offset)
		{
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0x917DCC", Offset = "0x917DCC", Length = "0x8C")]
		public KerningPair(uint firstGlyph, GlyphValueRecord_Legacy firstGlyphAdjustments, uint secondGlyph, GlyphValueRecord_Legacy secondGlyphAdjustments)
		{
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0x917E58", Offset = "0x917E58", Length = "0xC")]
		internal void ConvertLegacyKerningData()
		{
		}
	}
}
