using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000047")]
	public class KerningTable
	{
		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x10")]
		public List<KerningPair> kerningPairs;

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x15DE1C8", Offset = "0x15DE1C8", Length = "0x80")]
		public KerningTable()
		{
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x15DE930", Offset = "0x15DE930", Length = "0x1D4")]
		public void AddKerningPair()
		{
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x15DEB04", Offset = "0x15DEB04", Length = "0x1AC")]
		public int AddKerningPair(uint first, uint second, float offset)
		{
			return 0;
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0x15DECB8", Offset = "0x15DECB8", Length = "0x1EC")]
		public int AddGlyphPairAdjustmentRecord(uint first, GlyphValueRecord_Legacy firstAdjustments, uint second, GlyphValueRecord_Legacy secondAdjustments)
		{
			return 0;
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x15DEEAC", Offset = "0x15DEEAC", Length = "0x11C")]
		public void RemoveKerningPair(int left, int right)
		{
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x15DEFD0", Offset = "0x15DEFD0", Length = "0x58")]
		public void RemoveKerningPair(int index)
		{
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x15DF028", Offset = "0x15DF028", Length = "0x1EC")]
		public void SortKerningPairs()
		{
		}
	}
}
