using Cpp2ILInjected;

namespace HighlightPlus
{
	[Token(Token = "0x2000011")]
	public enum TargetOptions
	{
		[Token(Token = "0x4000025")]
		Children = 0,
		[Token(Token = "0x4000026")]
		OnlyThisObject = 1,
		[Token(Token = "0x4000027")]
		RootToChildren = 2,
		[Token(Token = "0x4000028")]
		LayerInScene = 3,
		[Token(Token = "0x4000029")]
		LayerInChildren = 4,
		[Token(Token = "0x400002A")]
		Scripting = 5
	}
}
