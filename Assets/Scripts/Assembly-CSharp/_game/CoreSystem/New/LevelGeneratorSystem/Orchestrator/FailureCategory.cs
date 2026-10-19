using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Token(Token = "0x2000362")]
	public enum FailureCategory
	{
		[Token(Token = "0x4000A09")]
		None = 0,
		[Token(Token = "0x4000A0A")]
		LimitReached = 1,
		[Token(Token = "0x4000A0B")]
		BriefTimeout = 2,
		[Token(Token = "0x4000A0C")]
		ExtractorMissingConcept = 3,
		[Token(Token = "0x4000A0D")]
		ExtractorError = 4,
		[Token(Token = "0x4000A0E")]
		ExtractorTransient = 5,
		[Token(Token = "0x4000A0F")]
		BudgetExceeded = 6,
		[Token(Token = "0x4000A10")]
		NotSolvable = 7,
		[Token(Token = "0x4000A11")]
		OffTrack = 8
	}
}
