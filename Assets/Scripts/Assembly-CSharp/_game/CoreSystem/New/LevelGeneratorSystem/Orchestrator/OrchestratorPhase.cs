using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Token(Token = "0x2000360")]
	public enum OrchestratorPhase
	{
		[Token(Token = "0x40009FD")]
		Idle = 0,
		[Token(Token = "0x40009FE")]
		GeneratingBriefs = 1,
		[Token(Token = "0x40009FF")]
		GeneratingLevels = 2,
		[Token(Token = "0x4000A00")]
		Paused = 3,
		[Token(Token = "0x4000A01")]
		Completed = 4,
		[Token(Token = "0x4000A02")]
		Cancelled = 5,
		[Token(Token = "0x4000A03")]
		Aborted = 6
	}
}
