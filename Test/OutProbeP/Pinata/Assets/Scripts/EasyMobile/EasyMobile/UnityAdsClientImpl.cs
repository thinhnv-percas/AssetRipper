using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000030")]
	public class UnityAdsClientImpl : AdClientImpl
	{
		[Token(Token = "0x400015D")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please enable UnityAds service.";

		[Token(Token = "0x400015E")]
		private const string BANNER_UNSUPPORTED_MESSAGE = "UnityAds does not support banner ad format.";

		[Token(Token = "0x400015F")]
		private static UnityAdsClientImpl sInstance;

		[Token(Token = "0x4000160")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_UnityAds_DataPrivacyConsent";

		[Token(Token = "0x170000AC")]
		public override AdNetwork Network
		{
			[Token(Token = "0x60002A8")]
			[Address(RVA = "0xFD6C90", Offset = "0xFD6C90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xA;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.UnityAds;
			}
		}

		[Token(Token = "0x170000AD")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x60002A9")]
			[Address(RVA = "0xFD6C98", Offset = "0xFD6C98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000AE")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x60002AA")]
			[Address(RVA = "0xFD6CA0", Offset = "0xFD6CA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x170000AF")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x60002AB")]
			[Address(RVA = "0xFD6CA8", Offset = "0xFD6CA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x170000B0")]
		public override bool IsInitialized
		{
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0xFD6CB0", Offset = "0xFD6CB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsInitialized;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsInitialized;
			}
		}

		[Token(Token = "0x170000B1")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x60002AD")]
			[Address(RVA = "0xFD6CB8", Offset = "0xFD6CB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B2")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x60002AE")]
			[Address(RVA = "0xFD6CC0", Offset = "0xFD6CC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B3")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x60002AF")]
			[Address(RVA = "0xFD6CC8", Offset = "0xFD6CC8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EBE9C8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256EB]) = v35;\nL_0018:\n\treturn \"SDK missing. Please enable UnityAds service.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please enable UnityAds service.";
			}
		}

		[Token(Token = "0x170000B4")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x60002B0")]
			[Address(RVA = "0xFD6D10", Offset = "0xFD6D10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000B5")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0xFD6E88", Offset = "0xFD6E88", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F06010]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256EF]) = v35;\nL_0018:\n\treturn \"EM_Ads_UnityAds_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_UnityAds_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0xFD6C08", Offset = "0xFD6C08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.AdClientImpl::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private UnityAdsClientImpl()
		{
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0xFD6C10", Offset = "0xFD6C10", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1F0DDE8]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20256EA]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.UnityAdsClientImpl();\n\tEasyMobile.AdClientImpl::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static UnityAdsClientImpl CreateClient()
		{
			UnityAdsClientImpl result = sInstance;
			if (sInstance == null)
			{
				UnityAdsClientImpl unityAdsClientImpl = (UnityAdsClientImpl)new AdClientImpl();
				sInstance = unityAdsClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0xFD6D18", Offset = "0xFD6D18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xFD6D20", Offset = "0xFD6D20", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x60002B3")]
		[Address(RVA = "0xFD6D24", Offset = "0xFD6D24", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0D328]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, placement, postition, size, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256EC]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, placement, postition, size, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"UnityAds does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition postition, BannerAdSize size)
		{
			Debug.LogWarning("UnityAds does not support banner ad format.");
		}

		[Token(Token = "0x60002B4")]
		[Address(RVA = "0xFD6D90", Offset = "0xFD6D90", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEA1F8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256ED]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"UnityAds does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalHideBannerAd(AdPlacement placement)
		{
			Debug.LogWarning("UnityAds does not support banner ad format.");
		}

		[Token(Token = "0x60002B5")]
		[Address(RVA = "0xFD6DFC", Offset = "0xFD6DFC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F03130]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256EE]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, placement, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"UnityAds does not support banner ad format.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalDestroyBannerAd(AdPlacement placement)
		{
			Debug.LogWarning("UnityAds does not support banner ad format.");
		}

		[Token(Token = "0x60002B6")]
		[Address(RVA = "0xFD6E68", Offset = "0xFD6E68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement _)
		{
		}

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0xFD6E6C", Offset = "0xFD6E6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0xFD6E74", Offset = "0xFD6E74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60002B9")]
		[Address(RVA = "0xFD6E78", Offset = "0xFD6E78", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement _)
		{
		}

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0xFD6E7C", Offset = "0xFD6E7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0xFD6E84", Offset = "0xFD6E84", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60002BD")]
		[Address(RVA = "0xFD6ED0", Offset = "0xFD6ED0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}
	}
}
