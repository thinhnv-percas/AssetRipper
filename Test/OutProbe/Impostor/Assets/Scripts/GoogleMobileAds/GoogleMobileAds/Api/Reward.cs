using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000048")]
	public class Reward : EventArgs
	{
		[Token(Token = "0x1700003C")]
		public string Type
		{
			[CompilerGenerated]
			[Token(Token = "0x6000311")]
			[Address(RVA = "0x13584E4", Offset = "0x13584E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Type>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000312")]
			[Address(RVA = "0x13584EC", Offset = "0x13584EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Type>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Type = value;
			}
		}

		[Token(Token = "0x1700003D")]
		public double Amount
		{
			[CompilerGenerated]
			[Token(Token = "0x6000313")]
			[Address(RVA = "0x13584F4", Offset = "0x13584F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Amount>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Amount;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000314")]
			[Address(RVA = "0x13584FC", Offset = "0x13584FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Amount>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Amount = value;
			}
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0x1342DE4", Offset = "0x1342DE4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.EventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36901]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tSystem.EventArgs::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Reward()
		{
		}
	}
}
