using Cpp2ILInjected;

namespace DG.Tweening
{
	[Token(Token = "0x2000002")]
	public enum AutoPlay
	{
		[Token(Token = "0x4000002")]
		None = 0,
		[Token(Token = "0x4000003")]
		AutoPlaySequences = 1,
		[Token(Token = "0x4000004")]
		AutoPlayTweeners = 2,
		[Token(Token = "0x4000005")]
		All = 3
	}
}
