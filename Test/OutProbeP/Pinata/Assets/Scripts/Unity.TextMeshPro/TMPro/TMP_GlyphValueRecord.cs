using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000025")]
	public struct TMP_GlyphValueRecord
	{
		[SerializeField]
		[Token(Token = "0x4000116")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private float m_XPlacement;

		[SerializeField]
		[Token(Token = "0x4000117")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		private float m_YPlacement;

		[SerializeField]
		[Token(Token = "0x4000118")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private float m_XAdvance;

		[SerializeField]
		[Token(Token = "0x4000119")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		private float m_YAdvance;

		[Token(Token = "0x1700004E")]
		public float xPlacement
		{
			[Token(Token = "0x60001B3")]
			[Address(RVA = "0x846858", Offset = "0x846858", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001B4")]
			[Address(RVA = "0x846860", Offset = "0x846860", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700004F")]
		public float yPlacement
		{
			[Token(Token = "0x60001B5")]
			[Address(RVA = "0x846868", Offset = "0x846868", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001B6")]
			[Address(RVA = "0x846870", Offset = "0x846870", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000050")]
		public float xAdvance
		{
			[Token(Token = "0x60001B7")]
			[Address(RVA = "0x846878", Offset = "0x846878", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001B8")]
			[Address(RVA = "0x846880", Offset = "0x846880", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000051")]
		public float yAdvance
		{
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0x846888", Offset = "0x846888", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001BA")]
			[Address(RVA = "0x846890", Offset = "0x846890", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0x846898", Offset = "0x846898", Length = "0xC")]
		public TMP_GlyphValueRecord(float xPlacement, float yPlacement, float xAdvance, float yAdvance)
		{
			m_XPlacement = 0f;
			m_YPlacement = 0f;
			m_XAdvance = 0f;
			m_YAdvance = 0f;
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0x8468A4", Offset = "0x8468A4", Length = "0xC")]
		internal TMP_GlyphValueRecord(GlyphValueRecord_Legacy valueRecord)
		{
			m_XPlacement = 0f;
			m_YPlacement = 0f;
			m_XAdvance = 0f;
			m_YAdvance = 0f;
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0x8468B0", Offset = "0x8468B0", Length = "0xA4")]
		internal TMP_GlyphValueRecord(UnityEngine.TextCore.LowLevel.GlyphValueRecord valueRecord)
		{
			m_XPlacement = 0f;
			m_YPlacement = 0f;
			m_XAdvance = 0f;
			m_YAdvance = 0f;
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0x928034", Offset = "0x928034", Length = "0x14")]
		public static TMP_GlyphValueRecord operator +(TMP_GlyphValueRecord a, TMP_GlyphValueRecord b)
		{
			return default(TMP_GlyphValueRecord);
		}
	}
}
