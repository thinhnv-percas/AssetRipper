using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000051")]
	public class MobileAds
	{
		[Token(Token = "0x2000052")]
		public static class Utils
		{
			[Token(Token = "0x6000355")]
			[Address(RVA = "0x135A454", Offset = "0x135A454", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv10 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv11 = \"il2cpp_codegen_initialize_runtime_metadata\"(v10, v12, v13, v14, v15, v16, v17, v18, returnVal1, v20, v21, v22, v23, v24, v25, v26);\n\tv30 = 1;\n\t*([1A3692A]) = v30;\nL_000E:\n\tv31 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0044;\n\tv44 = *([v39 @ X8_v3+B0]);\n\tv45 = v44 + 8;\n\tv47 = *([v136 @ X10_v7-8]);\n\tv141 = v47 == v42;\n\tif (v141) goto L_0039;\n\tv77 = v135 - 1;\n\tv79 = v136 + 0x10;\n\tv50 = v135 != 1;\n\tif (v50) goto L_FFFFFFFF;\n\tv80 = 6;\n\tv81 = v33;\n\tv82 = 0xB349B4(v81, v42, v80, v14, v15, v16, v17, v18, returnVal1, v20, v21, v22, v23, v24, v25, v26);\n\tgoto L_0044;\nL_0039:\n\tv147 = *([v136 @ X10_v7]);\n\tv148 = v147 + 6;\n\tv149 = v148 << 4;\n\tv150 = v39 + v149;\n\tv151 = v150 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IMobileAdsClient::GetDeviceScale(v31.client);\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static float GetDeviceScale()
			{
				MobileAds instance = Instance;
				return instance.client.GetDeviceScale();
			}

			[Token(Token = "0x6000356")]
			[Address(RVA = "0x135A4F4", Offset = "0x135A4F4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv10 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv11 = \"il2cpp_codegen_initialize_runtime_metadata\"(v10, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv30 = 1;\n\t*([1A3692B]) = v30;\nL_000E:\n\tv31 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0044;\n\tv44 = *([v39 @ X8_v3+B0]);\n\tv45 = v44 + 8;\n\tv47 = *([v136 @ X10_v7-8]);\n\tv141 = v47 == v42;\n\tif (v141) goto L_0039;\n\tv77 = v135 - 1;\n\tv79 = v136 + 0x10;\n\tv50 = v135 != 1;\n\tif (v50) goto L_FFFFFFFF;\n\tv80 = 7;\n\tv81 = v33;\n\tv82 = 0xB349B4(v81, v42, v80, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tgoto L_0044;\nL_0039:\n\tv147 = *([v136 @ X10_v7]);\n\tv148 = v147 + 7;\n\tv149 = v148 << 4;\n\tv150 = v39 + v149;\n\tv151 = v150 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IMobileAdsClient::GetDeviceSafeWidth(v31.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static int GetDeviceSafeWidth()
			{
				MobileAds instance = Instance;
				return instance.client.GetDeviceSafeWidth();
			}
		}

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x10")]
		private readonly IMobileAdsClient client;

		[Token(Token = "0x4000123")]
		private static IClientFactory clientFactory;

		[Token(Token = "0x4000124")]
		private static MobileAds instance;

		[Token(Token = "0x17000043")]
		public static MobileAds Instance
		{
			[Token(Token = "0x6000349")]
			[Address(RVA = "0x1359CF8", Offset = "0x1359CF8", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = GoogleMobileAds.Api.MobileAds;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3691F]) = v34;\nL_0013:\n\tv47 = v36.instance;\n\tv38 = v36.instance == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0026;\n\tv40 = new GoogleMobileAds.Api.MobileAds();\n\tv53 = GoogleMobileAds.Api.MobileAds::GetMobileAdsClient();\n\tv40.client = v53;\n\tSystem.Object::.ctor(v40);\n\tv46.instance = v40;\nL_0026:\n\treturn v47;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				MobileAds result = instance;
				if (instance == null)
				{
					MobileAds mobileAds = new MobileAds();
					IMobileAdsClient mobileAdsClient = GetMobileAdsClient();
					mobileAds.client = mobileAdsClient;
					instance = mobileAds;
					result = mobileAds;
				}
				return result;
			}
		}

		[Obsolete("Initialize(string appId) is deprecated, use Initialize(Action<InitializationStatus> initCompleteAction) instead.")]
		[Token(Token = "0x600034A")]
		[Address(RVA = "0x1359D90", Offset = "0x1359D90", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv16 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv39 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A36920]) = v36;\nL_0014:\n\tv37 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0049;\n\tv54 = *([v47 @ X8_v3+B0]);\n\tv55 = v54 + 8;\n\tv57 = *([v151 @ X10_v7-8]);\n\tv156 = v57 == v51;\n\tif (v156) goto L_0041;\n\tv87 = v150 - 1;\n\tv89 = v151 + 0x10;\n\tv60 = v150 != 1;\n\tif (v60) goto L_FFFFFFFF;\n\tv90 = v41;\n\tv91 = 0;\n\tv92 = 0xB349B4(v90, v51, v91, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tgoto L_0049;\nL_0041:\n\tv162 = *([v151 @ X10_v7]);\n\tv163 = v162 << 4;\n\tv164 = v47 + v163;\n\tv165 = v164 + 0x138;\nL_0049:\n\tGoogleMobileAds.Common.IMobileAdsClient::Initialize(v37.client, v33);\n\tgoto L_0055;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v172, v121, v101, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0055:\n\tGoogleMobileAds.Common.MobileAdsEventExecutor::Initialize();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize(string appId)
		{
			MobileAds mobileAds = Instance;
			string appId2 = default(string);
			mobileAds.client.Initialize(appId2);
			MobileAdsEventExecutor.Initialize();
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0x1359E64", Offset = "0x1359E64", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv18 = System.Action`1<GoogleMobileAds.Common.IInitializationStatusClient>;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv73 = GoogleMobileAds.Api.MobileAds+<>c__DisplayClass7_0;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36921]) = v38;\nL_0020:\n\tv40 = new GoogleMobileAds.Api.MobileAds+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v40);\n\tv40.initCompleteAction = initCompleteAction;\n\tv53 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tv61 = new System.Action`1<GoogleMobileAds.Common.IInitializationStatusClient>();\n\tSystem.Action`1<GoogleMobileAds.Common.IInitializationStatusClient>::.ctor(v61, v40, Il2CppMethodInfo);\n\tgoto L_0068;\n\tv144 = *([v137 @ X8_v6+B0]);\n\tv145 = v144 + 8;\n\tv147 = *([v184 @ X10_v7-8]);\n\tv189 = v147 == v141;\n\tif (v189) goto L_005F;\n\tv167 = v183 - 1;\n\tv169 = v184 + 0x10;\n\tv149 = v183 != 1;\n\tif (v149) goto L_FFFFFFFF;\n\tv170 = 1;\n\tv171 = v66;\n\tv172 = 0xB349B4(v171, v141, v170, v55, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0068;\nL_005F:\n\tv195 = *([v184 @ X10_v7]);\n\tv196 = v195 + 1;\n\tv197 = v196 << 4;\n\tv198 = v137 + v197;\n\tv199 = v198 + 0x138;\nL_0068:\n\tGoogleMobileAds.Common.IMobileAdsClient::Initialize(v53.client, v61);\n\tgoto L_0074;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v206, v123, v121, v55, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0074:\n\tGoogleMobileAds.Common.MobileAdsEventExecutor::Initialize();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize(Action<InitializationStatus> initCompleteAction)
		{
			MobileAds mobileAds = Instance;
			Action<IInitializationStatusClient> initCompleteAction2 = delegate(IInitializationStatusClient initStatusClient)
			{
				if (initCompleteAction != null)
				{
					InitializationStatus initializationStatus = null;
					initializationStatus.client = initStatusClient;
					initCompleteAction(initializationStatus);
				}
			};
			mobileAds.client.Initialize(initCompleteAction2);
			MobileAdsEventExecutor.Initialize();
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0x1359FB8", Offset = "0x1359FB8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv10 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv11 = \"il2cpp_codegen_initialize_runtime_metadata\"(v10, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv30 = 1;\n\t*([1A36922]) = v30;\nL_000E:\n\tv31 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0044;\n\tv44 = *([v39 @ X8_v3+B0]);\n\tv45 = v44 + 8;\n\tv47 = *([v136 @ X10_v7-8]);\n\tv141 = v47 == v42;\n\tif (v141) goto L_0039;\n\tv77 = v135 - 1;\n\tv79 = v136 + 0x10;\n\tv50 = v135 != 1;\n\tif (v50) goto L_FFFFFFFF;\n\tv80 = 2;\n\tv81 = v33;\n\tv82 = 0xB349B4(v81, v42, v80, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tgoto L_0044;\nL_0039:\n\tv147 = *([v136 @ X10_v7]);\n\tv148 = v147 + 2;\n\tv149 = v148 << 4;\n\tv150 = v39 + v149;\n\tv151 = v150 + 0x138;\nL_0044:\n\tGoogleMobileAds.Common.IMobileAdsClient::DisableMediationInitialization(v31.client);\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DisableMediationInitialization()
		{
			MobileAds mobileAds = Instance;
			mobileAds.client.DisableMediationInitialization();
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0x135A058", Offset = "0x135A058", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36923]) = v33;\nL_0010:\n\tv34 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0048;\n\tv47 = *([v42 @ X8_v3+B0]);\n\tv48 = v47 + 8;\n\tv50 = *([v143 @ X10_v7-8]);\n\tv148 = v50 == v45;\n\tif (v148) goto L_003B;\n\tv80 = v142 - 1;\n\tv82 = v143 + 0x10;\n\tv53 = v142 != 1;\n\tif (v53) goto L_FFFFFFFF;\n\tv83 = 4;\n\tv84 = v36;\n\tv85 = 0xB349B4(v84, v45, v83, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0048;\nL_003B:\n\tv154 = *([v143 @ X10_v7]);\n\tv155 = v154 + 4;\n\tv156 = v155 << 4;\n\tv157 = v42 + v156;\n\tv158 = v157 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IMobileAdsClient::SetApplicationMuted(v34.client, v31);\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetApplicationMuted(bool muted)
		{
			MobileAds mobileAds = Instance;
			bool applicationMuted = default(bool);
			mobileAds.client.SetApplicationMuted(applicationMuted);
		}

		[Token(Token = "0x600034E")]
		[Address(RVA = "0x135A108", Offset = "0x135A108", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36924]) = v33;\nL_0010:\n\tv34 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0048;\n\tv47 = *([v42 @ X8_v3+B0]);\n\tv48 = v47 + 8;\n\tv50 = *([v143 @ X10_v7-8]);\n\tv148 = v50 == v45;\n\tif (v148) goto L_003B;\n\tv80 = v142 - 1;\n\tv82 = v143 + 0x10;\n\tv53 = v142 != 1;\n\tif (v53) goto L_FFFFFFFF;\n\tv83 = 8;\n\tv84 = v36;\n\tv85 = 0xB349B4(v84, v45, v83, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0048;\nL_003B:\n\tv154 = *([v143 @ X10_v7]);\n\tv155 = v154 + 8;\n\tv156 = v155 << 4;\n\tv157 = v42 + v156;\n\tv158 = v157 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IMobileAdsClient::SetRequestConfiguration(v34.client, v31);\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetRequestConfiguration(RequestConfiguration requestConfiguration)
		{
			MobileAds mobileAds = Instance;
			RequestConfiguration requestConfiguration2 = default(RequestConfiguration);
			mobileAds.client.SetRequestConfiguration(requestConfiguration2);
		}

		[Token(Token = "0x600034F")]
		[Address(RVA = "0x135A1B8", Offset = "0x135A1B8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv10 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv11 = \"il2cpp_codegen_initialize_runtime_metadata\"(v10, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv30 = 1;\n\t*([1A36925]) = v30;\nL_000E:\n\tv31 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0044;\n\tv44 = *([v39 @ X8_v3+B0]);\n\tv45 = v44 + 8;\n\tv47 = *([v136 @ X10_v7-8]);\n\tv141 = v47 == v42;\n\tif (v141) goto L_0039;\n\tv77 = v135 - 1;\n\tv79 = v136 + 0x10;\n\tv50 = v135 != 1;\n\tif (v50) goto L_FFFFFFFF;\n\tv80 = 9;\n\tv81 = v33;\n\tv82 = 0xB349B4(v81, v42, v80, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tgoto L_0044;\nL_0039:\n\tv147 = *([v136 @ X10_v7]);\n\tv148 = v147 + 9;\n\tv149 = v148 << 4;\n\tv150 = v39 + v149;\n\tv151 = v150 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IMobileAdsClient::GetRequestConfiguration(v31.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RequestConfiguration GetRequestConfiguration()
		{
			MobileAds mobileAds = Instance;
			return mobileAds.client.GetRequestConfiguration();
		}

		[Token(Token = "0x6000350")]
		[Address(RVA = "0x135A258", Offset = "0x135A258", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, volume, v23, v24, v25, v26, v27, v28, v29);\n\tv33 = 1;\n\t*([1A36926]) = v33;\nL_0010:\n\tv34 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0048;\n\tv47 = *([v42 @ X8_v3+B0]);\n\tv48 = v47 + 8;\n\tv50 = *([v143 @ X10_v7-8]);\n\tv148 = v50 == v45;\n\tif (v148) goto L_003B;\n\tv80 = v142 - 1;\n\tv82 = v143 + 0x10;\n\tv53 = v142 != 1;\n\tif (v53) goto L_FFFFFFFF;\n\tv83 = 3;\n\tv84 = v36;\n\tv85 = 0xB349B4(v84, v45, v83, v18, v19, v20, v21, v22, volume, v23, v24, v25, v26, v27, v28, v29);\n\tgoto L_0048;\nL_003B:\n\tv154 = *([v143 @ X10_v7]);\n\tv155 = v154 + 3;\n\tv156 = v155 << 4;\n\tv157 = v42 + v156;\n\tv158 = v157 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IMobileAdsClient::SetApplicationVolume(v34.client, volume);\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetApplicationVolume(float volume)
		{
			MobileAds mobileAds = Instance;
			mobileAds.client.SetApplicationVolume(volume);
		}

		[Token(Token = "0x6000351")]
		[Address(RVA = "0x135A308", Offset = "0x135A308", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = GoogleMobileAds.Common.IMobileAdsClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36927]) = v33;\nL_0010:\n\tv34 = GoogleMobileAds.Api.MobileAds::get_Instance();\n\tgoto L_0048;\n\tv47 = *([v42 @ X8_v3+B0]);\n\tv48 = v47 + 8;\n\tv50 = *([v143 @ X10_v7-8]);\n\tv148 = v50 == v45;\n\tif (v148) goto L_003B;\n\tv80 = v142 - 1;\n\tv82 = v143 + 0x10;\n\tv53 = v142 != 1;\n\tif (v53) goto L_FFFFFFFF;\n\tv83 = 5;\n\tv84 = v36;\n\tv85 = 0xB349B4(v84, v45, v83, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0048;\nL_003B:\n\tv154 = *([v143 @ X10_v7]);\n\tv155 = v154 + 5;\n\tv156 = v155 << 4;\n\tv157 = v42 + v156;\n\tv158 = v157 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IMobileAdsClient::SetiOSAppPauseOnBackground(v34.client, v31);\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetiOSAppPauseOnBackground(bool pause)
		{
			MobileAds mobileAds = Instance;
			bool pause2 = default(bool);
			mobileAds.client.SetiOSAppPauseOnBackground(pause2);
		}

		[Token(Token = "0x6000352")]
		[Address(RVA = "0x13553C0", Offset = "0x13553C0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = GoogleMobileAds.GoogleMobileAdsClientFactory;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv42 = GoogleMobileAds.Api.MobileAds;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36928]) = v35;\nL_0016:\n\treturnVal1 = v37.clientFactory;\n\tv39 = v37.clientFactory == 0;\n\tv40 = ~v39;\n\tif (v40) goto L_002B;\n\tv46 = new GoogleMobileAds.GoogleMobileAdsClientFactory();\n\tSystem.Object::.ctor(v46);\n\tv59.clientFactory = v46;\n\treturnVal1 = v52.clientFactory;\nL_002B:\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IClientFactory GetClientFactory()
		{
			IClientFactory result = clientFactory;
			if (clientFactory == null)
			{
				GoogleMobileAdsClientFactory googleMobileAdsClientFactory = new GoogleMobileAdsClientFactory();
				clientFactory = googleMobileAdsClientFactory;
				result = clientFactory;
			}
			return result;
		}

		[Token(Token = "0x6000353")]
		[Address(RVA = "0x135A3B8", Offset = "0x135A3B8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv10 = GoogleMobileAds.IClientFactory;\n\tv11 = \"il2cpp_codegen_initialize_runtime_metadata\"(v10, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv30 = 1;\n\t*([1A36929]) = v30;\nL_000E:\n\tv31 = GoogleMobileAds.Api.MobileAds::GetClientFactory();\n\tgoto L_0042;\n\tv41 = *([v34 @ X8_v3+B0]);\n\tv42 = v41 + 8;\n\tv44 = *([v91 @ X10_v7-8]);\n\tv96 = v44 == v38;\n\tif (v96) goto L_0037;\n\tv74 = v90 - 1;\n\tv76 = v91 + 0x10;\n\tv47 = v90 != 1;\n\tif (v47) goto L_FFFFFFFF;\n\tv77 = 6;\n\tv78 = v36;\n\tv79 = 0xB349B4(v78, v38, v77, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tgoto L_0042;\nL_0037:\n\tv144 = *([v91 @ X10_v7]);\n\tv145 = v144 + 6;\n\tv146 = v145 << 4;\n\tv147 = v34 + v146;\n\tv148 = v147 + 0x138;\nL_0042:\n\tinterfaceTailCallResult = GoogleMobileAds.IClientFactory::MobileAdsInstance(v31);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IMobileAdsClient GetMobileAdsClient()
		{
			IClientFactory clientFactory = GetClientFactory();
			return clientFactory.MobileAdsInstance();
		}

		[Token(Token = "0x6000354")]
		[Address(RVA = "0x1359D70", Offset = "0x1359D70", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = GoogleMobileAds.Api.MobileAds::GetMobileAdsClient();\n\tthis.client = v6;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MobileAds()
		{
			IMobileAdsClient mobileAdsClient = GetMobileAdsClient();
			client = mobileAdsClient;
		}
	}
}
