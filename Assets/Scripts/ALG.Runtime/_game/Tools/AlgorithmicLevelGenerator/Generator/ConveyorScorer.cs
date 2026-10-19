using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000041")]
	public static class ConveyorScorer
	{
		[Token(Token = "0x2000042")]
		public struct ConveyorStats
		{
			[Token(Token = "0x400012C")]
			[FieldOffset(Offset = "0x0")]
			public double AvgPct;

			[Token(Token = "0x400012D")]
			[FieldOffset(Offset = "0x8")]
			public double PeakPct;

			[Token(Token = "0x400012E")]
			[FieldOffset(Offset = "0x10")]
			public int Steps;
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x3C17324", Offset = "0x3C17324", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv53 = v41.Count == 0;\n\tif (v53) goto L_0077;\n\tv136 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ConveyorTimelineEntry>::GetEnumerator(v41);\n\tv110 = v136._list;\n\tv100 = v136.Current;\n\tv95 = 0;\n\tv217 = v136.Current == 0;\n\tif (v217) goto L_0082;\n\t// 72 NotImplemented \"Instruction SMAX not yet implemented.\"\n\tv95 = v95 + v100.Total;\n\tgoto L_003F;\nL_0051:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v110 @ stack_-48_v3 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ConveyorTimelineEntry>));\nL_005F:\n\tv56 = v245 <= 0;\n\tif (v56) goto L_0077;\n\tv252 = v95 / v41.Count;\n\tv166 = v252 / v245;\n\tv163 = 0 / v245;\n\treturnBuffer.AvgPct = v166;\n\treturnBuffer.PeakPct = v163;\n\treturnBuffer.Steps = v41.Count;\n\t*([returnBuffer @ X8 (_game.Tools.AlgorithmicLevelGenerator.Generator.ConveyorScorer+ConveyorStats)+14]) = 0;\n\treturn returnBuffer;\nL_0077:\n\treturnBuffer.AvgPct = 0d;\n\treturnBuffer.PeakPct = 0d;\n\treturnBuffer.Steps = 0;\n\treturn returnBuffer;\nL_0082:\n\tv228 = new System.NullReferenceException();\n\tgoto L_008F;\nL_008F:\n\tv145 = Il2CppMethodInfo != 1;\n\tv170 = 0;\n\tv190 = v228;\n\tif (v145) goto L_00A1;\n\tv257 = 0x8BF5BC4(v228, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv263 = 0x8BF5BF4(v257, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v110 @ stack_-48_v3 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ConveyorTimelineEntry>));\n\tv241 = *([v257 @ X0_v18]) == 0;\n\tif (v241) goto L_005F;\n\tv259 = new System.OutOfMemoryException();\n\tv170 = *([v257 @ X0_v18]);\n\tv190 = v259;\n\treturn returnVal3;\nL_0021:\n\tv110 = 0;\n\tv48 = v41 == 0;\n\tif (v48) goto L_0077;\nL_003F:\n\tv215 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v110 @ stack_-48_v3 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ConveyorTimelineEntry>));\n\tv222 = v215 == 0;\n\tif (v222) goto L_0051;\nL_00A1:\n\tv262 = 0x317662C(&v170 @ stack_-58_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv265 = 0x8BF0368(v190, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal3 = 0xA1B8(v265, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ConveyorStats Measure(List<ConveyorTimelineEntry> timeline)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorScorer::Measure");
			return default;
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x3C174F4", Offset = "0x3C174F4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_002E;\nL_0049:\n\treturn 0xFFF0000000000000;\nL_001A:\n\tv50 = stats.PeakPct < 1d;\n\tv54 = stats.PeakPct == stats.PeakPct;\n\tv55 = 1d == 1d;\n\tv56 = v54 & v55;\n\tv57 = ~v56;\n\tv58 = v50 == v57;\n\tif (v58) goto L_0049;\nL_002E:\n\t// 46 NotImplemented \"Instruction FABD not yet implemented.\"\n\t// 47 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv81 = stats.PeakPct * 0.5d;\n\tv82 = 1d + v81;\n\treturnVal2 = -v82;\n\treturn returnVal2;\n")]
		public static double Score(ConveyorStats stats, double targetAvg, double targetPeak)
		{
			//IL_0014: Expected F8, but got I8
			bool flag = stats.PeakPct < 1.0;
			bool flag2 = stats.PeakPct == stats.PeakPct;
			bool flag3 = 1.0 == 1.0;
			bool flag4 = flag2 && flag3;
			bool flag5 = !flag4;
			if (flag == flag5)
			{
				return -4503599627370496.0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			double num = stats.PeakPct * 0.5;
			double num2 = 1.0 + num;
			return 0.0 - num2;
		}
	}
}
