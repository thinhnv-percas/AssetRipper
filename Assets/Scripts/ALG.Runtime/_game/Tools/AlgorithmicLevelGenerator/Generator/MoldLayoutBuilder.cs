using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000050")]
	public static class MoldLayoutBuilder
	{
		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x3C19D98", Offset = "0x3C19D98", Length = "0x410")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::.ctor(v75);\n\tv90 = moldCols + tapAlignedCellColors.Count;\n\tv91 = v90 - 1;\n\tv92 = v91 / moldCols;\n\tv104 = v92 < 1;\n\tif (v104) goto L_0148;\n\tv138 = 0;\n\tv247 = tapAlignedCellColors;\n\tgoto L_007E;\nL_006A:\n\tv138 = v138 + 1;\n\tv282 = v138 == v92;\n\tv247 = tapAlignedCellColors;\n\tif (v282) goto L_0148;\nL_007E:\n\tgoto L_0082;\nL_0082:\n\tv238 = v138 * moldCols;\n\tv418 = v247.Count - v238;\n\tv421 = System.Math::Min(moldCols, v418);\n\tv430 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::GetRange(v247, v238, v421);\n\tv436 = System.Linq.Enumerable::Range(0, moldCols);\n\tv218 = System.Linq.Enumerable::ToList(v436);\n\tv542 = v218.Count;\n\tv242 = v218.Count - 1;\n\tv145 = v242 < 1;\n\tif (v145) goto L_00E0;\n\tSystem.Collections.Generic.List`1<System.Int32>::set_Item(v218, v549, v560);\n\tv587 = v481 < 1;\n\tv466 = ~v587;\n\tv464 = v481 - 1;\n\tv460 = v464 == 0;\n\tv588 = ~v460;\n\tv450 = v466 & v588;\n\tv542 = v481;\n\tif (v450) goto L_00AD;\nL_00E0:\n\tv567 = 0xB291000 + 0xD78;\n\tv142 = v421 < 1;\n\tif (v142) goto L_006A;\n\tv487 = v430 == 0;\n\tif (v487) goto L_014A;\n\tv554 = v75 == 0;\n\tif (v554) goto L_0158;\n\tv248 = 0;\n\tgoto L_00FF;\nL_00F2:\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::Add(v75, v581);\n\tv248 = v248 + 1;\n\tv505 = v421 == v248;\n\tif (v505) goto L_006A;\nL_00FF:\n\tv581 = new _game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot();\n\tSystem.Object::.ctor(v581);\n\tv219 = System.Collections.Generic.List`1<System.Int32>::get_Item(v218, v248);\n\tv581.Col = v219;\n\tv581.Row = v138;\n\tv220 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::get_Item(v430, v248);\n\tv581.Color = v220;\n\tgoto L_00F2;\nL_0148:\n\treturn v75;\nL_014A:\n\tv556 = new _game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot();\n\tSystem.Object::.ctor(v556);\n\tv221 = System.Collections.Generic.List`1<System.Int32>::get_Item(v218, 0);\n\tv556.Col = v221;\n\tv556.Row = v138;\n\tthrow System.NullReferenceException;\nL_0158:\n\tv569 = new *([v567 @ X20_v12 (_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot)])();\n\tSystem.Object::.ctor(v569);\n\tv217 = System.Collections.Generic.List`1<System.Int32>::get_Item(v218, 0);\n\tv590 = v569 == 0;\n\tv223 = ~v590;\n\tv323 = v430;\n\tv329 = v138;\n\tv346 = v569;\n\tif (v223) goto L_0164;\n\tv249 = new System.NullReferenceException();\n\tv323 = v430;\n\tv329 = v138;\n\tv217 = v249;\n\tv346 = v569;\nL_0164:\n\t*([v346 @ X20_v3 (System.Object)+10]) = v217;\n\t*([v346 @ X20_v3 (System.Object)+14]) = v329;\n\tv355 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::get_Item(v323, 0);\n\t*([v346 @ X20_v3 (System.Object)+18]) = v355;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0047:\n\tv64 = new System.Random();\n\tSystem.Random::.ctor(v64, seed);\n\tv75 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>();\nL_00AD:\n\tv481 = v542 - 1;\n\tv549 = System.Random::Next(v64, v542);\n\tv553 = System.Collections.Generic.List`1<System.Int32>::get_Item(v218, v549);\n\tv560 = System.Collections.Generic.List`1<System.Int32>::get_Item(v218, v481);\n\tSystem.Collections.Generic.List`1<System.Int32>::set_Item(v218, v481, v553);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<MoldCellSlot> Build(List<SolverColor> tapAlignedCellColors, int moldCols, int seed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLayoutBuilder::Build");
			return default;
		}
	}
}
