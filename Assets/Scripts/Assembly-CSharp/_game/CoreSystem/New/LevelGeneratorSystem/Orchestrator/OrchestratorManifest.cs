using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Serializable]
	[Token(Token = "0x2000364")]
	public sealed class OrchestratorManifest
	{
		[Serializable]
		[Token(Token = "0x2000365")]
		public sealed class DiffTally
		{
			[Token(Token = "0x4000A20")]
			[FieldOffset(Offset = "0x10")]
			public string difficulty;

			[Token(Token = "0x4000A21")]
			[FieldOffset(Offset = "0x18")]
			public int requested;

			[Token(Token = "0x4000A22")]
			[FieldOffset(Offset = "0x1C")]
			public int saved;

			[Token(Token = "0x4000A23")]
			[FieldOffset(Offset = "0x20")]
			public int failed;

			[Token(Token = "0x6000E0D")]
			[Address(RVA = "0x3F03120", Offset = "0x3F03120", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public DiffTally()
			{
			}
		}

		[Token(Token = "0x4000A17")]
		[FieldOffset(Offset = "0x10")]
		public string SessionId;

		[Token(Token = "0x4000A18")]
		[FieldOffset(Offset = "0x18")]
		public DateTime StartedUtc;

		[Token(Token = "0x4000A19")]
		[FieldOffset(Offset = "0x20")]
		public DateTime FinishedUtc;

		[Token(Token = "0x4000A1A")]
		[FieldOffset(Offset = "0x28")]
		public string FinalPhase;

		[Token(Token = "0x4000A1B")]
		[FieldOffset(Offset = "0x30")]
		public List<DiffTally> PerDifficulty;

		[Token(Token = "0x4000A1C")]
		[FieldOffset(Offset = "0x38")]
		public long TotalTokens;

		[Token(Token = "0x4000A1D")]
		[FieldOffset(Offset = "0x40")]
		public int PauseCount;

		[Token(Token = "0x4000A1E")]
		[FieldOffset(Offset = "0x48")]
		public double TotalPausedSeconds;

		[Token(Token = "0x4000A1F")]
		[FieldOffset(Offset = "0x50")]
		public int ManagerInterventionCount;

		[Token(Token = "0x6000E0C")]
		[Address(RVA = "0x3F03094", Offset = "0x3F03094", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.OrchestratorManifest+DiffTally>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.OrchestratorManifest+DiffTally>::.ctor(v48);\n\tthis.PerDifficulty = v48;\n")]
		public OrchestratorManifest()
		{
			List<DiffTally> perDifficulty = new List<DiffTally>();
			PerDifficulty = perDifficulty;
		}
	}
}
