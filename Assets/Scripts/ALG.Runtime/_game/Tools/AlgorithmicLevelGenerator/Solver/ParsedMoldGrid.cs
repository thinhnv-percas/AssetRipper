using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000018")]
	public class ParsedMoldGrid
	{
		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x10")]
		public int Columns;

		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x14")]
		public int Rows;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x18")]
		public List<ParsedMoldCell> Cells;

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3C0B508", Offset = "0x3C0B508", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedMoldCell>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedMoldCell>::.ctor(v48);\n\tthis.Cells = v48;\n")]
		public ParsedMoldGrid()
		{
			List<ParsedMoldCell> cells = new List<ParsedMoldCell>();
			Cells = cells;
		}
	}
}
