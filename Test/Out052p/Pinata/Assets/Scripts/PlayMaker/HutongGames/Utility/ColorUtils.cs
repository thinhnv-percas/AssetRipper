using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.Utility
{
	[Token(Token = "0x2000083")]
	public static class ColorUtils
	{
		[Token(Token = "0x6000679")]
		[Address(RVA = "0xE53C10", Offset = "0xE53C10", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv46 = *([1EA8CD8]);\n\tv47 = *([v46 @ X8_v18]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, v49, v50, v51, v52, v53, v54, v55, color1, v0, v2, v3, color2, v4, v6, v7);\n\tv59 = 0 | 1;\n\t*([20247C8]) = v59;\nL_002D:\n\tgoto L_0036;\n\tv66 = *([v62 @ X0_v2+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0036;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, v49, v50, v51, v52, v53, v54, v55, color1, v0, v2, v3, color2, v4, v6, v7);\nL_0036:\n\tv76 = UnityEngine.Mathf::Approximately(color1, color2);\n\tv78 = v76 == 0;\n\tif (v78) goto L_0084;\n\tgoto L_0047;\n\tv110 = *([v79 @ X0_v8+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0047;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v79, v49, v50, v51, v52, v53, v54, v55, v73, v74, v2, v3, color2, v4, v6, v7);\nL_0047:\n\tv87 = UnityEngine.Mathf::Approximately(color1.g, color2.g);\n\tv90 = v87 == 0;\n\tif (v90) goto L_0084;\n\tgoto L_0058;\n\tv154 = *([v150 @ X0_v12+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0058;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v150, v49, v50, v51, v52, v53, v54, v55, v84, v96, v2, v3, color2, v4, v6, v7);\nL_0058:\n\tv88 = UnityEngine.Mathf::Approximately(color1.b, color2.b);\n\tv91 = v88 == 0;\n\tif (v91) goto L_0084;\n\tgoto L_0075;\n\tv166 = *([v162 @ X0_v16+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0075;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v162, v49, v50, v51, v52, v53, v54, v55, v85, v97, v2, v3, color2, v4, v6, v7);\nL_0075:\n\treturnVal2 = UnityEngine.Mathf::Approximately(color1.a, color2.a);\n\treturn returnVal2;\nL_0084:\n\treturn 0;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Approximately(Color color1, Color color2)
		{
			Color color3 = default(Color);
			Color color4 = default(Color);
			if (Mathf.Approximately(color3.r, color4.r) && Mathf.Approximately(color1.g, color2.g) && Mathf.Approximately(color1.b, color2.b))
			{
				return Mathf.Approximately(color1.a, color2.a);
			}
			return false;
		}

		[Token(Token = "0x600067A")]
		[Address(RVA = "0xE53D5C", Offset = "0xE53D5C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = r / 255f;\n\tv17 = g / 255f;\n\tv18 = b / 255f;\n\tv19 = a / 255f;\n\tv21 = 0;\n\tv24 = 0x101059C(&v21 @ stack_-20_v1 (UnityEngine.Color), 0, b, a, methodInfo, v26, v27, v28, v16, v17, v18, v19, a, v29, v30, v31);\n\treturn 0;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color FromIntRGBA(int r, int g, int b, int a)
		{
			float num = (float)r / 255f;
			float num2 = (float)g / 255f;
			float num3 = (float)b / 255f;
			float num4 = (float)a / 255f;
			Color color = default(Color);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}
	}
}
