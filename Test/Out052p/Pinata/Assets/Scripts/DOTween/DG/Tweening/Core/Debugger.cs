using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x200004B")]
	public static class Debugger
	{
		[Token(Token = "0x4000135")]
		public static int _logPriority;

		[Token(Token = "0x4000136")]
		private const string _LogPrefix = "<color=#0099bc><b>DOTWEEN ► </b></colo";

		[Token(Token = "0x17000007")]
		public static int logPriority
		{
			[Token(Token = "0x6000278")]
			[Address(RVA = "0x1071F54", Offset = "0x1071F54", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1ED64E0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026993]) = v35;\nL_001A:\n\treturn v41._logPriority;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _logPriority;
			}
		}

		[Token(Token = "0x6000279")]
		[Address(RVA = "0x1071FA4", Offset = "0x1071FA4", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC5DA0]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026994]) = v38;\nL_0016:\n\tv42 = message == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv47 = System.Object::ToString(message);\n\tgoto L_0022;\nL_0022:\n\tv57 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v50);\n\tgoto L_0034;\n\tv65 = *([v61 @ X8_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0034;\n\tv77 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v77, v50, v56, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv73 = DG.Tweening.DOTween;\nL_0034:\n\tv76 = v74.onWillLog == 0;\n\tif (v76) goto L_0054;\n\tgoto L_004A;\n\tv101 = *([v72 @ X8_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_004A;\n\tv127 = DG.Tweening.DOTween;\n\tv109 = *([v127 @ X8_v17 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv105 = v109.onWillLog;\nL_004A:\n\tv90 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v74.onWillLog, 3, v57);\n\tv92 = v90 == 0;\n\tif (v92) goto L_0068;\nL_0054:\n\tgoto L_0061;\n\tv111 = *([v97 @ X0_v8+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0061;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v97, v85, v83, v81, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0061:\n\tUnityEngine.Debug::Log(v57);\n\treturn;\nL_0068:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Log(object message)
		{
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
			if (DOTween.onWillLog == null || DOTween.onWillLog(LogType.Log, text3))
			{
				Debug.Log(text3);
			}
		}

		[Token(Token = "0x600027A")]
		[Address(RVA = "0x106F4F8", Offset = "0x106F4F8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE2448]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026995]) = v38;\nL_0016:\n\tv42 = message == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv47 = System.Object::ToString(message);\n\tgoto L_0022;\nL_0022:\n\tv57 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v50);\n\tgoto L_0034;\n\tv65 = *([v61 @ X8_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0034;\n\tv77 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v77, v50, v56, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv73 = DG.Tweening.DOTween;\nL_0034:\n\tv76 = v74.onWillLog == 0;\n\tif (v76) goto L_0054;\n\tgoto L_004A;\n\tv101 = *([v72 @ X8_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_004A;\n\tv127 = DG.Tweening.DOTween;\n\tv109 = *([v127 @ X8_v17 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv105 = v109.onWillLog;\nL_004A:\n\tv90 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v74.onWillLog, 2, v57);\n\tv92 = v90 == 0;\n\tif (v92) goto L_0068;\nL_0054:\n\tgoto L_0061;\n\tv111 = *([v97 @ X0_v8+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0061;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v97, v85, v83, v81, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0061:\n\tUnityEngine.Debug::LogWarning(v57);\n\treturn;\nL_0068:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogWarning(object message)
		{
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
			if (DOTween.onWillLog == null || DOTween.onWillLog(LogType.Warning, text3))
			{
				Debug.LogWarning(text3);
			}
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0x106F8D0", Offset = "0x106F8D0", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDFF18]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026996]) = v38;\nL_0016:\n\tv42 = message == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv47 = System.Object::ToString(message);\n\tgoto L_0022;\nL_0022:\n\tv57 = System.String::Concat(\"<color=#0099bc><b>DOTWEEN ► </b></color>\", v50);\n\tgoto L_0034;\n\tv65 = *([v61 @ X8_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0034;\n\tv77 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v77, v50, v56, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv73 = DG.Tweening.DOTween;\nL_0034:\n\tv76 = v74.onWillLog == 0;\n\tif (v76) goto L_0054;\n\tgoto L_004A;\n\tv101 = *([v72 @ X8_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_004A;\n\tv127 = DG.Tweening.DOTween;\n\tv109 = *([v127 @ X8_v17 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv105 = v109.onWillLog;\nL_004A:\n\tv90 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v74.onWillLog, 0, v57);\n\tv92 = v90 == 0;\n\tif (v92) goto L_0068;\nL_0054:\n\tgoto L_0061;\n\tv111 = *([v97 @ X0_v8+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0061;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v97, v85, v83, v81, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0061:\n\tUnityEngine.Debug::LogError(v57);\n\treturn;\nL_0068:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogError(object message)
		{
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
			if (DOTween.onWillLog == null || DOTween.onWillLog(default(LogType), text3))
			{
				Debug.LogError(text3);
			}
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0x1070B40", Offset = "0x1070B40", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EAB5C0]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026997]) = v38;\nL_001B:\n\tv47 = System.String::Format(\"<color=#00B500FF>{0} REPORT ►</color> {1}\", \"<color=#0099bc><b>DOTWEEN ► </b></color>\", message);\n\tgoto L_002D;\n\tv55 = *([v51 @ X8_v5 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002D;\n\tv67 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v67, v46, v43, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = DG.Tweening.DOTween;\nL_002D:\n\tv66 = v64.onWillLog == 0;\n\tif (v66) goto L_004D;\n\tgoto L_0043;\n\tv91 = *([v62 @ X8_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0043;\n\tv117 = DG.Tweening.DOTween;\n\tv99 = *([v117 @ X8_v16 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv95 = v99.onWillLog;\nL_0043:\n\tv80 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v64.onWillLog, 3, v47);\n\tv82 = v80 == 0;\n\tif (v82) goto L_0061;\nL_004D:\n\tgoto L_005A;\n\tv101 = *([v87 @ X0_v7+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_005A;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v87, v75, v73, v71, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005A:\n\tUnityEngine.Debug::Log(v47);\n\treturn;\nL_0061:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogReport(object message)
		{
			string text = string.Format("<color=#00B500FF>{0} REPORT ►</color> {1}", "<color=#0099bc><b>DOTWEEN ► </b></color>", message);
			if (DOTween.onWillLog == null || DOTween.onWillLog(LogType.Log, text))
			{
				Debug.Log(text);
			}
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0x1070C70", Offset = "0x1070C70", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EE4090]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026998]) = v38;\nL_001B:\n\tv47 = System.String::Format(\"<color=#ff7337>{0} SAFE MODE ►</color> {1}\", \"<color=#0099bc><b>DOTWEEN ► </b></color>\", message);\n\tgoto L_002D;\n\tv55 = *([v51 @ X8_v5 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002D;\n\tv67 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v67, v46, v43, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = DG.Tweening.DOTween;\nL_002D:\n\tv66 = v64.onWillLog == 0;\n\tif (v66) goto L_004D;\n\tgoto L_0043;\n\tv91 = *([v62 @ X8_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0043;\n\tv117 = DG.Tweening.DOTween;\n\tv99 = *([v117 @ X8_v16 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv95 = v99.onWillLog;\nL_0043:\n\tv80 = System.Func`3<UnityEngine.LogType, System.Object, System.Boolean>::Invoke(v64.onWillLog, 3, v47);\n\tv82 = v80 == 0;\n\tif (v82) goto L_0061;\nL_004D:\n\tgoto L_005A;\n\tv101 = *([v87 @ X0_v7+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_005A;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v87, v75, v73, v71, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005A:\n\tUnityEngine.Debug::LogWarning(v47);\n\treturn;\nL_0061:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogSafeModeReport(object message)
		{
			string text = string.Format("<color=#ff7337>{0} SAFE MODE ►</color> {1}", "<color=#0099bc><b>DOTWEEN ► </b></color>", message);
			if (DOTween.onWillLog == null || DOTween.onWillLog(LogType.Log, text))
			{
				Debug.LogWarning(text);
			}
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0x10720D0", Offset = "0x10720D0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EA4108]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026999]) = v35;\nL_0018:\n\tDG.Tweening.Core.Debugger::LogWarning(\"This Tween has been killed and is now invalid\");\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogInvalidTween(Tween t)
		{
			LogWarning("This Tween has been killed and is now invalid");
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0x1072118", Offset = "0x1072118", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE87E8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202699A]) = v35;\nL_0018:\n\tDG.Tweening.Core.Debugger::LogWarning(\"This Tween was added to a Sequence and can't be controlled directly\");\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogNestedTween(Tween t)
		{
			LogWarning("This Tween was added to a Sequence and can't be controlled directly");
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0x1072160", Offset = "0x1072160", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EA9A70]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202699B]) = v35;\nL_0018:\n\tDG.Tweening.Core.Debugger::LogWarning(\"Null Tween\");\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogNullTween(Tween t)
		{
			LogWarning("Null Tween");
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0x10721A8", Offset = "0x10721A8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1ED63B8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202699C]) = v35;\nL_0018:\n\tDG.Tweening.Core.Debugger::LogWarning(\"This Tween is not a path tween\");\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogNonPathTween(Tween t)
		{
			LogWarning("This Tween is not a path tween");
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0x10721F0", Offset = "0x10721F0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFC6A0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202699D]) = v38;\nL_0018:\n\tv44 = System.String::Format(\"This material doesn't have a {0} property\", propertyName);\n\tDG.Tweening.Core.Debugger::LogWarning(v44);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogMissingMaterialProperty(string propertyName)
		{
			string message = $"This material doesn't have a {propertyName} property";
			LogWarning(message);
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0x1072248", Offset = "0x1072248", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE7650]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202699E]) = v38;\nL_0018:\n\t// 24 Box v44 @ X0_v3 (System.Object), typeof(System.Int32), &propertyId @ X0 (System.Int32)\n\tv51 = System.String::Format(\"This material doesn't have a {0} property ID\", v44);\n\tDG.Tweening.Core.Debugger::LogWarning(v51);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogMissingMaterialProperty(int propertyId)
		{
			object arg = propertyId;
			string message = $"This material doesn't have a {arg} property ID";
			LogWarning(message);
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0x10722C8", Offset = "0x10722C8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECD850]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202699F]) = v38;\nL_0018:\n\tv44 = System.String::Format(\"Error in RemoveActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.\", errorInfo);\n\tDG.Tweening.Core.Debugger::LogWarning(v44);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogRemoveActiveTweenError(string errorInfo)
		{
			string message = $"Error in RemoveActiveTween ({errorInfo}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.";
			LogWarning(message);
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0x1072320", Offset = "0x1072320", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA3420]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269A0]) = v38;\nL_0018:\n\tv44 = System.String::Format(\"Error in AddActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.\", errorInfo);\n\tDG.Tweening.Core.Debugger::LogWarning(v44);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogAddActiveTweenError(string errorInfo)
		{
			string message = $"Error in AddActiveTween ({errorInfo}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.";
			LogWarning(message);
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0x1072378", Offset = "0x1072378", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EABA68]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269A1]) = v38;\nL_0013:\n\tv39 = logBehaviour == 0;\n\tif (v39) goto L_002C;\n\tv53 = logBehaviour != 1;\n\tif (v53) goto L_002E;\n\tv52._logPriority = 2;\n\tgoto L_0034;\nL_002C:\n\tv58._logPriority = 1;\n\tgoto L_0034;\nL_002E:\n\tv52._logPriority = 0;\nL_0034:\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetLogPriority(LogBehaviour logBehaviour)
		{
			switch (logBehaviour)
			{
			case LogBehaviour.Verbose:
				_logPriority = 2;
				break;
			case LogBehaviour.Default:
				_logPriority = 1;
				break;
			default:
				_logPriority = 0;
				break;
			}
		}
	}
}
