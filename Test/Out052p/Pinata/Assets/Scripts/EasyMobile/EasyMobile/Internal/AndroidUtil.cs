using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C6")]
	internal static class AndroidUtil
	{
		[Token(Token = "0x6000739")]
		[Address(RVA = "0xBFAE98", Offset = "0xBFAE98", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EDAA58]);\n\tv29 = *([v28 @ X8_v28]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, method, args, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022F24]) = v46;\nL_001C:\n\tv51 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0025;\n\tv56 = v51;\n\tv57 = 0x8907BC(v56, method, args, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv60 = *([v51 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0025:\n\tv61 = *([v51 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv62 = v61 == 0;\n\tif (v62) goto L_0046;\n\tv64 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0032;\n\tv86 = v64;\n\tv87 = 0x8907BC(v86, method, args, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv88 = *([v64 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv74 = ~v88;\n\tif (v74) goto L_0046;\n\tgoto L_0046;\n\tv105 = v79;\n\tv106 = 0x8907BC(v105, method, args, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0046:\n\tgoto L_004E;\n\tv89 = v81;\n\tv90 = 0x8907BC(v89, method, args, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_004E:\n\tv97 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v97, className, v93.Value);\n\tUnityEngine.AndroidJavaObject::CallStatic(v97, method, args);\nL_0063:\n\tgoto L_008A;\n\tv221 = *([v215 @ X8_v13+B0]);\n\tv222 = 0;\n\tv223 = v221 + 8;\n\tv225 = *([v264 @ X11_v6-8]);\n\tv269 = v225 == v218;\n\tif (v269) goto L_0083;\n\tv245 = v263 + 1;\n\tv274 = v245 < v217;\n\tv243 = ~v274;\n\tv247 = v264 + 0x10;\n\tv227 = ~v243;\n\tif (v227) goto L_FFFFFFFF;\n\tv248 = v104;\n\tv249 = 0;\n\tv250 = 0x8909C4(v248, v218, v249, v201, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_008A;\nL_0083:\n\tv275 = *([v264 @ X11_v6]);\n\tv276 = v275 << 4;\n\tv277 = v215 + v276;\n\tv278 = v277 + 0x130;\nL_008A:\n\tSystem.IDisposable::Dispose(v97);\n\tv300 = v209 + 1;\n\tv302 = v300 == 0;\n\tv305 = ~v302;\n\tif (v305) goto L_009D;\nL_0092:\n\tv361 = v172 == 0;\n\tv168 = ~v361;\n\tif (v168) goto L_00A3;\nL_009D:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00A3:\n\tv178 = new System.TypeLoadException();\n\tgoto L_00B6;\n\tv251 = 0x6D2BC0(v178, 0, 0, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv172 = *([v251 @ X0_v18]);\n\tv206 = 0x6D2490(v251, 0, 0, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv208 = v97 == 0;\n\tif (v208) goto L_0092;\n\tgoto L_0063;\nL_00B6:\n\tv252 = 0x6D2380(v178, 0, 0, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void CallJavaStaticMethod(string className, string method, params object[] args)
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = new AndroidJavaObject(className);
			androidJavaObject.CallStatic(method, args);
			int num = 0;
			int num2 = 0;
			((IDisposable)androidJavaObject).Dispose();
			if (num + 1 == 0 && num2 != 0)
			{
				TypeLoadException ex = new TypeLoadException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
		}

		[Token(Token = "0x600073A")]
		[Address(RVA = "0xB87BF0", Offset = "0xB87BF0", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EFDF00]);\n\tv33 = *([v32 @ X8_v30]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, method, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20229F9]) = v49;\nL_001E:\n\tv54 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0027;\n\tv59 = v54;\n\tv60 = 0x8907BC(v59, method, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv63 = *([v54 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0027:\n\tv64 = *([v54 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv65 = v64 == 0;\n\tif (v65) goto L_0048;\n\tv67 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0034;\n\tv89 = v67;\n\tv90 = 0x8907BC(v89, method, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0034:\n\tv91 = *([v67 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv77 = ~v91;\n\tif (v77) goto L_0048;\n\tgoto L_0048;\n\tv108 = v82;\n\tv109 = 0x8907BC(v108, method, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0048:\n\tgoto L_0050;\n\tv92 = v84;\n\tv93 = 0x8907BC(v92, method, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0050:\n\tv100 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v100, className, v96.Value);\n\tv119 = UnityEngine.AndroidJavaObject::CallStatic(v100, method, args);\nL_0068:\n\tgoto L_008F;\n\tv231 = *([v185 @ X8_v13+B0]);\n\tv232 = 0;\n\tv233 = v231 + 8;\n\tv235 = *([v273 @ X11_v6-8]);\n\tv278 = v235 == v188;\n\tif (v278) goto L_0088;\n\tv255 = v272 + 1;\n\tv285 = v255 < v187;\n\tv253 = ~v285;\n\tv257 = v273 + 0x10;\n\tv237 = ~v253;\n\tif (v237) goto L_FFFFFFFF;\n\tv258 = v107;\n\tv259 = 0;\n\tv260 = 0x8909C4(v258, v188, v259, v164, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_008F;\nL_0088:\n\tv286 = *([v273 @ X11_v6]);\n\tv287 = v286 << 4;\n\tv288 = v185 + v287;\n\tv289 = v288 + 0x130;\nL_008F:\n\tSystem.IDisposable::Dispose(v100);\n\tv311 = v180 + 1;\n\tv313 = v311 == 0;\n\tv316 = ~v313;\n\tif (v316) goto L_00A4;\nL_0097:\n\tv318 = v223 == 0;\n\tv221 = ~v318;\n\tif (v221) goto L_00AA;\nL_00A4:\n\treturn v339;\n\tthrow System.NullReferenceException;\nL_00AA:\n\tv230 = new System.TypeLoadException();\n\tgoto L_00BE;\n\tv283 = UnityEngine.AndroidJavaObject::CallStatic(v230, 0, 0);\n\tv223 = *([v283 @ X0_v18 (T)]);\n\tv173 = UnityEngine.AndroidJavaObject::CallStatic(v283, 0, 0);\n\tv175 = v100 == 0;\n\tif (v175) goto L_0097;\n\tgoto L_0068;\nL_00BE:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v230, 0, 0);\n\treturn returnVal1;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static T CallJavaStaticMethod<T>(string className, string method, params object[] args)
		{
			//IL_007d: Expected I, but got O
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = new AndroidJavaObject(className);
			T val = androidJavaObject.CallStatic<T>(method, args);
			IntPtr intPtr3 = (IntPtr)null;
			T val2 = val;
			int num = 0;
			((IDisposable)androidJavaObject).Dispose();
			int num2 = num + 1;
			bool flag = num2 == 0;
			bool flag2 = !flag;
			T result = val2;
			if (!flag2)
			{
				bool flag3 = intPtr3 == (IntPtr)0;
				bool flag4 = !flag3;
				result = val2;
				if (flag4)
				{
					TypeLoadException ex = new TypeLoadException();
					return ((AndroidJavaObject)(object)ex).CallStatic<T>((string)null, (object[])null);
				}
			}
			return result;
		}
	}
}
