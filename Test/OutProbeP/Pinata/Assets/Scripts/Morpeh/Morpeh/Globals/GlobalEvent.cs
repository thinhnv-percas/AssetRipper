using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[CreateAssetMenu]
	[Token(Token = "0x2000020")]
	public class GlobalEvent : GlobalEventInt
	{
		[Attribute(Type = typeof(ContextMenu), RVA = "0x73DE50", Offset = "0x73DE50")]
		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x15F797C", Offset = "0x15F797C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EE4E28]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A053]) = v38;\nL_001D:\n\tMorpeh.Globals.BaseGlobalEvent`1<System.Int32>::Publish(this, 0xFFFFFFFF);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Publish()
		{
			Publish(-1);
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x15F79D0", Offset = "0x15F79D0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EDABB8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A054]) = v38;\nL_001D:\n\tMorpeh.Globals.BaseGlobalEvent`1<System.Int32>::NextFrame(this, 0xFFFFFFFF);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void NextFrame()
		{
			NextFrame(-1);
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x15F7A24", Offset = "0x15F7A24", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEventInt::.ctor(this);\n\treturn;\n")]
		public GlobalEvent()
		{
		}
	}
}
