using Cpp2ILInjected;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x2000520")]
	public enum CameraFlowActionType
	{
		[Token(Token = "0x400114A")]
		GoToPose = 0,
		[Token(Token = "0x400114B")]
		PlayPath = 1,
		[Token(Token = "0x400114C")]
		EnableTracking = 2,
		[Token(Token = "0x400114D")]
		DisableTracking = 3,
		[Token(Token = "0x400114E")]
		TrackObject = 4
	}
}
