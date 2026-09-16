using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000042")]
	public class AdValueEventArgs : EventArgs
	{
		[Token(Token = "0x1700002D")]
		public AdValue AdValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60002ED")]
			[Address(RVA = "0x1358124", Offset = "0x1358124", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002EE")]
			[Address(RVA = "0x135812C", Offset = "0x135812C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdValue>k__BackingField = value;\n\treturn;\n")]
			set
			{
				AdValue = value;
			}
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x1346DC0", Offset = "0x1346DC0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.EventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368F7]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tSystem.EventArgs::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdValueEventArgs()
		{
		}
	}
}
