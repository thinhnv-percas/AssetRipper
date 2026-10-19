using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004C8")]
	public readonly struct UventHealthChanged : IEvent
	{
		[Token(Token = "0x400100F")]
		[FieldOffset(Offset = "0x0")]
		public readonly int PreviousHealth;

		[Token(Token = "0x4001010")]
		[FieldOffset(Offset = "0x4")]
		public readonly int NewHealth;

		[Token(Token = "0x6001443")]
		[Address(RVA = "0x3CF3330", Offset = "0x3CF3330", Length = "0x8")]
		public UventHealthChanged(int previousHealth, int newHealth)
		{
			PreviousHealth = previousHealth;
			NewHealth = newHealth;
		}
	}
}
