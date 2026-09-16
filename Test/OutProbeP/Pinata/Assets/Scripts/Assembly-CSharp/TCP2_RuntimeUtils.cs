using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000015")]
public static class TCP2_RuntimeUtils
{
	[Token(Token = "0x40000B9")]
	private const string BASE_SHADER_PATH = "Toony Colors Pro 2/";

	[Token(Token = "0x40000BA")]
	private const string VARIANT_SHADER_PATH = "Hidden/Toony Colors Pro 2/Variants/";

	[Token(Token = "0x40000BB")]
	private const string BASE_SHADER_NAME = "Desktop";

	[Token(Token = "0x40000BC")]
	private const string BASE_SHADER_NAME_MOB = "Mobile";

	[Token(Token = "0x40000BD")]
	private static List<string[]> ShaderVariants;

	[Token(Token = "0x6000096")]
	[Address(RVA = "0xB05E64", Offset = "0xB05E64", Length = "0x3E8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EDF8B0]);\n\tv35 = *([v34 @ X8_v67]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20224F1]) = v54;\nL_0022:\n\tv61 = UnityEngine.Material::get_shader(material);\n\tgoto L_0034;\n\tv210 = *([v146 @ X8_v9+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_0034;\n\tv276 = v146;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v276, v60, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0034:\n\tv218 = UnityEngine.Object::op_Inequality(v61, 0);\n\tv278 = v218 == 0;\n\tif (v278) goto L_FFFFFFFF;\n\tv196 = UnityEngine.Material::get_shader(material);\n\tv197 = UnityEngine.Object::get_name(v196);\n\tv198 = System.String::ToLower(v197);\n\tv326 = System.String::Contains(v198, \"mobile\");\n\tgoto L_005D;\nL_005D:\n\tv66 = v328 != 0;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0067;\nL_0067:\n\tgoto L_0076;\n\tv399 = *([v335 @ X0_v17 (Il2CppClass<TCP2_RuntimeUtils>)+E0]);\n\tv400 = v399 == 0;\n\tv401 = ~v400;\n\t// 107 Jump @b92\n\tv406 = \"il2cpp_codegen_runtime_class_init\"(v335, v194, v186, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv403 = TCP2_RuntimeUtils;\nL_0076:\n\tv411 = System.Collections.Generic.List`1<System.String[]>::GetEnumerator(v207.ShaderVariants);\n\tgoto L_00ED;\nL_0084:\n\tv469 = UnityEngine.Material::get_shaderKeywords(material);\n\tv596 = v469.Length;\n\tv431 = v469.Length < 1;\n\tif (v431) goto L_00ED;\nL_0096:\n\tv597 = v522 < v596;\n\tv598 = ~v597;\n\tif (v598) goto L_0104;\n\tv554 = *([v415 @ stack_-88+18]);\n\tv696 = *([v415 @ stack_-88+18]) < 2;\n\tif (v696) goto L_00DD;\nL_00B3:\n\tv755 = v516 < v554;\n\tv540 = ~v755;\n\tif (v540) goto L_00FA;\n\tv653 = v516 << 3;\n\tv759 = v415 + v653;\n\tv671 = System.String::op_Equality(v469[v522 @ X27_v13 (System.Int32)], *([v759 @ X8_v54+20]));\n\tv765 = v671 == 0;\n\tif (v765) goto L_00CF;\n\tv673 = *([v415 @ stack_-88+18]) == 0;\n\tif (v673) goto L_00FE;\n\tv771 = System.String::Concat(v735, \" \", *([v415 @ stack_-88+20]));\nL_00CF:\n\tv554 = *([v415 @ stack_-88+18]);\n\tv516 = v516 + 1;\n\tv718 = v516 < *([v415 @ stack_-88+18]);\n\tif (v718) goto L_00B3;\nL_00DD:\n\tv596 = v469.Length;\n\tv522 = v522 + 1;\n\tv430 = v522 < v469.Length;\n\tif (v430) goto L_0096;\nL_00ED:\n\tv478 = System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>::MoveNext(&v123 @ stack_-98_v5 (System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>));\n\tv480 = v478 == 0;\n\tv481 = ~v480;\n\tif (v481) goto L_0084;\n\tv486 = System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>::Dispose(&v123 @ stack_-98_v5 (System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>));\n\tgoto L_012A;\n\tv504 = new System.NullReferenceException();\nL_00FA:\n\tv555 = new System.IndexOutOfRangeException();\n\tthrow v555;\nL_00FE:\n\tv676 = new System.IndexOutOfRangeException();\n\tthrow v676;\n\tv645 = new System.NullReferenceException();\nL_0104:\n\tv648 = new System.IndexOutOfRangeException();\n\tthrow v648;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_0189;\n\tv761 = 0x6D2BC0(v268, 0, 0, v222, v40, v41, v42, v43, v123, v45, v46, v47, v48, v49, v50, v51);\n\tv313 = *([v761 @ X0_v55]);\n\tv766 = 0x6D2490(v761, 0, 0, v222, v40, v41, v42, v43, v123, v45, v46, v47, v48, v49, v50, v51);\n\tv309 = System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>::Dispose(&v123 @ stack_-98_v5 (System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>), Il2CppMethodInfo);\n\tv778 = v313 == 0;\n\tv311 = ~v778;\n\tif (v311) goto L_018D;\nL_012A:\n\tv496 = Il2CppClass<System.EmptyArray`1<System.Char>>;\n\tgoto L_0133;\n\tv505 = v496;\n\tv506 = System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>::Dispose(v505, v131);\n\tv509 = *([v496 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Char>>)+12E]);\nL_0133:\n\tv510 = *([v496 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Char>>)+12E]) & 0x200;\n\tv511 = v510 == 0;\n\tif (v511) goto L_0154;\n\tv557 = Il2CppClass<System.EmptyArray`1<System.Char>>;\n\tgoto L_0140;\n\tv609 = v557;\n\tv610 = System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>::Dispose(v609, v131);\nL_0140:\n\tv611 = *([v557 @ X21_v12 (Il2CppClass<System.EmptyArray`1<System.Char>>)+E0]) == 0;\n\tv567 = ~v611;\n\tif (v567) goto L_0154;\n\tgoto L_0154;\n\tv702 = v569;\n\tv703 = System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>::Dispose(v702, v131);\nL_0154:\n\tgoto L_015D;\n\tv612 = v137;\n\tv613 = System.Collections.Generic.List`1<System.String[]>+Enumerator<System.String[]>::Dispose(v612, v131);\nL_015D:\n\tv684 = System.String::TrimEnd(v111, v680.Value);\n\tv712 = System.String::op_Inequality(v684, *([v396 @ X8_v11 (System.String)]));\n\tv357 = v712 == 0;\n\tv350 = ~v357;\n\tv340 = ~v350;\n\tif (v340) goto L_FFFFFFFF;\n\tgoto L_0176;\nL_0176:\n\tv763 = System.String::Concat(v762, v684);\n\treturnVal2 = UnityEngine.Shader::Find(v763);\n\treturn returnVal2;\n\tv209 = new System.NullReferenceException();\nL_0189:\n\tv275 = 0x6D2380(v267, v265, v261, v221, v40, v41, v42, v43, v259, v45, v46, v47, v48, v49, v50, v51);\nL_018D:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 271 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static Shader GetShaderWithKeywords(Material material)
	{
		//IL_00d7: Expected I, but got O
		//IL_032c: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_01b2: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_021e: Expected I, but got O
		Shader shader = material.shader;
		int num;
		if (shader != null)
		{
			Shader shader2 = material.shader;
			string name = shader2.name;
			string text = name.ToLower();
			bool flag = text.Contains("mobile");
			num = (flag ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		string text2 = ((num != 0) ? "Mobile" : "Desktop");
		List<string[]>.Enumerator enumerator = ShaderVariants.GetEnumerator();
		IntPtr intPtr = (IntPtr)text2;
		List<string[]>.Enumerator enumerator2 = default(List<string[]>.Enumerator);
		object obj2 = default(object);
		while (enumerator2.MoveNext())
		{
			string[] shaderKeywords = material.shaderKeywords;
			int num2 = shaderKeywords.Length;
			if (shaderKeywords.Length < 1)
			{
				continue;
			}
			int num3 = 0;
			IntPtr intPtr2 = intPtr;
			bool flag3;
			do
			{
				if (num3 < num2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ stack_-88+18]");
					int num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ stack_-88+18]");
					if (0L >= 2L)
					{
						int num5 = 1;
						IntPtr intPtr3 = intPtr2;
						bool flag2;
						do
						{
							if (num5 < num4)
							{
								int num6 = num5 << 3;
								object obj = (long)(IntPtr)obj2 + (long)num6;
								string text3 = shaderKeywords[num3];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ X8_v54+20]");
								if (text3 == (string)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ stack_-88+18]");
									if ((IntPtr)0 == (IntPtr)0)
									{
										IndexOutOfRangeException ex = new IndexOutOfRangeException();
										throw ex;
									}
									IntPtr intPtr4 = intPtr3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ stack_-88+20]");
									string text4 = (string)(long)intPtr4 + " " + (string)0;
									intPtr3 = (IntPtr)text4;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ stack_-88+18]");
								num4 = 0;
								num5++;
								int num7 = num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ stack_-88+18]");
								flag2 = (long)num7 < 0L;
								intPtr2 = intPtr3;
								continue;
							}
							IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
							throw ex2;
						}
						while (flag2);
					}
					num2 = shaderKeywords.Length;
					num3++;
					flag3 = num3 < shaderKeywords.Length;
					intPtr = intPtr2;
					continue;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}
			while (flag3);
		}
		enumerator2.Dispose();
		IntPtr intPtr5 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Char>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ X21_v12 (Il2CppClass<System.EmptyArray`1<System.Char>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		string text5 = ((string)(long)intPtr).TrimEnd();
		string text6 = ((!(text5 != text2)) ? "Toony Colors Pro 2/" : "Hidden/Toony Colors Pro 2/Variants/");
		string name2 = text6 + text5;
		return Shader.Find(name2);
	}

	[Token(Token = "0x6000097")]
	[Address(RVA = "0xB0A964", Offset = "0xB0A964", Length = "0x4A8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBD470]);\n\tv23 = *([v22 @ X8_v70]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20224F2]) = v43;\nL_0018:\n\tv47 = new System.Collections.Generic.List`1<System.String[]>();\n\tSystem.Collections.Generic.List`1<System.String[]>::.ctor(v47);\n\t// 34 NewArr v56 @ X0_v5 (System.String[]), typeof(System.String[]), 2\n\tv62 = \"Specular\" == 0;\n\tif (v62) goto L_0030;\n\t// 45 IsInst v216 @ X0_v80, typeof(System.String), \"Specular\"\nL_0030:\n\tv345 = v56.Length;\n\tv223 = v56.Length == 0;\n\tif (v223) goto L_01A9;\n\tv56[0] = \"Specular\";\n\tv251 = \"TCP2_SPEC\" == 0;\n\tif (v251) goto L_0040;\n\t// 60 IsInst v385 @ X0_v79, typeof(System.String), \"TCP2_SPEC\"\n\tv345 = v56.Length;\nL_0040:\n\tv431 = v345 < 1;\n\tv138 = ~v431;\n\tv129 = v345 - 1;\n\tv111 = v129 == 0;\n\tv432 = ~v138;\n\tv66 = v432 | v111;\n\tif (v66) goto L_01A9;\n\tv56[1] = \"TCP2_SPEC\";\n\tSystem.Collections.Generic.List`1<System.String[]>::Add(v47, v56);\n\t// 88 NewArr v191 @ X0_v23 (System.String[]), typeof(System.String[]), 3\n\tv475 = \"Reflection\" == 0;\n\tif (v475) goto L_0066;\n\t// 99 IsInst v386 @ X0_v78, typeof(System.String), \"Reflection\"\nL_0066:\n\tv347 = v191.Length;\n\tv324 = v191.Length == 0;\n\tif (v324) goto L_01A9;\n\tv191[0] = \"Reflection\";\n\tv480 = \"TCP2_REFLECTION\" == 0;\n\tif (v480) goto L_0076;\n\t// 114 IsInst v387 @ X0_v77, typeof(System.String), \"TCP2_REFLECTION\"\n\tv347 = v191.Length;\nL_0076:\n\tv482 = v347 < 1;\n\tv277 = ~v482;\n\tv274 = v347 - 1;\n\tv268 = v274 == 0;\n\tv483 = ~v277;\n\tv253 = v483 | v268;\n\tif (v253) goto L_01A9;\n\tv191[1] = \"TCP2_REFLECTION\";\n\tv486 = \"TCP2_REFLECTION_MASKED\" == 0;\n\tif (v486) goto L_008F;\n\t// 139 IsInst v388 @ X0_v76, typeof(System.String), \"TCP2_REFLECTION_MASKED\"\n\tv347 = v191.Length;\nL_008F:\n\tv488 = v347 < 2;\n\tv139 = ~v488;\n\tv130 = v347 - 2;\n\tv112 = v130 == 0;\n\tv489 = ~v139;\n\tv67 = v489 | v112;\n\tif (v67) goto L_01A9;\n\tv191[2] = \"TCP2_REFLECTION_MASKED\";\n\tSystem.Collections.Generic.List`1<System.String[]>::Add(v47, v191);\n\t// 163 NewArr v192 @ X0_v32 (System.String[]), typeof(System.String[]), 2\n\tv495 = \"Matcap\" == 0;\n\tif (v495) goto L_00B1;\n\t// 174 IsInst v389 @ X0_v75, typeof(System.String), \"Matcap\"\nL_00B1:\n\tv348 = v192.Length;\n\tv325 = v192.Length == 0;\n\tif (v325) goto L_01A9;\n\tv192[0] = \"Matcap\";\n\tv500 = \"TCP2_MC\" == 0;\n\tif (v500) goto L_00C1;\n\t// 189 IsInst v390 @ X0_v74, typeof(System.String), \"TCP2_MC\"\n\tv348 = v192.Length;\nL_00C1:\n\tv502 = v348 < 1;\n\tv140 = ~v502;\n\tv131 = v348 - 1;\n\tv113 = v131 == 0;\n\tv503 = ~v140;\n\tv68 = v503 | v113;\n\tif (v68) goto L_01A9;\n\tv192[1] = \"TCP2_MC\";\n\tSystem.Collections.Generic.List`1<System.String[]>::Add(v47, v192);\n\t// 213 NewArr v193 @ X0_v39 (System.String[]), typeof(System.String[]), 2\n\tv509 = \"Rim\" == 0;\n\tif (v509) goto L_00E3;\n\t// 224 IsInst v391 @ X0_v73, typeof(System.String), \"Rim\"\nL_00E3:\n\tv349 = v193.Length;\n\tv326 = v193.Length == 0;\n\tif (v326) goto L_01A9;\n\tv193[0] = \"Rim\";\n\tv514 = \"TCP2_RIM\" == 0;\n\tif (v514) goto L_00F3;\n\t// 239 IsInst v392 @ X0_v72, typeof(System.String), \"TCP2_RIM\"\n\tv349 = v193.Length;\nL_00F3:\n\tv516 = v349 < 1;\n\tv141 = ~v516;\n\tv132 = v349 - 1;\n\tv114 = v132 == 0;\n\tv517 = ~v141;\n\tv69 = v517 | v114;\n\tif (v69) goto L_01A9;\n\tv193[1] = \"TCP2_RIM\";\n\tSystem.Collections.Generic.List`1<System.String[]>::Add(v47, v193);\n\t// 263 NewArr v194 @ X0_v46 (System.String[]), typeof(System.String[]), 2\n\tv523 = \"RimOutline\" == 0;\n\tif (v523) goto L_0115;\n\t// 274 IsInst v393 @ X0_v71, typeof(System.String), \"RimOutline\"\nL_0115:\n\tv350 = v194.Length;\n\tv327 = v194.Length == 0;\n\tif (v327) goto L_01A9;\n\tv194[0] = \"RimOutline\";\n\tv528 = \"TCP2_RIMO\" == 0;\n\tif (v528) goto L_0125;\n\t// 289 IsInst v394 @ X0_v70, typeof(System.String), \"TCP2_RIMO\"\n\tv350 = v194.Length;\nL_0125:\n\tv530 = v350 < 1;\n\tv142 = ~v530;\n\tv133 = v350 - 1;\n\tv115 = v133 == 0;\n\tv531 = ~v142;\n\tv70 = v531 | v115;\n\tif (v70) goto L_01A9;\n\tv194[1] = \"TCP2_RIMO\";\n\tSystem.Collections.Generic.List`1<System.String[]>::Add(v47, v194);\n\t// 313 NewArr v195 @ X0_v53 (System.String[]), typeof(System.String[]), 2\n\tv537 = \"Outline\" == 0;\n\tif (v537) goto L_0147;\n\t// 324 IsInst v395 @ X0_v69, typeof(System.String), \"Outline\"\nL_0147:\n\tv351 = v195.Length;\n\tv328 = v195.Length == 0;\n\tif (v328) goto L_01A9;\n\tv195[0] = \"Outline\";\n\tv542 = \"OUTLINES\" == 0;\n\tif (v542) goto L_0157;\n\t// 339 IsInst v396 @ X0_v68, typeof(System.String), \"OUTLINES\"\n\tv351 = v195.Length;\nL_0157:\n\tv544 = v351 < 1;\n\tv143 = ~v544;\n\tv134 = v351 - 1;\n\tv116 = v134 == 0;\n\tv545 = ~v143;\n\tv71 = v545 | v116;\n\tif (v71) goto L_01A9;\n\tv195[1] = \"OUTLINES\";\n\tSystem.Collections.Generic.List`1<System.String[]>::Add(v47, v195);\n\t// 363 NewArr v196 @ X0_v60 (System.String[]), typeof(System.String[]), 2\n\tv551 = \"OutlineBlending\" == 0;\n\tif (v551) goto L_0179;\n\t// 374 IsInst v397 @ X0_v67, typeof(System.String), \"OutlineBlending\"\nL_0179:\n\tv352 = v196.Length;\n\tv329 = v196.Length == 0;\n\tif (v329) goto L_01A9;\n\tv196[0] = \"OutlineBlending\";\n\tv556 = \"OUTLINE_BLENDING\" == 0;\n\tif (v556) goto L_0189;\n\t// 389 IsInst v398 @ X0_v66, typeof(System.String), \"OUTLINE_BLENDING\"\n\tv352 = v196.Length;\nL_0189:\n\tv558 = v352 < 1;\n\tv278 = ~v558;\n\tv275 = v352 - 1;\n\tv269 = v275 == 0;\n\tv559 = ~v278;\n\tv254 = v559 | v269;\n\tif (v254) goto L_01A9;\n\tv196[1] = \"OUTLINE_BLENDING\";\n\tSystem.Collections.Generic.List`1<System.String[]>::Add(v47, v196);\n\tv461.ShaderVariants = v47;\n\treturn;\nL_01A9:\n\tv353 = new System.IndexOutOfRangeException();\n\tgoto L_01AE;\n\tv429 = new System.ArrayTypeMismatchException();\nL_01AE:\n\tthrow v468;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 260 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static TCP2_RuntimeUtils()
	{
		//IL_0040: Expected O, but got I4
		//IL_06cd: Expected O, but got I
		//IL_00ad: Expected O, but got I4
		//IL_0125: Expected O, but got I4
		//IL_072b: Expected O, but got I
		//IL_0192: Expected O, but got I4
		//IL_0789: Expected O, but got I
		//IL_01e5: Expected O, but got I4
		//IL_0258: Expected O, but got I4
		//IL_07e7: Expected O, but got I
		//IL_02c5: Expected O, but got I4
		//IL_0338: Expected O, but got I4
		//IL_0845: Expected O, but got I
		//IL_03a5: Expected O, but got I4
		//IL_0418: Expected O, but got I4
		//IL_08a3: Expected O, but got I
		//IL_0485: Expected O, but got I4
		//IL_04f8: Expected O, but got I4
		//IL_0901: Expected O, but got I
		//IL_0565: Expected O, but got I4
		//IL_05d8: Expected O, but got I4
		//IL_095f: Expected O, but got I
		//IL_0645: Expected O, but got I4
		List<string[]> list = new List<string[]>();
		string[] array = new string[2];
		if ("Specular" != null)
		{
			object obj = "Specular" as string;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = "Specular";
			if ("TCP2_SPEC" != null)
			{
				object obj3 = "TCP2_SPEC" as string;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = "TCP2_SPEC";
				list.Add(array);
				string[] array2 = new string[3];
				if ("Reflection" != null)
				{
					object obj5 = "Reflection" as string;
				}
				object obj6 = array2.Length;
				if (array2.Length != 0)
				{
					array2[0] = "Reflection";
					if ("TCP2_REFLECTION" != null)
					{
						object obj7 = "TCP2_REFLECTION" as string;
						obj6 = array2.Length;
					}
					bool flag5 = (long)(IntPtr)obj6 < 1L;
					bool flag6 = !flag5;
					object obj8 = (long)(IntPtr)obj6 - 1L;
					bool flag7 = obj8 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array2[1] = "TCP2_REFLECTION";
						if ("TCP2_REFLECTION_MASKED" != null)
						{
							object obj9 = "TCP2_REFLECTION_MASKED" as string;
							obj6 = array2.Length;
						}
						bool flag9 = (long)(IntPtr)obj6 < 2L;
						bool flag10 = !flag9;
						object obj10 = (long)(IntPtr)obj6 - 2L;
						bool flag11 = obj10 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array2[2] = "TCP2_REFLECTION_MASKED";
							list.Add(array2);
							string[] array3 = new string[2];
							if ("Matcap" != null)
							{
								object obj11 = "Matcap" as string;
							}
							object obj12 = array3.Length;
							if (array3.Length != 0)
							{
								array3[0] = "Matcap";
								if ("TCP2_MC" != null)
								{
									object obj13 = "TCP2_MC" as string;
									obj12 = array3.Length;
								}
								bool flag13 = (long)(IntPtr)obj12 < 1L;
								bool flag14 = !flag13;
								object obj14 = (long)(IntPtr)obj12 - 1L;
								bool flag15 = obj14 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									array3[1] = "TCP2_MC";
									list.Add(array3);
									string[] array4 = new string[2];
									if ("Rim" != null)
									{
										object obj15 = "Rim" as string;
									}
									object obj16 = array4.Length;
									if (array4.Length != 0)
									{
										array4[0] = "Rim";
										if ("TCP2_RIM" != null)
										{
											object obj17 = "TCP2_RIM" as string;
											obj16 = array4.Length;
										}
										bool flag17 = (long)(IntPtr)obj16 < 1L;
										bool flag18 = !flag17;
										object obj18 = (long)(IntPtr)obj16 - 1L;
										bool flag19 = obj18 == null;
										bool flag20 = !flag18;
										if (!(flag20 || flag19))
										{
											array4[1] = "TCP2_RIM";
											list.Add(array4);
											string[] array5 = new string[2];
											if ("RimOutline" != null)
											{
												object obj19 = "RimOutline" as string;
											}
											object obj20 = array5.Length;
											if (array5.Length != 0)
											{
												array5[0] = "RimOutline";
												if ("TCP2_RIMO" != null)
												{
													object obj21 = "TCP2_RIMO" as string;
													obj20 = array5.Length;
												}
												bool flag21 = (long)(IntPtr)obj20 < 1L;
												bool flag22 = !flag21;
												object obj22 = (long)(IntPtr)obj20 - 1L;
												bool flag23 = obj22 == null;
												bool flag24 = !flag22;
												if (!(flag24 || flag23))
												{
													array5[1] = "TCP2_RIMO";
													list.Add(array5);
													string[] array6 = new string[2];
													if ("Outline" != null)
													{
														object obj23 = "Outline" as string;
													}
													object obj24 = array6.Length;
													if (array6.Length != 0)
													{
														array6[0] = "Outline";
														if ("OUTLINES" != null)
														{
															object obj25 = "OUTLINES" as string;
															obj24 = array6.Length;
														}
														bool flag25 = (long)(IntPtr)obj24 < 1L;
														bool flag26 = !flag25;
														object obj26 = (long)(IntPtr)obj24 - 1L;
														bool flag27 = obj26 == null;
														bool flag28 = !flag26;
														if (!(flag28 || flag27))
														{
															array6[1] = "OUTLINES";
															list.Add(array6);
															string[] array7 = new string[2];
															if ("OutlineBlending" != null)
															{
																object obj27 = "OutlineBlending" as string;
															}
															object obj28 = array7.Length;
															if (array7.Length != 0)
															{
																array7[0] = "OutlineBlending";
																if ("OUTLINE_BLENDING" != null)
																{
																	object obj29 = "OUTLINE_BLENDING" as string;
																	obj28 = array7.Length;
																}
																bool flag29 = (long)(IntPtr)obj28 < 1L;
																bool flag30 = !flag29;
																object obj30 = (long)(IntPtr)obj28 - 1L;
																bool flag31 = obj30 == null;
																bool flag32 = !flag30;
																if (!(flag32 || flag31))
																{
																	array7[1] = "OUTLINE_BLENDING";
																	list.Add(array7);
																	ShaderVariants = list;
																	return;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}
}
