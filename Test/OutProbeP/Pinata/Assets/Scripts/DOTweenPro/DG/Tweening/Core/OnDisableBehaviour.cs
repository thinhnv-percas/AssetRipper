using Cpp2ILInjected;

namespace DG.Tweening.Core
{
	[Token(Token = "0x200000B")]
	public enum OnDisableBehaviour
	{
		[Token(Token = "0x4000057")]
		None = 0,
		[Token(Token = "0x4000058")]
		Pause = 1,
		[Token(Token = "0x4000059")]
		Rewind = 2,
		[Token(Token = "0x400005A")]
		Kill = 3,
		[Token(Token = "0x400005B")]
		KillAndComplete = 4,
		[Token(Token = "0x400005C")]
		DestroyGameObject = 5
	}
}
