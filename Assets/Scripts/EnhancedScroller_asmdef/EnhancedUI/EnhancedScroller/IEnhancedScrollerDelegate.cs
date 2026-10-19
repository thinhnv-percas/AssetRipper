using Cpp2ILInjected;

namespace EnhancedUI.EnhancedScroller
{
	[Token(Token = "0x2000017")]
	public interface IEnhancedScrollerDelegate
	{
		[Token(Token = "0x60000B0")]
		int GetNumberOfCells(EnhancedScroller scroller);

		[Token(Token = "0x60000B1")]
		float GetCellViewSize(EnhancedScroller scroller, int dataIndex);

		[Token(Token = "0x60000B2")]
		EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex);
	}
}
