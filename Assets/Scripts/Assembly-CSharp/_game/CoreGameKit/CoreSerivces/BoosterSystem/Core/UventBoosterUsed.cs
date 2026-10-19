using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[Token(Token = "0x2000628")]
	public readonly struct UventBoosterUsed : IEvent
	{
		[Token(Token = "0x4001543")]
		[FieldOffset(Offset = "0x0")]
		public readonly string BoosterId;

		[Token(Token = "0x4001544")]
		[FieldOffset(Offset = "0x8")]
		public readonly int RemainingCount;

		[Token(Token = "0x6001A5C")]
		[Address(RVA = "0x3D52E90", Offset = "0x3D52E90", Length = "0x2C")]
		public UventBoosterUsed(string boosterId, int remainingCount)
		{
			BoosterId = boosterId;
			RemainingCount = remainingCount;
		}
	}
}
