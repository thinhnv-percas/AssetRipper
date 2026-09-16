using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Default
{
	[Token(Token = "0x2000002")]
	public class Factory
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x167FF84", Offset = "0x167FF84", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EC9C90]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B599]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IWindowsIAP Create(bool mocked)
		{
			NotImplementedException ex = new NotImplementedException();
			return (IWindowsIAP)new TypeLoadException();
		}
	}
}
