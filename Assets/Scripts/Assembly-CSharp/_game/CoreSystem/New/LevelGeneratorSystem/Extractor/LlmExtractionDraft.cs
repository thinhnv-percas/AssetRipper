using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Extractor
{
	[Serializable]
	[Token(Token = "0x200036E")]
	public class LlmExtractionDraft
	{
		[Token(Token = "0x4000A5A")]
		[FieldOffset(Offset = "0x10")]
		public string outcome;

		[Token(Token = "0x4000A5B")]
		[FieldOffset(Offset = "0x18")]
		public string[] conceptIds;

		[Token(Token = "0x4000A5C")]
		[FieldOffset(Offset = "0x20")]
		public string enrichedPrompt;

		[Token(Token = "0x4000A5D")]
		[FieldOffset(Offset = "0x28")]
		public string reasoning;

		[Token(Token = "0x4000A5E")]
		[FieldOffset(Offset = "0x30")]
		public string missingTerm;

		[Token(Token = "0x4000A5F")]
		[FieldOffset(Offset = "0x38")]
		public string missingReason;

		[Token(Token = "0x6000E1E")]
		[Address(RVA = "0x3F04FFC", Offset = "0x3F04FFC", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0023:\n\tv55 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv58 = *([v55 @ X0_v35 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv59 = v58 == 0;\n\tv70 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v59) goto L_006C;\nL_002B:\n\tgoto L_0033;\nL_0033:\n\tgoto L_0039;\nL_0039:\n\tthis.conceptIds = v105.Value;\n\tv113 = *([v45 @ X21_v3 (System.Int32)+90]);\n\tv114 = *([v113 @ X8_v17+B8]);\n\tthis.enrichedPrompt = *([v114 @ X8_v18]);\n\tv119 = *([v45 @ X21_v3 (System.Int32)+90]);\n\tv120 = *([v119 @ X8_v19+B8]);\n\tthis.reasoning = *([v120 @ X8_v20]);\n\tv125 = *([v45 @ X21_v3 (System.Int32)+90]);\n\tv126 = *([v125 @ X8_v21+B8]);\n\tthis.missingTerm = *([v126 @ X8_v22]);\n\tv131 = *([v45 @ X21_v3 (System.Int32)+90]);\n\tv132 = *([v131 @ X8_v23+B8]);\n\tthis.missingReason = *([v132 @ X8_v24]);\n\tSystem.Object::.ctor(this);\n\treturn;\n\tv61 = System.Array::Empty();\n\tv63 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv76 = *([v63 @ X0_v12 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv77 = v76 == 0;\n\tv65 = ~v77;\n\tv70 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v65) goto L_002B;\nL_006C:\n\tv73 = 0x220C238(v70, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv94 = *([v73 @ X0_v9+E4]) == 0;\n\tv80 = ~v94;\n\tif (v80) goto L_0033;\n\tgoto L_0079;\nL_0079:\n\tgoto L_0039;\nL_0017:\n\tv45 = 0xB7D5000 + 0x538;\n\tv46 = *([v45 @ X21_v3 (System.Int32)+90]);\n\tv47 = *([v46 @ X8_v3+B8]);\n\tthis.outcome = *([v47 @ X8_v4]);\n\tgoto L_0023;\n")]
		public LlmExtractionDraft()
		{
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X21_v3 (System.Int32)+90]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3+B8]");
			object obj2 = 0;
			outcome = (string)obj2;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X0_v35 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]");
			int num3 = (int)((nint)0 & (nint)1);
			bool flag = num3 == 0;
			nint num4 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X0_v9+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			conceptIds = Array.Empty<string>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X21_v3 (System.Int32)+90]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v17+B8]");
			object obj4 = 0;
			enrichedPrompt = (string)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X21_v3 (System.Int32)+90]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v19+B8]");
			object obj6 = 0;
			reasoning = (string)obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X21_v3 (System.Int32)+90]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X8_v21+B8]");
			object obj8 = 0;
			missingTerm = (string)obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X21_v3 (System.Int32)+90]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v23+B8]");
			object obj10 = 0;
			missingReason = (string)obj10;
		}
	}
}
