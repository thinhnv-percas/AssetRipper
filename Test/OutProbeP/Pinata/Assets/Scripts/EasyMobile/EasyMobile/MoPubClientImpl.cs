using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200002D")]
	public class MoPubClientImpl : AdClientImpl
	{
		[Token(Token = "0x4000155")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the MoPub plugin.";

		[Token(Token = "0x4000156")]
		private static MoPubClientImpl sInstance;

		[Token(Token = "0x4000157")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_MoPub_DataPrivacyConsent";

		[Token(Token = "0x17000090")]
		public override AdNetwork Network
		{
			[Token(Token = "0x6000260")]
			[Address(RVA = "0xFCDC44", Offset = "0xFCDC44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 8;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.MoPub;
			}
		}

		[Token(Token = "0x17000091")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x6000261")]
			[Address(RVA = "0xFCDC4C", Offset = "0xFCDC4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000092")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x6000262")]
			[Address(RVA = "0xFCDC54", Offset = "0xFCDC54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000093")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x6000263")]
			[Address(RVA = "0xFCDC5C", Offset = "0xFCDC5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000094")]
		public override bool IsInitialized
		{
			[Token(Token = "0x6000264")]
			[Address(RVA = "0xFCDC64", Offset = "0xFCDC64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsInitialized;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsInitialized;
			}
		}

		[Token(Token = "0x17000095")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x6000265")]
			[Address(RVA = "0xFCDC6C", Offset = "0xFCDC6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000096")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x6000267")]
			[Address(RVA = "0xFCDC7C", Offset = "0xFCDC7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000097")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x6000268")]
			[Address(RVA = "0xFCDC84", Offset = "0xFCDC84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000098")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x6000269")]
			[Address(RVA = "0xFCDC8C", Offset = "0xFCDC8C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1ED3378]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202565E]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the MoPub plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the MoPub plugin.";
			}
		}

		[Token(Token = "0x17000099")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x6000274")]
			[Address(RVA = "0xFCDD04", Offset = "0xFCDD04", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EAD708]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202565F]) = v35;\nL_0018:\n\treturn \"EM_Ads_MoPub_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_MoPub_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0xFCDB78", Offset = "0xFCDB78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.AdClientImpl::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private MoPubClientImpl()
		{
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0xFCDB80", Offset = "0xFCDB80", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F059D8]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202565D]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.MoPubClientImpl>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.MoPubClientImpl;\nL_0021:\n\tv53 = v51.sInstance == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0039;\n\tv56 = new EasyMobile.MoPubClientImpl();\n\tEasyMobile.AdClientImpl::.ctor(v56);\n\tgoto L_0034;\n\tv88 = *([v83 @ X0_v10 (Il2CppClass<EasyMobile.MoPubClientImpl>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0034;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v83, v58, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv92 = EasyMobile.MoPubClientImpl;\nL_0034:\n\tv64.sInstance = v56;\nL_0039:\n\tgoto L_0047;\n\tv70 = *([v59 @ X0_v4 (Il2CppClass<EasyMobile.MoPubClientImpl>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_0047;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v59, v57, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv74 = EasyMobile.MoPubClientImpl;\nL_0047:\n\treturn v77.sInstance;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static MoPubClientImpl CreateClient()
		{
			if (sInstance == null)
			{
				AdClientImpl adClientImpl = new AdClientImpl();
				sInstance = (MoPubClientImpl)adClientImpl;
			}
			return sInstance;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0xFCDC74", Offset = "0xFCDC74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x600026A")]
		[Address(RVA = "0xFCDCD4", Offset = "0xFCDCD4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0xFCDCD8", Offset = "0xFCDCD8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0xFCDCDC", Offset = "0xFCDCDC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalHideBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0xFCDCE0", Offset = "0xFCDCE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalDestroyBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0xFCDCE4", Offset = "0xFCDCE4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0xFCDCEC", Offset = "0xFCDCEC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0xFCDCF0", Offset = "0xFCDCF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0xFCDCF4", Offset = "0xFCDCF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0xFCDCFC", Offset = "0xFCDCFC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0xFCDD00", Offset = "0xFCDD00", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0xFCDD4C", Offset = "0xFCDD4C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}
	}
}
