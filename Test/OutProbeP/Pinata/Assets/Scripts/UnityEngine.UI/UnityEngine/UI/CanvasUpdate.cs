using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000004")]
	public enum CanvasUpdate
	{
		[Token(Token = "0x400000D")]
		Prelayout = 0,
		[Token(Token = "0x400000E")]
		Layout = 1,
		[Token(Token = "0x400000F")]
		PostLayout = 2,
		[Token(Token = "0x4000010")]
		PreRender = 3,
		[Token(Token = "0x4000011")]
		LatePreRender = 4,
		[Token(Token = "0x4000012")]
		MaxUpdateValue = 5
	}
}
