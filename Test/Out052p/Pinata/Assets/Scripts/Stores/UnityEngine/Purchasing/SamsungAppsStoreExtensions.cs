using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000030")]
	internal class SamsungAppsStoreExtensions : AndroidJavaProxy, ISamsungAppsCallback, ISamsungAppsExtensions, IStoreExtension, ISamsungAppsConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x20")]
		private Action<bool> m_RestoreCallback;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x28")]
		private AndroidJavaObject m_Java;

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0xC6AF00", Offset = "0xC6AF00", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE4F40]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20233B5]) = v38;\nL_0019:\n\tgoto L_0029;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0029;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.purchasing.samsung.ISamsungAppsStoreCallback\");\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SamsungAppsStoreExtensions()
			: base("com.unity.purchasing.samsung.ISamsungAppsStoreCallback")
		{
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0xC6AF74", Offset = "0xC6AF74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Java = java;\n\treturn;\n")]
		public void SetAndroidJavaObject(AndroidJavaObject java)
		{
			m_Java = java;
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0xC6E788", Offset = "0xC6E788", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EDC680]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, mode, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20233B6]) = v43;\nL_001B:\n\t// 27 NewArr v49 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 34 Box v56 @ X0_v5, typeof(UnityEngine.Purchasing.SamsungAppsMode), &mode @ X1 (UnityEngine.Purchasing.SamsungAppsMode)\n\tv59 = *([v56 @ X0_v5]);\n\t*([v59 @ X8_v11+160])(v63, v56, *([v59 @ X8_v11+168]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv66 = \"il2cpp_vm_object_unbox\"(v56, *([v59 @ X8_v11+168]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv95 = v63 == 0;\n\tif (v95) goto L_003B;\n\t// 55 IsInst v102 @ X0_v22, typeof(System.Object), v63 @ X0_v13\nL_003B:\n\tv90 = v49.Length == 0;\n\tif (v90) goto L_0052;\n\tv49[0] = v63;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Java, \"setMode\", v49);\n\treturn;\n\tv73 = new System.NullReferenceException();\n\tv80 = new System.NullReferenceException();\nL_0052:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0057;\n\tv110 = new System.ArrayTypeMismatchException();\nL_0057:\n\tthrow v109;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMode(SamsungAppsMode mode)
		{
			object[] array = new object[1];
			object obj = mode;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ X8_v11+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj3;
				m_Java.Call("setMode", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0xC6E8A8", Offset = "0xC6E8A8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBAA58]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233B7]) = v41;\nL_0015:\n\tthis.m_RestoreCallback = callback;\n\t// 27 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 0\n\tUnityEngine.AndroidJavaObject::Call(this.m_Java, \"restoreTransactions\", v47);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactions(Action<bool> callback)
		{
			m_RestoreCallback = callback;
			object[] args = new object[0];
			m_Java.Call("restoreTransactions", args);
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xC6E934", Offset = "0xC6E934", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED9FF8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233B8]) = v41;\nL_0016:\n\tv43 = this.m_RestoreCallback == 0;\n\tif (v43) goto L_002A;\n\tSystem.Action`1<System.Boolean>::Invoke(this.m_RestoreCallback, result);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTransactionsRestored(bool result)
		{
			if (m_RestoreCallback != null)
			{
				m_RestoreCallback(result);
			}
		}
	}
}
