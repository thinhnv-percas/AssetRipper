using Cpp2ILInjected;

namespace HighlightPlus
{
	[Token(Token = "0x200000B")]
	public enum SeeThroughMode
	{
		[Token(Token = "0x400000B")]
		WhenHighlighted = 0,
		[Token(Token = "0x400000C")]
		AlwaysWhenOccluded = 1,
		[Token(Token = "0x400000D")]
		Never = 2
	}
}
