using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200002A")]
	public class HeyzapClientImpl : AdClientImpl
	{
		[Token(Token = "0x4000147")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the Heyzap plugin.";

		[Token(Token = "0x4000148")]
		private static HeyzapClientImpl sInstance;

		[Token(Token = "0x4000149")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_Heyzap_DataPrivacyConsent";

		[Token(Token = "0x17000076")]
		public override AdNetwork Network
		{
			[Token(Token = "0x60001CA")]
			[Address(RVA = "0xBF50B4", Offset = "0xBF50B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 6;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.Heyzap;
			}
		}

		[Token(Token = "0x17000077")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x60001CB")]
			[Address(RVA = "0xBF50BC", Offset = "0xBF50BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000078")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x60001CC")]
			[Address(RVA = "0xBF50C4", Offset = "0xBF50C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000079")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x60001CD")]
			[Address(RVA = "0xBF50CC", Offset = "0xBF50CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700007A")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x60001CE")]
			[Address(RVA = "0xBF50D4", Offset = "0xBF50D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700007B")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x60001D0")]
			[Address(RVA = "0xBF50E4", Offset = "0xBF50E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700007C")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x60001D1")]
			[Address(RVA = "0xBF50EC", Offset = "0xBF50EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700007D")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x60001D2")]
			[Address(RVA = "0xBF50F4", Offset = "0xBF50F4", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB5568]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EE0]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the Heyzap plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the Heyzap plugin.";
			}
		}

		[Token(Token = "0x1700007E")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x60001DE")]
			[Address(RVA = "0xBF5240", Offset = "0xBF5240", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE1408]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EE3]) = v35;\nL_0018:\n\treturn \"EM_Ads_Heyzap_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_Heyzap_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0xBF502C", Offset = "0xBF502C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.AdClientImpl::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private HeyzapClientImpl()
		{
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0xBF5034", Offset = "0xBF5034", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EBC370]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022EDF]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.HeyzapClientImpl();\n\tEasyMobile.AdClientImpl::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static HeyzapClientImpl CreateClient()
		{
			HeyzapClientImpl result = sInstance;
			if (sInstance == null)
			{
				HeyzapClientImpl heyzapClientImpl = (HeyzapClientImpl)new AdClientImpl();
				sInstance = heyzapClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xBF50DC", Offset = "0xBF50DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0xBF513C", Offset = "0xBF513C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC3198]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EE1]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import the Heyzap plugin.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalInit()
		{
			Debug.LogError("SDK missing. Please import the Heyzap plugin.");
		}

		[Token(Token = "0x60001D4")]
		[Address(RVA = "0xBF51A8", Offset = "0xBF51A8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECDDC8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EE2]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import the Heyzap plugin.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowTestSuite()
		{
			Debug.LogError("SDK missing. Please import the Heyzap plugin.");
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0xBF5214", Offset = "0xBF5214", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize __)
		{
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0xBF5218", Offset = "0xBF5218", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalHideBannerAd(AdPlacement _)
		{
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0xBF521C", Offset = "0xBF521C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalDestroyBannerAd(AdPlacement _)
		{
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0xBF5220", Offset = "0xBF5220", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0xBF5224", Offset = "0xBF5224", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0xBF522C", Offset = "0xBF522C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0xBF5230", Offset = "0xBF5230", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0xBF5234", Offset = "0xBF5234", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0xBF523C", Offset = "0xBF523C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0xBF5288", Offset = "0xBF5288", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}
	}
}
