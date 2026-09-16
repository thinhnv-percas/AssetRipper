using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000093")]
	public class RatingRequestSettings
	{
		[SerializeField]
		[Token(Token = "0x400036D")]
		[FieldOffset(Offset = "0x10")]
		private RatingDialogContent mDefaultRatingDialogContent;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x733824", Offset = "0x733824")]
		[Token(Token = "0x400036E")]
		[FieldOffset(Offset = "0x18")]
		private uint mMinimumAcceptedStars;

		[SerializeField]
		[Token(Token = "0x400036F")]
		[FieldOffset(Offset = "0x20")]
		private string mSupportEmail;

		[SerializeField]
		[Token(Token = "0x4000370")]
		[FieldOffset(Offset = "0x28")]
		private string mIosAppId;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x733884", Offset = "0x733884")]
		[Token(Token = "0x4000371")]
		[FieldOffset(Offset = "0x30")]
		private uint mAnnualCap;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7338C8", Offset = "0x7338C8")]
		[Token(Token = "0x4000372")]
		[FieldOffset(Offset = "0x34")]
		private uint mDelayAfterInstallation;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x73390C", Offset = "0x73390C")]
		[Token(Token = "0x4000373")]
		[FieldOffset(Offset = "0x38")]
		private uint mCoolingOffPeriod;

		[SerializeField]
		[Token(Token = "0x4000374")]
		[FieldOffset(Offset = "0x3C")]
		private bool mIgnoreContraintsInDevelopment;

		[Token(Token = "0x170001BD")]
		public RatingDialogContent DefaultRatingDialogContent
		{
			[Token(Token = "0x600061E")]
			[Address(RVA = "0xFD2A88", Offset = "0xFD2A88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRatingDialogContent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRatingDialogContent;
			}
			[Token(Token = "0x600061F")]
			[Address(RVA = "0xFD2A90", Offset = "0xFD2A90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRatingDialogContent = value;\n\treturn;\n")]
			set
			{
				DefaultRatingDialogContent = value;
			}
		}

		[Token(Token = "0x170001BE")]
		public uint MinimumAcceptedStars
		{
			[Token(Token = "0x6000620")]
			[Address(RVA = "0xFD2A98", Offset = "0xFD2A98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMinimumAcceptedStars;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinimumAcceptedStars;
			}
			[Token(Token = "0x6000621")]
			[Address(RVA = "0xFD2AA0", Offset = "0xFD2AA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mMinimumAcceptedStars = value;\n\treturn;\n")]
			set
			{
				MinimumAcceptedStars = value;
			}
		}

		[Token(Token = "0x170001BF")]
		public string SupportEmail
		{
			[Token(Token = "0x6000622")]
			[Address(RVA = "0xFD2AA8", Offset = "0xFD2AA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mSupportEmail;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SupportEmail;
			}
			[Token(Token = "0x6000623")]
			[Address(RVA = "0xFD2AB0", Offset = "0xFD2AB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mSupportEmail = value;\n\treturn;\n")]
			set
			{
				SupportEmail = value;
			}
		}

		[Token(Token = "0x170001C0")]
		public string IosAppId
		{
			[Token(Token = "0x6000624")]
			[Address(RVA = "0xFD2AB8", Offset = "0xFD2AB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIosAppId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IosAppId;
			}
			[Token(Token = "0x6000625")]
			[Address(RVA = "0xFD2AC0", Offset = "0xFD2AC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mIosAppId = value;\n\treturn;\n")]
			set
			{
				IosAppId = value;
			}
		}

		[Token(Token = "0x170001C1")]
		public uint AnnualCap
		{
			[Token(Token = "0x6000626")]
			[Address(RVA = "0xFD2AC8", Offset = "0xFD2AC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAnnualCap;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnnualCap;
			}
			[Token(Token = "0x6000627")]
			[Address(RVA = "0xFD2AD0", Offset = "0xFD2AD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAnnualCap = value;\n\treturn;\n")]
			set
			{
				AnnualCap = value;
			}
		}

		[Token(Token = "0x170001C2")]
		public uint DelayAfterInstallation
		{
			[Token(Token = "0x6000628")]
			[Address(RVA = "0xFD2AD8", Offset = "0xFD2AD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDelayAfterInstallation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DelayAfterInstallation;
			}
			[Token(Token = "0x6000629")]
			[Address(RVA = "0xFD2AE0", Offset = "0xFD2AE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDelayAfterInstallation = value;\n\treturn;\n")]
			set
			{
				DelayAfterInstallation = value;
			}
		}

		[Token(Token = "0x170001C3")]
		public uint CoolingOffPeriod
		{
			[Token(Token = "0x600062A")]
			[Address(RVA = "0xFD2AE8", Offset = "0xFD2AE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCoolingOffPeriod;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CoolingOffPeriod;
			}
			[Token(Token = "0x600062B")]
			[Address(RVA = "0xFD2AF0", Offset = "0xFD2AF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mCoolingOffPeriod = value;\n\treturn;\n")]
			set
			{
				CoolingOffPeriod = value;
			}
		}

		[Token(Token = "0x170001C4")]
		public bool IgnoreConstraintsInDevelopment
		{
			[Token(Token = "0x600062C")]
			[Address(RVA = "0xFD2AF8", Offset = "0xFD2AF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIgnoreContraintsInDevelopment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IgnoreConstraintsInDevelopment;
			}
			[Token(Token = "0x600062D")]
			[Address(RVA = "0xFD2B00", Offset = "0xFD2B00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mIgnoreContraintsInDevelopment = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mIgnoreContraintsInDevelopment = value;
			}
		}

		[Token(Token = "0x600062E")]
		[Address(RVA = "0xFD2B0C", Offset = "0xFD2B0C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDBCF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256AD]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.RatingDialogContent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.RatingDialogContent;\nL_0025:\n\tthis.mMinimumAcceptedStars = 4;\n\tthis.mAnnualCap = 0xC;\n\tthis.mDelayAfterInstallation = 0xA;\n\tthis.mCoolingOffPeriod = 0xA;\n\tthis.mDefaultRatingDialogContent = v52.Default;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RatingRequestSettings()
		{
			MinimumAcceptedStars = 4u;
			AnnualCap = 12u;
			DelayAfterInstallation = 10u;
			CoolingOffPeriod = 10u;
			DefaultRatingDialogContent = RatingDialogContent.Default;
		}
	}
}
