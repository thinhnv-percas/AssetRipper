using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000029")]
	public class TMP_FontFeatureTable
	{
		[SerializeField]
		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x10")]
		internal List<TMP_GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecords;

		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x18")]
		internal Dictionary<long, TMP_GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecordLookupDictionary;

		[Token(Token = "0x17000057")]
		internal List<TMP_GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords
		{
			[Token(Token = "0x60001CF")]
			[Address(RVA = "0x92758C", Offset = "0x92758C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001D0")]
			[Address(RVA = "0x927594", Offset = "0x927594", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0x925FC4", Offset = "0x925FC4", Length = "0x9C")]
		public TMP_FontFeatureTable()
		{
		}

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0x92759C", Offset = "0x92759C", Length = "0x1D4")]
		public void SortGlyphPairAdjustmentRecords()
		{
		}
	}
}
