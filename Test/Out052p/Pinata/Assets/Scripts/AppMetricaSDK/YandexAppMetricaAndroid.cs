using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using YMMJSONUtils;

[Token(Token = "0x2000011")]
public class YandexAppMetricaAndroid : BaseYandexAppMetrica
{
	[Token(Token = "0x4000021")]
	[FieldOffset(Offset = "0x80")]
	private readonly AndroidJavaClass metricaClass;

	[Token(Token = "0x1700000C")]
	public override int LibraryApiLevel
	{
		[Token(Token = "0x6000074")]
		[Address(RVA = "0x15BFDCC", Offset = "0x15BFDCC", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0CA30]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029946]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"getLibraryApiLevel\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return metricaClass.CallStatic<int>("getLibraryApiLevel", Array.Empty<object>());
		}
	}

	[Token(Token = "0x1700000D")]
	public override string LibraryVersion
	{
		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15BFECC", Offset = "0x15BFECC", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EF7170]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029947]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"getLibraryVersion\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return metricaClass.CallStatic<string>("getLibraryVersion", Array.Empty<object>());
		}
	}

	[Token(Token = "0x600006C")]
	[Address(RVA = "0x15BDF5C", Offset = "0x15BDF5C", Length = "0x288")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EDDDC0]);\n\tv27 = *([v26 @ X8_v35]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, config, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202993E]) = v45;\nL_001A:\n\tv50 = 0x6D2410(&v47 @ stack_-A0, config, 0x60, v261, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tBaseYandexAppMetrica::UpdateConfiguration(this, &v47 @ stack_-A0);\n\tv56 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v56, \"com.unity3d.player.UnityPlayer\");\n\tv70 = UnityEngine.AndroidJavaObject::GetStatic(v56, \"currentActivity\");\n\t// 56 NewArr v79 @ X0_v45 (System.Object[]), typeof(System.Object[]), 2\n\tv108 = v70 == 0;\n\tif (v108) goto L_0045;\n\t// 65 IsInst v115 @ X0_v56, typeof(System.Object), v70 @ X0_v43 (UnityEngine.AndroidJavaObject)\n\tv117 = v115 == 0;\n\tif (v117) goto L_00BF;\nL_0045:\n\tv103 = v79.Length == 0;\n\tif (v103) goto L_00B5;\n\tv79[0] = v70;\n\tv166 = 0x6D2410(&v164 @ stack_-100, config, 0x60, v261, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv210 = YandexAppMetricaExtensionsAndroid::ToAndroidAppMetricaConfig(&v164 @ stack_-100);\n\tv217 = v210 == 0;\n\tif (v217) goto L_0058;\n\t// 84 IsInst v234 @ X0_v54, typeof(System.Object), v210 @ X0_v50 (UnityEngine.AndroidJavaObject)\n\tv236 = v234 == 0;\n\tif (v236) goto L_00C3;\nL_0058:\n\tv244 = v79.Length < 1;\n\tv145 = ~v244;\n\tv142 = v79.Length - 1;\n\tv136 = v142 == 0;\n\tv245 = ~v145;\n\tv121 = v245 | v136;\n\tif (v121) goto L_00B9;\n\tv79[1] = v210;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"activate\", v79);\nL_0076:\n\tgoto L_009D;\n\tv359 = *([v352 @ X8_v8+B0]);\n\tv360 = 0;\n\tv361 = v359 + 8;\n\tv363 = *([v391 @ X11_v6-8]);\n\tv405 = v363 == v355;\n\tif (v405) goto L_0096;\n\tv365 = v390 + 1;\n\tv464 = v365 < v354;\n\tv385 = ~v464;\n\tv367 = v391 + 0x10;\n\tv369 = ~v385;\n\tif (v369) goto L_FFFFFFFF;\n\tv386 = v60;\n\tv387 = 0;\n\tv388 = 0x8909C4(v386, v355, v387, v327, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_009D;\nL_0096:\n\tv465 = *([v391 @ X11_v6]);\n\tv466 = v465 << 4;\n\tv467 = v352 + v466;\n\tv468 = v467 + 0x130;\nL_009D:\n\tSystem.IDisposable::Dispose(v56);\n\tv490 = v346 + 1;\n\tv492 = v490 == 0;\n\tv495 = ~v492;\n\tif (v495) goto L_00B0;\nL_00A5:\n\tv497 = v298 == 0;\n\tv294 = ~v497;\n\tif (v294) goto L_00CA;\nL_00B0:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv93 = new System.NullReferenceException();\nL_00B5:\n\tv107 = new System.IndexOutOfRangeException();\n\tthrow v107;\nL_00B9:\n\tv162 = new System.IndexOutOfRangeException();\n\tthrow v162;\n\tv199 = new System.NullReferenceException();\nL_00BF:\n\tv208 = new System.ArrayTypeMismatchException();\n\tthrow v208;\nL_00C3:\n\tv241 = new System.ArrayTypeMismatchException();\n\tthrow v241;\nL_00CA:\n\tv304 = new System.TypeLoadException();\n\tgoto L_00D9;\n\tgoto L_00D9;\n\tgoto L_00D9;\n\tgoto L_00D9;\nL_00D9:\n\tgoto L_00E1;\n\tv357 = 0x6D2BC0(v304, 0, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv298 = *([v357 @ X0_v18]);\n\tv343 = 0x6D2490(v357, 0, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv345 = v56 == 0;\n\tif (v345) goto L_00A5;\n\tgoto L_0076;\nL_00E1:\n\tv358 = 0x6D2380(v304, 0, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void ActivateWithConfiguration(YandexAppMetricaConfig config)
	{
		//IL_028c: Expected O, but got Ref
		//IL_00ba: Expected O, but got Ref
		//IL_0136: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
		object obj = default(object);
		UpdateConfiguration((YandexAppMetricaConfig)(&obj));
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[2];
		if (androidJavaObject != null)
		{
			object obj2 = androidJavaObject as object;
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			object obj3 = default(object);
			AndroidJavaObject androidJavaObject2 = ((YandexAppMetricaConfig)(&obj3)).ToAndroidAppMetricaConfig();
			if (androidJavaObject2 != null)
			{
				object obj4 = androidJavaObject2 as object;
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj5 = array.Length - 1;
			bool flag3 = obj5 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = androidJavaObject2;
				metricaClass.CallStatic("activate", array);
				int num = 0;
				int num2 = 0;
				((IDisposable)androidJavaClass).Dispose();
				if (num + 1 == 0 && num2 != 0)
				{
					TypeLoadException ex3 = new TypeLoadException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				}
				return;
			}
			IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
			throw ex4;
		}
		IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
		throw ex5;
	}

	[Token(Token = "0x600006D")]
	[Address(RVA = "0x15BF24C", Offset = "0x15BF24C", Length = "0x1EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF0168]);\n\tv23 = *([v22 @ X8_v30]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202993F]) = v42;\nL_0018:\n\tv46 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v46, \"com.unity3d.player.UnityPlayer\");\n\tv60 = UnityEngine.AndroidJavaObject::GetStatic(v46, \"currentActivity\");\n\t// 47 NewArr v69 @ X0_v36 (System.Object[]), typeof(System.Object[]), 1\n\tv98 = v60 == 0;\n\tif (v98) goto L_003C;\n\t// 56 IsInst v105 @ X0_v40, typeof(System.Object), v60 @ X0_v34 (UnityEngine.AndroidJavaObject)\n\tv107 = v105 == 0;\n\tif (v107) goto L_0094;\nL_003C:\n\tv93 = v69.Length == 0;\n\tif (v93) goto L_008E;\n\tv69[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"resumeSession\", v69);\nL_0050:\n\tgoto L_0077;\n\tv247 = *([v242 @ X8_v8+B0]);\n\tv248 = 0;\n\tv249 = v247 + 8;\n\tv251 = *([v289 @ X11_v6-8]);\n\tv294 = v251 == v245;\n\tif (v294) goto L_0070;\n\tv271 = v288 + 1;\n\tv301 = v271 < v244;\n\tv269 = ~v301;\n\tv273 = v289 + 0x10;\n\tv253 = ~v269;\n\tif (v253) goto L_FFFFFFFF;\n\tv274 = v50;\n\tv275 = 0;\n\tv276 = 0x8909C4(v274, v245, v275, v227, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0077;\nL_0070:\n\tv302 = *([v289 @ X11_v6]);\n\tv303 = v302 << 4;\n\tv304 = v242 + v303;\n\tv305 = v304 + 0x130;\nL_0077:\n\tSystem.IDisposable::Dispose(v46);\n\tv327 = v229 + 1;\n\tv329 = v327 == 0;\n\tv332 = ~v329;\n\tif (v332) goto L_0089;\nL_007F:\n\tv334 = v198 == 0;\n\tv196 = ~v334;\n\tif (v196) goto L_009B;\nL_0089:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv83 = new System.NullReferenceException();\nL_008E:\n\tv97 = new System.IndexOutOfRangeException();\n\tthrow v97;\n\tv120 = new System.NullReferenceException();\nL_0094:\n\tv130 = new System.ArrayTypeMismatchException();\n\tthrow v130;\nL_009B:\n\tv204 = new System.TypeLoadException();\n\tgoto L_00A8;\n\tgoto L_00A8;\nL_00A8:\n\tgoto L_00B0;\n\tv299 = 0x6D2BC0(v204, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv198 = *([v299 @ X0_v15]);\n\tv235 = 0x6D2490(v299, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv237 = v46 == 0;\n\tif (v237) goto L_007F;\n\tgoto L_0050;\nL_00B0:\n\tv300 = 0x6D2380(v204, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void ResumeSession()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[1];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			metricaClass.CallStatic("resumeSession", array);
			int num = 0;
			int num2 = 0;
			((IDisposable)androidJavaClass).Dispose();
			if (num + 1 == 0 && num2 != 0)
			{
				TypeLoadException ex2 = new TypeLoadException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			return;
		}
		IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
		throw ex3;
	}

	[Token(Token = "0x600006E")]
	[Address(RVA = "0x15BF438", Offset = "0x15BF438", Length = "0x1EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE6CE8]);\n\tv23 = *([v22 @ X8_v30]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029940]) = v42;\nL_0018:\n\tv46 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v46, \"com.unity3d.player.UnityPlayer\");\n\tv60 = UnityEngine.AndroidJavaObject::GetStatic(v46, \"currentActivity\");\n\t// 47 NewArr v69 @ X0_v36 (System.Object[]), typeof(System.Object[]), 1\n\tv98 = v60 == 0;\n\tif (v98) goto L_003C;\n\t// 56 IsInst v105 @ X0_v40, typeof(System.Object), v60 @ X0_v34 (UnityEngine.AndroidJavaObject)\n\tv107 = v105 == 0;\n\tif (v107) goto L_0094;\nL_003C:\n\tv93 = v69.Length == 0;\n\tif (v93) goto L_008E;\n\tv69[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"pauseSession\", v69);\nL_0050:\n\tgoto L_0077;\n\tv247 = *([v242 @ X8_v8+B0]);\n\tv248 = 0;\n\tv249 = v247 + 8;\n\tv251 = *([v289 @ X11_v6-8]);\n\tv294 = v251 == v245;\n\tif (v294) goto L_0070;\n\tv271 = v288 + 1;\n\tv301 = v271 < v244;\n\tv269 = ~v301;\n\tv273 = v289 + 0x10;\n\tv253 = ~v269;\n\tif (v253) goto L_FFFFFFFF;\n\tv274 = v50;\n\tv275 = 0;\n\tv276 = 0x8909C4(v274, v245, v275, v227, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0077;\nL_0070:\n\tv302 = *([v289 @ X11_v6]);\n\tv303 = v302 << 4;\n\tv304 = v242 + v303;\n\tv305 = v304 + 0x130;\nL_0077:\n\tSystem.IDisposable::Dispose(v46);\n\tv327 = v229 + 1;\n\tv329 = v327 == 0;\n\tv332 = ~v329;\n\tif (v332) goto L_0089;\nL_007F:\n\tv334 = v198 == 0;\n\tv196 = ~v334;\n\tif (v196) goto L_009B;\nL_0089:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv83 = new System.NullReferenceException();\nL_008E:\n\tv97 = new System.IndexOutOfRangeException();\n\tthrow v97;\n\tv120 = new System.NullReferenceException();\nL_0094:\n\tv130 = new System.ArrayTypeMismatchException();\n\tthrow v130;\nL_009B:\n\tv204 = new System.TypeLoadException();\n\tgoto L_00A8;\n\tgoto L_00A8;\nL_00A8:\n\tgoto L_00B0;\n\tv299 = 0x6D2BC0(v204, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv198 = *([v299 @ X0_v15]);\n\tv235 = 0x6D2490(v299, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv237 = v46 == 0;\n\tif (v237) goto L_007F;\n\tgoto L_0050;\nL_00B0:\n\tv300 = 0x6D2380(v204, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void PauseSession()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[1];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			metricaClass.CallStatic("pauseSession", array);
			int num = 0;
			int num2 = 0;
			((IDisposable)androidJavaClass).Dispose();
			if (num + 1 == 0 && num2 != 0)
			{
				TypeLoadException ex2 = new TypeLoadException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			return;
		}
		IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
		throw ex3;
	}

	[Token(Token = "0x600006F")]
	[Address(RVA = "0x15BF624", Offset = "0x15BF624", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EA4910]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029941]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = message == 0;\n\tif (v50) goto L_0027;\n\t// 35 IsInst v55 @ X0_v16, typeof(System.Object), message @ X1 (System.String)\nL_0027:\n\tv62 = v47.Length == 0;\n\tif (v62) goto L_003B;\n\tv47[0] = message;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"reportEvent\", v47);\n\treturn;\n\tv51 = new System.NullReferenceException();\nL_003B:\n\tv67 = new System.IndexOutOfRangeException();\n\tgoto L_0042;\n\tv71 = new System.NullReferenceException();\n\tv74 = new System.ArrayTypeMismatchException();\nL_0042:\n\tthrow v88;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void ReportEvent(string message)
	{
		object[] array = new object[1];
		if (message != null)
		{
			object obj = message as object;
		}
		if (array.Length != 0)
		{
			array[0] = message;
			metricaClass.CallStatic("reportEvent", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000070")]
	[Address(RVA = "0x15BF6F4", Offset = "0x15BF6F4", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EEF5A8]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, message, parameters, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029942]) = v44;\nL_001C:\n\t// 28 NewArr v50 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv53 = message == 0;\n\tif (v53) goto L_0029;\n\t// 37 IsInst v99 @ X0_v13 (YandexAppMetricaAndroid), typeof(System.Object), message @ X1 (System.String)\nL_0029:\n\tv104 = v50.Length == 0;\n\tif (v104) goto L_0056;\n\tv50[0] = message;\n\tv137 = YandexAppMetricaAndroid::JsonStringFromDictionary(v99, parameters);\n\tv164 = v137 == 0;\n\tif (v164) goto L_0038;\n\t// 52 IsInst v157 @ X0_v20, typeof(System.Object), v137 @ X0_v16 (System.String)\nL_0038:\n\tv201 = v50.Length < 1;\n\tv123 = ~v201;\n\tv121 = v50.Length - 1;\n\tv117 = v121 == 0;\n\tv202 = ~v123;\n\tv107 = v202 | v117;\n\tif (v107) goto L_0056;\n\tv50[1] = v137;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"reportEvent\", v50);\n\treturn;\nL_0056:\n\tv153 = new System.IndexOutOfRangeException();\n\tgoto L_005B;\n\tv163 = new System.ArrayTypeMismatchException();\nL_005B:\n\tthrow v198;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void ReportEvent(string message, Dictionary<string, object> parameters)
	{
		//IL_00d9: Expected O, but got I4
		object[] array = new object[2];
		bool flag = message == null;
		YandexAppMetricaAndroid yandexAppMetricaAndroid = (YandexAppMetricaAndroid)(object)array;
		if (!flag)
		{
			yandexAppMetricaAndroid = (YandexAppMetricaAndroid)(message as object);
		}
		if (array.Length != 0)
		{
			array[0] = message;
			string text = yandexAppMetricaAndroid.JsonStringFromDictionary(parameters);
			if (text != null)
			{
				object obj = text as object;
			}
			bool flag2 = array.Length < 1;
			bool flag3 = !flag2;
			object obj2 = array.Length - 1;
			bool flag4 = obj2 == null;
			bool flag5 = !flag3;
			if (!(flag5 || flag4))
			{
				array[1] = text;
				metricaClass.CallStatic("reportEvent", array);
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000071")]
	[Address(RVA = "0x15BF874", Offset = "0x15BF874", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EC5CB8]);\n\tv29 = *([v28 @ X8_v28]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, condition, stackTrace, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029943]) = v46;\nL_001C:\n\t// 28 NewArr v51 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv59 = System.String::Concat(\"\\n\", stackTrace);\n\tv62 = v59 == 0;\n\tif (v62) goto L_0031;\n\t// 45 IsInst v130 @ X0_v29, typeof(System.Object), v59 @ X0_v5 (System.String)\nL_0031:\n\tv137 = v51.Length == 0;\n\tif (v137) goto L_007A;\n\tv51[0] = v59;\n\tv164 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v164, \"java.lang.Throwable\", v51);\n\t// 66 NewArr v152 @ X0_v20 (System.Object[]), typeof(System.Object[]), 2\n\tv247 = condition == 0;\n\tif (v247) goto L_004E;\n\t// 75 IsInst v195 @ X0_v27, typeof(System.Object), condition @ X1 (System.String)\nL_004E:\n\tv122 = v152.Length;\n\tv181 = v152.Length == 0;\n\tif (v181) goto L_007A;\n\tv152[0] = condition;\n\tv251 = v164 == 0;\n\tif (v251) goto L_005B;\n\t// 87 IsInst v196 @ X0_v25, typeof(System.Object), v164 @ X0_v18 (UnityEngine.AndroidJavaObject)\n\tv122 = v152.Length;\nL_005B:\n\tv254 = v122 < 1;\n\tv98 = ~v254;\n\tv94 = v122 - 1;\n\tv86 = v94 == 0;\n\tv255 = ~v98;\n\tv66 = v255 | v86;\n\tif (v66) goto L_007A;\n\tv152[1] = v164;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"reportError\", v152);\n\treturn;\nL_007A:\n\tv188 = new System.IndexOutOfRangeException();\n\tgoto L_007F;\n\tv206 = new System.ArrayTypeMismatchException();\nL_007F:\n\tthrow v245;\n\tthrow System.NullReferenceException;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void ReportError(string condition, string stackTrace)
	{
		//IL_00c9: Expected O, but got I4
		//IL_01c5: Expected O, but got I
		//IL_0133: Expected O, but got I4
		object[] array = new object[1];
		string text = "\n" + stackTrace;
		if (text != null)
		{
			object obj = text as object;
		}
		if (array.Length != 0)
		{
			array[0] = text;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Throwable", array);
			object[] array2 = new object[2];
			if (condition != null)
			{
				object obj2 = condition as object;
			}
			object obj3 = array2.Length;
			if (array2.Length != 0)
			{
				array2[0] = condition;
				if (androidJavaObject != null)
				{
					object obj4 = androidJavaObject as object;
					obj3 = array2.Length;
				}
				bool flag = (long)(IntPtr)obj3 < 1L;
				bool flag2 = !flag;
				object obj5 = (long)(IntPtr)obj3 - 1L;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = androidJavaObject;
					metricaClass.CallStatic("reportError", array2);
					return;
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000072")]
	[Address(RVA = "0x15BF9F8", Offset = "0x15BF9F8", Length = "0xEC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ECF008]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, enabled, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029944]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Boolean), &enabled @ X1 (System.Boolean)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"setLocationTracking\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SetLocationTracking(bool enabled)
	{
		object[] array = new object[1];
		object obj = enabled;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			metricaClass.CallStatic("setLocationTracking", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000073")]
	[Address(RVA = "0x15BFAE4", Offset = "0x15BFAE4", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F0ECC8]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, coordinates, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029945]) = v41;\nL_0017:\n\tv44 = coordinates.value == 0;\n\tif (v44) goto L_FFFFFFFF;\n\t// 29 NewArr v49 @ X0_v12 (System.Object[]), typeof(System.Object[]), 1\n\tv56 = 0x115D70C(coordinates, Il2CppMethodInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv64 = YandexAppMetricaExtensionsAndroid::ToAndroidLocation(v56);\n\tv101 = v64 == 0;\n\tif (v101) goto L_0031;\n\t// 45 IsInst v127 @ X0_v19, typeof(System.Object), v64 @ X0_v15 (UnityEngine.AndroidJavaObject)\nL_0031:\n\tv96 = v49.Length == 0;\n\tif (v96) goto L_004D;\n\tv49[0] = v64;\n\tgoto L_0049;\nL_0049:\n\tUnityEngine.AndroidJavaObject::CallStatic(v79, *([v83 @ X8_v4 (System.String)]), v76);\n\treturn;\n\tv75 = new System.NullReferenceException();\nL_004D:\n\tv100 = new System.IndexOutOfRangeException();\n\tgoto L_0052;\n\tv123 = new System.ArrayTypeMismatchException();\nL_0052:\n\tthrow v122;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SetLocation(YandexAppMetricaConfig.Coordinates? coordinates)
	{
		object[] args;
		AndroidJavaObject androidJavaObject2;
		string methodName;
		if ((object)coordinates.value != null)
		{
			object[] array = new object[1];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115D70C (inside System.Nullable`1<UnityEngine.Vector3>::Unbox +0xD0)");
			YandexAppMetricaConfig.Coordinates self = default(YandexAppMetricaConfig.Coordinates);
			AndroidJavaObject androidJavaObject = self.ToAndroidLocation();
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
			}
			if (array.Length == 0)
			{
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			array[0] = androidJavaObject;
			args = array;
			androidJavaObject2 = metricaClass;
			methodName = "setLocation";
		}
		else
		{
			args = null;
			androidJavaObject2 = metricaClass;
			methodName = "setLocation";
		}
		androidJavaObject2.CallStatic(methodName, args);
	}

	[Token(Token = "0x6000076")]
	[Address(RVA = "0x15BFFCC", Offset = "0x15BFFCC", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ED7620]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, userProfileID, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029948]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = userProfileID == 0;\n\tif (v50) goto L_0027;\n\t// 35 IsInst v55 @ X0_v16, typeof(System.Object), userProfileID @ X1 (System.String)\nL_0027:\n\tv62 = v47.Length == 0;\n\tif (v62) goto L_003B;\n\tv47[0] = userProfileID;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"setUserProfileID\", v47);\n\treturn;\n\tv51 = new System.NullReferenceException();\nL_003B:\n\tv67 = new System.IndexOutOfRangeException();\n\tgoto L_0042;\n\tv71 = new System.NullReferenceException();\n\tv74 = new System.ArrayTypeMismatchException();\nL_0042:\n\tthrow v88;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SetUserProfileID(string userProfileID)
	{
		object[] array = new object[1];
		if (userProfileID != null)
		{
			object obj = userProfileID as object;
		}
		if (array.Length != 0)
		{
			array[0] = userProfileID;
			metricaClass.CallStatic("setUserProfileID", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000077")]
	[Address(RVA = "0x15C009C", Offset = "0x15C009C", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EED6D0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, userProfile, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029949]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = YandexAppMetricaExtensionsAndroid::ToAndroidUserProfile(userProfile);\n\tv53 = v50 == 0;\n\tif (v53) goto L_002A;\n\t// 38 IsInst v67 @ X0_v16, typeof(System.Object), v50 @ X0_v5 (UnityEngine.AndroidJavaObject)\nL_002A:\n\tv71 = v47.Length == 0;\n\tif (v71) goto L_003F;\n\tv47[0] = v50;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"reportUserProfile\", v47);\n\treturn;\n\tv63 = new System.NullReferenceException();\nL_003F:\n\tv76 = new System.IndexOutOfRangeException();\n\tgoto L_0044;\n\tv77 = new System.ArrayTypeMismatchException();\nL_0044:\n\tthrow v90;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void ReportUserProfile(YandexAppMetricaUserProfile userProfile)
	{
		object[] array = new object[1];
		AndroidJavaObject androidJavaObject = userProfile.ToAndroidUserProfile();
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			metricaClass.CallStatic("reportUserProfile", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000078")]
	[Address(RVA = "0x15C0618", Offset = "0x15C0618", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBBB78]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, revenue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202994A]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv53 = 0x6D2410(&v50 @ stack_-78, revenue, 0x48, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv55 = YandexAppMetricaExtensionsAndroid::ToAndroidRevenue(&v50 @ stack_-78);\n\tv58 = v55 == 0;\n\tif (v58) goto L_002E;\n\t// 42 IsInst v72 @ X0_v18, typeof(System.Object), v55 @ X0_v7 (UnityEngine.AndroidJavaObject)\nL_002E:\n\tv76 = v47.Length == 0;\n\tif (v76) goto L_0043;\n\tv47[0] = v55;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"reportRevenue\", v47);\n\treturn;\n\tv68 = new System.NullReferenceException();\nL_0043:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv82 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v95;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void ReportRevenue(YandexAppMetricaRevenue revenue)
	{
		//IL_00b3: Expected O, but got Ref
		object[] array = new object[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
		object obj = default(object);
		AndroidJavaObject androidJavaObject = ((YandexAppMetricaRevenue)(&obj)).ToAndroidRevenue();
		if (androidJavaObject != null)
		{
			object obj2 = androidJavaObject as object;
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			metricaClass.CallStatic("reportRevenue", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000079")]
	[Address(RVA = "0x15C0C74", Offset = "0x15C0C74", Length = "0x268")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC84B8]);\n\tv27 = *([v26 @ X8_v38]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, enabled, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202994B]) = v45;\nL_001A:\n\tv49 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v49, \"com.unity3d.player.UnityPlayer\");\n\tv63 = UnityEngine.AndroidJavaObject::GetStatic(v49, \"currentActivity\");\n\t// 49 NewArr v72 @ X0_v42 (System.Object[]), typeof(System.Object[]), 2\n\tv101 = v63 == 0;\n\tif (v101) goto L_003E;\n\t// 58 IsInst v108 @ X0_v51, typeof(System.Object), v63 @ X0_v40 (UnityEngine.AndroidJavaObject)\n\tv110 = v108 == 0;\n\tif (v110) goto L_00B9;\nL_003E:\n\tv96 = v72.Length == 0;\n\tif (v96) goto L_00AF;\n\tv72[0] = v63;\n\t// 71 Box v163 @ X0_v45, typeof(System.Boolean), &enabled @ X1 (System.Boolean)\n\tv208 = v163 == 0;\n\tif (v208) goto L_0052;\n\t// 78 IsInst v218 @ X0_v49, typeof(System.Object), v163 @ X0_v45\n\tv219 = v218 == 0;\n\tif (v219) goto L_00BD;\nL_0052:\n\tv221 = v72.Length < 1;\n\tv138 = ~v221;\n\tv135 = v72.Length - 1;\n\tv129 = v135 == 0;\n\tv222 = ~v138;\n\tv114 = v222 | v129;\n\tif (v114) goto L_00B3;\n\tv72[1] = v163;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"setStatisticsSending\", v72);\nL_0070:\n\tgoto L_0097;\n\tv358 = *([v352 @ X8_v8+B0]);\n\tv359 = 0;\n\tv360 = v358 + 8;\n\tv362 = *([v392 @ X11_v6-8]);\n\tv406 = v362 == v355;\n\tif (v406) goto L_0090;\n\tv364 = v391 + 1;\n\tv411 = v364 < v354;\n\tv384 = ~v411;\n\tv366 = v392 + 0x10;\n\tv368 = ~v384;\n\tif (v368) goto L_FFFFFFFF;\n\tv385 = v53;\n\tv386 = 0;\n\tv387 = 0x8909C4(v385, v355, v386, v317, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0097;\nL_0090:\n\tv412 = *([v392 @ X11_v6]);\n\tv413 = v412 << 4;\n\tv414 = v352 + v413;\n\tv415 = v414 + 0x130;\nL_0097:\n\tSystem.IDisposable::Dispose(v49);\n\tv437 = v346 + 1;\n\tv439 = v437 == 0;\n\tv442 = ~v439;\n\tif (v442) goto L_00AA;\nL_009F:\n\tv500 = v304 == 0;\n\tv300 = ~v500;\n\tif (v300) goto L_00C4;\nL_00AA:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv86 = new System.NullReferenceException();\nL_00AF:\n\tv100 = new System.IndexOutOfRangeException();\n\tthrow v100;\nL_00B3:\n\tv157 = new System.IndexOutOfRangeException();\n\tthrow v157;\n\tv198 = new System.NullReferenceException();\nL_00B9:\n\tv207 = new System.ArrayTypeMismatchException();\n\tthrow v207;\nL_00BD:\n\tv243 = new System.ArrayTypeMismatchException();\n\tthrow v243;\nL_00C4:\n\tv310 = new System.TypeLoadException();\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\nL_00D3:\n\tgoto L_00DB;\n\tv388 = 0x6D2BC0(v310, 0, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv304 = *([v388 @ X0_v15]);\n\tv343 = 0x6D2490(v388, 0, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv345 = v49 == 0;\n\tif (v345) goto L_009F;\n\tgoto L_0070;\nL_00DB:\n\tv389 = 0x6D2380(v310, 0, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SetStatisticsSending(bool enabled)
	{
		//IL_0122: Expected O, but got I4
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[2];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			object obj2 = enabled;
			if (obj2 != null)
			{
				object obj3 = obj2 as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj4 = array.Length - 1;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = obj2;
				metricaClass.CallStatic("setStatisticsSending", array);
				int num = 0;
				int num2 = 0;
				((IDisposable)androidJavaClass).Dispose();
				if (num + 1 == 0 && num2 != 0)
				{
					TypeLoadException ex3 = new TypeLoadException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				}
				return;
			}
			IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
			throw ex4;
		}
		IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
		throw ex5;
	}

	[Token(Token = "0x600007A")]
	[Address(RVA = "0x15C0EDC", Offset = "0x15C0EDC", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED3D30]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202994C]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv105 = v74;\n\tv106 = 0x8907BC(v105, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0055:\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"sendEventsBuffer\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SendEventsBuffer()
	{
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		metricaClass.CallStatic("sendEventsBuffer");
	}

	[Token(Token = "0x600007B")]
	[Address(RVA = "0x15C0FD4", Offset = "0x15C0FD4", Length = "0xEC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([202994D]) & 1;\n\tv21 = v20 == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_001C;\n\tv25 = 0x15C3EC4(this, action, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([202994D]) = X8;\nL_001C:\n\t// 28 NewArr v45 @ X0_v2 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = new YandexAppMetricaDeviceIDListenerAndroid();\n\tYandexAppMetricaDeviceIDListenerAndroid::.ctor(v51, action);\n\tv84 = v51 == 0;\n\tif (v84) goto L_0031;\n\t// 45 IsInst v97 @ X0_v15, typeof(System.Object), v51 @ X0_v4 (YandexAppMetricaDeviceIDListenerAndroid)\nL_0031:\n\tv101 = v45.Length == 0;\n\tif (v101) goto L_0047;\n\tv45[0] = v51;\n\tUnityEngine.AndroidJavaObject::CallStatic(this.metricaClass, \"requestAppMetricaDeviceID\", v45);\n\treturn;\n\tv93 = new System.NullReferenceException();\nL_0047:\n\tv106 = new System.IndexOutOfRangeException();\n\tgoto L_004C;\n\tv107 = new System.ArrayTypeMismatchException();\nL_004C:\n\tthrow v110;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202994D]");
		if (0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15C3EC4 (inside YandexAppMetricaUserProfile::.ctor +0xB4)");
			return;
		}
		object[] array = new object[1];
		YandexAppMetricaDeviceIDListenerAndroid yandexAppMetricaDeviceIDListenerAndroid = new YandexAppMetricaDeviceIDListenerAndroid(action);
		if (yandexAppMetricaDeviceIDListenerAndroid != null)
		{
			object obj = yandexAppMetricaDeviceIDListenerAndroid as object;
		}
		if (array.Length != 0)
		{
			array[0] = yandexAppMetricaDeviceIDListenerAndroid;
			metricaClass.CallStatic("requestAppMetricaDeviceID", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600007C")]
	[Address(RVA = "0x15BF7FC", Offset = "0x15BF7FC", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED17B0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, dictionary, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202994E]) = v38;\nL_0013:\n\tv39 = dictionary == 0;\n\tif (v39) goto L_002F;\n\tgoto L_0027;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, dictionary, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\treturnVal2 = YMMJSONUtils.JSONEncoder::Encode(dictionary);\n\treturn returnVal2;\nL_002F:\n\treturn 0;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private string JsonStringFromDictionary(IDictionary dictionary)
	{
		if (dictionary != null)
		{
			return JSONEncoder.Encode(dictionary);
		}
		return null;
	}

	[Token(Token = "0x600007D")]
	[Address(RVA = "0x15BA9DC", Offset = "0x15BA9DC", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE0160]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202994F]) = v38;\nL_0016:\n\tv42 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v42, \"com.yandex.metrica.YandexMetrica\");\n\tthis.metricaClass = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaAndroid()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.yandex.metrica.YandexMetrica");
		metricaClass = androidJavaClass;
	}
}
