using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200009B")]
	public class TMP_TextElement
	{
		[SerializeField]
		[Token(Token = "0x40005BA")]
		[FieldOffset(Offset = "0x10")]
		protected TextElementType m_ElementType;

		[SerializeField]
		[Token(Token = "0x40005BB")]
		[FieldOffset(Offset = "0x14")]
		internal uint m_Unicode;

		[Token(Token = "0x40005BC")]
		[FieldOffset(Offset = "0x18")]
		internal TMP_Asset m_TextAsset;

		[Token(Token = "0x40005BD")]
		[FieldOffset(Offset = "0x20")]
		internal Glyph m_Glyph;

		[SerializeField]
		[Token(Token = "0x40005BE")]
		[FieldOffset(Offset = "0x28")]
		internal uint m_GlyphIndex;

		[SerializeField]
		[Token(Token = "0x40005BF")]
		[FieldOffset(Offset = "0x2C")]
		internal float m_Scale;

		[Token(Token = "0x17000167")]
		public TextElementType elementType
		{
			[Token(Token = "0x60005DD")]
			[Address(RVA = "0x1610410", Offset = "0x1610410", Length = "0x8")]
			get
			{
				return (TextElementType)0;
			}
		}

		[Token(Token = "0x17000168")]
		public uint unicode
		{
			[Token(Token = "0x60005DE")]
			[Address(RVA = "0x1610418", Offset = "0x1610418", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x60005DF")]
			[Address(RVA = "0x1610420", Offset = "0x1610420", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000169")]
		public TMP_Asset textAsset
		{
			[Token(Token = "0x60005E0")]
			[Address(RVA = "0x1610428", Offset = "0x1610428", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005E1")]
			[Address(RVA = "0x1610430", Offset = "0x1610430", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700016A")]
		public Glyph glyph
		{
			[Token(Token = "0x60005E2")]
			[Address(RVA = "0x1610438", Offset = "0x1610438", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005E3")]
			[Address(RVA = "0x1610440", Offset = "0x1610440", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700016B")]
		public uint glyphIndex
		{
			[Token(Token = "0x60005E4")]
			[Address(RVA = "0x1610448", Offset = "0x1610448", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x60005E5")]
			[Address(RVA = "0x1610450", Offset = "0x1610450", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700016C")]
		public float scale
		{
			[Token(Token = "0x60005E6")]
			[Address(RVA = "0x1610458", Offset = "0x1610458", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60005E7")]
			[Address(RVA = "0x1610460", Offset = "0x1610460", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60005E8")]
		[Address(RVA = "0x160CF00", Offset = "0x160CF00", Length = "0x8")]
		public TMP_TextElement()
		{
		}
	}
}
