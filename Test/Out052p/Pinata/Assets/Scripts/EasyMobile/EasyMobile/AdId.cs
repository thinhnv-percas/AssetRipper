using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000014")]
	public class AdId : CrossPlatformId
	{
		[Token(Token = "0x17000016")]
		public override string IosId
		{
			[Token(Token = "0x6000074")]
			[Address(RVA = "0xA4558C", Offset = "0xA4558C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ED0AE0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EB4]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\treturnVal1 = EasyMobile.Internal.Util::AutoTrimId(this.mIosId);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Util.AutoTrimId(IosId);
			}
		}

		[Token(Token = "0x17000017")]
		public override string AndroidId
		{
			[Token(Token = "0x6000075")]
			[Address(RVA = "0xA455F8", Offset = "0xA455F8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBB9D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EB5]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\treturnVal1 = EasyMobile.Internal.Util::AutoTrimId(this.mAndroidId);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Util.AutoTrimId(AndroidId);
			}
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0xA45664", Offset = "0xA45664", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mIosId = iOSId;\n\tthis.mAndroidId = androidId;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdId(string iOSId, string androidId)
		{
			mIosId = iOSId;
			mAndroidId = androidId;
		}
	}
}
