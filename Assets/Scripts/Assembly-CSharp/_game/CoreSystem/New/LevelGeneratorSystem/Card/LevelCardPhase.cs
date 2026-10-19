using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Card
{
	[Token(Token = "0x20003A6")]
	public enum LevelCardPhase
	{
		[Token(Token = "0x4000B23")]
		Idle = 0,
		[Token(Token = "0x4000B24")]
		Extracting = 1,
		[Token(Token = "0x4000B25")]
		Generating = 2,
		[Token(Token = "0x4000B26")]
		Done = 3
	}
}
