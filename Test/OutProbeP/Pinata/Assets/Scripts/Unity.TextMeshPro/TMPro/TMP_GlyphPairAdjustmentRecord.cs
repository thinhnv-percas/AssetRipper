using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000027")]
	public class TMP_GlyphPairAdjustmentRecord
	{
		[SerializeField]
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x10")]
		private TMP_GlyphAdjustmentRecord m_FirstAdjustmentRecord;

		[SerializeField]
		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x24")]
		private TMP_GlyphAdjustmentRecord m_SecondAdjustmentRecord;

		[SerializeField]
		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x38")]
		private FontFeatureLookupFlags m_FeatureLookupFlags;

		[Token(Token = "0x17000054")]
		public TMP_GlyphAdjustmentRecord firstAdjustmentRecord
		{
			[Token(Token = "0x60001C5")]
			[Address(RVA = "0x927F88", Offset = "0x927F88", Length = "0x14")]
			get
			{
				return default(TMP_GlyphAdjustmentRecord);
			}
			[Token(Token = "0x60001C6")]
			[Address(RVA = "0x927F9C", Offset = "0x927F9C", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x17000055")]
		public TMP_GlyphAdjustmentRecord secondAdjustmentRecord
		{
			[Token(Token = "0x60001C7")]
			[Address(RVA = "0x927FB0", Offset = "0x927FB0", Length = "0x14")]
			get
			{
				return default(TMP_GlyphAdjustmentRecord);
			}
			[Token(Token = "0x60001C8")]
			[Address(RVA = "0x927FC4", Offset = "0x927FC4", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x17000056")]
		public FontFeatureLookupFlags featureLookupFlags
		{
			[Token(Token = "0x60001C9")]
			[Address(RVA = "0x927FD8", Offset = "0x927FD8", Length = "0x8")]
			get
			{
				return (FontFeatureLookupFlags)0;
			}
			[Token(Token = "0x60001CA")]
			[Address(RVA = "0x927FE0", Offset = "0x927FE0", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0x926634", Offset = "0x926634", Length = "0x54")]
		public TMP_GlyphPairAdjustmentRecord(TMP_GlyphAdjustmentRecord firstAdjustmentRecord, TMP_GlyphAdjustmentRecord secondAdjustmentRecord)
		{
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0x926060", Offset = "0x926060", Length = "0xB8")]
		internal TMP_GlyphPairAdjustmentRecord(UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord glyphPairAdjustmentRecord)
		{
		}
	}
}
