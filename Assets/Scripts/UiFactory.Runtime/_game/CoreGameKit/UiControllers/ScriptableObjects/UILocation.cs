using Cpp2ILInjected;

namespace _game.CoreGameKit.UiControllers.ScriptableObjects
{
	[Token(Token = "0x2000025")]
	public enum UILocation
	{
		[Token(Token = "0x4000053")]
		SafeArea = 0,
		[Token(Token = "0x4000054")]
		NoSafeArea = 1,
		[Token(Token = "0x4000055")]
		OverlaySafeArea = 2,
		[Token(Token = "0x4000056")]
		OverlayNoSafeArea = 3,
		[Token(Token = "0x4000057")]
		Mask = 4,
		[Token(Token = "0x4000058")]
		PrioritySafeArea = 5,
		[Token(Token = "0x4000059")]
		AnimatableObjectArea = 6,
		[Token(Token = "0x400005A")]
		AnimParent_worldSpace = 7
	}
}
