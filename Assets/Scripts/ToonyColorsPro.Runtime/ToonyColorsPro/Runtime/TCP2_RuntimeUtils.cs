using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ToonyColorsPro.Runtime
{
	[Token(Token = "0x2000008")]
	public static class TCP2_RuntimeUtils
	{
		[Token(Token = "0x4000041")]
		private const string BASE_SHADER_PATH = "Toony Colors Pro 2/";

		[Token(Token = "0x4000042")]
		private const string VARIANT_SHADER_PATH = "Hidden/Toony Colors Pro 2/Variants/";

		[Token(Token = "0x4000043")]
		private const string BASE_SHADER_NAME = "Desktop";

		[Token(Token = "0x4000044")]
		private const string BASE_SHADER_NAME_MOB = "Mobile";

		[Token(Token = "0x4000045")]
		private static List<string[]> ShaderVariants = new List<string[]>
		{
			new string[2] { "Specular", "TCP2_SPEC" },
			new string[3] { "Reflection", "TCP2_REFLECTION", "TCP2_REFLECTION_MASKED" },
			new string[2] { "Matcap", "TCP2_MC" },
			new string[2] { "Rim", "TCP2_RIM" },
			new string[2] { "RimOutline", "TCP2_RIMO" },
			new string[2] { "Outline", "OUTLINES" },
			new string[2] { "OutlineBlending", "OUTLINE_BLENDING" }
		};

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x819A408", Offset = "0x819A408", Length = "0x40C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv66 = UnityEngine.Material::get_shader(material);\n\tgoto L_004B;\nL_004B:\n\tv198 = UnityEngine.Object::op_Inequality(v66, 0);\n\tv215 = ~v198;\n\tv216 = ~v215;\n\tif (v216) goto L_005B;\nL_FFFFFFFF:\n\tv165 = 0;\n\tgoto L_FFFFFFFF;\nL_005B:\n\tv167 = UnityEngine.Material::get_shader(material);\n\tv173 = v167 == 0;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\tv160 = 0;\n\tif (v173) goto L_0152;\n\tv168 = UnityEngine.Object::get_name(v167);\n\tv174 = v168 == 0;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\tv160 = 0;\n\tif (v174) goto L_0152;\n\tv169 = System.String::ToLower(v168);\n\tv175 = v169 == 0;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\tv160 = 0;\n\tif (v175) goto L_0152;\n\tv255 = System.String::Contains(v169, \"mobile\");\n\tv257 = v255 == 0;\nL_FFFFFFFF:\n\tv165 = \"mobile\";\n\tif (v257) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv150 = \"Mobile\";\nL_FFFFFFFF:\n\tv165 = \"mobile\";\n\tgoto L_0087;\nL_FFFFFFFF:\n\tv150 = \"Desktop\";\n\tgoto L_0087;\n\tv310 = System.Collections.Generic.List`1<System.String[]>::GetEnumerator(v181.ShaderVariants);\n\tv336 = v310.Current;\n\tv123 = v310._list;\nL_FFFFFFFF:\n\tv341 = v150;\n\tgoto L_00AB;\nL_00A7:\n\tv372 = v477.Length >= 1;\n\tif (v372) goto L_0150;\nL_00AB:\n\tv485 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v123 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String[]>));\n\tv347 = v485 == 0;\n\tif (v347) goto L_0117;\n\tv477 = UnityEngine.Material::get_shaderKeywords(material);\n\tv429 = v477 == 0;\n\tif (v429) goto L_014E;\n\tv473 = v477.Length;\n\tv430 = v310.Current == 0;\n\tif (v430) goto L_00A7;\n\tv453 = v477.Length < 1;\n\tif (v453) goto L_00AB;\n\tv432 = v336.Length;\n\tv361 = v310.Current + 0x28;\nL_FFFFFFFF:\n\tv365 = 0;\nL_FFFFFFFF:\n\tv640 = v341;\n\tgoto L_00E3;\nL_00CC:\n\tv473 = v477.Length;\nL_00E3:\n\tv617 = v432 < 2;\n\tif (v617) goto L_00CD;\nL_FFFFFFFF:\n\tv353 = 1;\nL_FFFFFFFF:\n\tv436 = v361;\n\tgoto L_00F9;\nL_FFFFFFFF:\n\tv640 = v667;\nL_00F9:\n\tv658 = v353 < v432;\n\tv395 = ~v658;\n\tif (v395) goto L_014A;\n\tv660 = System.String::op_Equality(v477[v365 @ X25_v7 (System.Int32)], *([v436 @ X20_v15]));\n\tv662 = v660 == 0;\n\tif (v662) goto L_00EB;\n\tv428 = v336.Length == 0;\n\tif (v428) goto L_014C;\n\tv667 = System.String::Concat(v640, \" \", v336[0]);\n\tgoto L_FFFFFFFF;\nL_0117:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v123 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String[]>));\nL_FFFFFFFF:\n\tv123 = v310._list;\nL_FFFFFFFF:\n\tv150 = v341;\nL_FFFFFFFF:\n\tv160 = Il2CppMethodInfo;\nL_0118:\n\tv176 = v150 == 0;\n\tif (v176) goto L_0152;\n\tv445 = System.String::TrimEnd(v150);\n\tv492 = System.String::op_Inequality(v445, v150);\n\tv524 = v492 == 0;\n\tv514 = ~v524;\n\tv496 = ~v514;\n\tif (v496) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv579 = \"Hidden/Toony Colors Pro 2/Variants/\";\n\tgoto L_0139;\nL_FFFFFFFF:\n\tv579 = \"Toony Colors Pro 2/\";\nL_014A:\n\tv422 = new System.IndexOutOfRangeException();\nL_FFFFFFFF:\n\tv298 = v422;\n\tgoto L_0181;\nL_014C:\n\tv423 = new System.IndexOutOfRangeException();\nL_FFFFFFFF:\n\tv298 = v423;\n\tgoto L_0181;\nL_014E:\n\tv424 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv298 = v424;\n\tgoto L_0181;\nL_0150:\n\tv425 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv298 = v425;\n\tgoto L_0181;\nL_0152:\n\tv188 = new System.NullReferenceException();\n\tgoto L_0163;\nL_0163:\n\tv211 = v160 != 1;\n\tif (v211) goto L_0173;\n\tv221 = 0x8BF5BC4(v188, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv242 = 0x8BF5BF4(v221, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v123 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String[]>));\n\tv227 = *([v221 @ X0_v13]) == 0;\nL_FFFFFFFF:\n\tv160 = Il2CppMethodInfo;\n\tif (v227) goto L_0118;\n\tv225 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv188 = v225;\nL_0173:\n\tgoto L_0179;\n\tv295 = 0x8BF0368(v188, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0180:\n\tv298 = new System.OutOfMemoryException();\nL_0181:\n\t// 385 Interrupt\n\treturnVal1 = 0x7C03E68(v298, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_003E:\n\tv58 = material == 0;\nL_FFFFFFFF:\n\tv123 = 0;\n\tif (v58) goto L_0152;\nL_0087:\n\tv177 = v181.ShaderVariants == 0;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\tv160 = v165;\n\tif (v177) goto L_0152;\nL_00CD:\n\tv365 = v365 + 1;\n\tv454 = v365 >= v473;\nL_FFFFFFFF:\n\tv341 = v640;\n\tif (v454) goto L_00AB;\nL_00EB:\n\tv353 = v353 + 1;\n\tv432 = v336.Length;\n\tv436 = v436 + 8;\n\tv623 = v353 >= v336.Length;\n\tif (v623) goto L_00CC;\nL_0139:\n\tv581 = System.String::Concat(v579, v445);\n\treturnVal2 = UnityEngine.Shader::Find(v581);\n\treturn returnVal2;\nL_0179:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v123 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String[]>));\n\tgoto L_0180;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Shader GetShaderWithKeywords(Material material)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_RuntimeUtils::GetShaderWithKeywords");
			return default;
		}
	}
}
