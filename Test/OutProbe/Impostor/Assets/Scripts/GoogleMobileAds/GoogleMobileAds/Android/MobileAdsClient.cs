using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x2000019")]
	public class MobileAdsClient : AndroidJavaProxy, IMobileAdsClient
	{
		[Token(Token = "0x4000047")]
		internal static MobileAdsClient instance;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x20")]
		private Action<IInitializationStatusClient> initCompleteAction;

		[Token(Token = "0x17000004")]
		public static MobileAdsClient Instance
		{
			[Token(Token = "0x60000E1")]
			[Address(RVA = "0x1349894", Offset = "0x1349894", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = GoogleMobileAds.Android.MobileAdsClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A367DC]) = v34;\nL_0015:\n\tgoto L_001E;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Android.MobileAdsClient;\nL_001E:\n\treturn v42.instance;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return instance;
			}
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x1349824", Offset = "0x1349824", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = UnityEngine.AndroidJavaProxy;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = \"com.google.android.gms.ads.initialization.OnInitializationCompleteListener\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367DB]) = v38;\nL_001C:\n\tgoto L_0026;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.google.android.gms.ads.initialization.OnInitializationCompleteListener\");\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private MobileAdsClient()
			: base("com.google.android.gms.ads.initialization.OnInitializationCompleteListener")
		{
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x13498EC", Offset = "0x13498EC", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv26 = UnityEngine.AndroidJavaClass;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, appId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, appId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv56 = System.Object[];\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, appId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv60 = \"com.unity3d.player.UnityPlayer\";\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, appId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv127 = \"com.google.android.gms.ads.MobileAds\";\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, appId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv158 = \"initialize\";\n\tv159 = \"il2cpp_codegen_initialize_runtime_metadata\"(v158, appId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv191 = \"currentActivity\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, appId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv46 = 1;\n\t*([1A367DD]) = v46;\nL_002B:\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"com.unity3d.player.UnityPlayer\");\n\tv73 = UnityEngine.AndroidJavaObject::GetStatic(v48, \"currentActivity\");\n\tv130 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v130, \"com.google.android.gms.ads.MobileAds\");\n\t// 72 NewArr v111 @ X0_v16 (System.Object[]), typeof(System.Object[]), 2\n\tv195 = v73 == 0;\n\tif (v195) goto L_0057;\n\t// 81 IsInst v178 @ X0_v23, typeof(System.Object), v73 @ X0_v12 (System.Object)\n\tv181 = v178 == 0;\n\tif (v181) goto L_0082;\nL_0057:\n\tv111[0] = v73;\n\tv234 = appId == 0;\n\tif (v234) goto L_006D;\n\t// 93 IsInst v179 @ X0_v21, typeof(System.Object), appId @ X1 (System.String)\n\tv182 = v179 == 0;\n\tif (v182) goto L_0082;\nL_006D:\n\tv111[1] = appId;\n\tUnityEngine.AndroidJavaObject::CallStatic(v130, \"initialize\", v111);\n\treturn;\n\tv125 = new System.NullReferenceException();\n\tv156 = new System.IndexOutOfRangeException();\nL_0082:\n\tv189 = new System.ArrayTypeMismatchException();\n\tthrow v189;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(string appId)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			object obj = androidJavaClass.GetStatic<object>("currentActivity");
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			object[] array = new object[2];
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					goto IL_0108;
				}
			}
			array[0] = obj;
			if (appId != null)
			{
				object obj3 = appId as object;
				if (obj3 == null)
				{
					goto IL_0108;
				}
			}
			array[1] = appId;
			androidJavaClass2.CallStatic("initialize", array);
			return;
			IL_0108:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x1349A88", Offset = "0x1349A88", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv28 = UnityEngine.AndroidJavaClass;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, initCompleteAction, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, initCompleteAction, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = System.Object[];\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, initCompleteAction, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv61 = \"com.unity3d.player.UnityPlayer\";\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, initCompleteAction, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv128 = \"com.google.android.gms.ads.MobileAds\";\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, initCompleteAction, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv159 = \"initialize\";\n\tv160 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, initCompleteAction, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv189 = \"currentActivity\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, initCompleteAction, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A367DE]) = v47;\nL_002B:\n\tthis.initCompleteAction = initCompleteAction;\n\tv49 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v49, \"com.unity3d.player.UnityPlayer\");\n\tv74 = UnityEngine.AndroidJavaObject::GetStatic(v49, \"currentActivity\");\n\tv131 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v131, \"com.google.android.gms.ads.MobileAds\");\n\t// 74 NewArr v111 @ X0_v16 (System.Object[]), typeof(System.Object[]), 2\n\tv193 = v74 == 0;\n\tif (v193) goto L_005A;\n\t// 83 IsInst v177 @ X0_v22, typeof(System.Object), v74 @ X0_v12 (System.Object)\n\tv179 = v177 == 0;\n\tif (v179) goto L_0082;\nL_005A:\n\tv111[0] = v74;\n\t// 93 IsInst v112 @ X0_v19, typeof(System.Object), this @ X0 (GoogleMobileAds.Android.MobileAdsClient)\n\tv150 = v112 == 0;\n\tif (v150) goto L_0082;\n\tv111[1] = this;\n\tUnityEngine.AndroidJavaObject::CallStatic(v131, \"initialize\", v111);\n\treturn;\n\tv126 = new System.NullReferenceException();\n\tv157 = new System.IndexOutOfRangeException();\nL_0082:\n\tv187 = new System.ArrayTypeMismatchException();\n\tthrow v187;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(Action<IInitializationStatusClient> initCompleteAction)
		{
			this.initCompleteAction = initCompleteAction;
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			object obj = androidJavaClass.GetStatic<object>("currentActivity");
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			object[] array = new object[2];
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					goto IL_00e5;
				}
			}
			array[0] = obj;
			object obj3 = this as object;
			if (obj3 != null)
			{
				array[1] = this;
				androidJavaClass2.CallStatic("initialize", array);
				return;
			}
			goto IL_00e5;
			IL_00e5:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x1349C28", Offset = "0x1349C28", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv30 = UnityEngine.AndroidJavaClass;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, volume, v39, v40, v41, v42, v43, v44, v45);\n\tv54 = System.Object[];\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, volume, v39, v40, v41, v42, v43, v44, v45);\n\tv60 = System.Single;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v33, v34, v35, v36, v37, v38, volume, v39, v40, v41, v42, v43, v44, v45);\n\tv66 = \"setAppVolume\";\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v33, v34, v35, v36, v37, v38, volume, v39, v40, v41, v42, v43, v44, v45);\n\tv74 = \"com.google.android.gms.ads.MobileAds\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v33, v34, v35, v36, v37, v38, volume, v39, v40, v41, v42, v43, v44, v45);\n\tv50 = 1;\n\t*([1A367DF]) = v50;\nL_0029:\n\tv52 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v52, \"com.google.android.gms.ads.MobileAds\");\n\t// 48 NewArr v64 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 53 Box v72 @ X0_v7, typeof(System.Single), &volume @ V0 (System.Single)\n\tv77 = v72 == 0;\n\tif (v77) goto L_0044;\n\t// 62 IsInst v91 @ X0_v18, typeof(System.Object), v72 @ X0_v7\n\tv93 = v91 == 0;\n\tif (v93) goto L_0059;\nL_0044:\n\tv64[0] = v72;\n\tUnityEngine.AndroidJavaObject::CallStatic(v52, \"setAppVolume\", v64);\n\treturn;\n\tv87 = new System.NullReferenceException();\n\tv101 = new System.IndexOutOfRangeException();\nL_0059:\n\tv107 = new System.ArrayTypeMismatchException();\n\tthrow v107;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetApplicationVolume(float volume)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			object[] array = new object[1];
			object obj = volume;
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = obj;
			androidJavaClass.CallStatic("setAppVolume", array);
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x1349D58", Offset = "0x1349D58", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv20 = UnityEngine.AndroidJavaClass;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = System.Object[];\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv55 = \"com.unity3d.player.UnityPlayer\";\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv94 = \"disableMediationAdapterInitialization\";\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv111 = \"com.google.android.gms.ads.MobileAds\";\n\tv112 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv130 = \"currentActivity\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A367E0]) = v41;\nL_0028:\n\tv43 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v43, \"com.unity3d.player.UnityPlayer\");\n\tv68 = UnityEngine.AndroidJavaObject::GetStatic(v43, \"currentActivity\");\n\tv97 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v97, \"com.google.android.gms.ads.MobileAds\");\n\t// 69 NewArr v78 @ X0_v16 (System.Object[]), typeof(System.Object[]), 1\n\tv134 = v68 == 0;\n\tif (v134) goto L_0054;\n\t// 78 IsInst v120 @ X0_v20, typeof(System.Object), v68 @ X0_v12 (System.Object)\n\tv122 = v120 == 0;\n\tif (v122) goto L_0067;\nL_0054:\n\tv78[0] = v68;\n\tUnityEngine.AndroidJavaObject::CallStatic(v97, \"disableMediationAdapterInitialization\", v78);\n\treturn;\n\tv92 = new System.NullReferenceException();\n\tv109 = new System.IndexOutOfRangeException();\nL_0067:\n\tv128 = new System.ArrayTypeMismatchException();\n\tthrow v128;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DisableMediationInitialization()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			object obj = androidJavaClass.GetStatic<object>("currentActivity");
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			object[] array = new object[1];
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = obj;
			androidJavaClass2.CallStatic("disableMediationAdapterInitialization", array);
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x1349EC0", Offset = "0x1349EC0", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv30 = UnityEngine.AndroidJavaClass;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, muted, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv55 = System.Boolean;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, muted, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv61 = System.Object[];\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, muted, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv67 = \"setAppMuted\";\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, muted, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv75 = \"com.google.android.gms.ads.MobileAds\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, muted, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv50 = 1;\n\t*([1A367E1]) = v50;\nL_002A:\n\tv53 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v53, \"com.google.android.gms.ads.MobileAds\");\n\t// 49 NewArr v65 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 54 Box v73 @ X0_v7, typeof(System.Boolean), &muted @ X1 (System.Boolean)\n\tv78 = v73 == 0;\n\tif (v78) goto L_0045;\n\t// 63 IsInst v92 @ X0_v18, typeof(System.Object), v73 @ X0_v7\n\tv94 = v92 == 0;\n\tif (v94) goto L_005A;\nL_0045:\n\tv65[0] = v73;\n\tUnityEngine.AndroidJavaObject::CallStatic(v53, \"setAppMuted\", v65);\n\treturn;\n\tv88 = new System.NullReferenceException();\n\tv102 = new System.IndexOutOfRangeException();\nL_005A:\n\tv108 = new System.ArrayTypeMismatchException();\n\tthrow v108;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetApplicationMuted(bool muted)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			object[] array = new object[1];
			object obj = muted;
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = obj;
			androidJavaClass.CallStatic("setAppMuted", array);
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x1349FF4", Offset = "0x1349FF4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = UnityEngine.AndroidJavaClass;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, requestConfiguration, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv50 = System.Object[];\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, requestConfiguration, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv56 = \"com.google.android.gms.ads.MobileAds\";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, requestConfiguration, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv61 = \"setRequestConfiguration\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, requestConfiguration, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv46 = 1;\n\t*([1A367E2]) = v46;\nL_0023:\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"com.google.android.gms.ads.MobileAds\");\n\tv59 = GoogleMobileAds.Android.RequestConfigurationClient::BuildRequestConfiguration(requestConfiguration);\n\t// 46 NewArr v66 @ X0_v7 (System.Object[]), typeof(System.Object[]), 1\n\tv69 = v59 == 0;\n\tif (v69) goto L_003D;\n\t// 55 IsInst v83 @ X0_v18, typeof(System.Object), v59 @ X0_v5 (UnityEngine.AndroidJavaObject)\n\tv85 = v83 == 0;\n\tif (v85) goto L_0051;\nL_003D:\n\tv66[0] = v59;\n\tUnityEngine.AndroidJavaObject::CallStatic(v48, \"setRequestConfiguration\", v66);\n\treturn;\n\tv79 = new System.NullReferenceException();\n\tv93 = new System.IndexOutOfRangeException();\nL_0051:\n\tv99 = new System.ArrayTypeMismatchException();\n\tthrow v99;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetRequestConfiguration(RequestConfiguration requestConfiguration)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			AndroidJavaObject androidJavaObject = RequestConfigurationClient.BuildRequestConfiguration(requestConfiguration);
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
			array[0] = androidJavaObject;
			androidJavaClass.CallStatic("setRequestConfiguration", array);
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x134A770", Offset = "0x134A770", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv22 = UnityEngine.AndroidJavaClass;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = \"getRequestConfiguration\";\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv73 = \"com.google.android.gms.ads.MobileAds\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A367E3]) = v43;\nL_0024:\n\tv45 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v45, \"com.google.android.gms.ads.MobileAds\");\n\tgoto L_0036;\n\tv63 = System.Array::Empty();\nL_0036:\n\tgoto L_003B;\n\tv74 = 0xB348B0(v67, v49, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003B:\n\tgoto L_0043;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v75, v49, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0043:\n\tgoto L_0050;\n\tv87 = 0xB348B0(v82, v49, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0050:\n\tv99 = UnityEngine.AndroidJavaObject::CallStatic(v45, \"getRequestConfiguration\", v92.Value);\n\treturnVal2 = GoogleMobileAds.Android.RequestConfigurationClient::GetRequestConfiguration(v99);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RequestConfiguration GetRequestConfiguration()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			object androidRequestConfiguration = androidJavaClass.CallStatic<object>("getRequestConfiguration", Array.Empty<object>());
			return RequestConfigurationClient.GetRequestConfiguration((AndroidJavaObject)androidRequestConfiguration);
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x134ABA8", Offset = "0x134ABA8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetiOSAppPauseOnBackground(bool pause)
		{
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x134ABAC", Offset = "0x134ABAC", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv20 = UnityEngine.AndroidJavaClass;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv103 = Il2CppMethodInfo;\n\tv104 = \"il2cpp_codegen_initialize_runtime_metadata\"(v103, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv109 = \"density\";\n\tv110 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv145 = \"getDisplayMetrics\";\n\tv146 = \"il2cpp_codegen_initialize_runtime_metadata\"(v145, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv153 = \"com.unity3d.player.UnityPlayer\";\n\tv154 = \"il2cpp_codegen_initialize_runtime_metadata\"(v153, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv163 = \"getResources\";\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv167 = \"currentActivity\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, methodInfo, v23, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A367E4]) = v41;\nL_0031:\n\tv43 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v43, \"com.unity3d.player.UnityPlayer\");\n\tv66 = UnityEngine.AndroidJavaObject::GetStatic(v43, \"currentActivity\");\n\tgoto L_0050;\n\tv112 = UnityEngine.AndroidJavaObject::GetStatic(Il2CppMethodInfo, \"currentActivity\");\nL_0050:\n\tgoto L_0055;\n\tv147 = UnityEngine.AndroidJavaObject::GetStatic(v116, v63, v64);\nL_0055:\n\tgoto L_FFFFFFFF;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v148, v63, v64, v24, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0063;\n\tv165 = UnityEngine.AndroidJavaObject::GetStatic(v158, v63, v64);\nL_0063:\n\tv170 = *([v83 @ X0_v13+B8]);\n\tv172 = UnityEngine.AndroidJavaObject::Call(v66, \"getResources\", *([v170 @ X8_v12]));\n\tgoto L_0079;\n\tv177 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getResources\", *([v170 @ X8_v12]));\nL_0079:\n\tgoto L_007E;\n\tv186 = UnityEngine.AndroidJavaObject::Call(v181, v80, v77, v68);\nL_007E:\n\tgoto L_FFFFFFFF;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v187, v80, v77, v68, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_008B;\n\tv198 = UnityEngine.AndroidJavaObject::Call(v194, v80, v77, v68);\nL_008B:\n\tv93 = *([v84 @ X0_v21+B8]);\n\tv85 = UnityEngine.AndroidJavaObject::Call(v172, \"getDisplayMetrics\", *([v93 @ X8_v19]));\n\treturnVal2 = UnityEngine.AndroidJavaObject::Get(v85, \"density\");\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetDeviceScale()
		{
			//IL_003c: Expected O, but got I
			//IL_0051: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_00a5: Expected O, but got I
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			object obj = androidJavaClass.GetStatic<object>("currentActivity");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X0_v13+B8]");
			object args = 0;
			object obj3 = ((AndroidJavaObject)obj).Call<object>("getResources", (object[])args);
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X0_v21+B8]");
			object args2 = 0;
			object obj5 = ((AndroidJavaObject)obj3).Call<object>("getDisplayMetrics", (object[])args2);
			return ((AndroidJavaObject)obj5).Get<float>("density");
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x134ADB0", Offset = "0x134ADB0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = GoogleMobileAds.Android.Utils::GetScreenWidth();\n\treturn returnVal1;\n")]
		public int GetDeviceSafeWidth()
		{
			return Utils.GetScreenWidth();
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x134AE30", Offset = "0x134AE30", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = GoogleMobileAds.Android.InitializationStatusClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, initStatus, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A367E5]) = v36;\nL_0013:\n\tv38 = this.initCompleteAction == 0;\n\tif (v38) goto L_002E;\n\tv42 = new GoogleMobileAds.Android.InitializationStatusClient();\n\tGoogleMobileAds.Android.InitializationStatusClient::.ctor(v42, initStatus);\n\tv61 = this.initCompleteAction == 0;\n\tif (v61) goto L_002F;\n\tSystem.Action`1<GoogleMobileAds.Common.IInitializationStatusClient>::Invoke(this.initCompleteAction, v42);\nL_002E:\n\treturn;\nL_002F:\n\tthrow v42;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onInitializationComplete(AndroidJavaObject initStatus)
		{
			if (initCompleteAction != null)
			{
				InitializationStatusClient initializationStatusClient = new InitializationStatusClient(initStatus);
				if (initCompleteAction == null)
				{
					throw initializationStatusClient;
				}
				initCompleteAction(initializationStatusClient);
			}
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x134AEB8", Offset = "0x134AEB8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GoogleMobileAds.Android.MobileAdsClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A367E6]) = v34;\nL_0012:\n\tv36 = new GoogleMobileAds.Android.MobileAdsClient();\n\tGoogleMobileAds.Android.MobileAdsClient::.ctor(v36);\n\tv39.instance = v36;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static MobileAdsClient()
		{
			MobileAdsClient mobileAdsClient = new MobileAdsClient();
			instance = mobileAdsClient;
		}
	}
}
