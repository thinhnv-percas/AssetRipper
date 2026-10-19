using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.Tracking.Events
{
	[Token(Token = "0x200059C")]
	public struct UventOfferRejected : IEvent
	{
		[Token(Token = "0x4001347")]
		[FieldOffset(Offset = "0x0")]
		public string OfferType;

		[Token(Token = "0x60017C6")]
		[Address(RVA = "0x3D30BA8", Offset = "0x3D30BA8", Length = "0x8")]
		public UventOfferRejected(string offerType)
		{
			OfferType = offerType;
		}
	}
}
