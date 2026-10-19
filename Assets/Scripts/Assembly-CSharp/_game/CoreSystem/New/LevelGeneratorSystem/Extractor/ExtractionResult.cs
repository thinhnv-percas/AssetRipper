using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Extractor
{
	[Token(Token = "0x200036C")]
	public sealed class ExtractionResult
	{
		[Token(Token = "0x4000A54")]
		[FieldOffset(Offset = "0x10")]
		public bool Success;

		[Token(Token = "0x4000A55")]
		[FieldOffset(Offset = "0x18")]
		public string[] ConceptIds;

		[Token(Token = "0x4000A56")]
		[FieldOffset(Offset = "0x20")]
		public string EnrichedPrompt;

		[Token(Token = "0x4000A57")]
		[FieldOffset(Offset = "0x28")]
		public string Reasoning;

		[Token(Token = "0x4000A58")]
		[FieldOffset(Offset = "0x30")]
		public string MissingTerm;

		[Token(Token = "0x4000A59")]
		[FieldOffset(Offset = "0x38")]
		public string MissingReason;

		[Token(Token = "0x6000E19")]
		[Address(RVA = "0x3F03D64", Offset = "0x3F03D64", Length = "0x340")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv53 = System.String::op_Equality(draft.outcome, \"commit\");\n\tv65 = v53 == 0;\n\tif (v65) goto L_0055;\n\tv75 = System.String::IsNullOrEmpty(draft.enrichedPrompt);\n\tv78 = ~v75;\n\tif (v78) goto L_0089;\n\tv147 = 0xB7D5000 + 0x538;\n\tv148 = *([v147 @ X8_v74 (System.Int32)+90]);\n\tv149 = *([v148 @ X8_v75+B8]);\n\tv130 = *([v149 @ X8_v76]);\n\tv80 = 0xB30E000 + 0x738;\nL_FFFFFFFF:\n\t;\n\tgoto L_0049;\nL_0043:\n\tv55 = 0xB7D5000 + 0x538;\n\tv56 = *([v55 @ X8_v12 (System.Int32)+90]);\n\tv57 = *([v56 @ X8_v13+B8]);\n\tv130 = *([v57 @ X8_v14]);\n\tv80 = 0xB309000 + 0xCD8;\nL_FFFFFFFF:\n\t;\n\tgoto L_006D;\nL_0055:\n\tv76 = System.String::op_Equality(draft.outcome, \"report_missing\");\n\tv128 = v76 == 0;\n\tif (v128) goto L_00CE;\n\tv100 = draft.missingTerm;\n\tv156 = draft.missingTerm == 0;\n\tif (v156) goto L_00E3;\n\tv118 = draft.missingReason;\n\tv172 = draft.missingReason == 0;\nL_FFFFFFFF:\n\tv130 = v100;\n\tif (v172) goto L_00EC;\nL_FFFFFFFF:\n\tv130 = v100;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv138 = v118;\n\tgoto L_006D;\nL_0069:\n\t*([B78EA3B]) = 1;\nL_FFFFFFFF:\n\tv130 = v100;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv138 = v118;\n\tv142.Success = 0;\n\tv142.MissingTerm = v130;\n\tv142.MissingReason = v138;\n\treturn v142;\nL_0089:\n\tv154 = new _game.CoreSystem.New.LevelGeneratorSystem.Extractor.ExtractionResult();\n\t_game.CoreSystem.New.LevelGeneratorSystem.Extractor.ExtractionResult::.ctor(v154);\n\tv154.Success = 1;\n\tv222 = draft.conceptIds;\n\tv210 = draft.conceptIds == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_00B0;\n\tgoto L_009A;\nL_009A:\n\tv262 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv265 = *([v262 @ X0_v54 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv266 = v265 == 0;\nL_FFFFFFFF:\n\tv281 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v266) goto L_00FA;\nL_00A2:\n\tgoto L_00AA;\nL_00AA:\n\tgoto L_00AD;\nL_00AD:\n\tv222 = v229.Value;\n\tv309 = 0xB7D5000 + 0x538;\n\tv310 = *([v309 @ X8_v47 (System.Int32)+90]);\n\tv311 = *([v310 @ X8_v48+B8]);\n\tv249 = *([v311 @ X8_v49]);\nL_00CE:\n\tv158 = 0xB7D5000 + 0x538;\n\tv159 = *([v158 @ X8_v22 (System.Int32)+90]);\n\tv160 = *([v159 @ X8_v23+B8]);\n\tv108 = System.String::Concat(\"unknown outcome value: '\", draft.outcome, \"'\");\n\tv181 = *([B78EA3B]) & 1;\n\tv111 = v181 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v111) goto L_0069;\nL_FFFFFFFF:\n\tv130 = *([v160 @ X8_v24]);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv138 = v108;\n\tgoto L_006D;\nL_00E3:\n\tv174 = 0xB7D5000 + 0x538;\n\tv175 = *([v174 @ X8_v36 (System.Int32)+90]);\n\tv176 = *([v175 @ X8_v37+B8]);\n\tv100 = *([v176 @ X8_v38]);\n\tv118 = draft.missingReason;\n\tv179 = draft.missingReason == 0;\n\tv180 = ~v179;\nL_FFFFFFFF:\n\tv130 = *([v176 @ X8_v38]);\n\tif (v180) goto L_FFFFFFFF;\nL_00EC:\n\tv192 = 0xB7D5000 + 0x538;\n\tv193 = *([v192 @ X8_v32 (System.Int32)+90]);\n\tv80 = *([v193 @ X8_v33+B8]);\nL_FFFFFFFF:\n\t;\n\tgoto L_0049;\n\tv268 = System.Array::Empty();\n\tv274 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv287 = *([v274 @ X0_v47 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv288 = v287 == 0;\n\tv276 = ~v288;\nL_FFFFFFFF:\n\tv281 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v276) goto L_00A2;\nL_00FA:\n\tv284 = 0x220C238(v281, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv307 = *([v284 @ X0_v44+E4]) == 0;\n\tv293 = ~v307;\n\tif (v293) goto L_00AA;\n\tgoto L_0107;\nL_0107:\n\tgoto L_00AD;\nL_0029:\n\tv43 = draft == 0;\n\tif (v43) goto L_0043;\nL_0049:\n\tv138 = *([v80 @ X8_v6 (System.Int32)]);\n\tv89 = *([B78EA3B]) & 1;\n\tv90 = v89 == 0;\nL_FFFFFFFF:\n\tv100 = v102;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv118 = v108;\n\tif (v90) goto L_0069;\nL_006D:\n\tv142 = new _game.CoreSystem.New.LevelGeneratorSystem.Extractor.ExtractionResult();\n\t_game.CoreSystem.New.LevelGeneratorSystem.Extractor.ExtractionResult::.ctor(v142);\nL_00B0:\n\tv154.ConceptIds = v222;\n\tv154.EnrichedPrompt = draft.enrichedPrompt;\n\tv249 = draft.reasoning;\n\tv290 = draft.reasoning == 0;\n\tv253 = ~v290;\n\tif (v253) goto L_00C2;\nL_00C2:\n\tv154.Reasoning = v249;\n\treturn v154;\n")]
		public static ExtractionResult FromDraft(LlmExtractionDraft draft)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ExtractionResult::FromDraft");
			return default;
		}

		[Token(Token = "0x6000E1A")]
		[Address(RVA = "0x3F040A4", Offset = "0x3F040A4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.Success = 0;\n\tv46.MissingTerm = missingTerm;\n\tv46.MissingReason = missingReason;\n\treturn v46;\nL_0018:\n\tv46 = new _game.CoreSystem.New.LevelGeneratorSystem.Extractor.ExtractionResult();\n\t_game.CoreSystem.New.LevelGeneratorSystem.Extractor.ExtractionResult::.ctor(v46);\n")]
		public static ExtractionResult Fail(string missingTerm, string missingReason)
		{
			ExtractionResult extractionResult = new ExtractionResult();
			extractionResult.Success = false;
			extractionResult.MissingTerm = missingTerm;
			extractionResult.MissingReason = missingReason;
			return extractionResult;
		}

		[Token(Token = "0x6000E1B")]
		[Address(RVA = "0x3F04134", Offset = "0x3F04134", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB78E000;\n\tv20 = *([B78E9CD]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0059;\n\tgoto L_0014;\nL_0014:\n\tv50 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv53 = *([v50 @ X0_v36 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv54 = v53 == 0;\n\tv72 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v54) goto L_0069;\nL_001C:\n\tgoto L_0024;\nL_0024:\n\tgoto L_002A;\nL_002A:\n\tthis.ConceptIds = v112.Value;\n\tv121 = 0xB7D5000 + 0x538;\n\tv122 = *([v121 @ X20_v8 (System.Int32)+90]);\n\tv123 = *([v122 @ X8_v16+B8]);\n\tthis.EnrichedPrompt = *([v123 @ X8_v17]);\n\tv128 = *([v121 @ X20_v8 (System.Int32)+90]);\n\tv129 = *([v128 @ X8_v18+B8]);\n\tthis.Reasoning = *([v129 @ X8_v19]);\n\tv134 = *([v121 @ X20_v8 (System.Int32)+90]);\n\tv135 = *([v134 @ X8_v20+B8]);\n\tthis.MissingTerm = *([v135 @ X8_v21]);\n\tv140 = *([v121 @ X20_v8 (System.Int32)+90]);\n\tv141 = *([v140 @ X8_v22+B8]);\n\tthis.MissingReason = *([v141 @ X8_v23]);\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0059:\n\t*([v16 @ X20_v1+9CD]) = 1;\n\tgoto L_0014;\n\tv60 = System.Array::Empty();\n\tv64 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv79 = *([v64 @ X0_v9 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv80 = v79 == 0;\n\tv66 = ~v80;\n\tv72 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v66) goto L_001C;\nL_0069:\n\tv76 = 0x220C238(v72, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = *([v76 @ X0_v5+E4]) == 0;\n\tv83 = ~v99;\n\tif (v83) goto L_0024;\n\tgoto L_0076;\nL_0076:\n\tgoto L_002A;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExtractionResult()
		{
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E9CD]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v36 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			ConceptIds = Array.Empty<string>();
			int num4 = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X20_v8 (System.Int32)+90]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v16+B8]");
			object enrichedPrompt = 0;
			EnrichedPrompt = (string)enrichedPrompt;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X20_v8 (System.Int32)+90]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v18+B8]");
			object reasoning = 0;
			Reasoning = (string)reasoning;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X20_v8 (System.Int32)+90]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v20+B8]");
			object missingTerm = 0;
			MissingTerm = (string)missingTerm;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X20_v8 (System.Int32)+90]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v22+B8]");
			object missingReason = 0;
			MissingReason = (string)missingReason;
		}
	}
}
