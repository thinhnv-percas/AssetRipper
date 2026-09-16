using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000044")]
	public struct KerningPairKey
	{
		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0x0")]
		public uint ascii_Left;

		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0x4")]
		public uint ascii_Right;

		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0x8")]
		public uint key;

		[Token(Token = "0x600023C")]
		[Address(RVA = "0x15DE70C", Offset = "0x15DE70C", Length = "0x10")]
		public KerningPairKey(uint ascii_left, uint ascii_right)
		{
			ascii_Left = 0u;
			ascii_Right = 0u;
			key = 0u;
		}
	}
}
