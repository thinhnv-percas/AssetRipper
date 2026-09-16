using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Common
{
	[Serializable]
	[Token(Token = "0x200004E")]
	internal struct ACTkByte4
	{
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x0")]
		public byte b1;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x1")]
		public byte b2;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x2")]
		public byte b3;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x3")]
		public byte b4;

		[Token(Token = "0x600044F")]
		[Address(RVA = "0xBF3D9C", Offset = "0xBF3D9C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b2 = this.b3;\n\tthis.b3 = this.b2;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Shuffle()
		{
			b2 = b3;
			b3 = b2;
		}

		[Token(Token = "0x6000450")]
		[Address(RVA = "0xBF3DB0", Offset = "0xBF3DB0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b3 = this.b2;\n\tthis.b2 = this.b3;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UnShuffle()
		{
			b3 = b2;
			b2 = b3;
		}
	}
}
