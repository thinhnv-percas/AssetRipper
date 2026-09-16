using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000011")]
public class Inventory
{
	[Token(Token = "0x4000037")]
	[FieldOffset(Offset = "0x10")]
	public List<ItemResources> resources;

	[Token(Token = "0x600006B")]
	[Address(RVA = "0xBFA000", Offset = "0xBFA000", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = System.Collections.Generic.List`1<ItemResources>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A355D4]) = v42;\nL_001A:\n\tv44 = new System.Collections.Generic.List`1<ItemResources>();\n\tSystem.Collections.Generic.List`1<ItemResources>::.ctor(v44);\n\tthis.resources = v44;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Inventory()
	{
		List<ItemResources> list = new List<ItemResources>();
		resources = list;
	}
}
