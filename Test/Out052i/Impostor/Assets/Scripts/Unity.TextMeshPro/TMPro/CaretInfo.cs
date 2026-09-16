using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x20000A2")]
	public struct CaretInfo
	{
		[Token(Token = "0x40005F3")]
		[FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x40005F4")]
		[FieldOffset(Offset = "0x4")]
		public CaretPosition position;

		[Token(Token = "0x6000619")]
		[Address(RVA = "0x16117DC", Offset = "0x16117DC", Length = "0x8")]
		public CaretInfo(int index, CaretPosition position)
		{
			this.index = 0;
			this.position = CaretPosition.None;
		}
	}
}
