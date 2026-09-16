using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 12)]
	[Token(Token = "0x200001E")]
	public struct KerningPairKey
	{
		[Token(Token = "0x4000100")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public uint ascii_Left;

		[Token(Token = "0x4000101")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public uint ascii_Right;

		[Token(Token = "0x4000102")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public uint key;

		[Token(Token = "0x6000191")]
		[Address(RVA = "0x846574", Offset = "0x846574", Length = "0x54")]
		public KerningPairKey(uint ascii_left, uint ascii_right)
		{
			ascii_Left = 0u;
			ascii_Right = 0u;
			key = 0u;
		}
	}
}
