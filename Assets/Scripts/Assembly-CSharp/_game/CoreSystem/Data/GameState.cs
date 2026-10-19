using Cpp2ILInjected;

namespace _game.CoreSystem.Data
{
	[Token(Token = "0x200050C")]
	public enum GameState
	{
		[Token(Token = "0x40010DE")]
		Continue = 0,
		[Token(Token = "0x40010DF")]
		Win = 1,
		[Token(Token = "0x40010E0")]
		Lose = 2
	}
}
