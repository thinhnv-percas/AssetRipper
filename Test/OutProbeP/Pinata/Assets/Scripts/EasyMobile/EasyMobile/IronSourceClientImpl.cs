using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200002C")]
	public class IronSourceClientImpl : AdClientImpl
	{
		[Token(Token = "0x400014A")]
		private const string NO_SDK_MESSAGE = "SDK missing. Please import the ironSource plugin.";

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x38")]
		protected IronSourceSettings mAdSettings;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x40")]
		protected bool mIsBannerAdLoaded;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x48")]
		protected IronSourceBannerSize mCurrentBannerAdSize;

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x50")]
		protected IronSourceBannerPosition mCurrentBannerAdPos;

		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x58")]
		protected AdPlacement mCurrentBannerAdPlacement;

		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x60")]
		protected bool mRewardedVideoIsCompleted;

		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x68")]
		protected AdPlacement mLastShownRewardedAdPlacement;

		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x70")]
		protected AdPlacement mLastShownInterstitialPlacement;

		[Token(Token = "0x4000153")]
		private static IronSourceClientImpl sInstance;

		[Token(Token = "0x4000154")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_IronSource_DataPrivacyConsent";

		[Token(Token = "0x17000087")]
		public override AdNetwork Network
		{
			[Token(Token = "0x600022E")]
			[Address(RVA = "0xB540F8", Offset = "0xB540F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 7;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdNetwork.IronSource;
			}
		}

		[Token(Token = "0x17000088")]
		public override bool IsBannerAdSupported
		{
			[Token(Token = "0x600022F")]
			[Address(RVA = "0xB54100", Offset = "0xB54100", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x17000089")]
		public override bool IsInterstitialAdSupported
		{
			[Token(Token = "0x6000230")]
			[Address(RVA = "0xB54108", Offset = "0xB54108", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700008A")]
		public override bool IsRewardedAdSupported
		{
			[Token(Token = "0x6000231")]
			[Address(RVA = "0xB54110", Offset = "0xB54110", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700008B")]
		public override bool IsSdkAvail
		{
			[Token(Token = "0x6000232")]
			[Address(RVA = "0xB54118", Offset = "0xB54118", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x1700008C")]
		protected override Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x6000234")]
			[Address(RVA = "0xB54128", Offset = "0xB54128", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700008D")]
		protected override Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x6000235")]
			[Address(RVA = "0xB54130", Offset = "0xB54130", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700008E")]
		protected override string NoSdkMessage
		{
			[Token(Token = "0x6000236")]
			[Address(RVA = "0xB54138", Offset = "0xB54138", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EFE888]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227B4]) = v35;\nL_0018:\n\treturn \"SDK missing. Please import the ironSource plugin.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "SDK missing. Please import the ironSource plugin.";
			}
		}

		[Token(Token = "0x1700008F")]
		protected override string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x6000241")]
			[Address(RVA = "0xB54B8C", Offset = "0xB54B8C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE7288]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227B7]) = v35;\nL_0018:\n\treturn \"EM_Ads_IronSource_DataPrivacyConsent\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "EM_Ads_IronSource_DataPrivacyConsent";
			}
		}

		[Token(Token = "0x1400000D")]
		public event Action OnRewardedVideoAdOpenedEvent
		{
			[Token(Token = "0x6000202")]
			[Address(RVA = "0xB53DC8", Offset = "0xB53DC8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onRewardedVideoAdOpenedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onRewardedVideoAdOpenedEvent += value;
			}
			[Token(Token = "0x6000203")]
			[Address(RVA = "0xB53DD4", Offset = "0xB53DD4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onRewardedVideoAdOpenedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onRewardedVideoAdOpenedEvent -= value;
			}
		}

		[Token(Token = "0x1400000E")]
		public event Action OnRewardedVideoAdClosedEvent
		{
			[Token(Token = "0x6000204")]
			[Address(RVA = "0xB53DE0", Offset = "0xB53DE0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onRewardedVideoAdClosedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onRewardedVideoAdClosedEvent += value;
			}
			[Token(Token = "0x6000205")]
			[Address(RVA = "0xB53DEC", Offset = "0xB53DEC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onRewardedVideoAdClosedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onRewardedVideoAdClosedEvent -= value;
			}
		}

		[Token(Token = "0x1400000F")]
		public event Action<bool> OnRewardedVideoAvailabilityChangedEvent
		{
			[Token(Token = "0x6000206")]
			[Address(RVA = "0xB53DF8", Offset = "0xB53DF8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onRewardedVideoAvailabilityChangedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += value;
			}
			[Token(Token = "0x6000207")]
			[Address(RVA = "0xB53E04", Offset = "0xB53E04", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onRewardedVideoAvailabilityChangedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onRewardedVideoAvailabilityChangedEvent -= value;
			}
		}

		[Token(Token = "0x14000010")]
		public event Action OnRewardedVideoAdStartedEvent
		{
			[Token(Token = "0x6000208")]
			[Address(RVA = "0xB53E10", Offset = "0xB53E10", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onRewardedVideoAdStartedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onRewardedVideoAdStartedEvent += value;
			}
			[Token(Token = "0x6000209")]
			[Address(RVA = "0xB53E1C", Offset = "0xB53E1C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onRewardedVideoAdStartedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onRewardedVideoAdStartedEvent -= value;
			}
		}

		[Token(Token = "0x14000011")]
		public event Action OnRewardedVideoAdEndedEvent
		{
			[Token(Token = "0x600020A")]
			[Address(RVA = "0xB53E28", Offset = "0xB53E28", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onRewardedVideoAdEndedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onRewardedVideoAdEndedEvent += value;
			}
			[Token(Token = "0x600020B")]
			[Address(RVA = "0xB53E34", Offset = "0xB53E34", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onRewardedVideoAdEndedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onRewardedVideoAdEndedEvent -= value;
			}
		}

		[Token(Token = "0x14000012")]
		public event Action<IronSourcePlacement> OnRewardedVideoAdRewardedEvent
		{
			[Token(Token = "0x600020C")]
			[Address(RVA = "0xB53E40", Offset = "0xB53E40", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onRewardedVideoAdRewardedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onRewardedVideoAdRewardedEvent += value;
			}
			[Token(Token = "0x600020D")]
			[Address(RVA = "0xB53E4C", Offset = "0xB53E4C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onRewardedVideoAdRewardedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onRewardedVideoAdRewardedEvent -= value;
			}
		}

		[Token(Token = "0x14000013")]
		public event Action<IronSourceError> OnRewardedVideoAdShowFailedEvent
		{
			[Token(Token = "0x600020E")]
			[Address(RVA = "0xB53E58", Offset = "0xB53E58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onRewardedVideoAdShowFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onRewardedVideoAdShowFailedEvent += value;
			}
			[Token(Token = "0x600020F")]
			[Address(RVA = "0xB53E64", Offset = "0xB53E64", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onRewardedVideoAdShowFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onRewardedVideoAdShowFailedEvent -= value;
			}
		}

		[Token(Token = "0x14000014")]
		public event Action OnInterstitialAdReadyEvent
		{
			[Token(Token = "0x6000210")]
			[Address(RVA = "0xB53E70", Offset = "0xB53E70", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdReadyEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdReadyEvent += value;
			}
			[Token(Token = "0x6000211")]
			[Address(RVA = "0xB53E7C", Offset = "0xB53E7C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdReadyEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdReadyEvent -= value;
			}
		}

		[Token(Token = "0x14000015")]
		public event Action OnInterstitialAdRewardedEvent
		{
			[Token(Token = "0x6000212")]
			[Address(RVA = "0xB53E88", Offset = "0xB53E88", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdRewardedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdRewardedEvent += value;
			}
			[Token(Token = "0x6000213")]
			[Address(RVA = "0xB53E94", Offset = "0xB53E94", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdRewardedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdRewardedEvent -= value;
			}
		}

		[Token(Token = "0x14000016")]
		public event Action<IronSourceError> OnInterstitialAdLoadFailedEvent
		{
			[Token(Token = "0x6000214")]
			[Address(RVA = "0xB53EA0", Offset = "0xB53EA0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdLoadFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdLoadFailedEvent += value;
			}
			[Token(Token = "0x6000215")]
			[Address(RVA = "0xB53EAC", Offset = "0xB53EAC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdLoadFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdLoadFailedEvent -= value;
			}
		}

		[Token(Token = "0x14000017")]
		public event Action OnInterstitialAdShowSucceededEvent
		{
			[Token(Token = "0x6000216")]
			[Address(RVA = "0xB53EB8", Offset = "0xB53EB8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdShowSucceededEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdShowSucceededEvent += value;
			}
			[Token(Token = "0x6000217")]
			[Address(RVA = "0xB53EC4", Offset = "0xB53EC4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdShowSucceededEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdShowSucceededEvent -= value;
			}
		}

		[Token(Token = "0x14000018")]
		public event Action<IronSourceError> OnInterstitialAdShowFailedEvent
		{
			[Token(Token = "0x6000218")]
			[Address(RVA = "0xB53ED0", Offset = "0xB53ED0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdShowFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdShowFailedEvent += value;
			}
			[Token(Token = "0x6000219")]
			[Address(RVA = "0xB53EDC", Offset = "0xB53EDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdShowFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdShowFailedEvent -= value;
			}
		}

		[Token(Token = "0x14000019")]
		public event Action OnInterstitialAdClickedEvent
		{
			[Token(Token = "0x600021A")]
			[Address(RVA = "0xB53EE8", Offset = "0xB53EE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdClickedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdClickedEvent += value;
			}
			[Token(Token = "0x600021B")]
			[Address(RVA = "0xB53EF4", Offset = "0xB53EF4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdClickedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdClickedEvent -= value;
			}
		}

		[Token(Token = "0x1400001A")]
		public event Action OnInterstitialAdOpenedEvent
		{
			[Token(Token = "0x600021C")]
			[Address(RVA = "0xB53F00", Offset = "0xB53F00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdOpenedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdOpenedEvent += value;
			}
			[Token(Token = "0x600021D")]
			[Address(RVA = "0xB53F0C", Offset = "0xB53F0C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdOpenedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdOpenedEvent -= value;
			}
		}

		[Token(Token = "0x1400001B")]
		public event Action OnInterstitialAdClosedEvent
		{
			[Token(Token = "0x600021E")]
			[Address(RVA = "0xB53F18", Offset = "0xB53F18", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onInterstitialAdClosedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onInterstitialAdClosedEvent += value;
			}
			[Token(Token = "0x600021F")]
			[Address(RVA = "0xB53F24", Offset = "0xB53F24", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onInterstitialAdClosedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onInterstitialAdClosedEvent -= value;
			}
		}

		[Token(Token = "0x1400001C")]
		public event Action OnBannerAdLoadedEvent
		{
			[Token(Token = "0x6000220")]
			[Address(RVA = "0xB53F30", Offset = "0xB53F30", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onBannerAdLoadedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onBannerAdLoadedEvent += value;
			}
			[Token(Token = "0x6000221")]
			[Address(RVA = "0xB53F3C", Offset = "0xB53F3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onBannerAdLoadedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onBannerAdLoadedEvent -= value;
			}
		}

		[Token(Token = "0x1400001D")]
		public event Action<IronSourceError> OnBannerAdLoadedFailedEvent
		{
			[Token(Token = "0x6000222")]
			[Address(RVA = "0xB53F48", Offset = "0xB53F48", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onBannerAdLoadFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onBannerAdLoadFailedEvent += value;
			}
			[Token(Token = "0x6000223")]
			[Address(RVA = "0xB53F54", Offset = "0xB53F54", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onBannerAdLoadFailedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onBannerAdLoadFailedEvent -= value;
			}
		}

		[Token(Token = "0x1400001E")]
		public event Action OnBannerAdClickedEvent
		{
			[Token(Token = "0x6000224")]
			[Address(RVA = "0xB53F60", Offset = "0xB53F60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onBannerAdClickedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onBannerAdClickedEvent += value;
			}
			[Token(Token = "0x6000225")]
			[Address(RVA = "0xB53F6C", Offset = "0xB53F6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onBannerAdClickedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onBannerAdClickedEvent -= value;
			}
		}

		[Token(Token = "0x1400001F")]
		public event Action OnBannerAdScreenPresentedEvent
		{
			[Token(Token = "0x6000226")]
			[Address(RVA = "0xB53F78", Offset = "0xB53F78", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onBannerAdScreenPresentedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onBannerAdScreenPresentedEvent += value;
			}
			[Token(Token = "0x6000227")]
			[Address(RVA = "0xB53F84", Offset = "0xB53F84", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onBannerAdScreenPresentedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onBannerAdScreenPresentedEvent -= value;
			}
		}

		[Token(Token = "0x14000020")]
		public event Action OnBannerAdScreenDismissedEvent
		{
			[Token(Token = "0x6000228")]
			[Address(RVA = "0xB53F90", Offset = "0xB53F90", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onBannerAdScreenDismissedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onBannerAdScreenDismissedEvent += value;
			}
			[Token(Token = "0x6000229")]
			[Address(RVA = "0xB53F9C", Offset = "0xB53F9C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onBannerAdScreenDismissedEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onBannerAdScreenDismissedEvent -= value;
			}
		}

		[Token(Token = "0x14000021")]
		public event Action OnBannerAdLeftApplicationEvent
		{
			[Token(Token = "0x600022A")]
			[Address(RVA = "0xB53FA8", Offset = "0xB53FA8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::add_onBannerAdLeftApplicationEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				IronSourceEvents.onBannerAdLeftApplicationEvent += value;
			}
			[Token(Token = "0x600022B")]
			[Address(RVA = "0xB53FB4", Offset = "0xB53FB4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tIronSourceEvents::remove_onBannerAdLeftApplicationEvent(value);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				IronSourceEvents.onBannerAdLeftApplicationEvent -= value;
			}
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0xB53FC0", Offset = "0xB53FC0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA7BA8]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227B2]) = v38;\nL_0019:\n\tgoto L_0024;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<IronSourceBannerSize>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0024;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = IronSourceBannerSize;\nL_0024:\n\tthis.mCurrentBannerAdPos = 2;\n\tthis.mCurrentBannerAdSize = v52.SMART;\n\tgoto L_0035;\n\tv62 = *([v57 @ X0_v4 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0035;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv66 = EasyMobile.AdPlacement;\nL_0035:\n\tthis.mLastShownRewardedAdPlacement = v69.Default;\n\tthis.mLastShownInterstitialPlacement = v72.Default;\n\tEasyMobile.AdClientImpl::.ctor(this);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IronSourceClientImpl()
		{
			mCurrentBannerAdPos = IronSourceBannerPosition.BOTTOM;
			mCurrentBannerAdSize = IronSourceBannerSize.SMART;
			mLastShownRewardedAdPlacement = AdPlacement.Default;
			mLastShownInterstitialPlacement = AdPlacement.Default;
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0xB5407C", Offset = "0xB5407C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1F10BE0]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20227B3]) = v37;\nL_0016:\n\tv47 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0029;\n\tv45 = new EasyMobile.IronSourceClientImpl();\n\tEasyMobile.IronSourceClientImpl::.ctor(v45);\n\tv57.sInstance = v45;\n\tv47 = v59.sInstance;\nL_0029:\n\treturn v47;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IronSourceClientImpl CreateClient()
		{
			IronSourceClientImpl result = sInstance;
			if (sInstance == null)
			{
				IronSourceClientImpl ironSourceClientImpl = new IronSourceClientImpl();
				sInstance = ironSourceClientImpl;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0xB54120", Offset = "0xB54120", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsValidPlacement(AdPlacement placement, AdType type)
		{
			return true;
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xB54180", Offset = "0xB54180", Length = "0x594")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EFE7B0]);\n\tv29 = *([v28 @ X8_v73]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20227B5]) = v48;\nL_001A:\n\tthis.mIsInitialized = 1;\n\tv51 = EasyMobile.EM_Settings::get_Advertising();\n\tthis.mAdSettings = v51.mIronSource;\n\tv58 = EasyMobile.AdClientImpl::GetApplicableDataPrivacyConsent(this);\n\tv64 = EasyMobile.IronSourceClientImpl::ApplyDataPrivacyConsent(this, v58);\n\tv65 = this.mAdSettings;\n\tv91 = ~v65.mUseAdvancedSetting;\n\tif (v91) goto L_0039;\n\tv111 = EasyMobile.IronSourceClientImpl::SetupAdvancedSetting(this, v65);\nL_0039:\n\tv97 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v97, \"IronSourceAppStateHandler\");\n\tUnityEngine.Object::set_hideFlags(v97, 0x3D);\n\tv156 = UnityEngine.GameObject::AddComponent(v97);\n\tv98 = IronSource::get_Agent();\n\tv85 = this.mAdSettings;\n\tv99 = EasyMobile.CrossPlatformId::get_Id(v85.mAppId);\n\tIronSource::init(v98, v99);\n\tv164 = new System.Action();\n\tSystem.Action::.ctor(v164, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onBannerAdClickedEvent(v164);\n\tv174 = new System.Action();\n\tSystem.Action::.ctor(v174, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onBannerAdLeftApplicationEvent(v174);\n\tv184 = new System.Action();\n\tSystem.Action::.ctor(v184, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onBannerAdLoadedEvent(v184);\n\tv196 = new System.Action`1<IronSourceError>();\n\tSystem.Action`1<IronSourceError>::.ctor(v196, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onBannerAdLoadFailedEvent(v196);\n\tv208 = new System.Action();\n\tSystem.Action::.ctor(v208, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onInterstitialAdClickedEvent(v208);\n\tv218 = new System.Action();\n\tSystem.Action::.ctor(v218, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onInterstitialAdClosedEvent(v218);\n\tv228 = new System.Action`1<IronSourceError>();\n\tSystem.Action`1<IronSourceError>::.ctor(v228, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onInterstitialAdLoadFailedEvent(v228);\n\tv238 = new System.Action();\n\tSystem.Action::.ctor(v238, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onInterstitialAdOpenedEvent(v238);\n\tv248 = new System.Action();\n\tSystem.Action::.ctor(v248, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onInterstitialAdReadyEvent(v248);\n\tv258 = new System.Action();\n\tSystem.Action::.ctor(v258, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onInterstitialAdShowSucceededEvent(v258);\n\tv268 = new System.Action`1<IronSourceError>();\n\tSystem.Action`1<IronSourceError>::.ctor(v268, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onInterstitialAdShowFailedEvent(v268);\n\tv280 = new System.Action`1<IronSourcePlacement>();\n\tSystem.Action`1<IronSourcePlacement>::.ctor(v280, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAdClickedEvent(v280);\n\tv292 = new System.Action();\n\tSystem.Action::.ctor(v292, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAdClosedEvent(v292);\n\tv302 = new System.Action();\n\tSystem.Action::.ctor(v302, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAdEndedEvent(v302);\n\tv312 = new System.Action();\n\tSystem.Action::.ctor(v312, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAdOpenedEvent(v312);\n\tv322 = new System.Action`1<IronSourcePlacement>();\n\tSystem.Action`1<IronSourcePlacement>::.ctor(v322, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAdRewardedEvent(v322);\n\tv332 = new System.Action`1<IronSourceError>();\n\tSystem.Action`1<IronSourceError>::.ctor(v332, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAdShowFailedEvent(v332);\n\tv342 = new System.Action();\n\tSystem.Action::.ctor(v342, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAdStartedEvent(v342);\n\tv354 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v354, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onRewardedVideoAvailabilityChangedEvent(v354);\n\tv368 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v368, this, Il2CppMethodInfo);\n\tIronSourceEvents::add_onSegmentReceivedEvent(v368);\n\tgoto L_017A;\n\tv382 = *([v378 @ X0_v84+E0]);\n\tv383 = v382 == 0;\n\tv384 = ~v383;\n\tif (v384) goto L_017A;\n\tv386 = \"il2cpp_codegen_runtime_class_init\"(v378, v375, v133, v129, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_017A:\n\tUnityEngine.Debug::Log(\"ironSource client has been initialized.\");\n\treturn;\n\tv78 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 290 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalInit()
		{
			mIsInitialized = true;
			AdSettings advertising = EM_Settings.Advertising;
			mAdSettings = advertising.IronSource;
			ConsentStatus applicableDataPrivacyConsent = base.GetApplicableDataPrivacyConsent();
			ApplyDataPrivacyConsent(applicableDataPrivacyConsent);
			IronSourceSettings ironSourceSettings = mAdSettings;
			if (ironSourceSettings.UseAdvancedSetting)
			{
				SetupAdvancedSetting(ironSourceSettings);
			}
			GameObject gameObject = new GameObject("IronSourceAppStateHandler");
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			IronSourceAppStateHandler ironSourceAppStateHandler = gameObject.AddComponent<IronSourceAppStateHandler>();
			IronSource agent = IronSource.Agent;
			IronSourceSettings ironSourceSettings2 = mAdSettings;
			string id = ironSourceSettings2.AppId.Id;
			agent.init(id);
			Action value = OnBannerAdClicked;
			IronSourceEvents.onBannerAdClickedEvent += value;
			Action value2 = OnBannerAdLeftApplication;
			IronSourceEvents.onBannerAdLeftApplicationEvent += value2;
			Action value3 = OnBannerAdLoaded;
			IronSourceEvents.onBannerAdLoadedEvent += value3;
			Action<IronSourceError> value4 = OnBannerAdLoadFailed;
			IronSourceEvents.onBannerAdLoadFailedEvent += value4;
			Action value5 = OnInterstitialAdClicked;
			IronSourceEvents.onInterstitialAdClickedEvent += value5;
			Action value6 = OnInterstititalAdClosed;
			IronSourceEvents.onInterstitialAdClosedEvent += value6;
			Action<IronSourceError> value7 = OnInterstitialAdLoadFailed;
			IronSourceEvents.onInterstitialAdLoadFailedEvent += value7;
			Action value8 = OnInterstitialAdOpened;
			IronSourceEvents.onInterstitialAdOpenedEvent += value8;
			Action value9 = OnInterstitialAdReady;
			IronSourceEvents.onInterstitialAdReadyEvent += value9;
			Action value10 = OnInterstitialAdShowSucceeded;
			IronSourceEvents.onInterstitialAdShowSucceededEvent += value10;
			Action<IronSourceError> value11 = OnInterstitialAdShowFailed;
			IronSourceEvents.onInterstitialAdShowFailedEvent += value11;
			Action<IronSourcePlacement> value12 = OnRewardedVideoAdClicked;
			IronSourceEvents.onRewardedVideoAdClickedEvent += value12;
			Action value13 = OnRewardedVideoClosed;
			IronSourceEvents.onRewardedVideoAdClosedEvent += value13;
			Action value14 = OnRewardedVideoAdEnded;
			IronSourceEvents.onRewardedVideoAdEndedEvent += value14;
			Action value15 = OnRewardedVideoAdOpened;
			IronSourceEvents.onRewardedVideoAdOpenedEvent += value15;
			Action<IronSourcePlacement> value16 = OnRewardedVideoAdRewarded;
			IronSourceEvents.onRewardedVideoAdRewardedEvent += value16;
			Action<IronSourceError> value17 = OnRewardedVideoAdShowFailed;
			IronSourceEvents.onRewardedVideoAdShowFailedEvent += value17;
			Action value18 = OnRewardedVideoAdStarted;
			IronSourceEvents.onRewardedVideoAdStartedEvent += value18;
			Action<bool> value19 = OnRewardedVideoAvailabilityChanged;
			IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += value19;
			Action<string> value20 = OnSegmentReceived;
			IronSourceEvents.onSegmentReceivedEvent += value20;
			Debug.Log("ironSource client has been initialized.");
		}

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xB54714", Offset = "0xB54714", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F03770]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, placement, position, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20227B6]) = v47;\nL_0019:\n\tv48 = position < 3;\n\tv49 = ~v48;\n\tv50 = position - 3;\n\tv52 = v50 == 0;\n\tv57 = ~v52;\n\tv58 = v49 & v57;\n\tif (v58) goto L_FFFFFFFF;\n\tv60 = 0x1819000 + 0x9B4;\n\tv64 = *([v60 @ X8_v15 (System.Int32)+position @ X2 (EasyMobile.BannerAdPosition)*4]);\n\tgoto L_002C;\nL_002C:\n\tv67 = EasyMobile.IronSourceClientImpl::ToIronSourceBannerSize(this, size);\n\tgoto L_003F;\n\tv76 = *([v72 @ X8_v6+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_003F;\n\tv87 = v72;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v87, v66, position, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_003F:\n\tv86 = EasyMobile.AdPlacement::op_Inequality(this.mCurrentBannerAdPlacement, placement);\n\tv89 = v86 == 0;\n\tif (v89) goto L_004A;\n\tthis.mCurrentBannerAdPlacement = placement;\n\tthis.mIsBannerAdLoaded = 0;\nL_004A:\n\tv95 = this.mCurrentBannerAdPos == v64;\n\tif (v95) goto L_0057;\n\tthis.mCurrentBannerAdPos = v64;\n\tthis.mIsBannerAdLoaded = 0;\nL_0057:\n\tv105 = this.mCurrentBannerAdSize == v67;\n\tif (v105) goto L_0076;\n\tthis.mCurrentBannerAdSize = v67;\n\tthis.mIsBannerAdLoaded = 0;\nL_0060:\n\tv115 = EasyMobile.IronSourceClientImpl::ToIronSourcePlacementName(v86, this.mCurrentBannerAdPlacement);\n\tv137 = System.String::IsNullOrEmpty(v115);\n\tv126 = IronSource::get_Agent();\n\tv128 = v137 == 0;\n\tif (v128) goto L_0073;\n\tIronSource::loadBanner(v126, this.mCurrentBannerAdSize, this.mCurrentBannerAdPos);\n\tgoto L_0079;\nL_0073:\n\tIronSource::loadBanner(v126, this.mCurrentBannerAdSize, this.mCurrentBannerAdPos, v115);\n\tgoto L_0079;\nL_0076:\n\tv111 = ~this.mIsBannerAdLoaded;\n\tif (v111) goto L_0060;\nL_0079:\n\tv135 = IronSource::get_Agent();\n\tIronSource::displayBanner(v135);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
			//IL_01da: Expected O, but got I4
			bool flag = position < BannerAdPosition.TopRight;
			bool flag2 = !flag;
			int num = (int)(position - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			int num3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 2484;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v15 (System.Int32)+position @ X2 (EasyMobile.BannerAdPosition)*4]");
				num3 = 0;
			}
			else
			{
				num3 = 2;
			}
			IronSourceBannerSize ironSourceBannerSize = ToIronSourceBannerSize(size);
			bool flag5 = mCurrentBannerAdPlacement != placement;
			if (flag5)
			{
				mCurrentBannerAdPlacement = placement;
				mIsBannerAdLoaded = false;
			}
			if (mCurrentBannerAdPos != (IronSourceBannerPosition)num3)
			{
				mCurrentBannerAdPos = (IronSourceBannerPosition)num3;
				mIsBannerAdLoaded = false;
			}
			if (mCurrentBannerAdSize != ironSourceBannerSize)
			{
				mCurrentBannerAdSize = ironSourceBannerSize;
				mIsBannerAdLoaded = false;
			}
			else if (mIsBannerAdLoaded)
			{
				goto IL_0125;
			}
			string text = ((IronSourceClientImpl)flag5).ToIronSourcePlacementName(mCurrentBannerAdPlacement);
			bool flag6 = string.IsNullOrEmpty(text);
			IronSource agent = IronSource.Agent;
			if (flag6)
			{
				agent.loadBanner(mCurrentBannerAdSize, mCurrentBannerAdPos);
			}
			else
			{
				agent.loadBanner(mCurrentBannerAdSize, mCurrentBannerAdPos, text);
			}
			goto IL_0125;
			IL_0125:
			IronSource agent2 = IronSource.Agent;
			agent2.displayBanner();
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0xB54A08", Offset = "0xB54A08", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = IronSource::get_Agent();\n\tIronSource::hideBanner(v7);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalHideBannerAd(AdPlacement _)
		{
			IronSource agent = IronSource.Agent;
			agent.hideBanner();
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0xB54A2C", Offset = "0xB54A2C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = IronSource::get_Agent();\n\tIronSource::destroyBanner(v11);\n\tthis.mIsBannerAdLoaded = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalDestroyBannerAd(AdPlacement _)
		{
			IronSource agent = IronSource.Agent;
			agent.destroyBanner();
			mIsBannerAdLoaded = false;
		}

		[Token(Token = "0x600023B")]
		[Address(RVA = "0xB54A64", Offset = "0xB54A64", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = IronSource::get_Agent();\n\treturnVal1 = IronSource::isInterstitialReady(v7);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsInterstitialAdReady(AdPlacement _)
		{
			IronSource agent = IronSource.Agent;
			return agent.isInterstitialReady();
		}

		[Token(Token = "0x600023C")]
		[Address(RVA = "0xB54A88", Offset = "0xB54A88", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = IronSource::get_Agent();\n\tIronSource::loadInterstitial(v7);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalLoadInterstitialAd(AdPlacement _)
		{
			IronSource agent = IronSource.Agent;
			agent.loadInterstitial();
		}

		[Token(Token = "0x600023D")]
		[Address(RVA = "0xB54AAC", Offset = "0xB54AAC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mLastShownInterstitialPlacement = placement;\n\tv12 = EasyMobile.IronSourceClientImpl::ToIronSourcePlacementName(this, placement);\n\tv16 = System.String::IsNullOrEmpty(v12);\n\tv19 = IronSource::get_Agent();\n\tv22 = v16 == 0;\n\tif (v22) goto L_0022;\n\tIronSource::showInterstitial(v19);\n\treturn;\nL_0022:\n\tIronSource::showInterstitial(v19, v12);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalShowInterstitialAd(AdPlacement placement)
		{
			mLastShownInterstitialPlacement = placement;
			string text = ToIronSourcePlacementName(placement);
			bool flag = string.IsNullOrEmpty(text);
			IronSource agent = IronSource.Agent;
			if (flag)
			{
				agent.showInterstitial();
			}
			else
			{
				agent.showInterstitial(text);
			}
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0xB54B08", Offset = "0xB54B08", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = IronSource::get_Agent();\n\treturnVal1 = IronSource::isRewardedVideoAvailable(v7);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool InternalIsRewardedAdReady(AdPlacement _)
		{
			IronSource agent = IronSource.Agent;
			return agent.isRewardedVideoAvailable();
		}

		[Token(Token = "0x600023F")]
		[Address(RVA = "0xB54B2C", Offset = "0xB54B2C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InternalLoadRewardedAd(AdPlacement _)
		{
		}

		[Token(Token = "0x6000240")]
		[Address(RVA = "0xB54B30", Offset = "0xB54B30", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mLastShownRewardedAdPlacement = placement;\n\tv12 = EasyMobile.IronSourceClientImpl::ToIronSourcePlacementName(this, placement);\n\tv16 = System.String::IsNullOrEmpty(v12);\n\tv19 = IronSource::get_Agent();\n\tv22 = v16 == 0;\n\tif (v22) goto L_0022;\n\tIronSource::showRewardedVideo(v19);\n\treturn;\nL_0022:\n\tIronSource::showRewardedVideo(v19, v12);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InternalShowRewardedAd(AdPlacement placement)
		{
			mLastShownRewardedAdPlacement = placement;
			string text = ToIronSourcePlacementName(placement);
			bool flag = string.IsNullOrEmpty(text);
			IronSource agent = IronSource.Agent;
			if (flag)
			{
				agent.showRewardedVideo();
			}
			else
			{
				agent.showRewardedVideo(text);
			}
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0xB54BD4", Offset = "0xB54BD4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = consent == 2;\n\tif (v11) goto L_0020;\n\tv25 = consent != 1;\n\tif (v25) goto L_002D;\n\tv46 = IronSource::get_Agent();\n\tgoto L_0028;\nL_0020:\n\tv46 = IronSource::get_Agent();\nL_0028:\n\tIronSource::setConsent(v46, v40);\n\treturn;\nL_002D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void ApplyDataPrivacyConsent(ConsentStatus consent)
		{
			IronSource agent;
			bool consent2;
			switch (consent)
			{
			case ConsentStatus.Granted:
				agent = IronSource.Agent;
				consent2 = true;
				break;
			case ConsentStatus.Revoked:
				agent = IronSource.Agent;
				consent2 = false;
				break;
			default:
				return;
			}
			agent.setConsent(consent2);
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0xB54940", Offset = "0xB54940", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECCEC8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, placement, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20227B8]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, placement, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\tv55 = EasyMobile.AdPlacement::op_Equality(placement, 0);\n\tv59 = v55 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0047;\n\tgoto L_0038;\n\tv81 = *([v61 @ X0_v8 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0038;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v61, v53, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv85 = EasyMobile.AdPlacement;\nL_0038:\n\tv90 = EasyMobile.AdPlacement::op_Equality(placement, v88.Default);\n\tv103 = v90 == 0;\n\tv74 = ~v103;\n\tif (v74) goto L_0047;\n\treturnVal1 = placement.mName;\nL_0047:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected string ToIronSourcePlacementName(AdPlacement placement)
		{
			bool flag = placement == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			string result = null;
			if (!flag3)
			{
				bool flag4 = placement == AdPlacement.Default;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = null;
				if (!flag6)
				{
					result = placement.Name;
				}
			}
			return result;
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0xB54C28", Offset = "0xB54C28", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB9870]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, bannerType, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20227B9]) = v38;\nL_0013:\n\tv39 = bannerType < 3;\n\tv40 = ~v39;\n\tv41 = bannerType - 3;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_002B;\n\tv52 = 0x1819000 + 0x618;\n\tv54 = *([v52 @ X9_v2 (System.Int32)+bannerType @ X1 (EasyMobile.IronSourceSettings+IronSourceBannerType)*4]) + v52;\n\t// 36 IndirectJump v54 @ X8_v9, v35 @ X0_v1 (EasyMobile.IronSourceClientImpl), v35 @ X0_v1 (EasyMobile.IronSourceClientImpl), bannerType @ X1 (EasyMobile.IronSourceSettings+IronSourceBannerType), methodInfo @ X2 (Il2CppMethodInfo), v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_002B:\n\tgoto L_0033;\n\tv77 = *([v57 @ X0_v2 (Il2CppClass<IronSourceBannerSize>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0033;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v57, bannerType, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv81 = IronSourceBannerSize;\nL_0033:\n\tgoto L_0069;\n\tX19 = *([1EDAA78]);\n\tX0 = *([X19]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0041;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0041;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0041:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 8;\n\tgoto L_0069;\n\tX19 = *([1EDAA78]);\n\tX0 = *([X19]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0051;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0051:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 0x10;\n\tgoto L_0069;\n\tX19 = *([1EDAA78]);\n\tX0 = *([X19]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0061;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0061;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0061:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 0x18;\nL_0069:\n\treturn v72.BANNER;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected IronSourceBannerSize ToIronSourceBannerSize(IronSourceSettings.IronSourceBannerType bannerType)
		{
			//IL_0029: Expected O, but got I
			bool flag = bannerType < IronSourceSettings.IronSourceBannerType.SmartBanner;
			bool flag2 = !flag;
			int num = (int)(bannerType - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 1560;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+bannerType @ X1 (EasyMobile.IronSourceSettings+IronSourceBannerType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X8_v9 (should have been resolved before IL gen)");
			}
			return IronSourceBannerSize.BANNER;
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0xB54870", Offset = "0xB54870", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = pos < 3;\n\tv2 = ~v0;\n\tv3 = pos - 3;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_0011;\n\tv13 = 0x1819000 + 0x9B4;\n\treturn *([v13 @ X8_v2 (System.Int32)+pos @ X1 (EasyMobile.BannerAdPosition)*4]);\nL_0011:\n\treturn 2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected IronSourceBannerPosition ToIronSourceBannerPosition(BannerAdPosition pos)
		{
			bool flag = pos < BannerAdPosition.TopRight;
			bool flag2 = !flag;
			int num = (int)(pos - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 2484;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v2 (System.Int32)+pos @ X1 (EasyMobile.BannerAdPosition)*4]");
				return (IronSourceBannerPosition)0;
			}
			return IronSourceBannerPosition.BOTTOM;
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0xB54890", Offset = "0xB54890", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB0770]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, adSize, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227BA]) = v41;\nL_0018:\n\tv44 = ~adSize.<IsSmartBanner>k__BackingField;\n\tif (v44) goto L_0030;\n\tgoto L_002F;\n\tv63 = *([v49 @ X0_v5 (Il2CppClass<IronSourceBannerSize>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_002F;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v49, adSize, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv67 = IronSourceBannerSize;\nL_002F:\n\treturn v70.SMART;\nL_0030:\n\tv53 = this->klass;\n\tv58 = this->klass->vtable[95];\n\tv59 = this->klass->vtable[95];\n\t// 59 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.IronSourceClientImpl), this @ X0 (EasyMobile.IronSourceClientImpl), adSize @ X1 (EasyMobile.BannerAdSize), v59 @ X2_v1, v58 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected IronSourceBannerSize ToIronSourceBannerSize(BannerAdSize adSize)
		{
			//IL_002d: Expected I, but got O
			//IL_003d: Expected O, but got I
			//IL_004d: Expected O, but got I
			if (!adSize.IsSmartBanner)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v4 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+720]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v4 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+728]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
			}
			return IronSourceBannerSize.SMART;
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0xB54D44", Offset = "0xB54D44", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv18 = *([1EDA440]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, adSize, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20227BB]) = v38;\nL_0023:\n\tv54 = adSize.<Height>k__BackingField > 0x45;\n\tif (v54) goto L_003F;\n\tgoto L_0031;\n\tv75 = *([v57 @ X0_v13 (Il2CppClass<IronSourceBannerSize>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0031;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v57, adSize, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv79 = IronSourceBannerSize;\nL_0031:\n\tgoto L_005E;\nL_003F:\n\tv74 = adSize.<Height>k__BackingField > 0xA9;\n\tif (v74) goto L_004F;\n\tgoto L_004C;\n\tv142 = *([v61 @ X0_v6 (Il2CppClass<IronSourceBannerSize>)+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_004C;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v61, adSize, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv145 = IronSourceBannerSize;\nL_004C:\n\tgoto L_005E;\nL_004F:\n\tgoto L_005E;\n\tv148 = *([v61 @ X0_v6 (Il2CppClass<IronSourceBannerSize>)+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\t// 83 ConditionalJump @b24, v150 @ TEMP_v10\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v61, adSize, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv151 = IronSourceBannerSize;\nL_005E:\n\treturn v129.BANNER;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual IronSourceBannerSize ToIronSourceNearestSize(BannerAdSize adSize)
		{
			if (adSize.Height <= 69 || adSize.Height <= 169)
			{
			}
			return IronSourceBannerSize.BANNER;
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0xB54E18", Offset = "0xB54E18", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this->klass;\n\tv4 = adSettings.mSegments;\n\tv5 = this->klass->vtable[97];\n\tv6 = this->klass->vtable[97];\n\t// 6 IndirectJump v5 @ X3_v1, this @ X0 (EasyMobile.IronSourceClientImpl), this @ X0 (EasyMobile.IronSourceClientImpl), v4 @ X1_v1 (EasyMobile.IronSourceSettings+SegmentSettings), v6 @ X2_v1, v5 @ X3_v1, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SetupAdvancedSetting(IronSourceSettings adSettings)
		{
			//IL_0005: Expected I, but got O
			//IL_0022: Expected O, but got I
			//IL_0032: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			IronSourceSettings.SegmentSettings segments = adSettings.Segments;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+740]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+748]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v5 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0xB54E40", Offset = "0xB54E40", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAA680]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, segmentSettings, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20227BC]) = v38;\nL_0013:\n\tv39 = segmentSettings == 0;\n\tif (v39) goto L_002D;\n\tv41 = EasyMobile.IronSourceSettings+SegmentSettings::ToIronSourceSegment(segmentSettings);\n\tv49 = v41 == 0;\n\tif (v49) goto L_003C;\n\tv60 = IronSource::get_Agent();\n\tIronSource::setSegment(v60, v41);\n\treturn;\nL_002D:\n\tgoto L_FFFFFFFF;\n\tv50 = *([v44 @ X0_v4+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, segmentSettings, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_004B;\nL_003C:\n\tgoto L_FFFFFFFF;\n\tv81 = *([v63 @ X0_v9+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_FFFFFFFF;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v63, segmentSettings, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_004B:\n\tUnityEngine.Debug::LogError(*([v72 @ X8_v3 (System.String)]));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SetupSegment(IronSourceSettings.SegmentSettings segmentSettings)
		{
			string message;
			if (segmentSettings != null)
			{
				IronSourceSegment ironSourceSegment = segmentSettings.ToIronSourceSegment();
				if (ironSourceSegment != null)
				{
					IronSource agent = IronSource.Agent;
					agent.setSegment(ironSourceSegment);
					return;
				}
				message = "Segment is null!!!";
			}
			else
			{
				message = "SengmentSettings is null!!!";
			}
			Debug.LogError(message);
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0xB55074", Offset = "0xB55074", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnBannerAdClicked()
		{
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0xB55078", Offset = "0xB55078", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnBannerAdLeftApplication()
		{
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0xB5507C", Offset = "0xB5507C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAD8A8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227BD]) = v38;\nL_0014:\n\tthis.mIsBannerAdLoaded = 1;\n\tgoto L_002A;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_002A;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tUnityEngine.Debug::Log(\"Banner ad is loaded.\");\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnBannerAdLoaded()
		{
			mIsBannerAdLoaded = true;
			Debug.Log("Banner ad is loaded.");
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0xB550F4", Offset = "0xB550F4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFCDC0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, error, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227BE]) = v41;\nL_0015:\n\tthis.mIsBannerAdLoaded = 0;\n\tv47 = System.String::Concat(\"Failed to load banner ad. Error: \", error);\n\tgoto L_0032;\n\tv55 = *([v51 @ X8_v7+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0032;\n\tv69 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v69, v44, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0032:\n\tUnityEngine.Debug::Log(v47);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnBannerAdLoadFailed(IronSourceError error)
		{
			mIsBannerAdLoaded = false;
			string message = "Failed to load banner ad. Error: " + error;
			Debug.Log(message);
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0xB5518C", Offset = "0xB5518C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnInterstitialAdClicked()
		{
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0xB55190", Offset = "0xB55190", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDE6A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227BF]) = v38;\nL_0018:\n\tv44 = EasyMobile.AdClientImpl::OnInterstitialAdCompleted(this, this.mLastShownInterstitialPlacement);\n\tgoto L_0028;\n\tv51 = *([v47 @ X0_v4 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v47, v40, v43, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = EasyMobile.AdPlacement;\nL_0028:\n\tthis.mLastShownInterstitialPlacement = v58.Default;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnInterstititalAdClosed()
		{
			base.OnInterstitialAdCompleted(mLastShownInterstitialPlacement);
			mLastShownInterstitialPlacement = AdPlacement.Default;
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0xB55218", Offset = "0xB55218", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F08CA0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20227C0]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"Failed to load interstitial ad. Error: \", error);\n\tgoto L_002E;\n\tv52 = *([v48 @ X8_v7+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002E;\n\tv65 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v65, v41, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002E:\n\tUnityEngine.Debug::Log(v44);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnInterstitialAdLoadFailed(IronSourceError error)
		{
			string message = "Failed to load interstitial ad. Error: " + error;
			Debug.Log(message);
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0xB552A0", Offset = "0xB552A0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnInterstitialAdOpened()
		{
		}

		[Token(Token = "0x6000252")]
		[Address(RVA = "0xB552A4", Offset = "0xB552A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnInterstitialAdReady()
		{
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0xB552A8", Offset = "0xB552A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnInterstitialAdShowSucceeded()
		{
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0xB552AC", Offset = "0xB552AC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFFD70]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20227C1]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"Failed to show interstitial ad. Error: \", error);\n\tgoto L_002E;\n\tv52 = *([v48 @ X8_v7+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002E;\n\tv65 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v65, v41, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002E:\n\tUnityEngine.Debug::Log(v44);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnInterstitialAdShowFailed(IronSourceError error)
		{
			string message = "Failed to show interstitial ad. Error: " + error;
			Debug.Log(message);
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0xB55334", Offset = "0xB55334", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnRewardedVideoAdClicked(IronSourcePlacement obj)
		{
		}

		[Token(Token = "0x6000256")]
		[Address(RVA = "0xB55338", Offset = "0xB55338", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F03D90]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227C2]) = v38;\nL_0015:\n\tv41 = this->klass;\n\tv42 = ~this.mRewardedVideoIsCompleted;\n\tif (v42) goto L_001B;\n\tv48 = this->klass->vtable[84];\n\tv47 = this->klass->vtable[84];\n\tgoto L_001E;\nL_001B:\n\tv48 = this->klass->vtable[83];\n\tv47 = this->klass->vtable[83];\nL_001E:\n\tv48(v50, this, this.mLastShownRewardedAdPlacement, v47, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tthis.mRewardedVideoIsCompleted = 0;\n\tgoto L_002F;\n\tv57 = *([v53 @ X0_v4 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002F;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v53, v40, v47, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv61 = EasyMobile.AdPlacement;\nL_002F:\n\tthis.mLastShownRewardedAdPlacement = v64.Default;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnRewardedVideoClosed()
		{
			//IL_0054: Expected I, but got O
			//IL_003a: Expected O, but got I
			//IL_004a: Expected O, but got I
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			if (mRewardedVideoIsCompleted)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v3 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+670]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v3 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+678]");
				object obj2 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v3 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+660]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v3 (Il2CppClass<EasyMobile.IronSourceClientImpl>)+668]");
				object obj2 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v48 @ X9_v2 (should have been resolved before IL gen)");
			mRewardedVideoIsCompleted = false;
			mLastShownRewardedAdPlacement = AdPlacement.Default;
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0xB553D8", Offset = "0xB553D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnRewardedVideoAdEnded()
		{
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0xB553DC", Offset = "0xB553DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mRewardedVideoIsCompleted = 0;\n\treturn;\n")]
		private void OnRewardedVideoAdOpened()
		{
			mRewardedVideoIsCompleted = false;
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0xB553E4", Offset = "0xB553E4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = placement == 0;\n\tif (v0) goto L_0004;\n\tthis.mRewardedVideoIsCompleted = 1;\nL_0004:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnRewardedVideoAdRewarded(IronSourcePlacement placement)
		{
			if (placement != null)
			{
				mRewardedVideoIsCompleted = true;
			}
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0xB553F4", Offset = "0xB553F4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB07C0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, error, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227C3]) = v41;\nL_001A:\n\tv47 = System.String::Concat(\"Failed to show rewarded video ad. Error: \", error);\n\tgoto L_002B;\n\tv55 = *([v51 @ X8_v7+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002B;\n\tv64 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v64, v44, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002B:\n\tUnityEngine.Debug::Log(v47);\n\tthis.mRewardedVideoIsCompleted = 0;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnRewardedVideoAdShowFailed(IronSourceError error)
		{
			string message = "Failed to show rewarded video ad. Error: " + error;
			Debug.Log(message);
			mRewardedVideoIsCompleted = false;
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0xB55490", Offset = "0xB55490", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mRewardedVideoIsCompleted = 0;\n\treturn;\n")]
		private void OnRewardedVideoAdStarted()
		{
			mRewardedVideoIsCompleted = false;
		}

		[Token(Token = "0x600025C")]
		[Address(RVA = "0xB55498", Offset = "0xB55498", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnRewardedVideoAvailabilityChanged(bool obj)
		{
		}

		[Token(Token = "0x600025D")]
		[Address(RVA = "0xB5549C", Offset = "0xB5549C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED11C0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, segment, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20227C4]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"Received segment: \", segment);\n\tgoto L_002E;\n\tv52 = *([v48 @ X8_v7+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002E;\n\tv65 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v65, v41, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002E:\n\tUnityEngine.Debug::Log(v44);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnSegmentReceived(string segment)
		{
			string message = "Received segment: " + segment;
			Debug.Log(message);
		}
	}
}
