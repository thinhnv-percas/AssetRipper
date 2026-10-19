using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x2000525")]
	public struct UventCameraFlowActivated : IEvent
	{
		[Token(Token = "0x400115F")]
		[FieldOffset(Offset = "0x0")]
		public string FlowName;
	}
}
