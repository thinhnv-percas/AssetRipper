using Cpp2ILInjected;

namespace EnhancedUI.EnhancedScroller
{
	[Token(Token = "0x2000008")]
	public delegate void ScrollerSnappedDelegate(EnhancedScroller scroller, int cellIndex, int dataIndex, EnhancedScrollerCellView cellView);
}
