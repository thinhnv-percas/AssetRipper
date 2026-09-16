using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000045")]
	public delegate void MatchDelegate(TurnBasedMatch match, bool shouldAutoLaunch, bool playerWantsToQuit);
}
