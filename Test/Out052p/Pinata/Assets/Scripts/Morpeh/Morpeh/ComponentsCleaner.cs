using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh
{
	[Attribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D554", Offset = "0x73D554")]
	[Attribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D554", Offset = "0x73D554")]
	[Attribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D554", Offset = "0x73D554")]
	[Token(Token = "0x2000013")]
	internal static class ComponentsCleaner
	{
		[Token(Token = "0x200003F")]
		internal delegate bool RemoveDelegate(in int id);

		[Token(Token = "0x4000033")]
		private static readonly Dictionary<int, RemoveDelegate> Cleaners;

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x15F5634", Offset = "0x15F5634", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC2248]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A03C]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Dictionary`2<System.Int32, Morpeh.ComponentsCleaner+RemoveDelegate>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, Morpeh.ComponentsCleaner+RemoveDelegate>::.ctor(v39);\n\tv47.Cleaners = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ComponentsCleaner()
		{
			Dictionary<int, RemoveDelegate> cleaners = new Dictionary<int, RemoveDelegate>();
			Cleaners = cleaners;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x15F56A8", Offset = "0x15F56A8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECD6D0]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, func, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A03D]) = v41;\nL_001B:\n\tgoto L_0028;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Morpeh.ComponentsCleaner>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0028;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v44, func, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Morpeh.ComponentsCleaner;\nL_0028:\n\tv61 = System.Collections.Generic.Dictionary`2<System.Int32, Morpeh.ComponentsCleaner+RemoveDelegate>::ContainsKey(v56.Cleaners, *([typeId @ X0 (System.Int32&)]));\n\tv64 = v61 == 0;\n\tif (v64) goto L_0032;\n\tgoto L_0048;\nL_0032:\n\tgoto L_0040;\n\tv89 = *([v66 @ X0_v7 (Il2CppClass<Morpeh.ComponentsCleaner>)+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0040;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v66, v57, v60, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv93 = Morpeh.ComponentsCleaner;\nL_0040:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, Morpeh.ComponentsCleaner+RemoveDelegate>::Add(v83.Cleaners, *([typeId @ X0 (System.Int32&)]), func);\nL_0048:\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Register(in int typeId, RemoveDelegate func)
		{
			if (Cleaners.ContainsKey(typeId))
			{
				return false;
			}
			Cleaners.Add(typeId, func);
			return true;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x15F5780", Offset = "0x15F5780", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EAE958]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, id, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([202A03E]) = v39;\nL_001B:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Morpeh.ComponentsCleaner>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v43, id, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = Morpeh.ComponentsCleaner;\nL_0029:\n\tv62 = System.Collections.Generic.Dictionary`2<System.Int32, Morpeh.ComponentsCleaner+RemoveDelegate>::TryGetValue(v55.Cleaners, typeId, &v58 @ stack_-30_v2 (Morpeh.ComponentsCleaner+RemoveDelegate));\n\tv65 = v62 == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tv68 = Morpeh.ComponentsCleaner+RemoveDelegate::Invoke(v58, &id @ X1 (System.Int32));\n\tgoto L_0038;\nL_0038:\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Clean(int typeId, int id)
		{
			if (Cleaners.TryGetValue(typeId, out var value))
			{
				int id2 = default(int);
				bool flag = value(in id2);
				return true;
			}
			return false;
		}
	}
}
