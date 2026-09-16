using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using IronSourceJSON;
using UnityEngine;

[Token(Token = "0x2000002")]
public class AndroidAgent : IronSourceIAgent
{
	[Token(Token = "0x4000001")]
	private static AndroidJavaObject _androidBridge;

	[Token(Token = "0x4000002")]
	private static readonly string AndroidBridge = "com.ironsource.unity.androidbridge.AndroidBridge";

	[Token(Token = "0x4000003")]
	private const string REWARD_AMOUNT = "reward_amount";

	[Token(Token = "0x4000004")]
	private const string REWARD_NAME = "reward_name";

	[Token(Token = "0x4000005")]
	private const string PLACEMENT_NAME = "placement_name";

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x158DB88", Offset = "0x158DB88", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0BCA0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029665]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tgoto L_002B;\n\tv47 = *([v43 @ X0_v3+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_002B;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Debug::Log(\"AndroidAgent ctr\");\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AndroidAgent()
	{
		Debug.Log("AndroidAgent ctr");
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x158DC04", Offset = "0x158DC04", Length = "0x278")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBDB28]);\n\tv23 = *([v22 @ X8_v45]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2029666]) = v43;\nL_001B:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<AndroidAgent>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = AndroidAgent;\nL_0024:\n\tv59 = v57._androidBridge == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_00C4;\n\tgoto L_0036;\n\tv153 = *([v53 @ X0_v3 (Il2CppClass<AndroidAgent>)+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_0036;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv236 = AndroidAgent;\n\tv161 = *([v236 @ X8_v40+B8]);\nL_0036:\n\tv166 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v166, v160.AndroidBridge);\n\tv241 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0048;\n\tv246 = v241;\n\tv247 = UnityEngine.AndroidJavaObject::CallStatic(v246, v183, v184, v27);\n\tv250 = *([v241 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0048:\n\tv251 = *([v241 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv252 = v251 == 0;\n\tif (v252) goto L_0069;\n\tv254 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0055;\n\tv276 = v254;\n\tv277 = UnityEngine.AndroidJavaObject::CallStatic(v276, v183, v184, v27);\nL_0055:\n\tv278 = *([v254 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv266 = ~v278;\n\tif (v266) goto L_0069;\n\tgoto L_0069;\n\tv298 = v260;\n\tv299 = UnityEngine.AndroidJavaObject::CallStatic(v298, v183, v184, v27);\nL_0069:\n\tgoto L_0077;\n\tv279 = v271;\n\tv280 = UnityEngine.AndroidJavaObject::CallStatic(v279, v183, v184, v27);\nL_0077:\n\tv295 = UnityEngine.AndroidJavaObject::CallStatic(v166, \"getInstance\", v287.Value);\n\tgoto L_0087;\n\tv321 = *([v303 @ X0_v34 (Il2CppClass<AndroidAgent>)+E0]);\n\tv322 = v321 == 0;\n\tv323 = ~v322;\n\tif (v323) goto L_0087;\n\tv331 = \"il2cpp_codegen_runtime_class_init\"(v303, v292, v291, v293, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv325 = AndroidAgent;\nL_0087:\n\tv328._androidBridge = v295;\nL_008E:\n\tgoto L_00B5;\n\tv362 = *([v356 @ X8_v23+B0]);\n\tv363 = 0;\n\tv364 = v362 + 8;\n\tv366 = *([v403 @ X11_v7-8]);\n\tv409 = v366 == v359;\n\tif (v409) goto L_00AE;\n\tv388 = v404 + 1;\n\tv414 = v388 < v358;\n\tv384 = ~v414;\n\tv386 = v403 + 0x10;\n\tv368 = ~v384;\n\tif (v368) goto L_FFFFFFFF;\n\tv389 = v148;\n\tv390 = 0;\n\tv391 = 0x8909C4(v389, v359, v390, v118, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00B5;\nL_00AE:\n\tv415 = *([v403 @ X11_v7]);\n\tv416 = v415 << 4;\n\tv417 = v356 + v416;\n\tv418 = v417 + 0x130;\nL_00B5:\n\tSystem.IDisposable::Dispose(v166);\n\tv143 = v71 + 1;\n\tv99 = v143 == 0;\n\tv79 = ~v99;\n\tif (v79) goto L_00C4;\nL_00BD:\n\tv428 = v124 == 0;\n\tv142 = ~v428;\n\tif (v142) goto L_00DB;\nL_00C4:\n\tgoto L_00D5;\n\tv167 = *([v149 @ X0_v5 (Il2CppClass<AndroidAgent>)+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_00D5;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v149, v132, v129, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv171 = AndroidAgent;\nL_00D5:\n\treturn v174._androidBridge;\n\tthrow System.NullReferenceException;\nL_00DB:\n\tv320 = new System.TypeLoadException();\n\tgoto L_00E8;\n\tgoto L_00E8;\nL_00E8:\n\tgoto L_00F0;\n\tv392 = UnityEngine.AndroidJavaObject::CallStatic(v320, 0, 0);\n\tv124 = *([v392 @ X0_v27 (UnityEngine.AndroidJavaObject)]);\n\tv351 = UnityEngine.AndroidJavaObject::CallStatic(v392, 0, 0);\n\tv353 = v166 == 0;\n\tif (v353) goto L_00BD;\n\tgoto L_008E;\nL_00F0:\n\treturnVal2 = UnityEngine.AndroidJavaObject::CallStatic(v320, 0, 0);\n\treturn returnVal2;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AndroidJavaObject getBridge()
	{
		//IL_01a8: Expected I, but got O
		if (_androidBridge == null)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass(AndroidBridge);
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidBridge = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
			_androidBridge = androidBridge;
			int num = 0;
			IntPtr intPtr3 = (IntPtr)null;
			((IDisposable)androidJavaClass).Dispose();
			if (num + 1 == 0 && intPtr3 != (IntPtr)0)
			{
				TypeLoadException ex = new TypeLoadException();
				return ((AndroidJavaObject)(object)ex).CallStatic<AndroidJavaObject>((string)null, (object[])null);
			}
		}
		return _androidBridge;
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x158DE7C", Offset = "0x158DE7C", Length = "0x10C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB5870]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pause, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029667]) = v42;\nL_0015:\n\tv43 = AndroidAgent::getBridge(v39);\n\tv49 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv54 = v49;\n\tv55 = 0x8907BC(v54, pause, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = *([v49 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv59 = *([v49 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv60 = v59 == 0;\n\tif (v60) goto L_0045;\n\tv62 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv84 = v62;\n\tv85 = 0x8907BC(v84, pause, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0031:\n\tv86 = *([v62 @ X21_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv74 = ~v86;\n\tif (v74) goto L_0045;\n\tgoto L_0045;\n\tv100 = v68;\n\tv101 = 0x8907BC(v100, pause, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0045:\n\tgoto L_004D;\n\tv87 = v79;\n\tv88 = 0x8907BC(v87, pause, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004D:\n\tv97 = pause == 0;\n\tif (v97) goto L_FFFFFFFF;\n\tgoto L_005E;\nL_005E:\n\tUnityEngine.AndroidJavaObject::Call(v43, *([v108 @ X8_v12 (System.String)]), v94.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onApplicationPause(bool pause)
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X21_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		string methodName = ((!pause) ? "onResume" : "onPause");
		bridge.Call(methodName);
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x158DF88", Offset = "0x158DF88", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE2868]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, age, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029668]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\t// 34 Box v55 @ X0_v6, typeof(System.Int32), &age @ X1 (System.Int32)\n\tv58 = v55 == 0;\n\tif (v58) goto L_002F;\n\t// 43 IsInst v72 @ X0_v17, typeof(System.Object), v55 @ X0_v6\nL_002F:\n\tv76 = v48.Length == 0;\n\tif (v76) goto L_0044;\n\tv48[0] = v55;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"setAge\", v48);\n\treturn;\n\tv68 = new System.NullReferenceException();\nL_0044:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0049;\n\tv82 = new System.ArrayTypeMismatchException();\nL_0049:\n\tthrow v90;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setAge(int age)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		object obj = age;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			bridge.Call("setAge", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x158E078", Offset = "0x158E078", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EBA4B0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, gender, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029669]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = gender == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), gender @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = gender;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"setGender\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setGender(string gender)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (gender != null)
		{
			object obj = gender as object;
		}
		if (array.Length != 0)
		{
			array[0] = gender;
			bridge.Call("setGender", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x158E14C", Offset = "0x158E14C", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB0E28]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, segment, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202966A]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = segment == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), segment @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = segment;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"setMediationSegment\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setMediationSegment(string segment)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (segment != null)
		{
			object obj = segment as object;
		}
		if (array.Length != 0)
		{
			array[0] = segment;
			bridge.Call("setMediationSegment", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x158E220", Offset = "0x158E220", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED44E8]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202966B]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv108 = v65;\n\tv109 = 0x8907BC(v108, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v40, \"getAdvertiserId\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string getAdvertiserId()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		return bridge.Call<string>("getAdvertiserId", Array.Empty<object>());
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0x158E320", Offset = "0x158E320", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA9680]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202966C]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"validateIntegration\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void validateIntegration()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("validateIntegration");
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x158E418", Offset = "0x158E418", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECCA28]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, track, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202966D]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\t// 34 Box v55 @ X0_v6, typeof(System.Boolean), &track @ X1 (System.Boolean)\n\tv58 = v55 == 0;\n\tif (v58) goto L_002F;\n\t// 43 IsInst v72 @ X0_v17, typeof(System.Object), v55 @ X0_v6\nL_002F:\n\tv76 = v48.Length == 0;\n\tif (v76) goto L_0044;\n\tv48[0] = v55;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"shouldTrackNetworkState\", v48);\n\treturn;\n\tv68 = new System.NullReferenceException();\nL_0044:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0049;\n\tv82 = new System.ArrayTypeMismatchException();\nL_0049:\n\tthrow v90;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void shouldTrackNetworkState(bool track)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		object obj = track;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			bridge.Call("shouldTrackNetworkState", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x158E508", Offset = "0x158E508", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF9230]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, dynamicUserId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202966E]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = dynamicUserId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v18, typeof(System.Object), dynamicUserId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003E;\n\tv48[0] = dynamicUserId;\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v41, \"setDynamicUserId\", v48);\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_003E:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0045;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0045:\n\tthrow v92;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool setDynamicUserId(string dynamicUserId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (dynamicUserId != null)
		{
			object obj = dynamicUserId as object;
		}
		if (array.Length != 0)
		{
			array[0] = dynamicUserId;
			return bridge.Call<bool>("setDynamicUserId", array);
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x158E5E4", Offset = "0x158E5E4", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECB3E8]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, enabled, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202966F]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\t// 34 Box v55 @ X0_v6, typeof(System.Boolean), &enabled @ X1 (System.Boolean)\n\tv58 = v55 == 0;\n\tif (v58) goto L_002F;\n\t// 43 IsInst v72 @ X0_v17, typeof(System.Object), v55 @ X0_v6\nL_002F:\n\tv76 = v48.Length == 0;\n\tif (v76) goto L_0044;\n\tv48[0] = v55;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"setAdaptersDebug\", v48);\n\treturn;\n\tv68 = new System.NullReferenceException();\nL_0044:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0049;\n\tv82 = new System.ArrayTypeMismatchException();\nL_0049:\n\tthrow v90;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setAdaptersDebug(bool enabled)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		object obj = enabled;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			bridge.Call("setAdaptersDebug", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0x158E6D4", Offset = "0x158E6D4", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EE4948]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, key, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2029670]) = v43;\nL_0016:\n\tv44 = AndroidAgent::getBridge(v40);\n\t// 29 NewArr v51 @ X0_v4 (System.Object[]), typeof(System.Object[]), 2\n\tv54 = key == 0;\n\tif (v54) goto L_0029;\n\t// 38 IsInst v96 @ X0_v22, typeof(System.Object), key @ X1 (System.String)\nL_0029:\n\tv130 = v51.Length;\n\tv103 = v51.Length == 0;\n\tif (v103) goto L_0054;\n\tv51[0] = key;\n\tv133 = value == 0;\n\tif (v133) goto L_0036;\n\t// 50 IsInst v152 @ X0_v20, typeof(System.Object), value @ X2 (System.String)\n\tv130 = v51.Length;\nL_0036:\n\tv160 = v130 < 1;\n\tv121 = ~v160;\n\tv119 = v130 - 1;\n\tv115 = v119 == 0;\n\tv161 = ~v121;\n\tv105 = v161 | v115;\n\tif (v105) goto L_0054;\n\tv51[1] = value;\n\tUnityEngine.AndroidJavaObject::Call(v44, \"setMetaData\", v51);\n\treturn;\nL_0054:\n\tv148 = new System.IndexOutOfRangeException();\n\tgoto L_0059;\n\tv157 = new System.ArrayTypeMismatchException();\nL_0059:\n\tthrow v195;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setMetaData(string key, string value)
	{
		//IL_003e: Expected O, but got I4
		//IL_0130: Expected O, but got I
		//IL_00a8: Expected O, but got I4
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[2];
		if (key != null)
		{
			object obj = key as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = key;
			if (value != null)
			{
				object obj3 = value as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = value;
				bridge.Call("setMetaData", array);
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0x158E7D4", Offset = "0x158E7D4", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC0588]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, userId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029671]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = userId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), userId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = userId;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"setUserId\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setUserId(string userId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (userId != null)
		{
			object obj = userId as object;
		}
		if (array.Length != 0)
		{
			array[0] = userId;
			bridge.Call("setUserId", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0x158E8A8", Offset = "0x158E8A8", Length = "0x24C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1F09D60]);\n\tv29 = *([v28 @ X8_v44]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, appKey, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([2029672]) = v48;\nL_0018:\n\tv49 = AndroidAgent::getBridge(v45);\n\t// 31 NewArr v56 @ X0_v4 (System.Object[]), typeof(System.Object[]), 3\n\tv62 = \"Unity\" == 0;\n\tif (v62) goto L_002E;\n\t// 42 IsInst v139 @ X0_v46, typeof(System.Object), \"Unity\"\nL_002E:\n\tv146 = v56.Length == 0;\n\tif (v146) goto L_00C4;\n\tv56[0] = \"Unity\";\n\tgoto L_0041;\n\tv256 = *([1EB4D70]);\n\tv257 = *([v256 @ X8_v39]);\n\tv258 = \"il2cpp_codegen_initialize_method\"(v257, v140, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv261 = 0 | 1;\n\t*([2029696]) = v261;\nL_0041:\n\tv263 = \"6.13.0\" == 0;\n\tif (v263) goto L_004A;\n\t// 70 IsInst v242 @ X0_v43, typeof(System.Object), \"6.13.0\"\nL_004A:\n\tv308 = v56.Length < 1;\n\tv204 = ~v308;\n\tv202 = v56.Length - 1;\n\tv198 = v202 == 0;\n\tv309 = ~v204;\n\tv188 = v309 | v198;\n\tif (v188) goto L_00C4;\n\tv56[1] = \"6.13.0\";\n\tv311 = UnityEngine.Application::get_unityVersion();\n\tv312 = v311 == 0;\n\tif (v312) goto L_0063;\n\t// 95 IsInst v243 @ X0_v41, typeof(System.Object), v311 @ X0_v21 (System.String)\nL_0063:\n\tv315 = v56.Length < 2;\n\tv111 = ~v315;\n\tv107 = v56.Length - 2;\n\tv99 = v107 == 0;\n\tv316 = ~v111;\n\tv79 = v316 | v99;\n\tif (v79) goto L_00C4;\n\tv56[2] = v311;\n\tUnityEngine.AndroidJavaObject::Call(v49, \"setPluginData\", v56);\n\tgoto L_0089;\n\tv327 = *([1EB4D70]);\n\tv328 = *([v327 @ X8_v34]);\n\tv329 = \"il2cpp_codegen_initialize_method\"(v328, v321, v320, v72, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv332 = 0 | 1;\n\t*([2029696]) = v332;\nL_0089:\n\tv337 = System.String::Concat(\"IntegrationHelper pluginVersion: \", \"6.13.0\");\n\tgoto L_009A;\n\tv345 = *([v341 @ X8_v26+E0]);\n\tv346 = v345 == 0;\n\tv347 = ~v346;\n\tgoto L_009A;\n\tv353 = v341;\n\tv349 = \"il2cpp_codegen_runtime_class_init\"(v353, v334, v75, v72, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_009A:\n\tUnityEngine.Debug::Log(v337);\n\tv354 = AndroidAgent::getBridge(v337);\n\t// 160 NewArr v126 @ X0_v31 (System.Object[]), typeof(System.Object[]), 1\n\tv356 = appKey == 0;\n\tif (v356) goto L_00AD;\n\t// 169 IsInst v244 @ X0_v35, typeof(System.Object), appKey @ X1 (System.String)\nL_00AD:\n\tv216 = v126.Length == 0;\n\tif (v216) goto L_00C4;\n\tv126[0] = appKey;\n\tUnityEngine.AndroidJavaObject::Call(v354, \"init\", v126);\n\treturn;\nL_00C4:\n\tv220 = new System.IndexOutOfRangeException();\n\tgoto L_00C9;\n\tv254 = new System.ArrayTypeMismatchException();\nL_00C9:\n\tthrow v305;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void init(string appKey)
	{
		//IL_00ac: Expected O, but got I4
		//IL_0158: Expected O, but got I4
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[3];
		if ("Unity" != null)
		{
			object obj = "Unity" as object;
		}
		if (array.Length != 0)
		{
			array[0] = "Unity";
			if ("6.13.0" != null)
			{
				object obj2 = "6.13.0" as object;
			}
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj3 = array.Length - 1;
			bool flag3 = obj3 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = "6.13.0";
				string unityVersion = Application.unityVersion;
				if (unityVersion != null)
				{
					object obj4 = unityVersion as object;
				}
				bool flag5 = array.Length < 2;
				bool flag6 = !flag5;
				object obj5 = array.Length - 2;
				bool flag7 = obj5 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = unityVersion;
					bridge.Call("setPluginData", array);
					string text = "IntegrationHelper pluginVersion: " + "6.13.0";
					Debug.Log(text);
					AndroidJavaObject bridge2 = ((AndroidAgent)(object)text).getBridge();
					object[] array2 = new object[1];
					if (appKey != null)
					{
						object obj6 = appKey as object;
					}
					if (array2.Length != 0)
					{
						array2[0] = appKey;
						bridge2.Call("init", array2);
						return;
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x158EB44", Offset = "0x158EB44", Length = "0x278")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EB0670]);\n\tv33 = *([v32 @ X8_v47]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, appKey, adUnits, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0 | 1;\n\t*([2029673]) = v51;\nL_001A:\n\tv52 = AndroidAgent::getBridge(v48);\n\t// 33 NewArr v59 @ X0_v4 (System.Object[]), typeof(System.Object[]), 3\n\tv65 = \"Unity\" == 0;\n\tif (v65) goto L_0030;\n\t// 44 IsInst v142 @ X0_v49, typeof(System.Object), \"Unity\"\nL_0030:\n\tv149 = v59.Length == 0;\n\tif (v149) goto L_00DD;\n\tv59[0] = \"Unity\";\n\tgoto L_0043;\n\tv276 = *([1EB4D70]);\n\tv277 = *([v276 @ X8_v42]);\n\tv278 = \"il2cpp_codegen_initialize_method\"(v277, v143, adUnits, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv281 = 0 | 1;\n\t*([2029696]) = v281;\nL_0043:\n\tv283 = \"6.13.0\" == 0;\n\tif (v283) goto L_004C;\n\t// 72 IsInst v259 @ X0_v46, typeof(System.Object), \"6.13.0\"\nL_004C:\n\tv330 = v59.Length < 1;\n\tv216 = ~v330;\n\tv214 = v59.Length - 1;\n\tv210 = v214 == 0;\n\tv331 = ~v216;\n\tv200 = v331 | v210;\n\tif (v200) goto L_00DD;\n\tv59[1] = \"6.13.0\";\n\tv333 = UnityEngine.Application::get_unityVersion();\n\tv334 = v333 == 0;\n\tif (v334) goto L_0065;\n\t// 97 IsInst v260 @ X0_v44, typeof(System.Object), v333 @ X0_v21 (System.String)\nL_0065:\n\tv337 = v59.Length < 2;\n\tv114 = ~v337;\n\tv110 = v59.Length - 2;\n\tv102 = v110 == 0;\n\tv338 = ~v114;\n\tv82 = v338 | v102;\n\tif (v82) goto L_00DD;\n\tv59[2] = v333;\n\tUnityEngine.AndroidJavaObject::Call(v52, \"setPluginData\", v59);\n\tgoto L_008B;\n\tv349 = *([1EB4D70]);\n\tv350 = *([v349 @ X8_v37]);\n\tv351 = \"il2cpp_codegen_initialize_method\"(v350, v343, v342, v75, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv354 = 0 | 1;\n\t*([2029696]) = v354;\nL_008B:\n\tv359 = System.String::Concat(\"IntegrationHelper pluginVersion: \", \"6.13.0\");\n\tgoto L_009C;\n\tv367 = *([v363 @ X8_v26+E0]);\n\tv368 = v367 == 0;\n\tv369 = ~v368;\n\tgoto L_009C;\n\tv375 = v363;\n\tv371 = \"il2cpp_codegen_runtime_class_init\"(v375, v356, v78, v75, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_009C:\n\tUnityEngine.Debug::Log(v359);\n\tv376 = AndroidAgent::getBridge(v359);\n\t// 162 NewArr v129 @ X0_v31 (System.Object[]), typeof(System.Object[]), 2\n\tv378 = appKey == 0;\n\tif (v378) goto L_00AE;\n\t// 171 IsInst v261 @ X0_v38, typeof(System.Object), appKey @ X1 (System.String)\nL_00AE:\n\tv186 = v129.Length;\n\tv230 = v129.Length == 0;\n\tif (v230) goto L_00DD;\n\tv129[0] = appKey;\n\tv382 = adUnits == 0;\n\tif (v382) goto L_00BB;\n\t// 183 IsInst v262 @ X0_v36, typeof(System.Object), adUnits @ X2 (System.String[])\n\tv186 = v129.Length;\nL_00BB:\n\tv385 = v186 < 1;\n\tv171 = ~v385;\n\tv169 = v186 - 1;\n\tv165 = v169 == 0;\n\tv386 = ~v171;\n\tv155 = v386 | v165;\n\tif (v155) goto L_00DD;\n\tv129[1] = adUnits;\n\tUnityEngine.AndroidJavaObject::Call(v376, \"init\", v129);\n\treturn;\nL_00DD:\n\tv236 = new System.IndexOutOfRangeException();\n\tgoto L_00E2;\n\tv274 = new System.ArrayTypeMismatchException();\nL_00E2:\n\tthrow v327;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void init(string appKey, params string[] adUnits)
	{
		//IL_00ac: Expected O, but got I4
		//IL_0158: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_034a: Expected O, but got I
		//IL_028c: Expected O, but got I4
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[3];
		if ("Unity" != null)
		{
			object obj = "Unity" as object;
		}
		if (array.Length != 0)
		{
			array[0] = "Unity";
			if ("6.13.0" != null)
			{
				object obj2 = "6.13.0" as object;
			}
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj3 = array.Length - 1;
			bool flag3 = obj3 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = "6.13.0";
				string unityVersion = Application.unityVersion;
				if (unityVersion != null)
				{
					object obj4 = unityVersion as object;
				}
				bool flag5 = array.Length < 2;
				bool flag6 = !flag5;
				object obj5 = array.Length - 2;
				bool flag7 = obj5 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = unityVersion;
					bridge.Call("setPluginData", array);
					string text = "IntegrationHelper pluginVersion: " + "6.13.0";
					Debug.Log(text);
					AndroidJavaObject bridge2 = ((AndroidAgent)(object)text).getBridge();
					object[] array2 = new object[2];
					if (appKey != null)
					{
						object obj6 = appKey as object;
					}
					object obj7 = array2.Length;
					if (array2.Length != 0)
					{
						array2[0] = appKey;
						if (adUnits != null)
						{
							object obj8 = adUnits as object;
							obj7 = array2.Length;
						}
						bool flag9 = (long)(IntPtr)obj7 < 1L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj7 - 1L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array2[1] = adUnits;
							bridge2.Call("init", array2);
							return;
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0x158EDBC", Offset = "0x158EDBC", Length = "0x278")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EDCD60]);\n\tv33 = *([v32 @ X8_v47]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, appKey, adUnits, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0 | 1;\n\t*([2029674]) = v51;\nL_001A:\n\tv52 = AndroidAgent::getBridge(v48);\n\t// 33 NewArr v59 @ X0_v4 (System.Object[]), typeof(System.Object[]), 3\n\tv65 = \"Unity\" == 0;\n\tif (v65) goto L_0030;\n\t// 44 IsInst v142 @ X0_v49, typeof(System.Object), \"Unity\"\nL_0030:\n\tv149 = v59.Length == 0;\n\tif (v149) goto L_00DD;\n\tv59[0] = \"Unity\";\n\tgoto L_0043;\n\tv276 = *([1EB4D70]);\n\tv277 = *([v276 @ X8_v42]);\n\tv278 = \"il2cpp_codegen_initialize_method\"(v277, v143, adUnits, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv281 = 0 | 1;\n\t*([2029696]) = v281;\nL_0043:\n\tv283 = \"6.13.0\" == 0;\n\tif (v283) goto L_004C;\n\t// 72 IsInst v259 @ X0_v46, typeof(System.Object), \"6.13.0\"\nL_004C:\n\tv330 = v59.Length < 1;\n\tv216 = ~v330;\n\tv214 = v59.Length - 1;\n\tv210 = v214 == 0;\n\tv331 = ~v216;\n\tv200 = v331 | v210;\n\tif (v200) goto L_00DD;\n\tv59[1] = \"6.13.0\";\n\tv333 = UnityEngine.Application::get_unityVersion();\n\tv334 = v333 == 0;\n\tif (v334) goto L_0065;\n\t// 97 IsInst v260 @ X0_v44, typeof(System.Object), v333 @ X0_v21 (System.String)\nL_0065:\n\tv337 = v59.Length < 2;\n\tv114 = ~v337;\n\tv110 = v59.Length - 2;\n\tv102 = v110 == 0;\n\tv338 = ~v114;\n\tv82 = v338 | v102;\n\tif (v82) goto L_00DD;\n\tv59[2] = v333;\n\tUnityEngine.AndroidJavaObject::Call(v52, \"setPluginData\", v59);\n\tgoto L_008B;\n\tv349 = *([1EB4D70]);\n\tv350 = *([v349 @ X8_v37]);\n\tv351 = \"il2cpp_codegen_initialize_method\"(v350, v343, v342, v75, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv354 = 0 | 1;\n\t*([2029696]) = v354;\nL_008B:\n\tv359 = System.String::Concat(\"IntegrationHelper pluginVersion: \", \"6.13.0\");\n\tgoto L_009C;\n\tv367 = *([v363 @ X8_v26+E0]);\n\tv368 = v367 == 0;\n\tv369 = ~v368;\n\tgoto L_009C;\n\tv375 = v363;\n\tv371 = \"il2cpp_codegen_runtime_class_init\"(v375, v356, v78, v75, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_009C:\n\tUnityEngine.Debug::Log(v359);\n\tv376 = AndroidAgent::getBridge(v359);\n\t// 162 NewArr v129 @ X0_v31 (System.Object[]), typeof(System.Object[]), 2\n\tv378 = appKey == 0;\n\tif (v378) goto L_00AE;\n\t// 171 IsInst v261 @ X0_v38, typeof(System.Object), appKey @ X1 (System.String)\nL_00AE:\n\tv186 = v129.Length;\n\tv230 = v129.Length == 0;\n\tif (v230) goto L_00DD;\n\tv129[0] = appKey;\n\tv382 = adUnits == 0;\n\tif (v382) goto L_00BB;\n\t// 183 IsInst v262 @ X0_v36, typeof(System.Object), adUnits @ X2 (System.String[])\n\tv186 = v129.Length;\nL_00BB:\n\tv385 = v186 < 1;\n\tv171 = ~v385;\n\tv169 = v186 - 1;\n\tv165 = v169 == 0;\n\tv386 = ~v171;\n\tv155 = v386 | v165;\n\tif (v155) goto L_00DD;\n\tv129[1] = adUnits;\n\tUnityEngine.AndroidJavaObject::Call(v376, \"initISDemandOnly\", v129);\n\treturn;\nL_00DD:\n\tv236 = new System.IndexOutOfRangeException();\n\tgoto L_00E2;\n\tv274 = new System.ArrayTypeMismatchException();\nL_00E2:\n\tthrow v327;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void initISDemandOnly(string appKey, params string[] adUnits)
	{
		//IL_00ac: Expected O, but got I4
		//IL_0158: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_034a: Expected O, but got I
		//IL_028c: Expected O, but got I4
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[3];
		if ("Unity" != null)
		{
			object obj = "Unity" as object;
		}
		if (array.Length != 0)
		{
			array[0] = "Unity";
			if ("6.13.0" != null)
			{
				object obj2 = "6.13.0" as object;
			}
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj3 = array.Length - 1;
			bool flag3 = obj3 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = "6.13.0";
				string unityVersion = Application.unityVersion;
				if (unityVersion != null)
				{
					object obj4 = unityVersion as object;
				}
				bool flag5 = array.Length < 2;
				bool flag6 = !flag5;
				object obj5 = array.Length - 2;
				bool flag7 = obj5 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = unityVersion;
					bridge.Call("setPluginData", array);
					string text = "IntegrationHelper pluginVersion: " + "6.13.0";
					Debug.Log(text);
					AndroidJavaObject bridge2 = ((AndroidAgent)(object)text).getBridge();
					object[] array2 = new object[2];
					if (appKey != null)
					{
						object obj6 = appKey as object;
					}
					object obj7 = array2.Length;
					if (array2.Length != 0)
					{
						array2[0] = appKey;
						if (adUnits != null)
						{
							object obj8 = adUnits as object;
							obj7 = array2.Length;
						}
						bool flag9 = (long)(IntPtr)obj7 < 1L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj7 - 1L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array2[1] = adUnits;
							bridge2.Call("initISDemandOnly", array2);
							return;
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0x158F034", Offset = "0x158F034", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F10700]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029675]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"showRewardedVideo\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showRewardedVideo()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("showRewardedVideo");
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0x158F12C", Offset = "0x158F12C", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE1738]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, placementName, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029676]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = placementName == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), placementName @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = placementName;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"showRewardedVideo\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showRewardedVideo(string placementName)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		if (array.Length != 0)
		{
			array[0] = placementName;
			bridge.Call("showRewardedVideo", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000013")]
	[Address(RVA = "0x158F200", Offset = "0x158F200", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECC620]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029677]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv108 = v65;\n\tv109 = 0x8907BC(v108, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v40, \"isRewardedVideoAvailable\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isRewardedVideoAvailable()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		return bridge.Call<bool>("isRewardedVideoAvailable", Array.Empty<object>());
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0x158F300", Offset = "0x158F300", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE11A0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, placementName, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029678]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = placementName == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v18, typeof(System.Object), placementName @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003E;\n\tv48[0] = placementName;\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v41, \"isRewardedVideoPlacementCapped\", v48);\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_003E:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0045;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0045:\n\tthrow v92;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isRewardedVideoPlacementCapped(string placementName)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		if (array.Length != 0)
		{
			array[0] = placementName;
			return bridge.Call<bool>("isRewardedVideoPlacementCapped", array);
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0x158F3DC", Offset = "0x158F3DC", Length = "0x21C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED5188]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029679]) = v42;\nL_0015:\n\tv43 = AndroidAgent::getBridge(v39);\n\t// 28 NewArr v50 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv53 = placementName == 0;\n\tif (v53) goto L_0029;\n\t// 37 IsInst v148 @ X0_v37, typeof(System.Object), placementName @ X1 (System.String)\nL_0029:\n\tv155 = v50.Length == 0;\n\tif (v155) goto L_00B0;\n\tv50[0] = placementName;\n\tv188 = UnityEngine.AndroidJavaObject::Call(v43, \"getPlacementInfo\", v50);\n\tv229 = v188 == 0;\n\tif (v229) goto L_FFFFFFFF;\n\tv200 = IronSourceJSON.Json+Parser::Parse(v188);\n\tgoto L_FFFFFFFF;\n\tv126 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v200, \"placement_name\");\n\tv301 = *([v126 @ X0_v21]);\n\t*([v301 @ X8_v20+160])(v303, v126, *([v301 @ X8_v20+168]), Il2CppMethodInfo, Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv127 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v200, \"reward_name\");\n\tv306 = *([v127 @ X0_v24]);\n\t*([v306 @ X8_v23+160])(v308, v127, *([v306 @ X8_v23+168]), Il2CppMethodInfo, Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv128 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v200, \"reward_amount\");\n\tv311 = *([v128 @ X0_v27]);\n\t*([v311 @ X8_v26+160])(v314, v128, *([v311 @ X8_v26+168]), Il2CppMethodInfo, Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0095;\n\tv322 = *([v318 @ X8_v29+E0]);\n\tv323 = v322 == 0;\n\tv324 = ~v323;\n\tif (v324) goto L_0095;\n\tv330 = v318;\n\tv326 = \"il2cpp_codegen_runtime_class_init\"(v330, v313, v109, v104, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0095:\n\tv329 = System.Convert::ToInt32(v314);\n\tv286 = new IronSourcePlacement();\n\tSystem.Object::.ctor(v286);\n\t*([v286 @ X0_v33 (System.Object)+20]) = v303;\n\t*([v286 @ X0_v33 (System.Object)+10]) = v308;\n\t*([v286 @ X0_v33 (System.Object)+18]) = v329;\n\tgoto L_00AC;\nL_00AC:\n\treturn v290;\n\tv125 = new System.NullReferenceException();\n\tv144 = new System.NullReferenceException();\nL_00B0:\n\tv178 = new System.IndexOutOfRangeException();\n\tgoto L_00B5;\n\tv180 = new System.ArrayTypeMismatchException();\nL_00B5:\n\tthrow v221;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourcePlacement getPlacementInfo(string placementName)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		if (array.Length != 0)
		{
			array[0] = placementName;
			string text = bridge.Call<string>("getPlacementInfo", array);
			if (text != null)
			{
				object obj2 = Json.Parser.Parse(text);
				Dictionary<string, object> dictionary = obj2 as Dictionary<string, object>;
				object obj3 = ((Dictionary<string, object>)obj2).get_Item("placement_name");
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v301 @ X8_v20+160] (should have been resolved before IL gen)");
				object obj5 = ((Dictionary<string, object>)obj2).get_Item("reward_name");
				object obj6 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v306 @ X8_v23+160] (should have been resolved before IL gen)");
				object obj7 = ((Dictionary<string, object>)obj2).get_Item("reward_amount");
				object obj8 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v26+160] (should have been resolved before IL gen)");
				string value = default(string);
				int num = Convert.ToInt32(value);
				return null;
			}
			return null;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000016")]
	[Address(RVA = "0x158F648", Offset = "0x158F648", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EAFB38]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, parameters, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202967A]) = v40;\nL_0015:\n\tv42 = IronSourceJSON.Json+Serializer::Serialize(parameters);\n\tv44 = AndroidAgent::getBridge(v42);\n\t// 30 NewArr v51 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v42 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v59 @ X0_v19, typeof(System.Object), v42 @ X0_v3 (System.String)\nL_002B:\n\tv66 = v51.Length == 0;\n\tif (v66) goto L_003F;\n\tv51[0] = v42;\n\tUnityEngine.AndroidJavaObject::Call(v44, \"setRewardedVideoServerParams\", v51);\n\treturn;\n\tv55 = new System.NullReferenceException();\nL_003F:\n\tv71 = new System.IndexOutOfRangeException();\n\tgoto L_0046;\n\tv75 = new System.NullReferenceException();\n\tv78 = new System.ArrayTypeMismatchException();\nL_0046:\n\tthrow v92;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setRewardedVideoServerParams(Dictionary<string, string> parameters)
	{
		string text = Json.Serializer.Serialize(parameters);
		AndroidJavaObject bridge = ((AndroidAgent)(object)text).getBridge();
		object[] array = new object[1];
		if (text != null)
		{
			object obj = text as object;
		}
		if (array.Length != 0)
		{
			array[0] = text;
			bridge.Call("setRewardedVideoServerParams", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0x158F72C", Offset = "0x158F72C", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE1970]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202967B]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"clearRewardedVideoServerParams\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void clearRewardedVideoServerParams()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("clearRewardedVideoServerParams");
	}

	[Token(Token = "0x6000018")]
	[Address(RVA = "0x158F824", Offset = "0x158F824", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC2708]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, instanceId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202967C]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = instanceId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), instanceId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = instanceId;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"showISDemandOnlyRewardedVideo\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showISDemandOnlyRewardedVideo(string instanceId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (instanceId != null)
		{
			object obj = instanceId as object;
		}
		if (array.Length != 0)
		{
			array[0] = instanceId;
			bridge.Call("showISDemandOnlyRewardedVideo", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000019")]
	[Address(RVA = "0x158F8F8", Offset = "0x158F8F8", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC1C18]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, instanceId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202967D]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = instanceId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), instanceId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = instanceId;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"loadISDemandOnlyRewardedVideo\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadISDemandOnlyRewardedVideo(string instanceId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (instanceId != null)
		{
			object obj = instanceId as object;
		}
		if (array.Length != 0)
		{
			array[0] = instanceId;
			bridge.Call("loadISDemandOnlyRewardedVideo", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600001A")]
	[Address(RVA = "0x158F9CC", Offset = "0x158F9CC", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECEDD0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, instanceId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202967E]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = instanceId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v18, typeof(System.Object), instanceId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003E;\n\tv48[0] = instanceId;\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v41, \"isISDemandOnlyRewardedVideoAvailable\", v48);\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_003E:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0045;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0045:\n\tthrow v92;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isISDemandOnlyRewardedVideoAvailable(string instanceId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (instanceId != null)
		{
			object obj = instanceId as object;
		}
		if (array.Length != 0)
		{
			array[0] = instanceId;
			return bridge.Call<bool>("isISDemandOnlyRewardedVideoAvailable", array);
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600001B")]
	[Address(RVA = "0x158FAA8", Offset = "0x158FAA8", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC1C98]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202967F]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"loadInterstitial\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadInterstitial()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("loadInterstitial");
	}

	[Token(Token = "0x600001C")]
	[Address(RVA = "0x158FBA0", Offset = "0x158FBA0", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0A188]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029680]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"showInterstitial\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showInterstitial()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("showInterstitial");
	}

	[Token(Token = "0x600001D")]
	[Address(RVA = "0x158FC98", Offset = "0x158FC98", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F0D028]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, placementName, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029681]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = placementName == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), placementName @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = placementName;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"showInterstitial\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showInterstitial(string placementName)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		if (array.Length != 0)
		{
			array[0] = placementName;
			bridge.Call("showInterstitial", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600001E")]
	[Address(RVA = "0x158FD6C", Offset = "0x158FD6C", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF6AD0]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029682]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv108 = v65;\n\tv109 = 0x8907BC(v108, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v40, \"isInterstitialReady\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isInterstitialReady()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		return bridge.Call<bool>("isInterstitialReady", Array.Empty<object>());
	}

	[Token(Token = "0x600001F")]
	[Address(RVA = "0x158FE6C", Offset = "0x158FE6C", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ED2008]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, placementName, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029683]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = placementName == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v18, typeof(System.Object), placementName @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003E;\n\tv48[0] = placementName;\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v41, \"isInterstitialPlacementCapped\", v48);\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_003E:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0045;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0045:\n\tthrow v92;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isInterstitialPlacementCapped(string placementName)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		if (array.Length != 0)
		{
			array[0] = placementName;
			return bridge.Call<bool>("isInterstitialPlacementCapped", array);
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000020")]
	[Address(RVA = "0x158FF48", Offset = "0x158FF48", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F09378]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, instanceId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029684]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = instanceId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), instanceId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = instanceId;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"loadISDemandOnlyInterstitial\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadISDemandOnlyInterstitial(string instanceId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (instanceId != null)
		{
			object obj = instanceId as object;
		}
		if (array.Length != 0)
		{
			array[0] = instanceId;
			bridge.Call("loadISDemandOnlyInterstitial", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000021")]
	[Address(RVA = "0x159001C", Offset = "0x159001C", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EBDA70]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, instanceId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029685]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = instanceId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), instanceId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = instanceId;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"showISDemandOnlyInterstitial\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showISDemandOnlyInterstitial(string instanceId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (instanceId != null)
		{
			object obj = instanceId as object;
		}
		if (array.Length != 0)
		{
			array[0] = instanceId;
			bridge.Call("showISDemandOnlyInterstitial", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000022")]
	[Address(RVA = "0x15900F0", Offset = "0x15900F0", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF4958]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, instanceId, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029686]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = instanceId == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v18, typeof(System.Object), instanceId @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003E;\n\tv48[0] = instanceId;\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v41, \"isISDemandOnlyInterstitialReady\", v48);\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_003E:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0045;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0045:\n\tthrow v92;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isISDemandOnlyInterstitialReady(string instanceId)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (instanceId != null)
		{
			object obj = instanceId as object;
		}
		if (array.Length != 0)
		{
			array[0] = instanceId;
			return bridge.Call<bool>("isISDemandOnlyInterstitialReady", array);
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000023")]
	[Address(RVA = "0x15901CC", Offset = "0x15901CC", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAE708]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029687]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"showOfferwall\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showOfferwall()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("showOfferwall");
	}

	[Token(Token = "0x6000024")]
	[Address(RVA = "0x15902C4", Offset = "0x15902C4", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC8B88]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, placementName, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029688]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = placementName == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v17, typeof(System.Object), placementName @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003C;\n\tv48[0] = placementName;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"showOfferwall\", v48);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003C:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0043;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0043:\n\tthrow v89;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showOfferwall(string placementName)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		if (array.Length != 0)
		{
			array[0] = placementName;
			bridge.Call("showOfferwall", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000025")]
	[Address(RVA = "0x1590398", Offset = "0x1590398", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC07C0]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029689]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"getOfferwallCredits\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void getOfferwallCredits()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("getOfferwallCredits");
	}

	[Token(Token = "0x6000026")]
	[Address(RVA = "0x1590490", Offset = "0x1590490", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F09D68]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202968A]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv108 = v65;\n\tv109 = 0x8907BC(v108, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v40, \"isOfferwallAvailable\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isOfferwallAvailable()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		return bridge.Call<bool>("isOfferwallAvailable", Array.Empty<object>());
	}

	[Token(Token = "0x6000027")]
	[Address(RVA = "0x1590590", Offset = "0x1590590", Length = "0x60")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EBA9E0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, size, position, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202968B]) = v41;\nL_0020:\n\tAndroidAgent::loadBanner(v38, size, position, \"\");\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position)
	{
		loadBanner(size, position, "");
	}

	[Token(Token = "0x6000028")]
	[Address(RVA = "0x15905F0", Offset = "0x15905F0", Length = "0x1E8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1F06C60]);\n\tv33 = *([v32 @ X8_v31]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, size, position, placementName, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([202968C]) = v50;\nL_001A:\n\tv51 = AndroidAgent::getBridge(v47);\n\t// 33 NewArr v58 @ X0_v4 (System.Object[]), typeof(System.Object[]), 5\n\tv139 = size.description == 0;\n\tif (v139) goto L_0030;\n\t// 45 IsInst v143 @ X0_v35, typeof(System.Object), size.description (System.String)\nL_0030:\n\tv193 = v58.Length;\n\tv150 = v58.Length == 0;\n\tif (v150) goto L_00B3;\n\tv58[0] = size.description;\n\tv193 = size.width;\n\t// 58 Box v196 @ X0_v16, typeof(System.Int32), &v193 @ X8_v12 (System.Int32)\n\tv295 = v196 == 0;\n\tif (v295) goto L_0044;\n\t// 65 IsInst v278 @ X0_v33, typeof(System.Object), v196 @ X0_v16\nL_0044:\n\tv193 = v58.Length;\n\tv300 = v58.Length < 1;\n\tv232 = ~v300;\n\tv228 = v58.Length - 1;\n\tv220 = v228 == 0;\n\tv301 = ~v232;\n\tv200 = v301 | v220;\n\tif (v200) goto L_00B3;\n\tv58[1] = v196;\n\tv193 = size.height;\n\t// 86 Box v305 @ X0_v19, typeof(System.Int32), &v193 @ X8_v12 (System.Int32)\n\tv306 = v305 == 0;\n\tif (v306) goto L_0060;\n\t// 93 IsInst v279 @ X0_v31, typeof(System.Object), v305 @ X0_v19\nL_0060:\n\tv193 = v58.Length;\n\tv309 = v58.Length < 2;\n\tv233 = ~v309;\n\tv229 = v58.Length - 2;\n\tv221 = v229 == 0;\n\tv310 = ~v233;\n\tv201 = v310 | v221;\n\tif (v201) goto L_00B3;\n\tv58[2] = v305;\n\t// 113 Box v313 @ X0_v22, typeof(System.Int32), &position @ X2 (IronSourceBannerPosition)\n\tv314 = v313 == 0;\n\tif (v314) goto L_007B;\n\t// 120 IsInst v280 @ X0_v29, typeof(System.Object), v313 @ X0_v22\nL_007B:\n\tv193 = v58.Length;\n\tv317 = v58.Length < 3;\n\tv234 = ~v317;\n\tv230 = v58.Length - 3;\n\tv222 = v230 == 0;\n\tv318 = ~v234;\n\tv202 = v318 | v222;\n\tif (v202) goto L_00B3;\n\tv58[3] = v313;\n\tv319 = placementName == 0;\n\tif (v319) goto L_0092;\n\t// 142 IsInst v281 @ X0_v27, typeof(System.Object), placementName @ X3 (System.String)\n\tv193 = v58.Length;\nL_0092:\n\tv322 = v193 < 4;\n\tv107 = ~v322;\n\tv103 = v193 - 4;\n\tv95 = v103 == 0;\n\tv323 = ~v107;\n\tv75 = v323 | v95;\n\tif (v75) goto L_00B3;\n\tv58[4] = placementName;\n\tUnityEngine.AndroidJavaObject::Call(v51, \"loadBanner\", v58);\n\treturn;\nL_00B3:\n\tv257 = new System.IndexOutOfRangeException();\n\tgoto L_00B8;\n\tv294 = new System.ArrayTypeMismatchException();\nL_00B8:\n\tthrow v297;\n\tthrow System.NullReferenceException;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position, string placementName)
	{
		//IL_00fd: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_027c: Expected O, but got I4
		//IL_0383: Expected O, but got I4
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[5];
		if (size.Description != null)
		{
			object obj = size.Description as object;
		}
		int num = array.Length;
		if (array.Length != 0)
		{
			array[0] = size.Description;
			num = size.Width;
			object obj2 = num;
			if (obj2 != null)
			{
				object obj3 = obj2 as object;
			}
			num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj4 = array.Length - 1;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = obj2;
				num = size.Height;
				object obj5 = num;
				if (obj5 != null)
				{
					object obj6 = obj5 as object;
				}
				num = array.Length;
				bool flag5 = array.Length < 2;
				bool flag6 = !flag5;
				object obj7 = array.Length - 2;
				bool flag7 = obj7 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = obj5;
					object obj8 = (int)position;
					if (obj8 != null)
					{
						object obj9 = obj8 as object;
					}
					num = array.Length;
					bool flag9 = array.Length < 3;
					bool flag10 = !flag9;
					object obj10 = array.Length - 3;
					bool flag11 = obj10 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array[3] = obj8;
						if (placementName != null)
						{
							object obj11 = placementName as object;
							num = array.Length;
						}
						bool flag13 = num < 4;
						bool flag14 = !flag13;
						object obj12 = num - 4;
						bool flag15 = obj12 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							array[4] = placementName;
							bridge.Call("loadBanner", array);
							return;
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000029")]
	[Address(RVA = "0x15907D8", Offset = "0x15907D8", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE8820]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202968D]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"destroyBanner\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void destroyBanner()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("destroyBanner");
	}

	[Token(Token = "0x600002A")]
	[Address(RVA = "0x15908D0", Offset = "0x15908D0", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFD610]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202968E]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"displayBanner\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void displayBanner()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("displayBanner");
	}

	[Token(Token = "0x600002B")]
	[Address(RVA = "0x15909C8", Offset = "0x15909C8", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFA420]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202968F]) = v39;\nL_0013:\n\tv40 = AndroidAgent::getBridge(v36);\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v83;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv105 = v65;\n\tv106 = 0x8907BC(v105, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tgoto L_0055;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.AndroidJavaObject::Call(v40, \"hideBanner\", v92.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void hideBanner()
	{
		AndroidJavaObject bridge = getBridge();
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		bridge.Call("hideBanner");
	}

	[Token(Token = "0x600002C")]
	[Address(RVA = "0x1590AC0", Offset = "0x1590AC0", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EEEE68]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, placementName, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029690]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv51 = placementName == 0;\n\tif (v51) goto L_0028;\n\t// 36 IsInst v56 @ X0_v18, typeof(System.Object), placementName @ X1 (System.String)\nL_0028:\n\tv63 = v48.Length == 0;\n\tif (v63) goto L_003E;\n\tv48[0] = placementName;\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(v41, \"isBannerPlacementCapped\", v48);\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_003E:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0045;\n\tv72 = new System.NullReferenceException();\n\tv75 = new System.ArrayTypeMismatchException();\nL_0045:\n\tthrow v92;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isBannerPlacementCapped(string placementName)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		if (array.Length != 0)
		{
			array[0] = placementName;
			return bridge.Call<bool>("isBannerPlacementCapped", array);
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600002D")]
	[Address(RVA = "0x1590B9C", Offset = "0x1590B9C", Length = "0xE4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1F102B0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, segment, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029691]) = v40;\nL_0017:\n\tv43 = IronSourceSegment::getSegmentAsDict(segment);\n\tv59 = IronSourceJSON.Json+Serializer::Serialize(v43);\n\tv72 = AndroidAgent::getBridge(v59);\n\t// 33 NewArr v64 @ X0_v15 (System.Object[]), typeof(System.Object[]), 1\n\tv99 = v59 == 0;\n\tif (v99) goto L_002E;\n\t// 42 IsInst v101 @ X0_v19, typeof(System.Object), v59 @ X0_v12 (System.String)\nL_002E:\n\tv77 = v64.Length == 0;\n\tif (v77) goto L_0043;\n\tv64[0] = v59;\n\tUnityEngine.AndroidJavaObject::Call(v72, \"setSegment\", v64);\n\treturn;\n\tv71 = new System.NullReferenceException();\nL_0043:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv89 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v88;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setSegment(IronSourceSegment segment)
	{
		Dictionary<string, string> segmentAsDict = segment.getSegmentAsDict();
		string text = Json.Serializer.Serialize(segmentAsDict);
		AndroidJavaObject bridge = ((AndroidAgent)(object)text).getBridge();
		object[] array = new object[1];
		if (text != null)
		{
			object obj = text as object;
		}
		if (array.Length != 0)
		{
			array[0] = text;
			bridge.Call("setSegment", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600002E")]
	[Address(RVA = "0x1591118", Offset = "0x1591118", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF4AE0]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, consent, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029692]) = v40;\nL_0014:\n\tv41 = AndroidAgent::getBridge(v37);\n\t// 27 NewArr v48 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\t// 34 Box v55 @ X0_v6, typeof(System.Boolean), &consent @ X1 (System.Boolean)\n\tv58 = v55 == 0;\n\tif (v58) goto L_002F;\n\t// 43 IsInst v72 @ X0_v17, typeof(System.Object), v55 @ X0_v6\nL_002F:\n\tv76 = v48.Length == 0;\n\tif (v76) goto L_0044;\n\tv48[0] = v55;\n\tUnityEngine.AndroidJavaObject::Call(v41, \"setConsent\", v48);\n\treturn;\n\tv68 = new System.NullReferenceException();\nL_0044:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0049;\n\tv82 = new System.ArrayTypeMismatchException();\nL_0049:\n\tthrow v90;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setConsent(bool consent)
	{
		AndroidJavaObject bridge = getBridge();
		object[] array = new object[1];
		object obj = consent;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			bridge.Call("setConsent", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}
}
