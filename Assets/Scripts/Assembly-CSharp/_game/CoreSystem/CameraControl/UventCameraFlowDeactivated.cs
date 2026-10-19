using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x2000526")]
	public struct UventCameraFlowDeactivated : IEvent
	{
		[Token(Token = "0x4001160")]
		[FieldOffset(Offset = "0x0")]
		public string FlowName;
	}
}
