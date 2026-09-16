using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Wrapper;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000016")]
	public static class GA_Progression
	{
		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x15A0988", Offset = "0x15A0988", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, 0, 0, 0, fields);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, IDictionary<string, object> fields)
		{
			CreateEvent(progressionStatus, progression01, null, null, null, fields);
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x15A0ABC", Offset = "0x15A0ABC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, progression02, 0, 0, fields);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, IDictionary<string, object> fields)
		{
			CreateEvent(progressionStatus, progression01, progression02, null, null, fields);
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x15A0AD0", Offset = "0x15A0AD0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, progression02, progression03, 0, fields);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, IDictionary<string, object> fields)
		{
			CreateEvent(progressionStatus, progression01, progression02, progression03, null, fields);
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x15A0AE0", Offset = "0x15A0AE0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1F04658]);\n\tv31 = *([v30 @ X8_v6]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, progression01, score, fields, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20297CE]) = v47;\nL_001D:\n\tv51 = 0;\n\tv54 = 0x115BDC0(&v51 @ stack_-38_v1 (System.Nullable`1<System.Int32>), score, Il2CppMethodInfo, fields, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, 0, 0, 0, fields);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, int score, IDictionary<string, object> fields)
		{
			int? num = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115BDC0 (inside System.Nullable`1<System.Double>::Unbox +0xA8)");
			CreateEvent(progressionStatus, progression01, null, null, null, fields);
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x15A0B74", Offset = "0x15A0B74", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EC1DB8]);\n\tv35 = *([v34 @ X8_v6]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, progression01, progression02, score, fields, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297CF]) = v50;\nL_001F:\n\tv54 = 0;\n\tv57 = 0x115BDC0(&v54 @ stack_-48_v1 (System.Nullable`1<System.Int32>), score, Il2CppMethodInfo, score, fields, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, progression02, 0, 0, fields);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, int score, IDictionary<string, object> fields)
		{
			int? num = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115BDC0 (inside System.Nullable`1<System.Double>::Unbox +0xA8)");
			CreateEvent(progressionStatus, progression01, progression02, null, null, fields);
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x15A0C14", Offset = "0x15A0C14", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv38 = *([1ED04F0]);\n\tv39 = *([v38 @ X8_v6]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, progression01, progression02, progression03, score, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20297D0]) = v53;\nL_0021:\n\tv57 = 0;\n\tv60 = 0x115BDC0(&v57 @ stack_-48_v1 (System.Nullable`1<System.Int32>), score, Il2CppMethodInfo, progression03, score, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, progression02, progression03, 0, fields);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> fields)
		{
			int? num = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115BDC0 (inside System.Nullable`1<System.Double>::Unbox +0xA8)");
			CreateEvent(progressionStatus, progression01, progression02, progression03, null, fields);
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x15A09A0", Offset = "0x15A09A0", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv39 = *([1EFD1F0]);\n\tv40 = *([v39 @ X8_v16]);\n\tv41 = \"il2cpp_codegen_initialize_method\"(v40, progression01, progression02, progression03, score, fields, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20297D1]) = v54;\nL_001E:\n\tv55 = score & 0xFF00000000;\n\tv56 = v55 == 0;\n\tif (v56) goto L_004C;\n\tv61 = 0x115BDD8(&score @ X4 (System.Nullable`1<System.Int32>), Il2CppMethodInfo, progression02, progression03, score, fields, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_003A;\n\tv96 = *([v71 @ X8_v13+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_003A;\n\tv109 = v71;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v109, v60, progression02, progression03, score, fields, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_003A:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddProgressionEventWithScore(progressionStatus, progression01, progression02, progression03, v61, fields);\n\treturn;\nL_004C:\n\tgoto L_0061;\n\tv75 = *([v64 @ X0_v2+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0061;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v64, progression01, progression02, progression03, score, fields, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0061:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddProgressionEvent(progressionStatus, progression01, progression02, progression03, fields);\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void CreateEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int? score, IDictionary<string, object> fields)
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected I4, but got Unknown
			if ((int)((_003F?)score & 0xFF00000000L) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115BDD8 (inside System.Nullable`1<System.Double>::Unbox +0xC0)");
				int score2 = default(int);
				GA_Wrapper.AddProgressionEventWithScore(progressionStatus, progression01, progression02, progression03, score2, fields);
			}
			else
			{
				GA_Wrapper.AddProgressionEvent(progressionStatus, progression01, progression02, progression03, fields);
			}
		}
	}
}
