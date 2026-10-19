using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200001F")]
	public class SolverResult
	{
		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x10")]
		public string SchemaVersion;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x18")]
		public string LevelId;

		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x20")]
		public string Result;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x28")]
		public VerdictLabel? Verdict;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x30")]
		public double Confidence;

		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x38")]
		public bool GreedyPass;

		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x39")]
		public bool MctsInvoked;

		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x40")]
		public Solution ShortestSolution;

		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x48")]
		public List<Solution> AlternativePaths;

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x50")]
		public List<ConveyorTimelineEntry> ConveyorTimeline;

		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x58")]
		public SolverMetrics Metrics;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x60")]
		public string StuckReason;

		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x68")]
		public UnsolvableEvidence UnsolvableEvidence;

		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x70")]
		public ForensicDiagnostics Diagnostics;

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x3C0B7E0", Offset = "0x3C0B7E0", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tthis.AlternativePaths = v72;\n\tv89 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ConveyorTimelineEntry>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ConveyorTimelineEntry>::.ctor(v89);\n\tthis.ConveyorTimeline = v89;\n\tv99 = new _game.Tools.AlgorithmicLevelGenerator.Solver.SolverMetrics();\n\tSystem.Object::.ctor(v99);\n\tthis.Metrics = v99;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0036:\n\tthis.SchemaVersion = \"1.1\";\n\tthis.Confidence = 1d;\n\tv72 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.Solution>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.Solution>::.ctor(v72);\n")]
		public SolverResult()
		{
			SchemaVersion = "1.1";
			Confidence = 1.0;
			List<Solution> alternativePaths = new List<Solution>();
			AlternativePaths = alternativePaths;
			List<ConveyorTimelineEntry> conveyorTimeline = new List<ConveyorTimelineEntry>();
			ConveyorTimeline = conveyorTimeline;
			SolverMetrics metrics = new SolverMetrics();
			Metrics = metrics;
		}
	}
}
