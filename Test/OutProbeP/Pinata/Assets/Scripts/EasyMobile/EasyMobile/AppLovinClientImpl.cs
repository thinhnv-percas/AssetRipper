using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000027")]
	public class AppLovinClientImpl : AdClientImpl
	{
		[Token(Token = "0x200010E")]
		public class EM_AppLovinAdsListener : MonoBehaviour
		{
			[Token(Token = "0x6000945")]
			[Address(RVA = "0xA4E5E8", Offset = "0xA4E5E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public EM_AppLovinAdsListener()
			{
			}
		}

		[Token(Token = "0x400013C")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the AppLovin plugin.";

		[Token(Token = "0x400013D")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_AppLovin_DataPrivacyConsent";

		[Token(Token = "0x400013E")]
		private static AppLovinClientImpl sInstance;

		[Token(Token = "0x1700005B")]
		public override AdNetwork Network
		{
			[Token(Token = "0x6000183")]
			[Address(RVA = "0xA4E4E4", Offset = "0xA4E4E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 3;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.AppLovin;
			}
		}

		[Token(Token = "0x1700005C")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x6000184")]
			[Address(RVA = "0xA4E4EC", Offset = "0xA4E4EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700005D")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x6000185")]
			[Address(RVA = "0xA4E4F4", Offset = "0xA4E4F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700005E")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x6000186")]
			[Address(RVA = "0xA4E4FC", Offset = "0xA4E4FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700005F")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x6000187")]
			[Address(RVA = "0xA4E504", Offset = "0xA4E504", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000060")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x6000189")]
			[Address(RVA = "0xA4E514", Offset = "0xA4E514", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EBF490]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F3D]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the AppLovin plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the AppLovin plugin.";
			}
		}

		[Token(Token = "0x17000061")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x600018A")]
			[Address(RVA = "0xA4E55C", Offset = "0xA4E55C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000062")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x600018B")]
			[Address(RVA = "0xA4E564", Offset = "0xA4E564", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000063")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x600018D")]
			[Address(RVA = "0xA4E570", Offset = "0xA4E570", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE3150]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F3E]) = v35;\nL_0018:\n\treturn \"EM_Ads_AppLovin_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_AppLovin_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0xA4E4DC", Offset = "0xA4E4DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AppLovinClientImpl()
		{
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0xA4C6D0", Offset = "0xA4C6D0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EDC5D8]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F3C]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.AppLovinClientImpl();\n\tSystem.Object::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AppLovinClientImpl CreateClient()
		{
			AppLovinClientImpl result = sInstance;
			if (sInstance == null)
			{
				AppLovinClientImpl appLovinClientImpl = new AppLovinClientImpl();
				sInstance = appLovinClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0xA4E50C", Offset = "0xA4E50C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0xA4E56C", Offset = "0xA4E56C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0xA4E5B8", Offset = "0xA4E5B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0xA4E5BC", Offset = "0xA4E5BC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
		}

		[Token(Token = "0x6000190")]
		[Address(RVA = "0xA4E5C0", Offset = "0xA4E5C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalHideBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0xA4E5C4", Offset = "0xA4E5C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalDestroyBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0xA4E5C8", Offset = "0xA4E5C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0xA4E5D0", Offset = "0xA4E5D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0xA4E5D4", Offset = "0xA4E5D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0xA4E5D8", Offset = "0xA4E5D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0xA4E5E0", Offset = "0xA4E5E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0xA4E5E4", Offset = "0xA4E5E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}
	}
}
