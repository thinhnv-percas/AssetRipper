using System;
using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200004B")]
	public class DebugUtils
	{
		[AttributeAttribute(Type = typeof(ConditionalAttribute), RVA = "0x740474", Offset = "0x740474")]
		[Token(Token = "0x6000157")]
		[Address(RVA = "0x9D7900", Offset = "0x9D7900", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECFFA0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A15]) = v38;\nL_0014:\n\tv40 = condition == 0;\n\tif (v40) goto L_001F;\n\treturn;\nL_001F:\n\tv48 = new System.Exception();\n\tSystem.Exception::.ctor(v48);\n\tthrow v48;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Assert(bool condition)
		{
			if (condition)
			{
				return;
			}
			Exception ex = new Exception();
			throw ex;
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0x9D7978", Offset = "0x9D7978", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugUtils()
		{
		}
	}
}
