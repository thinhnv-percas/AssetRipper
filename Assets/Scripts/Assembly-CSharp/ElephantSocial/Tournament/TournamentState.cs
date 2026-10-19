using Cpp2ILInjected;

namespace ElephantSocial.Tournament
{
	[Token(Token = "0x2000826")]
	public enum TournamentState
	{
		[Token(Token = "0x4001BA9")]
		Pending = 0,
		[Token(Token = "0x4001BAA")]
		Running = 1,
		[Token(Token = "0x4001BAB")]
		Completed = 2
	}
}
