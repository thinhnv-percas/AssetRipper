using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.Tracking.Events
{
	[Token(Token = "0x200059D")]
	public struct UventOfferShown : IEvent
	{
		[Token(Token = "0x4001348")]
		[FieldOffset(Offset = "0x0")]
		public string OfferType;

		[Token(Token = "0x60017C7")]
		[Address(RVA = "0x3D30BB0", Offset = "0x3D30BB0", Length = "0x8")]
		public UventOfferShown(string offerType)
		{
			OfferType = offerType;
		}
	}
}
