using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200002E")]
	internal class NoOpClientImpl : AdClientImpl
	{
		[Token(Token = "0x4000158")]
		private static NoOpClientImpl sInstance;

		[Token(Token = "0x1700009A")]
		public override AdNetwork Network
		{
			[Token(Token = "0x6000279")]
			[Address(RVA = "0xFCF574", Offset = "0xFCF574", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return default(AdNetwork);
			}
		}

		[Token(Token = "0x1700009B")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x600027A")]
			[Address(RVA = "0xFCF57C", Offset = "0xFCF57C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700009C")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x600027B")]
			[Address(RVA = "0xFCF584", Offset = "0xFCF584", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700009D")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x600027C")]
			[Address(RVA = "0xFCF58C", Offset = "0xFCF58C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700009E")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x600027D")]
			[Address(RVA = "0xFCF594", Offset = "0xFCF594", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700009F")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x600027E")]
			[Address(RVA = "0xFCF59C", Offset = "0xFCF59C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000A0")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x600027F")]
			[Address(RVA = "0xFCF5A4", Offset = "0xFCF5A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000A1")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x6000280")]
			[Address(RVA = "0xFCF5AC", Offset = "0xFCF5AC", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EBA6A0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202567E]) = v35;\nL_001A:\n\treturn v41.Empty;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return string.Empty;
			}
		}

		[Token(Token = "0x170000A2")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x600028C")]
			[Address(RVA = "0xFCF634", Offset = "0xFCF634", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EB89F0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202567F]) = v35;\nL_001A:\n\treturn v41.Empty;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return string.Empty;
			}
		}

		[Token(Token = "0x6000277")]
		[Address(RVA = "0xFCF4EC", Offset = "0xFCF4EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.AdClientImpl::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private NoOpClientImpl()
		{
		}

		[Token(Token = "0x6000278")]
		[Address(RVA = "0xFCF4F4", Offset = "0xFCF4F4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EBC8D0]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202567D]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.NoOpClientImpl();\n\tEasyMobile.AdClientImpl::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static NoOpClientImpl CreateClient()
		{
			NoOpClientImpl result = sInstance;
			if (sInstance == null)
			{
				NoOpClientImpl noOpClientImpl = (NoOpClientImpl)new AdClientImpl();
				sInstance = noOpClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xFCF5FC", Offset = "0xFCF5FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xFCF604", Offset = "0xFCF604", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0xFCF608", Offset = "0xFCF608", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0xFCF60C", Offset = "0xFCF60C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalHideBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0xFCF610", Offset = "0xFCF610", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalDestroyBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0xFCF614", Offset = "0xFCF614", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xFCF618", Offset = "0xFCF618", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xFCF620", Offset = "0xFCF620", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xFCF624", Offset = "0xFCF624", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xFCF628", Offset = "0xFCF628", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xFCF630", Offset = "0xFCF630", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xFCF684", Offset = "0xFCF684", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}
	}
}
