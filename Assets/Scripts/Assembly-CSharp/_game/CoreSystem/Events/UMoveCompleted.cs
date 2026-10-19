using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.Events
{
	[Token(Token = "0x2000507")]
	public struct UMoveCompleted : IEvent
	{
		[Token(Token = "0x40010CF")]
		[FieldOffset(Offset = "0x0")]
		public int moveNumber;

		[Token(Token = "0x40010D0")]
		[FieldOffset(Offset = "0x4")]
		public int col;

		[Token(Token = "0x40010D1")]
		[FieldOffset(Offset = "0x8")]
		public int row;

		[Token(Token = "0x40010D2")]
		[FieldOffset(Offset = "0xC")]
		public GameColor color;
	}
}
