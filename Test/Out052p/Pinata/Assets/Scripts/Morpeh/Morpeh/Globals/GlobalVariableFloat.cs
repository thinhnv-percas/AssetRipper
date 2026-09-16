using System;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[CreateAssetMenu]
	[Token(Token = "0x2000027")]
	public class GlobalVariableFloat : BaseGlobalVariable<float>
	{
		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x15F7DD0", Offset = "0x15F7DD0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE7A00]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, serializedData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A05E]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, serializedData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv53 = System.Globalization.CultureInfo::get_InvariantCulture();\n\treturnVal1 = System.Single::Parse(serializedData, v53);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override float Load(string serializedData)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			return float.Parse(serializedData, invariantCulture);
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x15F7E44", Offset = "0x15F7E44", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBFED8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A05F]) = v38;\nL_0015:\n\tv41 = this + 0x20;\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = System.Globalization.CultureInfo::get_InvariantCulture();\n\treturnVal1 = 0xBCCEFC(v41, v54, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string Save()
		{
			//IL_002e: Expected O, but got I
			object obj = (long)(IntPtr)this + 32L;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEFC (inside System.Single::IsNaN +0x2E4)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x15F7EBC", Offset = "0x15F7EBC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED5208]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A060]) = v38;\nL_001C:\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Single>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalVariableFloat()
		{
		}
	}
}
