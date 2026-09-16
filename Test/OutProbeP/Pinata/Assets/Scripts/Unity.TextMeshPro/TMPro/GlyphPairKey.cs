using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000028")]
	public struct GlyphPairKey
	{
		[Token(Token = "0x400011F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public uint firstGlyphIndex;

		[Token(Token = "0x4000120")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public uint secondGlyphIndex;

		[Token(Token = "0x4000121")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public long key;

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0x846528", Offset = "0x846528", Length = "0x14")]
		public GlyphPairKey(uint firstGlyphIndex, uint secondGlyphIndex)
		{
			this.firstGlyphIndex = 0u;
			this.secondGlyphIndex = 0u;
			key = 0L;
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0x84653C", Offset = "0x84653C", Length = "0x30")]
		internal GlyphPairKey(TMP_GlyphPairAdjustmentRecord record)
		{
			firstGlyphIndex = 0u;
			secondGlyphIndex = 0u;
			key = 0L;
		}
	}
}
