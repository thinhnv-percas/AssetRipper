using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000038")]
	public class MoPubSettings
	{
		[Token(Token = "0x2000113")]
		public enum SupportedNetwork
		{
			[Token(Token = "0x40004A0")]
			None = 0,
			[Token(Token = "0x40004A1")]
			AdColony = 1,
			[Token(Token = "0x40004A2")]
			AdMob = 2,
			[Token(Token = "0x40004A3")]
			AppLovin = 3,
			[Token(Token = "0x40004A4")]
			Chartboost = 4,
			[Token(Token = "0x40004A5")]
			Facebook = 5,
			[Token(Token = "0x40004A6")]
			IronSource = 6,
			[Token(Token = "0x40004A7")]
			OnebyAOL = 7,
			[Token(Token = "0x40004A8")]
			TapJoy = 8,
			[Token(Token = "0x40004A9")]
			UnityAds = 9,
			[Token(Token = "0x40004AA")]
			Vungle = 10
		}

		[Token(Token = "0x2000114")]
		public enum LogLevel
		{
			[Token(Token = "0x40004AC")]
			Debug = 20,
			[Token(Token = "0x40004AD")]
			Info = 30,
			[Token(Token = "0x40004AE")]
			None = 70
		}

		[Serializable]
		[Token(Token = "0x2000115")]
		public class MediatedNetwork
		{
			[SerializeField]
			[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x733F18", Offset = "0x733F18")]
			[Token(Token = "0x40004AF")]
			[FieldOffset(Offset = "0x10")]
			private bool mIsSupportedNetwork;

			[SerializeField]
			[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x733F64", Offset = "0x733F64")]
			[Token(Token = "0x40004B0")]
			[FieldOffset(Offset = "0x14")]
			private SupportedNetwork mSupportedNetworkName;

			[SerializeField]
			[Token(Token = "0x40004B1")]
			[FieldOffset(Offset = "0x18")]
			private string mAdapterConfigurationClassName;

			[SerializeField]
			[Token(Token = "0x40004B2")]
			[FieldOffset(Offset = "0x20")]
			private string mMediationSettingsClassName;

			[SerializeField]
			[Token(Token = "0x40004B3")]
			[FieldOffset(Offset = "0x28")]
			private StringStringSerializableDictionary mNetworkConfiguration;

			[SerializeField]
			[Token(Token = "0x40004B4")]
			[FieldOffset(Offset = "0x30")]
			private StringStringSerializableDictionary mMediationSettings;

			[SerializeField]
			[Token(Token = "0x40004B5")]
			[FieldOffset(Offset = "0x38")]
			private StringStringSerializableDictionary mMoPubRequestOption;

			[Token(Token = "0x17000258")]
			public bool IsSupportedNetwork
			{
				[Token(Token = "0x600094D")]
				[Address(RVA = "0xFCE004", Offset = "0xFCE004", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsSupportedNetwork;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return IsSupportedNetwork;
				}
				[Token(Token = "0x600094E")]
				[Address(RVA = "0xFCE00C", Offset = "0xFCE00C", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mIsSupportedNetwork = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					mIsSupportedNetwork = value;
				}
			}

			[Token(Token = "0x17000259")]
			public SupportedNetwork SupportedNetworkName
			{
				[Token(Token = "0x600094F")]
				[Address(RVA = "0xFCE018", Offset = "0xFCE018", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mSupportedNetworkName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return SupportedNetworkName;
				}
				[Token(Token = "0x6000950")]
				[Address(RVA = "0xFCE020", Offset = "0xFCE020", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mSupportedNetworkName = value;\n\treturn;\n")]
				set
				{
					SupportedNetworkName = value;
				}
			}

			[Token(Token = "0x1700025A")]
			public string AdapterConfigurationClassName
			{
				[Token(Token = "0x6000951")]
				[Address(RVA = "0xFCE028", Offset = "0xFCE028", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAdapterConfigurationClassName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return AdapterConfigurationClassName;
				}
				[Token(Token = "0x6000952")]
				[Address(RVA = "0xFCE030", Offset = "0xFCE030", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAdapterConfigurationClassName = value;\n\treturn;\n")]
				set
				{
					AdapterConfigurationClassName = value;
				}
			}

			[Token(Token = "0x1700025B")]
			public string MediationSettingsClassName
			{
				[Token(Token = "0x6000953")]
				[Address(RVA = "0xFCE038", Offset = "0xFCE038", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMediationSettingsClassName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return MediationSettingsClassName;
				}
				[Token(Token = "0x6000954")]
				[Address(RVA = "0xFCE040", Offset = "0xFCE040", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mMediationSettingsClassName = value;\n\treturn;\n")]
				set
				{
					MediationSettingsClassName = value;
				}
			}

			[Token(Token = "0x1700025C")]
			public Dictionary<string, string> NetworkConfiguration
			{
				[Token(Token = "0x6000955")]
				[Address(RVA = "0xFCE048", Offset = "0xFCE048", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mNetworkConfiguration;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return mNetworkConfiguration;
				}
				[Token(Token = "0x6000956")]
				[Address(RVA = "0xFCE050", Offset = "0xFCE050", Length = "0x90")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC3838]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025663]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mNetworkConfiguration = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					Dictionary<string, string> dictionary;
					if (value == null)
					{
						dictionary = null;
					}
					else
					{
						StringStringSerializableDictionary stringStringSerializableDictionary = value as StringStringSerializableDictionary;
						dictionary = ((stringStringSerializableDictionary == null) ? null : value);
					}
					mNetworkConfiguration = (StringStringSerializableDictionary)dictionary;
				}
			}

			[Token(Token = "0x1700025D")]
			public Dictionary<string, string> MediationSettings
			{
				[Token(Token = "0x6000957")]
				[Address(RVA = "0xFCE0E0", Offset = "0xFCE0E0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMediationSettings;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return mMediationSettings;
				}
				[Token(Token = "0x6000958")]
				[Address(RVA = "0xFCE0E8", Offset = "0xFCE0E8", Length = "0x90")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC2928]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025664]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mMediationSettings = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					Dictionary<string, string> dictionary;
					if (value == null)
					{
						dictionary = null;
					}
					else
					{
						StringStringSerializableDictionary stringStringSerializableDictionary = value as StringStringSerializableDictionary;
						dictionary = ((stringStringSerializableDictionary == null) ? null : value);
					}
					mMediationSettings = (StringStringSerializableDictionary)dictionary;
				}
			}

			[Token(Token = "0x1700025E")]
			public Dictionary<string, string> MoPubRequestOptions
			{
				[Token(Token = "0x6000959")]
				[Address(RVA = "0xFCE178", Offset = "0xFCE178", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMoPubRequestOption;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return mMoPubRequestOption;
				}
				[Token(Token = "0x600095A")]
				[Address(RVA = "0xFCE180", Offset = "0xFCE180", Length = "0x90")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFB508]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025665]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mMoPubRequestOption = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					Dictionary<string, string> dictionary;
					if (value == null)
					{
						dictionary = null;
					}
					else
					{
						StringStringSerializableDictionary stringStringSerializableDictionary = value as StringStringSerializableDictionary;
						dictionary = ((stringStringSerializableDictionary == null) ? null : value);
					}
					mMoPubRequestOption = (StringStringSerializableDictionary)dictionary;
				}
			}

			[Token(Token = "0x600095B")]
			[Address(RVA = "0xFCE210", Offset = "0xFCE210", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public MediatedNetwork()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x10")]
		private bool mReportAppOpen;

		[SerializeField]
		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x18")]
		private string mITuneAppID;

		[SerializeField]
		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x20")]
		private bool mEnableLocationPassing;

		[SerializeField]
		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x21")]
		private bool mUseAdvancedSetting;

		[SerializeField]
		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x22")]
		private bool mAllowLegitimateInterest;

		[SerializeField]
		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x24")]
		private LogLevel mLogLevel;

		[SerializeField]
		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x28")]
		private MediatedNetwork[] mMediatedNetworks;

		[SerializeField]
		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x30")]
		private bool mAutoRequestConsent;

		[SerializeField]
		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x31")]
		private bool mForceGdprApplicable;

		[SerializeField]
		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x38")]
		private AdId mDefaultBannerId;

		[SerializeField]
		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x40")]
		private AdId mDefaultInterstitialAdId;

		[SerializeField]
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x48")]
		private AdId mDefaultRewardedAdId;

		[SerializeField]
		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x50")]
		private Dictionary_AdPlacement_AdId mCustomBannerIds;

		[SerializeField]
		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x58")]
		private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;

		[SerializeField]
		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x60")]
		private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;

		[Token(Token = "0x170000E2")]
		public AdId DefaultBannerId
		{
			[Token(Token = "0x600031D")]
			[Address(RVA = "0xFCDD54", Offset = "0xFCDD54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultBannerId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultBannerId;
			}
			[Token(Token = "0x600031E")]
			[Address(RVA = "0xFCDD5C", Offset = "0xFCDD5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultBannerId = value;\n\treturn;\n")]
			set
			{
				DefaultBannerId = value;
			}
		}

		[Token(Token = "0x170000E3")]
		public AdId DefaultInterstitialAdId
		{
			[Token(Token = "0x600031F")]
			[Address(RVA = "0xFCDD64", Offset = "0xFCDD64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultInterstitialAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultInterstitialAdId;
			}
			[Token(Token = "0x6000320")]
			[Address(RVA = "0xFCDD6C", Offset = "0xFCDD6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultInterstitialAdId = value;\n\treturn;\n")]
			set
			{
				DefaultInterstitialAdId = value;
			}
		}

		[Token(Token = "0x170000E4")]
		public AdId DefaultRewardedAdId
		{
			[Token(Token = "0x6000321")]
			[Address(RVA = "0xFCDD74", Offset = "0xFCDD74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRewardedAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRewardedAdId;
			}
			[Token(Token = "0x6000322")]
			[Address(RVA = "0xFCDD7C", Offset = "0xFCDD7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRewardedAdId = value;\n\treturn;\n")]
			set
			{
				DefaultRewardedAdId = value;
			}
		}

		[Token(Token = "0x170000E5")]
		public Dictionary<AdPlacement, AdId> CustomBannerIds
		{
			[Token(Token = "0x6000323")]
			[Address(RVA = "0xFCDD84", Offset = "0xFCDD84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomBannerIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomBannerIds;
			}
			[Token(Token = "0x6000324")]
			[Address(RVA = "0xFCDD8C", Offset = "0xFCDD8C", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC5BA8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025660]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomBannerIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Dictionary<AdPlacement, AdId> dictionary;
				if (value == null)
				{
					dictionary = null;
				}
				else
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					dictionary = ((dictionary_AdPlacement_AdId == null) ? null : value);
				}
				mCustomBannerIds = (Dictionary_AdPlacement_AdId)dictionary;
			}
		}

		[Token(Token = "0x170000E6")]
		public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
		{
			[Token(Token = "0x6000325")]
			[Address(RVA = "0xFCDE1C", Offset = "0xFCDE1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomInterstitialAdIds;
			}
			[Token(Token = "0x6000326")]
			[Address(RVA = "0xFCDE24", Offset = "0xFCDE24", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB31E8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025661]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomInterstitialAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Dictionary<AdPlacement, AdId> dictionary;
				if (value == null)
				{
					dictionary = null;
				}
				else
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					dictionary = ((dictionary_AdPlacement_AdId == null) ? null : value);
				}
				mCustomInterstitialAdIds = (Dictionary_AdPlacement_AdId)dictionary;
			}
		}

		[Token(Token = "0x170000E7")]
		public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
		{
			[Token(Token = "0x6000327")]
			[Address(RVA = "0xFCDEB4", Offset = "0xFCDEB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomRewardedAdIds;
			}
			[Token(Token = "0x6000328")]
			[Address(RVA = "0xFCDEBC", Offset = "0xFCDEBC", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EECE10]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025662]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomRewardedAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Dictionary<AdPlacement, AdId> dictionary;
				if (value == null)
				{
					dictionary = null;
				}
				else
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					dictionary = ((dictionary_AdPlacement_AdId == null) ? null : value);
				}
				mCustomRewardedAdIds = (Dictionary_AdPlacement_AdId)dictionary;
			}
		}

		[Token(Token = "0x170000E8")]
		public bool ReportAppOpen
		{
			[Token(Token = "0x6000329")]
			[Address(RVA = "0xFCDF4C", Offset = "0xFCDF4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mReportAppOpen;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ReportAppOpen;
			}
			[Token(Token = "0x600032A")]
			[Address(RVA = "0xFCDF54", Offset = "0xFCDF54", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mReportAppOpen = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mReportAppOpen = value;
			}
		}

		[Token(Token = "0x170000E9")]
		public string ITuneAppID
		{
			[Token(Token = "0x600032B")]
			[Address(RVA = "0xFCDF60", Offset = "0xFCDF60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mITuneAppID;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ITuneAppID;
			}
			[Token(Token = "0x600032C")]
			[Address(RVA = "0xFCDF68", Offset = "0xFCDF68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mITuneAppID = value;\n\treturn;\n")]
			set
			{
				ITuneAppID = value;
			}
		}

		[Token(Token = "0x170000EA")]
		public bool EnableLocationPassing
		{
			[Token(Token = "0x600032D")]
			[Address(RVA = "0xFCDF70", Offset = "0xFCDF70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableLocationPassing;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableLocationPassing;
			}
			[Token(Token = "0x600032E")]
			[Address(RVA = "0xFCDF78", Offset = "0xFCDF78", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableLocationPassing = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableLocationPassing = value;
			}
		}

		[Token(Token = "0x170000EB")]
		public bool UseAdvancedSetting
		{
			[Token(Token = "0x600032F")]
			[Address(RVA = "0xFCDF84", Offset = "0xFCDF84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mUseAdvancedSetting;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UseAdvancedSetting;
			}
			[Token(Token = "0x6000330")]
			[Address(RVA = "0xFCDF8C", Offset = "0xFCDF8C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mUseAdvancedSetting = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mUseAdvancedSetting = value;
			}
		}

		[Token(Token = "0x170000EC")]
		public bool AllowLegitimateInterest
		{
			[Token(Token = "0x6000331")]
			[Address(RVA = "0xFCDF98", Offset = "0xFCDF98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAllowLegitimateInterest;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AllowLegitimateInterest;
			}
			[Token(Token = "0x6000332")]
			[Address(RVA = "0xFCDFA0", Offset = "0xFCDFA0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAllowLegitimateInterest = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mAllowLegitimateInterest = value;
			}
		}

		[Token(Token = "0x170000ED")]
		public LogLevel MoPubLogLevel
		{
			[Token(Token = "0x6000333")]
			[Address(RVA = "0xFCDFAC", Offset = "0xFCDFAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mLogLevel;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MoPubLogLevel;
			}
			[Token(Token = "0x6000334")]
			[Address(RVA = "0xFCDFB4", Offset = "0xFCDFB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mLogLevel = value;\n\treturn;\n")]
			set
			{
				MoPubLogLevel = value;
			}
		}

		[Token(Token = "0x170000EE")]
		public MediatedNetwork[] MediatedNetworks
		{
			[Token(Token = "0x6000335")]
			[Address(RVA = "0xFCDFBC", Offset = "0xFCDFBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMediatedNetworks;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MediatedNetworks;
			}
			[Token(Token = "0x6000336")]
			[Address(RVA = "0xFCDFC4", Offset = "0xFCDFC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mMediatedNetworks = value;\n\treturn;\n")]
			set
			{
				MediatedNetworks = value;
			}
		}

		[Token(Token = "0x170000EF")]
		public bool AutoRequestConsent
		{
			[Token(Token = "0x6000337")]
			[Address(RVA = "0xFCDFCC", Offset = "0xFCDFCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoRequestConsent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AutoRequestConsent;
			}
			[Token(Token = "0x6000338")]
			[Address(RVA = "0xFCDFD4", Offset = "0xFCDFD4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoRequestConsent = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mAutoRequestConsent = value;
			}
		}

		[Token(Token = "0x170000F0")]
		public bool ForceGdprApplicable
		{
			[Token(Token = "0x6000339")]
			[Address(RVA = "0xFCDFE0", Offset = "0xFCDFE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mForceGdprApplicable;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ForceGdprApplicable;
			}
			[Token(Token = "0x600033A")]
			[Address(RVA = "0xFCDFE8", Offset = "0xFCDFE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mForceGdprApplicable = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mForceGdprApplicable = value;
			}
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0xFCDFF4", Offset = "0xFCDFF4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mLogLevel = 0x46;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MoPubSettings()
		{
			MoPubLogLevel = LogLevel.None;
		}
	}
}
