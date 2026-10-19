using Cpp2ILInjected;

namespace HighlightPlus
{
	[Token(Token = "0x200001C")]
	public enum MaskMode
	{
		[Token(Token = "0x400004B")]
		Stencil = 0,
		[Token(Token = "0x400004C")]
		IgnoreMask = 1,
		[Token(Token = "0x400004D")]
		StencilAndCutout = 2,
		[Token(Token = "0x400004E")]
		CutoutOnly = 3
	}
}
