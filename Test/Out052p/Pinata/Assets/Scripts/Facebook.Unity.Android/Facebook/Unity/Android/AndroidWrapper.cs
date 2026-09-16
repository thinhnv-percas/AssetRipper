using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.Unity.Mobile.Android;
using UnityEngine;

namespace Facebook.Unity.Android
{
	[Token(Token = "0x2000002")]
	internal class AndroidWrapper : Facebook.Unity.Mobile.Android.IAndroidWrapper
	{
		[Token(Token = "0x4000001")]
		private const string FacebookJavaClassName = "com.facebook.unity.FB";

		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x10")]
		private AndroidJavaClass facebookJavaClass;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0xB88440", Offset = "0xB88440", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1F029C8]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodName, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20229FF]) = v44;\nL_0018:\n\tv46 = this.facebookJavaClass;\n\t// 28 NewArr v50 @ X0_v3 (System.Object[]), typeof(System.Object[]), 0\n\tv59 = Il2CppMethodInfo;\n\tv61 = *([v59 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 44 IndirectJump v61 @ X4_v1, v46 @ X21_v2 (UnityEngine.AndroidJavaClass), v46 @ X21_v2 (UnityEngine.AndroidJavaClass), methodName @ X1 (System.String), v50 @ X0_v3 (System.Object[]), methodof(UnityEngine.AndroidJavaObject::CallStatic), v61 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T CallStatic<T>(string methodName)
		{
			//IL_0013: Expected O, but got I
			while (true)
			{
				AndroidJavaClass androidJavaClass = facebookJavaClass;
				object[] array = new object[0];
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x1681788", Offset = "0x1681788", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.AndroidJavaObject::CallStatic(this.facebookJavaClass, methodName, args);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CallStatic(string methodName, params object[] args)
		{
			facebookJavaClass.CallStatic(methodName, args);
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x16817A4", Offset = "0x16817A4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F01330]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B950]) = v38;\nL_0016:\n\tv42 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v42, \"com.facebook.unity.FB\");\n\tthis.facebookJavaClass = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidWrapper()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.facebook.unity.FB");
			facebookJavaClass = androidJavaClass;
		}
	}
}
