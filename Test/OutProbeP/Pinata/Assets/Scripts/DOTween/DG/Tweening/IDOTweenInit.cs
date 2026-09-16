using Cpp2ILInjected;

namespace DG.Tweening
{
	[Token(Token = "0x200000C")]
	public interface IDOTweenInit
	{
		[Token(Token = "0x6000068")]
		IDOTweenInit SetCapacity(int tweenersCapacity, int sequencesCapacity);
	}
}
