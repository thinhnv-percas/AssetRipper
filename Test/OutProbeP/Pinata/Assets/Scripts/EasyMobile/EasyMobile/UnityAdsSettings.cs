using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200003B")]
	public class UnityAdsSettings
	{
		[Token(Token = "0x40001A2")]
		public const string DEFAULT_BANNER_ZONE_ID = "";

		[Token(Token = "0x40001A3")]
		public const string DEFAULT_VIDEO_ZONE_ID = "video";

		[Token(Token = "0x40001A4")]
		public const string DEFAULT_REWARDED_ZONE_ID = "rewardedVideo";

		[SerializeField]
		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x10")]
		private AdId mAppId;

		[SerializeField]
		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x18")]
		private AdId mDefaultBannerAdId;

		[SerializeField]
		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x20")]
		private AdId mDefaultInterstitialAdId;

		[SerializeField]
		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x28")]
		private AdId mDefaultRewardedAdId;

		[SerializeField]
		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x30")]
		private Dictionary_AdPlacement_AdId mCustomBannerAdIds;

		[SerializeField]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x38")]
		private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;

		[SerializeField]
		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x40")]
		private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;

		[SerializeField]
		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0x48")]
		private bool mEnableTestMode;

		[Token(Token = "0x170000F7")]
		public AdId AppId
		{
			[Token(Token = "0x600034A")]
			[Address(RVA = "0xFD6ED4", Offset = "0xFD6ED4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAppId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppId;
			}
			[Token(Token = "0x600034B")]
			[Address(RVA = "0xFD6EDC", Offset = "0xFD6EDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAppId = value;\n\treturn;\n")]
			set
			{
				AppId = value;
			}
		}

		[Token(Token = "0x170000F8")]
		public AdId DefaultBannerAdId
		{
			[Token(Token = "0x600034C")]
			[Address(RVA = "0xFD6EE4", Offset = "0xFD6EE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultBannerAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultBannerAdId;
			}
			[Token(Token = "0x600034D")]
			[Address(RVA = "0xFD6EEC", Offset = "0xFD6EEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultBannerAdId = value;\n\treturn;\n")]
			set
			{
				DefaultBannerAdId = value;
			}
		}

		[Token(Token = "0x170000F9")]
		public AdId DefaultInterstitialAdId
		{
			[Token(Token = "0x600034E")]
			[Address(RVA = "0xFD6EF4", Offset = "0xFD6EF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultInterstitialAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultInterstitialAdId;
			}
			[Token(Token = "0x600034F")]
			[Address(RVA = "0xFD6EFC", Offset = "0xFD6EFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultInterstitialAdId = value;\n\treturn;\n")]
			set
			{
				DefaultInterstitialAdId = value;
			}
		}

		[Token(Token = "0x170000FA")]
		public AdId DefaultRewardedAdId
		{
			[Token(Token = "0x6000350")]
			[Address(RVA = "0xFD6F04", Offset = "0xFD6F04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRewardedAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRewardedAdId;
			}
			[Token(Token = "0x6000351")]
			[Address(RVA = "0xFD6F0C", Offset = "0xFD6F0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRewardedAdId = value;\n\treturn;\n")]
			set
			{
				DefaultRewardedAdId = value;
			}
		}

		[Token(Token = "0x170000FB")]
		public Dictionary<AdPlacement, AdId> CustomBannerAdIds
		{
			[Token(Token = "0x6000352")]
			[Address(RVA = "0xFD6F14", Offset = "0xFD6F14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomBannerAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomBannerAdIds;
			}
			[Token(Token = "0x6000353")]
			[Address(RVA = "0xFD6F1C", Offset = "0xFD6F1C", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE56C8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256F0]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomBannerAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				mCustomBannerAdIds = (Dictionary_AdPlacement_AdId)dictionary;
			}
		}

		[Token(Token = "0x170000FC")]
		public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
		{
			[Token(Token = "0x6000354")]
			[Address(RVA = "0xFD6FAC", Offset = "0xFD6FAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomInterstitialAdIds;
			}
			[Token(Token = "0x6000355")]
			[Address(RVA = "0xFD6FB4", Offset = "0xFD6FB4", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EABA90]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256F1]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomInterstitialAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x170000FD")]
		public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
		{
			[Token(Token = "0x6000356")]
			[Address(RVA = "0xFD7044", Offset = "0xFD7044", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomRewardedAdIds;
			}
			[Token(Token = "0x6000357")]
			[Address(RVA = "0xFD704C", Offset = "0xFD704C", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFBCC0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256F2]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomRewardedAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x170000FE")]
		public bool EnableTestMode
		{
			[Token(Token = "0x6000358")]
			[Address(RVA = "0xFD70DC", Offset = "0xFD70DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableTestMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableTestMode;
			}
			[Token(Token = "0x6000359")]
			[Address(RVA = "0xFD70E4", Offset = "0xFD70E4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableTestMode = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableTestMode = value;
			}
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0xFD70F0", Offset = "0xFD70F0", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EA7ED8]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20256F3]) = v40;\nL_0016:\n\tSystem.Object::.ctor(this);\n\tv46 = new EasyMobile.AdId();\n\tEasyMobile.AdId::.ctor(v46, \"\", \"\");\n\tthis.mDefaultBannerAdId = v46;\n\tv54 = new EasyMobile.AdId();\n\tEasyMobile.AdId::.ctor(v54, \"video\", \"video\");\n\tthis.mDefaultInterstitialAdId = v54;\n\tv62 = new EasyMobile.AdId();\n\tEasyMobile.AdId::.ctor(v62, \"rewardedVideo\", \"rewardedVideo\");\n\tthis.mDefaultRewardedAdId = v62;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnityAdsSettings()
		{
			AdId defaultBannerAdId = new AdId("", "");
			DefaultBannerAdId = defaultBannerAdId;
			DefaultInterstitialAdId = new AdId("video", "video");
			DefaultRewardedAdId = new AdId("rewardedVideo", "rewardedVideo");
		}
	}
}
