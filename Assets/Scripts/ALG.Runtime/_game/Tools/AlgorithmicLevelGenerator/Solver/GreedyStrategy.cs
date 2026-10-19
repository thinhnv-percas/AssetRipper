using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000009")]
	public static class GreedyStrategy
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000037")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000038")]
			public static Comparison<(double Score, int Col, int Row)> _003C_003E9__0_0;

			[Token(Token = "0x6000034")]
			[Address(RVA = "0x3C0AAA8", Offset = "0x3C0AAA8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Tools.AlgorithmicLevelGenerator.Solver.GreedyStrategy+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000035")]
			[Address(RVA = "0x3C0AB0C", Offset = "0x3C0AB0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal unsafe int _003CChooseNextCube_003Eb__0_0((double Score, int Col, int Row) a, (double Score, int Col, int Row) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GreedyStrategy._003C_003Ec::_003CChooseNextCube_003Eb__0_0");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000B")]
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			[Token(Token = "0x4000039")]
			[FieldOffset(Offset = "0x10")]
			public GameState state;

			[Token(Token = "0x6000037")]
			[Address(RVA = "0x3C09FF4", Offset = "0x3C09FF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass0_0()
			{
			}
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x3C079E4", Offset = "0x3C079E4", Length = "0x2610")]
		public unsafe static (int, int)? ChooseNextCube(GameState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GreedyStrategy::ChooseNextCube");
			return default;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x3C09FFC", Offset = "0x3C09FFC", Length = "0x73C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0064;\n\tv86 = state.Grid == 0;\nL_FFFFFFFF:\n\tv170 = v171;\nL_FFFFFFFF:\n\tv241 = Il2CppMethodInfo;\n\tif (v86) goto L_01E8;\n\tv248 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Solver.GridCube>::get_Values(state.Grid);\n\tv253 = v248 == 0;\nL_FFFFFFFF:\n\tv170 = v171;\nL_FFFFFFFF:\n\tv241 = Il2CppMethodInfo;\n\tif (v253) goto L_01E8;\n\tv294 = &v226 @ stack_-110 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>);\n\tv295 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Solver.GridCube>+ValueCollection<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Solver.GridCube>::GetEnumerator(v248);\n\tv226 = *([v294 @ X8_v24]);\n\tv207 = *([v294 @ X8_v24+10]);\n\tv193 = *([v294 @ X8_v24]);\n\tv226 = 0;\n\tv316 = v72 == 0;\n\tif (v316) goto L_00C4;\n\tv471 = *([v294 @ X8_v24+10]) == 0;\nL_FFFFFFFF:\n\tv528 = Il2CppMethodInfo;\n\tif (v471) goto L_01E0;\n\tv345 = *([v207 @ stack_-100_v8+18]) == 0;\n\tif (v345) goto L_009F;\n\tv625 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::ContainsKey(v72, *([v207 @ stack_-100_v8+18]));\n\tv669 = v625 == 0;\n\tv346 = ~v669;\n\tif (v346) goto L_00B5;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v72, *([v207 @ stack_-100_v8+18]), 0);\nL_00B5:\n\t;\n\tv752 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(v72, *([v207 @ stack_-100_v8+18]));\n\tv337 = v752 + 3;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v72, *([v207 @ stack_-100_v8+18]), v337);\n\tgoto L_009F;\n\tv477 = *([v294 @ X8_v24+10]) == 0;\nL_FFFFFFFF:\n\tv528 = Il2CppMethodInfo;\n\tif (v477) goto L_01E0;\n\tv357 = *([v207 @ stack_-100_v8+18]) == 0;\n\tif (v357) goto L_00C4;\n\tv634 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv151 = &v499 @ stack_-A0_v7 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>);\nL_FFFFFFFF:\n\tv156 = 0;\nL_FFFFFFFF:\n\tv171 = state;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv241 = Il2CppMethodInfo;\n\tgoto L_01E7;\nL_00D1:\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Object>+ValueCollection<System.ValueTuple`2<System.Int32, System.Int32>, System.Object>+Enumerator<System.ValueTuple`2<System.Int32, System.Int32>, System.Object>::Dispose(&v193 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>));\n\tv254 = state.Tunnels == 0;\nL_FFFFFFFF:\n\tv170 = state;\nL_FFFFFFFF:\n\tv226 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv241 = Il2CppMethodInfo;\n\tif (v254) goto L_01E8;\n\tv632 = &v226 @ stack_-110 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>);\n\tv633 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.Tunnel>::GetEnumerator(state.Tunnels);\n\tv226 = *([v632 @ X8_v31]);\n\tv728 = *([v632 @ X8_v31+10]);\n\tv499 = *([v632 @ X8_v31]);\n\tv714 = *([v632 @ X8_v31+10]) == 0;\n\tif (v714) goto L_01E4;\n\tv829 = System.Collections.Generic.Queue`1<System.Int32Enum>::GetEnumerator(*([v728 @ stack_-100_v9+20]));\n\tv226 = *([v829 @ X0_v62]);\n\tv681 = *([v829 @ X0_v62]);\n\tv841 = v72 == 0;\n\tif (v841) goto L_0133;\nL_0110:\n\tv864 = System.Collections.Generic.Queue`1<System.Int32Enum>+Enumerator<System.Int32Enum>::MoveNext(&v681 @ stack_-C0_v9 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>));\n\tv888 = v864 == 0;\n\tif (v888) goto L_0142;\n\tv855 = System.Collections.Generic.Queue`1<System.Int32Enum>+Enumerator<System.Int32Enum>::get_Current(&v681 @ stack_-C0_v9 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>));\n\tv858 = v855 == 0;\n\tif (v858) goto L_0110;\n\tv902 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::ContainsKey(v72, v855);\n\tv905 = v902 == 0;\n\tv859 = ~v905;\n\tif (v859) goto L_012A;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v72, v855, 0);\nL_012A:\n\tv918 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(v72, v855);\n\tv850 = v918 + 3;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v72, v855, v850);\n\tgoto L_0110;\nL_0133:\n\tv871 = System.Collections.Generic.Queue`1<System.Int32Enum>+Enumerator<System.Int32Enum>::MoveNext(&v681 @ stack_-C0_v9 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>));\n\tv889 = ~v871;\n\tif (v889) goto L_0142;\n\tv867 = System.Collections.Generic.Queue`1<System.Int32Enum>+Enumerator<System.Int32Enum>::get_Current(&v681 @ stack_-C0_v9 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>));\n\tv711 = v867 == 0;\n\tif (v711) goto L_0133;\n\tv706 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv151 = v150;\nL_FFFFFFFF:\n\tv226 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv241 = Il2CppMethodInfo;\n\tgoto L_01E7;\nL_FFFFFFFF:\n\tv226 = 0;\n\tgoto L_00F1;\nL_FFFFFFFF:\n\tv226 = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv226 = 0;\nL_FFFFFFFF:\n\tv259 = 6;\n\tgoto L_0173;\nL_FFFFFFFF:\n\tv259 = 0xB;\nL_017B:\n\tv131 = v259 == 0xB;\n\tif (v131) goto L_0185;\n\tv538 = v259 == 0;\n\tv539 = ~v538;\n\tif (v539) goto L_01DF;\nL_0185:\n\tv255 = v186.ConveyorPool == 0;\nL_FFFFFFFF:\n\tv150 = v151;\nL_FFFFFFFF:\n\tv170 = v171;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v255) goto L_01E8;\n\tv664 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::GetEnumerator(v186.ConveyorPool);\n\tv226 = v664._dictionary;\n\tv636 = v664._dictionary;\n\tv737 = v72 == 0;\n\tif (v737) goto L_01C4;\n\tv790 = *([v664 @ X0_v28 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>+Enumerator<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>)+10]) == 0;\n\tif (v790) goto L_01A1;\n\tv835 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::ContainsKey(v72, *([v664 @ X0_v28 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>+Enumerator<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>)+10]));\n\tv843 = v835 == 0;\n\tv791 = ~v843;\n\tif (v791) goto L_01B6;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v72, *([v664 @ X0_v28 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>+Enumerator<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>)+10]), 0);\nL_01B6:\n\t;\n\tv883 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(v72, *([v664 @ X0_v28 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>+Enumerator<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>)+10]));\n\tv780 = v883 + v831;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v72, *([v664 @ X0_v28 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>+Enumerator<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>)+10]), v780);\n\tgoto L_01A1;\n\tv712 = \n// ... truncated")]
		private unsafe static Dictionary<SolverColor, int> ComputeSupplyInCells(GameState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GreedyStrategy::ComputeSupplyInCells");
			return default;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x3C0A738", Offset = "0x3C0A738", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv77 = state.MoldColumns == 0;\n\tv147 = Il2CppMethodInfo;\n\tif (v77) goto L_0106;\n\tv169 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldColumn>::GetEnumerator(state.MoldColumns);\n\tv133 = v169.Current;\n\tv126 = v169._list;\n\tv178 = v63 == 0;\n\tif (v178) goto L_00BB;\n\tv258 = v133.Cells;\n\tv361 = v133.Cells == 0;\n\tv148 = Il2CppMethodInfo;\n\tif (v361) goto L_0100;\n\tv268 = v133.ActiveIdx;\n\tgoto L_0085;\nL_0077:\n\tv268 = v268 + 1;\n\tv258 = v133.Cells;\n\tv524 = v133.Cells == 0;\n\tif (v524) goto L_0100;\nL_0085:\n\tv236 = v268 >= v258.Count;\n\tif (v236) goto L_006B;\n\tv589 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::get_Item(v258, v268);\n\tv592 = v589 == 0;\n\tif (v592) goto L_0102;\n\tv500 = v589.Fill < 0x3F7FBE77;\n\tv595 = v589.Fill == v589.Fill;\n\tv489 = ~v595;\n\tv486 = v500 == v489;\n\tv148 = v268;\n\tif (v486) goto L_0077;\n\tv600 = v589.Color == 0;\n\tv148 = v589.Color;\n\tif (v600) goto L_0077;\n\tv612 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::ContainsKey(v63, v589.Color);\n\tv614 = v612 == 0;\n\tv607 = ~v614;\n\tif (v607) goto L_00AC;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v63, v589.Color, 0);\nL_00AC:\n\tv626 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(v63, v589.Color);\n\tv602 = v626 + 1;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v63, v589.Color, v602);\n\tv148 = v589.Color;\n\tgoto L_0077;\n\tv301 = v133.Cells;\n\tv437 = v133.Cells == 0;\n\tv148 = Il2CppMethodInfo;\n\tif (v437) goto L_0100;\n\tv307 = v133.ActiveIdx;\n\tgoto L_00D4;\nL_00C6:\n\tv307 = v307 + 1;\n\tv301 = v133.Cells;\n\tv525 = v133.Cells == 0;\n\tv148 = v307;\n\tif (v525) goto L_0100;\nL_00D4:\n\tv277 = v307 >= v301.Count;\n\tif (v277) goto L_00BB;\n\tv590 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::get_Item(v301, v307);\n\tv593 = v590 == 0;\n\tif (v593) goto L_0102;\n\tv501 = v590.Fill < 0x3F7FBE77;\n\tv598 = v590.Fill == v590.Fill;\n\tv490 = ~v598;\n\tv487 = v501 == v490;\n\tif (v487) goto L_00C6;\n\tv557 = v590.Color == 0;\n\tif (v557) goto L_00C6;\n\tv555 = new System.NullReferenceException();\n\tv148 = v381;\n\tgoto L_0105;\nL_00F0:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v126 @ stack_-80_v4 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldColumn>));\nL_00FF:\n\treturn v63;\nL_0100:\n\tv534 = new System.NullReferenceException();\n\tv148 = v307;\n\tgoto L_0105;\nL_0102:\n\tv556 = new System.NullReferenceException();\n\tgoto L_0105;\nL_0105:\n\t// 261 Interrupt\n\tv146 = 0;\n\tv147 = v148;\nL_011B:\n\tv188 = v147 != 1;\n\tif (v188) goto L_012C;\n\tv210 = 0x8BF5BC4(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv311 = 0x8BF5BF4(v210, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v126 @ stack_-80_v4 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldColumn>));\n\tv218 = *([v210 @ X0_v12]) == 0;\n\tif (v218) goto L_00FF;\n\tv216 = new System.OutOfMemoryException();\n\tv146 = *([v210 @ X0_v12]);\n\tv161 = v216;\nL_012C:\n\tv225 = 0x3175D98(&v146 @ stack_-98 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv313 = 0x8BF0368(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v313, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0040:\n\tv63 = new System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::.ctor(v63);\n\tv72 = state == 0;\n\tv147 = Il2CppMethodInfo;\n\tif (v72) goto L_0106;\nL_0106:\n\tv161 = new System.NullReferenceException();\n\tgoto L_011B;\nL_006B:\n\tv271 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v126 @ stack_-80_v4 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldColumn>));\n\tv318 = v271 == 0;\n\tif (v318) goto L_00F0;\nL_00BB:\n\tv310 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v126 @ stack_-80_v4 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldColumn>));\n\tv319 = ~v310;\n\tif (v319) goto L_00F0;\n")]
		private unsafe static Dictionary<SolverColor, int> ComputeDemandInCells(GameState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GreedyStrategy::ComputeDemandInCells");
			return default;
		}
	}
}
