using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[Token(Token = "0x2000629")]
	public readonly struct UventBoosterPurchased : IEvent
	{
		[Token(Token = "0x4001545")]
		[FieldOffset(Offset = "0x0")]
		public readonly string BoosterId;

		[Token(Token = "0x4001546")]
		[FieldOffset(Offset = "0x8")]
		public readonly int Amount;

		[Token(Token = "0x4001547")]
		[FieldOffset(Offset = "0xC")]
		public readonly int NewCount;

		[Token(Token = "0x4001548")]
		[FieldOffset(Offset = "0x10")]
		public readonly string SourceType;

		[Token(Token = "0x6001A5D")]
		[Address(RVA = "0x3D52EBC", Offset = "0x3D52EBC", Length = "0x48")]
		public UventBoosterPurchased(string boosterId, int amount, int newCount, string sourceType)
		{
			BoosterId = boosterId;
			SourceType = sourceType;
			Amount = amount;
			NewCount = newCount;
		}
	}
}
