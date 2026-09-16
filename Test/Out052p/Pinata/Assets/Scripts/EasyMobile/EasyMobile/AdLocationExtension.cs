using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Obsolete]
	[Token(Token = "0x2000016")]
	public static class AdLocationExtension
	{
		[Token(Token = "0x600007C")]
		[Address(RVA = "0xA45C14", Offset = "0xA45C14", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE3F20]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EB9]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdLocation>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdLocation;\nL_0026:\n\tv58 = v52.Default == location;\n\tif (v58) goto L_004F;\n\tv75 = EasyMobile.AdLocation::ToString(location);\n\tgoto L_0047;\n\tv98 = *([v79 @ X8_v14+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0047;\n\tv122 = v79;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v122, v74, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\treturnVal3 = EasyMobile.AdPlacement::PlacementWithName(v75);\n\treturn returnVal3;\nL_004F:\n\tgoto L_005D;\n\tv85 = *([v67 @ X0_v4 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_005D;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv89 = EasyMobile.AdPlacement;\nL_005D:\n\treturn v92.Default;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdPlacement ToAdPlacement(this AdLocation location)
		{
			if (AdLocation.Default != location)
			{
				string name = location.ToString();
				return AdPlacement.PlacementWithName(name);
			}
			return AdPlacement.Default;
		}
	}
}
