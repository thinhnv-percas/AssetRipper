using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000053")]
	public class TMP_FontFeatureTable
	{
		[SerializeField]
		[Token(Token = "0x400023D")]
		[FieldOffset(Offset = "0x10")]
		internal List<TMP_GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecords;

		[Token(Token = "0x400023E")]
		[FieldOffset(Offset = "0x18")]
		internal Dictionary<uint, TMP_GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecordLookupDictionary;

		[Token(Token = "0x17000074")]
		public List<TMP_GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords
		{
			[Token(Token = "0x6000284")]
			[Address(RVA = "0x15E067C", Offset = "0x15E067C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000285")]
			[Address(RVA = "0x15E0684", Offset = "0x15E0684", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0x15DD390", Offset = "0x15DD390", Length = "0xC8")]
		public TMP_FontFeatureTable()
		{
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0x15D8864", Offset = "0x15D8864", Length = "0x1EC")]
		public void SortGlyphPairAdjustmentRecords()
		{
		}
	}
}
