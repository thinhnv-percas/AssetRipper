using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200002F")]
	public class TapjoyClientImpl : AdClientImpl
	{
		[Token(Token = "0x4000159")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the TapJoy plugin.";

		[Token(Token = "0x400015A")]
		private const string BANNER_UNSUPPORTED_MESSAGE = "TapJoy does not support banner ad format";

		[Token(Token = "0x400015B")]
		private static TapjoyClientImpl sInstance;

		[Token(Token = "0x400015C")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_TapJoy_DataPrivacyConsent";

		[Token(Token = "0x170000A3")]
		public override AdNetwork Network
		{
			[Token(Token = "0x6000290")]
			[Address(RVA = "0xFD6298", Offset = "0xFD6298", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 9;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.TapJoy;
			}
		}

		[Token(Token = "0x170000A4")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x6000291")]
			[Address(RVA = "0xFD62A0", Offset = "0xFD62A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A5")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x6000292")]
			[Address(RVA = "0xFD62A8", Offset = "0xFD62A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x170000A6")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x6000293")]
			[Address(RVA = "0xFD62B0", Offset = "0xFD62B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x170000A7")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x6000294")]
			[Address(RVA = "0xFD62B8", Offset = "0xFD62B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A8")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x6000296")]
			[Address(RVA = "0xFD62C8", Offset = "0xFD62C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000A9")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x6000297")]
			[Address(RVA = "0xFD62D0", Offset = "0xFD62D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000AA")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x6000298")]
			[Address(RVA = "0xFD62D8", Offset = "0xFD62D8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE7010]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256E0]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the TapJoy plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the TapJoy plugin.";
			}
		}

		[Token(Token = "0x170000AB")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x60002A3")]
			[Address(RVA = "0xFD6488", Offset = "0xFD6488", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB90F0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256E4]) = v35;\nL_0018:\n\treturn \"EM_Ads_TapJoy_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_TapJoy_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xFD61CC", Offset = "0xFD61CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.AdClientImpl::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TapjoyClientImpl()
		{
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xFD61D4", Offset = "0xFD61D4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F05200]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20256DF]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.TapjoyClientImpl>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.TapjoyClientImpl;\nL_0021:\n\tv53 = v51.sInstance == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0039;\n\tv56 = new EasyMobile.TapjoyClientImpl();\n\tEasyMobile.AdClientImpl::.ctor(v56);\n\tgoto L_0034;\n\tv88 = *([v83 @ X0_v10 (Il2CppClass<EasyMobile.TapjoyClientImpl>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0034;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v83, v58, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv92 = EasyMobile.TapjoyClientImpl;\nL_0034:\n\tv64.sInstance = v56;\nL_0039:\n\tgoto L_0047;\n\tv70 = *([v59 @ X0_v4 (Il2CppClass<EasyMobile.TapjoyClientImpl>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_0047;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v59, v57, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv74 = EasyMobile.TapjoyClientImpl;\nL_0047:\n\treturn v77.sInstance;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TapjoyClientImpl CreateClient()
		{
			if (sInstance == null)
			{
				AdClientImpl adClientImpl = new AdClientImpl();
				sInstance = (TapjoyClientImpl)adClientImpl;
			}
			return sInstance;
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0xFD62C0", Offset = "0xFD62C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0xFD6320", Offset = "0xFD6320", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0xFD6324", Offset = "0xFD6324", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EED668]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, _, __, ___, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256E1]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, _, __, ___, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"TapJoy does not support banner ad format\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalShowBannerAd(AdPlacement _, BannerAdPosition __, BannerAdSize ___)
		{
			Debug.Log("TapJoy does not support banner ad format");
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0xFD6390", Offset = "0xFD6390", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED0A90]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256E2]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"TapJoy does not support banner ad format\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalHideBannerAd(AdPlacement _)
		{
			Debug.Log("TapJoy does not support banner ad format");
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0xFD63FC", Offset = "0xFD63FC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC8550]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256E3]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, _, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"TapJoy does not support banner ad format\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalDestroyBannerAd(AdPlacement _)
		{
			Debug.Log("TapJoy does not support banner ad format");
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0xFD6468", Offset = "0xFD6468", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x600029E")]
		[Address(RVA = "0xFD6470", Offset = "0xFD6470", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x600029F")]
		[Address(RVA = "0xFD6474", Offset = "0xFD6474", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0xFD6478", Offset = "0xFD6478", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60002A1")]
		[Address(RVA = "0xFD6480", Offset = "0xFD6480", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xFD6484", Offset = "0xFD6484", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0xFD64D0", Offset = "0xFD64D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}
	}
}
