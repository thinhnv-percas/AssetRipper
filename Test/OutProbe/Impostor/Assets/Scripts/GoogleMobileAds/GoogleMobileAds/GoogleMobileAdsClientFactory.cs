using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Android;
using GoogleMobileAds.Common;
using GoogleMobileAds.Unity;
using UnityEngine;
using UnityEngine.Scripting;

namespace GoogleMobileAds
{
	[Preserve]
	[Token(Token = "0x2000009")]
	public class GoogleMobileAdsClientFactory : IClientFactory
	{
		[Token(Token = "0x600001C")]
		[Address(RVA = "0x133CBF0", Offset = "0x133CBF0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Unity.BannerClient;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = GoogleMobileAds.Android.BannerClient;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv61 = GoogleMobileAds.Common.DummyClient;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3672C]) = v35;\nL_001E:\n\tgoto L_0021;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv46 = UnityEngine.Application::get_platform();\n\tv59 = v46 != 0xB;\n\tif (v59) goto L_0038;\n\tv65 = new GoogleMobileAds.Android.BannerClient();\n\tGoogleMobileAds.Android.BannerClient::.ctor(v65);\n\tgoto L_0063;\nL_0038:\n\tgoto L_003B;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003B:\n\tv74 = UnityEngine.Application::get_platform();\n\tv75 = v74 == 0;\n\tif (v75) goto L_0054;\n\tgoto L_0045;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0045:\n\tv123 = UnityEngine.Application::get_platform();\n\tv77 = v123 != 7;\n\tif (v77) goto L_005B;\nL_0054:\n\tv105 = new GoogleMobileAds.Unity.BannerClient();\n\tGoogleMobileAds.Unity.BannerClient::.ctor(v105);\n\tgoto L_0063;\nL_005B:\n\tv104 = new GoogleMobileAds.Common.DummyClient();\n\tGoogleMobileAds.Common.DummyClient::.ctor(v104);\nL_0063:\n\treturn v112;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IBannerClient BuildBannerClient()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				return new GoogleMobileAds.Android.BannerClient();
			}
			if (Application.platform != RuntimePlatform.OSXEditor)
			{
				RuntimePlatform platform2 = Application.platform;
				if (platform2 != RuntimePlatform.WindowsEditor)
				{
					return new DummyClient();
				}
			}
			return new GoogleMobileAds.Unity.BannerClient();
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x133D1D4", Offset = "0x133D1D4", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Common.DummyClient;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = GoogleMobileAds.Unity.InterstitialClient;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv61 = GoogleMobileAds.Android.InterstitialClient;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3672D]) = v35;\nL_001E:\n\tgoto L_0021;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv46 = UnityEngine.Application::get_platform();\n\tv59 = v46 != 0xB;\n\tif (v59) goto L_0038;\n\tv65 = new GoogleMobileAds.Android.InterstitialClient();\n\tGoogleMobileAds.Android.InterstitialClient::.ctor(v65);\n\tgoto L_0063;\nL_0038:\n\tgoto L_003B;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003B:\n\tv74 = UnityEngine.Application::get_platform();\n\tv75 = v74 == 0;\n\tif (v75) goto L_0054;\n\tgoto L_0045;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0045:\n\tv123 = UnityEngine.Application::get_platform();\n\tv77 = v123 != 7;\n\tif (v77) goto L_005B;\nL_0054:\n\tv105 = new GoogleMobileAds.Unity.InterstitialClient();\n\tGoogleMobileAds.Unity.InterstitialClient::.ctor(v105);\n\tgoto L_0063;\nL_005B:\n\tv104 = new GoogleMobileAds.Common.DummyClient();\n\tGoogleMobileAds.Common.DummyClient::.ctor(v104);\nL_0063:\n\treturn v112;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IInterstitialClient BuildInterstitialClient()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				return new GoogleMobileAds.Android.InterstitialClient();
			}
			if (Application.platform != RuntimePlatform.OSXEditor)
			{
				RuntimePlatform platform2 = Application.platform;
				if (platform2 != RuntimePlatform.WindowsEditor)
				{
					return new DummyClient();
				}
			}
			return new GoogleMobileAds.Unity.InterstitialClient();
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x133D61C", Offset = "0x133D61C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Common.DummyClient;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = GoogleMobileAds.Android.RewardBasedVideoAdClient;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3672E]) = v35;\nL_001B:\n\tgoto L_001E;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = UnityEngine.Application::get_platform();\n\tv58 = v46 != 0xB;\n\tif (v58) goto L_0034;\n\tv62 = new GoogleMobileAds.Android.RewardBasedVideoAdClient();\n\tGoogleMobileAds.Android.RewardBasedVideoAdClient::.ctor(v62);\n\tgoto L_003C;\nL_0034:\n\tv66 = new GoogleMobileAds.Common.DummyClient();\n\tGoogleMobileAds.Common.DummyClient::.ctor(v66);\nL_003C:\n\treturn v71;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IRewardBasedVideoAdClient BuildRewardBasedVideoAdClient()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				return new RewardBasedVideoAdClient();
			}
			return new DummyClient();
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x133DCB4", Offset = "0x133DCB4", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Unity.RewardedAdClient;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = GoogleMobileAds.Android.RewardedAdClient;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv61 = GoogleMobileAds.Common.RewardedAdDummyClient;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3672F]) = v35;\nL_001E:\n\tgoto L_0021;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv46 = UnityEngine.Application::get_platform();\n\tv59 = v46 != 0xB;\n\tif (v59) goto L_0038;\n\tv65 = new GoogleMobileAds.Android.RewardedAdClient();\n\tGoogleMobileAds.Android.RewardedAdClient::.ctor(v65);\n\tgoto L_0063;\nL_0038:\n\tgoto L_003B;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003B:\n\tv74 = UnityEngine.Application::get_platform();\n\tv75 = v74 == 0;\n\tif (v75) goto L_0054;\n\tgoto L_0045;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0045:\n\tv123 = UnityEngine.Application::get_platform();\n\tv77 = v123 != 7;\n\tif (v77) goto L_005B;\nL_0054:\n\tv105 = new GoogleMobileAds.Unity.RewardedAdClient();\n\tGoogleMobileAds.Unity.RewardedAdClient::.ctor(v105);\n\tgoto L_0063;\nL_005B:\n\tv104 = new GoogleMobileAds.Common.RewardedAdDummyClient();\n\tGoogleMobileAds.Common.RewardedAdDummyClient::.ctor(v104);\nL_0063:\n\treturn v112;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IRewardedAdClient BuildRewardedAdClient()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				return new GoogleMobileAds.Android.RewardedAdClient();
			}
			if (Application.platform != RuntimePlatform.OSXEditor)
			{
				RuntimePlatform platform2 = Application.platform;
				if (platform2 != RuntimePlatform.WindowsEditor)
				{
					return new RewardedAdDummyClient();
				}
			}
			return new GoogleMobileAds.Unity.RewardedAdClient();
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x133E0BC", Offset = "0x133E0BC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Unity.RewardedInterstitialAdClient;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = GoogleMobileAds.Android.RewardedInterstitialAdClient;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv61 = GoogleMobileAds.Common.RewardedInterstitialAdDummyClient;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36730]) = v35;\nL_001E:\n\tgoto L_0021;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv46 = UnityEngine.Application::get_platform();\n\tv59 = v46 != 0xB;\n\tif (v59) goto L_0038;\n\tv65 = new GoogleMobileAds.Android.RewardedInterstitialAdClient();\n\tGoogleMobileAds.Android.RewardedInterstitialAdClient::.ctor(v65);\n\tgoto L_0063;\nL_0038:\n\tgoto L_003B;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003B:\n\tv74 = UnityEngine.Application::get_platform();\n\tv75 = v74 == 0;\n\tif (v75) goto L_0054;\n\tgoto L_0045;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0045:\n\tv123 = UnityEngine.Application::get_platform();\n\tv77 = v123 != 7;\n\tif (v77) goto L_005B;\nL_0054:\n\tv105 = new GoogleMobileAds.Unity.RewardedInterstitialAdClient();\n\tGoogleMobileAds.Unity.RewardedInterstitialAdClient::.ctor(v105);\n\tgoto L_0063;\nL_005B:\n\tv104 = new GoogleMobileAds.Common.RewardedInterstitialAdDummyClient();\n\tGoogleMobileAds.Common.RewardedInterstitialAdDummyClient::.ctor(v104);\nL_0063:\n\treturn v112;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IRewardedInterstitialAdClient BuildRewardedInterstitialAdClient()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				return new GoogleMobileAds.Android.RewardedInterstitialAdClient();
			}
			if (Application.platform != RuntimePlatform.OSXEditor)
			{
				RuntimePlatform platform2 = Application.platform;
				if (platform2 != RuntimePlatform.WindowsEditor)
				{
					return new RewardedInterstitialAdDummyClient();
				}
			}
			return new GoogleMobileAds.Unity.RewardedInterstitialAdClient();
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x133E4C4", Offset = "0x133E4C4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = GoogleMobileAds.Android.AdLoaderClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, args, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv44 = UnityEngine.Application;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, args, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv51 = GoogleMobileAds.Common.DummyClient;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, args, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv38 = 1;\n\t*([1A36731]) = v38;\nL_001D:\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, args, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0020:\n\tv49 = UnityEngine.Application::get_platform();\n\tv61 = v49 != 0xB;\n\tif (v61) goto L_0037;\n\tv65 = new GoogleMobileAds.Android.AdLoaderClient();\n\tGoogleMobileAds.Android.AdLoaderClient::.ctor(v65, args);\n\tgoto L_0040;\nL_0037:\n\tv69 = new GoogleMobileAds.Common.DummyClient();\n\tGoogleMobileAds.Common.DummyClient::.ctor(v69);\nL_0040:\n\treturn v76;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAdLoaderClient BuildAdLoaderClient(AdLoaderClientArgs args)
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				return new AdLoaderClient(args);
			}
			return new DummyClient();
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x133EA88", Offset = "0x133EA88", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Common.DummyClient;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = GoogleMobileAds.Android.MobileAdsClient;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36732]) = v35;\nL_001B:\n\tgoto L_001E;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = UnityEngine.Application::get_platform();\n\tv58 = v46 != 0xB;\n\tif (v58) goto L_0049;\n\tgoto L_0036;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0036:\n\tgoto L_0040;\n\tv77 = GoogleMobileAds.Android.MobileAdsClient;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv81 = 1;\n\t*([1A36945]) = v81;\nL_0040:\n\tgoto L_FFFFFFFF;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v82, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv99 = GoogleMobileAds.Android.MobileAdsClient;\n\tgoto L_0051;\nL_0049:\n\tv68 = new GoogleMobileAds.Common.DummyClient();\n\tGoogleMobileAds.Common.DummyClient::.ctor(v68);\nL_0051:\n\treturn v92;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IMobileAdsClient MobileAdsInstance()
		{
			RuntimePlatform platform = Application.platform;
			if (platform != RuntimePlatform.Android)
			{
				return new DummyClient();
			}
			return MobileAdsClient.instance;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x133EB70", Offset = "0x133EB70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GoogleMobileAdsClientFactory()
		{
		}
	}
}
