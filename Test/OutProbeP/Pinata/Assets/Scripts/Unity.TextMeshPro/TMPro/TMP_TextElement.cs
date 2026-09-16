using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000054")]
	public class TMP_TextElement
	{
		[SerializeField]
		[Token(Token = "0x40003CA")]
		[FieldOffset(Offset = "0x10")]
		protected TextElementType m_ElementType;

		[SerializeField]
		[Token(Token = "0x40003CB")]
		[FieldOffset(Offset = "0x14")]
		private uint m_Unicode;

		[Token(Token = "0x40003CC")]
		[FieldOffset(Offset = "0x18")]
		private Glyph m_Glyph;

		[SerializeField]
		[Token(Token = "0x40003CD")]
		[FieldOffset(Offset = "0x20")]
		private uint m_GlyphIndex;

		[SerializeField]
		[Token(Token = "0x40003CE")]
		[FieldOffset(Offset = "0x24")]
		private float m_Scale;

		[Token(Token = "0x17000135")]
		public TextElementType elementType
		{
			[Token(Token = "0x60004C4")]
			[Address(RVA = "0xC89E80", Offset = "0xC89E80", Length = "0x8")]
			get
			{
				return (TextElementType)0;
			}
		}

		[Token(Token = "0x17000136")]
		public uint unicode
		{
			[Token(Token = "0x60004C5")]
			[Address(RVA = "0xC89E88", Offset = "0xC89E88", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x60004C6")]
			[Address(RVA = "0xC89E90", Offset = "0xC89E90", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000137")]
		public Glyph glyph
		{
			[Token(Token = "0x60004C7")]
			[Address(RVA = "0xC89E98", Offset = "0xC89E98", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004C8")]
			[Address(RVA = "0xC89EA0", Offset = "0xC89EA0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000138")]
		public uint glyphIndex
		{
			[Token(Token = "0x60004C9")]
			[Address(RVA = "0xC89EA8", Offset = "0xC89EA8", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x60004CA")]
			[Address(RVA = "0xC89EB0", Offset = "0xC89EB0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000139")]
		public float scale
		{
			[Token(Token = "0x60004CB")]
			[Address(RVA = "0xC89EB8", Offset = "0xC89EB8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004CC")]
			[Address(RVA = "0xC89EC0", Offset = "0xC89EC0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60004CD")]
		[Address(RVA = "0xC89EC8", Offset = "0xC89EC8", Length = "0x8")]
		public TMP_TextElement()
		{
		}
	}
}
