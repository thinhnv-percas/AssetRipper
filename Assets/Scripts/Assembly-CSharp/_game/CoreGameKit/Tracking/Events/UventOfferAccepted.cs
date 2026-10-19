using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.Tracking.Events
{
	[Token(Token = "0x200059B")]
	public struct UventOfferAccepted : IEvent
	{
		[Token(Token = "0x4001346")]
		[FieldOffset(Offset = "0x0")]
		public string OfferType;

		[Token(Token = "0x60017C5")]
		[Address(RVA = "0x3D30BA0", Offset = "0x3D30BA0", Length = "0x8")]
		public UventOfferAccepted(string offerType)
		{
			OfferType = offerType;
		}
	}
}
