using System;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[CreateAssetMenu]
	[Token(Token = "0x2000028")]
	public class GlobalVariableInt : BaseGlobalVariable<int>
	{
		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x15F7F0C", Offset = "0x15F7F0C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC85A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, serializedData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A061]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, serializedData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv53 = System.Globalization.CultureInfo::get_InvariantCulture();\n\treturnVal1 = System.Int32::Parse(serializedData, v53);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override int Load(string serializedData)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			return int.Parse(serializedData, invariantCulture);
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x15F7F80", Offset = "0x15F7F80", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED3730]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A062]) = v38;\nL_0015:\n\tv41 = this + 0x20;\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = System.Globalization.CultureInfo::get_InvariantCulture();\n\treturnVal1 = 0xDC35C4(v41, v54, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string Save()
		{
			//IL_0033: Expected O, but got I
			object obj = (long)(IntPtr)this + 32L;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC35C4 (inside System.InvalidCastException::.ctor +0x2EC)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x15F7FF8", Offset = "0x15F7FF8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA7FA8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A063]) = v38;\nL_001C:\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalVariableInt()
		{
		}
	}
}
