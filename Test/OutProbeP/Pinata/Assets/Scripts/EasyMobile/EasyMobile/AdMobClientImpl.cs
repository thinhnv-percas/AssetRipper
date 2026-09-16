using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000026")]
	public class AdMobClientImpl : AdClientImpl
	{
		[Token(Token = "0x4000139")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the AdMob (Google Mobile Ads) plugin.";

		[Token(Token = "0x400013A")]
		private static AdMobClientImpl sInstance;

		[Token(Token = "0x400013B")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_AdMob_DataPrivacyConsent";

		[Token(Token = "0x17000052")]
		public override AdNetwork Network
		{
			[Token(Token = "0x600016C")]
			[Address(RVA = "0xA45EB8", Offset = "0xA45EB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.AdMob;
			}
		}

		[Token(Token = "0x17000053")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x600016D")]
			[Address(RVA = "0xA45EC0", Offset = "0xA45EC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000054")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x600016E")]
			[Address(RVA = "0xA45EC8", Offset = "0xA45EC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000055")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x600016F")]
			[Address(RVA = "0xA45ED0", Offset = "0xA45ED0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000056")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x6000170")]
			[Address(RVA = "0xA45ED8", Offset = "0xA45ED8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000057")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x6000172")]
			[Address(RVA = "0xA45EE8", Offset = "0xA45EE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000058")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x6000173")]
			[Address(RVA = "0xA45EF0", Offset = "0xA45EF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000059")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x6000174")]
			[Address(RVA = "0xA45EF8", Offset = "0xA45EF8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F0EE38]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EBB]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the AdMob (Google Mobile Ads) plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the AdMob (Google Mobile Ads) plugin.";
			}
		}

		[Token(Token = "0x1700005A")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x600017F")]
			[Address(RVA = "0xA45F70", Offset = "0xA45F70", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EBB4F0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021EBC]) = v35;\nL_0018:\n\treturn \"EM_Ads_AdMob_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_AdMob_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0xA45E30", Offset = "0xA45E30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AdMobClientImpl()
		{
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0xA45E38", Offset = "0xA45E38", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EA80D0]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EBA]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.AdMobClientImpl();\n\tSystem.Object::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdMobClientImpl CreateClient()
		{
			AdMobClientImpl result = sInstance;
			if (sInstance == null)
			{
				AdMobClientImpl adMobClientImpl = new AdMobClientImpl();
				sInstance = adMobClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0xA45EE0", Offset = "0xA45EE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0xA45F40", Offset = "0xA45F40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0xA45F44", Offset = "0xA45F44", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0xA45F48", Offset = "0xA45F48", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalHideBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0xA45F4C", Offset = "0xA45F4C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalDestroyBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0xA45F50", Offset = "0xA45F50", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0xA45F54", Offset = "0xA45F54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0xA45F5C", Offset = "0xA45F5C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0xA45F60", Offset = "0xA45F60", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0xA45F64", Offset = "0xA45F64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0xA45F6C", Offset = "0xA45F6C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0xA45FB8", Offset = "0xA45FB8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}
	}
}
