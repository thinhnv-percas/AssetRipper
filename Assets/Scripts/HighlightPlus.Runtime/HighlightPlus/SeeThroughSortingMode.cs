using Cpp2ILInjected;

namespace HighlightPlus
{
	[Token(Token = "0x200000C")]
	public enum SeeThroughSortingMode
	{
		[Token(Token = "0x400000F")]
		Default = 0,
		[Token(Token = "0x4000010")]
		SortByMaterialsRenderQueue = 1,
		[Token(Token = "0x4000011")]
		SortByMaterialsRenderQueueInverted = 2
	}
}
