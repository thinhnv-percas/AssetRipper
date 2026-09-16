using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals.ECS
{
	[Token(Token = "0x2000031")]
	internal static class InitializerECS
	{
		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x15F773C", Offset = "0x15F773C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EA8948]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A051]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1EDD170]);\n\tv57 = *([v56 @ X8_v15]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([2021C3B]) = v61;\nL_002D:\n\tgoto L_0039;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<Morpeh.World>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0039;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v62, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = Morpeh.World;\nL_0039:\n\tv78 = new Morpeh.Globals.ECS.ProcessEventsSystem();\n\tSystem.Object::.ctor(v78);\n\tv93 = Morpeh.World::AddSystem(v74.<Default>k__BackingField, 0x270F, v78);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Initialize()
		{
			ProcessEventsSystem system = new ProcessEventsSystem();
			bool flag = World.Default.AddSystem(9999, system);
		}
	}
}
