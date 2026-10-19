using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.LevelGeneratorSystem.Analysis;
using _game.CoreSystem.New.LevelGeneratorSystem.Audit;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Report
{
	[Token(Token = "0x2000332")]
	public sealed class GenerationReportModel
	{
		[Token(Token = "0x2000333")]
		public sealed class LlmPromptRow
		{
			[Token(Token = "0x4000981")]
			[FieldOffset(Offset = "0x10")]
			public string Role = "";

			[Token(Token = "0x4000982")]
			[FieldOffset(Offset = "0x18")]
			public string Label = "";

			[Token(Token = "0x4000983")]
			[FieldOffset(Offset = "0x20")]
			public string Text = "";

			[Token(Token = "0x6000DB3")]
			[Address(RVA = "0x3EF7AAC", Offset = "0x3EF7AAC", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0019:\n\tthis.Role = \"\";\n\tthis.Label = \"\";\n\tthis.Text = \"\";\n")]
			public LlmPromptRow()
			{
			}
		}

		[Token(Token = "0x2000334")]
		public sealed class LlmUsageRow
		{
			[Token(Token = "0x4000984")]
			[FieldOffset(Offset = "0x10")]
			public string Role;

			[Token(Token = "0x4000985")]
			[FieldOffset(Offset = "0x18")]
			public string Model;

			[Token(Token = "0x4000986")]
			[FieldOffset(Offset = "0x20")]
			public int Calls;

			[Token(Token = "0x4000987")]
			[FieldOffset(Offset = "0x28")]
			public double Seconds;

			[Token(Token = "0x4000988")]
			[FieldOffset(Offset = "0x30")]
			public long InputTokens;

			[Token(Token = "0x4000989")]
			[FieldOffset(Offset = "0x38")]
			public long OutputTokens;

			[Token(Token = "0x400098A")]
			[FieldOffset(Offset = "0x40")]
			public long CacheReadTokens;

			[Token(Token = "0x400098B")]
			[FieldOffset(Offset = "0x48")]
			public long CacheCreationTokens;

			[Token(Token = "0x17000104")]
			public long TotalTokens
			{
				[Token(Token = "0x6000DB4")]
				[Address(RVA = "0x3EF7B30", Offset = "0x3EF7B30", Length = "0x14")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.InputTokens + this.CacheReadTokens;\n\t// 3 NotImplemented \"Instruction ADDP not yet implemented.\"\n\treturn v3;\n")]
				get
				{
					long result = InputTokens + CacheReadTokens;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction ADDP not yet implemented.\"");
					return result;
				}
			}

			[Token(Token = "0x6000DB5")]
			[Address(RVA = "0x3EF7B44", Offset = "0x3EF7B44", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\treturn;\nL_0019:\n\tthis.Role = \"\";\n\tthis.Model = \"\";\n\tSystem.Object::.ctor(this);\n")]
			public LlmUsageRow()
			{
				Role = "";
				Model = "";
			}
		}

		[Token(Token = "0x4000965")]
		[FieldOffset(Offset = "0x10")]
		public string RunId = "";

		[Token(Token = "0x4000966")]
		[FieldOffset(Offset = "0x18")]
		public string LevelName = "";

		[Token(Token = "0x4000967")]
		[FieldOffset(Offset = "0x20")]
		public string CardId = "";

		[Token(Token = "0x4000968")]
		[FieldOffset(Offset = "0x28")]
		public OutcomeKind Outcome;

		[Token(Token = "0x4000969")]
		[FieldOffset(Offset = "0x30")]
		public string DesignerModel = "";

		[Token(Token = "0x400096A")]
		[FieldOffset(Offset = "0x38")]
		public string ExtractorModel = "";

		[Token(Token = "0x400096B")]
		[FieldOffset(Offset = "0x40")]
		public DateTime StartedUtc;

		[Token(Token = "0x400096C")]
		[FieldOffset(Offset = "0x48")]
		public DateTime FinishedUtc;

		[Token(Token = "0x400096D")]
		[FieldOffset(Offset = "0x50")]
		public int AttemptCount;

		[Token(Token = "0x400096E")]
		[FieldOffset(Offset = "0x54")]
		public bool SolverIsSolvable;

		[Token(Token = "0x400096F")]
		[FieldOffset(Offset = "0x58")]
		public string DoneReason = "";

		[Token(Token = "0x4000970")]
		[FieldOffset(Offset = "0x60")]
		public string FailureReason = "";

		[Token(Token = "0x4000971")]
		[FieldOffset(Offset = "0x68")]
		public long InputTokens;

		[Token(Token = "0x4000972")]
		[FieldOffset(Offset = "0x70")]
		public long OutputTokens;

		[Token(Token = "0x4000973")]
		[FieldOffset(Offset = "0x78")]
		public long CacheReadTokens;

		[Token(Token = "0x4000974")]
		[FieldOffset(Offset = "0x80")]
		public long CacheCreationTokens;

		[Token(Token = "0x4000975")]
		[FieldOffset(Offset = "0x88")]
		public LlmUsageRow[] LlmUsage;

		[Token(Token = "0x4000976")]
		[FieldOffset(Offset = "0x90")]
		public string DesignerPrompt;

		[Token(Token = "0x4000977")]
		[FieldOffset(Offset = "0x98")]
		public string AugmentedPrompt;

		[Token(Token = "0x4000978")]
		[FieldOffset(Offset = "0xA0")]
		public string[] ConceptIds;

		[Token(Token = "0x4000979")]
		[FieldOffset(Offset = "0xA8")]
		public LlmPromptRow[] LlmPrompts;

		[Token(Token = "0x400097A")]
		[FieldOffset(Offset = "0xB0")]
		public int[] TargetMoldBars;

		[Token(Token = "0x400097B")]
		[FieldOffset(Offset = "0xB8")]
		public int[] AchievedOccupancy;

		[Token(Token = "0x400097C")]
		[FieldOffset(Offset = "0xC0")]
		public int CapacityInUnits;

		[Token(Token = "0x400097D")]
		[FieldOffset(Offset = "0xC4")]
		public bool ConveyorFeasibilityWall;

		[Token(Token = "0x400097E")]
		[FieldOffset(Offset = "0xC8")]
		public AlternativePathsResult AlternativePaths;

		[Token(Token = "0x400097F")]
		[FieldOffset(Offset = "0xD0")]
		public MechanicAuditRow[] MechanicAudit;

		[Token(Token = "0x4000980")]
		[FieldOffset(Offset = "0xD8")]
		public string LogText;

		[Token(Token = "0x17000102")]
		public bool HasMoldTarget
		{
			[Token(Token = "0x6000DB0")]
			[Address(RVA = "0x3EF6F90", Offset = "0x3EF6F90", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.TargetMoldBars;\n\tv4 = v0.Length == 0;\n\tif (v4) goto L_0016;\n\tv30 = this.CapacityInUnits < 0;\n\tv31 = this.CapacityInUnits == 0;\n\tv33 = this.CapacityInUnits ^ this.CapacityInUnits;\n\tv34 = this.CapacityInUnits & v33;\n\tv35 = v34 < 0;\n\tv36 = v30 == v35;\n\tv37 = ~v31;\n\tv38 = v36 & v37;\n\treturn v38;\nL_0016:\n\treturn 0;\n")]
			get
			{
				int[] targetMoldBars = TargetMoldBars;
				if (targetMoldBars.Length != 0)
				{
					bool flag = CapacityInUnits < 0;
					bool flag2 = CapacityInUnits == 0;
					int num = CapacityInUnits ^ CapacityInUnits;
					int num2 = CapacityInUnits & num;
					bool flag3 = num2 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					return flag4 && flag5;
				}
				return false;
			}
		}

		[Token(Token = "0x17000103")]
		public double DurationSeconds
		{
			[Token(Token = "0x6000DB1")]
			[Address(RVA = "0x3EF6CD4", Offset = "0x3EF6CD4", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0026:\n\tv60 = System.DateTime::op_Subtraction(*([v47 @ X19_v2 (System.DateTime)+48]), this.StartedUtc);\n\tv61 = v60;\n\tgoto L_0030;\nL_0030:\n\treturnVal1 = System.TimeSpan::get_TotalSeconds(&v61 @ stack_-38_v1 (System.TimeSpan));\n\treturn returnVal1;\nL_001B:\n\tv47 = this.StartedUtc;\n\tgoto L_0026;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GenerationReportModel::get_DurationSeconds");
				return default;
			}
		}

		[Token(Token = "0x6000DB2")]
		[Address(RVA = "0x3EF762C", Offset = "0x3EF762C", Length = "0x480")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tthis.DesignerModel = \"\";\n\tthis.ExtractorModel = \"\";\n\tthis.DoneReason = \"\";\n\tthis.FailureReason = \"\";\n\tgoto L_004E;\nL_004E:\n\tv92 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmUsageRow>>;\n\tv95 = *([v92 @ X0_v132 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmUsageRow>>)+135]) & 1;\n\tv96 = v95 == 0;\n\tv107 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmUsageRow>>;\n\tif (v96) goto L_011E;\nL_0056:\n\tgoto L_0060;\nL_0060:\n\tgoto L_0066;\nL_0066:\n\tthis.LlmUsage = v136.Value;\n\tthis.DesignerPrompt = \"\";\n\tthis.AugmentedPrompt = \"\";\n\tgoto L_0076;\nL_0076:\n\tv152 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv155 = *([v152 @ X0_v129 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv156 = v155 == 0;\n\tv167 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v156) goto L_012F;\nL_007E:\n\tgoto L_0088;\nL_0088:\n\tgoto L_008E;\nL_008E:\n\tthis.ConceptIds = v196.Value;\n\tgoto L_0094;\nL_0094:\n\tv204 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmPromptRow>>;\n\tv207 = *([v204 @ X0_v126 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmPromptRow>>)+135]) & 1;\n\tv208 = v207 == 0;\n\tv219 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmPromptRow>>;\n\tif (v208) goto L_0140;\nL_009C:\n\tgoto L_00A6;\nL_00A6:\n\tgoto L_00AC;\nL_00AC:\n\tthis.LlmPrompts = v248.Value;\n\tgoto L_00B2;\nL_00B2:\n\tv256 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tv259 = *([v256 @ X0_v123 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]) & 1;\n\tv260 = v259 == 0;\n\tv271 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tif (v260) goto L_0151;\nL_00BA:\n\tgoto L_00C2;\nL_00C2:\n\tgoto L_00C8;\nL_00C8:\n\tthis.TargetMoldBars = v306.Value;\n\tgoto L_00CE;\nL_00CE:\n\tv317 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tv320 = *([v317 @ X0_v117 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]) & 1;\n\tv321 = v320 == 0;\n\tv332 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tif (v321) goto L_0169;\nL_00D6:\n\tgoto L_00E0;\nL_00E0:\n\tgoto L_00E6;\nL_00E6:\n\tthis.AchievedOccupancy = v361.Value;\n\tgoto L_00EC;\nL_00EC:\n\tv369 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>;\n\tv372 = *([v369 @ X0_v114 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>)+135]) & 1;\n\tv373 = v372 == 0;\n\tv384 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>;\n\tif (v373) goto L_017A;\nL_00F4:\n\tgoto L_00FC;\nL_00FC:\n\tgoto L_0102;\nL_0102:\n\tthis.MechanicAudit = v419.Value;\n\tthis.LogText = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\n\tv98 = System.Array::Empty();\n\tv100 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmUsageRow>>;\n\tv113 = *([v100 @ X0_v29 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmUsageRow>>)+135]) & 1;\n\tv114 = v113 == 0;\n\tv102 = ~v114;\n\tv107 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmUsageRow>>;\n\tif (v102) goto L_0056;\nL_011E:\n\tv110 = 0x220C238(v107, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0060;\n\tv158 = System.Array::Empty();\n\tv160 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv173 = *([v160 @ X0_v48 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv174 = v173 == 0;\n\tv162 = ~v174;\n\tv167 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v162) goto L_007E;\nL_012F:\n\tv170 = 0x220C238(v167, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0088;\n\tv210 = System.Array::Empty();\n\tv212 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmPromptRow>>;\n\tv225 = *([v212 @ X0_v61 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmPromptRow>>)+135]) & 1;\n\tv226 = v225 == 0;\n\tv214 = ~v226;\n\tv219 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmPromptRow>>;\n\tif (v214) goto L_009C;\nL_0140:\n\tv222 = 0x220C238(v219, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00A6;\n\tv262 = System.Array::Empty();\n\tv264 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tv277 = *([v264 @ X0_v75 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]) & 1;\n\tv278 = v277 == 0;\n\tv266 = ~v278;\n\tv271 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tif (v266) goto L_00BA;\nL_0151:\n\tv274 = 0x220C238(v271, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv295 = *([v274 @ X0_v72+E4]) == 0;\n\tv281 = ~v295;\n\tif (v281) goto L_00C2;\n\tgoto L_015E;\nL_015E:\n\tgoto L_00C8;\n\tv323 = System.Array::Empty();\n\tv325 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tv338 = *([v325 @ X0_v86 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]) & 1;\n\tv339 = v338 == 0;\n\tv327 = ~v339;\n\tv332 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tif (v327) goto L_00D6;\nL_0169:\n\tv335 = 0x220C238(v332, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00E0;\n\tv375 = System.Array::Empty();\n\tv377 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>;\n\tv390 = *([v377 @ X0_v100 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>)+135]) & 1;\n\tv391 = v390 == 0;\n\tv379 = ~v391;\n\tv384 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>;\n\tif (v379) goto L_00F4;\nL_017A:\n\tv387 = 0x220C238(v384, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv408 = *([v387 @ X0_v97+E4]) == 0;\n\tv394 = ~v408;\n\tif (v394) goto L_00FC;\n\tgoto L_0187;\nL_0187:\n\tgoto L_0102;\nL_002A:\n\tthis.RunId = \"\";\n\tthis.LevelName = \"\";\n\tthis.CardId = \"\";\n")]
		public GenerationReportModel()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X0_v132 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmUsageRow>>)+135]");
			bool flag = (int)((nint)0 & (nint)1) == 0;
			nint num2 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			LlmUsage = Array.Empty<LlmUsageRow>();
			DesignerPrompt = "";
			AugmentedPrompt = "";
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X0_v129 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]");
			bool flag2 = (int)((nint)0 & (nint)1) == 0;
			nint num4 = 0;
			if (flag2)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			ConceptIds = Array.Empty<string>();
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X0_v126 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportModel+LlmPromptRow>>)+135]");
			bool flag3 = (int)((nint)0 & (nint)1) == 0;
			nint num6 = 0;
			if (flag3)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			LlmPrompts = Array.Empty<LlmPromptRow>();
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ X0_v123 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]");
			bool flag4 = (int)((nint)0 & (nint)1) == 0;
			nint num8 = 0;
			if (flag4)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X0_v72+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			TargetMoldBars = Array.Empty<int>();
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X0_v117 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]");
			bool flag5 = (int)((nint)0 & (nint)1) == 0;
			nint num10 = 0;
			if (flag5)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			AchievedOccupancy = Array.Empty<int>();
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ X0_v114 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>)+135]");
			bool flag6 = (int)((nint)0 & (nint)1) == 0;
			nint num12 = 0;
			if (flag6)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X0_v97+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			MechanicAudit = Array.Empty<MechanicAuditRow>();
			LogText = "";
		}
	}
}
