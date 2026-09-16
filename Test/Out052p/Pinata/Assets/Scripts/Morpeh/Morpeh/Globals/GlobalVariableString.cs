using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[CreateAssetMenu]
	[Token(Token = "0x2000029")]
	public class GlobalVariableString : BaseGlobalVariable<string>
	{
		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x15F8048", Offset = "0x15F8048", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn serializedData;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string Load(string serializedData)
		{
			return serializedData;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x15F8050", Offset = "0x15F8050", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string Save()
		{
			return value;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x15F8058", Offset = "0x15F8058", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBFE20]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A064]) = v38;\nL_001C:\n\tMorpeh.Globals.BaseGlobalVariable`1<System.String>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalVariableString()
		{
		}
	}
}
