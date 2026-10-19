using Cpp2ILInjected;
using UnityEngine;

namespace EnhancedUI.EnhancedScroller
{
	[Token(Token = "0x2000007")]
	public delegate void ScrollerScrolledDelegate(EnhancedScroller scroller, Vector2 val, float scrollPosition);
}
