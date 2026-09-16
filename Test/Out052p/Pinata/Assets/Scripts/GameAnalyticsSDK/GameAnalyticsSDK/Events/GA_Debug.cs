using System.Collections.Generic;
using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Setup;
using UnityEngine;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000013")]
	public static class GA_Debug
	{
		[Token(Token = "0x4000091")]
		public static int MaxErrorCount = 10;

		[Token(Token = "0x4000092")]
		private static int _errorCount = 0;

		[Token(Token = "0x4000093")]
		private static bool _showLogOnGUI = false;

		[Token(Token = "0x4000094")]
		public static List<string> Messages;

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x15A0168", Offset = "0x15A0168", Length = "0x304")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv28 = *([1EA8AE8]);\n\tv29 = *([v28 @ X8_v54]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, stackTrace, type, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20297C8]) = v46;\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Events.GA_Debug>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v49, stackTrace, type, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = GameAnalyticsSDK.Events.GA_Debug;\nL_0027:\n\tv62 = ~v60._showLogOnGUI;\n\tif (v62) goto L_0061;\n\tgoto L_0035;\n\tv82 = *([v56 @ X0_v3 (Il2CppClass<GameAnalyticsSDK.Events.GA_Debug>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0035;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v56, stackTrace, type, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv86 = GameAnalyticsSDK.Events.GA_Debug;\n\tv89 = *([v86 @ X0_v59+B8]);\nL_0035:\n\tv91 = v88.Messages == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0051;\n\tv98 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v98);\n\tgoto L_004D;\n\tv318 = *([v263 @ X0_v54 (Il2CppClass<GameAnalyticsSDK.Events.GA_Debug>)+E0]);\n\tv319 = v318 == 0;\n\tv320 = ~v319;\n\tif (v320) goto L_004D;\n\tv326 = \"il2cpp_codegen_runtime_class_init\"(v263, v100, type, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv321 = GameAnalyticsSDK.Events.GA_Debug;\nL_004D:\n\tv106.Messages = v98;\nL_0051:\n\tgoto L_0060;\n\tv185 = *([v101 @ X0_v47 (Il2CppClass<GameAnalyticsSDK.Events.GA_Debug>)+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\t// 85 Jump @b69\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v101, v99, type, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv189 = GameAnalyticsSDK.Events.GA_Debug;\nL_0060:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v180.Messages, logString);\nL_0061:\n\tv81 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv112 = ~v81.SubmitErrors;\n\tif (v112) goto L_0114;\n\tgoto L_0076;\n\tv269 = *([v192 @ X0_v12 (Il2CppClass<GameAnalyticsSDK.Events.GA_Debug>)+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_0076;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v192, v69, v67, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv272 = GameAnalyticsSDK.Events.GA_Debug;\nL_0076:\n\tv206 = type == 3;\n\tif (v206) goto L_0114;\n\tv121 = v324._errorCount >= v324.MaxErrorCount;\n\tif (v121) goto L_0114;\n\tv329 = System.String::IsNullOrEmpty(stackTrace);\n\tv331 = v329 == 0;\n\tif (v331) goto L_00A3;\n\tv248 = new System.Diagnostics.StackTrace();\n\tSystem.Diagnostics.StackTrace::.ctor(v248);\n\tv338 = System.Diagnostics.StackTrace::ToString(v248);\nL_00A3:\n\tgoto L_00AC;\n\tv347 = *([v343 @ X0_v17 (Il2CppClass<GameAnalyticsSDK.Events.GA_Debug>)+E0]);\n\tv348 = v347 == 0;\n\tv349 = ~v348;\n\tgoto L_00AC;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v343, v245, v67, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv350 = GameAnalyticsSDK.Events.GA_Debug;\nL_00AC:\n\tv159 = v178._errorCount + 1;\n\tv178._errorCount = v159;\n\tv161 = System.String::Replace(logString, 0x22, 0x27);\n\tv162 = System.String::Replace(v161, 0xA, 0x20);\n\tv249 = System.String::Replace(v162, 0xD, 0x20);\n\tv163 = System.String::Replace(v175, 0x22, 0x27);\n\tv164 = System.String::Replace(v163, 0xA, 0x20);\n\tv361 = System.String::Replace(v164, 0xD, 0x20);\n\tv165 = System.String::Concat(v249, \" \", v361);\n\tv376 = v165.m_stringLength <= 0x2000;\n\tif (v376) goto L_00F6;\n\tv380 = System.String::Substring(v165, 0x2000);\nL_00F6:\n\tgoto L_00FC;\n\tv390 = *([v386 @ X0_v30+E0]);\n\tv391 = v390 == 0;\n\tv392 = ~v391;\n\tgoto L_00FC;\n\tv394 = \"il2cpp_codegen_runtime_class_init\"(v386, v382, v381, v118, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00FC:\n\tv396 = type < 4;\n\tv296 = ~v396;\n\tv294 = type - 4;\n\tv290 = v294 == 0;\n\tv397 = ~v290;\n\tv280 = v296 & v397;\n\tif (v280) goto L_FFFFFFFF;\n\tv399 = 0x183B000 + 0xBD0;\n\tv303 = *([v399 @ X8_v26 (System.Int32)+type @ X2 (UnityEngine.LogType)*4]);\n\tgoto L_0120;\nL_0114:\n\treturn;\nL_0120:\n\tGameAnalyticsSDK.Events.GA_Error::CreateNewEvent(v303, v384, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void HandleLog(string logString, string stackTrace, LogType type)
		{
			if (_showLogOnGUI)
			{
				if (Messages == null)
				{
					List<string> messages = new List<string>();
					Messages = messages;
				}
				Messages.Add(logString);
			}
			Settings settingsGA = GameAnalytics.SettingsGA;
			if (settingsGA.SubmitErrors && type != LogType.Log && _errorCount < MaxErrorCount)
			{
				bool flag = string.IsNullOrEmpty(stackTrace);
				bool flag2 = !flag;
				string text = stackTrace;
				if (!flag2)
				{
					StackTrace stackTrace2 = new StackTrace();
					string text2 = stackTrace2.ToString();
					text = text2;
				}
				int errorCount = _errorCount + 1;
				_errorCount = errorCount;
				string text3 = logString.Replace('"', '\'');
				string text4 = text3.Replace('\n', ' ');
				string text5 = text4.Replace('\r', ' ');
				string text6 = text.Replace('"', '\'');
				string text7 = text6.Replace('\n', ' ');
				string text8 = text7.Replace('\r', ' ');
				string text9 = text5 + " " + text8;
				bool flag3 = text9.Length <= 8192;
				string message = text9;
				if (!flag3)
				{
					string text10 = text9.Substring(8192);
					message = text10;
				}
				bool flag4 = type < LogType.Exception;
				bool flag5 = !flag4;
				int num = (int)(type - 4);
				bool flag6 = num == 0;
				bool flag7 = !flag6;
				GAErrorSeverity severity;
				if (!(flag5 && flag7))
				{
					int num2 = 25407488 + 3024;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ X8_v26 (System.Int32)+type @ X2 (UnityEngine.LogType)*4]");
					severity = GAErrorSeverity.Undefined;
				}
				else
				{
					severity = GAErrorSeverity.Info;
				}
				GA_Error.CreateNewEvent(severity, message, null);
			}
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x15A0500", Offset = "0x15A0500", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = type < 4;\n\tv2 = ~v0;\n\tv3 = type - 4;\n\tv5 = v3 == 0;\n\tv12 = ~v5;\n\tv13 = v2 & v12;\n\tif (v13) goto L_FFFFFFFF;\n\tv15 = 0x183B000 + 0xBD0;\n\tv18 = *([v15 @ X9_v3 (System.Int32)+type @ X1 (UnityEngine.LogType)*4]);\n\tgoto L_0014;\nL_0014:\n\tGameAnalyticsSDK.Events.GA_Error::CreateNewEvent(v18, message, 0);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SubmitError(string message, LogType type)
		{
			bool flag = type < LogType.Exception;
			bool flag2 = !flag;
			int num = (int)(type - 4);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			GAErrorSeverity severity;
			if (!(flag2 && flag4))
			{
				int num2 = 25407488 + 3024;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X9_v3 (System.Int32)+type @ X1 (UnityEngine.LogType)*4]");
				severity = GAErrorSeverity.Undefined;
			}
			else
			{
				severity = GAErrorSeverity.Info;
			}
			GA_Error.CreateNewEvent(severity, message, null);
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x15A0530", Offset = "0x15A0530", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDAE50]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20297C9]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Events.GA_Debug>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = GameAnalyticsSDK.Events.GA_Debug;\nL_0020:\n\tv49._showLogOnGUI = 1;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EnabledLog()
		{
			_showLogOnGUI = true;
		}
	}
}
