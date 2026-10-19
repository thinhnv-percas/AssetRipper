using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.Events
{
	[Token(Token = "0x200050B")]
	public struct UventGraceCountdownChanged : IEvent
	{
		[Token(Token = "0x40010DB")]
		[FieldOffset(Offset = "0x0")]
		public bool isActive;

		[Token(Token = "0x40010DC")]
		[FieldOffset(Offset = "0x4")]
		public float graceDuration;
	}
}
