using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Token(Token = "0x20006D2")]
	public readonly struct UventKeepPlayingPurchased : IEvent
	{
		[Token(Token = "0x40016F1")]
		[FieldOffset(Offset = "0x0")]
		public readonly int AttemptNumber;

		[Token(Token = "0x40016F2")]
		[FieldOffset(Offset = "0x4")]
		public readonly int CostPaid;

		[Token(Token = "0x40016F3")]
		[FieldOffset(Offset = "0x8")]
		public readonly bool IsEgoOffer;

		[Token(Token = "0x6001CE1")]
		[Address(RVA = "0x3D72650", Offset = "0x3D72650", Length = "0xC")]
		public UventKeepPlayingPurchased(int attemptNumber, int costPaid)
		{
			AttemptNumber = attemptNumber;
			CostPaid = costPaid;
			IsEgoOffer = false;
		}

		[Token(Token = "0x6001CE2")]
		[Address(RVA = "0x3D7265C", Offset = "0x3D7265C", Length = "0xC")]
		public UventKeepPlayingPurchased(int attemptNumber, bool egoOffer)
		{
			IsEgoOffer = egoOffer;
			AttemptNumber = attemptNumber;
			CostPaid = 0;
		}
	}
}
