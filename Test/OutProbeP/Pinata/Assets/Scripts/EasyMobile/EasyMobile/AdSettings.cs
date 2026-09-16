using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200001D")]
	public class AdSettings
	{
		[Serializable]
		[StructLayout((LayoutKind)0, Size = 12)]
		[Token(Token = "0x2000108")]
		public struct DefaultAdNetworks
		{
			[Token(Token = "0x400047B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public BannerAdNetwork bannerAdNetwork;

			[Token(Token = "0x400047C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public InterstitialAdNetwork interstitialAdNetwork;

			[Token(Token = "0x400047D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public RewardedAdNetwork rewardedAdNetwork;

			[Token(Token = "0x6000932")]
			[Address(RVA = "0x846FA4", Offset = "0x846FA4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (EasyMobile.AdSettings+DefaultAdNetworks)+10]) = banner;\n\t*([this @ X0 (EasyMobile.AdSettings+DefaultAdNetworks)+14]) = interstitial;\n\t*([this @ X0 (EasyMobile.AdSettings+DefaultAdNetworks)+18]) = rewarded;\n\treturn;\n")]
			public DefaultAdNetworks(BannerAdNetwork banner, InterstitialAdNetwork interstitial, RewardedAdNetwork rewarded)
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x40000EA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private AutoAdLoadingMode mAutoLoadAdsMode;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x73209C", Offset = "0x73209C")]
		[Token(Token = "0x40000EB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		private float mAdCheckingInterval;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7320E0", Offset = "0x7320E0")]
		[Token(Token = "0x40000EC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private float mAdLoadingInterval;

		[SerializeField]
		[Token(Token = "0x40000ED")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		internal DefaultAdNetworks mIosDefaultAdNetworks;

		[SerializeField]
		[Token(Token = "0x40000EE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		internal DefaultAdNetworks mAndroidDefaultAdNetworks;

		[SerializeField]
		[Token(Token = "0x40000EF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		private AdColonySettings mAdColony;

		[SerializeField]
		[Token(Token = "0x40000F0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		private AdMobSettings mAdMob;

		[SerializeField]
		[Token(Token = "0x40000F1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		private AppLovinSettings mAppLovin;

		[SerializeField]
		[Token(Token = "0x40000F2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		private AudienceNetworkSettings mFBAudience;

		[SerializeField]
		[Token(Token = "0x40000F3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		private ChartboostSettings mChartboost;

		[SerializeField]
		[Token(Token = "0x40000F4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		private HeyzapSettings mHeyzap;

		[SerializeField]
		[Token(Token = "0x40000F5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		private IronSourceSettings mIronSource;

		[SerializeField]
		[Token(Token = "0x40000F6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		private MoPubSettings mMoPub;

		[SerializeField]
		[Token(Token = "0x40000F7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
		private TapjoySettings mTapjoy;

		[SerializeField]
		[Token(Token = "0x40000F8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
		private UnityAdsSettings mUnityAds;

		[Token(Token = "0x17000019")]
		public AutoAdLoadingMode AutoAdLoadingMode
		{
			[Token(Token = "0x600008A")]
			[Address(RVA = "0xA46A20", Offset = "0xA46A20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoLoadAdsMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AutoAdLoadingMode;
			}
			[Token(Token = "0x600008B")]
			[Address(RVA = "0xA46A28", Offset = "0xA46A28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoLoadAdsMode = value;\n\treturn;\n")]
			set
			{
				AutoAdLoadingMode = value;
			}
		}

		[Token(Token = "0x1700001A")]
		public float AdCheckingInterval
		{
			[Token(Token = "0x600008C")]
			[Address(RVA = "0xA46A30", Offset = "0xA46A30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAdCheckingInterval;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdCheckingInterval;
			}
			[Token(Token = "0x600008D")]
			[Address(RVA = "0xA46A38", Offset = "0xA46A38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAdCheckingInterval = value;\n\treturn;\n")]
			set
			{
				AdCheckingInterval = value;
			}
		}

		[Token(Token = "0x1700001B")]
		public float AdLoadingInterval
		{
			[Token(Token = "0x600008E")]
			[Address(RVA = "0xA46A40", Offset = "0xA46A40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAdLoadingInterval;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdLoadingInterval;
			}
			[Token(Token = "0x600008F")]
			[Address(RVA = "0xA46A48", Offset = "0xA46A48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAdLoadingInterval = value;\n\treturn;\n")]
			set
			{
				AdLoadingInterval = value;
			}
		}

		[Token(Token = "0x1700001C")]
		public DefaultAdNetworks IosDefaultAdNetworks
		{
			[Token(Token = "0x6000090")]
			[Address(RVA = "0xA46A50", Offset = "0xA46A50", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIosDefaultAdNetworks;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mIosDefaultAdNetworks;
			}
		}

		[Token(Token = "0x1700001D")]
		public DefaultAdNetworks AndroidDefaultAdNetworks
		{
			[Token(Token = "0x6000091")]
			[Address(RVA = "0xA46A60", Offset = "0xA46A60", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAndroidDefaultAdNetworks;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mAndroidDefaultAdNetworks;
			}
		}

		[Token(Token = "0x1700001E")]
		public AdColonySettings AdColony
		{
			[Token(Token = "0x6000092")]
			[Address(RVA = "0xA46A70", Offset = "0xA46A70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAdColony;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdColony;
			}
		}

		[Token(Token = "0x1700001F")]
		public AdMobSettings AdMob
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0xA46A78", Offset = "0xA46A78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAdMob;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdMob;
			}
		}

		[Token(Token = "0x17000020")]
		public AppLovinSettings AppLovin
		{
			[Token(Token = "0x6000094")]
			[Address(RVA = "0xA46A80", Offset = "0xA46A80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAppLovin;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppLovin;
			}
		}

		[Token(Token = "0x17000021")]
		public AudienceNetworkSettings AudienceNetwork
		{
			[Token(Token = "0x6000095")]
			[Address(RVA = "0xA46A88", Offset = "0xA46A88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mFBAudience;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AudienceNetwork;
			}
		}

		[Token(Token = "0x17000022")]
		public ChartboostSettings Chartboost
		{
			[Token(Token = "0x6000096")]
			[Address(RVA = "0xA46A90", Offset = "0xA46A90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mChartboost;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Chartboost;
			}
		}

		[Token(Token = "0x17000023")]
		public HeyzapSettings Heyzap
		{
			[Token(Token = "0x6000097")]
			[Address(RVA = "0xA46A98", Offset = "0xA46A98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mHeyzap;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Heyzap;
			}
		}

		[Token(Token = "0x17000024")]
		public IronSourceSettings IronSource
		{
			[Token(Token = "0x6000098")]
			[Address(RVA = "0xA46AA0", Offset = "0xA46AA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIronSource;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IronSource;
			}
		}

		[Token(Token = "0x17000025")]
		public MoPubSettings MoPub
		{
			[Token(Token = "0x6000099")]
			[Address(RVA = "0xA46AA8", Offset = "0xA46AA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMoPub;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MoPub;
			}
		}

		[Token(Token = "0x17000026")]
		public TapjoySettings Tapjoy
		{
			[Token(Token = "0x600009A")]
			[Address(RVA = "0xA46AB0", Offset = "0xA46AB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mTapjoy;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Tapjoy;
			}
		}

		[Token(Token = "0x17000027")]
		public UnityAdsSettings UnityAds
		{
			[Token(Token = "0x600009B")]
			[Address(RVA = "0xA46AB8", Offset = "0xA46AB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mUnityAds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UnityAds;
			}
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0xA46AC0", Offset = "0xA46AC0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAndroidDefaultAdNetworks.interstitialAdNetwork = 0;\n\tthis.mIosDefaultAdNetworks.rewardedAdNetwork = 0;\n\tthis.mAutoLoadAdsMode = 0x4120000000000002;\n\tthis.mAdLoadingInterval = 20f;\n\tthis.mIosDefaultAdNetworks = 0;\n\tSystem.Object::.ctor(this);\n\treturn;\n\t*([X0]) = X1;\n\t*([X0+4]) = X2;\n\t*([X0+8]) = X3;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdSettings()
		{
			//IL_0047: Expected I4, but got I8
			base._002Ector();
			mAndroidDefaultAdNetworks.interstitialAdNetwork = default(InterstitialAdNetwork);
			mIosDefaultAdNetworks.rewardedAdNetwork = default(RewardedAdNetwork);
			AutoAdLoadingMode = AutoAdLoadingMode.LoadAllDefinedPlacements;
			AdLoadingInterval = 20f;
			mIosDefaultAdNetworks = default(DefaultAdNetworks);
		}
	}
}
