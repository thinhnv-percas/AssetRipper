using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000002")]
public class AndroidTenjin : BaseTenjin
{
	[Token(Token = "0x2000007")]
	private class DeferredDeeplinkListener : AndroidJavaProxy
	{
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x20")]
		private Tenjin.DeferredDeeplinkDelegate callback;

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x165DD34", Offset = "0x165DD34", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBE7F0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, deferredDeeplinkCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF48]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, deferredDeeplinkCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.tenjin.android.Callback\");\n\tthis.callback = deferredDeeplinkCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DeferredDeeplinkListener(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkCallback)
			: base("com.tenjin.android.Callback")
		{
			callback = deferredDeeplinkCallback;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x165EA40", Offset = "0x165EA40", Length = "0x3C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1ED8B80]);\n\tv41 = *([v40 @ X8_v59]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, clickedTenjinLink, isFirstSession, data, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([202AF49]) = v57;\nL_0021:\n\tv61 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v61);\n\t// 43 NewArr v70 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv76 = \"ad_network\" == 0;\n\tif (v76) goto L_003A;\n\t// 54 IsInst v142 @ X0_v68, typeof(System.Object), \"ad_network\"\nL_003A:\n\tv149 = v70.Length == 0;\n\tif (v149) goto L_0120;\n\tv70[0] = \"ad_network\";\n\tv236 = UnityEngine.AndroidJavaObject::Call(data, \"get\", v70);\n\t// 78 NewArr v111 @ X0_v22 (System.Object[]), typeof(System.Object[]), 1\n\tv327 = \"campaign_id\" == 0;\n\tif (v327) goto L_005E;\n\t// 89 IsInst v208 @ X0_v67, typeof(System.Object), \"campaign_id\"\nL_005E:\n\tv168 = v111.Length == 0;\n\tif (v168) goto L_0120;\n\tv111[0] = \"campaign_id\";\n\tv333 = UnityEngine.AndroidJavaObject::Call(data, \"get\", v111);\n\t// 108 NewArr v112 @ X0_v28 (System.Object[]), typeof(System.Object[]), 1\n\tv337 = \"advertising_id\" == 0;\n\tif (v337) goto L_007B;\n\t// 119 IsInst v209 @ X0_v66, typeof(System.Object), \"advertising_id\"\nL_007B:\n\tv169 = v112.Length == 0;\n\tif (v169) goto L_0120;\n\tv112[0] = \"advertising_id\";\n\tv343 = UnityEngine.AndroidJavaObject::Call(data, \"get\", v112);\n\t// 136 NewArr v113 @ X0_v34 (System.Object[]), typeof(System.Object[]), 1\n\tv347 = \"deferred_deeplink_url\" == 0;\n\tif (v347) goto L_0097;\n\t// 147 IsInst v210 @ X0_v65, typeof(System.Object), \"deferred_deeplink_url\"\nL_0097:\n\tv170 = v113.Length == 0;\n\tif (v170) goto L_0120;\n\tv113[0] = \"deferred_deeplink_url\";\n\tv352 = UnityEngine.AndroidJavaObject::Call(data, \"get\", v113);\n\tv253 = System.String::IsNullOrEmpty(v236);\n\tv355 = v253 == 0;\n\tv356 = ~v355;\n\tif (v356) goto L_00B5;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v61, \"ad_network\", v236);\nL_00B5:\n\tv254 = System.String::IsNullOrEmpty(v333);\n\tv370 = v254 == 0;\n\tv371 = ~v370;\n\tif (v371) goto L_00C7;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v61, \"campaign_id\", v333);\nL_00C7:\n\tv255 = System.String::IsNullOrEmpty(v343);\n\tv385 = v255 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_00D7;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v61, \"advertising_id\", v343);\nL_00D7:\n\tv256 = System.String::IsNullOrEmpty(v352);\n\tv398 = v256 == 0;\n\tv399 = ~v398;\n\tif (v399) goto L_00ED;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v61, \"deferred_deeplink_url\", v352);\nL_00ED:\n\tgoto L_00F6;\n\tv417 = *([v412 @ X0_v51+E0]);\n\tv418 = v417 == 0;\n\tv419 = ~v418;\n\tif (v419) goto L_00F6;\n\tv421 = \"il2cpp_codegen_runtime_class_init\"(v412, v403, v401, v241, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_00F6:\n\tv257 = System.Convert::ToString(clickedTenjinLink);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"clicked_tenjin_link\", v257);\n\tv433 = System.Convert::ToString(isFirstSession);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"is_first_session\", v433);\n\tTenjin+DeferredDeeplinkDelegate::Invoke(this.callback, v61);\n\treturn;\n\tv139 = new System.NullReferenceException();\nL_0120:\n\tv181 = new System.IndexOutOfRangeException();\n\tgoto L_0127;\n\tv207 = new System.NullReferenceException();\n\tv231 = new System.ArrayTypeMismatchException();\nL_0127:\n\tthrow v279;\n// 219 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onSuccess(bool clickedTenjinLink, bool isFirstSession, AndroidJavaObject data)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			object[] array = new object[1];
			if ("ad_network" != null)
			{
				object obj = "ad_network" as object;
			}
			if (array.Length != 0)
			{
				array[0] = "ad_network";
				string value = data.Call<string>("get", array);
				object[] array2 = new object[1];
				if ("campaign_id" != null)
				{
					object obj2 = "campaign_id" as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = "campaign_id";
					string value2 = data.Call<string>("get", array2);
					object[] array3 = new object[1];
					if ("advertising_id" != null)
					{
						object obj3 = "advertising_id" as object;
					}
					if (array3.Length != 0)
					{
						array3[0] = "advertising_id";
						string value3 = data.Call<string>("get", array3);
						object[] array4 = new object[1];
						if ("deferred_deeplink_url" != null)
						{
							object obj4 = "deferred_deeplink_url" as object;
						}
						if (array4.Length != 0)
						{
							array4[0] = "deferred_deeplink_url";
							string value4 = data.Call<string>("get", array4);
							if (!string.IsNullOrEmpty(value))
							{
								dictionary.set_Item("ad_network", value);
							}
							if (!string.IsNullOrEmpty(value2))
							{
								dictionary.set_Item("campaign_id", value2);
							}
							if (!string.IsNullOrEmpty(value3))
							{
								dictionary.set_Item("advertising_id", value3);
							}
							if (!string.IsNullOrEmpty(value4))
							{
								dictionary.set_Item("deferred_deeplink_url", value4);
							}
							string value5 = Convert.ToString(clickedTenjinLink);
							dictionary.Add("clicked_tenjin_link", value5);
							string value6 = Convert.ToString(isFirstSession);
							dictionary.Add("is_first_session", value6);
							callback(dictionary);
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}

	[Token(Token = "0x4000001")]
	private const string AndroidJavaTenjinClass = "com.tenjin.android.TenjinSDK";

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x30")]
	private AndroidJavaObject tenjinJava;

	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x38")]
	private AndroidJavaObject activity;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x165C6D8", Offset = "0x165C6D8", Length = "0x1EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC5738]);\n\tv27 = *([v26 @ X8_v38]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, apiKey, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202AF37]) = v45;\nL_001D:\n\tgoto L_0024;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0024;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, apiKey, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0024:\n\tv60 = UnityEngine.Debug::get_isDebugBuild();\n\tv62 = v60 == 0;\n\tif (v62) goto L_0038;\n\tgoto L_0036;\n\tv76 = *([v63 @ X0_v36+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0036;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v63, apiKey, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0036:\n\tUnityEngine.Debug::Log(\"Android Initializing\");\nL_0038:\n\tthis.apiKey = apiKey;\n\tAndroidTenjin::initActivity(this);\n\tv86 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v86, \"com.tenjin.android.TenjinSDK\");\n\tv92 = v86 == 0;\n\tif (v92) goto L_008F;\n\t// 74 NewArr v97 @ X0_v20 (System.Object[]), typeof(System.Object[]), 2\n\tv152 = this.activity == 0;\n\tif (v152) goto L_0057;\n\t// 84 IsInst v182 @ X0_v34, typeof(System.Object), this.activity (UnityEngine.AndroidJavaObject)\nL_0057:\n\tv218 = v97.Length;\n\tv189 = v97.Length == 0;\n\tif (v189) goto L_0084;\n\tv97[0] = this.activity;\n\tv192 = apiKey == 0;\n\tif (v192) goto L_0064;\n\t// 96 IsInst v260 @ X0_v32, typeof(System.Object), apiKey @ X1 (System.String)\n\tv218 = v97.Length;\nL_0064:\n\tv268 = v218 < 1;\n\tv210 = ~v268;\n\tv208 = v218 - 1;\n\tv204 = v208 == 0;\n\tv269 = ~v210;\n\tv194 = v269 | v204;\n\tif (v194) goto L_0084;\n\tv97[1] = apiKey;\n\tv245 = UnityEngine.AndroidJavaObject::CallStatic(v86, \"getInstance\", v97);\n\tthis.tenjinJava = v245;\n\treturn;\nL_0084:\n\tv219 = new System.IndexOutOfRangeException();\n\tgoto L_0089;\n\tv265 = new System.ArrayTypeMismatchException();\nL_0089:\n\tthrow v271;\nL_008F:\n\tv144 = System.String::Format(\"AndroidTenjin failed to load {0} class\", *([v129 @ X22_v4 (System.String)]));\n\tv151 = new UnityEngine.MissingReferenceException();\n\tUnityEngine.MissingReferenceException::.ctor(v151, v144);\n\tthrow v151;\n\tthrow System.NullReferenceException;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Init(string apiKey)
	{
		//IL_00db: Expected O, but got I4
		//IL_01ea: Expected O, but got I
		//IL_0147: Expected O, but got I4
		if (Debug.isDebugBuild)
		{
			Debug.Log("Android Initializing");
		}
		ApiKey = apiKey;
		initActivity();
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.tenjin.android.TenjinSDK");
		bool flag = androidJavaClass == null;
		string arg = "com.tenjin.android.TenjinSDK";
		if (!flag)
		{
			object[] array = new object[2];
			if (activity != null)
			{
				object obj = activity as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = activity;
				if (apiKey != null)
				{
					object obj3 = apiKey as object;
					obj2 = array.Length;
				}
				bool flag2 = (long)(IntPtr)obj2 < 1L;
				bool flag3 = !flag2;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag4 = obj4 == null;
				bool flag5 = !flag3;
				if (!(flag5 || flag4))
				{
					array[1] = apiKey;
					AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", array);
					tenjinJava = androidJavaObject;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
		string message = $"AndroidTenjin failed to load {arg} class";
		MissingReferenceException ex3 = new MissingReferenceException(message);
		throw ex3;
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x165C95C", Offset = "0x165C95C", Length = "0x218")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EBFF28]);\n\tv31 = *([v30 @ X8_v41]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, apiKey, sharedSecret, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202AF38]) = v48;\nL_001F:\n\tgoto L_0026;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0026;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, apiKey, sharedSecret, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0026:\n\tv63 = UnityEngine.Debug::get_isDebugBuild();\n\tv65 = v63 == 0;\n\tif (v65) goto L_003A;\n\tgoto L_0038;\n\tv79 = *([v66 @ X0_v39+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0038;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v66, apiKey, sharedSecret, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0038:\n\tUnityEngine.Debug::Log(\"Android Initializing with Shared Secret\");\nL_003A:\n\tthis.apiKey = apiKey;\n\tthis.sharedSecret = sharedSecret;\n\tAndroidTenjin::initActivity(this);\n\tv89 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v89, \"com.tenjin.android.TenjinSDK\");\n\tv95 = v89 == 0;\n\tif (v95) goto L_00A9;\n\t// 77 NewArr v100 @ X0_v20 (System.Object[]), typeof(System.Object[]), 3\n\tv155 = this.activity == 0;\n\tif (v155) goto L_005A;\n\t// 87 IsInst v185 @ X0_v37, typeof(System.Object), this.activity (UnityEngine.AndroidJavaObject)\nL_005A:\n\tv234 = v100.Length;\n\tv192 = v100.Length == 0;\n\tif (v192) goto L_009E;\n\tv100[0] = this.activity;\n\tv195 = apiKey == 0;\n\tif (v195) goto L_0067;\n\t// 99 IsInst v288 @ X0_v35, typeof(System.Object), apiKey @ X1 (System.String)\n\tv234 = v100.Length;\nL_0067:\n\tv299 = v234 < 1;\n\tv221 = ~v299;\n\tv218 = v234 - 1;\n\tv212 = v218 == 0;\n\tv300 = ~v221;\n\tv197 = v300 | v212;\n\tif (v197) goto L_009E;\n\tv100[1] = apiKey;\n\tv303 = sharedSecret == 0;\n\tif (v303) goto L_007D;\n\t// 121 IsInst v289 @ X0_v33, typeof(System.Object), sharedSecret @ X2 (System.String)\n\tv234 = v100.Length;\nL_007D:\n\tv306 = v234 < 2;\n\tv222 = ~v306;\n\tv219 = v234 - 2;\n\tv213 = v219 == 0;\n\tv307 = ~v222;\n\tv198 = v307 | v213;\n\tif (v198) goto L_009E;\n\tv100[2] = sharedSecret;\n\tv261 = UnityEngine.AndroidJavaObject::CallStatic(v89, \"getInstanceWithSharedSecret\", v100);\n\tthis.tenjinJava = v261;\n\treturn;\nL_009E:\n\tv235 = new System.IndexOutOfRangeException();\n\tgoto L_00A3;\n\tv296 = new System.ArrayTypeMismatchException();\nL_00A3:\n\tthrow v302;\nL_00A9:\n\tv147 = System.String::Format(\"AndroidTenjin failed to load {0} class\", *([v132 @ X23_v4 (System.String)]));\n\tv154 = new UnityEngine.MissingReferenceException();\n\tUnityEngine.MissingReferenceException::.ctor(v154, v147);\n\tthrow v154;\n\tthrow System.NullReferenceException;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void InitWithSharedSecret(string apiKey, string sharedSecret)
	{
		//IL_00e5: Expected O, but got I4
		//IL_0244: Expected O, but got I
		//IL_0151: Expected O, but got I4
		//IL_02a2: Expected O, but got I
		//IL_01a1: Expected O, but got I4
		if (Debug.isDebugBuild)
		{
			Debug.Log("Android Initializing with Shared Secret");
		}
		ApiKey = apiKey;
		SharedSecret = sharedSecret;
		initActivity();
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.tenjin.android.TenjinSDK");
		bool flag = androidJavaClass == null;
		string arg = "com.tenjin.android.TenjinSDK";
		if (!flag)
		{
			object[] array = new object[3];
			if (activity != null)
			{
				object obj = activity as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = activity;
				if (apiKey != null)
				{
					object obj3 = apiKey as object;
					obj2 = array.Length;
				}
				bool flag2 = (long)(IntPtr)obj2 < 1L;
				bool flag3 = !flag2;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag4 = obj4 == null;
				bool flag5 = !flag3;
				if (!(flag5 || flag4))
				{
					array[1] = apiKey;
					if (sharedSecret != null)
					{
						object obj5 = sharedSecret as object;
						obj2 = array.Length;
					}
					bool flag6 = (long)(IntPtr)obj2 < 2L;
					bool flag7 = !flag6;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag8 = obj6 == null;
					bool flag9 = !flag7;
					if (!(flag9 || flag8))
					{
						array[2] = sharedSecret;
						AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstanceWithSharedSecret", array);
						tenjinJava = androidJavaObject;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
		string message = $"AndroidTenjin failed to load {arg} class";
		MissingReferenceException ex3 = new MissingReferenceException(message);
		throw ex3;
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x165CB74", Offset = "0x165CB74", Length = "0x2B8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EFE100]);\n\tv33 = *([v32 @ X8_v45]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, apiKey, appSubversion, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202AF39]) = v50;\nL_0020:\n\tgoto L_0027;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, apiKey, appSubversion, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0027:\n\tv65 = UnityEngine.Debug::get_isDebugBuild();\n\tv67 = v65 == 0;\n\tif (v67) goto L_003B;\n\tgoto L_0039;\n\tv81 = *([v68 @ X0_v52+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0039;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v68, apiKey, appSubversion, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0039:\n\tUnityEngine.Debug::Log(\"Android Initializing with Subversion\");\nL_003B:\n\tthis.apiKey = apiKey;\n\tthis.appSubversion = appSubversion;\n\tAndroidTenjin::initActivity(this);\n\tv91 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v91, \"com.tenjin.android.TenjinSDK\");\n\tv97 = v91 == 0;\n\tif (v97) goto L_00D5;\n\t// 78 NewArr v102 @ X0_v20 (System.Object[]), typeof(System.Object[]), 3\n\tv176 = this.activity == 0;\n\tif (v176) goto L_005B;\n\t// 88 IsInst v212 @ X0_v50, typeof(System.Object), this.activity (UnityEngine.AndroidJavaObject)\nL_005B:\n\tv284 = v102.Length;\n\tv219 = v102.Length == 0;\n\tif (v219) goto L_00C8;\n\tv102[0] = this.activity;\n\tv222 = apiKey == 0;\n\tif (v222) goto L_0068;\n\t// 100 IsInst v348 @ X0_v48, typeof(System.Object), apiKey @ X1 (System.String)\n\tv284 = v102.Length;\nL_0068:\n\tv365 = v284 < 1;\n\tv255 = ~v365;\n\tv252 = v284 - 1;\n\tv246 = v252 == 0;\n\tv366 = ~v255;\n\tv231 = v366 | v246;\n\tif (v231) goto L_00C8;\n\tv102[1] = apiKey;\n\t// 122 Box v395 @ X0_v33, typeof(System.Int32), &appSubversion @ X2 (System.Int32)\n\tv402 = v395 == 0;\n\tif (v402) goto L_0085;\n\t// 129 IsInst v349 @ X0_v46, typeof(System.Object), v395 @ X0_v33\nL_0085:\n\tv405 = v102.Length < 2;\n\tv254 = ~v405;\n\tv251 = v102.Length - 2;\n\tv245 = v251 == 0;\n\tv406 = ~v254;\n\tv230 = v406 | v245;\n\tif (v230) goto L_00C8;\n\tv102[2] = v395;\n\tv411 = UnityEngine.AndroidJavaObject::CallStatic(v91, \"getInstanceWithAppSubversion\", v102);\n\tthis.tenjinJava = v411;\n\t// 159 NewArr v414 @ X0_v38 (System.Object[]), typeof(System.Object[]), 1\n\t// 164 Box v398 @ X0_v40, typeof(System.Int32), &appSubversion @ X2 (System.Int32)\n\tv416 = v398 == 0;\n\tif (v416) goto L_00B1;\n\t// 173 IsInst v350 @ X0_v44, typeof(System.Object), v398 @ X0_v40\nL_00B1:\n\tv272 = v414.Length == 0;\n\tif (v272) goto L_00C8;\n\tv414[0] = v398;\n\tUnityEngine.AndroidJavaObject::Call(v411, \"appendAppSubversion\", v414);\n\treturn;\nL_00C8:\n\tv285 = new System.IndexOutOfRangeException();\n\tgoto L_00CD;\n\tv362 = new System.ArrayTypeMismatchException();\nL_00CD:\n\tthrow v383;\n\tthrow System.NullReferenceException;\nL_00D5:\n\tv167 = System.String::Format(\"AndroidTenjin failed to load {0} class\", *([v146 @ X23_v4 (System.String)]));\n\tv174 = new UnityEngine.MissingReferenceException();\n\tUnityEngine.MissingReferenceException::.ctor(v174, v167);\n\tthrow v174;\n\tthrow System.NullReferenceException;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void InitWithAppSubversion(string apiKey, int appSubversion)
	{
		//IL_00e5: Expected O, but got I4
		//IL_033f: Expected O, but got I
		//IL_0151: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		if (Debug.isDebugBuild)
		{
			Debug.Log("Android Initializing with Subversion");
		}
		ApiKey = apiKey;
		AppSubversion = appSubversion;
		initActivity();
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.tenjin.android.TenjinSDK");
		bool flag = androidJavaClass == null;
		string arg = "com.tenjin.android.TenjinSDK";
		if (!flag)
		{
			object[] array = new object[3];
			if (activity != null)
			{
				object obj = activity as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = activity;
				if (apiKey != null)
				{
					object obj3 = apiKey as object;
					obj2 = array.Length;
				}
				bool flag2 = (long)(IntPtr)obj2 < 1L;
				bool flag3 = !flag2;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag4 = obj4 == null;
				bool flag5 = !flag3;
				if (!(flag5 || flag4))
				{
					array[1] = apiKey;
					object obj5 = appSubversion;
					if (obj5 != null)
					{
						object obj6 = obj5 as object;
					}
					bool flag6 = array.Length < 2;
					bool flag7 = !flag6;
					object obj7 = array.Length - 2;
					bool flag8 = obj7 == null;
					bool flag9 = !flag7;
					if (!(flag9 || flag8))
					{
						array[2] = obj5;
						AndroidJavaObject androidJavaObject = (tenjinJava = androidJavaClass.CallStatic<AndroidJavaObject>("getInstanceWithAppSubversion", array));
						object[] array2 = new object[1];
						object obj8 = appSubversion;
						if (obj8 != null)
						{
							object obj9 = obj8 as object;
						}
						if (array2.Length != 0)
						{
							array2[0] = obj8;
							androidJavaObject.Call("appendAppSubversion", array2);
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
		string message = $"AndroidTenjin failed to load {arg} class";
		MissingReferenceException ex3 = new MissingReferenceException(message);
		throw ex3;
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x165CE2C", Offset = "0x165CE2C", Length = "0x2EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EDFFA8]);\n\tv37 = *([v36 @ X8_v48]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, apiKey, sharedSecret, appSubversion, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202AF3A]) = v53;\nL_0022:\n\tgoto L_0029;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, apiKey, sharedSecret, appSubversion, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0029:\n\tv68 = UnityEngine.Debug::get_isDebugBuild();\n\tv70 = v68 == 0;\n\tif (v70) goto L_003D;\n\tgoto L_003B;\n\tv84 = *([v71 @ X0_v55+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_003B;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v71, apiKey, sharedSecret, appSubversion, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_003B:\n\tUnityEngine.Debug::Log(\"Android Initializing with Subversion\");\nL_003D:\n\tthis.apiKey = apiKey;\n\tthis.sharedSecret = sharedSecret;\n\tthis.appSubversion = appSubversion;\n\tAndroidTenjin::initActivity(this);\n\tv94 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v94, \"com.tenjin.android.TenjinSDK\");\n\tv100 = v94 == 0;\n\tif (v100) goto L_00EF;\n\t// 81 NewArr v105 @ X0_v20 (System.Object[]), typeof(System.Object[]), 4\n\tv180 = this.activity == 0;\n\tif (v180) goto L_005E;\n\t// 91 IsInst v217 @ X0_v53, typeof(System.Object), this.activity (UnityEngine.AndroidJavaObject)\nL_005E:\n\tv302 = v105.Length;\n\tv224 = v105.Length == 0;\n\tif (v224) goto L_00E2;\n\tv105[0] = this.activity;\n\tv227 = apiKey == 0;\n\tif (v227) goto L_006B;\n\t// 103 IsInst v368 @ X0_v51, typeof(System.Object), apiKey @ X1 (System.String)\n\tv302 = v105.Length;\nL_006B:\n\tv389 = v302 < 1;\n\tv268 = ~v389;\n\tv264 = v302 - 1;\n\tv256 = v264 == 0;\n\tv390 = ~v268;\n\tv236 = v390 | v256;\n\tif (v236) goto L_00E2;\n\tv105[1] = apiKey;\n\tv416 = sharedSecret == 0;\n\tif (v416) goto L_0081;\n\t// 125 IsInst v369 @ X0_v49, typeof(System.Object), sharedSecret @ X2 (System.String)\n\tv302 = v105.Length;\nL_0081:\n\tv425 = v302 < 2;\n\tv269 = ~v425;\n\tv265 = v302 - 2;\n\tv257 = v265 == 0;\n\tv426 = ~v269;\n\tv237 = v426 | v257;\n\tif (v237) goto L_00E2;\n\tv105[2] = sharedSecret;\n\t// 147 Box v430 @ X0_v34, typeof(System.Int32), &appSubversion @ X3 (System.Int32)\n\tv431 = v430 == 0;\n\tif (v431) goto L_009E;\n\t// 154 IsInst v370 @ X0_v47, typeof(System.Object), v430 @ X0_v34\nL_009E:\n\tv434 = v105.Length < 3;\n\tv267 = ~v434;\n\tv263 = v105.Length - 3;\n\tv255 = v263 == 0;\n\tv435 = ~v267;\n\tv235 = v435 | v255;\n\tif (v235) goto L_00E2;\n\tv105[3] = v430;\n\tv440 = UnityEngine.AndroidJavaObject::CallStatic(v94, \"getInstanceWithSharedSecretAppSubversion\", v105);\n\tthis.tenjinJava = v440;\n\t// 184 NewArr v443 @ X0_v39 (System.Object[]), typeof(System.Object[]), 1\n\t// 189 Box v419 @ X0_v41, typeof(System.Int32), &appSubversion @ X3 (System.Int32)\n\tv445 = v419 == 0;\n\tif (v445) goto L_00CA;\n\t// 198 IsInst v371 @ X0_v45, typeof(System.Object), v419 @ X0_v41\nL_00CA:\n\tv286 = v443.Length == 0;\n\tif (v286) goto L_00E2;\n\tv443[0] = v419;\n\tUnityEngine.AndroidJavaObject::Call(v440, \"appendAppSubversion\", v443);\n\treturn;\nL_00E2:\n\tv303 = new System.IndexOutOfRangeException();\n\tgoto L_00E7;\n\tv386 = new System.ArrayTypeMismatchException();\nL_00E7:\n\tthrow v406;\n\tthrow System.NullReferenceException;\nL_00EF:\n\tv172 = System.String::Format(\"AndroidTenjin failed to load {0} class\", *([v149 @ X24_v4 (System.String)]));\n\tv179 = new UnityEngine.MissingReferenceException();\n\tUnityEngine.MissingReferenceException::.ctor(v179, v172);\n\tthrow v179;\n\tthrow System.NullReferenceException;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void InitWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion)
	{
		//IL_00ef: Expected O, but got I4
		//IL_0399: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_03f7: Expected O, but got I
		//IL_01ab: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		if (Debug.isDebugBuild)
		{
			Debug.Log("Android Initializing with Subversion");
		}
		ApiKey = apiKey;
		SharedSecret = sharedSecret;
		AppSubversion = appSubversion;
		initActivity();
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.tenjin.android.TenjinSDK");
		bool flag = androidJavaClass == null;
		string arg = "com.tenjin.android.TenjinSDK";
		if (!flag)
		{
			object[] array = new object[4];
			if (activity != null)
			{
				object obj = activity as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = activity;
				if (apiKey != null)
				{
					object obj3 = apiKey as object;
					obj2 = array.Length;
				}
				bool flag2 = (long)(IntPtr)obj2 < 1L;
				bool flag3 = !flag2;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag4 = obj4 == null;
				bool flag5 = !flag3;
				if (!(flag5 || flag4))
				{
					array[1] = apiKey;
					if (sharedSecret != null)
					{
						object obj5 = sharedSecret as object;
						obj2 = array.Length;
					}
					bool flag6 = (long)(IntPtr)obj2 < 2L;
					bool flag7 = !flag6;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag8 = obj6 == null;
					bool flag9 = !flag7;
					if (!(flag9 || flag8))
					{
						array[2] = sharedSecret;
						object obj7 = appSubversion;
						if (obj7 != null)
						{
							object obj8 = obj7 as object;
						}
						bool flag10 = array.Length < 3;
						bool flag11 = !flag10;
						object obj9 = array.Length - 3;
						bool flag12 = obj9 == null;
						bool flag13 = !flag11;
						if (!(flag13 || flag12))
						{
							array[3] = obj7;
							AndroidJavaObject androidJavaObject = (tenjinJava = androidJavaClass.CallStatic<AndroidJavaObject>("getInstanceWithSharedSecretAppSubversion", array));
							object[] array2 = new object[1];
							object obj10 = appSubversion;
							if (obj10 != null)
							{
								object obj11 = obj10 as object;
							}
							if (array2.Length != 0)
							{
								array2[0] = obj10;
								androidJavaObject.Call("appendAppSubversion", array2);
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
		string message = $"AndroidTenjin failed to load {arg} class";
		MissingReferenceException ex3 = new MissingReferenceException(message);
		throw ex3;
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x165C8C4", Offset = "0x165C8C4", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC5608]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AF3B]) = v38;\nL_0016:\n\tv42 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v42, \"com.unity3d.player.UnityPlayer\");\n\tv56 = UnityEngine.AndroidJavaObject::GetStatic(v42, \"currentActivity\");\n\tthis.activity = v56;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void initActivity()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		activity = androidJavaObject;
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x165D118", Offset = "0x165D118", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EBF148]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF3C]) = v40;\nL_0015:\n\tv42 = ~this.optIn;\n\tif (v42) goto L_001B;\n\tgoto L_001F;\nL_001B:\n\tv46 = ~this.optOut;\n\tif (v46) goto L_FFFFFFFF;\nL_001F:\n\tv55 = *([v48 @ X8_v16 (System.String)]);\nL_0024:\n\t// 36 NewArr v60 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv63 = v55 == 0;\n\tif (v63) goto L_0031;\n\t// 45 IsInst v103 @ X0_v13, typeof(System.Object), v55 @ X20_v2 (Il2CppClass<System.String>)\nL_0031:\n\tv108 = v60.Length < 1;\n\tv90 = ~v108;\n\tv87 = v60.Length - 1;\n\tv81 = v87 == 0;\n\tv109 = ~v90;\n\tv66 = v109 | v81;\n\tif (v66) goto L_0051;\n\tv60[1] = v55;\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"connect\", v60);\n\treturn;\n\tgoto L_0024;\n\tv99 = new System.NullReferenceException();\nL_0051:\n\tv123 = new System.IndexOutOfRangeException();\n\tgoto L_0056;\n\tv124 = new System.ArrayTypeMismatchException();\nL_0056:\n\tthrow v145;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Connect()
	{
		//IL_00fd: Expected I, but got O
		//IL_0138: Expected I, but got O
		//IL_0097: Expected O, but got I4
		//IL_0062: Expected O, but got I
		//IL_00de: Expected O, but got I
		string text;
		IntPtr intPtr;
		if (optIn)
		{
			text = "optin";
		}
		else
		{
			if (!optOut)
			{
				intPtr = (IntPtr)null;
				goto IL_013d;
			}
			text = "optout";
		}
		intPtr = (IntPtr)text;
		goto IL_013d;
		IL_013d:
		object[] array = new object[2];
		if (intPtr != (IntPtr)0)
		{
			object obj = ((long)intPtr) as object;
		}
		bool flag = array.Length < 1;
		bool flag2 = !flag;
		object obj2 = array.Length - 1;
		bool flag3 = obj2 == null;
		bool flag4 = !flag2;
		if (!(flag4 || flag3))
		{
			array[1] = (long)intPtr;
			tenjinJava.Call("connect", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x165D20C", Offset = "0x165D20C", Length = "0x11C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB6870]);\n\tv25 = *([v24 @ X8_v27]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, deferredDeeplink, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202AF3D]) = v43;\nL_0017:\n\tv45 = ~this.optIn;\n\tif (v45) goto L_001D;\n\tgoto L_0021;\nL_001D:\n\tv49 = ~this.optOut;\n\tif (v49) goto L_FFFFFFFF;\nL_0021:\n\tv58 = *([v51 @ X8_v20 (System.String)]);\nL_0026:\n\t// 38 NewArr v63 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv66 = deferredDeeplink == 0;\n\tif (v66) goto L_0032;\n\t// 47 IsInst v106 @ X0_v18, typeof(System.Object), deferredDeeplink @ X1 (System.String)\nL_0032:\n\tv101 = v63.Length;\n\tv113 = v63.Length == 0;\n\tif (v113) goto L_005F;\n\tv63[0] = deferredDeeplink;\n\tv132 = v58 == 0;\n\tif (v132) goto L_003F;\n\t// 59 IsInst v126 @ X0_v16, typeof(System.Object), v58 @ X21_v2 (Il2CppClass<System.String>)\n\tv101 = v63.Length;\nL_003F:\n\tv167 = v101 < 1;\n\tv93 = ~v167;\n\tv90 = v101 - 1;\n\tv84 = v90 == 0;\n\tv168 = ~v93;\n\tv69 = v168 | v84;\n\tif (v69) goto L_005F;\n\tv63[1] = v58;\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"connect\", v63);\n\treturn;\n\tgoto L_0026;\nL_005F:\n\tv148 = new System.IndexOutOfRangeException();\n\tgoto L_0065;\n\tv102 = new System.NullReferenceException();\n\tv131 = new System.ArrayTypeMismatchException();\nL_0065:\n\tthrow v159;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Connect(string deferredDeeplink)
	{
		//IL_0115: Expected I, but got O
		//IL_0150: Expected I, but got O
		//IL_0075: Expected O, but got I4
		//IL_017e: Expected O, but got I
		//IL_00cc: Expected O, but got I
		//IL_00f6: Expected O, but got I
		//IL_00df: Expected O, but got I4
		string text;
		IntPtr intPtr;
		if (optIn)
		{
			text = "optin";
		}
		else
		{
			if (!optOut)
			{
				intPtr = (IntPtr)null;
				goto IL_01b3;
			}
			text = "optout";
		}
		intPtr = (IntPtr)text;
		goto IL_01b3;
		IL_01b3:
		object[] array = new object[2];
		if (deferredDeeplink != null)
		{
			object obj = deferredDeeplink as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = deferredDeeplink;
			if (intPtr != (IntPtr)0)
			{
				object obj3 = ((long)intPtr) as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = (long)intPtr;
				tenjinJava.Call("connect", array);
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0x165D328", Offset = "0x165D328", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC5108]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF3E]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv49 = eventName == 0;\n\tif (v49) goto L_0026;\n\t// 34 IsInst v62 @ X0_v13, typeof(System.Object), eventName @ X1 (System.String)\nL_0026:\n\tv67 = v46.Length == 0;\n\tif (v67) goto L_003A;\n\tv46[0] = eventName;\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"eventWithName\", v46);\n\treturn;\n\tv58 = new System.NullReferenceException();\nL_003A:\n\tv72 = new System.IndexOutOfRangeException();\n\tgoto L_003F;\n\tv73 = new System.ArrayTypeMismatchException();\nL_003F:\n\tthrow v85;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SendEvent(string eventName)
	{
		object[] array = new object[1];
		if (eventName != null)
		{
			object obj = eventName as object;
		}
		if (array.Length != 0)
		{
			array[0] = eventName;
			tenjinJava.Call("eventWithName", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x165D3EC", Offset = "0x165D3EC", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EFF510]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, eventName, eventValue, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AF3F]) = v44;\nL_001B:\n\t// 27 NewArr v49 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv52 = eventName == 0;\n\tif (v52) goto L_0027;\n\t// 36 IsInst v92 @ X0_v18, typeof(System.Object), eventName @ X1 (System.String)\nL_0027:\n\tv87 = v49.Length;\n\tv99 = v49.Length == 0;\n\tif (v99) goto L_0052;\n\tv49[0] = eventName;\n\tv118 = eventValue == 0;\n\tif (v118) goto L_0034;\n\t// 48 IsInst v112 @ X0_v16, typeof(System.Object), eventValue @ X2 (System.String)\n\tv87 = v49.Length;\nL_0034:\n\tv153 = v87 < 1;\n\tv79 = ~v153;\n\tv76 = v87 - 1;\n\tv70 = v76 == 0;\n\tv154 = ~v79;\n\tv55 = v154 | v70;\n\tif (v55) goto L_0052;\n\tv49[1] = eventValue;\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"eventWithNameAndValue\", v49);\n\treturn;\nL_0052:\n\tv134 = new System.IndexOutOfRangeException();\n\tgoto L_0058;\n\tv88 = new System.NullReferenceException();\n\tv117 = new System.ArrayTypeMismatchException();\nL_0058:\n\tthrow v145;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SendEvent(string eventName, string eventValue)
	{
		//IL_003e: Expected O, but got I4
		//IL_0128: Expected O, but got I
		//IL_00a8: Expected O, but got I4
		object[] array = new object[2];
		if (eventName != null)
		{
			object obj = eventName as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = eventName;
			if (eventValue != null)
			{
				object obj3 = eventValue as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = eventValue;
				tenjinJava.Call("eventWithNameAndValue", array);
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x165D4DC", Offset = "0x165D4DC", Length = "0x76C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv48 = *([1EB2460]);\n\tv49 = *([v48 @ X8_v119]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, productId, currencyCode, quantity, transactionId, receipt, signature, methodInfo, unitPrice, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([202AF40]) = v62;\nL_0025:\n\tv66 = receipt == 0;\n\tif (v66) goto L_01E1;\n\tv67 = signature == 0;\n\tif (v67) goto L_01E1;\n\t// 42 NewArr v72 @ X0_v72 (System.Object[]), typeof(System.Object[]), 6\n\tv201 = productId == 0;\n\tif (v201) goto L_0036;\n\t// 51 IsInst v216 @ X0_v139, typeof(System.Object), productId @ X1 (System.String)\nL_0036:\n\tv584 = v72.Length;\n\tv223 = v72.Length == 0;\n\tif (v223) goto L_033A;\n\tv72[0] = productId;\n\tv648 = currencyCode == 0;\n\tif (v648) goto L_0043;\n\t// 63 IsInst v690 @ X0_v137, typeof(System.Object), currencyCode @ X2 (System.String)\n\tv584 = v72.Length;\nL_0043:\n\tv780 = v584 < 1;\n\tv449 = ~v780;\n\tv424 = v584 - 1;\n\tv374 = v424 == 0;\n\tv781 = ~v449;\n\tv249 = v781 | v374;\n\tif (v249) goto L_033A;\n\tv72[1] = currencyCode;\n\t// 85 Box v791 @ X0_v76, typeof(System.Int32), &quantity @ X3 (System.Int32)\n\tv793 = v791 == 0;\n\tif (v793) goto L_0060;\n\t// 92 IsInst v691 @ X0_v135, typeof(System.Object), v791 @ X0_v76\nL_0060:\n\tv800 = v72.Length < 2;\n\tv439 = ~v800;\n\tv414 = v72.Length - 2;\n\tv364 = v414 == 0;\n\tv801 = ~v439;\n\tv239 = v801 | v364;\n\tif (v239) goto L_033A;\n\tv72[2] = v791;\n\t// 114 Box v810 @ X0_v79, typeof(System.Double), &unitPrice @ V0 (System.Double)\n\tv812 = v810 == 0;\n\tif (v812) goto L_007D;\n\t// 121 IsInst v692 @ X0_v133, typeof(System.Object), v810 @ X0_v79\nL_007D:\n\tv819 = v72.Length < 3;\n\tv440 = ~v819;\n\tv415 = v72.Length - 3;\n\tv365 = v415 == 0;\n\tv820 = ~v440;\n\tv240 = v820 | v365;\n\tif (v240) goto L_033A;\n\tv72[3] = v810;\n\t// 141 IsInst v502 @ X0_v82, typeof(System.Object), receipt @ X5 (System.String)\n\tv837 = v72.Length < 4;\n\tv441 = ~v837;\n\tv416 = v72.Length - 4;\n\tv366 = v416 == 0;\n\tv838 = ~v441;\n\tv241 = v838 | v366;\n\tif (v241) goto L_033A;\n\tv72[4] = receipt;\n\t// 161 IsInst v503 @ X0_v84, typeof(System.Object), signature @ X6 (System.String)\n\tv873 = v72.Length < 5;\n\tv144 = ~v873;\n\tv138 = v72.Length - 5;\n\tv126 = v138 == 0;\n\tv874 = ~v144;\n\tv96 = v874 | v126;\n\tif (v96) goto L_033A;\n\tv72[5] = signature;\n\tgoto L_00BF;\n\tv884 = *([v879 @ X0_v85+E0]);\n\tv885 = v884 == 0;\n\tv886 = ~v885;\n\tif (v886) goto L_00BF;\n\tv888 = \"il2cpp_codegen_runtime_class_init\"(v879, v474, currencyCode, quantity, transactionId, receipt, signature, methodInfo, unitPrice, v53, v54, v55, v56, v57, v58, v59);\nL_00BF:\n\tv858 = UnityEngine.Debug::get_isDebugBuild();\n\tv861 = v858 == 0;\n\tif (v861) goto L_032A;\n\t// 197 NewArr v170 @ X0_v90 (System.Object[]), typeof(System.Object[]), 12\n\tv906 = \"Android Transaction \" == 0;\n\tif (v906) goto L_00D3;\n\t// 208 IsInst v693 @ X0_v130, typeof(System.Object), \"Android Transaction \"\nL_00D3:\n\tv588 = v170.Length;\n\tv533 = v170.Length == 0;\n\tif (v533) goto L_033A;\n\tv170[0] = \"Android Transaction \";\n\tv915 = productId == 0;\n\tif (v915) goto L_00E1;\n\t// 221 IsInst v694 @ X0_v129, typeof(System.Object), productId @ X1 (System.String)\n\tv588 = v170.Length;\nL_00E1:\n\tv921 = v588 < 1;\n\tv450 = ~v921;\n\tv425 = v588 - 1;\n\tv375 = v425 == 0;\n\tv922 = ~v450;\n\tv250 = v922 | v375;\n\tif (v250) goto L_033A;\n\tv170[1] = productId;\n\tv929 = \", \" == 0;\n\tif (v929) goto L_00F9;\n\t// 245 IsInst v695 @ X0_v127, typeof(System.Object), \", \"\n\tv588 = v170.Length;\nL_00F9:\n\tv932 = v588 < 2;\n\tv451 = ~v932;\n\tv426 = v588 - 2;\n\tv376 = v426 == 0;\n\tv933 = ~v451;\n\tv251 = v933 | v376;\n\tif (v251) goto L_033A;\n\tv170[2] = \", \";\n\tv938 = currencyCode == 0;\n\tif (v938) goto L_0110;\n\t// 268 IsInst v696 @ X0_v126, typeof(System.Object), currencyCode @ X2 (System.String)\n\tv588 = v170.Length;\nL_0110:\n\tv943 = v588 < 3;\n\tv452 = ~v943;\n\tv427 = v588 - 3;\n\tv377 = v427 == 0;\n\tv944 = ~v452;\n\tv252 = v944 | v377;\n\tif (v252) goto L_033A;\n\tv170[3] = currencyCode;\n\tv949 = \", \" == 0;\n\tif (v949) goto L_0126;\n\t// 290 IsInst v697 @ X0_v124, typeof(System.Object), \", \"\n\tv588 = v170.Length;\nL_0126:\n\tv955 = v588 < 4;\n\tv453 = ~v955;\n\tv428 = v588 - 4;\n\tv378 = v428 == 0;\n\tv956 = ~v453;\n\tv253 = v956 | v378;\n\tif (v253) goto L_033A;\n\tv170[4] = \", \";\n\t// 311 Box v961 @ X0_v100, typeof(System.Int32), &quantity @ X3 (System.Int32)\n\tv966 = v961 == 0;\n\tif (v966) goto L_0141;\n\t// 318 IsInst v698 @ X0_v123, typeof(System.Object), v961 @ X0_v100\nL_0141:\n\tv589 = v170.Length;\n\tv972 = v170.Length < 5;\n\tv442 = ~v972;\n\tv417 = v170.Length - 5;\n\tv367 = v417 == 0;\n\tv973 = ~v442;\n\tv242 = v973 | v367;\n\tif (v242) goto L_033A;\n\tv170[5] = v961;\n\tv976 = \", \" == 0;\n\tif (v976) goto L_0158;\n\t// 340 IsInst v699 @ X0_v121, typeof(System.Object), \", \"\n\tv589 = v170.Length;\nL_0158:\n\tv989 = v589 < 6;\n\tv454 = ~v989;\n\tv429 = v589 - 6;\n\tv379 = v429 == 0;\n\tv990 = ~v454;\n\tv254 = v990 | v379;\n\tif (v254) goto L_033A;\n\tv170[6] = \", \";\n\t// 363 Box v1001 @ X0_v105, typeof(System.Double), &unitPrice @ V0 (System.Double)\n\tv1003 = v1001 == 0;\n\tif (v1003) goto L_0175;\n\t// 370 IsInst v700 @ X0_v120, typeof(System.Object), v1001 @ X0_v105\nL_0175:\n\tv590 = v170.Length;\n\tv1006 = v170.Length < 7;\n\tv443 = ~v1006;\n\tv418 = v170.Length - 7;\n\tv368 = v418 == 0;\n\tv1007 = ~v443;\n\tv243 = v1007 | v368;\n\tif (v243) goto L_033A;\n\tv170[7] = v1001;\n\tv1009 = \", \" == 0;\n\tif (v1009) goto L_018C;\n\t// 392 IsInst v701 @ X0_v118, typeof(System.Object), \", \"\n\tv590 = v170.Length;\nL_018C:\n\tv1011 = v590 < 8;\n\tv455 = ~v1011;\n\tv430 = v590 - 8;\n\tv380 = v430 == 0;\n\tv1012 = ~v455;\n\tv255 = v1012 | v380;\n\tif (v255) goto L_033A;\n\tv170[8] = \", \";\n\t// 413 IsInst v507 @ X0_v110, typeof(System.Object), receipt @ X5 (System.String)\n\tv591 = v170.Length;\n\tv1014 = v170.Length < 9;\n\tv444 = ~v1014;\n\tv419 = v170.Length - 9;\n\tv369 = v419 == 0;\n\tv1015 = ~v444;\n\tv244 = v1015 | v369;\n\tif (v244) goto L_033A;\n\tv170[9] = receipt;\n\tv1017 = \", \" == 0;\n\tif (v1017) goto L_01B7;\n\t// 435 IsInst v702 @ X0_v117, typeof(System.Object), \", \"\n\tv591 = v170.Length;\nL_01B7:\n\tv1019 = v591 < 0xA;\n\tv456 = ~v1019;\n\tv431 = v591 - 0xA;\n\tv381 = v431 == 0;\n\tv1020 = ~v456;\n\tv256 = v1020 | v381;\n\tif (v256) goto L_033A;\n\tv170[10] = \", \";\n\t// 456 IsInst v508 @ X0_v114, typeof(System.Object), signature @ X6 (System.String)\n\tv1022 = v170.Length < 0xB;\n\tv445 = ~v1022;\n\tv420 = v170.Length - 0xB;\n\tv370 = v420 == 0;\n\tv1023 = ~v445;\n\tv245 = v1023 | v370;\n\tif (v245) goto L_033A;\n\tv170[11] = signature;\n\tv980 = System.String::Concat(v170);\n\tgoto L_0318;\nL_01E1:\n\t// 481 NewArr v70 @ X0_v18 (System.Object[]), typeof(System.Object[]), 4\n\tv77 = productId == 0;\n\tif (v77) goto L_01ED;\n\t// 490 IsInst v205 @ X0_v71, typeof(System.Object), productId @ X1 (System.String)\nL_01ED:\n\tv592 = v70.Length;\n\tv212 = v70.Length == 0;\n\tif (v212) goto L_033A;\n\tv70[0] = productId;\n\tv224 = currencyCode == 0;\n\tif (v224) goto L_01FA;\n\t// 502 IsInst v703 @ X0_v69, typeof(System.Object), currencyCode @ X2 (System.String)\n\tv592 = v70.Length;\nL_01FA:\n\tv776 = v592 < 1;\n\tv457 = ~v776;\n\tv432 = v592 - 1;\n\tv382 = v432 == 0;\n\tv777 = ~v457;\n\tv257 = v777 | v382;\n\tif (v257) goto L_033A;\n\tv70[1] = currencyCode;\n\t// 524 Box v787 @ X0_v22, typeof(System.Int32), &quantity @ X3 (System.Int32)\n\tv792 = v787 == 0;\n\tif (v792) goto L_0217;\n\t// 531 IsInst v704 @ X0_v67, typeof(System.Object), v787 @ X0_v22\nL_0217:\n\tv796 = v70.Length < 2;\n\tv446 = ~v796;\n\tv421 = v70.Length - 2;\n\tv371 = v421 == 0;\n\tv797 = ~v446;\n\tv246 = v797 | v371;\n\tif (v246) goto L_033A;\n\tv70[2] = v787;\n\t// 553 Box v805 @ X0_v25, typeof(System.Double), &unitPrice @ V0 (System.Double)\n\tv811 = v805 == 0;\n\tif (v811) goto L_0234;\n\t// 560 IsInst v705 @ X0_v65, typeof(System.Object), v805 @ X0_v25\nL_0234:\n\tv815 = v70.Length < 3;\n\tv145 = ~v815;\n\tv139 = v70.Length - 3;\n\tv127 = v139 == 0;\n\tv816 = ~v145;\n\tv97 = v816 | v127;\n\tif (v97) goto L_033A;\n\tv70[3] = v805;\n\tgoto L_024E;\n\tv827 = *([v822 @ X0_v27+E0]);\n\tv828 = v827 == 0;\n\tv829 = ~v828;\n\tif (v829) goto L_024E;\n\tv831 = \"il2cpp_codegen_runtime_class_init\"(v822, v481, currencyCode, quantity, transactionId, receipt, signature, methodInfo, unitPrice, v53, v54, v55, v56, v57, v58, v59);\nL_024E:\n\tv834 = UnityEngine.Debug::get_isDebugBuild();\n\tv836 = v834 == 0;\n\tif (v836) goto L_032A;\n\t// 596 NewArr v171 @ X0_v32 (System.Object[]), typeof(System.Object[]), 8\n\tv872 = \"Android Tra\n// ... truncated")]
	public override void Transaction(string productId, string currencyCode, int quantity, double unitPrice, string transactionId, string receipt, string signature)
	{
		//IL_0935: Expected O, but got I4
		//IL_1253: Expected O, but got I
		//IL_006e: Expected O, but got I4
		//IL_099f: Expected O, but got I4
		//IL_0a1e: Expected O, but got I4
		//IL_0f5e: Expected O, but got I
		//IL_00d8: Expected O, but got I4
		//IL_0acd: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_0b95: Expected O, but got I4
		//IL_0310: Expected O, but got I4
		//IL_12b1: Expected O, but got I
		//IL_0c00: Expected O, but got I4
		//IL_130f: Expected O, but got I
		//IL_0c52: Expected O, but got I4
		//IL_136d: Expected O, but got I
		//IL_03d8: Expected O, but got I4
		//IL_0ca3: Expected O, but got I4
		//IL_13cb: Expected O, but got I
		//IL_0fbc: Expected O, but got I
		//IL_0cf5: Expected O, but got I4
		//IL_0443: Expected O, but got I4
		//IL_0d53: Expected O, but got I4
		//IL_0d7f: Expected O, but got I4
		//IL_101a: Expected O, but got I
		//IL_0495: Expected O, but got I4
		//IL_1429: Expected O, but got I
		//IL_1078: Expected O, but got I
		//IL_0e01: Expected O, but got I4
		//IL_04e6: Expected O, but got I4
		//IL_0e81: Expected O, but got I4
		//IL_10d6: Expected O, but got I
		//IL_0538: Expected O, but got I4
		//IL_0596: Expected O, but got I4
		//IL_05c2: Expected O, but got I4
		//IL_1134: Expected O, but got I
		//IL_0644: Expected O, but got I4
		//IL_06a2: Expected O, but got I4
		//IL_06ce: Expected O, but got I4
		//IL_1192: Expected O, but got I
		//IL_0750: Expected O, but got I4
		//IL_0784: Expected O, but got I4
		//IL_07b0: Expected O, but got I4
		//IL_11f0: Expected O, but got I
		//IL_0832: Expected O, but got I4
		//IL_0888: Expected O, but got I4
		object[] args;
		string message;
		if (receipt != null && signature != null)
		{
			object[] array = new object[6];
			if (productId != null)
			{
				object obj = productId as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = productId;
				if (currencyCode != null)
				{
					object obj3 = currencyCode as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = currencyCode;
					object obj5 = quantity;
					if (obj5 != null)
					{
						object obj6 = obj5 as object;
					}
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = obj5;
						object obj8 = unitPrice;
						if (obj8 != null)
						{
							object obj9 = obj8 as object;
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj10 = array.Length - 3;
						bool flag11 = obj10 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = obj8;
							object obj11 = receipt as object;
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj12 = array.Length - 4;
							bool flag15 = obj12 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = receipt;
								object obj13 = signature as object;
								bool flag17 = array.Length < 5;
								bool flag18 = !flag17;
								object obj14 = array.Length - 5;
								bool flag19 = obj14 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = signature;
									bool isDebugBuild = Debug.isDebugBuild;
									bool flag21 = !isDebugBuild;
									args = array;
									if (flag21)
									{
										goto IL_0ef0;
									}
									object[] array2 = new object[12];
									if ("Android Transaction " != null)
									{
										object obj15 = "Android Transaction " as object;
									}
									object obj16 = array2.Length;
									if (array2.Length != 0)
									{
										array2[0] = "Android Transaction ";
										if (productId != null)
										{
											object obj17 = productId as object;
											obj16 = array2.Length;
										}
										bool flag22 = (long)(IntPtr)obj16 < 1L;
										bool flag23 = !flag22;
										object obj18 = (long)(IntPtr)obj16 - 1L;
										bool flag24 = obj18 == null;
										bool flag25 = !flag23;
										if (!(flag25 || flag24))
										{
											array2[1] = productId;
											if (", " != null)
											{
												object obj19 = ", " as object;
												obj16 = array2.Length;
											}
											bool flag26 = (long)(IntPtr)obj16 < 2L;
											bool flag27 = !flag26;
											object obj20 = (long)(IntPtr)obj16 - 2L;
											bool flag28 = obj20 == null;
											bool flag29 = !flag27;
											if (!(flag29 || flag28))
											{
												array2[2] = ", ";
												if (currencyCode != null)
												{
													object obj21 = currencyCode as object;
													obj16 = array2.Length;
												}
												bool flag30 = (long)(IntPtr)obj16 < 3L;
												bool flag31 = !flag30;
												object obj22 = (long)(IntPtr)obj16 - 3L;
												bool flag32 = obj22 == null;
												bool flag33 = !flag31;
												if (!(flag33 || flag32))
												{
													array2[3] = currencyCode;
													if (", " != null)
													{
														object obj23 = ", " as object;
														obj16 = array2.Length;
													}
													bool flag34 = (long)(IntPtr)obj16 < 4L;
													bool flag35 = !flag34;
													object obj24 = (long)(IntPtr)obj16 - 4L;
													bool flag36 = obj24 == null;
													bool flag37 = !flag35;
													if (!(flag37 || flag36))
													{
														array2[4] = ", ";
														object obj25 = quantity;
														if (obj25 != null)
														{
															object obj26 = obj25 as object;
														}
														object obj27 = array2.Length;
														bool flag38 = array2.Length < 5;
														bool flag39 = !flag38;
														object obj28 = array2.Length - 5;
														bool flag40 = obj28 == null;
														bool flag41 = !flag39;
														if (!(flag41 || flag40))
														{
															array2[5] = obj25;
															if (", " != null)
															{
																object obj29 = ", " as object;
																obj27 = array2.Length;
															}
															bool flag42 = (long)(IntPtr)obj27 < 6L;
															bool flag43 = !flag42;
															object obj30 = (long)(IntPtr)obj27 - 6L;
															bool flag44 = obj30 == null;
															bool flag45 = !flag43;
															if (!(flag45 || flag44))
															{
																array2[6] = ", ";
																object obj31 = unitPrice;
																if (obj31 != null)
																{
																	object obj32 = obj31 as object;
																}
																object obj33 = array2.Length;
																bool flag46 = array2.Length < 7;
																bool flag47 = !flag46;
																object obj34 = array2.Length - 7;
																bool flag48 = obj34 == null;
																bool flag49 = !flag47;
																if (!(flag49 || flag48))
																{
																	array2[7] = obj31;
																	if (", " != null)
																	{
																		object obj35 = ", " as object;
																		obj33 = array2.Length;
																	}
																	bool flag50 = (long)(IntPtr)obj33 < 8L;
																	bool flag51 = !flag50;
																	object obj36 = (long)(IntPtr)obj33 - 8L;
																	bool flag52 = obj36 == null;
																	bool flag53 = !flag51;
																	if (!(flag53 || flag52))
																	{
																		array2[8] = ", ";
																		object obj37 = receipt as object;
																		object obj38 = array2.Length;
																		bool flag54 = array2.Length < 9;
																		bool flag55 = !flag54;
																		object obj39 = array2.Length - 9;
																		bool flag56 = obj39 == null;
																		bool flag57 = !flag55;
																		if (!(flag57 || flag56))
																		{
																			array2[9] = receipt;
																			if (", " != null)
																			{
																				object obj40 = ", " as object;
																				obj38 = array2.Length;
																			}
																			bool flag58 = (long)(IntPtr)obj38 < 10L;
																			bool flag59 = !flag58;
																			object obj41 = (long)(IntPtr)obj38 - 10L;
																			bool flag60 = obj41 == null;
																			bool flag61 = !flag59;
																			if (!(flag61 || flag60))
																			{
																				array2[10] = ", ";
																				object obj42 = signature as object;
																				bool flag62 = array2.Length < 11;
																				bool flag63 = !flag62;
																				object obj43 = array2.Length - 11;
																				bool flag64 = obj43 == null;
																				bool flag65 = !flag63;
																				if (!(flag65 || flag64))
																				{
																					array2[11] = signature;
																					message = string.Concat(array2);
																					args = array;
																					goto IL_0ee2;
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			object[] array3 = new object[4];
			if (productId != null)
			{
				object obj44 = productId as object;
			}
			object obj45 = array3.Length;
			if (array3.Length != 0)
			{
				array3[0] = productId;
				if (currencyCode != null)
				{
					object obj46 = currencyCode as object;
					obj45 = array3.Length;
				}
				bool flag66 = (long)(IntPtr)obj45 < 1L;
				bool flag67 = !flag66;
				object obj47 = (long)(IntPtr)obj45 - 1L;
				bool flag68 = obj47 == null;
				bool flag69 = !flag67;
				if (!(flag69 || flag68))
				{
					array3[1] = currencyCode;
					object obj48 = quantity;
					if (obj48 != null)
					{
						object obj49 = obj48 as object;
					}
					bool flag70 = array3.Length < 2;
					bool flag71 = !flag70;
					object obj50 = array3.Length - 2;
					bool flag72 = obj50 == null;
					bool flag73 = !flag71;
					if (!(flag73 || flag72))
					{
						array3[2] = obj48;
						object obj51 = unitPrice;
						if (obj51 != null)
						{
							object obj52 = obj51 as object;
						}
						bool flag74 = array3.Length < 3;
						bool flag75 = !flag74;
						object obj53 = array3.Length - 3;
						bool flag76 = obj53 == null;
						bool flag77 = !flag75;
						if (!(flag77 || flag76))
						{
							array3[3] = obj51;
							bool isDebugBuild2 = Debug.isDebugBuild;
							bool flag78 = !isDebugBuild2;
							args = array3;
							if (flag78)
							{
								goto IL_0ef0;
							}
							object[] array4 = new object[8];
							if ("Android Transaction " != null)
							{
								object obj54 = "Android Transaction " as object;
							}
							object obj55 = array4.Length;
							if (array4.Length != 0)
							{
								array4[0] = "Android Transaction ";
								if (productId != null)
								{
									object obj56 = productId as object;
									obj55 = array4.Length;
								}
								bool flag79 = (long)(IntPtr)obj55 < 1L;
								bool flag80 = !flag79;
								object obj57 = (long)(IntPtr)obj55 - 1L;
								bool flag81 = obj57 == null;
								bool flag82 = !flag80;
								if (!(flag82 || flag81))
								{
									array4[1] = productId;
									if (", " != null)
									{
										object obj58 = ", " as object;
										obj55 = array4.Length;
									}
									bool flag83 = (long)(IntPtr)obj55 < 2L;
									bool flag84 = !flag83;
									object obj59 = (long)(IntPtr)obj55 - 2L;
									bool flag85 = obj59 == null;
									bool flag86 = !flag84;
									if (!(flag86 || flag85))
									{
										array4[2] = ", ";
										if (currencyCode != null)
										{
											object obj60 = currencyCode as object;
											obj55 = array4.Length;
										}
										bool flag87 = (long)(IntPtr)obj55 < 3L;
										bool flag88 = !flag87;
										object obj61 = (long)(IntPtr)obj55 - 3L;
										bool flag89 = obj61 == null;
										bool flag90 = !flag88;
										if (!(flag90 || flag89))
										{
											array4[3] = currencyCode;
											if (", " != null)
											{
												object obj62 = ", " as object;
												obj55 = array4.Length;
											}
											bool flag91 = (long)(IntPtr)obj55 < 4L;
											bool flag92 = !flag91;
											object obj63 = (long)(IntPtr)obj55 - 4L;
											bool flag93 = obj63 == null;
											bool flag94 = !flag92;
											if (!(flag94 || flag93))
											{
												array4[4] = ", ";
												object obj64 = quantity;
												if (obj64 != null)
												{
													object obj65 = obj64 as object;
												}
												object obj66 = array4.Length;
												bool flag95 = array4.Length < 5;
												bool flag96 = !flag95;
												object obj67 = array4.Length - 5;
												bool flag97 = obj67 == null;
												bool flag98 = !flag96;
												if (!(flag98 || flag97))
												{
													array4[5] = obj64;
													if (", " != null)
													{
														object obj68 = ", " as object;
														obj66 = array4.Length;
													}
													bool flag99 = (long)(IntPtr)obj66 < 6L;
													bool flag100 = !flag99;
													object obj69 = (long)(IntPtr)obj66 - 6L;
													bool flag101 = obj69 == null;
													bool flag102 = !flag100;
													if (!(flag102 || flag101))
													{
														array4[6] = ", ";
														object obj70 = unitPrice;
														if (obj70 != null)
														{
															object obj71 = obj70 as object;
														}
														bool flag103 = array4.Length < 7;
														bool flag104 = !flag103;
														object obj72 = array4.Length - 7;
														bool flag105 = obj72 == null;
														bool flag106 = !flag104;
														if (!(flag106 || flag105))
														{
															array4[7] = obj70;
															message = string.Concat(array4);
															args = array3;
															goto IL_0ee2;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
		IL_0ef0:
		tenjinJava.Call("transaction", args);
		return;
		IL_0ee2:
		Debug.Log(message);
		goto IL_0ef0;
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x165DC48", Offset = "0x165DC48", Length = "0xEC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC2AC8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, deferredDeeplinkDelegate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF41]) = v41;\nL_0018:\n\tv45 = new AndroidTenjin+DeferredDeeplinkListener();\n\tAndroidTenjin+DeferredDeeplinkListener::.ctor(v45, deferredDeeplinkDelegate);\n\t// 33 NewArr v53 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv56 = v45 == 0;\n\tif (v56) goto L_002E;\n\t// 42 IsInst v61 @ X0_v18, typeof(System.Object), v45 @ X0_v3 (AndroidTenjin+DeferredDeeplinkListener)\nL_002E:\n\tv68 = v53.Length == 0;\n\tif (v68) goto L_0042;\n\tv53[0] = v45;\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"getDeeplink\", v53);\n\treturn;\n\tv57 = new System.NullReferenceException();\nL_0042:\n\tv73 = new System.IndexOutOfRangeException();\n\tgoto L_0049;\n\tv77 = new System.NullReferenceException();\n\tv80 = new System.ArrayTypeMismatchException();\nL_0049:\n\tthrow v94;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void GetDeeplink(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkDelegate)
	{
		DeferredDeeplinkListener deferredDeeplinkListener = new DeferredDeeplinkListener(deferredDeeplinkDelegate);
		object[] array = new object[1];
		if (deferredDeeplinkListener != null)
		{
			object obj = deferredDeeplinkListener as object;
		}
		if (array.Length != 0)
		{
			array[0] = deferredDeeplinkListener;
			tenjinJava.Call("getDeeplink", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0x165DDBC", Offset = "0x165DDBC", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EA52F8]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF42]) = v40;\nL_0015:\n\tthis.optIn = 1;\n\tv47 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv52 = v47;\n\tv53 = 0x8907BC(v52, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv57 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0045;\n\tv60 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv82 = v60;\n\tv83 = 0x8907BC(v82, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv84 = *([v60 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv70 = ~v84;\n\tif (v70) goto L_0045;\n\tgoto L_0045;\n\tv106 = v75;\n\tv107 = 0x8907BC(v106, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tgoto L_0057;\n\tv85 = v77;\n\tv86 = 0x8907BC(v85, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"optIn\", v93.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptIn()
	{
		optIn = true;
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		tenjinJava.Call("optIn");
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0x165DEBC", Offset = "0x165DEBC", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EC76D0]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF43]) = v40;\nL_0015:\n\tthis.optOut = 1;\n\tv47 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv52 = v47;\n\tv53 = 0x8907BC(v52, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv57 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0045;\n\tv60 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv82 = v60;\n\tv83 = 0x8907BC(v82, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv84 = *([v60 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv70 = ~v84;\n\tif (v70) goto L_0045;\n\tgoto L_0045;\n\tv106 = v75;\n\tv107 = 0x8907BC(v106, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tgoto L_0057;\n\tv85 = v77;\n\tv86 = 0x8907BC(v85, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"optOut\", v93.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptOut()
	{
		optOut = true;
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		tenjinJava.Call("optOut");
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0x165DFBC", Offset = "0x165DFBC", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv21 = *([1EBD528]);\n\tv22 = *([v21 @ X8_v5]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, parameters, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF44]) = v40;\nL_0017:\n\tv43 = 0x1660FC8(v38, parameters, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n\tX1 = 0 | 1;\n\tX0 = *([1EFE000]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_0043;\n\tX8 = *([1EA6400]);\n\tX0 = X21;\n\tX1 = *([X8]);\n\tX0 = System.Collections.Generic.List`1::ToArray /* +30 sharing this address */(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_0043;\n\tif (TEMP) goto L_002F;\n\tX8 = *([X20]);\n\tX0 = X21;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0047;\nL_002F:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_0045;\n\t*([X20+20]) = X21;\n\tif (TEMP) goto L_0043;\n\tX8 = *([1F0AC00]);\n\tX0 = X19;\n\tX2 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX1 = *([X8]);\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX3 = 0;\n\tX21 = stack[0];\n\t// 64 ShiftStack 48\n\tUnityEngine.AndroidJavaObject::Call(X0, X1, X2, X3);\n\treturn;\nL_0043:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0045:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0048;\nL_0047:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0048:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptInParams(List<string> parameters)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1660FC8 (inside Tenjin+DeferredDeeplinkDelegate::EndInvoke +0x18)");
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x165E0A4", Offset = "0x165E0A4", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EEDAF8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, parameters, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF45]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = System.Collections.Generic.List`1<System.String>::ToArray(parameters);\n\tv75 = v54 == 0;\n\tif (v75) goto L_002F;\n\t// 43 IsInst v79 @ X0_v16, typeof(System.Object), v54 @ X0_v12 (System.String[])\nL_002F:\n\tv71 = v47.Length == 0;\n\tif (v71) goto L_0044;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"optOutParams\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0044:\n\tv74 = new System.IndexOutOfRangeException();\n\tgoto L_0049;\n\tv85 = new System.ArrayTypeMismatchException();\nL_0049:\n\tthrow v84;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptOutParams(List<string> parameters)
	{
		object[] array = new object[1];
		string[] array2 = parameters.ToArray();
		if (array2 != null)
		{
			object obj = array2 as object;
		}
		if (array.Length != 0)
		{
			array[0] = array2;
			tenjinJava.Call("optOutParams", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0x165E18C", Offset = "0x165E18C", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EEE400]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, appSubversion, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF46]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 32 Box v53 @ X0_v5, typeof(System.Int32), &appSubversion @ X1 (System.Int32)\n\tv56 = v53 == 0;\n\tif (v56) goto L_002D;\n\t// 41 IsInst v61 @ X0_v16, typeof(System.Object), v53 @ X0_v5\nL_002D:\n\tv68 = v46.Length == 0;\n\tif (v68) goto L_0042;\n\tv46[0] = v53;\n\tUnityEngine.AndroidJavaObject::Call(this.tenjinJava, \"appendAppSubversion\", v46);\n\treturn;\n\tv75 = new System.NullReferenceException();\nL_0042:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0047;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0047:\n\tthrow v88;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void AppendAppSubversion(int appSubversion)
	{
		object[] array = new object[1];
		object obj = appSubversion;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			tenjinJava.Call("appendAppSubversion", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0x165E274", Offset = "0x165E274", Length = "0x7BC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv33 = *([1ECD418]);\n\tv34 = *([v33 @ X8_v95]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202AF47]) = v53;\nL_001C:\n\tv54 = &v55 @ stack_-80;\n\tv61 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002B;\n\tv66 = v61;\n\tv67 = 0x8907BC(v66, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv70 = *([v61 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002B:\n\tv71 = *([v61 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv72 = v71 == 0;\n\tif (v72) goto L_004C;\n\tv74 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0038;\n\tv96 = v74;\n\tv97 = 0x8907BC(v96, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0038:\n\tv98 = *([v74 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv84 = ~v98;\n\tif (v84) goto L_004C;\n\tgoto L_004C;\n\tv117 = v89;\n\tv118 = 0x8907BC(v117, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_004C:\n\tgoto L_0054;\n\tv99 = v91;\n\tv100 = 0x8907BC(v99, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0054:\n\tv107 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v107, \"java.util.HashMap\", v103.Value);\n\tv124 = UnityEngine.AndroidJavaObject::GetRawClass(v107);\n\tv207 = UnityEngine.AndroidJNIHelper::GetMethodID(v124, \"put\", \"(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;\");\n\t*([v21 @ X29-58]) = v207;\n\t// 111 NewArr v192 @ X0_v35 (System.Object[]), typeof(System.Object[]), 2\n\tgoto L_00A0;\n\tv401 = *([v394 @ X8_v31+B0]);\n\tv402 = 0;\n\tv403 = v401 + 8;\n\tv405 = *([v443 @ X11_v45-8]);\n\tv449 = v405 == v397;\n\tif (v449) goto L_0099;\n\tv427 = v444 + 1;\n\tv519 = v427 < v396;\n\tv423 = ~v519;\n\tv425 = v443 + 0x10;\n\tv407 = ~v423;\n\tif (v407) goto L_FFFFFFFF;\n\tv428 = v27;\n\tv429 = 0;\n\tv430 = 0x8909C4(v428, v397, v429, v181, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00A0;\nL_0099:\n\tv520 = *([v443 @ X11_v45]);\n\tv521 = v520 << 4;\n\tv522 = v394 + v521;\n\tv523 = v522 + 0x130;\nL_00A0:\n\tv249 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::GetEnumerator(parameters);\nL_00AC:\n\tgoto L_00D3;\n\tv789 = *([v744 @ X8_v35+B0]);\n\tv790 = 0;\n\tv791 = v789 + 8;\n\tv793 = *([v837 @ X11_v40-8]);\n\tv843 = v793 == v748;\n\tif (v843) goto L_00CC;\n\tv815 = v838 + 1;\n\tv848 = v815 < v746;\n\tv811 = ~v848;\n\tv813 = v837 + 0x10;\n\tv795 = ~v811;\n\tif (v795) goto L_FFFFFFFF;\n\tv816 = v197;\n\tv817 = 0;\n\tv818 = 0x8909C4(v816, v748, v817, v566, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00D3;\nL_00CC:\n\tv849 = *([v837 @ X11_v40]);\n\tv850 = v849 << 4;\n\tv851 = v744 + v850;\n\tv852 = v851 + 0x130;\nL_00D3:\n\tv573 = System.Collections.IEnumerator::MoveNext(v249);\n\tv858 = v573 == 0;\n\tif (v858) goto L_0264;\n\tgoto L_0104;\n\tv866 = *([v859 @ X8_v39+B0]);\n\tv867 = 0;\n\tv868 = v866 + 8;\n\tv870 = *([v906 @ X11_v35-8]);\n\tv912 = v870 == v863;\n\tif (v912) goto L_00FD;\n\tv892 = v907 + 1;\n\tv917 = v892 < v861;\n\tv888 = ~v917;\n\tv890 = v906 + 0x10;\n\tv872 = ~v888;\n\tif (v872) goto L_FFFFFFFF;\n\tv893 = v197;\n\tv894 = 0;\n\tv895 = 0x8909C4(v893, v863, v894, v566, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0104;\nL_00FD:\n\tv918 = *([v906 @ X11_v35]);\n\tv919 = v918 << 4;\n\tv920 = v859 + v919;\n\tv921 = v920 + 0x130;\nL_0104:\n\tv928 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Current(v249);\n\t// 265 NewArr v932 @ X0_v47 (System.Object[]), typeof(System.Object[]), 1\n\tv935 = v928 == 0;\n\tif (v935) goto L_0116;\n\t// 274 IsInst v941 @ X0_v116, typeof(System.Object), v928 @ X0_v45 (System.Collections.Generic.KeyValuePair`2<System.String, System.String>)\n\tv945 = v941 == 0;\n\tif (v945) goto L_0275;\nL_0116:\n\tv948 = v932.Length == 0;\n\tif (v948) goto L_026D;\n\tv932[0] = v928;\n\tv957 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v957, \"java.lang.String\", v932);\n\t// 295 NewArr v998 @ X0_v64 (System.Object[]), typeof(System.Object[]), 1\n\tv359 = v998 == 0;\n\tif (v359) goto L_0210;\n\tgoto L_0134;\n\t// 304 IsInst v1003 @ X0_v112, typeof(System.Object), 0\n\tv365 = v1003 == 0;\n\tif (v365) goto L_0229;\nL_0134:\n\tv360 = v998.Length == 0;\n\tif (v360) goto L_0212;\n\tv998[0] = 0;\n\tv1011 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v1011, \"java.lang.String\", v998);\n\tv361 = v192 == 0;\n\tif (v361) goto L_0218;\n\tv1016 = v957 == 0;\n\tif (v1016) goto L_014D;\n\t// 330 IsInst v1020 @ X0_v108, typeof(System.Object), v957 @ X0_v61 (UnityEngine.AndroidJavaObject)\n\tv366 = v1020 == 0;\n\tif (v366) goto L_022E;\nL_014D:\n\tv374 = v192.Length;\n\tv362 = v192.Length == 0;\n\tif (v362) goto L_021A;\n\tv192[0] = v957;\n\tv1025 = v1011 == 0;\n\tif (v1025) goto L_015A;\n\t// 342 IsInst v1030 @ X0_v104, typeof(System.Object), v1011 @ X0_v71 (UnityEngine.AndroidJavaObject)\n\tv367 = v1030 == 0;\n\tif (v367) goto L_0233;\n\tv374 = v192.Length;\nL_015A:\n\tv1034 = v374 < 1;\n\tv311 = ~v1034;\n\tv307 = v374 - 1;\n\tv299 = v307 == 0;\n\tv1035 = ~v311;\n\tv279 = v1035 | v299;\n\tif (v279) goto L_021F;\n\tv192[1] = v1011;\n\tv1038 = UnityEngine.AndroidJavaObject::GetRawObject(v107);\n\tv1043 = UnityEngine.AndroidJNIHelper::CreateJNIArgArray(v192);\n\tv1047 = UnityEngine.AndroidJNI::CallObjectMethod(v1038, *([v21 @ X29-58]), v1043);\n\tv1183 = v270 + 1;\n\t*([v54 @ X27_v1+v1183 @ X28_v16*4]) = 0xAD;\nL_0176:\n\tv1049 = v1011 == 0;\n\tif (v1049) goto L_01A6;\n\tgoto L_01A5;\n\tv1093 = *([v1050 @ X8_v75+B0]);\n\tv1094 = 0;\n\tv1095 = v1093 + 8;\n\tv1097 = *([v1136 @ X11_v30-8]);\n\tv1142 = v1097 == v1054;\n\tif (v1142) goto L_019E;\n\tv1119 = v1137 + 1;\n\tv1174 = v1119 < v1052;\n\tv1115 = ~v1174;\n\tv1117 = v1136 + 0x10;\n\tv1099 = ~v1115;\n\tif (v1099) goto L_FFFFFFFF;\n\tv1120 = v263;\n\tv1121 = 0;\n\tv1122 = 0x8909C4(v1120, v1054, v1121, v333, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01A5;\nL_019E:\n\tv1175 = *([v1136 @ X11_v30]);\n\tv1176 = v1175 << 4;\n\tv1177 = v1050 + v1176;\n\tv1178 = v1177 + 0x130;\nL_01A5:\n\tSystem.IDisposable::Dispose(v1011);\nL_01A6:\n\tv1088 = v1183 + 1;\n\tv1090 = v1088 == 0;\n\tif (v1090) goto L_01BF;\n\tv1123 = v537 == 0;\n\tif (v1123) goto L_01BB;\n\tv1157 = *([v54 @ X27_v1+v1183 @ X28_v16*4]) != 0xAD;\n\tif (v1157) goto L_0227;\nL_01BB:\n\tv1169 = v957 == 0;\n\tv1170 = ~v1169;\n\tif (v1170) goto L_01CC;\n\tgoto L_01F4;\nL_01BF:\n\tv1124 = v537 == 0;\n\tv1125 = ~v1124;\n\tif (v1125) goto L_0227;\nL_01C4:\n\tv1194 = v957 == 0;\n\tif (v1194) goto L_01F4;\nL_01CC:\n\tgoto L_01F3;\n\tv1235 = *([v1196 @ X8_v69+B0]);\n\tv1236 = 0;\n\tv1237 = v1235 + 8;\n\tv1239 = *([v1277 @ X11_v24-8]);\n\tv1283 = v1239 == v1200;\n\tif (v1283) goto L_01EC;\n\tv1261 = v1278 + 1;\n\tv1289 = v1261 < v1198;\n\tv1257 = ~v1289;\n\tv1259 = v1277 + 0x10;\n\tv1241 = ~v1257;\n\tif (v1241) goto L_FFFFFFFF;\n\tv1262 = v265;\n\tv1263 = 0;\n\tv1264 = 0x8909C4(v1262, v1200, v1263, v333, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01F3;\nL_01EC:\n\tv1290 = *([v1277 @ X11_v24]);\n\tv1291 = v1290 << 4;\n\tv1292 = v1196 + v1291;\n\tv1293 = v1292 + 0x130;\nL_01F3:\n\tSystem.IDisposable::Dispose(v957);\nL_01F4:\n\tv739 = v270 + 1;\n\tv1232 = v739 == 0;\n\tif (v1232) goto L_020C;\n\tv700 = *([v54 @ X27_v1+v270 @ X28_v9*4]) != 0xAD;\n\tif (v700) goto L_020C;\n\tv742 = 0xFFFFFFFF ^ v270;\n\tv270 = v270 + v742;\n\tgoto L_00AC;\nL_020C:\n\tv740 = v692 == 0;\n\tif (v740) goto L_00AC;\n\tgoto L_0274;\nL_0210:\n\tv349 = new System.NullReferenceException();\n\tgoto L_027F;\nL_0212:\n\tv1012 = new System.IndexOutOfRangeException();\n\tthrow v1012;\n\tgoto L_027F;\nL_0218:\n\tv349 = new System.NullReferenceException();\n\tgoto L_027F;\nL_021A:\n\tv1026 = new System.IndexOutOfRangeException();\n\tthrow v1026;\n\tgoto L_027F;\nL_021F:\n\tv1039 = new System.IndexOutOfRangeException();\n\tthrow v1039;\n\tgoto L_027F;\nL_0227:\n\tv354 = new System.TypeLoadException();\n\tgoto L_027F;\nL_0229:\n\tv1013 = new System.ArrayTypeMismatchException();\n\tthrow v1013;\n\tgoto L_027F;\nL_022E:\n\tv1027 = new System.ArrayTypeMismatchException();\n\tthrow v1027;\n\tgoto L_027F;\nL_0233:\n\tv1040 = new System.ArrayTypeMismatchExce\n// ... truncated")]
	public static AndroidJavaObject CreateJavaMapFromDictainary(IDictionary<string, string> parameters)
	{
		//IL_00be: Expected O, but got I8
		//IL_0582: Expected O, but got I
		//IL_08b0: Expected O, but got I
		//IL_04b1: Expected O, but got I4
		//IL_04ba: Expected O, but got I4
		//IL_060e: Expected I4, but got O
		//IL_0639: Expected O, but got I8
		//IL_0646: Expected O, but got I8
		//IL_064e: Expected I4, but got O
		//IL_04f0: Expected O, but got I4
		//IL_0271: Expected O, but got I4
		//IL_077d: Expected O, but got I
		//IL_0355: Expected O, but got I
		//IL_02f3: Expected O, but got I4
		//IL_07c1: Expected O, but got I
		//IL_052b: Expected O, but got I4
		//IL_0534: Expected O, but got I4
		//IL_087d: Expected O, but got I8
		//IL_0893: Expected O, but got I8
		//IL_07fb: Expected O, but got I
		//IL_0457: Expected I4, but got I8
		//IL_0465: Expected O, but got I
		object obj = obj;
		object obj3 = default(object);
		object obj2 = obj3;
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.HashMap");
		IntPtr rawClass = androidJavaObject.GetRawClass();
		IntPtr methodID = AndroidJNIHelper.GetMethodID(rawClass, "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
		object[] array = new object[2];
		IEnumerator<KeyValuePair<string, string>> enumerator = parameters.GetEnumerator();
		object obj4 = 4294967295L;
		int num = 0;
		object obj6;
		int num2;
		object obj17 = default(object);
		AndroidJavaObject result = default(AndroidJavaObject);
		while (true)
		{
			object obj5;
			IEnumerator<KeyValuePair<string, string>> enumerator2;
			if (!enumerator.MoveNext())
			{
				obj5 = (long)(IntPtr)obj4 + 1L;
				_ = 193;
				bool flag = enumerator == null;
				bool flag2 = !flag;
				enumerator2 = enumerator;
				if (!flag2)
				{
					obj6 = obj5;
					num2 = num;
					break;
				}
				goto IL_08ed;
			}
			KeyValuePair<string, string> current = enumerator.Current;
			object[] array2 = new object[1];
			if ((object)current != null)
			{
				object obj7 = current as object;
				if (obj7 == null)
				{
					goto IL_05e9;
				}
			}
			int num4;
			object obj14;
			object obj15;
			NullReferenceException ex6;
			if (array2.Length != 0)
			{
				array2[0] = current;
				AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.lang.String", array2);
				object[] array3 = new object[1];
				if (array3 != null)
				{
					if (array3.Length == 0)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					array3[0] = null;
					AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("java.lang.String", array3);
					if (array != null)
					{
						if (androidJavaObject2 != null)
						{
							object obj8 = androidJavaObject2 as object;
							if (obj8 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						object obj9 = array.Length;
						if (array.Length != 0)
						{
							array[0] = androidJavaObject2;
							if (androidJavaObject3 != null)
							{
								object obj10 = androidJavaObject3 as object;
								if (obj10 == null)
								{
									ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
									throw ex3;
								}
								obj9 = array.Length;
							}
							bool flag3 = (long)(IntPtr)obj9 < 1L;
							bool flag4 = !flag3;
							object obj11 = (long)(IntPtr)obj9 - 1L;
							bool flag5 = obj11 == null;
							bool flag6 = !flag4;
							if (!(flag6 || flag5))
							{
								array[1] = androidJavaObject3;
								IntPtr rawObject = androidJavaObject.GetRawObject();
								jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(array);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
								IntPtr intPtr3 = AndroidJNI.CallObjectMethod(rawObject, (IntPtr)0, args);
								object obj12 = (long)(IntPtr)obj4 + 1L;
								_ = 173;
								((IDisposable)androidJavaObject3)?.Dispose();
								object obj13 = (long)(IntPtr)obj12 + 1L;
								int num3;
								if (obj13 != null)
								{
									if (num != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v1183 @ X28_v16*4]");
										if ((IntPtr)0 != (IntPtr)173)
										{
											goto IL_0519;
										}
									}
									bool flag7 = androidJavaObject2 == null;
									bool flag8 = !flag7;
									num3 = num;
									if (!flag8)
									{
										num4 = num;
										obj4 = obj12;
										goto IL_07ec;
									}
								}
								else
								{
									if (num != 0)
									{
										goto IL_0519;
									}
									bool flag9 = androidJavaObject2 == null;
									num3 = 0;
									obj12 = 4294967295L;
									num4 = 0;
									obj4 = 4294967295L;
									if (flag9)
									{
										goto IL_07ec;
									}
								}
								((IDisposable)androidJavaObject2).Dispose();
								num4 = num3;
								obj4 = obj12;
								goto IL_07ec;
							}
							IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
							throw ex4;
						}
						IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
						throw ex5;
					}
					ex6 = new NullReferenceException();
					obj14 = "java.lang.String";
					obj15 = 0;
					enumerator2 = enumerator;
				}
				else
				{
					ex6 = new NullReferenceException();
					obj14 = 1;
					obj15 = 0;
					enumerator2 = enumerator;
				}
				goto IL_08cd;
			}
			IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
			throw ex7;
			IL_07ec:
			object obj16 = (long)(IntPtr)obj4 + 1L;
			if (obj16 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v270 @ X28_v9*4]");
				if ((IntPtr)0 == (IntPtr)173)
				{
					int num5 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj4);
					obj4 = (long)(IntPtr)obj4 + (long)num5;
					num = num4;
					continue;
				}
			}
			bool flag10 = num4 == 0;
			num = 0;
			if (!flag10)
			{
				TypeLoadException ex8 = new TypeLoadException();
				goto IL_05e9;
			}
			continue;
			IL_08ed:
			enumerator2.Dispose();
			obj6 = obj5;
			num2 = num;
			break;
			IL_0519:
			TypeLoadException ex9 = new TypeLoadException();
			obj14 = 0;
			obj15 = 0;
			ex6 = (NullReferenceException)(object)ex9;
			enumerator2 = enumerator;
			goto IL_08cd;
			IL_08cd:
			if ((IntPtr)obj14 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				num = (int)obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				bool flag11 = enumerator2 == null;
				obj5 = 4294967295L;
				obj6 = 4294967295L;
				num2 = (int)obj17;
				if (flag11)
				{
					break;
				}
				goto IL_08ed;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return result;
			IL_05e9:
			ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
			throw ex10;
		}
		object obj18 = (long)(IntPtr)obj6 + 1L;
		if (obj18 != null)
		{
			if (num2 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v589 @ X28_v1*4]");
				if ((IntPtr)0 != (IntPtr)193)
				{
					goto IL_06a3;
				}
			}
		}
		else if (num2 != 0)
		{
			goto IL_06a3;
		}
		return androidJavaObject;
		IL_06a3:
		throw new TypeLoadException();
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0x165EA30", Offset = "0x165EA30", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AndroidTenjin()
	{
	}
}
