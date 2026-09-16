using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000007")]
	public class IAPSecurityException : Exception
	{
		[Token(Token = "0x6000038")]
		[Address(RVA = "0x15D4EDC", Offset = "0x15D4EDC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F01DF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A29]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tSystem.Exception::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPSecurityException()
		{
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x15D4B90", Offset = "0x15D4B90", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA9B20]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A2A]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tSystem.Exception::.ctor(this, message);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPSecurityException(string message)
			: base(message)
		{
		}
	}
}
