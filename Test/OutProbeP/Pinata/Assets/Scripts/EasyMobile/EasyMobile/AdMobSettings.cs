using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000032")]
	public class AdMobSettings
	{
		[Serializable]
		[Token(Token = "0x200010F")]
		public class AdMobTargetingSettings
		{
			[SerializeField]
			[Token(Token = "0x400048C")]
			[FieldOffset(Offset = "0x10")]
			private AdChildDirectedTreatment mTagForChildDirectedTreatment;

			[SerializeField]
			[Token(Token = "0x400048D")]
			[FieldOffset(Offset = "0x18")]
			private StringStringSerializableDictionary mExtraOptions;

			[Token(Token = "0x17000256")]
			public AdChildDirectedTreatment TagForChildDirectedTreatment
			{
				[Token(Token = "0x6000946")]
				[Address(RVA = "0xA461F0", Offset = "0xA461F0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mTagForChildDirectedTreatment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return TagForChildDirectedTreatment;
				}
				[Token(Token = "0x6000947")]
				[Address(RVA = "0xA461F8", Offset = "0xA461F8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mTagForChildDirectedTreatment = value;\n\treturn;\n")]
				set
				{
					TagForChildDirectedTreatment = value;
				}
			}

			[Token(Token = "0x17000257")]
			public Dictionary<string, string> ExtraOptions
			{
				[Token(Token = "0x6000948")]
				[Address(RVA = "0xA46200", Offset = "0xA46200", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mExtraOptions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return mExtraOptions;
				}
				[Token(Token = "0x6000949")]
				[Address(RVA = "0xA46208", Offset = "0xA46208", Length = "0x90")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDE4D8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EC0]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mExtraOptions = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					mExtraOptions = (StringStringSerializableDictionary)dictionary;
				}
			}

			[Token(Token = "0x600094A")]
			[Address(RVA = "0xA46298", Offset = "0xA46298", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AdMobTargetingSettings()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x10")]
		private AdMobTargetingSettings mTargetingSettings;

		[SerializeField]
		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x18")]
		private bool mEnableTestMode;

		[SerializeField]
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x20")]
		private AdId mAppId;

		[SerializeField]
		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x28")]
		private AdId mDefaultBannerAdId;

		[SerializeField]
		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x30")]
		private AdId mDefaultInterstitialAdId;

		[SerializeField]
		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x38")]
		private AdId mDefaultRewardedAdId;

		[SerializeField]
		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x40")]
		private Dictionary_AdPlacement_AdId mCustomBannerAdIds;

		[SerializeField]
		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x48")]
		private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;

		[SerializeField]
		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x50")]
		private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;

		[Token(Token = "0x170000BE")]
		public AdId AppId
		{
			[Token(Token = "0x60002CF")]
			[Address(RVA = "0xA45FBC", Offset = "0xA45FBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAppId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppId;
			}
			[Token(Token = "0x60002D0")]
			[Address(RVA = "0xA45FC4", Offset = "0xA45FC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAppId = value;\n\treturn;\n")]
			set
			{
				AppId = value;
			}
		}

		[Token(Token = "0x170000BF")]
		public AdId DefaultBannerAdId
		{
			[Token(Token = "0x60002D1")]
			[Address(RVA = "0xA45FCC", Offset = "0xA45FCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultBannerAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultBannerAdId;
			}
			[Token(Token = "0x60002D2")]
			[Address(RVA = "0xA45FD4", Offset = "0xA45FD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultBannerAdId = value;\n\treturn;\n")]
			set
			{
				DefaultBannerAdId = value;
			}
		}

		[Token(Token = "0x170000C0")]
		public AdId DefaultInterstitialAdId
		{
			[Token(Token = "0x60002D3")]
			[Address(RVA = "0xA45FDC", Offset = "0xA45FDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultInterstitialAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultInterstitialAdId;
			}
			[Token(Token = "0x60002D4")]
			[Address(RVA = "0xA45FE4", Offset = "0xA45FE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultInterstitialAdId = value;\n\treturn;\n")]
			set
			{
				DefaultInterstitialAdId = value;
			}
		}

		[Token(Token = "0x170000C1")]
		public AdId DefaultRewardedAdId
		{
			[Token(Token = "0x60002D5")]
			[Address(RVA = "0xA45FEC", Offset = "0xA45FEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRewardedAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRewardedAdId;
			}
			[Token(Token = "0x60002D6")]
			[Address(RVA = "0xA45FF4", Offset = "0xA45FF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRewardedAdId = value;\n\treturn;\n")]
			set
			{
				DefaultRewardedAdId = value;
			}
		}

		[Token(Token = "0x170000C2")]
		public bool EnableTestMode
		{
			[Token(Token = "0x60002D7")]
			[Address(RVA = "0xA45FFC", Offset = "0xA45FFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableTestMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableTestMode;
			}
			[Token(Token = "0x60002D8")]
			[Address(RVA = "0xA46004", Offset = "0xA46004", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableTestMode = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableTestMode = value;
			}
		}

		[Token(Token = "0x170000C3")]
		public AdMobTargetingSettings TargetingSettings
		{
			[Token(Token = "0x60002D9")]
			[Address(RVA = "0xA46010", Offset = "0xA46010", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mTargetingSettings;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TargetingSettings;
			}
			[Token(Token = "0x60002DA")]
			[Address(RVA = "0xA46018", Offset = "0xA46018", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mTargetingSettings = value;\n\treturn;\n")]
			set
			{
				TargetingSettings = value;
			}
		}

		[Token(Token = "0x170000C4")]
		public Dictionary<AdPlacement, AdId> CustomBannerAdIds
		{
			[Token(Token = "0x60002DB")]
			[Address(RVA = "0xA46020", Offset = "0xA46020", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomBannerAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomBannerAdIds;
			}
			[Token(Token = "0x60002DC")]
			[Address(RVA = "0xA46028", Offset = "0xA46028", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC6880]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EBD]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomBannerAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x170000C5")]
		public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
		{
			[Token(Token = "0x60002DD")]
			[Address(RVA = "0xA460B8", Offset = "0xA460B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomInterstitialAdIds;
			}
			[Token(Token = "0x60002DE")]
			[Address(RVA = "0xA460C0", Offset = "0xA460C0", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECE0F0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EBE]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomInterstitialAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x170000C6")]
		public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
		{
			[Token(Token = "0x60002DF")]
			[Address(RVA = "0xA46150", Offset = "0xA46150", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomRewardedAdIds;
			}
			[Token(Token = "0x60002E0")]
			[Address(RVA = "0xA46158", Offset = "0xA46158", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED4AD0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EBF]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomRewardedAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0xA461E8", Offset = "0xA461E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdMobSettings()
		{
		}
	}
}
