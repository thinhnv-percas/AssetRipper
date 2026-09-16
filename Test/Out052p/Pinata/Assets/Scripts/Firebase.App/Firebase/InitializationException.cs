using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x2000015")]
	public sealed class InitializationException : Exception
	{
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x73B5E0", Offset = "0x73B5E0")]
		[CompilerGenerated]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x88")]
		private InitResult _003CInitResult_003Ek__BackingField;

		[Token(Token = "0x17000016")]
		private InitResult InitResult
		{
			[CompilerGenerated]
			[Token(Token = "0x6000091")]
			[Address(RVA = "0x1600EC8", Offset = "0x1600EC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<InitResult>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CInitResult_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x15FE780", Offset = "0x15FE780", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F0B000]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, result, message, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1A0]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, result, message, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tSystem.Exception::.ctor(this, message);\n\tthis.<InitResult>k__BackingField = result;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InitializationException(InitResult result, string message)
			: base(message)
		{
			_003CInitResult_003Ek__BackingField = result;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x16004B8", Offset = "0x16004B8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1F07960]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, result, message, inner, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202A1A1]) = v47;\nL_001F:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, result, message, inner, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0029:\n\tSystem.Exception::.ctor(this, message, inner);\n\tthis.<InitResult>k__BackingField = result;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InitializationException(InitResult result, string message, Exception inner)
			: base(message, inner)
		{
			_003CInitResult_003Ek__BackingField = result;
		}
	}
}
