using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PlayReport
{
	[Token(Token = "0x200034F")]
	public sealed class PlayReportModel
	{
		[Token(Token = "0x2000350")]
		public sealed class PlayedStep
		{
			[Token(Token = "0x40009BF")]
			[FieldOffset(Offset = "0x10")]
			public int X;

			[Token(Token = "0x40009C0")]
			[FieldOffset(Offset = "0x14")]
			public int Y;

			[Token(Token = "0x40009C1")]
			[FieldOffset(Offset = "0x18")]
			public string Color;

			[Token(Token = "0x40009C2")]
			[FieldOffset(Offset = "0x20")]
			public int Occupancy;

			[Token(Token = "0x6000DEF")]
			[Address(RVA = "0x3F0046C", Offset = "0x3F0046C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.Color = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public PlayedStep()
			{
				Color = "";
			}
		}

		[Token(Token = "0x2000351")]
		public sealed class IntendedStep
		{
			[Token(Token = "0x40009C3")]
			[FieldOffset(Offset = "0x10")]
			public int X;

			[Token(Token = "0x40009C4")]
			[FieldOffset(Offset = "0x14")]
			public int Y;

			[Token(Token = "0x40009C5")]
			[FieldOffset(Offset = "0x18")]
			public string Color;

			[Token(Token = "0x6000DF0")]
			[Address(RVA = "0x3F004D0", Offset = "0x3F004D0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.Color = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public IntendedStep()
			{
				Color = "";
			}
		}

		[Token(Token = "0x40009B7")]
		[FieldOffset(Offset = "0x10")]
		public LevelPlayMode Mode;

		[Token(Token = "0x40009B8")]
		[FieldOffset(Offset = "0x18")]
		public string LevelId;

		[Token(Token = "0x40009B9")]
		[FieldOffset(Offset = "0x20")]
		public bool Won;

		[Token(Token = "0x40009BA")]
		[FieldOffset(Offset = "0x24")]
		public int TapCount;

		[Token(Token = "0x40009BB")]
		[FieldOffset(Offset = "0x28")]
		public PlayedStep[] PlayedSteps;

		[Token(Token = "0x40009BC")]
		[FieldOffset(Offset = "0x30")]
		public IntendedStep[] IntendedSteps;

		[Token(Token = "0x40009BD")]
		[FieldOffset(Offset = "0x38")]
		public int FirstDivergenceStep;

		[Token(Token = "0x40009BE")]
		[FieldOffset(Offset = "0x3C")]
		public int DivergentStepCount;

		[Token(Token = "0x6000DEE")]
		[Address(RVA = "0x3F002C4", Offset = "0x3F002C4", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0027:\n\tv59 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+PlayedStep>>;\n\tv62 = *([v59 @ X0_v39 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+PlayedStep>>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv74 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+PlayedStep>>;\n\tif (v63) goto L_0074;\nL_002F:\n\tgoto L_0039;\nL_0039:\n\tgoto L_003F;\nL_003F:\n\tthis.PlayedSteps = v103.Value;\n\tgoto L_0045;\nL_0045:\n\tv111 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+IntendedStep>>;\n\tv114 = *([v111 @ X0_v36 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+IntendedStep>>)+135]) & 1;\n\tv115 = v114 == 0;\n\tv126 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+IntendedStep>>;\n\tif (v115) goto L_0085;\nL_004D:\n\tgoto L_0055;\nL_0055:\n\tgoto L_005B;\nL_005B:\n\tthis.IntendedSteps = v161.Value;\n\tthis.FirstDivergenceStep = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tv65 = System.Array::Empty();\n\tv67 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+PlayedStep>>;\n\tv80 = *([v67 @ X0_v11 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+PlayedStep>>)+135]) & 1;\n\tv81 = v80 == 0;\n\tv69 = ~v81;\n\tv74 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+PlayedStep>>;\n\tif (v69) goto L_002F;\nL_0074:\n\tv77 = 0x220C238(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0039;\n\tv117 = System.Array::Empty();\n\tv119 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+IntendedStep>>;\n\tv132 = *([v119 @ X0_v25 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+IntendedStep>>)+135]) & 1;\n\tv133 = v132 == 0;\n\tv121 = ~v133;\n\tv126 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+IntendedStep>>;\n\tif (v121) goto L_004D;\nL_0085:\n\tv129 = 0x220C238(v126, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = *([v129 @ X0_v22+E4]) == 0;\n\tv136 = ~v150;\n\tif (v136) goto L_0055;\n\tgoto L_0092;\nL_0092:\n\tgoto L_005B;\nL_0021:\n\tthis.LevelId = \"\";\n\tgoto L_0027;\n")]
		public PlayReportModel()
		{
			LevelId = "";
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v39 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+PlayedStep>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			PlayedSteps = Array.Empty<PlayedStep>();
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X0_v36 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportModel+IntendedStep>>)+135]");
			int num5 = (int)((nint)0 & (nint)1);
			bool flag2 = num5 == 0;
			nint num6 = 0;
			if (flag2)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X0_v22+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			IntendedSteps = Array.Empty<IntendedStep>();
			FirstDivergenceStep = -1;
		}
	}
}
