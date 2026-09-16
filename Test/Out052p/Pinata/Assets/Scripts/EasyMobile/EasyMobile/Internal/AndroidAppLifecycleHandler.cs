using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000B4")]
	public class AndroidAppLifecycleHandler : IAppLifecycleHandler
	{
		[Token(Token = "0x40003A1")]
		private const string ANDROID_JAVA_CLASS = "com.sglib.easymobile.androidnative.AppUtil";

		[Token(Token = "0x60006DC")]
		[Address(RVA = "0xBFADB4", Offset = "0xBFADB4", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEAEF0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, isFocus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022F21]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 30 Box v50 @ X0_v5, typeof(System.Boolean), &isFocus @ X1 (System.Boolean)\n\tv53 = v50 == 0;\n\tif (v53) goto L_002B;\n\t// 39 IsInst v59 @ X0_v15, typeof(System.Object), v50 @ X0_v5\nL_002B:\n\tv66 = v43.Length == 0;\n\tif (v66) goto L_003E;\n\tv43[0] = v50;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.AppUtil\", \"OnApplicationFocus\", v43);\n\treturn;\n\tv55 = new System.NullReferenceException();\nL_003E:\n\tv71 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv79 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v85;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnApplicationFocus(bool isFocus)
		{
			object[] array = new object[1];
			object obj = isFocus;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.AppUtil", "OnApplicationFocus", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60006DD")]
		[Address(RVA = "0xBFB070", Offset = "0xBFB070", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAF730]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, isPaused, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022F22]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 30 Box v50 @ X0_v5, typeof(System.Boolean), &isPaused @ X1 (System.Boolean)\n\tv53 = v50 == 0;\n\tif (v53) goto L_002B;\n\t// 39 IsInst v59 @ X0_v15, typeof(System.Object), v50 @ X0_v5\nL_002B:\n\tv66 = v43.Length == 0;\n\tif (v66) goto L_003E;\n\tv43[0] = v50;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.AppUtil\", \"OnApplicationPause\", v43);\n\treturn;\n\tv55 = new System.NullReferenceException();\nL_003E:\n\tv71 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv79 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v85;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnApplicationPause(bool isPaused)
		{
			object[] array = new object[1];
			object obj = isPaused;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.AppUtil", "OnApplicationPause", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60006DE")]
		[Address(RVA = "0xBFB154", Offset = "0xBFB154", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EF4C28]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022F23]) = v37;\nL_0016:\n\tv42 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_001F;\n\tv47 = v42;\n\tv48 = 0x8907BC(v47, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv51 = *([v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_001F:\n\tv52 = *([v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv53 = v52 == 0;\n\tif (v53) goto L_0040;\n\tv55 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002C;\n\tv77 = v55;\n\tv78 = 0x8907BC(v77, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002C:\n\tv79 = *([v55 @ X19_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv65 = ~v79;\n\tif (v65) goto L_0040;\n\tgoto L_0040;\n\tv98 = v70;\n\tv99 = 0x8907BC(v98, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0040:\n\tgoto L_0050;\n\tv80 = v72;\n\tv81 = 0x8907BC(v80, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0050:\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.AppUtil\", \"OnApplicationQuit\", v85.Value);\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnApplicationQuit()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X19_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.AppUtil", "OnApplicationQuit");
		}

		[Token(Token = "0x60006DF")]
		[Address(RVA = "0xBFB234", Offset = "0xBFB234", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidAppLifecycleHandler()
		{
		}
	}
}
