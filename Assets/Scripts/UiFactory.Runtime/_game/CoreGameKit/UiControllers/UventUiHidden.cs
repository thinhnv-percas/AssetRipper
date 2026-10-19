using System;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000007")]
	public struct UventUiHidden : IEvent
	{
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x0")]
		public Type uiControllerType;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x8")]
		public bool sendToAnalytics;
	}
}
