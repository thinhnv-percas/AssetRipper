using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.Tracking.Events
{
	[Token(Token = "0x200059E")]
	public struct UventShopOpened : IEvent
	{
		[Token(Token = "0x4001349")]
		[FieldOffset(Offset = "0x0")]
		public bool IsHover;

		[Token(Token = "0x60017C8")]
		[Address(RVA = "0x3D30BB8", Offset = "0x3D30BB8", Length = "0x8")]
		public UventShopOpened(bool isHover)
		{
			IsHover = isHover;
		}
	}
}
