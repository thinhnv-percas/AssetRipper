using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x200004D")]
	public class CustomNativeEventArgs : EventArgs
	{
		[Token(Token = "0x17000042")]
		public CustomNativeTemplateAd nativeAd
		{
			[CompilerGenerated]
			[Token(Token = "0x6000323")]
			[Address(RVA = "0x13585E8", Offset = "0x13585E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<nativeAd>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return nativeAd;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000324")]
			[Address(RVA = "0x13585F0", Offset = "0x13585F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<nativeAd>k__BackingField = value;\n\treturn;\n")]
			set
			{
				nativeAd = value;
			}
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0x13558D8", Offset = "0x13558D8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.EventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36903]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tSystem.EventArgs::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CustomNativeEventArgs()
		{
		}
	}
}
