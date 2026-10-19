using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Serializable]
	[Token(Token = "0x2000374")]
	public sealed class GenerationManifest
	{
		[Token(Token = "0x4000A69")]
		[FieldOffset(Offset = "0x10")]
		public string RunId;

		[Token(Token = "0x4000A6A")]
		[FieldOffset(Offset = "0x18")]
		public string Model;

		[Token(Token = "0x4000A6B")]
		[FieldOffset(Offset = "0x20")]
		public DateTime StartedUtc;

		[Token(Token = "0x4000A6C")]
		[FieldOffset(Offset = "0x28")]
		public DateTime FinishedUtc;

		[Token(Token = "0x4000A6D")]
		[FieldOffset(Offset = "0x30")]
		public int ToolCallCount;

		[Token(Token = "0x4000A6E")]
		[FieldOffset(Offset = "0x34")]
		public bool ClaudeFinished;

		[Token(Token = "0x4000A6F")]
		[FieldOffset(Offset = "0x35")]
		public bool SolverIsSolvable;

		[Token(Token = "0x4000A70")]
		[FieldOffset(Offset = "0x38")]
		public string FailureReason;

		[Token(Token = "0x4000A71")]
		[FieldOffset(Offset = "0x40")]
		public string DoneReason;

		[Token(Token = "0x4000A72")]
		[FieldOffset(Offset = "0x48")]
		public long InputTokens;

		[Token(Token = "0x4000A73")]
		[FieldOffset(Offset = "0x50")]
		public long OutputTokens;

		[Token(Token = "0x4000A74")]
		[FieldOffset(Offset = "0x58")]
		public long CacheCreationTokens;

		[Token(Token = "0x4000A75")]
		[FieldOffset(Offset = "0x60")]
		public long CacheReadTokens;

		[Token(Token = "0x4000A76")]
		[FieldOffset(Offset = "0x68")]
		public long TotalTokens;

		[Token(Token = "0x4000A77")]
		[FieldOffset(Offset = "0x70")]
		public List<string> LogTailLines;

		[Token(Token = "0x6000E40")]
		[Address(RVA = "0x3F08534", Offset = "0x3F08534", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v48);\n\tthis.LogTailLines = v48;\n")]
		public GenerationManifest()
		{
			List<string> logTailLines = new List<string>();
			LogTailLines = logTailLines;
		}
	}
}
