using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000029")]
	public class ChartboostClientImpl : AdClientImpl
	{
		[Token(Token = "0x4000143")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the Chartboost plugin.";

		[Token(Token = "0x4000144")]
		private const string BANNER_UNSUPPORTED_MESSAGE = "Chartboost does not support banner ad format.";

		[Token(Token = "0x4000145")]
		private static ChartboostClientImpl sInstance;

		[Token(Token = "0x4000146")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_Chartboost_DataPrivacyConsent";

		[Token(Token = "0x1700006D")]
		public override AdNetwork Network
		{
			[Token(Token = "0x60001B3")]
			[Address(RVA = "0xA4EFFC", Offset = "0xA4EFFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 5;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.Chartboost;
			}
		}

		[Token(Token = "0x1700006E")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x60001B4")]
			[Address(RVA = "0xA4F004", Offset = "0xA4F004", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700006F")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x60001B5")]
			[Address(RVA = "0xA4F00C", Offset = "0xA4F00C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000070")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x60001B6")]
			[Address(RVA = "0xA4F014", Offset = "0xA4F014", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000071")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x60001B7")]
			[Address(RVA = "0xA4F01C", Offset = "0xA4F01C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000072")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0xA4F02C", Offset = "0xA4F02C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000073")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x60001BA")]
			[Address(RVA = "0xA4F034", Offset = "0xA4F034", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000074")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x60001BB")]
			[Address(RVA = "0xA4F03C", Offset = "0xA4F03C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE3280]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F4D]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the Chartboost plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the Chartboost plugin.";
			}
		}

		[Token(Token = "0x17000075")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x60001C6")]
			[Address(RVA = "0xA4F1EC", Offset = "0xA4F1EC", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F026D8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F51]) = v35;\nL_0018:\n\treturn \"EM_Ads_Chartboost_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_Chartboost_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0xA4EFF4", Offset = "0xA4EFF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ChartboostClientImpl()
		{
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0xA4C750", Offset = "0xA4C750", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EC30D8]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F4C]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.ChartboostClientImpl();\n\tSystem.Object::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ChartboostClientImpl CreateClient()
		{
			ChartboostClientImpl result = sInstance;
			if (sInstance == null)
			{
				ChartboostClientImpl chartboostClientImpl = new ChartboostClientImpl();
				sInstance = chartboostClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x60001B8")]
		[Address(RVA = "0xA4F024", Offset = "0xA4F024", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0xA4F084", Offset = "0xA4F084", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0xA4F088", Offset = "0xA4F088", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDE670]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, _, __, ___, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F4E]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, _, __, ___, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Chartboost does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalShowBannerAd(AdPlacement _, BannerAdPosition __, BannerAdSize ___)
		{
			Debug.LogWarning("Chartboost does not support banner ad format.");
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0xA4F0F4", Offset = "0xA4F0F4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDD460]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F4F]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Chartboost does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalHideBannerAd(AdPlacement _)
		{
			Debug.LogWarning("Chartboost does not support banner ad format.");
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0xA4F160", Offset = "0xA4F160", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC9C08]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F50]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Chartboost does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalDestroyBannerAd(AdPlacement _)
		{
			Debug.LogWarning("Chartboost does not support banner ad format.");
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0xA4F1CC", Offset = "0xA4F1CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0xA4F1D0", Offset = "0xA4F1D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0xA4F1D8", Offset = "0xA4F1D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0xA4F1DC", Offset = "0xA4F1DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0xA4F1E0", Offset = "0xA4F1E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0xA4F1E8", Offset = "0xA4F1E8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0xA4F234", Offset = "0xA4F234", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0B608]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, consent, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F52]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, consent, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"SDK missing. Please import the Chartboost plugin.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
			Debug.Log("SDK missing. Please import the Chartboost plugin.");
		}
	}
}
