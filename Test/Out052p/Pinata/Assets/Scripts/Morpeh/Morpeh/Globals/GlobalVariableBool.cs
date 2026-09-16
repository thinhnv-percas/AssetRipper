using System;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[CreateAssetMenu]
	[Token(Token = "0x2000026")]
	public class GlobalVariableBool : BaseGlobalVariable<bool>
	{
		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x15F7CA0", Offset = "0x15F7CA0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFF290]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, serializedData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A05B]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, serializedData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\treturnVal1 = System.Boolean::Parse(serializedData);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool Load(string serializedData)
		{
			return bool.Parse(serializedData);
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x15F7D08", Offset = "0x15F7D08", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F08A68]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A05C]) = v38;\nL_0015:\n\tv41 = this + 0x20;\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = System.Globalization.CultureInfo::get_InvariantCulture();\n\treturnVal1 = 0xE8F1AC(v41, v54, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string Save()
		{
			//IL_002e: Expected O, but got I
			object obj = (long)(IntPtr)this + 32L;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E8F1AC (inside System.BitConverter::.cctor +0xC4)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x15F7D80", Offset = "0x15F7D80", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE00C8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A05D]) = v38;\nL_001C:\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Boolean>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalVariableBool()
		{
		}
	}
}
