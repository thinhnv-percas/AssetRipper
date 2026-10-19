using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000038")]
	public class WalkResult
	{
		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x10")]
		public bool Success;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x18")]
		public string FailReason;

		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x20")]
		public List<SolverColor> CubeColors;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x28")]
		public List<SolverColor> MoldCellColors;

		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x30")]
		public ConstructiveSimulator FinalSim;

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x3C10D38", Offset = "0x3C10D38", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv58 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v58);\n\tthis.MoldCellColors = v58;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v48);\n\tthis.CubeColors = v48;\n")]
		public WalkResult()
		{
			List<SolverColor> cubeColors = new List<SolverColor>();
			CubeColors = cubeColors;
			List<SolverColor> moldCellColors = new List<SolverColor>();
			MoldCellColors = moldCellColors;
		}
	}
}
