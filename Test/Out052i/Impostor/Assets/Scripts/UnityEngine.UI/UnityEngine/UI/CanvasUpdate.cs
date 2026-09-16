using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000008")]
	public enum CanvasUpdate
	{
		[Token(Token = "0x4000017")]
		Prelayout = 0,
		[Token(Token = "0x4000018")]
		Layout = 1,
		[Token(Token = "0x4000019")]
		PostLayout = 2,
		[Token(Token = "0x400001A")]
		PreRender = 3,
		[Token(Token = "0x400001B")]
		LatePreRender = 4,
		[Token(Token = "0x400001C")]
		MaxUpdateValue = 5
	}
}
