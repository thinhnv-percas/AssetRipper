using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000056")]
	public class PathingResult
	{
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x10")]
		public int AltWinPaths;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x14")]
		public int PeakAvailableCubes;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x18")]
		public bool GreedySolved;

		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x1C")]
		public int RolloutsRun;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x20")]
		public int RolloutsWon;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x28")]
		public List<List<(int Col, int Row)>> SampleWinningSequences;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x30")]
		public string Verdict;

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x3C1AFB8", Offset = "0x3C1AFB8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>>::.ctor(v48);\n\tthis.SampleWinningSequences = v48;\n")]
		public PathingResult()
		{
			List<List<(int, int)>> sampleWinningSequences = new List<List<(int, int)>>();
			SampleWinningSequences = sampleWinningSequences;
		}
	}
}
