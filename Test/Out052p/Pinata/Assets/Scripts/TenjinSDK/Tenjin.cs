using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000006")]
public static class Tenjin
{
	[Token(Token = "0x2000008")]
	public delegate void DeferredDeeplinkDelegate(Dictionary<string, string> deferredLinkData);

	[Token(Token = "0x4000009")]
	private static Dictionary<string, BaseTenjin> _instances;

	[Token(Token = "0x6000049")]
	[Address(RVA = "0x1660720", Offset = "0x1660720", Length = "0x128")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA8BE8]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF68]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Tenjin>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\t// 30 Jump @b26\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = Tenjin;\nL_0029:\n\tv62 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::ContainsKey(v54._instances, apiKey);\n\tv79 = v62 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_004C;\n\tgoto L_003E;\n\tv111 = *([v96 @ X0_v18 (Il2CppClass<Tenjin>)+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_003E;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v96, v60, v61, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv115 = Tenjin;\nL_003E:\n\tv87 = Tenjin::createTenjin(apiKey, 0, 0);\n\tSystem.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::Add(v91._instances, apiKey, v87);\nL_004C:\n\tgoto L_0061;\n\tv120 = *([v107 @ X0_v12 (Il2CppClass<Tenjin>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\t// 80 ConditionalJump @b28, v122 @ TEMP_v19\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v107, v68, v66, v64, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv124 = Tenjin;\nL_0061:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::get_Item(v74._instances, apiKey);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static BaseTenjin getInstance(string apiKey)
	{
		if (!_instances.ContainsKey(apiKey))
		{
			BaseTenjin value = createTenjin(apiKey, null, 0);
			_instances.Add(apiKey, value);
		}
		return _instances.get_Item(apiKey);
	}

	[Token(Token = "0x600004A")]
	[Address(RVA = "0x16609C0", Offset = "0x16609C0", Length = "0x158")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC45A8]);\n\tv27 = *([v26 @ X8_v28]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, sharedSecret, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202AF69]) = v45;\nL_001D:\n\tv52 = System.String::Concat(apiKey, \".\", sharedSecret);\n\tgoto L_0035;\n\tv60 = *([v56 @ X8_v5 (Il2CppClass<Tenjin>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\t// 41 Jump @b27\n\tv72 = v56;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v72, v51, v49, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv68 = Tenjin;\nL_0035:\n\tv77 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::ContainsKey(v69._instances, v52);\n\tv94 = v77 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0058;\n\tgoto L_004A;\n\tv126 = *([v111 @ X0_v19 (Il2CppClass<Tenjin>)+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_004A;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v111, v75, v76, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv130 = Tenjin;\nL_004A:\n\tv104 = Tenjin::createTenjin(apiKey, sharedSecret, 0);\n\tSystem.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::Add(v108._instances, v52, v104);\nL_0058:\n\tgoto L_006F;\n\tv135 = *([v122 @ X0_v13 (Il2CppClass<Tenjin>)+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\t// 92 ConditionalJump @b29, v137 @ TEMP_v19\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v122, v85, v83, v81, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv139 = Tenjin;\nL_006F:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::get_Item(v91._instances, v52);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static BaseTenjin getInstanceWithSharedSecret(string apiKey, string sharedSecret)
	{
		string key = apiKey + "." + sharedSecret;
		if (!_instances.ContainsKey(key))
		{
			BaseTenjin value = createTenjin(apiKey, sharedSecret, 0);
			_instances.Add(key, value);
		}
		return _instances.get_Item(key);
	}

	[Token(Token = "0x600004B")]
	[Address(RVA = "0x1660B18", Offset = "0x1660B18", Length = "0x174")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1F083E0]);\n\tv27 = *([v26 @ X8_v30]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, appSubversion, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202AF6A]) = v45;\nL_001C:\n\t// 28 Box v51 @ X0_v3 (System.Object), typeof(System.Int32), &appSubversion @ X1 (System.Int32)\n\tv58 = System.String::Concat(apiKey, \".\", v51);\n\tgoto L_003B;\n\tv66 = *([v62 @ X8_v7 (Il2CppClass<Tenjin>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\t// 47 Jump @b28\n\tv78 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v78, v57, v54, v56, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv74 = Tenjin;\nL_003B:\n\tv83 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::ContainsKey(v75._instances, v58);\n\tv100 = v83 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_005E;\n\tgoto L_0050;\n\tv132 = *([v117 @ X0_v21 (Il2CppClass<Tenjin>)+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0050;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v117, v81, v82, v56, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv136 = Tenjin;\nL_0050:\n\tv110 = Tenjin::createTenjin(apiKey, 0, appSubversion);\n\tSystem.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::Add(v114._instances, v58, v110);\nL_005E:\n\tgoto L_006D;\n\tv141 = *([v128 @ X0_v15 (Il2CppClass<Tenjin>)+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\t// 98 ConditionalJump @b30, v143 @ TEMP_v19\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v128, v87, v91, v89, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv145 = Tenjin;\nL_006D:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::get_Item(v97._instances, v58);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static BaseTenjin getInstanceWithAppSubversion(string apiKey, int appSubversion)
	{
		object obj = appSubversion;
		string key = apiKey + "." + obj;
		if (!_instances.ContainsKey(key))
		{
			BaseTenjin value = createTenjin(apiKey, null, appSubversion);
			_instances.Add(key, value);
		}
		return _instances.get_Item(key);
	}

	[Token(Token = "0x600004C")]
	[Address(RVA = "0x1660C8C", Offset = "0x1660C8C", Length = "0x27C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1F07680]);\n\tv31 = *([v30 @ X8_v49]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sharedSecret, appSubversion, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202AF6B]) = v48;\nL_001D:\n\t// 29 NewArr v53 @ X0_v3 (System.Object[]), typeof(System.Object[]), 5\n\tv56 = apiKey == 0;\n\tif (v56) goto L_0029;\n\t// 38 IsInst v134 @ X0_v52, typeof(System.Object), apiKey @ X0 (System.String)\nL_0029:\n\tv233 = v53.Length;\n\tv141 = v53.Length == 0;\n\tif (v141) goto L_00E7;\n\tv53[0] = apiKey;\n\tv173 = \".\" == 0;\n\tif (v173) goto L_0038;\n\t// 52 IsInst v253 @ X0_v50, typeof(System.Object), \".\"\n\tv233 = v53.Length;\nL_0038:\n\tv269 = v233 < 1;\n\tv207 = ~v269;\n\tv203 = v233 - 1;\n\tv195 = v203 == 0;\n\tv270 = ~v207;\n\tv175 = v270 | v195;\n\tif (v175) goto L_00E7;\n\tv53[1] = \".\";\n\tv310 = sharedSecret == 0;\n\tif (v310) goto L_004F;\n\t// 75 IsInst v254 @ X0_v49, typeof(System.Object), sharedSecret @ X1 (System.String)\n\tv233 = v53.Length;\nL_004F:\n\tv313 = v233 < 2;\n\tv208 = ~v313;\n\tv204 = v233 - 2;\n\tv196 = v204 == 0;\n\tv314 = ~v208;\n\tv176 = v314 | v196;\n\tif (v176) goto L_00E7;\n\tv53[2] = sharedSecret;\n\tv316 = \".\" == 0;\n\tif (v316) goto L_0065;\n\t// 97 IsInst v255 @ X0_v47, typeof(System.Object), \".\"\n\tv233 = v53.Length;\nL_0065:\n\tv318 = v233 < 3;\n\tv209 = ~v318;\n\tv205 = v233 - 3;\n\tv197 = v205 == 0;\n\tv319 = ~v209;\n\tv177 = v319 | v197;\n\tif (v177) goto L_00E7;\n\tv53[3] = \".\";\n\t// 120 Box v325 @ X0_v22, typeof(System.Int32), &appSubversion @ X2 (System.Int32)\n\tv326 = v325 == 0;\n\tif (v326) goto L_0083;\n\t// 127 IsInst v256 @ X0_v46, typeof(System.Object), v325 @ X0_v22\nL_0083:\n\tv329 = v53.Length < 4;\n\tv99 = ~v329;\n\tv95 = v53.Length - 4;\n\tv87 = v95 == 0;\n\tv330 = ~v99;\n\tv67 = v330 | v87;\n\tif (v67) goto L_00E7;\n\tv53[4] = v325;\n\tv332 = System.String::Concat(v53);\n\tgoto L_00AA;\n\tv338 = *([v334 @ X8_v20 (Il2CppClass<Tenjin>)+E0]);\n\tv339 = v338 == 0;\n\tv340 = ~v339;\n\t// 158 ConditionalJump @b57, v340 @ TEMP_v42\n\tv346 = v334;\n\tv342 = \"il2cpp_codegen_runtime_class_init\"(v346, v114, appSubversion, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv345 = Tenjin;\nL_00AA:\n\tv351 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::ContainsKey(v126._instances, v332);\n\tv353 = v351 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00CD;\n\tgoto L_00BF;\n\tv370 = *([v355 @ X0_v36 (Il2CppClass<Tenjin>)+E0]);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_00BF;\n\tv386 = \"il2cpp_codegen_runtime_class_init\"(v355, v349, v350, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv374 = Tenjin;\nL_00BF:\n\tv162 = Tenjin::createTenjin(apiKey, sharedSecret, appSubversion);\n\tSystem.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::Add(v166._instances, v332, v162);\nL_00CD:\n\tgoto L_00DC;\n\tv379 = *([v366 @ X0_v30 (Il2CppClass<Tenjin>)+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\t// 209 ConditionalJump @b59, v381 @ TEMP_v34\n\tv387 = \"il2cpp_codegen_runtime_class_init\"(v366, v115, v61, v58, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv383 = Tenjin;\nL_00DC:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::get_Item(v127._instances, v332);\n\treturn returnVal2;\nL_00E7:\n\tv234 = new System.IndexOutOfRangeException();\n\tgoto L_00EC;\n\tv267 = new System.ArrayTypeMismatchException();\nL_00EC:\n\tthrow v309;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static BaseTenjin getInstanceWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion)
	{
		//IL_003e: Expected O, but got I4
		//IL_02e7: Expected O, but got I
		//IL_00aa: Expected O, but got I4
		//IL_0345: Expected O, but got I
		//IL_00fb: Expected O, but got I4
		//IL_03a3: Expected O, but got I
		//IL_014d: Expected O, but got I4
		//IL_01cd: Expected O, but got I4
		object[] array = new object[5];
		if (apiKey != null)
		{
			object obj = apiKey as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = apiKey;
			if ("." != null)
			{
				object obj3 = "." as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = ".";
				if (sharedSecret != null)
				{
					object obj5 = sharedSecret as object;
					obj2 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj2 < 2L;
				bool flag6 = !flag5;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = sharedSecret;
					if ("." != null)
					{
						object obj7 = "." as object;
						obj2 = array.Length;
					}
					bool flag9 = (long)(IntPtr)obj2 < 3L;
					bool flag10 = !flag9;
					object obj8 = (long)(IntPtr)obj2 - 3L;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array[3] = ".";
						object obj9 = appSubversion;
						if (obj9 != null)
						{
							object obj10 = obj9 as object;
						}
						bool flag13 = array.Length < 4;
						bool flag14 = !flag13;
						object obj11 = array.Length - 4;
						bool flag15 = obj11 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							array[4] = obj9;
							string key = string.Concat(array);
							if (!_instances.ContainsKey(key))
							{
								BaseTenjin value = createTenjin(apiKey, sharedSecret, appSubversion);
								_instances.Add(key, value);
							}
							return _instances.get_Item(key);
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600004D")]
	[Address(RVA = "0x1660848", Offset = "0x1660848", Length = "0x178")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EE1530]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, sharedSecret, appSubversion, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AF6C]) = v44;\nL_001A:\n\tv48 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v48, \"Tenjin\");\n\tUnityEngine.Object::set_hideFlags(v48, 0x3D);\n\tgoto L_0035;\n\tv81 = *([v77 @ X0_v8+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0035;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v77, v55, v57, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tUnityEngine.Object::DontDestroyOnLoad(v48);\n\tv122 = UnityEngine.GameObject::AddComponent(v48);\n\tv63 = System.String::IsNullOrEmpty(sharedSecret);\n\tv124 = appSubversion == 0;\n\tif (v124) goto L_0052;\n\tv126 = v63 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_0052;\n\tv139 = AndroidTenjin::InitWithSharedSecretAppSubversion(v122, apiKey, sharedSecret, appSubversion);\n\tgoto L_0079;\nL_0052:\n\tv64 = System.String::IsNullOrEmpty(sharedSecret);\n\tv131 = v64 == 0;\n\tif (v131) goto L_006A;\n\tv155 = appSubversion == 0;\n\tif (v155) goto L_0070;\n\tv153 = AndroidTenjin::InitWithAppSubversion(v122, apiKey, appSubversion);\n\tgoto L_0079;\nL_006A:\n\tv154 = AndroidTenjin::InitWithSharedSecret(v122, apiKey, sharedSecret);\n\tgoto L_0079;\nL_0070:\n\tv152 = AndroidTenjin::Init(v122, apiKey);\nL_0079:\n\treturn v122;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static BaseTenjin createTenjin(string apiKey, string sharedSecret, int appSubversion)
	{
		GameObject gameObject = new GameObject("Tenjin");
		gameObject.hideFlags = HideFlags.HideAndDontSave;
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		AndroidTenjin androidTenjin = gameObject.AddComponent<AndroidTenjin>();
		bool flag = string.IsNullOrEmpty(sharedSecret);
		if (appSubversion != 0 && !flag)
		{
			androidTenjin.InitWithSharedSecretAppSubversion(apiKey, sharedSecret, appSubversion);
		}
		else if (string.IsNullOrEmpty(sharedSecret))
		{
			if (appSubversion != 0)
			{
				androidTenjin.InitWithAppSubversion(apiKey, appSubversion);
			}
			else
			{
				androidTenjin.Init(apiKey);
			}
		}
		else
		{
			androidTenjin.InitWithSharedSecret(apiKey, sharedSecret);
		}
		return androidTenjin;
	}

	[Token(Token = "0x600004E")]
	[Address(RVA = "0x1660F08", Offset = "0x1660F08", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1ECBC60]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF6D]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::.ctor(v39);\n\tv47._instances = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static Tenjin()
	{
		Dictionary<string, BaseTenjin> instances = new Dictionary<string, BaseTenjin>();
		_instances = instances;
	}
}
