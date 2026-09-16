using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x730FFC", Offset = "0x730FFC")]
	[Token(Token = "0x200001F")]
	public class Advertising : MonoBehaviour
	{
		[Token(Token = "0x40000FE")]
		private static AdColonyClientImpl sAdColonyClient;

		[Token(Token = "0x40000FF")]
		private static AdMobClientImpl sAdMobClient;

		[Token(Token = "0x4000100")]
		private static AppLovinClientImpl sAppLovinClient;

		[Token(Token = "0x4000101")]
		private static ChartboostClientImpl sChartboostClient;

		[Token(Token = "0x4000102")]
		private static AudienceNetworkClientImpl sAudienceNetworkClient;

		[Token(Token = "0x4000103")]
		private static HeyzapClientImpl sHeyzapClient;

		[Token(Token = "0x4000104")]
		private static MoPubClientImpl sMoPubClient;

		[Token(Token = "0x4000105")]
		private static IronSourceClientImpl sIronSourceClient;

		[Token(Token = "0x4000106")]
		private static TapjoyClientImpl sTapjoyClient;

		[Token(Token = "0x4000107")]
		private static UnityAdsClientImpl sUnityAdsClient;

		[Token(Token = "0x4000108")]
		private static AdClientImpl sDefaultBannerAdClient;

		[Token(Token = "0x4000109")]
		private static AdClientImpl sDefaultInterstitialAdClient;

		[Token(Token = "0x400010A")]
		private static AdClientImpl sDefaultRewardedAdClient;

		[Token(Token = "0x400010B")]
		private const string AD_REMOVE_STATUS_PPKEY = "EM_REMOVE_ADS";

		[Token(Token = "0x400010C")]
		private const int AD_ENABLED = 1;

		[Token(Token = "0x400010D")]
		private const int AD_DISABLED = -1;

		[Token(Token = "0x400010E")]
		private static readonly float DEFAULT_TIMESTAMP = -1000f;

		[Token(Token = "0x400010F")]
		private static IEnumerator autoLoadAdsCoroutine;

		[Token(Token = "0x4000110")]
		private static AutoAdLoadingMode currentAutoLoadAdsMode = default(AutoAdLoadingMode);

		[Token(Token = "0x4000111")]
		private static float lastDefaultInterstitialAdLoadTimestamp = DEFAULT_TIMESTAMP;

		[Token(Token = "0x4000112")]
		private static float lastDefaultRewardedAdLoadTimestamp = DEFAULT_TIMESTAMP;

		[Token(Token = "0x4000113")]
		private static Dictionary<string, float> lastCustomInterstitialAdsLoadTimestamp;

		[Token(Token = "0x4000114")]
		private static Dictionary<string, float> lastCustomRewardedAdsLoadTimestamp;

		[Token(Token = "0x4000115")]
		private static bool isUpdatingAutoLoadMode;

		[Token(Token = "0x4000116")]
		private static Dictionary<AdNetwork, List<AdPlacement>> activeBannerAds;

		[CompilerGenerated]
		[Token(Token = "0x4000117")]
		private static Action<InterstitialAdNetwork, AdPlacement> m_InterstitialAdCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000118")]
		private static Action<RewardedAdNetwork, AdPlacement> m_RewardedAdSkipped;

		[CompilerGenerated]
		[Token(Token = "0x4000119")]
		private static Action<RewardedAdNetwork, AdPlacement> m_RewardedAdCompleted;

		[CompilerGenerated]
		[Token(Token = "0x400011A")]
		private static Action m_AdsRemoved;

		[Token(Token = "0x17000028")]
		[field: Token(Token = "0x40000FD")]
		public static Advertising Instance
		{
			[Token(Token = "0x600009D")]
			[Address(RVA = "0xA46AF4", Offset = "0xA46AF4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEB6F8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021ECA]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Advertising;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600009E")]
			[Address(RVA = "0xA46B5C", Offset = "0xA46B5C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECC8F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021ECB]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Advertising;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000029")]
		public static AdColonyClientImpl AdColonyClient
		{
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0xA47348", Offset = "0xA47348", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBCB98]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021ED4]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sAdColonyClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(1);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sAdColonyClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sAdColonyClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sAdColonyClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.AdColony);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						AdColonyClientImpl adColonyClientImpl = adClientImpl as AdColonyClientImpl;
						adClientImpl2 = ((adColonyClientImpl == null) ? null : adClientImpl);
					}
					sAdColonyClient = (AdColonyClientImpl)adClientImpl2;
				}
				return sAdColonyClient;
			}
		}

		[Token(Token = "0x1700002A")]
		public static AdMobClientImpl AdMobClient
		{
			[Token(Token = "0x60000A8")]
			[Address(RVA = "0xA47520", Offset = "0xA47520", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBD570]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021ED5]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sAdMobClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(2);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sAdMobClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sAdMobClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sAdMobClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.AdMob);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						AdMobClientImpl adMobClientImpl = adClientImpl as AdMobClientImpl;
						adClientImpl2 = ((adMobClientImpl == null) ? null : adClientImpl);
					}
					sAdMobClient = (AdMobClientImpl)adClientImpl2;
				}
				return sAdMobClient;
			}
		}

		[Token(Token = "0x1700002B")]
		public static AppLovinClientImpl AppLovinClient
		{
			[Token(Token = "0x60000A9")]
			[Address(RVA = "0xA47620", Offset = "0xA47620", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA7FD8]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021ED6]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sAppLovinClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(3);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sAppLovinClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sAppLovinClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sAppLovinClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.AppLovin);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						AppLovinClientImpl appLovinClientImpl = adClientImpl as AppLovinClientImpl;
						adClientImpl2 = ((appLovinClientImpl == null) ? null : adClientImpl);
					}
					sAppLovinClient = (AppLovinClientImpl)adClientImpl2;
				}
				return sAppLovinClient;
			}
		}

		[Token(Token = "0x1700002C")]
		public static ChartboostClientImpl ChartboostClient
		{
			[Token(Token = "0x60000AA")]
			[Address(RVA = "0xA47720", Offset = "0xA47720", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF0160]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021ED7]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sChartboostClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(5);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sChartboostClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sChartboostClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sChartboostClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.Chartboost);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						ChartboostClientImpl chartboostClientImpl = adClientImpl as ChartboostClientImpl;
						adClientImpl2 = ((chartboostClientImpl == null) ? null : adClientImpl);
					}
					sChartboostClient = (ChartboostClientImpl)adClientImpl2;
				}
				return sChartboostClient;
			}
		}

		[Token(Token = "0x1700002D")]
		public static AudienceNetworkClientImpl AudienceNetworkClient
		{
			[Token(Token = "0x60000AB")]
			[Address(RVA = "0xA47820", Offset = "0xA47820", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB3A38]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021ED8]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sAudienceNetworkClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(4);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sAudienceNetworkClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sAudienceNetworkClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sAudienceNetworkClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.AudienceNetwork);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						AudienceNetworkClientImpl audienceNetworkClientImpl = adClientImpl as AudienceNetworkClientImpl;
						adClientImpl2 = ((audienceNetworkClientImpl == null) ? null : adClientImpl);
					}
					sAudienceNetworkClient = (AudienceNetworkClientImpl)adClientImpl2;
				}
				return sAudienceNetworkClient;
			}
		}

		[Token(Token = "0x1700002E")]
		public static HeyzapClientImpl HeyzapClient
		{
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0xA47920", Offset = "0xA47920", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC5120]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021ED9]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sHeyzapClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(6);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sHeyzapClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sHeyzapClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sHeyzapClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.Heyzap);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						HeyzapClientImpl heyzapClientImpl = adClientImpl as HeyzapClientImpl;
						adClientImpl2 = ((heyzapClientImpl == null) ? null : adClientImpl);
					}
					sHeyzapClient = (HeyzapClientImpl)adClientImpl2;
				}
				return sHeyzapClient;
			}
		}

		[Token(Token = "0x1700002F")]
		public static MoPubClientImpl MoPubClient
		{
			[Token(Token = "0x60000AD")]
			[Address(RVA = "0xA47A20", Offset = "0xA47A20", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBE750]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EDA]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sMoPubClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(8);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sMoPubClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sMoPubClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sMoPubClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.MoPub);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						MoPubClientImpl moPubClientImpl = adClientImpl as MoPubClientImpl;
						adClientImpl2 = ((moPubClientImpl == null) ? null : adClientImpl);
					}
					sMoPubClient = (MoPubClientImpl)adClientImpl2;
				}
				return sMoPubClient;
			}
		}

		[Token(Token = "0x17000030")]
		public static IronSourceClientImpl IronSourceClient
		{
			[Token(Token = "0x60000AE")]
			[Address(RVA = "0xA47B20", Offset = "0xA47B20", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE9C48]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EDB]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sIronSourceClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(7);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sIronSourceClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sIronSourceClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sIronSourceClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.IronSource);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						IronSourceClientImpl ironSourceClientImpl = adClientImpl as IronSourceClientImpl;
						adClientImpl2 = ((ironSourceClientImpl == null) ? null : adClientImpl);
					}
					sIronSourceClient = (IronSourceClientImpl)adClientImpl2;
				}
				return sIronSourceClient;
			}
		}

		[Token(Token = "0x17000031")]
		public static TapjoyClientImpl TapjoyClient
		{
			[Token(Token = "0x60000AF")]
			[Address(RVA = "0xA47C20", Offset = "0xA47C20", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0D140]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EDC]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sTapjoyClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(9);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sTapjoyClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sTapjoyClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sTapjoyClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.TapJoy);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						TapjoyClientImpl tapjoyClientImpl = adClientImpl as TapjoyClientImpl;
						adClientImpl2 = ((tapjoyClientImpl == null) ? null : adClientImpl);
					}
					sTapjoyClient = (TapjoyClientImpl)adClientImpl2;
				}
				return sTapjoyClient;
			}
		}

		[Token(Token = "0x17000032")]
		public static UnityAdsClientImpl UnityAdsClient
		{
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0xA47D20", Offset = "0xA47D20", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDC530]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EDD]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Advertising;\nL_0021:\n\tv53 = v51.sUnityAdsClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_005D;\n\tgoto L_002F;\n\tv112 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_002F;\n\tv134 = v49;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v134, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv104 = EasyMobile.Advertising::SetupAdClient(0xA);\n\tv106 = v104 == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0059;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tv102.sUnityAdsClient = v99;\nL_005D:\n\tgoto L_006B;\n\tv120 = *([v107 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_006B;\n\tv135 = v107;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v135, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv128 = EasyMobile.Advertising;\nL_006B:\n\treturn v129.sUnityAdsClient;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sUnityAdsClient == null)
				{
					AdClientImpl adClientImpl = SetupAdClient(AdNetwork.UnityAds);
					AdClientImpl adClientImpl2;
					if (adClientImpl == null)
					{
						adClientImpl2 = null;
					}
					else
					{
						UnityAdsClientImpl unityAdsClientImpl = adClientImpl as UnityAdsClientImpl;
						adClientImpl2 = ((unityAdsClientImpl == null) ? null : adClientImpl);
					}
					sUnityAdsClient = (UnityAdsClientImpl)adClientImpl2;
				}
				return sUnityAdsClient;
			}
		}

		[Token(Token = "0x17000033")]
		private static AdClientImpl DefaultBannerAdClient
		{
			[Token(Token = "0x60000B1")]
			[Address(RVA = "0xA47E20", Offset = "0xA47E20", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1ED0B48]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EDE]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv57 = v40;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv52 = EasyMobile.Advertising;\nL_0022:\n\tv55 = v53.sDefaultBannerAdClient == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_006B;\n\tv59 = UnityEngine.Application::get_platform();\n\tv104 = v59 == 8;\n\tif (v104) goto L_0048;\n\tv133 = v59 != 0xB;\n\tif (v133) goto L_005C;\n\tv165 = EasyMobile.EM_Settings::get_Advertising();\n\tv188 = EasyMobile.Advertising;\n\tv191 = *([v188 @ X0_v23 (Il2CppClass<EasyMobile.Advertising>)+12F]) & 2;\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_FFFFFFFF;\n\tgoto L_0064;\nL_0048:\n\tv134 = EasyMobile.EM_Settings::get_Advertising();\n\tgoto L_0064;\n\tgoto L_0064;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v206, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0064;\nL_005C:\n\tgoto L_FFFFFFFF;\n\tv174 = *([v166 @ X0_v19+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_FFFFFFFF;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v166, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0064:\n\tv90 = EasyMobile.Advertising::GetWorkableAdClient(v96);\n\tv88.sDefaultBannerAdClient = v90;\nL_006B:\n\tgoto L_007A;\n\tv109 = *([v93 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tgoto L_007A;\n\tv135 = v93;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v135, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv117 = EasyMobile.Advertising;\nL_007A:\n\treturn v118.sDefaultBannerAdClient;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00d2: Expected I4, but got O
				//IL_0067: Expected I, but got O
				//IL_00df: Expected I4, but got O
				//IL_00b2: Expected I4, but got O
				if (sDefaultBannerAdClient == null)
				{
					AdNetwork network;
					switch (Application.platform)
					{
					case RuntimePlatform.Android:
					{
						AdSettings advertising2 = EM_Settings.Advertising;
						IntPtr intPtr = (IntPtr)typeof(Advertising);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X0_v23 (Il2CppClass<EasyMobile.Advertising>)+12F]");
						AdSettings.DefaultAdNetworks defaultAdNetworks = default(AdSettings.DefaultAdNetworks);
						network = ((0u != 0) ? ((AdNetwork)defaultAdNetworks) : ((AdNetwork)advertising2.mAndroidDefaultAdNetworks));
						break;
					}
					case RuntimePlatform.IPhonePlayer:
					{
						AdSettings advertising = EM_Settings.Advertising;
						network = (AdNetwork)advertising.mIosDefaultAdNetworks;
						break;
					}
					default:
						network = default(AdNetwork);
						break;
					}
					AdClientImpl workableAdClient = GetWorkableAdClient(network);
					sDefaultBannerAdClient = workableAdClient;
				}
				return sDefaultBannerAdClient;
			}
		}

		[Token(Token = "0x17000034")]
		private static AdClientImpl DefaultInterstitialAdClient
		{
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0xA4820C", Offset = "0xA4820C", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F0FE10]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EDF]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv57 = v40;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv52 = EasyMobile.Advertising;\nL_0022:\n\tv55 = v53.sDefaultInterstitialAdClient == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_006B;\n\tv59 = UnityEngine.Application::get_platform();\n\tv104 = v59 == 8;\n\tif (v104) goto L_0048;\n\tv133 = v59 != 0xB;\n\tif (v133) goto L_005C;\n\tv165 = EasyMobile.EM_Settings::get_Advertising();\n\tv188 = EasyMobile.Advertising;\n\tv191 = *([v188 @ X0_v23 (Il2CppClass<EasyMobile.Advertising>)+12F]) & 2;\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_FFFFFFFF;\n\tgoto L_0064;\nL_0048:\n\tv134 = EasyMobile.EM_Settings::get_Advertising();\n\tgoto L_0064;\n\tgoto L_0064;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v206, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0064;\nL_005C:\n\tgoto L_FFFFFFFF;\n\tv174 = *([v166 @ X0_v19+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_FFFFFFFF;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v166, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0064:\n\tv90 = EasyMobile.Advertising::GetWorkableAdClient(v96);\n\tv88.sDefaultInterstitialAdClient = v90;\nL_006B:\n\tgoto L_007A;\n\tv109 = *([v93 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tgoto L_007A;\n\tv135 = v93;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v135, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv117 = EasyMobile.Advertising;\nL_007A:\n\treturn v118.sDefaultInterstitialAdClient;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0067: Expected I, but got O
				if (sDefaultInterstitialAdClient == null)
				{
					AdNetwork network;
					switch (Application.platform)
					{
					case RuntimePlatform.Android:
					{
						AdSettings advertising2 = EM_Settings.Advertising;
						IntPtr intPtr = (IntPtr)typeof(Advertising);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X0_v23 (Il2CppClass<EasyMobile.Advertising>)+12F]");
						InterstitialAdNetwork interstitialAdNetwork = default(InterstitialAdNetwork);
						network = (AdNetwork)((0u != 0) ? interstitialAdNetwork : advertising2.mAndroidDefaultAdNetworks.interstitialAdNetwork);
						break;
					}
					case RuntimePlatform.IPhonePlayer:
					{
						AdSettings advertising = EM_Settings.Advertising;
						network = (AdNetwork)advertising.mIosDefaultAdNetworks.interstitialAdNetwork;
						break;
					}
					default:
						network = default(AdNetwork);
						break;
					}
					AdClientImpl workableAdClient = GetWorkableAdClient(network);
					sDefaultInterstitialAdClient = workableAdClient;
				}
				return sDefaultInterstitialAdClient;
			}
		}

		[Token(Token = "0x17000035")]
		private static AdClientImpl DefaultRewardedAdClient
		{
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0xA48338", Offset = "0xA48338", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EFD030]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EE0]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X8_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv57 = v40;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv52 = EasyMobile.Advertising;\nL_0022:\n\tv55 = v53.sDefaultRewardedAdClient == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_006B;\n\tv59 = UnityEngine.Application::get_platform();\n\tv104 = v59 == 8;\n\tif (v104) goto L_0048;\n\tv133 = v59 != 0xB;\n\tif (v133) goto L_005C;\n\tv165 = EasyMobile.EM_Settings::get_Advertising();\n\tv188 = EasyMobile.Advertising;\n\tv191 = *([v188 @ X0_v23 (Il2CppClass<EasyMobile.Advertising>)+12F]) & 2;\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_FFFFFFFF;\n\tgoto L_0064;\nL_0048:\n\tv134 = EasyMobile.EM_Settings::get_Advertising();\n\tgoto L_0064;\n\tgoto L_0064;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v206, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0064;\nL_005C:\n\tgoto L_FFFFFFFF;\n\tv174 = *([v166 @ X0_v19+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_FFFFFFFF;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v166, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0064:\n\tv90 = EasyMobile.Advertising::GetWorkableAdClient(v96);\n\tv88.sDefaultRewardedAdClient = v90;\nL_006B:\n\tgoto L_007A;\n\tv109 = *([v93 @ X8_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tgoto L_007A;\n\tv135 = v93;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v135, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv117 = EasyMobile.Advertising;\nL_007A:\n\treturn v118.sDefaultRewardedAdClient;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0067: Expected I, but got O
				if (sDefaultRewardedAdClient == null)
				{
					AdNetwork network;
					switch (Application.platform)
					{
					case RuntimePlatform.Android:
					{
						AdSettings advertising2 = EM_Settings.Advertising;
						IntPtr intPtr = (IntPtr)typeof(Advertising);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X0_v23 (Il2CppClass<EasyMobile.Advertising>)+12F]");
						RewardedAdNetwork rewardedAdNetwork = default(RewardedAdNetwork);
						network = (AdNetwork)((0u != 0) ? rewardedAdNetwork : advertising2.mAndroidDefaultAdNetworks.rewardedAdNetwork);
						break;
					}
					case RuntimePlatform.IPhonePlayer:
					{
						AdSettings advertising = EM_Settings.Advertising;
						network = (AdNetwork)advertising.mIosDefaultAdNetworks.rewardedAdNetwork;
						break;
					}
					default:
						network = default(AdNetwork);
						break;
					}
					AdClientImpl workableAdClient = GetWorkableAdClient(network);
					sDefaultRewardedAdClient = workableAdClient;
				}
				return sDefaultRewardedAdClient;
			}
		}

		[Token(Token = "0x17000036")]
		public static ConsentStatus DataPrivacyConsent
		{
			[Token(Token = "0x60000B9")]
			[Address(RVA = "0xA48B44", Offset = "0xA48B44", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.AdvertisingConsentManager::get_Instance();\n\tv9 = *([v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1C0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1C8]);\n\t// 13 IndirectJump v10 @ X2_v1, v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager), v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0016: Expected I, but got O
				//IL_0026: Expected O, but got I
				//IL_0036: Expected O, but got I
				AdvertisingConsentManager instance = AdvertisingConsentManager.Instance;
				IntPtr intPtr = (IntPtr)instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
				return ConsentStatus.Unknown;
			}
		}

		[Token(Token = "0x17000037")]
		public static AutoAdLoadingMode AutoAdLoadingMode
		{
			[Token(Token = "0x60000BF")]
			[Address(RVA = "0xA48ED8", Offset = "0xA48ED8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED9AC0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EE7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Advertising;\nL_0024:\n\treturn v49.currentAutoLoadAdsMode;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return currentAutoLoadAdsMode;
			}
			[Token(Token = "0x60000C0")]
			[Address(RVA = "0xA486A0", Offset = "0xA486A0", Length = "0x228")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F0DAE0]);\n\tv21 = *([v20 @ X8_v52]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021EE8]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = EasyMobile.Advertising;\nL_0027:\n\tv60 = v54.currentAutoLoadAdsMode == value;\n\tif (v60) goto L_00D6;\n\tgoto L_0039;\n\tv107 = *([v50 @ X0_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0039;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv178 = EasyMobile.Advertising;\n\tv115 = *([v178 @ X8_v47+B8]);\nL_0039:\n\tv114.isUpdatingAutoLoadMode = 1;\n\tv116 = EasyMobile.EM_Settings::get_Advertising();\n\tv116.mAutoLoadAdsMode = value;\n\tv180.currentAutoLoadAdsMode = value;\n\tv181.isUpdatingAutoLoadMode = 0;\n\tv184 = v182.autoLoadAdsCoroutine == 0;\n\tif (v184) goto L_0071;\n\tgoto L_0054;\n\tv209 = *([v179 @ X0_v9 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0054;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v179, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0054:\n\tgoto L_005F;\n\tv225 = *([1EB9888]);\n\tv226 = *([v225 @ X8_v44]);\n\tv227 = \"il2cpp_codegen_initialize_method\"(v226, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv230 = 0 | 1;\n\t*([2021FDB]) = v230;\nL_005F:\n\tgoto L_006C;\n\tv252 = *([v231 @ X0_v36 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\t// 99 Jump @b53\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v231, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv256 = EasyMobile.Advertising;\nL_006C:\n\tUnityEngine.MonoBehaviour::StopCoroutine(v191.<Instance>k__BackingField, v191.autoLoadAdsCoroutine);\nL_0071:\n\tv204 = value == 2;\n\tif (v204) goto L_0093;\n\tv70 = value != 1;\n\tif (v70) goto L_00C7;\n\tgoto L_008D;\n\tv259 = *([v235 @ X0_v30 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv260 = v259 == 0;\n\tv261 = ~v260;\n\tif (v261) goto L_008D;\n\tv263 = \"il2cpp_codegen_runtime_class_init\"(v235, v91, v89, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008D:\n\tv273 = EasyMobile.Advertising::CRAutoLoadDefaultAds(0f);\n\tgoto L_009F;\nL_0093:\n\tgoto L_009A;\n\tv243 = *([v220 @ X0_v22 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv244 = v243 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_009A;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v220, v91, v89, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_009A:\n\tv273 = EasyMobile.Advertising::CRAutoLoadAllAds(0f);\nL_009F:\n\tv159.autoLoadAdsCoroutine = v273;\n\tgoto L_00AE;\n\tv284 = *([1EB9888]);\n\tv285 = *([v284 @ X8_v23]);\n\tv286 = \"il2cpp_codegen_initialize_method\"(v285, v91, v89, v25, v26, v27, v28, v29, v120, v31, v32, v33, v34, v35, v36, v37);\n\tv288 = EasyMobile.Advertising;\n\tv290 = 0 | 1;\n\t*([2021FDB]) = v290;\nL_00AE:\n\tgoto L_00C1;\n\tv294 = *([v287 @ X0_v13 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv295 = v294 == 0;\n\tv296 = ~v295;\n\t// 178 Jump @b55\n\tv301 = \"il2cpp_codegen_runtime_class_init\"(v287, v91, v89, v25, v26, v27, v28, v29, v120, v31, v32, v33, v34, v35, v36, v37);\n\tv298 = EasyMobile.Advertising;\nL_00C1:\n\tv162 = UnityEngine.MonoBehaviour::StartCoroutine(v171.<Instance>k__BackingField, v171.autoLoadAdsCoroutine);\n\treturn;\nL_00C7:\n\tgoto L_00CF;\n\tv268 = *([v239 @ X0_v26 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_00CF;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v239, v91, v89, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv271 = EasyMobile.Advertising;\nL_00CF:\n\tv101.autoLoadAdsCoroutine = 0;\nL_00D6:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (currentAutoLoadAdsMode == value)
				{
					return;
				}
				isUpdatingAutoLoadMode = true;
				AdSettings advertising = EM_Settings.Advertising;
				advertising.AutoAdLoadingMode = value;
				currentAutoLoadAdsMode = value;
				isUpdatingAutoLoadMode = false;
				if (autoLoadAdsCoroutine != null)
				{
					Instance.StopCoroutine(autoLoadAdsCoroutine);
				}
				IEnumerator enumerator;
				if (value != AutoAdLoadingMode.LoadAllDefinedPlacements)
				{
					if (value != AutoAdLoadingMode.LoadDefaultAds)
					{
						autoLoadAdsCoroutine = null;
						return;
					}
					enumerator = CRAutoLoadDefaultAds();
				}
				else
				{
					enumerator = CRAutoLoadAllAds();
				}
				autoLoadAdsCoroutine = enumerator;
				Coroutine coroutine = Instance.StartCoroutine(autoLoadAdsCoroutine);
			}
		}

		[Token(Token = "0x14000001")]
		public static event Action<InterstitialAdNetwork, AdPlacement> InterstitialAdCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x600009F")]
			[Address(RVA = "0xA46BC8", Offset = "0xA46BC8", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F01B90]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ECC]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`2<EasyMobile.InterstitialAdNetwork, EasyMobile.AdPlacement>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xB0;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_InterstitialAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<InterstitialAdNetwork, AdPlacement>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 176L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0xA46CB8", Offset = "0xA46CB8", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF4C08]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ECD]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`2<EasyMobile.InterstitialAdNetwork, EasyMobile.AdPlacement>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xB0;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_InterstitialAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<InterstitialAdNetwork, AdPlacement>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 176L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000002")]
		public static event Action<RewardedAdNetwork, AdPlacement> RewardedAdSkipped
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0xA46DA8", Offset = "0xA46DA8", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0E280]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ECE]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xB8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_RewardedAdSkipped;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<RewardedAdNetwork, AdPlacement>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 184L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A2")]
			[Address(RVA = "0xA46E98", Offset = "0xA46E98", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC2C70]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ECF]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xB8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_RewardedAdSkipped;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<RewardedAdNetwork, AdPlacement>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 184L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000003")]
		public static event Action<RewardedAdNetwork, AdPlacement> RewardedAdCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0xA46F88", Offset = "0xA46F88", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED46E8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ED0]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xC0;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_RewardedAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<RewardedAdNetwork, AdPlacement>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 192L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0xA47078", Offset = "0xA47078", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFCBC8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ED1]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xC0;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_RewardedAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<RewardedAdNetwork, AdPlacement>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 192L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000004")]
		public static event Action AdsRemoved
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A5")]
			[Address(RVA = "0xA47168", Offset = "0xA47168", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF85B0]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ED2]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xC8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_AdsRemoved;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 200L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0xA47258", Offset = "0xA47258", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFD658]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021ED3]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Advertising;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Advertising;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0xC8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Advertising.m_AdsRemoved;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 200L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000005")]
		public static event Action<ConsentStatus> DataPrivacyConsentUpdated
		{
			[Token(Token = "0x60000B7")]
			[Address(RVA = "0xA489A4", Offset = "0xA489A4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.AdvertisingConsentManager::get_Instance();\n\tEasyMobile.ConsentManager::add_DataPrivacyConsentUpdated(v10, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				AdvertisingConsentManager instance = AdvertisingConsentManager.Instance;
				instance.DataPrivacyConsentUpdated += value;
			}
			[Token(Token = "0x60000B8")]
			[Address(RVA = "0xA48A74", Offset = "0xA48A74", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.AdvertisingConsentManager::get_Instance();\n\tEasyMobile.ConsentManager::remove_DataPrivacyConsentUpdated(v10, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				AdvertisingConsentManager instance = AdvertisingConsentManager.Instance;
				instance.DataPrivacyConsentUpdated -= value;
			}
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0xA48464", Offset = "0xA48464", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE2720]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021EE1]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tgoto L_0030;\n\tv61 = *([1EB9888]);\n\tv62 = *([v61 @ X8_v28]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = 0 | 1;\n\t*([2021FDB]) = v66;\nL_0030:\n\tgoto L_003F;\n\tv71 = *([v67 @ X0_v5 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003F;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = EasyMobile.Advertising;\nL_003F:\n\tgoto L_0049;\n\tv87 = *([v81 @ X8_v9+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0049;\n\tv98 = v81;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v98, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv97 = UnityEngine.Object::op_Inequality(v80.<Instance>k__BackingField, 0);\n\tv100 = v97 == 0;\n\tif (v100) goto L_0066;\n\tgoto L_0060;\n\tv109 = *([v101 @ X0_v20+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0060;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v101, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_0066:\n\tgoto L_0070;\n\tv124 = *([v105 @ X0_v10+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0070;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v105, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0070:\n\tgoto L_007B;\n\tv136 = *([1EE3568]);\n\tv137 = *([v136 @ X8_v19]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv141 = 0 | 1;\n\t*([2021FDC]) = v141;\nL_007B:\n\tgoto L_0083;\n\tv165 = *([v142 @ X0_v13 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tgoto L_0083;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v142, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv168 = EasyMobile.Advertising;\nL_0083:\n\tv160.<Instance>k__BackingField = this;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0xA485DC", Offset = "0xA485DC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EA5950]);\n\tv15 = *([v14 @ X8_v18]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EE2]) = v35;\nL_0011:\n\tv36 = EasyMobile.EM_Settings::get_Advertising();\n\tv38 = v36.mHeyzap;\n\tv53 = ~v38.mShowTestSuite;\n\tif (v53) goto L_002B;\n\tgoto L_0026;\n\tv70 = *([v62 @ X0_v14 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0026;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0026:\n\tv43 = EasyMobile.Advertising::get_HeyzapClient();\n\tEasyMobile.HeyzapClientImpl::ShowTestSuite(v43);\nL_002B:\n\tv44 = EasyMobile.EM_Settings::get_Advertising();\n\tgoto L_0041;\n\tv98 = *([v95 @ X0_v10+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0041;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v95, v41, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0041:\n\tEasyMobile.Advertising::set_AutoAdLoadingMode(v44.mAutoLoadAdsMode);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			AdSettings advertising = EM_Settings.Advertising;
			HeyzapSettings heyzap = advertising.Heyzap;
			if (heyzap.ShowTestSuite)
			{
				HeyzapClientImpl heyzapClient = HeyzapClient;
				heyzapClient.ShowTestSuite();
				advertising = (AdSettings)(object)heyzapClient;
			}
			AdSettings advertising2 = EM_Settings.Advertising;
			AutoAdLoadingMode = advertising2.AutoAdLoadingMode;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0xA488C8", Offset = "0xA488C8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EC43F0]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EE3]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.Advertising;\nL_0021:\n\tv53 = ~v51.isUpdatingAutoLoadMode;\n\tv54 = ~v53;\n\tif (v54) goto L_0044;\n\tgoto L_0030;\n\tv100 = *([v47 @ X0_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0030;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv145 = EasyMobile.Advertising;\n\tv107 = *([v145 @ X8_v13+B8]);\nL_0030:\n\tv91 = EasyMobile.EM_Settings::get_Advertising();\n\tv62 = v106.currentAutoLoadAdsMode != v91.mAutoLoadAdsMode;\n\tif (v62) goto L_0045;\nL_0044:\n\treturn;\nL_0045:\n\tv148 = EasyMobile.EM_Settings::get_Advertising();\n\tgoto L_005A;\n\tv155 = *([v151 @ X0_v10+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_005A;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v151, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_005A:\n\tEasyMobile.Advertising::set_AutoAdLoadingMode(v148.mAutoLoadAdsMode);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (!isUpdatingAutoLoadMode)
			{
				AdSettings advertising = EM_Settings.Advertising;
				if (currentAutoLoadAdsMode != advertising.AutoAdLoadingMode)
				{
					AdSettings advertising2 = EM_Settings.Advertising;
					AutoAdLoadingMode = advertising2.AutoAdLoadingMode;
				}
			}
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0xA48B68", Offset = "0xA48B68", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.AdvertisingConsentManager::get_Instance();\n\tv9 = *([v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1D0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1D8]);\n\t// 13 IndirectJump v10 @ X2_v1, v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager), v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GrantDataPrivacyConsent()
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			AdvertisingConsentManager instance = AdvertisingConsentManager.Instance;
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1D8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0xA48B8C", Offset = "0xA48B8C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF82C0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EE4]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = EasyMobile.Advertising::GetAdClient(adNetwork);\n\tv55 = *([v53 @ X0_v5 (EasyMobile.AdClientImpl)]);\n\tv58 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6B0]);\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6B8]);\n\t// 43 IndirectJump v58 @ X2_v1, v53 @ X0_v5 (EasyMobile.AdClientImpl), v53 @ X0_v5 (EasyMobile.AdClientImpl), v59 @ X1_v1, v58 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GrantDataPrivacyConsent(AdNetwork adNetwork)
		{
			//IL_001f: Expected I, but got O
			//IL_002f: Expected O, but got I
			//IL_003f: Expected O, but got I
			while (true)
			{
				AdClientImpl adClient = GetAdClient(adNetwork);
				IntPtr intPtr = (IntPtr)adClient;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6B0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6B8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0xA48DBC", Offset = "0xA48DBC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.AdvertisingConsentManager::get_Instance();\n\tv9 = *([v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1E0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1E8]);\n\t// 13 IndirectJump v10 @ X2_v1, v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager), v6 @ X0_v1 (EasyMobile.AdvertisingConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RevokeDataPrivacyConsent()
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			AdvertisingConsentManager instance = AdvertisingConsentManager.Instance;
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.AdvertisingConsentManager>)+1E8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0xA48DE0", Offset = "0xA48DE0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE1588]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EE5]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = EasyMobile.Advertising::GetAdClient(adNetwork);\n\tv55 = *([v53 @ X0_v5 (EasyMobile.AdClientImpl)]);\n\tv58 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6C0]);\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6C8]);\n\t// 43 IndirectJump v58 @ X2_v1, v53 @ X0_v5 (EasyMobile.AdClientImpl), v53 @ X0_v5 (EasyMobile.AdClientImpl), v59 @ X1_v1, v58 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RevokeDataPrivacyConsent(AdNetwork adNetwork)
		{
			//IL_001f: Expected I, but got O
			//IL_002f: Expected O, but got I
			//IL_003f: Expected O, but got I
			while (true)
			{
				AdClientImpl adClient = GetAdClient(adNetwork);
				IntPtr intPtr = (IntPtr)adClient;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0xA48E5C", Offset = "0xA48E5C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB8558]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EE6]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = EasyMobile.Advertising::GetAdClient(adNetwork);\n\tv55 = *([v53 @ X0_v5 (EasyMobile.AdClientImpl)]);\n\tv58 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6A0]);\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6A8]);\n\t// 43 IndirectJump v58 @ X2_v1, v53 @ X0_v5 (EasyMobile.AdClientImpl), v53 @ X0_v5 (EasyMobile.AdClientImpl), v59 @ X1_v1, v58 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ConsentStatus GetDataPrivacyConsent(AdNetwork adNetwork)
		{
			//IL_001f: Expected I, but got O
			//IL_002f: Expected O, but got I
			//IL_003f: Expected O, but got I
			while (true)
			{
				AdClientImpl adClient = GetAdClient(adNetwork);
				IntPtr intPtr = (IntPtr)adClient;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<EasyMobile.AdClientImpl>)+6A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0xA49038", Offset = "0xA49038", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBFB78]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021EE9]) = v42;\nL_001B:\n\tgoto L_0021;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0021;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0021:\n\tv56 = EasyMobile.Advertising::get_DefaultBannerAdClient();\n\tgoto L_0039;\n\tv64 = *([v60 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0039;\n\tv81 = v60;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv72 = EasyMobile.AdPlacement;\nL_0039:\n\tgoto L_004C;\n\tv82 = *([v76 @ X0_v6 (Il2CppClass<EasyMobile.BannerAdSize>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_004C;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v76, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv86 = EasyMobile.BannerAdSize;\nL_004C:\n\tEasyMobile.Advertising::ShowBannerAd(v56, v75.Default, position, v89.SmartBanner);\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowBannerAd(BannerAdPosition position)
		{
			AdClientImpl defaultBannerAdClient = DefaultBannerAdClient;
			ShowBannerAd(defaultBannerAdClient, AdPlacement.Default, position, BannerAdSize.SmartBanner);
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0xA492E4", Offset = "0xA492E4", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EEC058]);\n\tv25 = *([v24 @ X8_v13]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, size, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021EEA]) = v43;\nL_001C:\n\tgoto L_0022;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, size, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0022:\n\tv57 = EasyMobile.Advertising::get_DefaultBannerAdClient();\n\tgoto L_003E;\n\tv65 = *([v61 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003E;\n\tv85 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v85, size, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv73 = EasyMobile.AdPlacement;\nL_003E:\n\tEasyMobile.Advertising::ShowBannerAd(v57, v74.Default, position, size);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowBannerAd(BannerAdPosition position, BannerAdSize size)
		{
			AdClientImpl defaultBannerAdClient = DefaultBannerAdClient;
			ShowBannerAd(defaultBannerAdClient, AdPlacement.Default, position, size);
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0xA49394", Offset = "0xA49394", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC4358]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, position, size, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021EEB]) = v44;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, position, size, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tv59 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tgoto L_0040;\n\tv67 = *([v63 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0040;\n\tv87 = v63;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v87, position, size, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv75 = EasyMobile.AdPlacement;\nL_0040:\n\tEasyMobile.Advertising::ShowBannerAd(v59, v76.Default, position, size);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowBannerAd(BannerAdNetwork adNetwork, BannerAdPosition position, BannerAdSize size)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			ShowBannerAd(workableAdClient, AdPlacement.Default, position, size);
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0xA4944C", Offset = "0xA4944C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EB7698]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, placement, position, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021EEC]) = v47;\nL_001F:\n\tgoto L_0026;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0026;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, placement, position, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0026:\n\tv62 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tEasyMobile.Advertising::ShowBannerAd(v62, placement, position, size);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowBannerAd(BannerAdNetwork adNetwork, AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			ShowBannerAd(workableAdClient, placement, position, size);
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0xA494DC", Offset = "0xA494DC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EDC0C0]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EED]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultBannerAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv75 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v75, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\tEasyMobile.Advertising::HideBannerAd(v51, v68.Default);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void HideBannerAd()
		{
			AdClientImpl defaultBannerAdClient = DefaultBannerAdClient;
			HideBannerAd(defaultBannerAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0xA496CC", Offset = "0xA496CC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEE470]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EEE]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tEasyMobile.Advertising::HideBannerAd(v56, placement);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void HideBannerAd(BannerAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			HideBannerAd(workableAdClient, placement);
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0xA49744", Offset = "0xA49744", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EAA0F0]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EEF]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultBannerAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv75 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v75, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\tEasyMobile.Advertising::DestroyBannerAd(v51, v68.Default);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DestroyBannerAd()
		{
			AdClientImpl defaultBannerAdClient = DefaultBannerAdClient;
			DestroyBannerAd(defaultBannerAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0xA49934", Offset = "0xA49934", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA40F0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EF0]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tEasyMobile.Advertising::DestroyBannerAd(v56, placement);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DestroyBannerAd(BannerAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			DestroyBannerAd(workableAdClient, placement);
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0xA499AC", Offset = "0xA499AC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EB21F8]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EF1]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultInterstitialAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv75 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v75, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\tEasyMobile.Advertising::LoadInterstitialAd(v51, v68.Default);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadInterstitialAd()
		{
			AdClientImpl defaultInterstitialAdClient = DefaultInterstitialAdClient;
			LoadInterstitialAd(defaultInterstitialAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0xA49B40", Offset = "0xA49B40", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0A930]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EF2]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Advertising::get_DefaultInterstitialAdClient();\n\tEasyMobile.Advertising::LoadInterstitialAd(v52, placement);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadInterstitialAd(AdPlacement placement)
		{
			AdClientImpl defaultInterstitialAdClient = DefaultInterstitialAdClient;
			LoadInterstitialAd(defaultInterstitialAdClient, placement);
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0xA49BA8", Offset = "0xA49BA8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F09D50]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EF3]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tEasyMobile.Advertising::LoadInterstitialAd(v56, placement);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadInterstitialAd(InterstitialAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			LoadInterstitialAd(workableAdClient, placement);
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0xA49C20", Offset = "0xA49C20", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EAD780]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EF4]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultInterstitialAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv76 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v76, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\treturnVal1 = EasyMobile.Advertising::IsInterstitialAdReady(v51, v68.Default);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInterstitialAdReady()
		{
			AdClientImpl defaultInterstitialAdClient = DefaultInterstitialAdClient;
			return IsInterstitialAdReady(defaultInterstitialAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0xA49DB8", Offset = "0xA49DB8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F10A40]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EF5]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Advertising::get_DefaultInterstitialAdClient();\n\treturnVal1 = EasyMobile.Advertising::IsInterstitialAdReady(v52, placement);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInterstitialAdReady(AdPlacement placement)
		{
			AdClientImpl defaultInterstitialAdClient = DefaultInterstitialAdClient;
			return IsInterstitialAdReady(defaultInterstitialAdClient, placement);
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0xA49E20", Offset = "0xA49E20", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC5AB8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EF6]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\treturnVal1 = EasyMobile.Advertising::IsInterstitialAdReady(v56, placement);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInterstitialAdReady(InterstitialAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			return IsInterstitialAdReady(workableAdClient, placement);
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0xA49E98", Offset = "0xA49E98", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EF1650]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EF7]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultInterstitialAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv75 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v75, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\tEasyMobile.Advertising::ShowInterstitialAd(v51, v68.Default);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowInterstitialAd()
		{
			AdClientImpl defaultInterstitialAdClient = DefaultInterstitialAdClient;
			ShowInterstitialAd(defaultInterstitialAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0xA4A05C", Offset = "0xA4A05C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDB900]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EF8]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Advertising::get_DefaultInterstitialAdClient();\n\tEasyMobile.Advertising::ShowInterstitialAd(v52, placement);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowInterstitialAd(AdPlacement placement)
		{
			AdClientImpl defaultInterstitialAdClient = DefaultInterstitialAdClient;
			ShowInterstitialAd(defaultInterstitialAdClient, placement);
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0xA4A0C4", Offset = "0xA4A0C4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF7DB0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EF9]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tEasyMobile.Advertising::ShowInterstitialAd(v56, placement);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowInterstitialAd(InterstitialAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			ShowInterstitialAd(workableAdClient, placement);
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0xA4A13C", Offset = "0xA4A13C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EB07B8]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EFA]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultRewardedAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv75 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v75, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\tEasyMobile.Advertising::LoadRewardedAd(v51, v68.Default);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadRewardedAd()
		{
			AdClientImpl defaultRewardedAdClient = DefaultRewardedAdClient;
			LoadRewardedAd(defaultRewardedAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0xA4A298", Offset = "0xA4A298", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE4220]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EFB]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Advertising::get_DefaultRewardedAdClient();\n\tEasyMobile.Advertising::LoadRewardedAd(v52, placement);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadRewardedAd(AdPlacement placement)
		{
			AdClientImpl defaultRewardedAdClient = DefaultRewardedAdClient;
			LoadRewardedAd(defaultRewardedAdClient, placement);
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0xA4A300", Offset = "0xA4A300", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F042A8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EFC]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tEasyMobile.Advertising::LoadRewardedAd(v56, placement);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadRewardedAd(RewardedAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			LoadRewardedAd(workableAdClient, placement);
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xA4A378", Offset = "0xA4A378", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EDAF88]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EFD]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultRewardedAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv76 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v76, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\treturnVal1 = EasyMobile.Advertising::IsRewardedAdReady(v51, v68.Default);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRewardedAdReady()
		{
			AdClientImpl defaultRewardedAdClient = DefaultRewardedAdClient;
			return IsRewardedAdReady(defaultRewardedAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xA4A4D4", Offset = "0xA4A4D4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC54A0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EFE]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Advertising::get_DefaultRewardedAdClient();\n\treturnVal1 = EasyMobile.Advertising::IsRewardedAdReady(v52, placement);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRewardedAdReady(AdPlacement placement)
		{
			AdClientImpl defaultRewardedAdClient = DefaultRewardedAdClient;
			return IsRewardedAdReady(defaultRewardedAdClient, placement);
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0xA4A53C", Offset = "0xA4A53C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE6D38]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EFF]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\treturnVal1 = EasyMobile.Advertising::IsRewardedAdReady(v56, placement);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRewardedAdReady(RewardedAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			return IsRewardedAdReady(workableAdClient, placement);
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0xA4A5B4", Offset = "0xA4A5B4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F04400]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F00]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = EasyMobile.Advertising::get_DefaultRewardedAdClient();\n\tgoto L_0036;\n\tv59 = *([v55 @ X8_v7 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0036;\n\tv75 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v75, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = EasyMobile.AdPlacement;\nL_0036:\n\tEasyMobile.Advertising::ShowRewardedAd(v51, v68.Default);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowRewardedAd()
		{
			AdClientImpl defaultRewardedAdClient = DefaultRewardedAdClient;
			ShowRewardedAd(defaultRewardedAdClient, AdPlacement.Default);
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xA4A710", Offset = "0xA4A710", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F005E8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F01]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Advertising::get_DefaultRewardedAdClient();\n\tEasyMobile.Advertising::ShowRewardedAd(v52, placement);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowRewardedAd(AdPlacement placement)
		{
			AdClientImpl defaultRewardedAdClient = DefaultRewardedAdClient;
			ShowRewardedAd(defaultRewardedAdClient, placement);
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xA4A778", Offset = "0xA4A778", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE05C0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F02]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.Advertising::GetWorkableAdClient(adNetwork);\n\tEasyMobile.Advertising::ShowRewardedAd(v56, placement);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowRewardedAd(RewardedAdNetwork adNetwork, AdPlacement placement)
		{
			AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)adNetwork);
			ShowRewardedAd(workableAdClient, placement);
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0xA4A7F0", Offset = "0xA4A7F0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EA8870]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F03]) = v35;\nL_0016:\n\tv41 = EasyMobile.Internal.StorageUtil::GetInt(\"EM_REMOVE_ADS\", 1);\n\tv44 = v41 + 1;\n\tv46 = v44 == 0;\n\treturn v46;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsAdRemoved()
		{
			int num = StorageUtil.GetInt("EM_REMOVE_ADS", 1);
			int num2 = num + 1;
			return num2 == 0;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0xA4A84C", Offset = "0xA4A84C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECCE80]);\n\tv19 = *([v18 @ X8_v31]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F04]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tEasyMobile.Advertising::DestroyAllBannerAds();\n\tv53 = revokeConsents == 0;\n\tif (v53) goto L_0034;\n\tgoto L_002D;\n\tv69 = *([v54 @ X0_v22 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_002D;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tEasyMobile.Advertising::RevokeAllNetworksDataPrivacyConsent();\n\tEasyMobile.Advertising::RevokeDataPrivacyConsent();\nL_0034:\n\tEasyMobile.Internal.StorageUtil::SetInt(\"EM_REMOVE_ADS\", 0xFFFFFFFF);\n\tEasyMobile.Internal.StorageUtil::Save();\n\tgoto L_0044;\n\tv78 = *([v74 @ X0_v7 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0044;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v74, v66, v67, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv82 = EasyMobile.Advertising;\nL_0044:\n\tv87 = v85.AdsRemoved == 0;\n\tif (v87) goto L_005D;\n\tgoto L_0056;\n\tv109 = *([v81 @ X0_v8 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0056;\n\tv131 = EasyMobile.Advertising;\n\tv132 = *([v131 @ X8_v21 (Il2CppClass<EasyMobile.Advertising>)+B8]);\n\tv115 = v132.AdsRemoved;\nL_0056:\n\tSystem.Action::Invoke(v85.AdsRemoved);\nL_005D:\n\tgoto L_006C;\n\tv116 = *([v105 @ X0_v10+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_006C;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v105, v95, v67, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_006C:\n\tUnityEngine.Debug::Log(\"Ads were removed.\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoveAds(bool revokeConsents = false)
		{
			DestroyAllBannerAds();
			if (revokeConsents)
			{
				RevokeAllNetworksDataPrivacyConsent();
				RevokeDataPrivacyConsent();
			}
			StorageUtil.SetInt("EM_REMOVE_ADS", -1);
			StorageUtil.Save();
			if (Advertising.AdsRemoved != null)
			{
				Advertising.AdsRemoved();
			}
			Debug.Log("Ads were removed.");
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0xA4AF38", Offset = "0xA4AF38", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1ED5C20]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F05]) = v35;\nL_0016:\n\tEasyMobile.Internal.StorageUtil::SetInt(\"EM_REMOVE_ADS\", 1);\n\tEasyMobile.Internal.StorageUtil::Save();\n\tgoto L_002D;\n\tv48 = *([v44 @ X0_v4+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002D;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v38, v39, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002D:\n\tUnityEngine.Debug::Log(\"Ads were re-enabled.\");\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ResetRemoveAds()
		{
			StorageUtil.SetInt("EM_REMOVE_ADS", 1);
			StorageUtil.Save();
			Debug.Log("Ads were re-enabled.");
		}

		[Obsolete]
		[Token(Token = "0x60000DE")]
		[Address(RVA = "0xA4AFC4", Offset = "0xA4AFC4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Advertising();\n\tv12 = v6.mAutoLoadAdsMode - 1;\n\tv14 = v12 == 0;\n\treturn v14;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsAutoLoadDefaultAds()
		{
			AdSettings advertising = EM_Settings.Advertising;
			int num = (int)(advertising.AutoAdLoadingMode - 1);
			return num == 0;
		}

		[Obsolete]
		[Token(Token = "0x60000DF")]
		[Address(RVA = "0xA4AFEC", Offset = "0xA4AFEC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.EM_Settings::get_Advertising();\n\tv10.mAutoLoadAdsMode = isAutoLoad;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EnableAutoLoadDefaultAds(bool isAutoLoad)
		{
			AdSettings advertising = EM_Settings.Advertising;
			advertising.AutoAdLoadingMode = (isAutoLoad ? AutoAdLoadingMode.LoadDefaultAds : AutoAdLoadingMode.None);
		}

		[Obsolete]
		[Token(Token = "0x60000E0")]
		[Address(RVA = "0xA4B01C", Offset = "0xA4B01C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDADA0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F06]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tEasyMobile.Advertising::EnableAutoLoadDefaultAds(isAutoLoad);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAutoLoadDefaultAds(bool isAutoLoad)
		{
			EnableAutoLoadDefaultAds(isAutoLoad);
		}

		[Obsolete]
		[Token(Token = "0x60000E1")]
		[Address(RVA = "0xA4B080", Offset = "0xA4B080", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE2320]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F07]) = v41;\nL_0016:\n\tv43 = EasyMobile.AdLocationExtension::ToAdPlacement(location);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv65 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v65, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tEasyMobile.Advertising::LoadInterstitialAd(adNetwork, v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadInterstitialAd(InterstitialAdNetwork adNetwork, AdLocation location)
		{
			AdPlacement placement = location.ToAdPlacement();
			LoadInterstitialAd(adNetwork, placement);
		}

		[Obsolete]
		[Token(Token = "0x60000E2")]
		[Address(RVA = "0xA4B104", Offset = "0xA4B104", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB0CB0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F08]) = v41;\nL_0016:\n\tv43 = EasyMobile.AdLocationExtension::ToAdPlacement(location);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv66 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v66, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\treturnVal1 = EasyMobile.Advertising::IsInterstitialAdReady(adNetwork, v43);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInterstitialAdReady(InterstitialAdNetwork adNetwork, AdLocation location)
		{
			AdPlacement placement = location.ToAdPlacement();
			return IsInterstitialAdReady(adNetwork, placement);
		}

		[Obsolete]
		[Token(Token = "0x60000E3")]
		[Address(RVA = "0xA4B188", Offset = "0xA4B188", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDEAB0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F09]) = v41;\nL_0016:\n\tv43 = EasyMobile.AdLocationExtension::ToAdPlacement(location);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv65 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v65, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tEasyMobile.Advertising::ShowInterstitialAd(adNetwork, v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowInterstitialAd(InterstitialAdNetwork adNetwork, AdLocation location)
		{
			AdPlacement placement = location.ToAdPlacement();
			ShowInterstitialAd(adNetwork, placement);
		}

		[Obsolete]
		[Token(Token = "0x60000E4")]
		[Address(RVA = "0xA4B20C", Offset = "0xA4B20C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA8B10]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F0A]) = v41;\nL_0016:\n\tv43 = EasyMobile.AdLocationExtension::ToAdPlacement(location);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv65 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v65, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tEasyMobile.Advertising::LoadRewardedAd(adNetwork, v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadRewardedAd(RewardedAdNetwork adNetwork, AdLocation location)
		{
			AdPlacement placement = location.ToAdPlacement();
			LoadRewardedAd(adNetwork, placement);
		}

		[Obsolete]
		[Token(Token = "0x60000E5")]
		[Address(RVA = "0xA4B290", Offset = "0xA4B290", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB6A68]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F0B]) = v41;\nL_0016:\n\tv43 = EasyMobile.AdLocationExtension::ToAdPlacement(location);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv66 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v66, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\treturnVal1 = EasyMobile.Advertising::IsRewardedAdReady(adNetwork, v43);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRewardedAdReady(RewardedAdNetwork adNetwork, AdLocation location)
		{
			AdPlacement placement = location.ToAdPlacement();
			return IsRewardedAdReady(adNetwork, placement);
		}

		[Obsolete]
		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xA4B314", Offset = "0xA4B314", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ECE978]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F0C]) = v41;\nL_0016:\n\tv43 = EasyMobile.AdLocationExtension::ToAdPlacement(location);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv65 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v65, location, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tEasyMobile.Advertising::ShowRewardedAd(adNetwork, v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowRewardedAd(RewardedAdNetwork adNetwork, AdLocation location)
		{
			AdPlacement placement = location.ToAdPlacement();
			ShowRewardedAd(adNetwork, placement);
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7343D8", Offset = "0x7343D8")]
		[Token(Token = "0x60000E7")]
		[Address(RVA = "0xA48F40", Offset = "0xA48F40", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBEB50]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, delay, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021F0D]) = v38;\nL_0016:\n\tv42 = new EasyMobile.Advertising+<CRAutoLoadDefaultAds>d__121();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.delay = delay;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IEnumerator CRAutoLoadDefaultAds(float delay = 0f)
		{
			_003CCRAutoLoadDefaultAds_003Ed__121 _003CCRAutoLoadDefaultAds_003Ed__122 = null;
			_003CCRAutoLoadDefaultAds_003Ed__122._003C_003E1__state = 0;
			_003CCRAutoLoadDefaultAds_003Ed__122.delay = delay;
			return _003CCRAutoLoadDefaultAds_003Ed__122;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x73443C", Offset = "0x73443C")]
		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xA48FBC", Offset = "0xA48FBC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC64C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, delay, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021F0E]) = v38;\nL_0016:\n\tv42 = new EasyMobile.Advertising+<CRAutoLoadAllAds>d__122();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.delay = delay;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IEnumerator CRAutoLoadAllAds(float delay = 0f)
		{
			_003CCRAutoLoadAllAds_003Ed__122 _003CCRAutoLoadAllAds_003Ed__123 = null;
			_003CCRAutoLoadAllAds_003Ed__123._003C_003E1__state = 0;
			_003CCRAutoLoadAllAds_003Ed__123.delay = delay;
			return _003CCRAutoLoadAllAds_003Ed__123;
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xA4B3F0", Offset = "0xA4B3F0", Length = "0x6FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = &v25 @ X29;\n\tgoto L_001F;\n\tv37 = *([1ED9928]);\n\tv38 = *([v37 @ X8_v109]);\n\tv39 = \"il2cpp_codegen_initialize_method\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2021F0F]) = v57;\nL_001F:\n\t*([v25 @ X29-78]) = 0;\n\t*([v25 @ X29-70]) = 0;\n\t*([v25 @ X29-80]) = 0;\n\t*([v25 @ X29-98]) = 0;\n\t*([v25 @ X29-90]) = 0;\n\t*([v25 @ X29-A0]) = 0;\n\t*([v25 @ X29-A4]) = 0;\n\t*([v25 @ X29-C8]) = &v59 @ stack_-F0;\n\tgoto L_0034;\n\tv67 = *([v63 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_0034;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_0034:\n\tv74 = EasyMobile.Advertising::IsAdRemoved();\n\tv76 = v74 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0285;\n\tv215 = System.Collections.Generic.List`1<EasyMobile.IAdClient>::GetEnumerator(clients);\n\tv263 = *([v25 @ X29-C0]);\n\t*([v25 @ X29-70]) = *([v25 @ X29-B0]);\n\t*([v25 @ X29-80]) = *([v25 @ X29-C0]);\nL_0050:\n\tv508 = &v25 @ X29 - 0x80;\n\tv509 = System.Collections.Generic.List`1<EasyMobile.IAdClient>+Enumerator<EasyMobile.IAdClient>::MoveNext(v508);\n\tv511 = v509 == 0;\n\tif (v511) goto L_022F;\n\tv281 = *([v25 @ X29-70]);\n\tv552 = *([v281 @ X20_v9 (EasyMobile.IAdClient)]);\n\tv555 = *([v552 @ X8_v27 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v555) goto L_007A;\n\tv634 = *([v552 @ X8_v27 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_0065:\n\tv639 = *([v634 @ X11_v25-8]) == EasyMobile.IAdClient;\n\tif (v639) goto L_007D;\n\tv633 = v633 + 1;\n\tv659 = v633 < *([v552 @ X8_v27 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv592 = ~v659;\n\tv634 = v634 + 0x10;\n\tv576 = ~v592;\n\tif (v576) goto L_0065;\nL_007A:\n\tv665 = 0x8909C4(v281, EasyMobile.IAdClient, 0x20, *([v859 @ X0_v50+8]), v43, v44, v45, v46, v263, v362, v49, v50, v51, v52, v53, v54);\n\tgoto L_0084;\nL_007D:\n\tv661 = *([v634 @ X11_v25]) + 0x20;\n\tv662 = v661 << 4;\n\tv663 = v552 + v662;\n\tv665 = v663 + 0x130;\nL_0084:\n\t*([v665 @ X0_v32])(v670, v281, *([v665 @ X0_v32+8]), v603, *([v859 @ X0_v50+8]), v43, v44, v45, v46, v263, v362, v49, v50, v51, v52, v53, v54);\n\tv672 = v670 == 0;\n\tv673 = ~v672;\n\tif (v673) goto L_0097;\n\tv683 = new System.Collections.Generic.List`1<EasyMobile.AdPlacement>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::.ctor(v683);\nL_0097:\n\tgoto L_00A6;\n\tv695 = *([v690 @ X0_v36+E0]);\n\tv696 = v695 == 0;\n\tv697 = ~v696;\n\t// 155 ConditionalJump @b25, v697 @ TEMP_v94\n\tv698 = \"il2cpp_codegen_runtime_class_init\"(v690, v616, v603, v217, v43, v44, v45, v46, v263, v221, v49, v50, v51, v52, v53, v54);\nL_00A6:\n\tv707 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::Contains(v601, v701.Default);\n\tv709 = v707 == 0;\n\tv710 = ~v709;\n\tif (v710) goto L_00C2;\n\tgoto L_00BC;\n\tv731 = *([v711 @ X0_v112 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv732 = v731 == 0;\n\tv733 = ~v732;\n\tif (v733) goto L_00BC;\n\tv741 = \"il2cpp_codegen_runtime_class_init\"(v711, v702, v705, v217, v43, v44, v45, v46, v263, v221, v49, v50, v51, v52, v53, v54);\n\tv735 = EasyMobile.AdPlacement;\nL_00BC:\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::Add(v601, v737.Default);\nL_00C2:\n\tv730 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::GetEnumerator(v601);\n\tv263 = *([v25 @ X29-C0]);\n\t*([v25 @ X29-90]) = *([v25 @ X29-B0]);\n\t*([v25 @ X29-A0]) = *([v25 @ X29-C0]);\nL_00C8:\n\tv785 = &v25 @ X29 - 0xA0;\n\tv786 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>+Enumerator<EasyMobile.AdPlacement>::MoveNext(v785);\n\tv788 = v786 == 0;\n\tif (v788) goto L_01CC;\n\tv789 = *([v281 @ X20_v9 (EasyMobile.IAdClient)]);\n\tv792 = *([v789 @ X8_v51 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v792) goto L_00F0;\n\tv838 = *([v789 @ X8_v51 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_00DB:\n\tv843 = *([v838 @ X11_v20-8]) == EasyMobile.IAdClient;\n\tif (v843) goto L_00F3;\n\tv837 = v837 + 1;\n\tv852 = v837 < *([v789 @ X8_v51 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv816 = ~v852;\n\tv838 = v838 + 0x10;\n\tv800 = ~v816;\n\tif (v800) goto L_00DB;\nL_00F0:\n\tv859 = 0x8909C4(v281, EasyMobile.IAdClient, 7, *([v859 @ X0_v50+8]), v43, v44, v45, v46, v263, v362, v49, v50, v51, v52, v53, v54);\n\tgoto L_00FC;\nL_00F3:\n\tv854 = *([v838 @ X11_v20]) + 7;\n\tv855 = v854 << 4;\n\tv856 = v789 + v855;\n\tv859 = v856 + 0x130;\nL_00FC:\n\t*([v859 @ X0_v50])(v776, v281, *([v25 @ X29-90]), 1, *([v859 @ X0_v50+8]), v43, v44, v45, v46, v263, v362, v49, v50, v51, v52, v53, v54);\n\tv862 = v776 & 1;\n\tv779 = v862 == 0;\n\tif (v779) goto L_00C8;\n\tgoto L_012B;\n\tv872 = *([v866 @ X8_v54+B0]);\n\tv873 = 0;\n\tv874 = v872 + 8;\n\tv876 = *([v913 @ X11_v15-8]);\n\tv918 = v876 == v867;\n\tif (v918) goto L_0124;\n\tv896 = v912 + 1;\n\tv923 = v896 < v868;\n\tv894 = ~v923;\n\tv898 = v913 + 0x10;\n\tv878 = ~v894;\n\tif (v878) goto L_FFFFFFFF;\n\tv899 = v281;\n\tv900 = 0;\n\tv901 = 0x8909C4(v899, v867, v900, v360, v43, v44, v45, v46, v412, v362, v49, v50, v51, v52, v53, v54);\n\tgoto L_012B;\nL_0124:\n\tv924 = *([v913 @ X11_v15]);\n\tv925 = v924 << 4;\n\tv926 = v866 + v925;\n\tv927 = v926 + 0x130;\nL_012B:\n\tv933 = EasyMobile.IAdClient::get_Network(v281);\n\t*([v25 @ X29-A4]) = v933;\n\tv416 = &v25 @ X29 - 0xA4;\n\t// 306 Box v937 @ X0_v57, typeof(EasyMobile.AdNetwork), v416 @ X1_v28\n\tv431 = v937 == 0;\n\tif (v431) goto L_01D3;\n\tv938 = *([v937 @ X0_v57]);\n\t*([v938 @ X8_v60+160])(v940, v937, *([v938 @ X8_v60+168]), 0, *([v859 @ X0_v50+8]), v43, v44, v45, v46, v263, v362, v49, v50, v51, v52, v53, v54);\n\tv942 = \"il2cpp_vm_object_unbox\"(v937, *([v938 @ X8_v60+168]), 0, *([v859 @ X0_v50+8]), v43, v44, v45, v46, v263, v362, v49, v50, v51, v52, v53, v54);\n\t*([v25 @ X29-A4]) = *([v942 @ X0_v63]);\n\tv432 = *([v25 @ X29-90]) == 0;\n\tif (v432) goto L_01D6;\n\tv947 = EasyMobile.AdPlacement::ToString(*([v25 @ X29-90]));\n\tv950 = System.String::Concat(v940, v947);\n\tgoto L_0158;\n\tv956 = *([v952 @ X0_v70+E0]);\n\tv957 = v956 == 0;\n\tv958 = ~v957;\n\tif (v958) goto L_0158;\n\tv960 = \"il2cpp_codegen_runtime_class_init\"(v952, v948, v377, v360, v43, v44, v45, v46, v412, v362, v49, v50, v51, v52, v53, v54);\nL_0158:\n\tv773 = EasyMobile.Advertising::IsInterstitialAdReady(v281, *([v25 @ X29-90]));\n\tv964 = v773 == 0;\n\tv778 = ~v964;\n\tif (v778) goto L_00C8;\n\tgoto L_016A;\n\tv969 = *([v965 @ X0_v74 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv970 = v969 == 0;\n\tv971 = ~v970;\n\tif (v971) goto L_016A;\n\tv977 = \"il2cpp_codegen_runtime_class_init\"(v965, v418, v377, v360, v43, v44, v45, v46, v412, v362, v49, v50, v51, v52, v53, v54);\n\tv973 = EasyMobile.Advertising;\nL_016A:\n\tv433 = v441.lastCustomInterstitialAdsLoadTimestamp == 0;\n\tif (v433) goto L_01D8;\n\tv980 = System.Collections.Generic.Dictionary`2<System.String, System.Single>::ContainsKey(v441.lastCustomInterstitialAdsLoadTimestamp, v950);\n\tv982 = v980 == 0;\n\tv983 = ~v982;\n\tif (v983) goto L_018B;\n\tgoto L_0182;\n\tv998 = *([v984 @ X0_v97 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv999 = v998 == 0;\n\tv1000 = ~v999;\n\tif (v1000) goto L_0182;\n\tv1009 = \"il2cpp_codegen_runtime_class_init\"(v984, v421, v380, v360, v43, v44, v45, v46, v412, v362, v49, v50, v51, v52, v53, v54);\n\tv1002 = EasyMobile.Advertising;\nL_0182:\n\tv436 = v444.lastCustomInterstitialAdsLoadTimestamp == 0;\n\tif (v436) goto L_01DE;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Single>::Add(v444.lastCustomInterstitialAdsLoadTimestamp, v950, v444.DEFAULT_TIMESTAMP);\nL_018B:\n\tv413 = UnityEngine.Time::get_realtimeSinceStartup();\n\tgoto L_019A;\n\tv1011 = *([v1005 @ X0_v81 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv1012 = v1011 == 0;\n\tv1013 = ~v1012;\n\tif (v1013) goto L_019A;\n\tv1019 = \"il2cpp_codegen_runtime_class_init\"(v1005, v419, v378, v360, v43, v44, v45, v46, v413, v362, v49, v50, v51, v52, v53, v54);\n\tv1015 = EasyMobile.Advertising;\nL_019A:\n\tv434 = v442.lastCustomInterstitialAdsLoadTimestamp == 0;\n\tif (v434) goto L_01DA;\n\tv414 = System.Collections.Generic.Dictionary`2<System.String, System.Single>::get_Item(v442.lastCustomInterstitialAdsLoadTimestamp, v950);\n\tv774 = EasyMobile.EM_Settings::get_Advertising();\n\tv435 = v774 == 0;\n\tif (v435) goto L_01DC;\n\tv263 = v774.mAdLoadingInterval;\n\tv362 = v413 - v414;\n\tv400 = v362 < v774.mAdLoadingInterval;\n\tif (v400) goto L_00C8;\n\tgoto L_0\n// ... truncated")]
		private unsafe static void LoadAllInterstitialAds(List<IAdClient> clients)
		{
			//IL_005b: Expected F4, but got I
			//IL_0082: Expected O, but got I8
			//IL_0b61: Expected O, but got I
			//IL_082a: Expected O, but got I
			//IL_0839: Expected O, but got I
			//IL_0879: Expected O, but got I
			//IL_0891: Expected O, but got I
			//IL_00a0: Expected O, but got I
			//IL_00ad: Expected I, but got O
			//IL_00e8: Expected O, but got I
			//IL_08db: Expected O, but got I
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_0190: Expected O, but got I
			//IL_019f: Expected O, but got I
			//IL_022a: Expected F4, but got I
			//IL_0134: Expected O, but got I
			//IL_0aae: Expected O, but got I
			//IL_0572: Expected O, but got I
			//IL_0581: Expected O, but got I
			//IL_0752: Expected O, but got I
			//IL_076a: Expected O, but got I
			//IL_0251: Expected I, but got O
			//IL_0797: Expected O, but got I
			//IL_028c: Expected O, but got I
			//IL_07d2: Expected I4, but got I8
			//IL_07e0: Expected O, but got I
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_030e: Expected O, but got Unknown
			//IL_032b: Expected O, but got I
			//IL_033a: Expected O, but got I
			//IL_0a75: Expected O, but got I
			//IL_0a7e: Expected I4, but got O
			//IL_02d8: Expected O, but got I
			//IL_05b3: Expected O, but got I
			//IL_039b: Expected O, but got I
			//IL_085b: Expected I4, but got O
			//IL_03ca: Expected O, but got I
			//IL_03ed: Expected I, but got O
			//IL_05f9: Expected O, but got I
			//IL_0621: Expected O, but got I
			//IL_063f: Expected O, but got I
			//IL_0667: Expected O, but got I
			//IL_06d3: Expected O, but got I
			//IL_068d: Expected O, but got I
			//IL_0511: Expected O, but got I
			//IL_0711: Expected O, but got I
			object obj = obj;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			if (IsAdRemoved())
			{
				return;
			}
			List<IAdClient>.Enumerator enumerator = clients.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C0]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-B0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C0]");
			_ = 0;
			object obj2 = 4294967295L;
			int num2 = 0;
			IntPtr intPtr2 = default(IntPtr);
			object obj8 = default(object);
			object obj9 = default(object);
			List<AdPlacement> list = default(List<AdPlacement>);
			object obj14 = default(object);
			object obj15 = default(object);
			string text3 = default(string);
			float num12 = default(float);
			float num14 = default(float);
			NullReferenceException ex = default(NullReferenceException);
			NullReferenceException ex4 = default(NullReferenceException);
			NullReferenceException ex5 = default(NullReferenceException);
			NullReferenceException ex6 = default(NullReferenceException);
			while (true)
			{
				List<IAdClient>.Enumerator enumerator2 = (List<IAdClient>.Enumerator)((long)(IntPtr)obj - 128L);
				IAdClient adClient;
				int num6;
				if (((List<IAdClient>.Enumerator*)enumerator2)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-70]");
					adClient = (IAdClient)0;
					IntPtr intPtr = (IntPtr)adClient;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X8_v27 (Il2CppClass<EasyMobile.IAdClient>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_014d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X8_v27 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
					object obj3 = 0L + 8L;
					int num3 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ X11_v25-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IAdClient))
						{
							break;
						}
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X8_v27 (Il2CppClass<EasyMobile.IAdClient>)+126]");
						bool flag = (long)num4 < 0L;
						bool flag2 = !flag;
						obj3 = (long)(IntPtr)obj3 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_014d;
					}
					object obj4 = obj3 + 32;
					int num5 = (int)((long)(IntPtr)obj4 << 4);
					object obj5 = (long)intPtr + (long)num5;
					object obj6 = (long)(IntPtr)obj5 + 304L;
					num6 = (int)(long)intPtr2;
					goto IL_0998;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
				object obj7 = 0;
				obj8 = (long)(IntPtr)obj2 + 1L;
				_ = 290;
				break;
				IL_0849:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				num2 = (int)obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				break;
				IL_0998:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v665 @ X0_v32] (should have been resolved before IL gen)");
				bool flag3 = list == null;
				bool flag4 = !flag3;
				List<AdPlacement> list2 = list;
				if (!flag4)
				{
					List<AdPlacement> list3 = new List<AdPlacement>();
					list2 = list3;
				}
				bool flag5 = list2.Contains(AdPlacement.Default);
				bool flag6 = !flag5;
				bool flag7 = !flag6;
				intPtr2 = (IntPtr)0;
				if (!flag7)
				{
					list2.Add(AdPlacement.Default);
					intPtr2 = (IntPtr)0;
				}
				List<AdPlacement>.Enumerator enumerator3 = list2.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C0]");
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-B0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C0]");
				_ = 0;
				while (true)
				{
					List<AdPlacement>.Enumerator enumerator4 = (List<AdPlacement>.Enumerator)((long)(IntPtr)obj - 160L);
					if (!((List<AdPlacement>.Enumerator*)enumerator4)->MoveNext())
					{
						break;
					}
					IntPtr intPtr3 = (IntPtr)adClient;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ X8_v51 (Il2CppClass<EasyMobile.IAdClient>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_02f1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ X8_v51 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
					object obj10 = 0L + 8L;
					int num7 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ X11_v20-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IAdClient))
						{
							break;
						}
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ X8_v51 (Il2CppClass<EasyMobile.IAdClient>)+126]");
						bool flag8 = (long)num8 < 0L;
						bool flag9 = !flag8;
						obj10 = (long)(IntPtr)obj10 + 16L;
						if (!flag9)
						{
							continue;
						}
						goto IL_02f1;
					}
					object obj11 = obj10 + 7;
					int num9 = (int)((long)(IntPtr)obj11 << 4);
					object obj12 = (long)intPtr3 + (long)num9;
					object obj13 = (long)(IntPtr)obj12 + 304L;
					goto IL_0a15;
					IL_0b32:
					if ((IntPtr)obj14 != (IntPtr)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						return;
					}
					goto IL_0849;
					IL_02f1:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0a15;
					IL_0a15:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v859 @ X0_v50] (should have been resolved before IL gen)");
					int num10 = (int)((long)(IntPtr)obj15 & 1L);
					bool flag10 = num10 == 0;
					intPtr2 = (IntPtr)1;
					if (flag10)
					{
						continue;
					}
					AdNetwork network = adClient.Network;
					object obj16 = (long)(IntPtr)obj - 164L;
					object obj17 = (AdNetwork)obj16;
					if (obj17 != null)
					{
						object obj18 = obj17;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v938 @ X8_v60+160] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
							string text = ((AdPlacement)0).ToString();
							string text2 = text3 + text;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
							bool flag11 = IsInterstitialAdReady(adClient, (AdPlacement)0);
							bool flag12 = !flag11;
							bool flag13 = !flag12;
							intPtr2 = (IntPtr)null;
							if (flag13)
							{
								continue;
							}
							if (lastCustomInterstitialAdsLoadTimestamp != null)
							{
								bool flag14 = lastCustomInterstitialAdsLoadTimestamp.ContainsKey(text2);
								bool flag15 = !flag14;
								bool flag16 = !flag15;
								string text4 = text2;
								if (!flag16)
								{
									if (lastCustomInterstitialAdsLoadTimestamp == null)
									{
										ex = new NullReferenceException();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X0_v50+8]");
										object obj19 = 0;
										float num11 = num12;
										obj8 = obj2;
										float num13 = num14;
										obj14 = text2;
										goto IL_0b32;
									}
									lastCustomInterstitialAdsLoadTimestamp.Add(text2, DEFAULT_TIMESTAMP);
									text4 = text2;
								}
								float realtimeSinceStartup = Time.realtimeSinceStartup;
								if (lastCustomInterstitialAdsLoadTimestamp != null)
								{
									num14 = lastCustomInterstitialAdsLoadTimestamp.get_Item(text2);
									AdSettings advertising = EM_Settings.Advertising;
									if (advertising != null)
									{
										num = advertising.AdLoadingInterval;
										num12 = realtimeSinceStartup - num14;
										bool flag17 = num12 < advertising.AdLoadingInterval;
										intPtr2 = (IntPtr)0;
										if (flag17)
										{
											continue;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
										LoadInterstitialAd(adClient, (AdPlacement)0);
										float realtimeSinceStartup2 = Time.realtimeSinceStartup;
										if (lastCustomInterstitialAdsLoadTimestamp != null)
										{
											lastCustomInterstitialAdsLoadTimestamp.set_Item(text2, realtimeSinceStartup2);
											intPtr2 = (IntPtr)0;
											num = realtimeSinceStartup2;
											continue;
										}
										NullReferenceException ex2 = new NullReferenceException();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X0_v50+8]");
										object obj19 = 0;
										float num11 = num12;
										obj8 = obj2;
										float num13 = advertising.AdLoadingInterval;
										obj14 = text2;
										NullReferenceException ex3 = ex;
									}
									else
									{
										NullReferenceException ex3 = new NullReferenceException();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X0_v50+8]");
										object obj19 = 0;
										float num11 = num12;
										obj8 = obj2;
										float num13 = realtimeSinceStartup;
										obj14 = text4;
										ex3 = ex4;
									}
								}
								else
								{
									ex4 = new NullReferenceException();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X0_v50+8]");
									object obj19 = 0;
									float num11 = num12;
									obj8 = obj2;
									float num13 = num;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
									obj14 = 0;
									NullReferenceException ex3 = ex5;
								}
							}
							else
							{
								ex5 = new NullReferenceException();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X0_v50+8]");
								object obj19 = 0;
								float num11 = num12;
								obj8 = obj2;
								float num13 = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v938 @ X8_v60+168]");
								obj14 = 0;
							}
						}
						else
						{
							NullReferenceException ex3 = new NullReferenceException();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X0_v50+8]");
							object obj19 = 0;
							float num11 = num12;
							obj8 = obj2;
							float num13 = num;
							obj14 = obj16;
							ex3 = ex6;
						}
					}
					else
					{
						ex6 = new NullReferenceException();
					}
					goto IL_0b32;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
				object obj20 = 0;
				obj2 = (long)(IntPtr)obj2 + 1L;
				_ = 262;
				List<AdPlacement>.Enumerator enumerator5 = (List<AdPlacement>.Enumerator)((long)(IntPtr)obj - 160L);
				((List<AdPlacement>.Enumerator*)enumerator5)->Dispose();
				object obj21 = (long)(IntPtr)obj2 + 1L;
				if (obj21 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
					object obj22 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ X8_v47+v538 @ X25_v8*4]");
					if ((IntPtr)0 == (IntPtr)262)
					{
						int num15 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj2);
						obj2 = (long)(IntPtr)obj2 + (long)num15;
						continue;
					}
				}
				bool flag18 = num2 == 0;
				num2 = 0;
				if (!flag18)
				{
					num2 = 0;
					throw new TypeLoadException();
				}
				continue;
				IL_014d:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				num6 = 32;
				goto IL_0998;
			}
			List<IAdClient>.Enumerator enumerator6 = (List<IAdClient>.Enumerator)((long)(IntPtr)obj - 128L);
			((List<IAdClient>.Enumerator*)enumerator6)->Dispose();
			object obj23 = (long)(IntPtr)obj8 + 1L;
			if (obj23 != null)
			{
				if (num2 == 0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ X8_v12+v155 @ X25_v3*4]");
				if ((IntPtr)0 == (IntPtr)290)
				{
					return;
				}
			}
			else if (num2 == 0)
			{
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xA4BAEC", Offset = "0xA4BAEC", Length = "0x6E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = &v25 @ X29;\n\tgoto L_001F;\n\tv37 = *([1F0FCB0]);\n\tv38 = *([v37 @ X8_v106]);\n\tv39 = \"il2cpp_codegen_initialize_method\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2021F10]) = v57;\nL_001F:\n\t*([v25 @ X29-78]) = 0;\n\t*([v25 @ X29-70]) = 0;\n\t*([v25 @ X29-80]) = 0;\n\t*([v25 @ X29-98]) = 0;\n\t*([v25 @ X29-90]) = 0;\n\t*([v25 @ X29-A0]) = 0;\n\t*([v25 @ X29-A4]) = 0;\n\t*([v25 @ X29-C8]) = &v59 @ stack_-F0;\n\tv67 = System.Collections.Generic.List`1<EasyMobile.IAdClient>::GetEnumerator(clients);\n\t*([v25 @ X29-70]) = *([v25 @ X29-B0]);\n\t*([v25 @ X29-80]) = *([v25 @ X29-C0]);\nL_0041:\n\tv330 = &v25 @ X29 - 0x80;\n\tv331 = System.Collections.Generic.List`1<EasyMobile.IAdClient>+Enumerator<EasyMobile.IAdClient>::MoveNext(v330);\n\tv335 = v331 == 0;\n\tif (v335) goto L_0221;\n\tv149 = *([v25 @ X29-70]);\n\tgoto L_0075;\n\tv433 = *([v386 @ X8_v25+B0]);\n\tv434 = 0;\n\tv435 = v433 + 8;\n\tv437 = *([v564 @ X11_v24-8]);\n\tv569 = v437 == v387;\n\tif (v569) goto L_006D;\n\tv457 = v563 + 1;\n\tv603 = v457 < v388;\n\tv455 = ~v603;\n\tv459 = v564 + 0x10;\n\tv439 = ~v455;\n\tif (v439) goto L_FFFFFFFF;\n\tv460 = 0x21;\n\tv461 = v149;\n\tv462 = 0x8909C4(v461, v387, v460, v69, v43, v44, v45, v46, v129, v74, v49, v50, v51, v52, v53, v54);\n\tgoto L_0075;\nL_006D:\n\tv604 = *([v564 @ X11_v24]);\n\tv605 = v604 + 0x21;\n\tv606 = v605 << 4;\n\tv607 = v386 + v606;\n\tv608 = v607 + 0x130;\nL_0075:\n\tv614 = EasyMobile.IAdClient::get_DefinedCustomRewardedAdPlacements(*([v25 @ X29-70]));\n\tv616 = v614 == 0;\n\tv617 = ~v616;\n\tif (v617) goto L_0088;\n\tv651 = new System.Collections.Generic.List`1<EasyMobile.AdPlacement>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::.ctor(v651);\nL_0088:\n\tgoto L_0097;\n\tv663 = *([v658 @ X0_v33+E0]);\n\tv664 = v663 == 0;\n\tv665 = ~v664;\n\t// 140 ConditionalJump @b20, v665 @ TEMP_v88\n\tv666 = \"il2cpp_codegen_runtime_class_init\"(v658, v479, v466, v69, v43, v44, v45, v46, v129, v74, v49, v50, v51, v52, v53, v54);\nL_0097:\n\tv675 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::Contains(v464, v669.Default);\n\tv677 = v675 == 0;\n\tv678 = ~v677;\n\tif (v678) goto L_00B4;\n\tgoto L_00AE;\n\tv701 = *([v679 @ X0_v109 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv702 = v701 == 0;\n\tv703 = ~v702;\n\tif (v703) goto L_00AE;\n\tv711 = \"il2cpp_codegen_runtime_class_init\"(v679, v670, v673, v69, v43, v44, v45, v46, v129, v74, v49, v50, v51, v52, v53, v54);\n\tv705 = EasyMobile.AdPlacement;\nL_00AE:\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::Insert(v464, 0, v707.Default);\nL_00B4:\n\tv700 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::GetEnumerator(v464);\n\tv226 = *([v25 @ X29-C0]);\n\t*([v25 @ X29-90]) = *([v25 @ X29-B0]);\n\t*([v25 @ X29-A0]) = *([v25 @ X29-C0]);\nL_00BA:\n\tv755 = &v25 @ X29 - 0xA0;\n\tv756 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>+Enumerator<EasyMobile.AdPlacement>::MoveNext(v755);\n\tv758 = v756 == 0;\n\tif (v758) goto L_01BE;\n\tv759 = *([v149 @ X20_v8 (EasyMobile.IAdClient)]);\n\tv762 = *([v759 @ X8_v49 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v762) goto L_00E2;\n\tv808 = *([v759 @ X8_v49 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_00CD:\n\tv813 = *([v808 @ X11_v19-8]) == EasyMobile.IAdClient;\n\tif (v813) goto L_00E5;\n\tv807 = v807 + 1;\n\tv822 = v807 < *([v759 @ X8_v49 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv786 = ~v822;\n\tv808 = v808 + 0x10;\n\tv770 = ~v786;\n\tif (v770) goto L_00CD;\nL_00E2:\n\tv829 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::Insert(*([v25 @ X29-70]), EasyMobile.IAdClient, 7);\n\tgoto L_00EA;\nL_00E5:\n\tv824 = *([v808 @ X11_v19]) + 7;\n\tv825 = v824 << 4;\n\tv826 = v759 + v825;\n\tv829 = v826 + 0x130;\nL_00EA:\n\t;\n\t*([v829 @ X0_v47])(v746, *([v25 @ X29-70]), *([v25 @ X29-90]), 2, *([v829 @ X0_v47+8]), v43, v44, v45, v46, v226, v165, v49, v50, v51, v52, v53, v54);\n\tv832 = v746 & 1;\n\tv749 = v832 == 0;\n\tif (v749) goto L_00BA;\n\tgoto L_011D;\n\tv842 = *([v836 @ X8_v52+B0]);\n\tv843 = 0;\n\tv844 = v842 + 8;\n\tv846 = *([v883 @ X11_v14-8]);\n\tv888 = v846 == v837;\n\tif (v888) goto L_0116;\n\tv866 = v882 + 1;\n\tv893 = v866 < v838;\n\tv864 = ~v893;\n\tv868 = v883 + 0x10;\n\tv848 = ~v864;\n\tif (v848) goto L_FFFFFFFF;\n\tv869 = v149;\n\tv870 = 0;\n\tv871 = 0x8909C4(v869, v837, v870, v161, v43, v44, v45, v46, v226, v165, v49, v50, v51, v52, v53, v54);\n\tgoto L_011D;\nL_0116:\n\tv894 = *([v883 @ X11_v14]);\n\tv895 = v894 << 4;\n\tv896 = v836 + v895;\n\tv897 = v896 + 0x130;\nL_011D:\n\tv903 = EasyMobile.IAdClient::get_Network(*([v25 @ X29-70]));\n\t*([v25 @ X29-A4]) = v903;\n\tv235 = &v25 @ X29 - 0xA4;\n\t// 292 Box v907 @ X0_v54, typeof(EasyMobile.AdNetwork), v235 @ X1_v28 (System.Int32)\n\tv251 = v907 == 0;\n\tif (v251) goto L_01C5;\n\tv908 = *([v907 @ X0_v54]);\n\t*([v908 @ X8_v58+160])(v910, v907, *([v908 @ X8_v58+168]), 0, *([v829 @ X0_v47+8]), v43, v44, v45, v46, v226, v165, v49, v50, v51, v52, v53, v54);\n\tv912 = \"il2cpp_vm_object_unbox\"(v907, *([v908 @ X8_v58+168]), 0, *([v829 @ X0_v47+8]), v43, v44, v45, v46, v226, v165, v49, v50, v51, v52, v53, v54);\n\t*([v25 @ X29-A4]) = *([v912 @ X0_v60]);\n\tv252 = *([v25 @ X29-90]) == 0;\n\tif (v252) goto L_01C8;\n\tv917 = EasyMobile.AdPlacement::ToString(*([v25 @ X29-90]));\n\tv920 = System.String::Concat(v910, v917);\n\tgoto L_014A;\n\tv926 = *([v922 @ X0_v67+E0]);\n\tv927 = v926 == 0;\n\tv928 = ~v927;\n\tif (v928) goto L_014A;\n\tv930 = \"il2cpp_codegen_runtime_class_init\"(v922, v918, v186, v161, v43, v44, v45, v46, v226, v165, v49, v50, v51, v52, v53, v54);\nL_014A:\n\tv743 = EasyMobile.Advertising::IsRewardedAdReady(*([v25 @ X29-70]), *([v25 @ X29-90]));\n\tv934 = v743 == 0;\n\tv748 = ~v934;\n\tif (v748) goto L_00BA;\n\tgoto L_015C;\n\tv939 = *([v935 @ X0_v71 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv940 = v939 == 0;\n\tv941 = ~v940;\n\tif (v941) goto L_015C;\n\tv947 = \"il2cpp_codegen_runtime_class_init\"(v935, v237, v186, v161, v43, v44, v45, v46, v226, v165, v49, v50, v51, v52, v53, v54);\n\tv943 = EasyMobile.Advertising;\nL_015C:\n\tv253 = v262.lastCustomRewardedAdsLoadTimestamp == 0;\n\tif (v253) goto L_01CA;\n\tv950 = System.Collections.Generic.Dictionary`2<System.String, System.Single>::ContainsKey(v262.lastCustomRewardedAdsLoadTimestamp, v920);\n\tv952 = v950 == 0;\n\tv953 = ~v952;\n\tif (v953) goto L_017D;\n\tgoto L_0174;\n\tv968 = *([v954 @ X0_v94 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv969 = v968 == 0;\n\tv970 = ~v969;\n\tif (v970) goto L_0174;\n\tv979 = \"il2cpp_codegen_runtime_class_init\"(v954, v240, v189, v161, v43, v44, v45, v46, v226, v165, v49, v50, v51, v52, v53, v54);\n\tv972 = EasyMobile.Advertising;\nL_0174:\n\tv256 = v265.lastCustomRewardedAdsLoadTimestamp == 0;\n\tif (v256) goto L_01D0;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Single>::Add(v265.lastCustomRewardedAdsLoadTimestamp, v920, v265.DEFAULT_TIMESTAMP);\nL_017D:\n\tv227 = UnityEngine.Time::get_realtimeSinceStartup();\n\tgoto L_018C;\n\tv981 = *([v975 @ X0_v78 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv982 = v981 == 0;\n\tv983 = ~v982;\n\tif (v983) goto L_018C;\n\tv989 = \"il2cpp_codegen_runtime_class_init\"(v975, v238, v187, v161, v43, v44, v45, v46, v227, v165, v49, v50, v51, v52, v53, v54);\n\tv985 = EasyMobile.Advertising;\nL_018C:\n\tv254 = v263.lastCustomRewardedAdsLoadTimestamp == 0;\n\tif (v254) goto L_01CC;\n\tv228 = System.Collections.Generic.Dictionary`2<System.String, System.Single>::get_Item(v263.lastCustomRewardedAdsLoadTimestamp, v920);\n\tv744 = EasyMobile.EM_Settings::get_Advertising();\n\tv255 = v744 == 0;\n\tif (v255) goto L_01CE;\n\tv226 = v744.mAdLoadingInterval;\n\tv165 = v227 - v228;\n\tv209 = v165 < v744.mAdLoadingInterval;\n\tif (v209) goto L_00BA;\n\tgoto L_01AF;\n\tv996 = *([v992 @ X0_v84+E0]);\n\tv997 = v996 == 0;\n\tv998 = ~v997;\n\tif (v998) goto L_01AF;\n\tv1000 = \"il2cpp_codegen_runtime_class_init\"(v992, v239, v188, v161, v43, v44, v45, v46, v738, v166, v49, v50, v51, v52, v53, v54);\nL_01AF:\n\tEasyMobile.Advertising::LoadRewardedAd(*([v25 @ X29-70]), *([v25 @ X29-90]));\n\tv226 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv257 = v266.lastCustomRewardedAdsLoadTimestamp == 0;\n\tif (v257) goto L_01D3;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Single>::set_Item(v266.lastCustomRewardedAdsLoadTimestamp, v920, v226);\n\tgoto L_00BA;\nL_01BE:\n\tv763 = *([v25 @ X29-C8]);\n\tv371 = v371 + 1;\n\t*\n// ... truncated")]
		private unsafe static void LoadAllRewardedAds(List<IAdClient> clients)
		{
			//IL_0041: Expected O, but got I8
			//IL_0046: Expected I, but got O
			//IL_0950: Expected O, but got I
			//IL_0623: Expected O, but got I
			//IL_0632: Expected O, but got I
			//IL_0680: Expected O, but got I
			//IL_0698: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_078d: Expected O, but got I
			//IL_06e2: Expected O, but got I
			//IL_00dd: Expected F4, but got I
			//IL_089d: Expected O, but got I
			//IL_0432: Expected O, but got I
			//IL_0441: Expected O, but got I
			//IL_0553: Expected O, but got I
			//IL_056b: Expected O, but got I
			//IL_0104: Expected I, but got O
			//IL_05fa: Expected I, but got O
			//IL_01c4: Expected O, but got I4
			//IL_01c4: Expected I4, but got O
			//IL_01c4: Expected O, but got I
			//IL_0598: Expected O, but got I
			//IL_013f: Expected O, but got I
			//IL_060d: Expected I, but got O
			//IL_05d3: Expected I4, but got I8
			//IL_05e1: Expected O, but got I
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Expected O, but got Unknown
			//IL_01f4: Expected O, but got I
			//IL_0203: Expected O, but got I
			//IL_084c: Expected O, but got I
			//IL_018b: Expected O, but got I
			//IL_0264: Expected O, but got I
			//IL_065b: Expected I, but got O
			//IL_029b: Expected O, but got I
			//IL_029b: Expected O, but got I
			//IL_0518: Expected I4, but got O
			//IL_04f1: Expected I4, but got O
			//IL_03df: Expected O, but got I
			//IL_03df: Expected O, but got I
			//IL_0537: Expected I4, but got O
			object obj = obj;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			List<IAdClient>.Enumerator enumerator = clients.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-B0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C0]");
			_ = 0;
			object obj2 = 4294967295L;
			IntPtr intPtr = (IntPtr)null;
			int num5 = default(int);
			object obj7 = default(object);
			string text3 = default(string);
			object obj10 = default(object);
			NullReferenceException ex2 = default(NullReferenceException);
			NullReferenceException ex4 = default(NullReferenceException);
			NullReferenceException ex5 = default(NullReferenceException);
			NullReferenceException ex = default(NullReferenceException);
			NullReferenceException ex6 = default(NullReferenceException);
			List<AdPlacement> list3 = default(List<AdPlacement>);
			while (true)
			{
				List<IAdClient>.Enumerator enumerator2 = (List<IAdClient>.Enumerator)((long)(IntPtr)obj - 128L);
				if (((List<IAdClient>.Enumerator*)enumerator2)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-70]");
					IAdClient adClient = (IAdClient)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-70]");
					List<AdPlacement> definedCustomRewardedAdPlacements = ((IAdClient)0).DefinedCustomRewardedAdPlacements;
					bool flag = definedCustomRewardedAdPlacements == null;
					bool flag2 = !flag;
					List<AdPlacement> list = definedCustomRewardedAdPlacements;
					if (!flag2)
					{
						List<AdPlacement> list2 = new List<AdPlacement>();
						list = list2;
					}
					if (!list.Contains(AdPlacement.Default))
					{
						list.Insert(0, AdPlacement.Default);
					}
					List<AdPlacement>.Enumerator enumerator3 = list.GetEnumerator();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C0]");
					float num = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-B0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C0]");
					_ = 0;
					while (true)
					{
						List<AdPlacement>.Enumerator enumerator4 = (List<AdPlacement>.Enumerator)((long)(IntPtr)obj - 160L);
						if (!((List<AdPlacement>.Enumerator*)enumerator4)->MoveNext())
						{
							break;
						}
						IntPtr intPtr2 = (IntPtr)adClient;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ X8_v49 (Il2CppClass<EasyMobile.IAdClient>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_01a4;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ X8_v49 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
						object obj3 = 0L + 8L;
						int num2 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ X11_v19-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IAdClient))
							{
								break;
							}
							num2++;
							int num3 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ X8_v49 (Il2CppClass<EasyMobile.IAdClient>)+126]");
							bool flag3 = (long)num3 < 0L;
							bool flag4 = !flag3;
							obj3 = (long)(IntPtr)obj3 + 16L;
							if (!flag4)
							{
								continue;
							}
							goto IL_01a4;
						}
						object obj4 = obj3 + 7;
						int num4 = (int)((long)(IntPtr)obj4 << 4);
						object obj5 = (long)intPtr2 + (long)num4;
						object obj6 = (long)(IntPtr)obj5 + 304L;
						goto IL_0804;
						IL_0921:
						if (num5 != 1)
						{
							((List<AdPlacement>)(object)ex).Insert(num5, (AdPlacement)(object)ex);
							return;
						}
						goto IL_0642;
						IL_01a4:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-70]");
						((List<AdPlacement>)0).Insert((int)typeof(IAdClient), (AdPlacement)7);
						goto IL_0804;
						IL_0804:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v829 @ X0_v47] (should have been resolved before IL gen)");
						if ((int)((long)(IntPtr)obj7 & 1L) == 0)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-70]");
						AdNetwork network = ((IAdClient)0).Network;
						int num6 = (int)((long)(IntPtr)obj - 164L);
						object obj8 = (AdNetwork)num6;
						if (obj8 != null)
						{
							object obj9 = obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v908 @ X8_v58+160] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
								string text = ((AdPlacement)0).ToString();
								string text2 = text3 + text;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-70]");
								IntPtr intPtr3 = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
								if (IsRewardedAdReady((IAdClient)(long)intPtr3, (AdPlacement)0))
								{
									continue;
								}
								if (lastCustomRewardedAdsLoadTimestamp != null)
								{
									bool flag5 = lastCustomRewardedAdsLoadTimestamp.ContainsKey(text2);
									bool flag6 = !flag5;
									bool flag7 = !flag6;
									string text4 = text2;
									if (!flag7)
									{
										if (lastCustomRewardedAdsLoadTimestamp == null)
										{
											ex2 = new NullReferenceException();
											obj10 = obj2;
											num5 = (int)text2;
											goto IL_0921;
										}
										lastCustomRewardedAdsLoadTimestamp.Add(text2, DEFAULT_TIMESTAMP);
										text4 = text2;
									}
									float realtimeSinceStartup = Time.realtimeSinceStartup;
									if (lastCustomRewardedAdsLoadTimestamp != null)
									{
										float num7 = lastCustomRewardedAdsLoadTimestamp.get_Item(text2);
										AdSettings advertising = EM_Settings.Advertising;
										if (advertising != null)
										{
											num = advertising.AdLoadingInterval;
											float num8 = realtimeSinceStartup - num7;
											if (num8 < advertising.AdLoadingInterval)
											{
												continue;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-70]");
											IntPtr intPtr4 = (IntPtr)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
											LoadRewardedAd((IAdClient)(long)intPtr4, (AdPlacement)0);
											num = Time.realtimeSinceStartup;
											if (lastCustomRewardedAdsLoadTimestamp != null)
											{
												lastCustomRewardedAdsLoadTimestamp.set_Item(text2, num);
												continue;
											}
											NullReferenceException ex3 = new NullReferenceException();
											obj10 = obj2;
											num5 = (int)text2;
											ex = ex2;
										}
										else
										{
											ex = new NullReferenceException();
											obj10 = obj2;
											num5 = (int)text4;
											ex = ex4;
										}
									}
									else
									{
										ex4 = new NullReferenceException();
										obj10 = obj2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-90]");
										num5 = 0;
										ex = ex5;
									}
								}
								else
								{
									ex5 = new NullReferenceException();
									obj10 = obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v908 @ X8_v58+168]");
									num5 = 0;
								}
							}
							else
							{
								ex = new NullReferenceException();
								obj10 = obj2;
								num5 = num6;
								ex = ex6;
							}
						}
						else
						{
							ex6 = new NullReferenceException();
						}
						goto IL_0921;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
					object obj11 = 0;
					obj2 = (long)(IntPtr)obj2 + 1L;
					_ = 255;
					List<AdPlacement>.Enumerator enumerator5 = (List<AdPlacement>.Enumerator)((long)(IntPtr)obj - 160L);
					((List<AdPlacement>.Enumerator*)enumerator5)->Dispose();
					object obj12 = (long)(IntPtr)obj2 + 1L;
					if (obj12 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ X8_v45+v371 @ X25_v7*4]");
						if ((IntPtr)0 == (IntPtr)255)
						{
							int num9 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj2);
							obj2 = (long)(IntPtr)obj2 + (long)num9;
							continue;
						}
					}
					bool flag8 = intPtr == (IntPtr)0;
					intPtr = (IntPtr)null;
					if (!flag8)
					{
						intPtr = (IntPtr)null;
						throw new TypeLoadException();
					}
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
				object obj14 = 0;
				obj10 = (long)(IntPtr)obj2 + 1L;
				_ = 283;
				break;
				IL_0642:
				((List<AdPlacement>)(object)ex).Insert(num5, (AdPlacement)(object)ex);
				intPtr = (IntPtr)list3;
				list3.Insert(num5, (AdPlacement)(object)ex);
				break;
			}
			List<IAdClient>.Enumerator enumerator6 = (List<IAdClient>.Enumerator)((long)(IntPtr)obj - 128L);
			((List<IAdClient>.Enumerator*)enumerator6)->Dispose();
			object obj15 = (long)(IntPtr)obj10 + 1L;
			if (obj15 != null)
			{
				if (intPtr == (IntPtr)0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-C8]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ X8_v10+v414 @ X25_v1*4]");
				if ((IntPtr)0 == (IntPtr)283)
				{
					return;
				}
			}
			else if (intPtr == (IntPtr)0)
			{
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x96B998", Offset = "0x96B998", Length = "0x584")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EB0DD0]);\n\tv35 = *([v34 @ X8_v79]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021556]) = v54;\nL_001E:\n\tv58 = new System.Collections.Generic.List`1<EasyMobile.IAdClient>();\n\tSystem.Collections.Generic.List`1<EasyMobile.IAdClient>::.ctor(v58);\n\tgoto L_0034;\n\tv71 = *([v66 @ X0_v4+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_0034;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v66, v62, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0034:\n\tv80 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_0045;\n\tv88 = *([v84 @ X8_v9+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0045;\n\tv98 = v84;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v98, v79, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0045:\n\tv97 = System.Enum::GetValues(v80);\n\tv101 = System.Array::GetEnumerator(v97);\nL_0054:\n\tgoto L_007B;\n\tv362 = *([v323 @ X8_v24+B0]);\n\tv363 = 0;\n\tv364 = v362 + 8;\n\tv366 = *([v437 @ X11_v26-8]);\n\tv442 = v366 == v324;\n\tif (v442) goto L_0074;\n\tv386 = v436 + 1;\n\tv447 = v386 < v325;\n\tv384 = ~v447;\n\tv388 = v437 + 0x10;\n\tv368 = ~v384;\n\tif (v368) goto L_FFFFFFFF;\n\tv389 = v174;\n\tv390 = 0;\n\tv391 = 0x8909C4(v389, v324, v390, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_007B;\nL_0074:\n\tv448 = *([v437 @ X11_v26]);\n\tv449 = v448 << 4;\n\tv450 = v323 + v449;\n\tv451 = v450 + 0x130;\nL_007B:\n\tv472 = System.Collections.IEnumerator::MoveNext(v101);\n\tv474 = v472 == 0;\n\tif (v474) goto L_FFFFFFFF;\n\tv487 = *([v101 @ X0_v41 (System.Collections.IEnumerator)]);\n\tv490 = *([v487 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v490) goto L_00A1;\n\tv628 = *([v487 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_008C:\n\tv633 = *([v628 @ X11_v21-8]) == System.Collections.IEnumerator;\n\tif (v633) goto L_00A4;\n\tv627 = v627 + 1;\n\tv692 = v627 < *([v487 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv581 = ~v692;\n\tv628 = v628 + 0x10;\n\tv565 = ~v581;\n\tif (v565) goto L_008C;\nL_00A1:\n\tv709 = 0x8909C4(v101, System.Collections.IEnumerator, 1, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00AB;\nL_00A4:\n\tv694 = *([v628 @ X11_v21]) + 1;\n\tv695 = v694 << 4;\n\tv696 = v487 + v695;\n\tv709 = v696 + 0x130;\nL_00AB:\n\t*([v709 @ X0_v46])(v714, v101, *([v709 @ X0_v46+8]), v698, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_FFFFFFFF;\n\tv752 = v717;\n\tv753 = 0x8907BC(v752, v712, v698, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv799 = v799_asT == 0;\n\tif (v799) goto L_0189;\n\tv840 = \"il2cpp_vm_object_unbox\"(v714, *([v709 @ X0_v46+8]), v698, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00D8;\n\tv910 = *([v879 @ X0_v65+E0]);\n\tv911 = v910 == 0;\n\tv912 = ~v911;\n\tif (v912) goto L_00D8;\n\tv914 = \"il2cpp_codegen_runtime_class_init\"(v879, v712, v698, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00D8:\n\tv919 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv926 = Il2CppClass<T>;\n\tgoto L_00E3;\n\tv931 = v926;\n\tv932 = 0x8907BC(v931, v918, v698, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00E3:\n\tv230 = Il2CppClass<T>;\n\t*([v926 @ X23_v16 (Il2CppClass<T>)+160])(v937, &v230 @ stack_-78_v12 (Il2CppClass<T>), *([v926 @ X23_v16 (Il2CppClass<T>)+168]), v698, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00F8;\n\tv942 = *([v938 @ X0_v72+E0]);\n\tv943 = v942 == 0;\n\tv944 = ~v943;\n\tif (v944) goto L_00F8;\n\tv946 = \"il2cpp_codegen_runtime_class_init\"(v938, v935, v698, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00F8:\n\tv950 = System.Enum::Parse(v919, v937);\n\tgoto L_FFFFFFFF;\n\tv957 = *([v953 @ X0_v76+E0]);\n\tv958 = v957 == 0;\n\tv959 = ~v958;\n\t// 260 ConditionalJump @b46, v959 @ TEMP_v75\n\tv960 = \"il2cpp_codegen_runtime_class_init\"(v953, v903, v286, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv241 = v241_asT == 0;\n\tif (v241) goto L_018D;\n\tv967 = \"il2cpp_vm_object_unbox\"(v950, EasyMobile.AdNetwork, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv922 = EasyMobile.Advertising::GetAdClient(*([v967 @ X0_v79]));\n\tv315 = EasyMobile.AdClientImpl::get_IsSdkAvail(v922);\n\tv318 = v315 == 0;\n\tif (v318) goto L_0054;\n\tgoto L_0135;\n\tv975 = *([v970 @ X0_v83+E0]);\n\tv976 = v975 == 0;\n\tv977 = ~v976;\n\tif (v977) goto L_0135;\n\tv979 = \"il2cpp_codegen_runtime_class_init\"(v970, v312, v286, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0135:\n\tv984 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv987 = Il2CppClass<T>;\n\tgoto L_0140;\n\tv992 = v987;\n\tv993 = 0x8907BC(v992, v983, v286, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0140:\n\tv224 = Il2CppClass<T>;\n\t*([v987 @ X23_v18 (Il2CppClass<T>)+160])(v998, &v224 @ stack_-90_v9 (Il2CppClass<T>), *([v987 @ X23_v18 (Il2CppClass<T>)+168]), 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0155;\n\tv1003 = *([v999 @ X0_v90+E0]);\n\tv1004 = v1003 == 0;\n\tv1005 = ~v1004;\n\tif (v1005) goto L_0155;\n\tv1007 = \"il2cpp_codegen_runtime_class_init\"(v999, v996, v286, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0155:\n\tv1011 = System.Enum::Parse(v984, v998);\n\tgoto L_FFFFFFFF;\n\tv1018 = *([v1014 @ X0_v94+E0]);\n\tv1019 = v1018 == 0;\n\tv1020 = ~v1019;\n\t// 353 ConditionalJump @b65, v1020 @ TEMP_v69\n\tv1021 = \"il2cpp_codegen_runtime_class_init\"(v1014, v266, v239, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv289 = v289_asT == 0;\n\tif (v289) goto L_0196;\n\tv1028 = \"il2cpp_vm_object_unbox\"(v1011, EasyMobile.AdNetwork, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv421 = EasyMobile.Advertising::GetWorkableAdClient(*([v1028 @ X0_v97]));\n\tv319 = v58 == 0;\n\tif (v319) goto L_0198;\n\tSystem.Collections.Generic.List`1<EasyMobile.IAdClient>::Add(v58, v421);\n\tgoto L_0054;\n\tgoto L_01C2;\nL_0189:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_018D:\n\tthrow System.InvalidCastException;\n\tv909 = new System.NullReferenceException();\n\tv178 = new System.NullReferenceException();\n\tv183 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0196:\n\tthrow System.InvalidCastException;\nL_0198:\n\tv425 = new System.NullReferenceException();\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\n\tgoto L_01B8;\nL_01B8:\n\tv486 = v421 != 1;\n\tif (v486) goto L_020F;\n\tv493 = 0x6D2BC0(v425, v421, v425, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv555 = *([v493 @ X0_v29]);\n\tv609 = 0x6D2490(v493, v421, v425, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_01C2:\n\t// 450 IsInst v616 @ X0_v13 (System.IDisposable), typeof(System.IDisposable), v606 @ X20_v3 (System.Collections.IEnumerator)\n\tv638 = v616 == 0;\n\tif (v638) goto L_01F2;\n\tgoto L_01F1;\n\tv756 = *([v722 @ X8_v12+B0]);\n\tv757 = 0;\n\tv758 = v756 + 8;\n\tv760 = *([v828 @ X11_v7-8]);\n\tv833 = v760 == v723;\n\tif (v833) goto L_01EA;\n\tv780 = v827 + 1;\n\tv870 = v780 < v724;\n\tv778 = ~v870;\n\tv782 = v828 + 0x10;\n\tv762 = ~v778;\n\tif (v762) goto L_FFFFFFFF;\n\tv783 = v547;\n\tv784 = 0;\n\tv785 = 0x8909C4(v783, v723, v784, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01F1;\nL_01EA:\n\tv871 = *([v828 @ X11_v7]);\n\tv872 = v871 << 4;\n\tv873 = v722 + v872;\n\tv874 = v873 + 0x130;\nL_01F1:\n\tSystem.IDisposable::Dispose(v616);\nL_01F2:\n\tv751 = v511 + 1;\n\tv529 = v751 == 0;\n\tv519 = ~v529;\n\tif (v519) goto L_020A;\n\tv786 = v555 == 0;\n\tv553 = ~v786;\n\tif (v553) goto L_020E;\nL_020A:\n\treturn v58;\nL_020E:\n\tv551 = new System.TypeLoadException();\nL_020F:\n\treturnVal1 = 0x6D2380(v551, v548, v516, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\treturn returnVal1;\n// 317 bookkeeping instructions omitted: flag registers\n// ... truncated")]
		private static List<IAdClient> GetAvailableNetworks<T>()
		{
			//IL_0044: Expected I, but got O
			//IL_007f: Expected O, but got I
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_0127: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_00cb: Expected O, but got I
			//IL_01ce: Expected I4, but got O
			//IL_01fe: Expected I4, but got O
			//IL_0287: Expected I4, but got O
			//IL_02ce: Expected I4, but got O
			//IL_0397: Expected I4, but got O
			List<IAdClient> list = new List<IAdClient>();
			Type typeFromHandle = typeof(T);
			Array values = Enum.GetValues(typeFromHandle);
			IEnumerator enumerator = values.GetEnumerator();
			object obj5 = default(object);
			string value = default(string);
			object obj7 = default(object);
			string value2 = default(string);
			object obj9 = default(object);
			object obj10 = default(object);
			while (true)
			{
				int num4;
				if (enumerator.MoveNext())
				{
					IntPtr intPtr = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00e4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ X11_v21-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00e4;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					num4 = 0;
					goto IL_0470;
				}
				int num5 = 0;
				IEnumerator enumerator2 = enumerator;
				int num6 = 0;
				goto IL_0484;
				IL_00e4:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				num4 = 1;
				goto IL_0470;
				IL_0470:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v709 @ X0_v46] (should have been resolved before IL gen)");
				T val = (T)((obj5 is T) ? obj5 : null);
				TypeLoadException ex3;
				NullReferenceException ex2;
				IAdClient typeFromHandle4;
				if (val != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					Type typeFromHandle2 = typeof(T);
					IntPtr intPtr2 = (IntPtr)0;
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v926 @ X23_v16 (Il2CppClass<T>)+160] (should have been resolved before IL gen)");
					object obj6 = Enum.Parse(typeFromHandle2, value);
					if ((int)((obj6 is AdNetwork) ? obj6 : null) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						AdClientImpl adClient = GetAdClient((AdNetwork)obj7);
						if (adClient.IsSdkAvail)
						{
							Type typeFromHandle3 = typeof(T);
							IntPtr intPtr4 = (IntPtr)0;
							IntPtr intPtr5 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v987 @ X23_v18 (Il2CppClass<T>)+160] (should have been resolved before IL gen)");
							object obj8 = Enum.Parse(typeFromHandle3, value2);
							AdNetwork adNetwork = (AdNetwork)((obj8 is AdNetwork) ? obj8 : null);
							bool flag3 = adNetwork == AdNetwork.None;
							enumerator2 = enumerator;
							typeFromHandle4 = (IAdClient)typeof(AdNetwork);
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								AdClientImpl workableAdClient = GetWorkableAdClient((AdNetwork)obj9);
								bool flag4 = list == null;
								enumerator2 = enumerator;
								typeFromHandle4 = workableAdClient;
								if (!flag4)
								{
									list.Add(workableAdClient);
									continue;
								}
								NullReferenceException ex = new NullReferenceException();
								bool flag5 = (IntPtr)workableAdClient != (IntPtr)1;
								ex2 = ex;
								ex3 = (TypeLoadException)(object)ex;
								if (flag5)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
								num6 = (int)obj10;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
								num5 = -1;
								goto IL_0484;
							}
							throw new InvalidCastException();
						}
						continue;
					}
					throw new InvalidCastException();
				}
				throw new InvalidCastException();
				IL_0484:
				(enumerator2 as IDisposable)?.Dispose();
				if (num5 + 1 != 0 || num6 == 0)
				{
					return list;
				}
				ex3 = new TypeLoadException();
				ex2 = null;
				typeFromHandle4 = null;
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			List<IAdClient> result = default(List<IAdClient>);
			return result;
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0xA49110", Offset = "0xA49110", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EC33C0]);\n\tv33 = *([v32 @ X8_v24]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, placement, position, size, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2021F11]) = v49;\nL_0020:\n\tgoto L_0026;\n\tv56 = *([v52 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0026;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, placement, position, size, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0026:\n\tv63 = EasyMobile.Advertising::IsAdRemoved();\n\tv65 = v63 == 0;\n\tif (v65) goto L_004D;\n\tgoto L_0043;\n\tv73 = *([v68 @ X0_v23+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0043;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v68, placement, position, size, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0043:\n\tUnityEngine.Debug::Log(\"Could not show banner ad: ads were removed.\");\n\treturn;\nL_004D:\n\tgoto L_0078;\n\tv100 = *([v93 @ X8_v5+B0]);\n\tv101 = 0;\n\tv102 = v100 + 8;\n\tv104 = *([v213 @ X11_v11-8]);\n\tv218 = v104 == v96;\n\tif (v218) goto L_006D;\n\tv134 = v212 + 1;\n\tv223 = v134 < v95;\n\tv131 = ~v223;\n\tv137 = v213 + 0x10;\n\tv107 = ~v131;\n\tif (v107) goto L_FFFFFFFF;\n\tv139 = 0xB;\n\tv140 = v26;\n\tv141 = 0x8909C4(v140, v96, v139, size, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0078;\nL_006D:\n\tv224 = *([v213 @ X11_v11]);\n\tv225 = v224 + 0xB;\n\tv226 = v225 << 4;\n\tv227 = v93 + v226;\n\tv228 = v227 + 0x130;\nL_0078:\n\tEasyMobile.IAdClient::ShowBannerAd(client, placement, position, size);\n\tgoto L_00A4;\n\tv255 = *([v251 @ X8_v8+B0]);\n\tv256 = 0;\n\tv257 = v255 + 8;\n\tv259 = *([v296 @ X11_v6-8]);\n\tv301 = v259 == v252;\n\tif (v301) goto L_009D;\n\tv279 = v295 + 1;\n\tv306 = v279 < v253;\n\tv277 = ~v306;\n\tv281 = v296 + 0x10;\n\tv261 = ~v277;\n\tif (v261) goto L_FFFFFFFF;\n\tv282 = v26;\n\tv283 = 0;\n\tv284 = 0x8909C4(v282, v252, v283, v143, v145, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00A4;\nL_009D:\n\tv307 = *([v296 @ X11_v6]);\n\tv308 = v307 << 4;\n\tv309 = v251 + v308;\n\tv310 = v309 + 0x130;\nL_00A4:\n\tv317 = EasyMobile.IAdClient::get_Network(client);\n\tgoto L_00BC;\n\tv322 = *([v197 @ X8_v11+E0]);\n\tv323 = v322 == 0;\n\tv324 = ~v323;\n\tgoto L_00BC;\n\tv327 = v197;\n\tv326 = \"il2cpp_codegen_runtime_class_init\"(v327, v315, v152, v143, v145, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00BC:\n\tEasyMobile.Advertising::AddActiveBannerAd(v317, placement);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ShowBannerAd(IAdClient client, AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
			if (IsAdRemoved())
			{
				Debug.Log("Could not show banner ad: ads were removed.");
				return;
			}
			client.ShowBannerAd(placement, position, size);
			AdNetwork network = client.Network;
			AddActiveBannerAd(network, placement);
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0xA49574", Offset = "0xA49574", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDD790]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F12]) = v41;\nL_0018:\n\tv44 = client->klass;\n\tv48 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v48) goto L_003B;\n\tv104 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_0026:\n\tv109 = *([v104 @ X11_v11-8]) == EasyMobile.IAdClient;\n\tif (v109) goto L_003E;\n\tv103 = v103 + 1;\n\tv164 = v103 < *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv82 = ~v164;\n\tv104 = v104 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_0026;\nL_003B:\n\tv185 = 0x8909C4(client, EasyMobile.IAdClient, 0xC, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0046;\nL_003E:\n\tv166 = *([v104 @ X11_v11]) + 0xC;\n\tv167 = v166 << 4;\n\tv168 = v44 + v167;\n\tv185 = v168 + 0x130;\nL_0046:\n\t*([v185 @ X0_v4])(v191, client, placement, *([v185 @ X0_v4+8]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0072;\n\tv196 = *([v192 @ X8_v6+B0]);\n\tv197 = 0;\n\tv198 = v196 + 8;\n\tv200 = *([v237 @ X11_v6-8]);\n\tv242 = v200 == v193;\n\tif (v242) goto L_006B;\n\tv220 = v236 + 1;\n\tv247 = v220 < v194;\n\tv218 = ~v247;\n\tv222 = v237 + 0x10;\n\tv202 = ~v218;\n\tif (v202) goto L_FFFFFFFF;\n\tv223 = v16;\n\tv224 = 0;\n\tv225 = 0x8909C4(v223, v193, v224, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0072;\nL_006B:\n\tv248 = *([v237 @ X11_v6]);\n\tv249 = v248 << 4;\n\tv250 = v192 + v249;\n\tv251 = v250 + 0x130;\nL_0072:\n\tv258 = EasyMobile.IAdClient::get_Network(client);\n\tgoto L_0089;\n\tv265 = *([v159 @ X8_v11+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\tgoto L_0089;\n\tv270 = v159;\n\tv269 = \"il2cpp_codegen_runtime_class_init\"(v270, v256, v122, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0089:\n\tEasyMobile.Advertising::RemoveActiveBannerAd(v258, placement);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void HideBannerAd(IAdClient client, AdPlacement placement)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IntPtr intPtr = (IntPtr)client;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X11_v11-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAdClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 12;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0133;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0133;
			IL_0133:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v185 @ X0_v4] (should have been resolved before IL gen)");
			AdNetwork network = client.Network;
			RemoveActiveBannerAd(network, placement);
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0xA497DC", Offset = "0xA497DC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EB2860]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F13]) = v41;\nL_001D:\n\tgoto L_0046;\n\tv51 = *([v44 @ X8_v3+B0]);\n\tv52 = 0;\n\tv53 = v51 + 8;\n\tv55 = *([v104 @ X11_v11-8]);\n\tv109 = v55 == v47;\n\tif (v109) goto L_003D;\n\tv85 = v103 + 1;\n\tv164 = v85 < v46;\n\tv82 = ~v164;\n\tv88 = v104 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_FFFFFFFF;\n\tv90 = 0xD;\n\tv91 = v16;\n\tv92 = 0x8909C4(v91, v47, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0046;\nL_003D:\n\tv165 = *([v104 @ X11_v11]);\n\tv166 = v165 + 0xD;\n\tv167 = v166 << 4;\n\tv168 = v44 + v167;\n\tv169 = v168 + 0x130;\nL_0046:\n\tEasyMobile.IAdClient::DestroyBannerAd(client, placement);\n\tgoto L_0072;\n\tv196 = *([v192 @ X8_v6+B0]);\n\tv197 = 0;\n\tv198 = v196 + 8;\n\tv200 = *([v237 @ X11_v6-8]);\n\tv242 = v200 == v193;\n\tif (v242) goto L_006B;\n\tv220 = v236 + 1;\n\tv247 = v220 < v194;\n\tv218 = ~v247;\n\tv222 = v237 + 0x10;\n\tv202 = ~v218;\n\tif (v202) goto L_FFFFFFFF;\n\tv223 = v16;\n\tv224 = 0;\n\tv225 = 0x8909C4(v223, v193, v224, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0072;\nL_006B:\n\tv248 = *([v237 @ X11_v6]);\n\tv249 = v248 << 4;\n\tv250 = v192 + v249;\n\tv251 = v250 + 0x130;\nL_0072:\n\tv258 = EasyMobile.IAdClient::get_Network(client);\n\tgoto L_0089;\n\tv265 = *([v159 @ X8_v11+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\tgoto L_0089;\n\tv270 = v159;\n\tv269 = \"il2cpp_codegen_runtime_class_init\"(v270, v256, v122, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0089:\n\tEasyMobile.Advertising::RemoveActiveBannerAd(v258, placement);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DestroyBannerAd(IAdClient client, AdPlacement placement)
		{
			client.DestroyBannerAd(placement);
			AdNetwork network = client.Network;
			RemoveActiveBannerAd(network, placement);
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0xA4A984", Offset = "0xA4A984", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv31 = *([1EAD0F8]);\n\tv32 = *([v31 @ X8_v44]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([2021F14]) = v52;\nL_001C:\n\tv54 = &v55 @ stack_-F0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-98]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-A0]) = 0;\n\tgoto L_0039;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\t// 46 Jump @b60\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v59, v34, v35, v36, v37, v38, v39, v40, v53, v42, v43, v44, v45, v46, v47, v48);\n\tv67 = EasyMobile.Advertising;\nL_0039:\n\tv78 = System.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::GetEnumerator(v70.activeBannerAds);\n\t*([v21 @ X29-60]) = *([v21 @ X29-A8]);\n\t*([v21 @ X29-80]) = *([v21 @ X29-C8]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-B8]);\nL_004B:\n\tv254 = &v21 @ X29 - 0x80;\n\tv242 = System.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>+Enumerator<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::MoveNext(v254);\n\tv256 = v242 == 0;\n\tif (v256) goto L_00BE;\n\tv173 = *([v21 @ X29-68]);\n\tv245 = *([v21 @ X29-68]) == 0;\n\tif (v245) goto L_004B;\n\tv199 = v173._size < 1;\n\tif (v199) goto L_004B;\n\tgoto L_006C;\n\tv358 = *([v348 @ X0_v27+E0]);\n\tv359 = v358 == 0;\n\tv360 = ~v359;\n\tif (v360) goto L_006C;\n\tv362 = \"il2cpp_codegen_runtime_class_init\"(v348, v239, v194, v36, v37, v38, v39, v40, v237, v126, v43, v44, v45, v46, v47, v48);\nL_006C:\n\tv366 = EasyMobile.Advertising::GetWorkableAdClient(*([v21 @ X29-70]));\n\tv399 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::GetEnumerator(*([v21 @ X29-68]));\n\t*([v21 @ X29-90]) = *([v21 @ X29-B8]);\n\t*([v21 @ X29-A0]) = *([v21 @ X29-C8]);\nL_0077:\n\tv437 = &v21 @ X29 - 0xA0;\n\tv438 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>+Enumerator<EasyMobile.AdPlacement>::MoveNext(v437);\n\tv442 = v438 == 0;\n\tif (v442) goto L_0085;\n\tv188 = v366 == 0;\n\tif (v188) goto L_008B;\n\tv434 = EasyMobile.AdClientImpl::DestroyBannerAd(v366, *([v21 @ X29-90]));\n\tgoto L_0077;\nL_0085:\n\tv116 = v116 + 1;\n\t*([v54 @ X23_v1+v116 @ X24_v5*4]) = 0x73;\n\tgoto L_009E;\nL_008B:\n\tv186 = new System.NullReferenceException();\n\tgoto L_00C2;\n\tgoto L_008F;\n\tgoto L_008F;\nL_008F:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00CF;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009E:\n\tv458 = &v21 @ X29 - 0xA0;\n\tv243 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>+Enumerator<EasyMobile.AdPlacement>::Dispose(v458);\n\tv246 = v116 + 1;\n\tv460 = v246 == 0;\n\tif (v460) goto L_00B8;\n\tv200 = *([v54 @ X23_v1+v116 @ X24_v5*4]) != 0x73;\n\tif (v200) goto L_00B8;\n\tv250 = 0xFFFFFFFF ^ v116;\n\tv116 = v116 + v250;\n\tgoto L_004B;\nL_00B8:\n\tv247 = ~v138;\n\tif (v247) goto L_004B;\n\tthrow System.TypeLoadException;\nL_00BE:\n\tv116 = v116 + 1;\n\t*([v54 @ X23_v1+v116 @ X24_v5*4]) = 0x8C;\n\tgoto L_00D6;\nL_00C2:\n\tgoto L_00CF;\n\tgoto L_00CF;\n\tgoto L_00CF;\n\tgoto L_00CF;\nL_00CF:\n\tv155 = Il2CppMethodInfo != 1;\n\tif (v155) goto L_0116;\n\tv468 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>+Enumerator<EasyMobile.AdPlacement>::MoveNext(v186);\n\tv138 = v468.m_value;\n\tv339 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>+Enumerator<EasyMobile.AdPlacement>::MoveNext(v468);\nL_00D6:\n\tv345 = &v21 @ X29 - 0x80;\n\tv347 = System.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>+Enumerator<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::Dispose(v345);\n\tv353 = v116 + 1;\n\tv355 = v353 == 0;\n\tif (v355) goto L_00F0;\n\tv367 = ~v138;\n\tif (v367) goto L_00F7;\n\tv405 = *([v54 @ X23_v1+v116 @ X24_v5*4]) == 0x8C;\n\tif (v405) goto L_00F7;\nL_00EF:\n\tthrow System.TypeLoadException;\nL_00F0:\n\tv394 = ~v138;\n\tv395 = ~v394;\n\tif (v395) goto L_00EF;\nL_00F7:\n\tgoto L_0105;\n\tv422 = *([v413 @ X0_v17 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv423 = v422 == 0;\n\tv424 = ~v423;\n\t// 251 ConditionalJump @b63, v424 @ TEMP_v23\n\tv439 = \"il2cpp_codegen_runtime_class_init\"(v413, v130, v80, v36, v37, v38, v39, v40, v128, v126, v43, v44, v45, v46, v47, v48);\n\tv426 = EasyMobile.Advertising;\nL_0105:\n\tSystem.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::Clear(v136.activeBannerAds);\n\treturn;\n\tv139 = new System.NullReferenceException();\nL_0116:\n\tv193 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>+Enumerator<EasyMobile.AdPlacement>::MoveNext(v185);\n\treturn;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void DestroyAllBannerAds()
		{
			//IL_004f: Expected O, but got I8
			//IL_039c: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_02a1: Expected O, but got I
			//IL_02b9: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_00df: Expected O, but got I
			//IL_03d5: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_018d: Expected O, but got I
			//IL_0139: Expected O, but got I
			//IL_01e5: Expected I4, but got I8
			//IL_01f3: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Dictionary<AdNetwork, List<AdPlacement>>.Enumerator enumerator = activeBannerAds.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B8]");
			_ = 0;
			object obj4 = 4294967295L;
			bool flag = false;
			while (true)
			{
				Dictionary<AdNetwork, List<AdPlacement>>.Enumerator enumerator2 = (Dictionary<AdNetwork, List<AdPlacement>>.Enumerator)((long)(IntPtr)obj - 128L);
				if (((Dictionary<AdNetwork, List<AdPlacement>>.Enumerator*)enumerator2)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					List<AdPlacement> list = (List<AdPlacement>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					if ((IntPtr)0 == (IntPtr)0 || list.Count < 1)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
					AdClientImpl workableAdClient = GetWorkableAdClient(AdNetwork.None);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					List<AdPlacement>.Enumerator enumerator3 = ((List<AdPlacement>)0).GetEnumerator();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
					_ = 0;
					while (true)
					{
						List<AdPlacement>.Enumerator enumerator4 = (List<AdPlacement>.Enumerator)((long)(IntPtr)obj - 160L);
						if (!((List<AdPlacement>.Enumerator*)enumerator4)->MoveNext())
						{
							break;
						}
						if (workableAdClient != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							workableAdClient.DestroyBannerAd((AdPlacement)0);
							continue;
						}
						goto IL_0158;
					}
					obj4 = (long)(IntPtr)obj4 + 1L;
					_ = 115;
					List<AdPlacement>.Enumerator enumerator5 = (List<AdPlacement>.Enumerator)((long)(IntPtr)obj - 160L);
					((List<AdPlacement>.Enumerator*)enumerator5)->Dispose();
					object obj5 = (long)(IntPtr)obj4 + 1L;
					if (obj5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X23_v1+v116 @ X24_v5*4]");
						if ((IntPtr)0 == (IntPtr)115)
						{
							int num = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj4);
							obj4 = (long)(IntPtr)obj4 + (long)num;
							continue;
						}
					}
					bool flag2 = !flag;
					flag = false;
					if (!flag2)
					{
						flag = false;
						throw new TypeLoadException();
					}
					continue;
				}
				obj4 = (long)(IntPtr)obj4 + 1L;
				_ = 140;
				goto IL_0292;
				IL_0292:
				Dictionary<AdNetwork, List<AdPlacement>>.Enumerator enumerator6 = (Dictionary<AdNetwork, List<AdPlacement>>.Enumerator)((long)(IntPtr)obj - 128L);
				((Dictionary<AdNetwork, List<AdPlacement>>.Enumerator*)enumerator6)->Dispose();
				object obj6 = (long)(IntPtr)obj4 + 1L;
				if (obj6 != null)
				{
					if (flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X23_v1+v116 @ X24_v5*4]");
						if ((IntPtr)0 != (IntPtr)140)
						{
							goto IL_0314;
						}
					}
				}
				else if (flag)
				{
					goto IL_0314;
				}
				activeBannerAds.Clear();
				return;
				IL_0314:
				throw new TypeLoadException();
				IL_0158:
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					break;
				}
				bool flag3 = ((List<AdPlacement>.Enumerator*)ex)->MoveNext();
				flag = ((bool*)(flag3 ? 1 : 0))->m_value;
				bool flag4 = (flag3 ? ((List<AdPlacement>.Enumerator*)1) : ((List<AdPlacement>.Enumerator*)null))->MoveNext();
				goto IL_0292;
			}
			NullReferenceException ex2 = default(NullReferenceException);
			bool flag5 = ((List<AdPlacement>.Enumerator*)ex2)->MoveNext();
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0xA49A44", Offset = "0xA49A44", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFEC98]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F15]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv55 = EasyMobile.Advertising::IsAdRemoved();\n\tv57 = v55 == 0;\n\tif (v57) goto L_0034;\n\treturn;\nL_0034:\n\tgoto L_0063;\n\tv135 = *([v130 @ X8_v7+B0]);\n\tv136 = 0;\n\tv137 = v135 + 8;\n\tv139 = *([v175 @ X11_v5-8]);\n\tv181 = v139 == v133;\n\tif (v181) goto L_0054;\n\tv161 = v176 + 1;\n\tv186 = v161 < v132;\n\tv157 = ~v186;\n\tv159 = v175 + 0x10;\n\tv141 = ~v157;\n\tif (v141) goto L_FFFFFFFF;\n\tv162 = 0x13;\n\tv163 = v16;\n\tv164 = 0x8909C4(v163, v133, v162, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0063;\nL_0054:\n\tv187 = *([v175 @ X11_v5]);\n\tv188 = v187 + 0x13;\n\tv189 = v188 << 4;\n\tv190 = v130 + v189;\n\tv191 = v190 + 0x130;\nL_0063:\n\tEasyMobile.IAdClient::LoadInterstitialAd(client, placement);\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void LoadInterstitialAd(IAdClient client, AdPlacement placement)
		{
			if (!IsAdRemoved())
			{
				client.LoadInterstitialAd(placement);
			}
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0xA49CB8", Offset = "0xA49CB8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAE098]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F16]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv55 = EasyMobile.Advertising::IsAdRemoved();\n\tv57 = v55 == 0;\n\tif (v57) goto L_0035;\n\treturn 0;\nL_0035:\n\tgoto L_0064;\n\tv136 = *([v131 @ X8_v7+B0]);\n\tv137 = 0;\n\tv138 = v136 + 8;\n\tv140 = *([v176 @ X11_v5-8]);\n\tv182 = v140 == v134;\n\tif (v182) goto L_0055;\n\tv162 = v177 + 1;\n\tv187 = v162 < v133;\n\tv158 = ~v187;\n\tv160 = v176 + 0x10;\n\tv142 = ~v158;\n\tif (v142) goto L_FFFFFFFF;\n\tv163 = 0x14;\n\tv164 = v16;\n\tv165 = 0x8909C4(v164, v134, v163, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0064;\nL_0055:\n\tv188 = *([v176 @ X11_v5]);\n\tv189 = v188 + 0x14;\n\tv190 = v189 << 4;\n\tv191 = v131 + v190;\n\tv192 = v191 + 0x130;\nL_0064:\n\tinterfaceTailCallResult = EasyMobile.IAdClient::IsInterstitialAdReady(client, placement);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsInterstitialAdReady(IAdClient client, AdPlacement placement)
		{
			if (IsAdRemoved())
			{
				return false;
			}
			return client.IsInterstitialAdReady(placement);
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0xA49F30", Offset = "0xA49F30", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEC630]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F17]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv55 = EasyMobile.Advertising::IsAdRemoved();\n\tv57 = v55 == 0;\n\tif (v57) goto L_0045;\n\tgoto L_003B;\n\tv65 = *([v60 @ X0_v12+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003B;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v60, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003B:\n\tUnityEngine.Debug::Log(\"Could not show interstitial ad: ads were disabled by RemoveAds().\");\n\treturn;\nL_0045:\n\tgoto L_0074;\n\tv89 = *([v82 @ X8_v7+B0]);\n\tv90 = 0;\n\tv91 = v89 + 8;\n\tv93 = *([v192 @ X11_v5-8]);\n\tv198 = v93 == v85;\n\tif (v198) goto L_0065;\n\tv126 = v193 + 1;\n\tv203 = v126 < v84;\n\tv120 = ~v203;\n\tv123 = v192 + 0x10;\n\tv96 = ~v120;\n\tif (v96) goto L_FFFFFFFF;\n\tv127 = 0x15;\n\tv128 = v16;\n\tv129 = 0x8909C4(v128, v85, v127, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0074;\nL_0065:\n\tv204 = *([v192 @ X11_v5]);\n\tv205 = v204 + 0x15;\n\tv206 = v205 << 4;\n\tv207 = v82 + v206;\n\tv208 = v207 + 0x130;\nL_0074:\n\tEasyMobile.IAdClient::ShowInterstitialAd(client, placement);\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ShowInterstitialAd(IAdClient client, AdPlacement placement)
		{
			if (IsAdRemoved())
			{
				Debug.Log("Could not show interstitial ad: ads were disabled by RemoveAds().");
			}
			else
			{
				client.ShowInterstitialAd(placement);
			}
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0xA4A1D4", Offset = "0xA4A1D4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EC9288]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F18]) = v41;\nL_001D:\n\tgoto L_004C;\n\tv51 = *([v44 @ X8_v3+B0]);\n\tv52 = 0;\n\tv53 = v51 + 8;\n\tv55 = *([v102 @ X11_v5-8]);\n\tv108 = v55 == v47;\n\tif (v108) goto L_003D;\n\tv88 = v103 + 1;\n\tv165 = v88 < v46;\n\tv82 = ~v165;\n\tv85 = v102 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_FFFFFFFF;\n\tv89 = 0x1D;\n\tv90 = v16;\n\tv91 = 0x8909C4(v90, v47, v89, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_003D:\n\tv166 = *([v102 @ X11_v5]);\n\tv167 = v166 + 0x1D;\n\tv168 = v167 << 4;\n\tv169 = v44 + v168;\n\tv170 = v169 + 0x130;\nL_004C:\n\tEasyMobile.IAdClient::LoadRewardedAd(client, placement);\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void LoadRewardedAd(IAdClient client, AdPlacement placement)
		{
			client.LoadRewardedAd(placement);
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0xA4A410", Offset = "0xA4A410", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDC820]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F19]) = v41;\nL_0018:\n\tv44 = client->klass;\n\tv48 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v48) goto L_003B;\n\tv102 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_0026:\n\tv108 = *([v102 @ X11_v5-8]) == EasyMobile.IAdClient;\n\tif (v108) goto L_003E;\n\tv103 = v103 + 1;\n\tv165 = v103 < *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv82 = ~v165;\n\tv102 = v102 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_0026;\nL_003B:\n\tv172 = 0x8909C4(client, EasyMobile.IAdClient, 0x1E, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0042;\nL_003E:\n\tv167 = *([v102 @ X11_v5]) + 0x1E;\n\tv168 = v167 << 4;\n\tv169 = v44 + v168;\n\tv172 = v169 + 0x130;\nL_0042:\n\tv116 = *([v172 @ X0_v4]);\n\tv123 = *([v172 @ X0_v4+8]);\n\t// 76 IndirectJump v116 @ X3_v1, client @ X0 (EasyMobile.IAdClient), client @ X0 (EasyMobile.IAdClient), placement @ X1 (EasyMobile.AdPlacement), v123 @ X2_v2, v116 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsRewardedAdReady(IAdClient client, AdPlacement placement)
		{
			//IL_000d: Expected I, but got O
			//IL_013d: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IntPtr intPtr = (IntPtr)client;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAdClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 30;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0125;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0125;
			IL_0125:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v116 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0xA4A64C", Offset = "0xA4A64C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F05C68]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F1A]) = v41;\nL_0018:\n\tv44 = client->klass;\n\tv48 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v48) goto L_003B;\n\tv102 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_0026:\n\tv108 = *([v102 @ X11_v5-8]) == EasyMobile.IAdClient;\n\tif (v108) goto L_003E;\n\tv103 = v103 + 1;\n\tv165 = v103 < *([v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv82 = ~v165;\n\tv102 = v102 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_0026;\nL_003B:\n\tv172 = 0x8909C4(client, EasyMobile.IAdClient, 0x1F, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0042;\nL_003E:\n\tv167 = *([v102 @ X11_v5]) + 0x1F;\n\tv168 = v167 << 4;\n\tv169 = v44 + v168;\n\tv172 = v169 + 0x130;\nL_0042:\n\tv116 = *([v172 @ X0_v4]);\n\tv123 = *([v172 @ X0_v4+8]);\n\t// 76 IndirectJump v116 @ X3_v1, client @ X0 (EasyMobile.IAdClient), client @ X0 (EasyMobile.IAdClient), placement @ X1 (EasyMobile.AdPlacement), v123 @ X2_v2, v116 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ShowRewardedAd(IAdClient client, AdPlacement placement)
		{
			//IL_000d: Expected I, but got O
			//IL_013d: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IntPtr intPtr = (IntPtr)client;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAdClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<EasyMobile.IAdClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 31;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0125;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0125;
			IL_0125:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v116 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xA4C1CC", Offset = "0xA4C1CC", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EA7E08]);\n\tv25 = *([v24 @ X8_v28]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F1B]) = v43;\nL_001D:\n\tgoto L_002D;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\t// 33 Jump @b29\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv55 = EasyMobile.Advertising;\nL_002D:\n\tv68 = System.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::TryGetValue(v58.activeBannerAds, network, &v65 @ stack_-38_v4 (System.Collections.Generic.List`1<EasyMobile.AdPlacement>));\n\tv83 = v65 == 0;\n\tif (v83) goto L_0047;\n\tv110 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::Contains(v65, placement);\n\tv116 = v110 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0071;\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::Add(v65, placement);\n\tgoto L_0071;\nL_0047:\n\tgoto L_0053;\n\tv118 = *([v111 @ X0_v13 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0053;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v111, v66, v64, v67, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv122 = EasyMobile.Advertising;\nL_0053:\n\tv97 = new System.Collections.Generic.List`1<EasyMobile.AdPlacement>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::.ctor(v97);\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::Add(v97, placement);\n\tSystem.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::set_Item(v126.activeBannerAds, network, v97);\nL_0071:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddActiveBannerAd(AdNetwork network, AdPlacement placement)
		{
			bool flag = activeBannerAds.TryGetValue(network, out var value);
			if (value != null)
			{
				if (!value.Contains(placement))
				{
					value.Add(placement);
				}
			}
			else
			{
				List<AdPlacement> list = new List<AdPlacement>();
				list.Add(placement);
				activeBannerAds.set_Item(network, list);
			}
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0xA4C33C", Offset = "0xA4C33C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EBC618]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F1C]) = v41;\nL_001C:\n\tgoto L_002C;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\t// 32 Jump @b15\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v45, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = EasyMobile.Advertising;\nL_002C:\n\tv66 = System.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::TryGetValue(v56.activeBannerAds, network, &v63 @ stack_-28_v2 (System.Collections.Generic.List`1<EasyMobile.AdPlacement>));\n\tv69 = v63 == 0;\n\tif (v69) goto L_003B;\n\tv74 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::Remove(v63, placement);\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void RemoveActiveBannerAd(AdNetwork network, AdPlacement placement)
		{
			bool flag = activeBannerAds.TryGetValue(network, out var value);
			if (value != null)
			{
				bool flag2 = value.Remove(placement);
			}
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xA4C3F4", Offset = "0xA4C3F4", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EA6C98]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2021F1D]) = v43;\nL_001E:\n\tgoto L_0026;\n\tv53 = *([v46 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0026;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv62 = System.Type::GetTypeFromHandle(EasyMobile.AdNetwork);\n\tgoto L_0037;\n\tv70 = *([v66 @ X8_v10+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0037;\n\tv80 = v66;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v80, v61, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0037:\n\tv79 = System.Enum::GetValues(v62);\n\tv83 = System.Array::GetEnumerator(v79);\n\tv146 = v83 == 0;\n\tif (v146) goto L_00C9;\nL_0049:\n\tgoto L_0070;\n\tv226 = *([v212 @ X8_v21+B0]);\n\tv227 = 0;\n\tv228 = v226 + 8;\n\tv230 = *([v317 @ X11_v23-8]);\n\tv322 = v230 == v213;\n\tif (v322) goto L_0069;\n\tv250 = v316 + 1;\n\tv329 = v250 < v214;\n\tv248 = ~v329;\n\tv252 = v317 + 0x10;\n\tv232 = ~v248;\n\tif (v232) goto L_FFFFFFFF;\n\tv253 = v144;\n\tv254 = 0;\n\tv255 = 0x8909C4(v253, v213, v254, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0070;\nL_0069:\n\tv330 = *([v317 @ X11_v23]);\n\tv331 = v330 << 4;\n\tv332 = v212 + v331;\n\tv333 = v332 + 0x130;\nL_0070:\n\tv354 = System.Collections.IEnumerator::MoveNext(v83);\n\tv356 = v354 == 0;\n\tif (v356) goto L_FFFFFFFF;\n\tv395 = *([v83 @ X0_v29 (System.Collections.IEnumerator)]);\n\tv398 = *([v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v398) goto L_0096;\n\tv468 = *([v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0081:\n\tv473 = *([v468 @ X11_v18-8]) == System.Collections.IEnumerator;\n\tif (v473) goto L_0099;\n\tv467 = v467 + 1;\n\tv507 = v467 < *([v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv448 = ~v507;\n\tv468 = v468 + 0x10;\n\tv432 = ~v448;\n\tif (v432) goto L_0081;\nL_0096:\n\tv523 = 0x8909C4(v83, System.Collections.IEnumerator, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A0;\nL_0099:\n\tv509 = *([v468 @ X11_v18]) + 1;\n\tv510 = v509 << 4;\n\tv511 = v395 + v510;\n\tv523 = v511 + 0x130;\nL_00A0:\n\t*([v523 @ X0_v34])(v528, v83, *([v523 @ X0_v34+8]), v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv180 = v180_asT == 0;\n\tif (v180) goto L_00C6;\n\tv204 = \"il2cpp_vm_object_unbox\"(v528, EasyMobile.AdNetwork, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv207 = *([v204 @ X0_v40]) == 0;\n\tif (v207) goto L_0049;\n\tgoto L_00C1;\n\tv598 = *([v594 @ X0_v41+E0]);\n\tv599 = v598 == 0;\n\tv600 = ~v599;\n\tif (v600) goto L_00C1;\n\tv602 = \"il2cpp_codegen_runtime_class_init\"(v594, v202, v93, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00C1:\n\tEasyMobile.Advertising::GrantDataPrivacyConsent(*([v204 @ X0_v40]));\n\tgoto L_0049;\n\tgoto L_00E2;\nL_00C6:\n\tv563 = new System.InvalidCastException();\n\tv138 = new System.NullReferenceException();\n\tv145 = new System.NullReferenceException();\nL_00C9:\n\tv171 = new System.NullReferenceException();\n\tgoto L_00D8;\n\tgoto L_00D8;\n\tgoto L_00D8;\n\tgoto L_00D8;\n\tgoto L_00D8;\nL_00D8:\n\tv225 = v295 != 1;\n\tif (v225) goto L_0129;\n\tv256 = 0x6D2BC0(v171, v295, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv260 = *([v256 @ X0_v25]);\n\tv328 = 0x6D2490(v256, v295, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E2:\n\t// 226 IsInst v425 @ X0_v11 (System.IDisposable), typeof(System.IDisposable), v421 @ X19_v4 (System.Collections.IEnumerator)\n\tv456 = v425 == 0;\n\tif (v456) goto L_0112;\n\tgoto L_0111;\n\tv529 = *([v478 @ X8_v13+B0]);\n\tv530 = 0;\n\tv531 = v529 + 8;\n\tv533 = *([v575 @ X11_v7-8]);\n\tv580 = v533 == v479;\n\tif (v580) goto L_010A;\n\tv553 = v574 + 1;\n\tv586 = v553 < v480;\n\tv551 = ~v586;\n\tv555 = v575 + 0x10;\n\tv535 = ~v551;\n\tif (v535) goto L_FFFFFFFF;\n\tv556 = v304;\n\tv557 = 0;\n\tv558 = 0x8909C4(v556, v479, v557, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0111;\nL_010A:\n\tv587 = *([v575 @ X11_v7]);\n\tv588 = v587 << 4;\n\tv589 = v478 + v588;\n\tv590 = v589 + 0x130;\nL_0111:\n\tSystem.IDisposable::Dispose(v425);\nL_0112:\n\tv506 = v292 + 1;\n\tv276 = v506 == 0;\n\tv266 = ~v276;\n\tif (v266) goto L_0124;\n\tv559 = v260 == 0;\n\tv300 = ~v559;\n\tif (v300) goto L_0128;\nL_0124:\n\treturn;\nL_0128:\n\tv298 = new System.TypeLoadException();\nL_0129:\n\tv305 = 0x6D2380(v171, v295, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void GrantAllNetworksDataPrivacyConsent()
		{
			//IL_004b: Expected I, but got O
			//IL_026c: Expected I4, but got O
			//IL_0069: Expected I, but got O
			//IL_00a4: Expected O, but got I
			//IL_0176: Expected I4, but got O
			//IL_02ce: Expected I, but got O
			//IL_0203: Expected I, but got O
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_014c: Expected O, but got I
			//IL_015b: Expected O, but got I
			//IL_00f0: Expected O, but got I
			//IL_01c8: Expected I4, but got O
			Type typeFromHandle = typeof(AdNetwork);
			Array values = Enum.GetValues(typeFromHandle);
			IEnumerator enumerator = values.GetEnumerator();
			bool flag = enumerator == null;
			IntPtr intPtr = (IntPtr)null;
			IEnumerator enumerator2 = enumerator;
			if (flag)
			{
				goto IL_022c;
			}
			object obj5 = default(object);
			object obj6 = default(object);
			int num4;
			while (enumerator.MoveNext())
			{
				IntPtr intPtr2 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0109;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					bool flag2 = (long)num2 < 0L;
					bool flag3 = !flag2;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_0109;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr2 + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				num4 = 0;
				goto IL_033f;
				IL_0109:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				num4 = 1;
				goto IL_033f;
				IL_033f:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v523 @ X0_v34] (should have been resolved before IL gen)");
				if ((int)((obj5 is AdNetwork) ? obj5 : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					if (obj6 != null)
					{
						GrantDataPrivacyConsent((AdNetwork)obj6);
					}
					continue;
				}
				goto IL_01ec;
			}
			int num5 = 0;
			int num6 = 0;
			enumerator2 = enumerator;
			goto IL_0353;
			IL_022c:
			NullReferenceException ex = new NullReferenceException();
			if (intPtr != (IntPtr)1)
			{
				goto IL_02db;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj7 = default(object);
			num5 = (int)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			num6 = -1;
			goto IL_0353;
			IL_01ec:
			InvalidCastException ex2 = new InvalidCastException();
			intPtr = (IntPtr)typeof(AdNetwork);
			NullReferenceException ex3 = new NullReferenceException();
			enumerator2 = enumerator;
			NullReferenceException ex4 = new NullReferenceException();
			goto IL_022c;
			IL_0353:
			(enumerator2 as IDisposable)?.Dispose();
			if (num6 + 1 != 0 || num5 == 0)
			{
				return;
			}
			TypeLoadException ex5 = new TypeLoadException();
			num4 = 0;
			intPtr = (IntPtr)null;
			ex = (NullReferenceException)(object)ex5;
			goto IL_02db;
			IL_02db:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0xA4AC5C", Offset = "0xA4AC5C", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ED9170]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2021F1E]) = v43;\nL_001E:\n\tgoto L_0026;\n\tv53 = *([v46 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0026;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv62 = System.Type::GetTypeFromHandle(EasyMobile.AdNetwork);\n\tgoto L_0037;\n\tv70 = *([v66 @ X8_v10+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0037;\n\tv80 = v66;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v80, v61, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0037:\n\tv79 = System.Enum::GetValues(v62);\n\tv83 = System.Array::GetEnumerator(v79);\n\tv146 = v83 == 0;\n\tif (v146) goto L_00C9;\nL_0049:\n\tgoto L_0070;\n\tv226 = *([v212 @ X8_v21+B0]);\n\tv227 = 0;\n\tv228 = v226 + 8;\n\tv230 = *([v317 @ X11_v23-8]);\n\tv322 = v230 == v213;\n\tif (v322) goto L_0069;\n\tv250 = v316 + 1;\n\tv329 = v250 < v214;\n\tv248 = ~v329;\n\tv252 = v317 + 0x10;\n\tv232 = ~v248;\n\tif (v232) goto L_FFFFFFFF;\n\tv253 = v144;\n\tv254 = 0;\n\tv255 = 0x8909C4(v253, v213, v254, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0070;\nL_0069:\n\tv330 = *([v317 @ X11_v23]);\n\tv331 = v330 << 4;\n\tv332 = v212 + v331;\n\tv333 = v332 + 0x130;\nL_0070:\n\tv354 = System.Collections.IEnumerator::MoveNext(v83);\n\tv356 = v354 == 0;\n\tif (v356) goto L_FFFFFFFF;\n\tv395 = *([v83 @ X0_v29 (System.Collections.IEnumerator)]);\n\tv398 = *([v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v398) goto L_0096;\n\tv468 = *([v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0081:\n\tv473 = *([v468 @ X11_v18-8]) == System.Collections.IEnumerator;\n\tif (v473) goto L_0099;\n\tv467 = v467 + 1;\n\tv507 = v467 < *([v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv448 = ~v507;\n\tv468 = v468 + 0x10;\n\tv432 = ~v448;\n\tif (v432) goto L_0081;\nL_0096:\n\tv523 = 0x8909C4(v83, System.Collections.IEnumerator, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A0;\nL_0099:\n\tv509 = *([v468 @ X11_v18]) + 1;\n\tv510 = v509 << 4;\n\tv511 = v395 + v510;\n\tv523 = v511 + 0x130;\nL_00A0:\n\t*([v523 @ X0_v34])(v528, v83, *([v523 @ X0_v34+8]), v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv180 = v180_asT == 0;\n\tif (v180) goto L_00C6;\n\tv204 = \"il2cpp_vm_object_unbox\"(v528, EasyMobile.AdNetwork, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv207 = *([v204 @ X0_v40]) == 0;\n\tif (v207) goto L_0049;\n\tgoto L_00C1;\n\tv598 = *([v594 @ X0_v41+E0]);\n\tv599 = v598 == 0;\n\tv600 = ~v599;\n\tif (v600) goto L_00C1;\n\tv602 = \"il2cpp_codegen_runtime_class_init\"(v594, v202, v93, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00C1:\n\tEasyMobile.Advertising::RevokeDataPrivacyConsent(*([v204 @ X0_v40]));\n\tgoto L_0049;\n\tgoto L_00E2;\nL_00C6:\n\tv563 = new System.InvalidCastException();\n\tv138 = new System.NullReferenceException();\n\tv145 = new System.NullReferenceException();\nL_00C9:\n\tv171 = new System.NullReferenceException();\n\tgoto L_00D8;\n\tgoto L_00D8;\n\tgoto L_00D8;\n\tgoto L_00D8;\n\tgoto L_00D8;\nL_00D8:\n\tv225 = v295 != 1;\n\tif (v225) goto L_0129;\n\tv256 = 0x6D2BC0(v171, v295, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv260 = *([v256 @ X0_v25]);\n\tv328 = 0x6D2490(v256, v295, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E2:\n\t// 226 IsInst v425 @ X0_v11 (System.IDisposable), typeof(System.IDisposable), v421 @ X19_v4 (System.Collections.IEnumerator)\n\tv456 = v425 == 0;\n\tif (v456) goto L_0112;\n\tgoto L_0111;\n\tv529 = *([v478 @ X8_v13+B0]);\n\tv530 = 0;\n\tv531 = v529 + 8;\n\tv533 = *([v575 @ X11_v7-8]);\n\tv580 = v533 == v479;\n\tif (v580) goto L_010A;\n\tv553 = v574 + 1;\n\tv586 = v553 < v480;\n\tv551 = ~v586;\n\tv555 = v575 + 0x10;\n\tv535 = ~v551;\n\tif (v535) goto L_FFFFFFFF;\n\tv556 = v304;\n\tv557 = 0;\n\tv558 = 0x8909C4(v556, v479, v557, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0111;\nL_010A:\n\tv587 = *([v575 @ X11_v7]);\n\tv588 = v587 << 4;\n\tv589 = v478 + v588;\n\tv590 = v589 + 0x130;\nL_0111:\n\tSystem.IDisposable::Dispose(v425);\nL_0112:\n\tv506 = v292 + 1;\n\tv276 = v506 == 0;\n\tv266 = ~v276;\n\tif (v266) goto L_0124;\n\tv559 = v260 == 0;\n\tv300 = ~v559;\n\tif (v300) goto L_0128;\nL_0124:\n\treturn;\nL_0128:\n\tv298 = new System.TypeLoadException();\nL_0129:\n\tv305 = 0x6D2380(v171, v295, v263, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void RevokeAllNetworksDataPrivacyConsent()
		{
			//IL_004b: Expected I, but got O
			//IL_026c: Expected I4, but got O
			//IL_0069: Expected I, but got O
			//IL_00a4: Expected O, but got I
			//IL_0176: Expected I4, but got O
			//IL_02ce: Expected I, but got O
			//IL_0203: Expected I, but got O
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_014c: Expected O, but got I
			//IL_015b: Expected O, but got I
			//IL_00f0: Expected O, but got I
			//IL_01c8: Expected I4, but got O
			Type typeFromHandle = typeof(AdNetwork);
			Array values = Enum.GetValues(typeFromHandle);
			IEnumerator enumerator = values.GetEnumerator();
			bool flag = enumerator == null;
			IntPtr intPtr = (IntPtr)null;
			IEnumerator enumerator2 = enumerator;
			if (flag)
			{
				goto IL_022c;
			}
			object obj5 = default(object);
			object obj6 = default(object);
			int num4;
			while (enumerator.MoveNext())
			{
				IntPtr intPtr2 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0109;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					bool flag2 = (long)num2 < 0L;
					bool flag3 = !flag2;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_0109;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr2 + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				num4 = 0;
				goto IL_033f;
				IL_0109:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				num4 = 1;
				goto IL_033f;
				IL_033f:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v523 @ X0_v34] (should have been resolved before IL gen)");
				if ((int)((obj5 is AdNetwork) ? obj5 : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					if (obj6 != null)
					{
						RevokeDataPrivacyConsent((AdNetwork)obj6);
					}
					continue;
				}
				goto IL_01ec;
			}
			int num5 = 0;
			int num6 = 0;
			enumerator2 = enumerator;
			goto IL_0353;
			IL_022c:
			NullReferenceException ex = new NullReferenceException();
			if (intPtr != (IntPtr)1)
			{
				goto IL_02db;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj7 = default(object);
			num5 = (int)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			num6 = -1;
			goto IL_0353;
			IL_01ec:
			InvalidCastException ex2 = new InvalidCastException();
			intPtr = (IntPtr)typeof(AdNetwork);
			NullReferenceException ex3 = new NullReferenceException();
			enumerator2 = enumerator;
			NullReferenceException ex4 = new NullReferenceException();
			goto IL_022c;
			IL_0353:
			(enumerator2 as IDisposable)?.Dispose();
			if (num6 + 1 != 0 || num5 == 0)
			{
				return;
			}
			TypeLoadException ex5 = new TypeLoadException();
			num4 = 0;
			intPtr = (IntPtr)null;
			ex = (NullReferenceException)(object)ex5;
			goto IL_02db;
			IL_02db:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xA48C08", Offset = "0xA48C08", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE4400]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F1F]) = v38;\nL_0014:\n\tv39 = network < 0xA;\n\tv40 = ~v39;\n\tv41 = network - 0xA;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_0063;\n\tv52 = 0x1818000 + 0x8DC;\n\tv54 = *([v52 @ X9_v5 (System.Int32)+network @ X0 (EasyMobile.AdNetwork)*4]) + v52;\n\t// 37 IndirectJump v54 @ X8_v14, network @ X0 (EasyMobile.AdNetwork), network @ X0 (EasyMobile.AdNetwork), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX0 = 0;\n\tX0 = EasyMobile.NoOpClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = EasyMobile.AdMobClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = EasyMobile.AppLovinClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = EasyMobile.AudienceNetworkClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = 0;\n\tX0 = EasyMobile.IronSourceClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX8 = *([1ED9A58]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_003E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_003E:\n\tX0 = 0;\n\tX0 = EasyMobile.TapjoyClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = EasyMobile.AdColonyClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = EasyMobile.ChartboostClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = 0;\n\tX0 = EasyMobile.HeyzapClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX8 = *([1F05728]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0054;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0054;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0054:\n\tX0 = 0;\n\tX0 = EasyMobile.MoPubClientImpl::CreateClient(X0);\n\tgoto L_0059;\n\tX0 = 0;\n\tX0 = EasyMobile.UnityAdsClientImpl::CreateClient(X0);\nL_0059:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\t// 93 ShiftStack 48\n\treturn X0;\nL_0063:\n\t// 99 Box network @ X0 (EasyMobile.AdNetwork), typeof(EasyMobile.AdNetwork), &network @ X0 (EasyMobile.AdNetwork)\n\tnetwork = 0x846A20(network, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv79 = *([network @ X0 (EasyMobile.AdNetwork)]);\n\t*([v79 @ X8_v5+160])(v83, network, *([v79 @ X8_v5+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tnetwork = 0x846F90(network, *([v79 @ X8_v5+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv92 = System.String::Concat(\"No client implemented for the network:\", v83);\n\tv97 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v97, v92);\n\tthrow v97;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AdClientImpl GetAdClient(AdNetwork network)
		{
			//IL_0040: Expected I4, but got O
			//IL_0057: Expected O, but got I4
			//IL_0029: Expected O, but got I
			bool flag = network < AdNetwork.UnityAds;
			bool flag2 = !flag;
			int num = (int)(network - 10);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 2268;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v5 (System.Int32)+network @ X0 (EasyMobile.AdNetwork)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X8_v14 (should have been resolved before IL gen)");
			}
			AdNetwork adNetwork = (AdNetwork)(object)network;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
			object obj2 = network;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v79 @ X8_v5+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846F90 (inside HutongGames.Extensions.TextureExtensions+Point::.ctor +0x18)");
			string text = default(string);
			string message = "No client implemented for the network:" + text;
			NotImplementedException ex = new NotImplementedException(message);
			throw ex;
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0xA47448", Offset = "0xA47448", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED42D0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F20]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = EasyMobile.Advertising::GetAdClient(network);\n\tv55 = v53 == 0;\n\tif (v55) goto L_004B;\n\tv60 = EasyMobile.AdClientImpl::get_Network(v53);\n\tv61 = v60 == 0;\n\tif (v61) goto L_004B;\n\tgoto L_0036;\n\tv86 = *([v82 @ X0_v10+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0036;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v82, v59, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0036:\n\tEasyMobile.Advertising::SubscribeAdClientEvents(v53);\n\tv71 = EasyMobile.AdClientImpl::get_IsInitialized(v53);\n\tv96 = v71 == 0;\n\tv73 = ~v96;\n\tif (v73) goto L_004B;\n\tv70 = EasyMobile.AdClientImpl::Init(v53);\nL_004B:\n\treturn v53;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AdClientImpl SetupAdClient(AdNetwork network)
		{
			AdClientImpl adClient = GetAdClient(network);
			if (adClient != null && adClient.Network != AdNetwork.None)
			{
				SubscribeAdClientEvents(adClient);
				if (!adClient.IsInitialized)
				{
					adClient.Init();
				}
			}
			return adClient;
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0xA47F6C", Offset = "0xA47F6C", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA8168]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F21]) = v38;\nL_0014:\n\tv39 = network < 0xA;\n\tv40 = ~v39;\n\tv41 = network - 0xA;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_00BF;\n\tv52 = 0x1818000 + 0x8B0;\n\tv54 = *([v52 @ X9_v5 (System.Int32)+network @ X0 (EasyMobile.AdNetwork)*4]) + v52;\n\t// 37 IndirectJump v54 @ X8_v14, network @ X0 (EasyMobile.AdNetwork), network @ X0 (EasyMobile.AdNetwork), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX0 = 0;\n\tX0 = EasyMobile.NoOpClientImpl::CreateClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0035;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0035;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0035:\n\tX0 = EasyMobile.Advertising::get_AdMobClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = 0xA59764(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0044;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0044;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0044:\n\tX0 = EasyMobile.Advertising::get_AppLovinClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0052;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0052;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0052:\n\tX0 = EasyMobile.Advertising::get_AudienceNetworkClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0060;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0060;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0060:\n\tX0 = EasyMobile.Advertising::get_IronSourceClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006E:\n\tX0 = EasyMobile.Advertising::get_TapjoyClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_007C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007C:\n\tX0 = EasyMobile.Advertising::get_AdColonyClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_008A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008A:\n\tX0 = EasyMobile.Advertising::get_ChartboostClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0098;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0098;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0098:\n\tX0 = EasyMobile.Advertising::get_HeyzapClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00A6;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A6;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A6:\n\tX0 = EasyMobile.Advertising::get_MoPubClient(X0);\n\tgoto L_00B5;\n\tX8 = *([1EE2138]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00B4;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B4;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B4:\n\tX0 = EasyMobile.Advertising::get_UnityAdsClient(X0);\nL_00B5:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\t// 185 ShiftStack 48\n\treturn X0;\nL_00BF:\n\t// 191 Box network @ X0 (EasyMobile.AdNetwork), typeof(EasyMobile.AdNetwork), &network @ X0 (EasyMobile.AdNetwork)\n\tnetwork = 0x846A20(network, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv79 = *([network @ X0 (EasyMobile.AdNetwork)]);\n\t*([v79 @ X8_v5+160])(v83, network, *([v79 @ X8_v5+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tnetwork = 0x846F90(network, *([v79 @ X8_v5+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv92 = System.String::Concat(\"No client found for the network:\", v83);\n\tv97 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v97, v92);\n\tthrow v97;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AdClientImpl GetWorkableAdClient(AdNetwork network)
		{
			//IL_0040: Expected I4, but got O
			//IL_0057: Expected O, but got I4
			//IL_0029: Expected O, but got I
			bool flag = network < AdNetwork.UnityAds;
			bool flag2 = !flag;
			int num = (int)(network - 10);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 2224;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v5 (System.Int32)+network @ X0 (EasyMobile.AdNetwork)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X8_v14 (should have been resolved before IL gen)");
			}
			AdNetwork adNetwork = (AdNetwork)(object)network;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
			object obj2 = network;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v79 @ X8_v5+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846F90 (inside HutongGames.Extensions.TextureExtensions+Point::.ctor +0x18)");
			string text = default(string);
			string message = "No client found for the network:" + text;
			NotImplementedException ex = new NotImplementedException(message);
			throw ex;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0xA4C850", Offset = "0xA4C850", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EADA60]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021F22]) = v44;\nL_0016:\n\tv45 = client == 0;\n\tif (v45) goto L_0053;\n\tv49 = new System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>();\n\tSystem.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>::.ctor(v49, 0, Il2CppMethodInfo);\n\tv134 = client->klass;\n\tv138 = *([v134 @ X8_v5 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v138) goto L_0049;\n\tv180 = *([v134 @ X8_v5 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_0034:\n\tv185 = *([v180 @ X11_v17-8]) == EasyMobile.IAdClient;\n\tif (v185) goto L_0055;\n\tv179 = v179 + 1;\n\tv190 = v179 < *([v134 @ X8_v5 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv161 = ~v190;\n\tv180 = v180 + 0x10;\n\tv145 = ~v161;\n\tif (v145) goto L_0034;\nL_0049:\n\tv211 = System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>::.ctor(client, EasyMobile.IAdClient, 0xE);\n\tgoto L_005D;\nL_0053:\n\treturn;\nL_0055:\n\tv192 = *([v180 @ X11_v17]) + 0xE;\n\tv193 = v192 << 4;\n\tv194 = v134 + v193;\n\tv211 = v194 + 0x130;\nL_005D:\n\t*([v211 @ X0_v4 (System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>)])(v217, client, v49, *([v211 @ X0_v4 (System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>)+8]), Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv219 = new System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>();\n\tSystem.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>::.ctor(v219, 0, Il2CppMethodInfo);\n\tgoto L_0094;\n\tv230 = *([v226 @ X8_v10+B0]);\n\tv231 = 0;\n\tv232 = v230 + 8;\n\tv234 = *([v271 @ X11_v12-8]);\n\tv276 = v234 == v227;\n\tif (v276) goto L_008B;\n\tv254 = v270 + 1;\n\tv281 = v254 < v228;\n\tv252 = ~v281;\n\tv256 = v271 + 0x10;\n\tv236 = ~v252;\n\tif (v236) goto L_FFFFFFFF;\n\tv257 = 0x16;\n\tv258 = v18;\n\tv259 = 0x8909C4(v258, v227, v257, v222, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0094;\nL_008B:\n\tv282 = *([v271 @ X11_v12]);\n\tv283 = v282 + 0x16;\n\tv284 = v283 << 4;\n\tv285 = v226 + v284;\n\tv286 = v285 + 0x130;\nL_0094:\n\tEasyMobile.IAdClient::add_RewardedAdSkipped(client, v219);\n\tv310 = new System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>();\n\tSystem.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>::.ctor(v310, 0, Il2CppMethodInfo);\n\tv317 = client->klass;\n\tv124 = *([v317 @ X8_v15 (Il2CppClass<EasyMobile.IAdClient>)+126]) == 0;\n\tif (v124) goto L_00C0;\n\tv361 = *([v317 @ X8_v15 (Il2CppClass<EasyMobile.IAdClient>)+B0]) + 8;\nL_00AB:\n\tv366 = *([v361 @ X11_v7-8]) == EasyMobile.IAdClient;\n\tif (v366) goto L_00C3;\n\tv360 = v360 + 1;\n\tv371 = v360 < *([v317 @ X8_v15 (Il2CppClass<EasyMobile.IAdClient>)+126]);\n\tv342 = ~v371;\n\tv361 = v361 + 0x10;\n\tv326 = ~v342;\n\tif (v326) goto L_00AB;\nL_00C0:\n\tv378 = System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>::.ctor(client, EasyMobile.IAdClient, 0x18);\n\tgoto L_00C7;\nL_00C3:\n\tv373 = *([v361 @ X11_v7]) + 0x18;\n\tv374 = v373 << 4;\n\tv375 = v317 + v374;\n\tv378 = v375 + 0x130;\nL_00C7:\n\tv112 = *([v378 @ X0_v14 (System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>)]);\n\tv114 = *([v378 @ X0_v14 (System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>)+8]);\n\t// 211 IndirectJump v112 @ X3_v4 (Il2CppClass<System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>>), client @ X0 (EasyMobile.IAdClient), client @ X0 (EasyMobile.IAdClient), v310 @ X0_v13 (System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>), v114 @ X2_v9, v112 @ X3_v4 (Il2CppClass<System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>>), v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SubscribeAdClientEvents(IAdClient client)
		{
			//IL_0023: Expected I, but got O
			//IL_005e: Expected O, but got I
			//IL_0254: Expected I, but got O
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00f4: Expected O, but got I
			//IL_0103: Expected O, but got I
			//IL_02ab: Expected I, but got O
			//IL_02bb: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_00aa: Expected O, but got I
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_01b3: Expected O, but got I
			//IL_01c2: Expected O, but got I
			//IL_016a: Expected O, but got I
			if (client == null)
			{
				return;
			}
			Action<IAdClient, AdPlacement> action = OnInternalInterstitialAdCompleted;
			IntPtr intPtr = (IntPtr)client;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v5 (Il2CppClass<EasyMobile.IAdClient>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v5 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X11_v17-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IAdClient))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v5 (Il2CppClass<EasyMobile.IAdClient>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 14;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					Action<IAdClient, AdPlacement> action2 = (Action<IAdClient, AdPlacement>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ X0_v4 (System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>)] (should have been resolved before IL gen)");
			Action<IAdClient, AdPlacement> value = OnInternalRewardedAdSkipped;
			client.RewardedAdSkipped += value;
			Action<IAdClient, AdPlacement> action3 = OnInternalRewardedAdCompleted;
			IntPtr intPtr2 = (IntPtr)client;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X8_v15 (Il2CppClass<EasyMobile.IAdClient>)+126]");
			Action<IAdClient, AdPlacement> action4 = default(Action<IAdClient, AdPlacement>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X8_v15 (Il2CppClass<EasyMobile.IAdClient>)+B0]");
				object obj4 = 0L + 8L;
				int num4 = 0;
				bool flag4;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ X11_v7-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IAdClient))
					{
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X8_v15 (Il2CppClass<EasyMobile.IAdClient>)+126]");
						bool flag3 = (long)num5 < 0L;
						flag4 = !flag3;
						obj4 = (long)(IntPtr)obj4 + 16L;
						continue;
					}
					object obj5 = obj4 + 24;
					int num6 = (int)((long)(IntPtr)obj5 << 4);
					object obj6 = (long)intPtr2 + (long)num6;
					action4 = (Action<IAdClient, AdPlacement>)((long)(IntPtr)obj6 + 304L);
					break;
				}
				while (!flag4);
			}
			IntPtr intPtr3 = (IntPtr)action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ X0_v14 (System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>)+8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v112 @ X3_v4 (Il2CppClass<System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0xA4CA70", Offset = "0xA4CA70", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED2168]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F23]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = EasyMobile.Advertising;\nL_0025:\n\tv59 = v57.InterstitialAdCompleted == 0;\n\tif (v59) goto L_0062;\n\tgoto L_003B;\n\tv70 = *([v53 @ X0_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\t// 46 ConditionalJump @b25, v72 @ TEMP_v16\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v53, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv177 = EasyMobile.Advertising;\n\tv77 = *([v177 @ X8_v16+B8]);\n\tv79 = *([v77 @ X8_v17+B0]);\nL_003B:\n\tgoto L_006A;\n\tv178 = *([v167 @ X8_v9+B0]);\n\tv179 = 0;\n\tv180 = v178 + 8;\n\tv182 = *([v218 @ X11_v6-8]);\n\tv224 = v182 == v170;\n\tif (v224) goto L_0063;\n\tv204 = v219 + 1;\n\tv229 = v204 < v169;\n\tv200 = ~v229;\n\tv202 = v218 + 0x10;\n\tv184 = ~v200;\n\tif (v184) goto L_FFFFFFFF;\n\tv205 = v18;\n\tv206 = 0;\n\tv207 = 0x8909C4(v205, v170, v206, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_006A;\nL_0062:\n\treturn;\nL_0063:\n\tv230 = *([v218 @ X11_v6]);\n\tv231 = v230 << 4;\n\tv232 = v167 + v231;\n\tv233 = v232 + 0x130;\nL_006A:\n\tv174 = EasyMobile.IAdClient::get_Network(client);\n\tSystem.Action`2<EasyMobile.InterstitialAdNetwork, EasyMobile.AdPlacement>::Invoke(v57.InterstitialAdCompleted, v174, placement);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnInternalInterstitialAdCompleted(IAdClient client, AdPlacement placement)
		{
			if (Advertising.InterstitialAdCompleted != null)
			{
				AdNetwork network = client.Network;
				Advertising.InterstitialAdCompleted((InterstitialAdNetwork)network, placement);
			}
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0xA4CBAC", Offset = "0xA4CBAC", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC9670]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F24]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = EasyMobile.Advertising;\nL_0025:\n\tv59 = v57.RewardedAdSkipped == 0;\n\tif (v59) goto L_0062;\n\tgoto L_003B;\n\tv70 = *([v53 @ X0_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\t// 46 ConditionalJump @b25, v72 @ TEMP_v16\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v53, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv177 = EasyMobile.Advertising;\n\tv77 = *([v177 @ X8_v16+B8]);\n\tv79 = *([v77 @ X8_v17+B8]);\nL_003B:\n\tgoto L_006A;\n\tv178 = *([v167 @ X8_v9+B0]);\n\tv179 = 0;\n\tv180 = v178 + 8;\n\tv182 = *([v218 @ X11_v6-8]);\n\tv224 = v182 == v170;\n\tif (v224) goto L_0063;\n\tv204 = v219 + 1;\n\tv229 = v204 < v169;\n\tv200 = ~v229;\n\tv202 = v218 + 0x10;\n\tv184 = ~v200;\n\tif (v184) goto L_FFFFFFFF;\n\tv205 = v18;\n\tv206 = 0;\n\tv207 = 0x8909C4(v205, v170, v206, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_006A;\nL_0062:\n\treturn;\nL_0063:\n\tv230 = *([v218 @ X11_v6]);\n\tv231 = v230 << 4;\n\tv232 = v167 + v231;\n\tv233 = v232 + 0x130;\nL_006A:\n\tv174 = EasyMobile.IAdClient::get_Network(client);\n\tSystem.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>::Invoke(v57.RewardedAdSkipped, v174, placement);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnInternalRewardedAdSkipped(IAdClient client, AdPlacement placement)
		{
			if (Advertising.RewardedAdSkipped != null)
			{
				AdNetwork network = client.Network;
				Advertising.RewardedAdSkipped((RewardedAdNetwork)network, placement);
			}
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0xA4CCE8", Offset = "0xA4CCE8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0F428]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F25]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = EasyMobile.Advertising;\nL_0025:\n\tv59 = v57.RewardedAdCompleted == 0;\n\tif (v59) goto L_0062;\n\tgoto L_003B;\n\tv70 = *([v53 @ X0_v3 (Il2CppClass<EasyMobile.Advertising>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\t// 46 ConditionalJump @b25, v72 @ TEMP_v16\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v53, placement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv177 = EasyMobile.Advertising;\n\tv77 = *([v177 @ X8_v16+B8]);\n\tv79 = *([v77 @ X8_v17+C0]);\nL_003B:\n\tgoto L_006A;\n\tv178 = *([v167 @ X8_v9+B0]);\n\tv179 = 0;\n\tv180 = v178 + 8;\n\tv182 = *([v218 @ X11_v6-8]);\n\tv224 = v182 == v170;\n\tif (v224) goto L_0063;\n\tv204 = v219 + 1;\n\tv229 = v204 < v169;\n\tv200 = ~v229;\n\tv202 = v218 + 0x10;\n\tv184 = ~v200;\n\tif (v184) goto L_FFFFFFFF;\n\tv205 = v18;\n\tv206 = 0;\n\tv207 = 0x8909C4(v205, v170, v206, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_006A;\nL_0062:\n\treturn;\nL_0063:\n\tv230 = *([v218 @ X11_v6]);\n\tv231 = v230 << 4;\n\tv232 = v167 + v231;\n\tv233 = v232 + 0x130;\nL_006A:\n\tv174 = EasyMobile.IAdClient::get_Network(client);\n\tSystem.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>::Invoke(v57.RewardedAdCompleted, v174, placement);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnInternalRewardedAdCompleted(IAdClient client, AdPlacement placement)
		{
			if (Advertising.RewardedAdCompleted != null)
			{
				AdNetwork network = client.Network;
				Advertising.RewardedAdCompleted((RewardedAdNetwork)network, placement);
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0xA4CE24", Offset = "0xA4CE24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Advertising()
		{
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0xA4CE2C", Offset = "0xA4CE2C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF1B40]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2021F26]) = v41;\nL_001A:\n\tv47.DEFAULT_TIMESTAMP = -1000f;\n\tv48.currentAutoLoadAdsMode = 0;\n\tv49.lastDefaultInterstitialAdLoadTimestamp = v49.DEFAULT_TIMESTAMP;\n\tv51.lastDefaultRewardedAdLoadTimestamp = v51.DEFAULT_TIMESTAMP;\n\tv55 = new System.Collections.Generic.Dictionary`2<System.String, System.Single>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Single>::.ctor(v55);\n\tv61.lastCustomInterstitialAdsLoadTimestamp = v55;\n\tv63 = new System.Collections.Generic.Dictionary`2<System.String, System.Single>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Single>::.ctor(v63);\n\tv67.lastCustomRewardedAdsLoadTimestamp = v63;\n\tv68.isUpdatingAutoLoadMode = 0;\n\tv72 = new System.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>();\n\tSystem.Collections.Generic.Dictionary`2<EasyMobile.AdNetwork, System.Collections.Generic.List`1<EasyMobile.AdPlacement>>::.ctor(v72);\n\tv78.activeBannerAds = v72;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Advertising()
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			lastCustomInterstitialAdsLoadTimestamp = dictionary;
			Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
			lastCustomRewardedAdsLoadTimestamp = dictionary2;
			isUpdatingAutoLoadMode = false;
			Dictionary<AdNetwork, List<AdPlacement>> dictionary3 = new Dictionary<AdNetwork, List<AdPlacement>>();
			activeBannerAds = dictionary3;
		}
	}
}
