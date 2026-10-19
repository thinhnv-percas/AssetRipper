using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004C9")]
	public readonly struct UventHealthRemoved : IEvent
	{
		[Token(Token = "0x4001011")]
		[FieldOffset(Offset = "0x0")]
		public readonly int NewHealth;

		[Token(Token = "0x6001444")]
		[Address(RVA = "0x3CF3CC4", Offset = "0x3CF3CC4", Length = "0x8")]
		public UventHealthRemoved(int newHealth)
		{
			NewHealth = newHealth;
		}
	}
}
