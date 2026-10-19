using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Token(Token = "0x20006CE")]
	public readonly struct UventLevelFailed : IEvent
	{
		[Token(Token = "0x40016F0")]
		[FieldOffset(Offset = "0x0")]
		public readonly bool IsButtonFail;

		[Token(Token = "0x6001CE0")]
		[Address(RVA = "0x3D72648", Offset = "0x3D72648", Length = "0x8")]
		public UventLevelFailed(bool isButtonFail)
		{
			IsButtonFail = isButtonFail;
		}
	}
}
