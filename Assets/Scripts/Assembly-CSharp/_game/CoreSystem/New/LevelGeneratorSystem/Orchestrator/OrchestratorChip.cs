using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Token(Token = "0x2000363")]
	public enum OrchestratorChip
	{
		[Token(Token = "0x4000A13")]
		Queued = 0,
		[Token(Token = "0x4000A14")]
		Generating = 1,
		[Token(Token = "0x4000A15")]
		Saved = 2,
		[Token(Token = "0x4000A16")]
		Failed = 3
	}
}
