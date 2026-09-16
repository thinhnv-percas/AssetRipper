using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000A3")]
	public static class Debugger
	{
		[Token(Token = "0x20000A4")]
		internal static class Sequence
		{
			[Token(Token = "0x60003DA")]
			[Address(RVA = "0xC2C2D8", Offset = "0xC2C2D8", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = \"You can't add elements to a NULL Sequence\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357CA]) = v34;\nL_0017:\n\tDG.Tweening.Core.Debugger::LogWarning(\"You can't add elements to a NULL Sequence\", 0);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void LogAddToNullSequence()
			{
				LogWarning("You can't add elements to a NULL Sequence");
			}

			[Token(Token = "0x60003DB")]
			[Address(RVA = "0xC2C31C", Offset = "0xC2C31C", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = \"You can't add elements to an inactive/killed Sequence\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357CB]) = v34;\nL_0017:\n\tDG.Tweening.Core.Debugger::LogWarning(\"You can't add elements to an inactive/killed Sequence\", 0);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void LogAddToInactiveSequence()
			{
				LogWarning("You can't add elements to an inactive/killed Sequence");
			}

			[Token(Token = "0x60003DC")]
			[Address(RVA = "0xC2C360", Offset = "0xC2C360", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = \"The Sequence has started and is now locked, you can only elements to a Sequence before it starts\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357CC]) = v34;\nL_0017:\n\tDG.Tweening.Core.Debugger::LogWarning(\"The Sequence has started and is now locked, you can only elements to a Sequence before it starts\", 0);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void LogAddToLockedSequence()
			{
				LogWarning("The Sequence has started and is now locked, you can only elements to a Sequence before it starts");
			}

			[Token(Token = "0x60003DD")]
			[Address(RVA = "0xC2C3A4", Offset = "0xC2C3A4", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = \"You can't add a NULL tween to a Sequence\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357CD]) = v34;\nL_0017:\n\tDG.Tweening.Core.Debugger::LogWarning(\"You can't add a NULL tween to a Sequence\", 0);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void LogAddNullTween()
			{
				LogWarning("You can't add a NULL tween to a Sequence");
			}

			[Token(Token = "0x60003DE")]
			[Address(RVA = "0xC2C3E8", Offset = "0xC2C3E8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = \"You can't add an inactive/killed tween to a Sequence\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357CE]) = v37;\nL_001A:\n\tDG.Tweening.Core.Debugger::LogWarning(\"You can't add an inactive/killed tween to a Sequence\", t);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void LogAddInactiveTween(Tween t)
			{
				LogWarning("You can't add an inactive/killed tween to a Sequence", t);
			}

			[Token(Token = "0x60003DF")]
			[Address(RVA = "0xC2C430", Offset = "0xC2C430", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = \"You can't add a tween that is already nested into a Sequence to another Sequence\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357CF]) = v37;\nL_001A:\n\tDG.Tweening.Core.Debugger::LogWarning(\"You can't add a tween that is already nested into a Sequence to another Sequence\", t);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void LogAddAlreadySequencedTween(Tween t)
			{
				LogWarning("You can't add a tween that is already nested into a Sequence to another Sequence", t);
			}
		}

		[Token(Token = "0x40001CA")]
		internal static int _logPriority;

		[Token(Token = "0x40001CB")]
		private const string _LogPrefix = "<color=#0099bc><b>DOTWEEN ► </b></color>";

		[Token(Token = "0x1700000F")]
		public static int logPriority
		{
			[Token(Token = "0x60003C7")]
			[Address(RVA = "0xC2B40C", Offset = "0xC2B40C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = DG.Tweening.Core.Debugger;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357B7]) = v34;\nL_0018:\n\treturn v38._logPriority;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _logPriority;
			}
		}

		[Token(Token = "0x60003C8")]
		[Address(RVA = "0xC2B454", Offset = "0xC2B454", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = UnityEngine.Debug;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = \"<color=#0099bc><b>DOTWEEN ► </b></color>\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A357B8]) = v38;\nL_001C:\n\tv42 = message == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv50 = System.Object::ToString(message);\n\tgoto L_0028;\nL_0028:\n\tv62 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v55);\n\tgoto L_0033;\n\tv68 = v63;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v68, v55, v61, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv72 = DG.Tweening.DOTween;\nL_0033:\n\tv88 = v73.onWillLog;\n\tv75 = v73.onWillLog == 0;\n\tif (v75) goto L_0050;\n\tv77 = *([v71 @ X8_v5 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0046;\n\tv88 = v108.onWillLog;\nL_0046:\n\tv90 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v88, 3, v62);\n\tv110 = v90 & 1;\n\tv92 = v110 == 0;\n\tif (v92) goto L_0060;\nL_0050:\n\tgoto L_0059;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v97, v85, v79, v81, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0059:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\nL_0060:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Log(object message)
		{
			//IL_00f6: Expected I, but got O
			//IL_007d: Expected O, but got I4
			string text2;
			if (message != null)
			{
				string text = message.ToString();
				text2 = text;
			}
			else
			{
				text2 = null;
			}
			string text3 = "<color=#0099bc><b>DOTWEEN ► </b></color>" + text2;
			nint num = (nint)typeof(DOTween);
			Func<LogType, object, bool> onWillLog = DOTween.onWillLog;
			if (DOTween.onWillLog != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v5 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((nint)0 == 0)
				{
					onWillLog = DOTween.onWillLog;
				}
				object obj = onWillLog(LogType.Log, text3);
				if ((int)((nint)obj & 1) == 0)
				{
					return;
				}
			}
			Debug.Log(text3);
		}

		[Token(Token = "0x60003C9")]
		[Address(RVA = "0xC2B578", Offset = "0xC2B578", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = UnityEngine.Debug;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv58 = \"<color=#0099bc><b>DOTWEEN ► </b></color>\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A357B9]) = v41;\nL_001F:\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = DG.Tweening.DOTween;\nL_0026:\n\tv56 = ~v52.debugMode;\n\tif (v56) goto L_0036;\n\tv60 = DG.Tweening.Core.Debugger::GetDebugDataMessage(t);\n\tv65 = message == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tv77 = System.Object::ToString(message);\n\tgoto L_0043;\nL_0036:\n\tv62 = message == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tv70 = System.Object::ToString(message);\n\tgoto L_0048;\nL_0043:\n\tv101 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v60, v88);\n\tgoto L_FFFFFFFF;\nL_0048:\n\tv101 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v80);\n\tgoto L_0052;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v107, v99, v98, v97, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv113 = DG.Tweening.DOTween;\nL_0052:\n\tv133 = v114.onWillLog;\n\tv116 = v114.onWillLog == 0;\n\tif (v116) goto L_006E;\n\tv118 = *([v112 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_0064;\n\tv133 = v157.onWillLog;\nL_0064:\n\tv129 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v133, 2, v101);\n\tv146 = v129 & 1;\n\tv131 = v146 == 0;\n\tif (v131) goto L_0080;\nL_006E:\n\tgoto L_0078;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v136, v124, v122, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0078:\n\tUnityEngine.Debug::LogWarning(v101);\n\treturn;\nL_0080:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogWarning(object message, Tween t = null)
		{
			//IL_00a2: Expected I, but got O
			//IL_00fb: Expected O, but got I4
			string text3;
			if (DOTween.debugMode)
			{
				string debugDataMessage = GetDebugDataMessage(t);
				string text2;
				if (message != null)
				{
					string text = message.ToString();
					text2 = text;
				}
				else
				{
					text2 = null;
				}
				text3 = "<color=#0099bc><b>DOTWEEN ► </b></color>" + debugDataMessage + text2;
			}
			else
			{
				string text5;
				if (message != null)
				{
					string text4 = message.ToString();
					text5 = text4;
				}
				else
				{
					text5 = null;
				}
				text3 = "<color=#0099bc><b>DOTWEEN ► </b></color>" + text5;
			}
			nint num = (nint)typeof(DOTween);
			Func<LogType, object, bool> onWillLog = DOTween.onWillLog;
			if (DOTween.onWillLog != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((nint)0 == 0)
				{
					onWillLog = DOTween.onWillLog;
				}
				object obj = onWillLog(LogType.Warning, text3);
				if ((int)((nint)obj & 1) == 0)
				{
					return;
				}
			}
			Debug.LogWarning(text3);
		}

		[Token(Token = "0x60003CA")]
		[Address(RVA = "0xC2B768", Offset = "0xC2B768", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = UnityEngine.Debug;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv58 = \"<color=#0099bc><b>DOTWEEN ► </b></color>\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A357BA]) = v41;\nL_001F:\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = DG.Tweening.DOTween;\nL_0026:\n\tv56 = ~v52.debugMode;\n\tif (v56) goto L_0036;\n\tv60 = DG.Tweening.Core.Debugger::GetDebugDataMessage(t);\n\tv65 = message == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tv77 = System.Object::ToString(message);\n\tgoto L_0043;\nL_0036:\n\tv62 = message == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tv70 = System.Object::ToString(message);\n\tgoto L_0048;\nL_0043:\n\tv101 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v60, v88);\n\tgoto L_FFFFFFFF;\nL_0048:\n\tv101 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v80);\n\tgoto L_0052;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v107, v99, v98, v97, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv113 = DG.Tweening.DOTween;\nL_0052:\n\tv133 = v114.onWillLog;\n\tv116 = v114.onWillLog == 0;\n\tif (v116) goto L_006E;\n\tv118 = *([v112 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_0064;\n\tv133 = v157.onWillLog;\nL_0064:\n\tv129 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v133, 0, v101);\n\tv146 = v129 & 1;\n\tv131 = v146 == 0;\n\tif (v131) goto L_0080;\nL_006E:\n\tgoto L_0078;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v136, v124, v122, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0078:\n\tUnityEngine.Debug::LogError(v101);\n\treturn;\nL_0080:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogError(object message, Tween t = null)
		{
			//IL_00a2: Expected I, but got O
			//IL_0104: Expected O, but got I4
			string text3;
			if (DOTween.debugMode)
			{
				string debugDataMessage = GetDebugDataMessage(t);
				string text2;
				if (message != null)
				{
					string text = message.ToString();
					text2 = text;
				}
				else
				{
					text2 = null;
				}
				text3 = "<color=#0099bc><b>DOTWEEN ► </b></color>" + debugDataMessage + text2;
			}
			else
			{
				string text5;
				if (message != null)
				{
					string text4 = message.ToString();
					text5 = text4;
				}
				else
				{
					text5 = null;
				}
				text3 = "<color=#0099bc><b>DOTWEEN ► </b></color>" + text5;
			}
			nint num = (nint)typeof(DOTween);
			Func<LogType, object, bool> onWillLog = DOTween.onWillLog;
			if (DOTween.onWillLog != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((nint)0 == 0)
				{
					onWillLog = DOTween.onWillLog;
				}
				object obj = onWillLog(default(LogType), text3);
				if ((int)((nint)obj & 1) == 0)
				{
					return;
				}
			}
			Debug.LogError(text3);
		}

		[Token(Token = "0x60003CB")]
		[Address(RVA = "0xC2B8F8", Offset = "0xC2B8F8", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = UnityEngine.Debug;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv58 = \"<color=#0099bc><b>DOTWEEN ► </b></color>\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A357BB]) = v41;\nL_001F:\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = DG.Tweening.DOTween;\nL_0026:\n\tv56 = ~v52.debugMode;\n\tif (v56) goto L_0036;\n\tv60 = DG.Tweening.Core.Debugger::GetDebugDataMessage(t);\n\tv65 = message == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tv77 = System.Object::ToString(message);\n\tgoto L_0043;\nL_0036:\n\tv62 = message == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tv70 = System.Object::ToString(message);\n\tgoto L_0048;\nL_0043:\n\tv101 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v60, v88);\n\tgoto L_FFFFFFFF;\nL_0048:\n\tv101 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v80);\n\tgoto L_0052;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v107, v99, v98, v97, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv113 = DG.Tweening.DOTween;\nL_0052:\n\tv133 = v114.onWillLog;\n\tv116 = v114.onWillLog == 0;\n\tif (v116) goto L_006C;\n\tv118 = *([v112 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_0064;\n\tv133 = v160.onWillLog;\nL_0064:\n\tv143 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v133, 3, v101);\n\tv144 = v143 & 1;\n\tv131 = v144 == 0;\n\tif (v131) goto L_00A8;\nL_006C:\n\tgoto L_0075;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v128, v124, v122, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv147 = DG.Tweening.DOTween;\nL_0075:\n\tv154 = v148.safeModeLogBehaviour == 3;\n\tif (v154) goto L_00AF;\n\tv204 = v148.safeModeLogBehaviour == 2;\n\tif (v204) goto L_00C1;\n\tv163 = v148.safeModeLogBehaviour != 1;\n\tif (v163) goto L_00A8;\n\tgoto L_00A0;\n\tv275 = \"il2cpp_codegen_runtime_class_init\"(v271, v124, v122, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A0:\n\tUnityEngine.Debug::Log(v101);\n\treturn;\nL_00A8:\n\treturn;\nL_00AF:\n\tgoto L_00B9;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v211, v124, v122, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00B9:\n\tUnityEngine.Debug::LogError(v101);\n\treturn;\nL_00C1:\n\tgoto L_00CB;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v265, v124, v122, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00CB:\n\tUnityEngine.Debug::LogWarning(v101);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogSafeModeCapturedError(object message, Tween t = null)
		{
			//IL_00a2: Expected I, but got O
			//IL_00fb: Expected O, but got I4
			string text3;
			if (DOTween.debugMode)
			{
				string debugDataMessage = GetDebugDataMessage(t);
				string text2;
				if (message != null)
				{
					string text = message.ToString();
					text2 = text;
				}
				else
				{
					text2 = null;
				}
				text3 = "<color=#0099bc><b>DOTWEEN ► </b></color>" + debugDataMessage + text2;
			}
			else
			{
				string text5;
				if (message != null)
				{
					string text4 = message.ToString();
					text5 = text4;
				}
				else
				{
					text5 = null;
				}
				text3 = "<color=#0099bc><b>DOTWEEN ► </b></color>" + text5;
			}
			nint num = (nint)typeof(DOTween);
			Func<LogType, object, bool> onWillLog = DOTween.onWillLog;
			if (DOTween.onWillLog != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((nint)0 == 0)
				{
					onWillLog = DOTween.onWillLog;
				}
				object obj = onWillLog(LogType.Log, text3);
				if ((int)((nint)obj & 1) == 0)
				{
					return;
				}
			}
			if (DOTween.safeModeLogBehaviour != SafeModeLogBehaviour.Error)
			{
				if (DOTween.safeModeLogBehaviour != SafeModeLogBehaviour.Warning)
				{
					if (DOTween.safeModeLogBehaviour == SafeModeLogBehaviour.Normal)
					{
						Debug.Log(text3);
					}
				}
				else
				{
					Debug.LogWarning(text3);
				}
			}
			else
			{
				Debug.LogError(text3);
			}
		}

		[Token(Token = "0x60003CC")]
		[Address(RVA = "0xC2BB1C", Offset = "0xC2BB1C", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = UnityEngine.Debug;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv61 = \"<color=#0099bc><b>DOTWEEN ► </b></color>\";\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv72 = \"<color=#00B500FF>{0} REPORT ►</color> {1}\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A357BC]) = v46;\nL_0026:\n\tv51 = System.String::Format(\"<color=#00B500FF>{0} REPORT ►</color> {1}\", \"<color=#0099bc><b>DOTWEEN ► </b></color>\", message);\n\tgoto L_0031;\n\tv63 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v63, v48, v49, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv67 = DG.Tweening.DOTween;\nL_0031:\n\tv85 = v68.onWillLog;\n\tv70 = v68.onWillLog == 0;\n\tif (v70) goto L_004E;\n\tv74 = *([v66 @ X8_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0044;\n\tv85 = v105.onWillLog;\nL_0044:\n\tv87 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v85, 3, v51);\n\tv107 = v87 & 1;\n\tv89 = v107 == 0;\n\tif (v89) goto L_0062;\nL_004E:\n\tgoto L_0059;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v94, v78, v76, v80, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0059:\n\tUnityEngine.Debug::Log(v51);\n\treturn;\nL_0062:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogReport(object message)
		{
			//IL_00ba: Expected I, but got O
			//IL_0059: Expected O, but got I4
			string text = string.Format("<color=#00B500FF>{0} REPORT ►</color> {1}", "<color=#0099bc><b>DOTWEEN ► </b></color>", message);
			nint num = (nint)typeof(DOTween);
			Func<LogType, object, bool> onWillLog = DOTween.onWillLog;
			if (DOTween.onWillLog != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((nint)0 == 0)
				{
					onWillLog = DOTween.onWillLog;
				}
				object obj = onWillLog(LogType.Log, text);
				if ((int)((nint)obj & 1) == 0)
				{
					return;
				}
			}
			Debug.Log(text);
		}

		[Token(Token = "0x60003CD")]
		[Address(RVA = "0xC2BC44", Offset = "0xC2BC44", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = UnityEngine.Debug;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv61 = \"<color=#0099bc><b>DOTWEEN ► </b></color>\";\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv72 = \"<color=#ff7337>{0} SAFE MODE ►</color> {1}\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A357BD]) = v46;\nL_0026:\n\tv51 = System.String::Format(\"<color=#ff7337>{0} SAFE MODE ►</color> {1}\", \"<color=#0099bc><b>DOTWEEN ► </b></color>\", message);\n\tgoto L_0031;\n\tv63 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v63, v48, v49, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv67 = DG.Tweening.DOTween;\nL_0031:\n\tv85 = v68.onWillLog;\n\tv70 = v68.onWillLog == 0;\n\tif (v70) goto L_004E;\n\tv74 = *([v66 @ X8_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0044;\n\tv85 = v105.onWillLog;\nL_0044:\n\tv87 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v85, 3, v51);\n\tv107 = v87 & 1;\n\tv89 = v107 == 0;\n\tif (v89) goto L_0062;\nL_004E:\n\tgoto L_0059;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v94, v78, v76, v80, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0059:\n\tUnityEngine.Debug::LogWarning(v51);\n\treturn;\nL_0062:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogSafeModeReport(object message)
		{
			//IL_00ba: Expected I, but got O
			//IL_0059: Expected O, but got I4
			string text = string.Format("<color=#ff7337>{0} SAFE MODE ►</color> {1}", "<color=#0099bc><b>DOTWEEN ► </b></color>", message);
			nint num = (nint)typeof(DOTween);
			Func<LogType, object, bool> onWillLog = DOTween.onWillLog;
			if (DOTween.onWillLog != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((nint)0 == 0)
				{
					onWillLog = DOTween.onWillLog;
				}
				object obj = onWillLog(LogType.Log, text);
				if ((int)((nint)obj & 1) == 0)
				{
					return;
				}
			}
			Debug.LogWarning(text);
		}

		[Token(Token = "0x60003CE")]
		[Address(RVA = "0xC2BD6C", Offset = "0xC2BD6C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = \"This Tween has been killed and is now invalid\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357BE]) = v34;\nL_0017:\n\tDG.Tweening.Core.Debugger::LogWarning(\"This Tween has been killed and is now invalid\", 0);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogInvalidTween(Tween t)
		{
			LogWarning("This Tween has been killed and is now invalid");
		}

		[Token(Token = "0x60003CF")]
		[Address(RVA = "0xC2BDB0", Offset = "0xC2BDB0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = \"This Tween was added to a Sequence and can't be controlled directly\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357BF]) = v37;\nL_001A:\n\tDG.Tweening.Core.Debugger::LogWarning(\"This Tween was added to a Sequence and can't be controlled directly\", t);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogNestedTween(Tween t)
		{
			LogWarning("This Tween was added to a Sequence and can't be controlled directly", t);
		}

		[Token(Token = "0x60003D0")]
		[Address(RVA = "0xC2BDF8", Offset = "0xC2BDF8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = \"Null Tween\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357C0]) = v34;\nL_0017:\n\tDG.Tweening.Core.Debugger::LogWarning(\"Null Tween\", 0);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogNullTween(Tween t)
		{
			LogWarning("Null Tween");
		}

		[Token(Token = "0x60003D1")]
		[Address(RVA = "0xC2BE3C", Offset = "0xC2BE3C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = \"This Tween is not a path tween\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357C1]) = v37;\nL_001A:\n\tDG.Tweening.Core.Debugger::LogWarning(\"This Tween is not a path tween\", t);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogNonPathTween(Tween t)
		{
			LogWarning("This Tween is not a path tween", t);
		}

		[Token(Token = "0x60003D2")]
		[Address(RVA = "0xC2BE84", Offset = "0xC2BE84", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = \"This material doesn't have a {0} property\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357C2]) = v37;\nL_0016:\n\tv41 = System.String::Format(\"This material doesn't have a {0} property\", propertyName);\n\tDG.Tweening.Core.Debugger::LogWarning(v41, 0);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogMissingMaterialProperty(string propertyName)
		{
			string message = $"This material doesn't have a {propertyName} property";
			LogWarning(message);
		}

		[Token(Token = "0x60003D3")]
		[Address(RVA = "0xC2BED8", Offset = "0xC2BED8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = System.Int32;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = \"This material doesn't have a {0} property ID\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A357C3]) = v42;\nL_001C:\n\t// 28 Box v46 @ X0_v3 (System.Object), typeof(System.Int32), &propertyId @ X0 (System.Int32)\n\tv53 = System.String::Format(\"This material doesn't have a {0} property ID\", v46);\n\tDG.Tweening.Core.Debugger::LogWarning(v53, 0);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogMissingMaterialProperty(int propertyId)
		{
			object arg = propertyId;
			string message = $"This material doesn't have a {arg} property ID";
			LogWarning(message);
		}

		[Token(Token = "0x60003D4")]
		[Address(RVA = "0xC2BF60", Offset = "0xC2BF60", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = \"Error in RemoveActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.\";\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A357C4]) = v40;\nL_0018:\n\tv44 = System.String::Format(\"Error in RemoveActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.\", errorInfo);\n\tDG.Tweening.Core.Debugger::LogWarning(v44, t);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogRemoveActiveTweenError(string errorInfo, Tween t)
		{
			string message = $"Error in RemoveActiveTween ({errorInfo}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.";
			LogWarning(message, t);
		}

		[Token(Token = "0x60003D5")]
		[Address(RVA = "0xC2BFC0", Offset = "0xC2BFC0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = \"Error in AddActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.\";\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A357C5]) = v40;\nL_0018:\n\tv44 = System.String::Format(\"Error in AddActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.\", errorInfo);\n\tDG.Tweening.Core.Debugger::LogWarning(v44, t);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogAddActiveTweenError(string errorInfo, Tween t)
		{
			string message = $"Error in AddActiveTween ({errorInfo}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.";
			LogWarning(message, t);
		}

		[Token(Token = "0x60003D6")]
		[Address(RVA = "0xC2C020", Offset = "0xC2C020", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = DG.Tweening.Core.Debugger;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A357C6]) = v33;\nL_0012:\n\tv36 = logBehaviour == 0;\n\tif (v36) goto L_FFFFFFFF;\n\tv48 = logBehaviour != 1;\n\tif (v48) goto L_0028;\n\tgoto L_0026;\nL_0026:\n\tv72._logPriority = v53;\n\tgoto L_002D;\nL_0028:\n\tv47._logPriority = 0;\nL_002D:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetLogPriority(LogBehaviour logBehaviour)
		{
			int num;
			switch (logBehaviour)
			{
			case LogBehaviour.Verbose:
				num = 2;
				break;
			case LogBehaviour.Default:
				num = 1;
				break;
			default:
				_logPriority = 0;
				return;
			}
			_logPriority = num;
		}

		[Token(Token = "0x60003D7")]
		[Address(RVA = "0xC2C094", Offset = "0xC2C094", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.Core.Debugger;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A357C7]) = v35;\nL_0018:\n\tgoto L_001D;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv44 = DG.Tweening.DOTween;\nL_001D:\n\tv47 = v45.safeModeLogBehaviour == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv48 = v45.safeModeLogBehaviour - 1;\n\tv49 = v48 < 1;\n\tv50 = ~v49;\n\tv51 = v48 - 1;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_FFFFFFFF;\n\tv69 = v64._logPriority < 0;\n\tv70 = v64._logPriority == 0;\n\tv72 = v64._logPriority ^ v64._logPriority;\n\tv73 = v64._logPriority & v72;\n\tv74 = v73 < 0;\n\tv75 = v69 == v74;\n\tv76 = ~v70;\n\tv77 = v75 & v76;\n\tgoto L_0046;\n\tgoto L_0046;\nL_0046:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ShouldLogSafeModeCapturedError()
		{
			if (DOTween.safeModeLogBehaviour != SafeModeLogBehaviour.None)
			{
				int num = (int)(DOTween.safeModeLogBehaviour - 1);
				bool flag = num < 1;
				bool flag2 = !flag;
				int num2 = num - 1;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					bool flag5 = _logPriority < 0;
					bool flag6 = _logPriority == 0;
					int num3 = _logPriority ^ _logPriority;
					int num4 = _logPriority & num3;
					bool flag7 = num4 < 0;
					bool flag8 = flag5 == flag7;
					bool flag9 = !flag6;
					return flag8 && flag9;
				}
				return true;
			}
			return false;
		}

		[Token(Token = "0x60003D8")]
		[Address(RVA = "0xC2B708", Offset = "0xC2B708", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = \"\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357C8]) = v37;\nL_0016:\n\tv40 = \"\";\n\tDG.Tweening.Core.Debugger::AddDebugDataToMessage(&v40 @ stack_-28_v1 (System.String), t);\n\treturn \"\";\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetDebugDataMessage(Tween t)
		{
			string message = "";
			AddDebugDataToMessage(ref message, t);
			return "";
		}

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0xC2C134", Offset = "0xC2C134", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv24 = System.Int32;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = \"[stringId: {0}]\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv99 = \"\\n\";\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv115 = \"[intId: {0}]\";\n\tv116 = \"il2cpp_codegen_initialize_runtime_metadata\"(v115, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv120 = \"DEBUG MODE INFO ► \";\n\tv121 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv139 = \"[tween target: {0}]\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v139, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A357C9]) = v43;\nL_0024:\n\tv44 = t == 0;\n\tif (v44) goto L_0082;\n\tv51 = t.debugTargetId == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_003A;\n\tv101 = t.stringId == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_003A;\n\tv86 = t.intId + 0x3E7;\n\tv73 = v86 == 0;\n\tif (v73) goto L_0082;\nL_003A:\n\tv113 = System.String::Concat(*([message @ X0 (System.String&)]), \"DEBUG MODE INFO ► \");\n\t*([message @ X0 (System.String&)]) = v113;\n\tv118 = t.debugTargetId == 0;\n\tif (v118) goto L_004B;\n\tv127 = System.String::Format(\"[tween target: {0}]\", t.debugTargetId);\n\tv133 = System.String::Concat(v113, v127);\n\t*([message @ X0 (System.String&)]) = v133;\nL_004B:\n\tv137 = t.stringId == 0;\n\tif (v137) goto L_0059;\n\tv146 = System.String::Format(\"[stringId: {0}]\", t.stringId);\n\tv152 = System.String::Concat(v90, v146);\n\t*([message @ X0 (System.String&)]) = v152;\nL_0059:\n\tv85 = t.intId + 0x3E7;\n\tv72 = v85 == 0;\n\tif (v72) goto L_0078;\n\tv158 = t.intId;\n\t// 101 Box v163 @ X0_v11 (System.Object), typeof(System.Int32), &v158 @ X8_v11 (System.Int32)\n\tv180 = System.String::Format(\"[intId: {0}]\", v163);\n\tv169 = System.String::Concat(v90, v180);\n\t*([message @ X0 (System.String&)]) = v169;\nL_0078:\n\tv83 = System.String::Concat(v90, \"\\n\");\n\t*([message @ X0 (System.String&)]) = v83;\nL_0082:\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void AddDebugDataToMessage(ref string message, Tween t)
		{
			if (t != null && (t.debugTargetId != null || t.stringId != null || t.intId + 999 != 0))
			{
				string text = message + "DEBUG MODE INFO ► ";
				ref string reference = ref *(string*)text;
				bool flag = t.debugTargetId == null;
				string text2 = text;
				if (!flag)
				{
					string text3 = $"[tween target: {t.debugTargetId}]";
					string text4 = text + text3;
					reference = ref *(string*)text4;
					text2 = text4;
				}
				if (t.stringId != null)
				{
					string text5 = $"[stringId: {t.stringId}]";
					string text6 = text2 + text5;
					reference = ref *(string*)text6;
					text2 = text6;
				}
				if (t.intId + 999 != 0)
				{
					int intId = t.intId;
					object arg = intId;
					string text7 = $"[intId: {arg}]";
					string text8 = text2 + text7;
					reference = ref *(string*)text8;
					text2 = text8;
				}
				string text9 = text2 + "\n";
				reference = ref *(string*)text9;
			}
		}
	}
}
