using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.ManifestGenerator.Elements
{
	[Token(Token = "0x200009D")]
	public static class AndroidManifestElementStyleExtension
	{
		[Token(Token = "0x6000681")]
		[Address(RVA = "0xB584C0", Offset = "0xB584C0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED9FA0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022805]) = v38;\nL_0013:\n\tv39 = elementStyle - 1;\n\tv40 = v39 < 0x19;\n\tv41 = ~v40;\n\tv42 = v39 - 0x19;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_FFFFFFFF;\n\tv52 = 0x1E9D000 + 0x800;\n\tv58 = *([v52 @ X9_v3 (System.Int32)+v39 @ X8_v3 (System.Int32)*8]);\n\tgoto L_002C;\nL_002C:\n\treturn *([v58 @ X8_v4 (System.String)]);\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToAndroidManifestFormat(this AndroidManifestElementStyles elementStyle)
		{
			//IL_0024: Expected O, but got I
			int num = (int)(elementStyle - 1);
			bool flag = num < 25;
			bool flag2 = !flag;
			int num2 = num - 25;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 32100352 + 2048;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v3 (System.Int32)+v39 @ X8_v3 (System.Int32)*8]");
				return (string)0;
			}
			return "none";
		}

		[Token(Token = "0x6000682")]
		[Address(RVA = "0xB57AA0", Offset = "0xB57AA0", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED39E8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022806]) = v38;\nL_0013:\n\tv39 = v36 - 1;\n\tv40 = v39 < 0x19;\n\tv41 = ~v40;\n\tv42 = v39 - 0x19;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_002F;\n\tv52 = 0x1819000 + 0x6E0;\n\tv54 = *([v52 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]) + v52;\n\t// 36 IndirectJump v54 @ X8_v5, v36 @ X0_v1 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), v36 @ X0_v1 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = *([1ED9488]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 1;\n\tgoto L_00A2;\nL_002F:\n\tgoto L_00AC;\n\tX8 = *([1EF3478]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 2;\n\tgoto L_00A2;\n\tX8 = *([1EF2E08]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 3;\n\tgoto L_00A2;\n\tX8 = *([1F0E968]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 4;\n\tgoto L_00A2;\n\tX8 = *([1EF7CF8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 5;\n\tgoto L_00A2;\n\tX8 = *([1EB8D18]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 6;\n\tgoto L_00A2;\n\tX8 = *([1EE33D0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 7;\n\tgoto L_00A2;\n\tX8 = *([1F02638]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 8;\n\tgoto L_00A2;\n\tX8 = *([1EA3360]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 9;\n\tgoto L_00A2;\n\tX8 = *([1EAF9C8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.ManifestElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1F00A40]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0xB;\n\tgoto L_00A2;\n\tX8 = *([1EEBB40]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 0xC;\n\tgoto L_00A2;\n\tX8 = *([1EFFD28]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0xD;\n\tgoto L_00A2;\n\tX8 = *([1EDD940]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = 0 | 0xE;\nL_00A2:\n\tX9 = *([X8+180]);\n\tX2 = *([X8+188]);\n\tX0 = X19;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00AC:\n\treturn 0;\n\tX8 = *([1EEF668]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.PermissionTreeElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EFDE00]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.ProviderElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EB8420]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.ReceiverElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EACB50]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.ServiceElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1F0D938]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.SupportsGlTextureElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EA3398]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.SupportsScreensElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EEECB8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.UsesConfigurationElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1ED0EC8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.UsesFeatureElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1ED7540]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.UsesLibraryElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EC6A48]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.UsesPermissionElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EC8548]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.UsesPermissionSdk23Element::.ctor(X0, X1);\n\tgoto L_00AC;\n\tX8 = *([1EE1F00]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tEasyMobile.ManifestGenerator.Elements.UsesSdkElement::.ctor(X0, X1);\n\tgoto L_00AC;\n\treturn X0;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AndroidManifestElement CreateElementClass(this AndroidManifestElementStyles style)
		{
			//IL_0029: Expected O, but got I
			AndroidManifestElementStyles androidManifestElementStyles = default(AndroidManifestElementStyles);
			int num = (int)(androidManifestElementStyles - 1);
			bool flag = num < 25;
			bool flag2 = !flag;
			int num2 = num - 25;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25268224 + 1760;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X8_v5 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x6000683")]
		[Address(RVA = "0xB575FC", Offset = "0xB575FC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1EF0498]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022807]) = v38;\nL_001F:\n\treturnVal1 = System.String::StartsWith(attribute, \"android:\");\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsAndroidAttribute(this string attribute)
		{
			return attribute.StartsWith("android:");
		}
	}
}
