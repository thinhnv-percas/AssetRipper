using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000016")]
	public class ParsedTunnel
	{
		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x18")]
		public TunnelDirection Direction;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x20")]
		public List<SolverColor> Queue;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x28")]
		public string OriginalSaveModelType;

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3C0B638", Offset = "0x3C0B638", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tthis.OriginalSaveModelType = \"TunnelCubeComponent\";\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0023:\n\tv54 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v54);\n\tthis.Queue = v54;\n")]
		public ParsedTunnel()
		{
			List<SolverColor> queue = new List<SolverColor>();
			Queue = queue;
			OriginalSaveModelType = "TunnelCubeComponent";
		}
	}
}
