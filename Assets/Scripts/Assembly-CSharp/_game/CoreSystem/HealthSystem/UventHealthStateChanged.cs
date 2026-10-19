using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004CC")]
	public readonly struct UventHealthStateChanged : IEvent
	{
		[Token(Token = "0x4001014")]
		[FieldOffset(Offset = "0x0")]
		public readonly HealthState PreviousState;

		[Token(Token = "0x4001015")]
		[FieldOffset(Offset = "0x4")]
		public readonly HealthState NewState;

		[Token(Token = "0x6001446")]
		[Address(RVA = "0x3CF3B08", Offset = "0x3CF3B08", Length = "0x8")]
		public UventHealthStateChanged(HealthState previousState, HealthState newState)
		{
			PreviousState = previousState;
			NewState = newState;
		}
	}
}
