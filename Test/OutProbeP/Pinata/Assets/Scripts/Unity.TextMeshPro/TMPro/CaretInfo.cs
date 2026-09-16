using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 8)]
	[Token(Token = "0x2000059")]
	public struct CaretInfo
	{
		[Token(Token = "0x40003F1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x40003F2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public CaretPosition position;

		[Token(Token = "0x60004E6")]
		[Address(RVA = "0x846194", Offset = "0x846194", Length = "0x4C")]
		public CaretInfo(int index, CaretPosition position)
		{
			this.index = 0;
			this.position = CaretPosition.None;
		}
	}
}
