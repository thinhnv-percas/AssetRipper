using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200002E")]
	internal class SamsungAppsJavaBridge : AndroidJavaProxy, ISamsungAppsCallback
	{
		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x20")]
		private ISamsungAppsCallback forwardTo;

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0xC6E63C", Offset = "0xC6E63C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAB908]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, forwardTo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233B3]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, forwardTo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.purchasing.samsung.ISamsungAppsCallback\");\n\tthis.forwardTo = forwardTo;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SamsungAppsJavaBridge(ISamsungAppsCallback forwardTo)
			: base("com.unity.purchasing.samsung.ISamsungAppsCallback")
		{
			this.forwardTo = forwardTo;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0xC6E6C4", Offset = "0xC6E6C4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ED6708]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233B4]) = v41;\nL_001E:\n\tgoto L_004C;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v42;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v48, v91, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 << 4;\n\tv169 = v45 + v168;\n\tv170 = v169 + 0x130;\nL_004C:\n\tUnityEngine.Purchasing.ISamsungAppsCallback::OnTransactionsRestored(this.forwardTo, result);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTransactionsRestored(bool result)
		{
			forwardTo.OnTransactionsRestored(result);
		}
	}
}
