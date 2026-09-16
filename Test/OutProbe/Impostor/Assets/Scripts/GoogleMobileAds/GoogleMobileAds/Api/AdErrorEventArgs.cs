using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000038")]
	public class AdErrorEventArgs : EventArgs
	{
		[Token(Token = "0x17000016")]
		public string Message
		{
			[CompilerGenerated]
			[Token(Token = "0x60002AB")]
			[Address(RVA = "0x13574BC", Offset = "0x13574BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Message>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Message;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0x13574C4", Offset = "0x13574C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Message>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Message = value;
			}
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0x1342FC8", Offset = "0x1342FC8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.EventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368E5]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tSystem.EventArgs::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdErrorEventArgs()
		{
		}
	}
}
