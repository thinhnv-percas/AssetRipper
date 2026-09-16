using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200004F")]
	public struct TMP_GlyphValueRecord
	{
		[SerializeField]
		[Token(Token = "0x4000231")]
		[FieldOffset(Offset = "0x0")]
		internal float m_XPlacement;

		[SerializeField]
		[Token(Token = "0x4000232")]
		[FieldOffset(Offset = "0x4")]
		internal float m_YPlacement;

		[SerializeField]
		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x8")]
		internal float m_XAdvance;

		[SerializeField]
		[Token(Token = "0x4000234")]
		[FieldOffset(Offset = "0xC")]
		internal float m_YAdvance;

		[Token(Token = "0x1700006B")]
		public float xPlacement
		{
			[Token(Token = "0x6000268")]
			[Address(RVA = "0x15E04D0", Offset = "0x15E04D0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000269")]
			[Address(RVA = "0x15E04D8", Offset = "0x15E04D8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700006C")]
		public float yPlacement
		{
			[Token(Token = "0x600026A")]
			[Address(RVA = "0x15E04E0", Offset = "0x15E04E0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600026B")]
			[Address(RVA = "0x15E04E8", Offset = "0x15E04E8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700006D")]
		public float xAdvance
		{
			[Token(Token = "0x600026C")]
			[Address(RVA = "0x15E04F0", Offset = "0x15E04F0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600026D")]
			[Address(RVA = "0x15E04F8", Offset = "0x15E04F8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700006E")]
		public float yAdvance
		{
			[Token(Token = "0x600026E")]
			[Address(RVA = "0x15E0500", Offset = "0x15E0500", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600026F")]
			[Address(RVA = "0x15E0508", Offset = "0x15E0508", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0x15DDE88", Offset = "0x15DDE88", Length = "0xC")]
		public TMP_GlyphValueRecord(float xPlacement, float yPlacement, float xAdvance, float yAdvance)
		{
			m_XPlacement = 0f;
			m_YPlacement = 0f;
			m_XAdvance = 0f;
			m_YAdvance = 0f;
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0x15E0510", Offset = "0x15E0510", Length = "0xC")]
		internal TMP_GlyphValueRecord(GlyphValueRecord_Legacy valueRecord)
		{
			m_XPlacement = 0f;
			m_YPlacement = 0f;
			m_XAdvance = 0f;
			m_YAdvance = 0f;
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0x15E051C", Offset = "0x15E051C", Length = "0x60")]
		internal TMP_GlyphValueRecord(GlyphValueRecord valueRecord)
		{
			m_XPlacement = 0f;
			m_YPlacement = 0f;
			m_XAdvance = 0f;
			m_YAdvance = 0f;
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0x15E057C", Offset = "0x15E057C", Length = "0x14")]
		public static TMP_GlyphValueRecord operator +(TMP_GlyphValueRecord a, TMP_GlyphValueRecord b)
		{
			return default(TMP_GlyphValueRecord);
		}
	}
}
