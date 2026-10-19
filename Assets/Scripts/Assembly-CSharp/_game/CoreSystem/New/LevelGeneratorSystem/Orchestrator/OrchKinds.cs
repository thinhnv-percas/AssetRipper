using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Token(Token = "0x2000369")]
	public static class OrchKinds
	{
		[Token(Token = "0x4000A35")]
		public const string SessionStarted = "sessionStarted";

		[Token(Token = "0x4000A36")]
		public const string SessionFinished = "sessionFinished";

		[Token(Token = "0x4000A37")]
		public const string SessionAborted = "sessionAborted";

		[Token(Token = "0x4000A38")]
		public const string SessionCancelled = "sessionCancelled";

		[Token(Token = "0x4000A39")]
		public const string BriefStageStarted = "briefStageStarted";

		[Token(Token = "0x4000A3A")]
		public const string BriefGenerated = "briefGenerated";

		[Token(Token = "0x4000A3B")]
		public const string BriefTimedOut = "briefTimedOut";

		[Token(Token = "0x4000A3C")]
		public const string BriefSkipped = "briefSkipped";

		[Token(Token = "0x4000A3D")]
		public const string CardQueued = "cardQueued";

		[Token(Token = "0x4000A3E")]
		public const string CardStarted = "cardStarted";

		[Token(Token = "0x4000A3F")]
		public const string CardSaved = "cardSaved";

		[Token(Token = "0x4000A40")]
		public const string FailureClassified = "failureClassified";

		[Token(Token = "0x4000A41")]
		public const string RetryScheduled = "retryScheduled";

		[Token(Token = "0x4000A42")]
		public const string CircuitBreakerTripped = "circuitBreakerTripped";

		[Token(Token = "0x4000A43")]
		public const string LimitHit = "limitHit";

		[Token(Token = "0x4000A44")]
		public const string Paused = "paused";

		[Token(Token = "0x4000A45")]
		public const string Resumed = "resumed";

		[Token(Token = "0x4000A46")]
		public const string UsageProbe = "usageProbe";

		[Token(Token = "0x4000A47")]
		public const string ManagerDispatched = "managerDispatched";

		[Token(Token = "0x4000A48")]
		public const string ManagerResult = "managerResult";

		[Token(Token = "0x4000A49")]
		public const string Triage = "triage";

		[Token(Token = "0x4000A4A")]
		public const string RangeAdjusted = "rangeAdjusted";

		[Token(Token = "0x4000A4B")]
		public const string FreshPromptCycle = "freshPromptCycle";

		[Token(Token = "0x4000A4C")]
		public const string Error = "error";
	}
}
