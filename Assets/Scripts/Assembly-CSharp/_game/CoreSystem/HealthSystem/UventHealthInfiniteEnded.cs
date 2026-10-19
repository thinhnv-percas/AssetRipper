using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.HealthSystem
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x20004CB")]
	public readonly struct UventHealthInfiniteEnded : IEvent
	{
	}
}
