using Cpp2ILInjected;

namespace DG.Tweening
{
	[Token(Token = "0x2000005")]
	public delegate void TweenCallback();
	[Token(Token = "0x2000006")]
	public delegate void TweenCallback<in T>(T value);
}
