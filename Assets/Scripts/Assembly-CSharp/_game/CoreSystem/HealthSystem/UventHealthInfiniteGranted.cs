using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004CA")]
	public readonly struct UventHealthInfiniteGranted : IEvent
	{
		[Token(Token = "0x4001012")]
		[FieldOffset(Offset = "0x0")]
		public readonly int PreviousDuration;

		[Token(Token = "0x4001013")]
		[FieldOffset(Offset = "0x4")]
		public readonly int AddedDuration;

		[Token(Token = "0x6001445")]
		[Address(RVA = "0x3CF3798", Offset = "0x3CF3798", Length = "0x8")]
		public UventHealthInfiniteGranted(int previousDuration, int addedDuration)
		{
			PreviousDuration = previousDuration;
			AddedDuration = addedDuration;
		}
	}
}
