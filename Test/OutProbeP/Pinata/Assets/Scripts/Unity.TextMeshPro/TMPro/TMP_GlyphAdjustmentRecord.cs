using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 20)]
	[Token(Token = "0x2000026")]
	public struct TMP_GlyphAdjustmentRecord
	{
		[SerializeField]
		[Token(Token = "0x400011A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private uint m_GlyphIndex;

		[SerializeField]
		[Token(Token = "0x400011B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		private TMP_GlyphValueRecord m_GlyphValueRecord;

		[Token(Token = "0x17000052")]
		public uint glyphIndex
		{
			[Token(Token = "0x60001BF")]
			[Address(RVA = "0x8467EC", Offset = "0x8467EC", Length = "0x8")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x60001C0")]
			[Address(RVA = "0x8467F4", Offset = "0x8467F4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000053")]
		public TMP_GlyphValueRecord glyphValueRecord
		{
			[Token(Token = "0x60001C1")]
			[Address(RVA = "0x8467FC", Offset = "0x8467FC", Length = "0xC")]
			get
			{
				return default(TMP_GlyphValueRecord);
			}
			[Token(Token = "0x60001C2")]
			[Address(RVA = "0x846808", Offset = "0x846808", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0x846814", Offset = "0x846814", Length = "0x10")]
		public TMP_GlyphAdjustmentRecord(uint glyphIndex, TMP_GlyphValueRecord glyphValueRecord)
		{
			m_GlyphIndex = 0u;
			m_GlyphValueRecord = default(TMP_GlyphValueRecord);
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0x846824", Offset = "0x846824", Length = "0x34")]
		internal TMP_GlyphAdjustmentRecord(UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord adjustmentRecord)
		{
			m_GlyphIndex = 0u;
			m_GlyphValueRecord = default(TMP_GlyphValueRecord);
		}
	}
}
