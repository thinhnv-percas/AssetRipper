using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000007")]
	internal class JavaBridge : AndroidJavaProxy, IUnityCallback
	{
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x20")]
		private IUnityCallback forwardTo;

		[Token(Token = "0x600001C")]
		[Address(RVA = "0xC64970", Offset = "0xC64970", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF35D8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, forwardTo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023357]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, forwardTo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.purchasing.common.IUnityCallback\");\n\tthis.forwardTo = forwardTo;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JavaBridge(IUnityCallback forwardTo)
			: base("com.unity.purchasing.common.IUnityCallback")
		{
			this.forwardTo = forwardTo;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0xC649F8", Offset = "0xC649F8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EECBA0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, forwardTo, javaInterface, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023358]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, forwardTo, javaInterface, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, javaInterface);\n\tthis.forwardTo = forwardTo;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JavaBridge(IUnityCallback forwardTo, string javaInterface)
			: base(javaInterface)
		{
			this.forwardTo = forwardTo;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0xC64A7C", Offset = "0xC64A7C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EB6C10]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023359]) = v41;\nL_001E:\n\tgoto L_004C;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v42;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v48, v91, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 << 4;\n\tv169 = v45 + v168;\n\tv170 = v169 + 0x130;\nL_004C:\n\tUnityEngine.Purchasing.IUnityCallback::OnSetupFailed(this.forwardTo, json);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnSetupFailed(string json)
		{
			forwardTo.OnSetupFailed(json);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0xC64B40", Offset = "0xC64B40", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEC8F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202335A]) = v41;\nL_0015:\n\tv42 = this.forwardTo;\n\tv45 = *([v42 @ X20_v2 (UnityEngine.Purchasing.IUnityCallback)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == UnityEngine.Purchasing.IUnityCallback;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, UnityEngine.Purchasing.IUnityCallback, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (UnityEngine.Purchasing.IUnityCallback), v42 @ X20_v2 (UnityEngine.Purchasing.IUnityCallback), json @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnProductsRetrieved(string json)
		{
			//IL_000d: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IUnityCallback unityCallback = forwardTo;
			IntPtr intPtr = (IntPtr)unityCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUnityCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0139;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0139;
			IL_0139:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0xC64C08", Offset = "0xC64C08", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EF2BF8]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, id, receipt, transactionID, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202335B]) = v47;\nL_0019:\n\tv48 = this.forwardTo;\n\tv51 = *([v48 @ X22_v2 (UnityEngine.Purchasing.IUnityCallback)]);\n\tv55 = *([v51 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]) == 0;\n\tif (v55) goto L_0040;\n\tv109 = *([v51 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]) + 8;\nL_002B:\n\tv115 = *([v109 @ X11_v5-8]) == UnityEngine.Purchasing.IUnityCallback;\n\tif (v115) goto L_0043;\n\tv110 = v110 + 1;\n\tv180 = v110 < *([v51 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]);\n\tv89 = ~v180;\n\tv109 = v109 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_002B;\nL_0040:\n\tv187 = 0x8909C4(v48, UnityEngine.Purchasing.IUnityCallback, 2, transactionID, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0047;\nL_0043:\n\tv182 = *([v109 @ X11_v5]) + 2;\n\tv183 = v182 << 4;\n\tv184 = v51 + v183;\n\tv187 = v184 + 0x130;\nL_0047:\n\tv127 = *([v187 @ X0_v4]);\n\tv125 = *([v187 @ X0_v4+8]);\n\t// 85 IndirectJump v127 @ X5_v1, v48 @ X22_v2 (UnityEngine.Purchasing.IUnityCallback), v48 @ X22_v2 (UnityEngine.Purchasing.IUnityCallback), id @ X1 (System.String), receipt @ X2 (System.String), transactionID @ X3 (System.String), v125 @ X4_v1, v127 @ X5_v1, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseSucceeded(string id, string receipt, string transactionID)
		{
			//IL_000d: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IUnityCallback unityCallback = forwardTo;
			IntPtr intPtr = (IntPtr)unityCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUnityCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0139;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0139;
			IL_0139:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0xC64CE8", Offset = "0xC64CE8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC7838]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202335C]) = v41;\nL_0015:\n\tv42 = this.forwardTo;\n\tv45 = *([v42 @ X20_v2 (UnityEngine.Purchasing.IUnityCallback)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == UnityEngine.Purchasing.IUnityCallback;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, UnityEngine.Purchasing.IUnityCallback, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 3;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (UnityEngine.Purchasing.IUnityCallback), v42 @ X20_v2 (UnityEngine.Purchasing.IUnityCallback), json @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(string json)
		{
			//IL_000d: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IUnityCallback unityCallback = forwardTo;
			IntPtr intPtr = (IntPtr)unityCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUnityCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0139;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0139;
			IL_0139:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		}
	}
}
