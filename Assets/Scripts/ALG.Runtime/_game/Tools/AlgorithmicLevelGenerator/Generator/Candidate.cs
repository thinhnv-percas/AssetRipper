using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000036")]
	public class Candidate
	{
		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x10")]
		public ParsedLevel Level;

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x18")]
		public List<(int Col, int Row)> TapOrder;

		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x20")]
		public List<int> LayerIndexPerTap;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x28")]
		public int RetryCount;

		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x30")]
		public string GeneratedFromTemplate;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x38")]
		public GeneratorConfig ConfigUsed;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x40")]
		public SolverResult VerificationResult;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x48")]
		public PathingResult Pathing;

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x3C10C48", Offset = "0x3C10C48", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v72);\n\tthis.LayerIndexPerTap = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v56);\n\tthis.TapOrder = v56;\n")]
		public Candidate()
		{
			List<(int, int)> tapOrder = new List<(int, int)>();
			TapOrder = tapOrder;
			List<int> layerIndexPerTap = new List<int>();
			LayerIndexPerTap = layerIndexPerTap;
		}
	}
}
