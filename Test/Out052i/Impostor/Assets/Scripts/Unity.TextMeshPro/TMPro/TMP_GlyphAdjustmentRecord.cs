using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000050")]
	public struct TMP_GlyphAdjustmentRecord
	{
		[SerializeField]
		[Token(Token = "0x4000235")]
		[FieldOffset(Offset = "0x0")]
		internal uint m_GlyphIndex;

		[SerializeField]
		[Token(Token = "0x4000236")]
		[FieldOffset(Offset = "0x4")]
		internal TMP_GlyphValueRecord m_GlyphValueRecord;

		[Token(Token = "0x1700006F")]
		public uint glyphIndex
		{
			[Token(Token = "0x6000274")]
			[Address(RVA = "0x15E0590", Offset = "0x15E0590", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x6000275")]
			[Address(RVA = "0x15E0598", Offset = "0x15E0598", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000070")]
		public TMP_GlyphValueRecord glyphValueRecord
		{
			[Token(Token = "0x6000276")]
			[Address(RVA = "0x15E05A0", Offset = "0x15E05A0", Length = "0xC")]
			get
			{
				return default(TMP_GlyphValueRecord);
			}
			[Token(Token = "0x6000277")]
			[Address(RVA = "0x15E05AC", Offset = "0x15E05AC", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x6000278")]
		[Address(RVA = "0x15DDE94", Offset = "0x15DDE94", Length = "0x10")]
		public TMP_GlyphAdjustmentRecord(uint glyphIndex, TMP_GlyphValueRecord glyphValueRecord)
		{
			m_GlyphIndex = 0u;
			m_GlyphValueRecord = default(TMP_GlyphValueRecord);
		}

		[Token(Token = "0x6000279")]
		[Address(RVA = "0x15E05B8", Offset = "0x15E05B8", Length = "0x54")]
		internal TMP_GlyphAdjustmentRecord(GlyphAdjustmentRecord adjustmentRecord)
		{
			m_GlyphIndex = 0u;
			m_GlyphValueRecord = default(TMP_GlyphValueRecord);
		}
	}
}
