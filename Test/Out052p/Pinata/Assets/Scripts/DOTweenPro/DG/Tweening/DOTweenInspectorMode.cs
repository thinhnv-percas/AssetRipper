using Cpp2ILInjected;

namespace DG.Tweening
{
	[Token(Token = "0x2000005")]
	public enum DOTweenInspectorMode
	{
		[Token(Token = "0x400000D")]
		Default = 0,
		[Token(Token = "0x400000E")]
		InfoAndWaypointsOnly = 1,
		[Token(Token = "0x400000F")]
		Developer = 2,
		[Token(Token = "0x4000010")]
		OnlyPath = 3
	}
}
