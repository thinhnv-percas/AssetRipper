using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000053")]
	public static class PaletteGenerator
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000054")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000165")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000166")]
			public static Func<SolverColor, bool> _003C_003E9__1_0;

			[Token(Token = "0x60000DE")]
			[Address(RVA = "0x3C1AE5C", Offset = "0x3C1AE5C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Tools.AlgorithmicLevelGenerator.Generator.PaletteGenerator+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000DF")]
			[Address(RVA = "0x3C1AEC0", Offset = "0x3C1AEC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGenerate_003Eb__1_0(SolverColor c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PaletteGenerator._003C_003Ec::_003CGenerate_003Eb__1_0");
				return default;
			}
		}

		[Token(Token = "0x4000164")]
		public static readonly SolverColor[] AvailablePool = new SolverColor[11]
		{
			SolverColor.Red,
			SolverColor.Blue,
			SolverColor.Green,
			SolverColor.Yellow,
			SolverColor.Orange,
			SolverColor.Purple,
			SolverColor.Pink,
			SolverColor.Teal,
			SolverColor.Brown,
			SolverColor.LightGrey,
			SolverColor.DarkGrey
		};

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x3C1A8A4", Offset = "0x3C1A8A4", Length = "0x514")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004F;\n\tgoto L_0069;\n\tv111 = v167.Length < colorCount;\n\tif (v111) goto L_016E;\n\tgoto L_0088;\n\tgoto L_0096;\nL_00A7:\n\tv321 = System.Linq.Enumerable::Where(frozenColors, v253);\n\tv242 = System.Linq.Enumerable::ToList(v321);\n\tv199 = v242.Count > colorCount;\n\tif (v199) goto L_0189;\n\tv406 = new System.Random();\n\tSystem.Random::.ctor(v406, seed);\n\tv243 = new System.Collections.Generic.HashSet`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.HashSet`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v243, v242);\n\tv60.picked = v243;\n\tgoto L_00E3;\n\tv244 = System.Linq.Enumerable::ToList(v525);\n\tv578 = v244.Count;\n\tv261 = v244.Count - 1;\n\tv200 = v261 < 1;\n\tif (v200) goto L_012E;\n\tSystem.Collections.Generic.List`1<System.Int32Enum>::set_Item(v244, v584, v613);\n\tv627 = v549 < 1;\n\tv544 = ~v627;\n\tv543 = v549 - 1;\n\tv541 = v543 == 0;\n\tv628 = ~v541;\n\tv536 = v544 & v628;\n\tv578 = v549;\n\tif (v536) goto L_0106;\nL_012E:\n\tv245 = v60.picked;\n\tv257 = colorCount - v245.Count;\n\tv562 = v257 < 1;\n\tv604 = v245;\n\tif (v562) goto L_016A;\n\tv265 = 0;\n\tv617 = System.Collections.Generic.HashSet`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::Add(v60.picked, v246);\n\tv265 = v265 + 1;\n\tv593 = v257 != v265;\n\tif (v593) goto L_0146;\n\tv604 = v60.picked;\nL_016E:\n\tv158 = 0xB292000 + 0x8C0;\n\tv168 = 0x317666C(v158, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv279 = _game.Tools.AlgorithmicLevelGenerator.Solver.ParsedSnakeSegment;\n\tv280 = *([v279 @ X8_v5 (Il2CppClass<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedSnakeSegment>)]);\n\tv282 = 0x3175AC4(*([v279 @ X8_v5 (Il2CppClass<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedSnakeSegment>)]), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv351 = *([v280 @ X20_v7+18]);\n\tv298 = 0xB7D5000 + 0x538;\n\tv301 = \"il2cpp_vm_object_box\"(*([v298 @ X21_v5 (System.Int32)+48]), &v351 @ stack_-64_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv323 = colorCount;\n\tv326 = \"il2cpp_vm_object_box\"(*([v298 @ X21_v5 (System.Int32)+48]), &v323 @ stack_-68_v2 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv372 = 0xB308000 + 0xB98;\n\tv379 = v326;\n\tv383 = v301;\n\tgoto L_01A0;\nL_0189:\n\tv408 = 0x3175AC4(v242, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv351 = v242.Count;\n\tv382 = 0xB7D5000 + 0x538;\n\tv429 = \"il2cpp_vm_object_box\"(*([v382 @ X21_v8 (System.Int32)+48]), &v351 @ stack_-64_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv323 = colorCount;\n\tv436 = \"il2cpp_vm_object_box\"(*([v382 @ X21_v8 (System.Int32)+48]), &v323 @ stack_-68_v2 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv372 = 0xB2FD000 + 0xF68;\n\tv379 = v436;\n\tv383 = v429;\n\tv421 = new v411();\n\t_game.Tools.AlgorithmicLevelGenerator.Generator.GeneratorException::.ctor(v421, v397);\n\tthrow v421;\nL_004F:\n\tv60 = new _game.Tools.AlgorithmicLevelGenerator.Generator.PaletteGenerator+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v60);\n\tv79 = colorCount < 1;\n\tif (v79) goto L_016E;\nL_0069:\n\tv167 = v166.AvailablePool;\nL_0088:\n\tv293 = v291.<>9__1_0 == 0;\n\tv294 = ~v293;\n\tv253 = v291.<>9__1_0;\n\tif (v294) goto L_00A7;\nL_0096:\n\tv337 = new System.Func`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Boolean>();\n\tSystem.Func`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Boolean>::.ctor(v337, v332.<>9, Il2CppMethodInfo);\n\tv389.<>9__1_0 = v337;\n\tv253 = v337;\nL_00E3:\n\tv520 = new System.Func`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Boolean>();\n\tSystem.Func`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Boolean>::.ctor(v520, v60, Il2CppMethodInfo);\n\tv525 = System.Linq.Enumerable::Where(v517.AvailablePool, v520);\nL_0106:\n\tv549 = v578 - 1;\n\tv584 = System.Random::Next(v406, v578);\n\tv588 = System.Collections.Generic.List`1<System.Int32Enum>::get_Item(v244, v584);\n\tv613 = System.Collections.Generic.List`1<System.Int32Enum>::get_Item(v244, v549);\n\tSystem.Collections.Generic.List`1<System.Int32Enum>::set_Item(v244, v549, v588);\nL_016A:\n\treturnVal2 = System.Linq.Enumerable::ToArray(v604);\n\treturn returnVal2;\nL_0146:\n\tv246 = System.Collections.Generic.List`1<System.Int32Enum>::get_Item(v244, v265);\nL_01A0:\n\tv397 = System.String::Format(v372, v383, v379);\n\tv411 = 0xB28E000 + 0xA68;\n")]
		public static SolverColor[] Generate(int colorCount, HashSet<SolverColor> frozenColors, Difficulty difficulty, int seed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaletteGenerator::Generate");
			return default;
		}
	}
}
