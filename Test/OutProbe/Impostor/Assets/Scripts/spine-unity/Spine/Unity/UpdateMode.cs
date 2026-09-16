using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x200009F")]
	public enum UpdateMode
	{
		[Token(Token = "0x40003E6")]
		Nothing = 0,
		[Token(Token = "0x40003E7")]
		OnlyAnimationStatus = 1,
		[Token(Token = "0x40003E8")]
		OnlyEventTimelines = 4,
		[Token(Token = "0x40003E9")]
		EverythingExceptMesh = 2,
		[Token(Token = "0x40003EA")]
		FullUpdate = 3
	}
}
