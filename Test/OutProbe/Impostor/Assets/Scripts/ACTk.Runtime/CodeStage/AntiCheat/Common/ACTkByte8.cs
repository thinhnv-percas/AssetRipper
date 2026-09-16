using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Common
{
	[Serializable]
	[Token(Token = "0x200004F")]
	internal struct ACTkByte8
	{
		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x0")]
		public byte b1;

		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x1")]
		public byte b2;

		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x2")]
		public byte b3;

		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x3")]
		public byte b4;

		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x4")]
		public byte b5;

		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x5")]
		public byte b6;

		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0x6")]
		public byte b7;

		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0x7")]
		public byte b8;

		[Token(Token = "0x6000451")]
		[Address(RVA = "0xBF3DC4", Offset = "0xBF3DC4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b1 = this.b2;\n\tthis.b2 = this.b1;\n\tthis.b5 = this.b6;\n\tthis.b8 = this.b5;\n\tthis.b6 = this.b8;\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Shuffle()
		{
			b1 = b2;
			b2 = b1;
			b5 = b6;
			b8 = b5;
			b6 = b8;
		}

		[Token(Token = "0x6000452")]
		[Address(RVA = "0xBF3DF0", Offset = "0xBF3DF0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b1 = this.b2;\n\tthis.b2 = this.b1;\n\tthis.b5 = this.b8;\n\tthis.b6 = this.b5;\n\tthis.b8 = this.b6;\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UnShuffle()
		{
			b1 = b2;
			b2 = b1;
			b5 = b8;
			b6 = b5;
			b8 = b6;
		}
	}
}
