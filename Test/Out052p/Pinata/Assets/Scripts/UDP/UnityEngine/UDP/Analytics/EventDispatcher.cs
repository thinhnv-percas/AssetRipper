using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP.Analytics
{
	[Token(Token = "0x2000023")]
	internal class EventDispatcher
	{
		[Token(Token = "0x4000072")]
		private static AndroidJavaClass serviceClass;

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x15C6468", Offset = "0x15C6468", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1F076D0]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029992]) = v35;\nL_0014:\n\tv39 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v39, \"com.unity.udp.sdk.internal.analytics.Dispatcher\");\n\tv48.serviceClass = v39;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void init()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity.udp.sdk.internal.analytics.Dispatcher");
			serviceClass = androidJavaClass;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x15C57B8", Offset = "0x15C57B8", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EADA30]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029993]) = v40;\nL_0019:\n\tv46 = v44.serviceClass == 0;\n\tif (v46) goto L_0043;\n\t// 31 NewArr v51 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv59 = v38 == 0;\n\tif (v59) goto L_002C;\n\t// 40 IsInst v91 @ X0_v12, typeof(System.Object), v38 @ X0_v1 (System.Object)\nL_002C:\n\tv77 = v51.Length == 0;\n\tif (v77) goto L_0046;\n\tv51[0] = v38;\n\tUnityEngine.AndroidJavaObject::CallStatic(v44.serviceClass, \"Send\", v51);\n\treturn;\nL_0043:\n\tUnityEngine.UDP.Analytics.EventDispatcher::init();\n\treturn;\n\tv60 = new System.NullReferenceException();\nL_0046:\n\tv102 = new System.IndexOutOfRangeException();\n\tgoto L_004B;\n\tv104 = new System.ArrayTypeMismatchException();\nL_004B:\n\tthrow v106;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DispatchEvent(object e)
		{
			if (serviceClass != null)
			{
				object[] array = new object[1];
				object obj = default(object);
				if (obj != null)
				{
					object obj2 = obj as object;
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				array[0] = obj;
				serviceClass.CallStatic("Send", array);
			}
			else
			{
				init();
			}
		}
	}
}
