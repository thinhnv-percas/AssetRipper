using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Token(Token = "0x20006D3")]
	public readonly struct UventKeepPlayingCantAfford : IEvent
	{
		[Token(Token = "0x40016F4")]
		[FieldOffset(Offset = "0x0")]
		public readonly int Cost;

		[Token(Token = "0x6001CE3")]
		[Address(RVA = "0x3D72668", Offset = "0x3D72668", Length = "0x8")]
		public UventKeepPlayingCantAfford(int cost)
		{
			Cost = cost;
		}
	}
}
