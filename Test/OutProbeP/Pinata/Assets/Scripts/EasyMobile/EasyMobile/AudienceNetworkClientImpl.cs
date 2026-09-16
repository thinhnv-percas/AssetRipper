using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000028")]
	public class AudienceNetworkClientImpl : AdClientImpl
	{
		[Token(Token = "0x400013F")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the FB Audience Network plugin.";

		[Token(Token = "0x4000140")]
		private const string AD_HANDLER_GO_NAME = "EM_Ads_FBAN_Handler";

		[Token(Token = "0x4000141")]
		private static AudienceNetworkClientImpl sInstance;

		[Token(Token = "0x4000142")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_FacebookAudience_DataPrivacyConsent";

		[Token(Token = "0x17000064")]
		public override AdNetwork Network
		{
			[Token(Token = "0x600019A")]
			[Address(RVA = "0xA4E830", Offset = "0xA4E830", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 4;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.AudienceNetwork;
			}
		}

		[Token(Token = "0x17000065")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x600019B")]
			[Address(RVA = "0xA4E838", Offset = "0xA4E838", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000066")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x600019C")]
			[Address(RVA = "0xA4E840", Offset = "0xA4E840", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000067")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x600019D")]
			[Address(RVA = "0xA4E848", Offset = "0xA4E848", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000068")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x600019E")]
			[Address(RVA = "0xA4E850", Offset = "0xA4E850", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000069")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x60001A0")]
			[Address(RVA = "0xA4E860", Offset = "0xA4E860", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700006A")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x60001A1")]
			[Address(RVA = "0xA4E868", Offset = "0xA4E868", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700006B")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0xA4E870", Offset = "0xA4E870", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F09288]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F43]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the FB Audience Network plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the FB Audience Network plugin.";
			}
		}

		[Token(Token = "0x1700006C")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x60001AD")]
			[Address(RVA = "0xA4E8E8", Offset = "0xA4E8E8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB7370]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F44]) = v35;\nL_0018:\n\treturn \"EM_Ads_FacebookAudience_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_FacebookAudience_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x6000198")]
		[Address(RVA = "0xA4E828", Offset = "0xA4E828", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AudienceNetworkClientImpl()
		{
		}

		[Token(Token = "0x6000199")]
		[Address(RVA = "0xA4C7D0", Offset = "0xA4C7D0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EE7128]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F42]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.AudienceNetworkClientImpl();\n\tSystem.Object::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AudienceNetworkClientImpl CreateClient()
		{
			AudienceNetworkClientImpl result = sInstance;
			if (sInstance == null)
			{
				AudienceNetworkClientImpl audienceNetworkClientImpl = new AudienceNetworkClientImpl();
				sInstance = audienceNetworkClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0xA4E858", Offset = "0xA4E858", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return false;
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0xA4E8B8", Offset = "0xA4E8B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalInit()
		{
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0xA4E8BC", Offset = "0xA4E8BC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0xA4E8C0", Offset = "0xA4E8C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalHideBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0xA4E8C4", Offset = "0xA4E8C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalDestroyBannerAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0xA4E8C8", Offset = "0xA4E8C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0xA4E8D0", Offset = "0xA4E8D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0xA4E8D4", Offset = "0xA4E8D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0xA4E8D8", Offset = "0xA4E8D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement placement)
		{
			return false;
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0xA4E8E0", Offset = "0xA4E8E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0xA4E8E4", Offset = "0xA4E8E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0xA4E930", Offset = "0xA4E930", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0xA4E934", Offset = "0xA4E934", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this->klass;\n\tv4 = adSettings.mTestDevices;\n\tv5 = this->klass->vtable[96];\n\tv6 = this->klass->vtable[96];\n\t// 6 IndirectJump v5 @ X3_v1, this @ X0 (EasyMobile.AudienceNetworkClientImpl), this @ X0 (EasyMobile.AudienceNetworkClientImpl), v4 @ X1_v1 (System.String[]), v6 @ X2_v1, v5 @ X3_v1, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SetupTestMode(AudienceNetworkSettings adSettings)
		{
			//IL_0005: Expected I, but got O
			//IL_0022: Expected O, but got I
			//IL_0032: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			string[] testDevices = adSettings.TestDevices;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.AudienceNetworkClientImpl>)+730]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.AudienceNetworkClientImpl>)+738]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v5 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0xA4E95C", Offset = "0xA4E95C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF8CB0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, ids, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F45]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, ids, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"SDK missing. Please import the FB Audience Network plugin.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SetupTestDevices(string[] ids)
		{
			Debug.Log("SDK missing. Please import the FB Audience Network plugin.");
		}
	}
}
