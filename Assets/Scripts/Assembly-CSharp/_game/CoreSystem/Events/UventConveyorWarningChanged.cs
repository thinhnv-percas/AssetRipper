using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.Events
{
	[Token(Token = "0x2000509")]
	public struct UventConveyorWarningChanged : IEvent
	{
		[Token(Token = "0x40010D8")]
		[FieldOffset(Offset = "0x0")]
		public bool isWarningActive;
	}
}
