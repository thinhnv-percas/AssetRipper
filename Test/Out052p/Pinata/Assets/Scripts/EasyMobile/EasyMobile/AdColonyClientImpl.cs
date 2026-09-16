using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000025")]
	public class AdColonyClientImpl : AdClientImpl
	{
		[Token(Token = "0x4000135")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the AdColony plugin.";

		[Token(Token = "0x4000136")]
		private const string BANNER_UNSUPPORTED_MESSAGE = "AdColony does not support banner ad format.";

		[Token(Token = "0x4000137")]
		private static AdColonyClientImpl sInstance;

		[Token(Token = "0x4000138")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_AdColony_DataPrivacyConsent";

		[Token(Token = "0x17000049")]
		public override AdNetwork Network
		{
			[Token(Token = "0x6000155")]
			[Address(RVA = "0xA451A8", Offset = "0xA451A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.AdColony;
			}
		}

		[Token(Token = "0x1700004A")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x6000156")]
			[Address(RVA = "0xA451B0", Offset = "0xA451B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700004B")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x6000157")]
			[Address(RVA = "0xA451B8", Offset = "0xA451B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700004C")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x6000158")]
			[Address(RVA = "0xA451C0", Offset = "0xA451C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700004D")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x6000159")]
			[Address(RVA = "0xA451C8", Offset = "0xA451C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700004E")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x600015B")]
			[Address(RVA = "0xA451D8", Offset = "0xA451D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700004F")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x600015C")]
			[Address(RVA = "0xA451E0", Offset = "0xA451E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000050")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x600015D")]
			[Address(RVA = "0xA451E8", Offset = "0xA451E8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB1530]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EAD]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the AdColony plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the AdColony plugin.";
			}
		}

		[Token(Token = "0x17000051")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x6000168")]
			[Address(RVA = "0xA45398", Offset = "0xA45398", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EED440]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EB1]) = v35;\nL_0018:\n\treturn \"EM_Ads_AdColony_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_AdColony_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0xA45120", Offset = "0xA45120", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AdColonyClientImpl()
		{
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0xA45128", Offset = "0xA45128", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EA5650]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EAC]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.AdColonyClientImpl();\n\tSystem.Object::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdColonyClientImpl CreateClient()
		{
			AdColonyClientImpl result = sInstance;
			if (sInstance == null)
			{
				AdColonyClientImpl adColonyClientImpl = new AdColonyClientImpl();
				sInstance = adColonyClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x600015A")]
		[Address(RVA = "0xA451D0", Offset = "0xA451D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0xA45230", Offset = "0xA45230", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0xA45234", Offset = "0xA45234", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA4348]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, placement, position, size, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EAE]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, placement, position, size, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"AdColony does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
			Debug.LogWarning("AdColony does not support banner ad format.");
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0xA452A0", Offset = "0xA452A0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F02BA8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EAF]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"AdColony does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalHideBannerAd(AdPlacement placement)
		{
			Debug.LogWarning("AdColony does not support banner ad format.");
		}

		[Token(Token = "0x6000161")]
		[Address(RVA = "0xA4530C", Offset = "0xA4530C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBBD30]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EB0]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"AdColony does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalDestroyBannerAd(AdPlacement placement)
		{
			Debug.LogWarning("AdColony does not support banner ad format.");
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0xA45378", Offset = "0xA45378", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0xA4537C", Offset = "0xA4537C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0xA45384", Offset = "0xA45384", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0xA45388", Offset = "0xA45388", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0xA4538C", Offset = "0xA4538C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0xA45394", Offset = "0xA45394", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0xA453E0", Offset = "0xA453E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}
	}
}
