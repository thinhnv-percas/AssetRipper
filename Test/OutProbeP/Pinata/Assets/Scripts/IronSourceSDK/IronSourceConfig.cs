using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using IronSourceJSON;
using UnityEngine;

[Token(Token = "0x2000004")]
public class IronSourceConfig
{
	[Token(Token = "0x400000C")]
	private const string unsupportedPlatformStr = "Unsupported Platform";

	[Token(Token = "0x400000D")]
	private static IronSourceConfig _instance;

	[Token(Token = "0x400000E")]
	private static AndroidJavaObject _androidBridge;

	[Token(Token = "0x400000F")]
	private static readonly string AndroidBridge = "com.ironsource.unity.androidbridge.AndroidBridge";

	[Token(Token = "0x17000002")]
	public static IronSourceConfig Instance
	{
		[Token(Token = "0x6000060")]
		[Address(RVA = "0x15939CC", Offset = "0x15939CC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EC4E00]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20296C9]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = IronSourceConfig;\nL_0021:\n\tv53 = v51._instance == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0038;\n\tv56 = new IronSourceConfig();\n\tIronSourceConfig::.ctor(v56);\n\tgoto L_0033;\n\tv86 = *([v81 @ X0_v10 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0033;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v81, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv90 = IronSourceConfig;\nL_0033:\n\tv62._instance = v56;\nL_0038:\n\tgoto L_0046;\n\tv68 = *([v57 @ X0_v4 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_0046;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv72 = IronSourceConfig;\nL_0046:\n\treturn v75._instance;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			if (_instance == null)
			{
				IronSourceConfig instance = new IronSourceConfig();
				_instance = instance;
			}
			return _instance;
		}
	}

	[Token(Token = "0x6000061")]
	[Address(RVA = "0x1593A8C", Offset = "0x1593A8C", Length = "0x238")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE9F28]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296CA]) = v42;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tgoto L_002A;\n\tv51 = *([v47 @ X0_v3 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v47, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv55 = IronSourceConfig;\nL_002A:\n\tv63 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v63, v59.AndroidBridge);\n\tv72 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv77 = v72;\n\tv78 = UnityEngine.AndroidJavaObject::CallStatic(v77, v65, v66, v27);\n\tv81 = *([v72 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003C:\n\tv82 = *([v72 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv83 = v82 == 0;\n\tif (v83) goto L_005D;\n\tv85 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0049;\n\tv107 = v85;\n\tv108 = UnityEngine.AndroidJavaObject::CallStatic(v107, v65, v66, v27);\nL_0049:\n\tv109 = *([v85 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv95 = ~v109;\n\tif (v95) goto L_005D;\n\tgoto L_005D;\n\tv129 = v100;\n\tv130 = UnityEngine.AndroidJavaObject::CallStatic(v129, v65, v66, v27);\nL_005D:\n\tgoto L_006B;\n\tv110 = v102;\n\tv111 = UnityEngine.AndroidJavaObject::CallStatic(v110, v65, v66, v27);\nL_006B:\n\tv126 = UnityEngine.AndroidJavaObject::CallStatic(v63, \"getInstance\", v118.Value);\n\tgoto L_007B;\n\tv201 = *([v134 @ X0_v29 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_007B;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v134, v123, v122, v124, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv205 = IronSourceConfig;\nL_007B:\n\tv208._androidBridge = v126;\nL_0082:\n\tgoto L_00A9;\n\tv255 = *([v249 @ X8_v15+B0]);\n\tv256 = 0;\n\tv257 = v255 + 8;\n\tv259 = *([v297 @ X11_v6-8]);\n\tv303 = v259 == v252;\n\tif (v303) goto L_00A2;\n\tv281 = v298 + 1;\n\tv308 = v281 < v251;\n\tv277 = ~v308;\n\tv279 = v297 + 0x10;\n\tv261 = ~v277;\n\tif (v261) goto L_FFFFFFFF;\n\tv282 = v67;\n\tv283 = 0;\n\tv284 = 0x8909C4(v282, v252, v283, v233, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A9;\nL_00A2:\n\tv309 = *([v297 @ X11_v6]);\n\tv310 = v309 << 4;\n\tv311 = v249 + v310;\n\tv312 = v311 + 0x130;\nL_00A9:\n\tSystem.IDisposable::Dispose(v63);\n\tv334 = v239 + 1;\n\tv336 = v334 == 0;\n\tv339 = ~v336;\n\tif (v339) goto L_00BB;\nL_00B1:\n\tv393 = v196 == 0;\n\tv192 = ~v393;\n\tif (v192) goto L_00C1;\nL_00BB:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00C1:\n\tv200 = new System.TypeLoadException();\n\tgoto L_00CE;\n\tgoto L_00CE;\nL_00CE:\n\tgoto L_00D6;\n\tv285 = UnityEngine.AndroidJavaObject::CallStatic(v200, 0, 0);\n\tv196 = *([v285 @ X0_v21 (UnityEngine.AndroidJavaObject)]);\n\tv242 = UnityEngine.AndroidJavaObject::CallStatic(v285, 0, 0);\n\tv244 = v63 == 0;\n\tif (v244) goto L_00B1;\n\tgoto L_0082;\nL_00D6:\n\tv286 = UnityEngine.AndroidJavaObject::CallStatic(v200, 0, 0);\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourceConfig()
	{
		//IL_0178: Expected I, but got O
		base._002Ector();
		AndroidJavaClass androidJavaClass = new AndroidJavaClass(AndroidBridge);
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		_androidBridge = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		int num = 0;
		IntPtr intPtr3 = (IntPtr)null;
		((IDisposable)androidJavaClass).Dispose();
		if (num + 1 == 0 && intPtr3 != (IntPtr)0)
		{
			AndroidJavaObject androidJavaObject = ((AndroidJavaObject)(object)new TypeLoadException()).CallStatic<AndroidJavaObject>((string)null, (object[])null);
		}
	}

	[Token(Token = "0x6000062")]
	[Address(RVA = "0x1593CC4", Offset = "0x1593CC4", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EE4678]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, language, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([20296CB]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, language, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = IronSourceConfig;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = language == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), language @ X1 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = language;\n\tUnityEngine.AndroidJavaObject::Call(v55._androidBridge, \"setLanguage\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setLanguage(string language)
	{
		object[] array = new object[1];
		if (language != null)
		{
			object obj = language as object;
		}
		if (array.Length != 0)
		{
			array[0] = language;
			_androidBridge.Call("setLanguage", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000063")]
	[Address(RVA = "0x1593DB8", Offset = "0x1593DB8", Length = "0x110")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF8F60]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, status, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([20296CC]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, status, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = IronSourceConfig;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v68 @ X0_v7, typeof(System.Boolean), &status @ X1 (System.Boolean)\n\tv71 = v68 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v85 @ X0_v18, typeof(System.Object), v68 @ X0_v7\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v68;\n\tUnityEngine.AndroidJavaObject::Call(v55._androidBridge, \"setClientSideCallbacks\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setClientSideCallbacks(bool status)
	{
		object[] array = new object[1];
		object obj = status;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			_androidBridge.Call("setClientSideCallbacks", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000064")]
	[Address(RVA = "0x1593EC8", Offset = "0x1593EC8", Length = "0x104")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EC8508]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, rewardedVideoCustomParams, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([20296CD]) = v40;\nL_0015:\n\tv42 = IronSourceJSON.Json+Serializer::Serialize(rewardedVideoCustomParams);\n\tgoto L_002B;\n\tv50 = *([v46 @ X8_v3 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_002B;\n\tv66 = v46;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v66, rewardedVideoCustomParams, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv58 = IronSourceConfig;\nL_002B:\n\t// 43 NewArr v65 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\tv69 = v42 == 0;\n\tif (v69) goto L_0038;\n\t// 52 IsInst v74 @ X0_v19, typeof(System.Object), v42 @ X0_v3 (System.String)\nL_0038:\n\tv81 = v65.Length == 0;\n\tif (v81) goto L_004C;\n\tv65[0] = v42;\n\tUnityEngine.AndroidJavaObject::Call(v60._androidBridge, \"setRewardedVideoCustomParams\", v65);\n\treturn;\n\tv70 = new System.NullReferenceException();\nL_004C:\n\tv86 = new System.IndexOutOfRangeException();\n\tgoto L_0053;\n\tv90 = new System.NullReferenceException();\n\tv93 = new System.ArrayTypeMismatchException();\nL_0053:\n\tthrow v107;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setRewardedVideoCustomParams(Dictionary<string, string> rewardedVideoCustomParams)
	{
		string text = Json.Serializer.Serialize(rewardedVideoCustomParams);
		object[] array = new object[1];
		if (text != null)
		{
			object obj = text as object;
		}
		if (array.Length != 0)
		{
			array[0] = text;
			_androidBridge.Call("setRewardedVideoCustomParams", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000065")]
	[Address(RVA = "0x1593FCC", Offset = "0x1593FCC", Length = "0x104")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ED14E8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, offerwallCustomParams, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([20296CE]) = v40;\nL_0015:\n\tv42 = IronSourceJSON.Json+Serializer::Serialize(offerwallCustomParams);\n\tgoto L_002B;\n\tv50 = *([v46 @ X8_v3 (Il2CppClass<IronSourceConfig>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_002B;\n\tv66 = v46;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v66, offerwallCustomParams, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv58 = IronSourceConfig;\nL_002B:\n\t// 43 NewArr v65 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\tv69 = v42 == 0;\n\tif (v69) goto L_0038;\n\t// 52 IsInst v74 @ X0_v19, typeof(System.Object), v42 @ X0_v3 (System.String)\nL_0038:\n\tv81 = v65.Length == 0;\n\tif (v81) goto L_004C;\n\tv65[0] = v42;\n\tUnityEngine.AndroidJavaObject::Call(v60._androidBridge, \"setOfferwallCustomParams\", v65);\n\treturn;\n\tv70 = new System.NullReferenceException();\nL_004C:\n\tv86 = new System.IndexOutOfRangeException();\n\tgoto L_0053;\n\tv90 = new System.NullReferenceException();\n\tv93 = new System.ArrayTypeMismatchException();\nL_0053:\n\tthrow v107;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setOfferwallCustomParams(Dictionary<string, string> offerwallCustomParams)
	{
		string text = Json.Serializer.Serialize(offerwallCustomParams);
		object[] array = new object[1];
		if (text != null)
		{
			object obj = text as object;
		}
		if (array.Length != 0)
		{
			array[0] = text;
			_androidBridge.Call("setOfferwallCustomParams", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}
}
