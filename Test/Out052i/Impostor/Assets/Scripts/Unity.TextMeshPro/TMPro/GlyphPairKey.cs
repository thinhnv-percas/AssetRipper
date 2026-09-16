using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000052")]
	public struct GlyphPairKey
	{
		[Token(Token = "0x400023A")]
		[FieldOffset(Offset = "0x0")]
		public uint firstGlyphIndex;

		[Token(Token = "0x400023B")]
		[FieldOffset(Offset = "0x4")]
		public uint secondGlyphIndex;

		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x8")]
		public uint key;

		[Token(Token = "0x6000282")]
		[Address(RVA = "0x15E066C", Offset = "0x15E066C", Length = "0x10")]
		public GlyphPairKey(uint firstGlyphIndex, uint secondGlyphIndex)
		{
			this.firstGlyphIndex = 0u;
			this.secondGlyphIndex = 0u;
			key = 0u;
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0x15D82EC", Offset = "0x15D82EC", Length = "0x28")]
		internal GlyphPairKey(TMP_GlyphPairAdjustmentRecord record)
		{
			firstGlyphIndex = 0u;
			secondGlyphIndex = 0u;
			key = 0u;
		}
	}
}
