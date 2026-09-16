using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000034")]
	public class AudienceNetworkSettings
	{
		[Token(Token = "0x2000110")]
		public enum FBAudienceBannerAdSize
		{
			[Token(Token = "0x400048F")]
			_50 = 0,
			[Token(Token = "0x4000490")]
			_90 = 1,
			[Token(Token = "0x4000491")]
			_250 = 2
		}

		[SerializeField]
		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x10")]
		private FBAudienceBannerAdSize mBannerAdSize;

		[SerializeField]
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x14")]
		private bool mEnableTestMode;

		[SerializeField]
		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x18")]
		private string[] mTestDevices;

		[SerializeField]
		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x20")]
		private AdId mDefaultBannerId;

		[SerializeField]
		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x28")]
		private AdId mDefaultInterstitialAdId;

		[SerializeField]
		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x30")]
		private AdId mDefaultRewardedAdId;

		[SerializeField]
		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x38")]
		private Dictionary_AdPlacement_AdId mCustomBannerIds;

		[SerializeField]
		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x40")]
		private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;

		[SerializeField]
		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x48")]
		private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;

		[Token(Token = "0x170000D0")]
		public FBAudienceBannerAdSize BannerAdSize
		{
			[Token(Token = "0x60002F5")]
			[Address(RVA = "0xA4E9C8", Offset = "0xA4E9C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mBannerAdSize;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BannerAdSize;
			}
			[Token(Token = "0x60002F6")]
			[Address(RVA = "0xA4E9D0", Offset = "0xA4E9D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mBannerAdSize = value;\n\treturn;\n")]
			set
			{
				BannerAdSize = value;
			}
		}

		[Token(Token = "0x170000D1")]
		public bool EnableTestMode
		{
			[Token(Token = "0x60002F7")]
			[Address(RVA = "0xA4E9D8", Offset = "0xA4E9D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableTestMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableTestMode;
			}
			[Token(Token = "0x60002F8")]
			[Address(RVA = "0xA4E9E0", Offset = "0xA4E9E0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableTestMode = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableTestMode = value;
			}
		}

		[Token(Token = "0x170000D2")]
		public string[] TestDevices
		{
			[Token(Token = "0x60002F9")]
			[Address(RVA = "0xA4E9EC", Offset = "0xA4E9EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mTestDevices;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TestDevices;
			}
			[Token(Token = "0x60002FA")]
			[Address(RVA = "0xA4E9F4", Offset = "0xA4E9F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mTestDevices = value;\n\treturn;\n")]
			set
			{
				TestDevices = value;
			}
		}

		[Token(Token = "0x170000D3")]
		public AdId DefaultBannerId
		{
			[Token(Token = "0x60002FB")]
			[Address(RVA = "0xA4E9FC", Offset = "0xA4E9FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultBannerId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultBannerId;
			}
			[Token(Token = "0x60002FC")]
			[Address(RVA = "0xA4EA04", Offset = "0xA4EA04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultBannerId = value;\n\treturn;\n")]
			set
			{
				DefaultBannerId = value;
			}
		}

		[Token(Token = "0x170000D4")]
		public AdId DefaultInterstitialAdId
		{
			[Token(Token = "0x60002FD")]
			[Address(RVA = "0xA4EA0C", Offset = "0xA4EA0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultInterstitialAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultInterstitialAdId;
			}
			[Token(Token = "0x60002FE")]
			[Address(RVA = "0xA4EA14", Offset = "0xA4EA14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultInterstitialAdId = value;\n\treturn;\n")]
			set
			{
				DefaultInterstitialAdId = value;
			}
		}

		[Token(Token = "0x170000D5")]
		public AdId DefaultRewardedAdId
		{
			[Token(Token = "0x60002FF")]
			[Address(RVA = "0xA4EA1C", Offset = "0xA4EA1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRewardedAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRewardedAdId;
			}
			[Token(Token = "0x6000300")]
			[Address(RVA = "0xA4EA24", Offset = "0xA4EA24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRewardedAdId = value;\n\treturn;\n")]
			set
			{
				DefaultRewardedAdId = value;
			}
		}

		[Token(Token = "0x170000D6")]
		public Dictionary<AdPlacement, AdId> CustomBannerIds
		{
			[Token(Token = "0x6000301")]
			[Address(RVA = "0xA4EA2C", Offset = "0xA4EA2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomBannerIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomBannerIds;
			}
			[Token(Token = "0x6000302")]
			[Address(RVA = "0xA4EA34", Offset = "0xA4EA34", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED1ED8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F46]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomBannerIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x170000D7")]
		public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
		{
			[Token(Token = "0x6000303")]
			[Address(RVA = "0xA4EAC4", Offset = "0xA4EAC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomInterstitialAdIds;
			}
			[Token(Token = "0x6000304")]
			[Address(RVA = "0xA4EACC", Offset = "0xA4EACC", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F06048]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F47]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomInterstitialAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x170000D8")]
		public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
		{
			[Token(Token = "0x6000305")]
			[Address(RVA = "0xA4EB5C", Offset = "0xA4EB5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomRewardedAdIds;
			}
			[Token(Token = "0x6000306")]
			[Address(RVA = "0xA4EB64", Offset = "0xA4EB64", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF3178]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F48]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomRewardedAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000307")]
		[Address(RVA = "0xA4EBF4", Offset = "0xA4EBF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AudienceNetworkSettings()
		{
		}
	}
}
