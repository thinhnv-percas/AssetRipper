using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.Events
{
	[Token(Token = "0x2000508")]
	public struct USandCubeClicked : IEvent
	{
		[Token(Token = "0x40010D3")]
		[FieldOffset(Offset = "0x0")]
		public int cubeIndex;

		[Token(Token = "0x40010D4")]
		[FieldOffset(Offset = "0x4")]
		public int col;

		[Token(Token = "0x40010D5")]
		[FieldOffset(Offset = "0x8")]
		public int row;

		[Token(Token = "0x40010D6")]
		[FieldOffset(Offset = "0xC")]
		public bool isPourable;

		[Token(Token = "0x40010D7")]
		[FieldOffset(Offset = "0x10")]
		public GameColor color;
	}
}
