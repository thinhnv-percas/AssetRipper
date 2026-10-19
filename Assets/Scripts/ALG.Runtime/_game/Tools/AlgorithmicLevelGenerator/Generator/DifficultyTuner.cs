using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000049")]
	public static class DifficultyTuner
	{
		[Token(Token = "0x200004A")]
		public struct Band
		{
			[Token(Token = "0x4000143")]
			[FieldOffset(Offset = "0x0")]
			public double MinPct;

			[Token(Token = "0x4000144")]
			[FieldOffset(Offset = "0x8")]
			public double MaxPct;
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x3C19B28", Offset = "0x3C19B28", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = d < 3;\n\tv2 = ~v0;\n\tv3 = d - 3;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_0018;\n\treturn d;\nL_0018:\n\treturn d;\n")]
		public static Band ConveyorTargetBand(Difficulty d)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DifficultyTuner::ConveyorTargetBand");
			return default;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x3C19B64", Offset = "0x3C19B64", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv59 = d == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_0036:\n\tv64 = d == 2;\n\tif (v64) goto L_FFFFFFFF;\n\tv91 = d != 3;\n\tif (v91) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv133 = 0.5000000000873115d;\nL_FFFFFFFF:\n\tv135 = 0x7FEE666666666666;\nL_FFFFFFFF:\n\treturnVal1 = &v111 @ stack_-40_v4;\n\tgoto L_005E;\nL_FFFFFFFF:\n\tv133 = 0.5d;\nL_FFFFFFFF:\n\tv135 = 0x3FF3333333333333;\nL_FFFFFFFF:\n\treturnVal1 = &v111 @ stack_-40_v4;\n\tgoto L_005E;\nL_FFFFFFFF:\n\tv133 = 0.2d;\nL_FFFFFFFF:\n\tv135 = 0.4d;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv133 = 0x7FE6666666666666;\nL_FFFFFFFF:\n\tv135 = 0.8d;\nL_0024:\n\tv58 = d > 1;\n\tif (v58) goto L_0036;\nL_005E:\n\tSystem.ValueTuple`2<System.Double, System.Double>::.ctor(returnVal1, v133, v135);\n\treturn returnVal1;\nL_FFFFFFFF:\n\treturnVal1 = &v111 @ stack_-40_v4;\n")]
		public unsafe static (double, double) ConveyorTargets(Difficulty d)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DifficultyTuner::ConveyorTargets");
			return default;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x3C19C48", Offset = "0x3C19C48", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = d < 3;\n\tv2 = ~v0;\n\tv3 = d - 3;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_0012;\n\tv13 = 0x9307000 + 0x9F0;\n\treturn *([v13 @ X8_v3 (System.Int32)+d @ X0 (_game.Tools.AlgorithmicLevelGenerator.Generator.Difficulty)*8]);\nL_0012:\n\treturn 0.8d;\n")]
		public static double CoverCounterFactor(Difficulty d)
		{
			//IL_0079: Expected F8, but got I
			bool flag = (uint)d < 3u;
			bool flag2 = !flag;
			int num = (int)(d - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 154169344 + 2544;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v3 (System.Int32)+d @ X0 (_game.Tools.AlgorithmicLevelGenerator.Generator.Difficulty)*8]");
				return 0.0;
			}
			return 0.8;
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x3C19C6C", Offset = "0x3C19C6C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = d == 0;\n\tv11 = ~v5;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\n\treturnVal1 = 2 + 1;\n\tgoto L_0011;\nL_FFFFFFFF:\n\treturnVal1 = 2;\nL_0011:\n\treturn returnVal1;\n")]
		public static int PeakAvailableThreshold(Difficulty d)
		{
			if (d != Difficulty.Easy)
			{
				return 2 + 1;
			}
			return 2;
		}
	}
}
