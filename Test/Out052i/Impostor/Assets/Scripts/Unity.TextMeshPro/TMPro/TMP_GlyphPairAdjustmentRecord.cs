using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000051")]
	public class TMP_GlyphPairAdjustmentRecord
	{
		[SerializeField]
		[Token(Token = "0x4000237")]
		[FieldOffset(Offset = "0x10")]
		internal TMP_GlyphAdjustmentRecord m_FirstAdjustmentRecord;

		[SerializeField]
		[Token(Token = "0x4000238")]
		[FieldOffset(Offset = "0x24")]
		internal TMP_GlyphAdjustmentRecord m_SecondAdjustmentRecord;

		[SerializeField]
		[Token(Token = "0x4000239")]
		[FieldOffset(Offset = "0x38")]
		internal FontFeatureLookupFlags m_FeatureLookupFlags;

		[Token(Token = "0x17000071")]
		public TMP_GlyphAdjustmentRecord firstAdjustmentRecord
		{
			[Token(Token = "0x600027A")]
			[Address(RVA = "0x15E060C", Offset = "0x15E060C", Length = "0x14")]
			get
			{
				return default(TMP_GlyphAdjustmentRecord);
			}
			[Token(Token = "0x600027B")]
			[Address(RVA = "0x15E0620", Offset = "0x15E0620", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x17000072")]
		public TMP_GlyphAdjustmentRecord secondAdjustmentRecord
		{
			[Token(Token = "0x600027C")]
			[Address(RVA = "0x15E0634", Offset = "0x15E0634", Length = "0x14")]
			get
			{
				return default(TMP_GlyphAdjustmentRecord);
			}
			[Token(Token = "0x600027D")]
			[Address(RVA = "0x15E0648", Offset = "0x15E0648", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x17000073")]
		public FontFeatureLookupFlags featureLookupFlags
		{
			[Token(Token = "0x600027E")]
			[Address(RVA = "0x15E065C", Offset = "0x15E065C", Length = "0x8")]
			get
			{
				return FontFeatureLookupFlags.None;
			}
			[Token(Token = "0x600027F")]
			[Address(RVA = "0x15E0664", Offset = "0x15E0664", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0x15DDEA4", Offset = "0x15DDEA4", Length = "0x48")]
		public TMP_GlyphPairAdjustmentRecord(TMP_GlyphAdjustmentRecord firstAdjustmentRecord, TMP_GlyphAdjustmentRecord secondAdjustmentRecord)
		{
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0x15DD458", Offset = "0x15DD458", Length = "0xB4")]
		internal TMP_GlyphPairAdjustmentRecord(GlyphPairAdjustmentRecord glyphPairAdjustmentRecord)
		{
		}
	}
}
