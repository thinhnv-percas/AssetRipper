using System;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000006")]
	public struct UventUiShown : IEvent
	{
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x0")]
		public Type uiControllerType;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x8")]
		public bool sendToAnalytics;
	}
}
