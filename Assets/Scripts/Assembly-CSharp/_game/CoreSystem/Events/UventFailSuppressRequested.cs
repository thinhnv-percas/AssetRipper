using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.Events
{
	[Token(Token = "0x200050A")]
	public struct UventFailSuppressRequested : IEvent
	{
		[Token(Token = "0x40010D9")]
		[FieldOffset(Offset = "0x0")]
		public bool suppress;

		[Token(Token = "0x40010DA")]
		[FieldOffset(Offset = "0x8")]
		public string reason;
	}
}
