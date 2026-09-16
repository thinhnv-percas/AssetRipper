using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000021")]
	public class KerningTable
	{
		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x10")]
		public List<KerningPair> kerningPairs;

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0x917EEC", Offset = "0x917EEC", Length = "0x74")]
		public KerningTable()
		{
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0x917F60", Offset = "0x917F60", Length = "0x12C")]
		public void AddKerningPair()
		{
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0x91808C", Offset = "0x91808C", Length = "0x13C")]
		public int AddKerningPair(uint first, uint second, float offset)
		{
			return 0;
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0x9181D0", Offset = "0x9181D0", Length = "0x17C")]
		public int AddGlyphPairAdjustmentRecord(uint first, GlyphValueRecord_Legacy firstAdjustments, uint second, GlyphValueRecord_Legacy secondAdjustments)
		{
			return 0;
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0x918354", Offset = "0x918354", Length = "0x104")]
		public void RemoveKerningPair(int left, int right)
		{
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0x918460", Offset = "0x918460", Length = "0x68")]
		public void RemoveKerningPair(int index)
		{
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x9184C8", Offset = "0x9184C8", Length = "0x1D4")]
		public void SortKerningPairs()
		{
		}
	}
}
