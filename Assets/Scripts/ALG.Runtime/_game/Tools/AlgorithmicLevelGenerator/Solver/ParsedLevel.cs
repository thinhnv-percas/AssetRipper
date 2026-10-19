using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000011")]
	public class ParsedLevel
	{
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x10")]
		public string LevelId;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x18")]
		public int GridCols;

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x1C")]
		public int GridRows;

		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x20")]
		public List<ParsedCube> Cubes;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x28")]
		public List<ParsedTunnel> Tunnels;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x30")]
		public HashSet<(int Col, int Row)> Walls;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x38")]
		public ParsedMoldGrid MoldGrid;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x40")]
		public List<int[][]> LinkedMolds;

		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x48")]
		public List<List<(int Col, int Row)>> LinkedSandGroups;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x50")]
		public List<int[][]> Bonds;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x58")]
		public int FrameConveyorCapacity;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x60")]
		public Dictionary<(int Col, int Row), ParsedSnakeSegment> SnakeSegments;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x68")]
		public List<ParsedPin> Pins;

		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x70")]
		public List<ParsedHammerArea> HammerAreas;

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x3C0B188", Offset = "0x3C0B188", Length = "0x380")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005D;\n\tv91 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedTunnel>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedTunnel>::.ctor(v91);\n\tthis.Tunnels = v91;\n\tv108 = new System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v108);\n\tthis.Walls = v108;\n\tv127 = new _game.Tools.AlgorithmicLevelGenerator.Solver.ParsedMoldGrid();\n\tgoto L_0092;\n\tSystem.Object::.ctor(v127);\n\tthis.MoldGrid = v127;\n\tv182 = new System.Collections.Generic.List`1<System.Int32[][]>();\n\tSystem.Collections.Generic.List`1<System.Int32[][]>::.ctor(v182);\n\tthis.LinkedMolds = v182;\n\tv190 = new System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>>::.ctor(v190);\n\tthis.LinkedSandGroups = v190;\n\tv200 = new System.Collections.Generic.List`1<System.Int32[][]>();\n\tSystem.Collections.Generic.List`1<System.Int32[][]>::.ctor(v200);\n\tthis.Bonds = v200;\n\tthis.FrameConveyorCapacity = 0xC;\n\tv211 = new System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Solver.ParsedSnakeSegment>();\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Solver.ParsedSnakeSegment>::.ctor(v211);\n\tthis.SnakeSegments = v211;\n\tv223 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedPin>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedPin>::.ctor(v223);\n\tthis.Pins = v223;\n\tv235 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>::.ctor(v235);\n\tthis.HammerAreas = v235;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_005D:\n\tv74 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedCube>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedCube>::.ctor(v74);\n\tthis.Cubes = v74;\nL_0092:\n\tv152 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedMoldCell>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedMoldCell>::.ctor(v152);\n\tv127.Cells = v152;\n")]
		public ParsedLevel()
		{
			List<ParsedCube> cubes = new List<ParsedCube>();
			Cubes = cubes;
			Tunnels = new List<ParsedTunnel>();
			Walls = new HashSet<(int, int)>();
			ParsedMoldGrid parsedMoldGrid = new ParsedMoldGrid();
			List<ParsedMoldCell> cells = new List<ParsedMoldCell>();
			parsedMoldGrid.Cells = cells;
			MoldGrid = parsedMoldGrid;
			LinkedMolds = new List<int[][]>();
			LinkedSandGroups = new List<List<(int, int)>>();
			Bonds = new List<int[][]>();
			FrameConveyorCapacity = 12;
			SnakeSegments = new Dictionary<(int, int), ParsedSnakeSegment>();
			Pins = new List<ParsedPin>();
			HammerAreas = new List<ParsedHammerArea>();
		}
	}
}
