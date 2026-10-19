using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000058")]
	public static class PathingValidator
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000059")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000173")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000174")]
			public static Func<(int Col, int Row), string> _003C_003E9__1_0;

			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x3C1BB5C", Offset = "0x3C1BB5C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Tools.AlgorithmicLevelGenerator.Generator.PathingValidator+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x3C1BBC0", Offset = "0x3C1BBC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CValidate_003Eb__1_0((int Col, int Row) s)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PathingValidator._003C_003Ec::_003CValidate_003Eb__1_0");
				return default;
			}
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x3C1B0FC", Offset = "0x3C1B0FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.Tools.AlgorithmicLevelGenerator.Generator.PathingValidator::Validate(initialState, rolloutCount, baseSeed, 3);\n\treturn returnVal1;\n")]
		public static PathingResult Validate(GameState initialState, int rolloutCount, int baseSeed)
		{
			return Validate(initialState, rolloutCount, baseSeed, 3);
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x3C1B104", Offset = "0x3C1B104", Length = "0x6B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0057;\n\tSystem.Object::.ctor(v65);\n\tv65.RolloutsRun = rolloutCount;\n\tv115 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v115);\n\tv323 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Solver.GridCube>::get_Count(initialState.Grid);\n\tv189 = rolloutCount < 1;\n\tif (v189) goto L_014A;\n\tv610 = baseSeed * 0x1EEF;\n\tv180 = v323 + 0x10;\n\tv267 = _game.Tools.AlgorithmicLevelGenerator.Generator.RolloutStrategy::RunRandomized(initialState, v610, v180);\n\tv482 = v267.PeakAvailable <= v65.PeakAvailableCubes;\n\tif (v482) goto L_00B9;\n\tv65.PeakAvailableCubes = v267.PeakAvailable;\n\tv533 = v65.RolloutsWon + 1;\n\tv65.RolloutsWon = v533;\n\tgoto L_00CA;\nL_00CA:\n\tv583 = v578.<>9__1_0 == 0;\n\tv584 = ~v583;\n\tv155 = v578.<>9__1_0;\n\tv163 = v267.Steps;\n\tv285 = \"|\";\n\tif (v584) goto L_00FB;\n\tv285 = \"|\";\n\tgoto L_00DE;\nL_00DE:\n\tgoto L_00E7;\n\tv155 = v666;\n\tv163 = v267.Steps;\n\tv560 = System.Collections.Generic.HashSet`1<System.String>::Add(v115, v268);\n\tv561 = ~v560;\n\tv253 = initialState;\n\tif (v561) goto L_013A;\n\tv286 = *([v102 @ X0_v8]);\n\tv269 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v269, v267.Steps);\n\tv780 = *([v286 @ X19_v18+1C]) + 1;\n\t*([v286 @ X19_v18+1C]) = v780;\n\tv169 = *([v286 @ X19_v18+10]);\n\tv790 = *([v286 @ X19_v18+18]) < *([v169 @ X9_v25+18]);\n\tv556 = ~v790;\n\tif (v556) goto L_018F;\n\tv563 = *([v286 @ X19_v18+18]) + 1;\n\t*([v286 @ X19_v18+18]) = v563;\n\tv539 = *([v286 @ X19_v18+18]) << 3;\n\tv799 = v169 + v539;\n\tv800 = v799 + 0x20;\n\t*([v800 @ X0_v68]) = v269;\n\tv253 = initialState;\nL_013A:\n\tv65.GreedySolved = v267.Won;\n\tv305 = rolloutCount - 1;\n\tv412 = rolloutCount != 1;\n\tif (v412) goto L_019D;\nL_014A:\n\tv65.AltWinPaths = v115.Count;\n\tv375 = v65.RolloutsWon == 0;\n\tif (v375) goto L_016C;\n\tv494 = v115.Count <= 1;\n\tif (v494) goto L_016F;\n\tv513 = v65.PeakAvailableCubes >= peakThreshold;\n\tif (v513) goto L_0176;\n\tv574 = 0xB30D000 + 0x100;\n\tgoto L_0178;\nL_016C:\n\tv525 = 0xB30D000 + 0xF50;\n\tgoto L_0173;\nL_016F:\n\tv525 = 0xB30D000 + 0xF8;\nL_0176:\n\tv574 = 0xB30E000 + 0x3E0;\nL_018F:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v286, v269);\n\tv65.GreedySolved = v267.Won;\n\tv426 = rolloutCount == 1;\n\tv305 = rolloutCount - 1;\n\tv253 = initialState;\n\tif (v426) goto L_014A;\nL_019D:\n\tv308 = v610 + 0x1F;\n\tv402 = 0xB29A000 + 0xE28;\n\tgoto L_01B3;\nL_01A6:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v290, v273);\n\tv253 = initialState;\nL_01A7:\n\tv308 = v308 + 0x1F;\n\tv427 = v305 == 1;\n\tv305 = v305 - 1;\n\tif (v427) goto L_014A;\nL_01B3:\n\tv184 = v323 + 0x10;\n\tv271 = _game.Tools.AlgorithmicLevelGenerator.Generator.RolloutStrategy::RunRandomized(v253, v308, v184);\n\tv680 = v271.PeakAvailable <= v65.PeakAvailableCubes;\n\tif (v680) goto L_01D4;\n\tv65.PeakAvailableCubes = v271.PeakAvailable;\n\tv692 = v65.RolloutsWon + 1;\n\tv65.RolloutsWon = v692;\n\tv693 = *([v402 @ X28_v15 (System.Int32)]);\n\tv695 = *([v693 @ X0_v30+E4]) == 0;\n\tif (v695) goto L_01E8;\n\tv783 = *([v693 @ X0_v30+B8]);\n\tv159 = *([v783 @ X8_v49+8]);\n\tv738 = *([v783 @ X8_v49+8]) == 0;\n\tv739 = ~v738;\n\tv289 = \"|\";\n\tif (v739) goto L_0214;\n\tv758 = \"|\";\n\tgoto L_01F4;\nL_01E8:\n\tv754 = *([v402 @ X28_v15 (System.Int32)]);\n\tv783 = *([v754 @ X0_v53+B8]);\n\tv159 = *([v783 @ X8_v49+8]);\n\tv769 = *([v783 @ X8_v49+8]) == 0;\n\tv757 = ~v769;\n\tv758 = \"|\";\n\tv289 = \"|\";\n\tif (v757) goto L_0214;\nL_01F4:\n\tgoto L_01FE;\n\tv159 = v789;\n\tv253 = initialState;\n\tv289 = v758;\n\tv722 = System.Collections.Generic.HashSet`1<System.String>::Add(v115, v272);\n\tv402 = 0xB29A000 + 0xE28;\n\tv724 = ~v722;\n\tif (v724) goto L_01A7;\n\tv290 = *([v102 @ X0_v8]);\n\tv273 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v273, v271.Steps);\n\tv817 = *([v290 @ X19_v11+1C]) + 1;\n\t*([v290 @ X19_v11+1C]) = v817;\n\tv173 = *([v290 @ X19_v11+10]);\n\tv818 = *([v290 @ X19_v11+18]) < *([v173 @ X9_v13+18]);\n\tv716 = ~v818;\n\tif (v716) goto L_01A6;\n\tv727 = *([v290 @ X19_v11+18]) + 1;\n\t*([v290 @ X19_v11+18]) = v727;\n\tv696 = *([v290 @ X19_v11+18]) << 3;\n\tv819 = v173 + v696;\n\tv820 = v819 + 0x20;\n\t*([v820 @ X0_v41]) = v273;\n\tv253 = initialState;\n\tgoto L_01A7;\nL_0057:\n\tv65 = new _game.Tools.AlgorithmicLevelGenerator.Generator.PathingResult();\n\tgoto L_006C;\nL_006C:\n\tv90 = new System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>>::.ctor(v90);\n\tv102 = v65 + 0x28;\n\tv65.SampleWinningSequences = v90;\nL_00B9:\n\tv190 = v267.Won != 1;\n\tv253 = initialState;\n\tif (v190) goto L_013A;\nL_00FB:\n\tv642 = System.Linq.Enumerable::Select(v163, v155);\n\tv268 = System.String::Join(v285, v642);\nL_00E7:\n\tv666 = new System.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.String>();\n\tSystem.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.String>::.ctor(v666, v660.<>9, Il2CppMethodInfo);\n\tv689.<>9__1_0 = v666;\nL_0178:\n\tv65.Verdict = *([v574 @ X8_v17 (System.Int32)]);\nL_0173:\n\tv65.Verdict = *([v525 @ X8_v11 (System.Int32)]);\n\tgoto L_0189;\nL_01D4:\n\tv193 = v271.Won != 1;\n\tif (v193) goto L_01A7;\nL_0214:\n\tv767 = System.Linq.Enumerable::Select(v271.Steps, v159);\n\tv272 = System.String::Join(v289, v767);\nL_01FE:\n\tv789 = new System.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.String>();\n\tSystem.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.String>::.ctor(v789, *([v783 @ X8_v49]), Il2CppMethodInfo);\n\tv805.<>9__1_0 = v789;\nL_0189:\n\treturn v65;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PathingResult Validate(GameState initialState, int rolloutCount, int baseSeed, int peakThreshold)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PathingValidator::Validate");
			return default;
		}
	}
}
