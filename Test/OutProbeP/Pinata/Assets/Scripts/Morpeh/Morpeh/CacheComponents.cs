using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh
{
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D630", Offset = "0x73D630")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D630", Offset = "0x73D630")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D630", Offset = "0x73D630")]
	[Token(Token = "0x2000014")]
	internal static class CacheComponents<T> where T : struct, IComponent
	{
		[Token(Token = "0x4000034")]
		internal static T[] Components;

		[Token(Token = "0x4000035")]
		private static int capacity;

		[Token(Token = "0x4000036")]
		private static int length;

		[Token(Token = "0x4000037")]
		private static T empty;

		[Token(Token = "0x4000038")]
		private static readonly Queue<int> FreeIndexes;

		[Token(Token = "0x6000059")]
		[Address(RVA = "0xD96344", Offset = "0xD96344", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED3FE0]);\n\tv21 = *([v20 @ X8_v55]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20240D4]) = v40;\nL_0019:\n\tgoto L_001D;\n\tv46 = v41;\n\tv47 = 0x8907BC(v46, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001D:\n\tv50 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0025;\n\tv55 = v50;\n\tv56 = 0x8907BC(v55, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv58 = *([v50 @ X20_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\t*([v58 @ X8_v6 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+8]) = 0x800;\n\tgoto L_0031;\n\tv65 = v60;\n\tv66 = 0x8907BC(v65, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv69 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0039;\n\tv74 = v69;\n\tv75 = 0x8907BC(v74, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tv77 = *([v69 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\t*([v77 @ X8_v10 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+C]) = 0;\n\tgoto L_0044;\n\tv83 = v78;\n\tv84 = 0x8907BC(v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tv87 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_004D;\n\tv92 = v87;\n\tv93 = 0x8907BC(v92, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004D:\n\tv96 = *([v87 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tgoto L_005C;\n\tv102 = v95;\n\tv103 = 0x8907BC(v102, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005C:\n\tgoto L_0061;\n\tv111 = v106;\n\tv112 = 0x8907BC(v111, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0061:\n\t// 97 NewArr v116 @ X0_v11 (T[]), typeof(Il2CppClass<T[]>), [v96 @ X8_v14 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+8]\n\tgoto L_0071;\n\tv123 = v117;\n\tv124 = 0x8907BC(v123, v115, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0071:\n\tgoto L_0075;\n\tv132 = v127;\n\tv133 = 0x8907BC(v132, v115, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0075:\n\tv135.Components = v116;\n\tv139 = new System.Collections.Generic.Queue`1<System.Int32>();\n\tSystem.Collections.Generic.Queue`1<System.Int32>::.ctor(v139);\n\tgoto L_0088;\n\tv149 = v144;\n\tv150 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v149, v143);\nL_0088:\n\tv153 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0090;\n\tv158 = v153;\n\tv159 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v158, v143);\nL_0090:\n\tv161 = *([v153 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\t*([v161 @ X8_v28 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]) = v139;\n\tgoto L_009B;\n\tv167 = v162;\n\tv168 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v167, v143);\nL_009B:\n\tv171 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_00A4;\n\tv176 = v171;\n\tv177 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v176, v143);\n\tv180 = *([v171 @ X20_v12 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_00A4:\n\tv181 = *([v171 @ X20_v12 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv182 = v181 == 0;\n\tif (v182) goto L_00D4;\n\tgoto L_00B0;\n\tv205 = v183;\n\tv206 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v205, v143);\nL_00B0:\n\tv199 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_00B9;\n\tv222 = v199;\n\tv223 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v222, v143);\nL_00B9:\n\tv224 = *([v199 @ X20_v19 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv193 = ~v224;\n\tif (v193) goto L_00D4;\n\tgoto L_00CA;\n\tv246 = v235;\n\tv247 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v246, v143);\nL_00CA:\n\tgoto L_00D4;\n\tv260 = v198;\n\tv261 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v260, v143);\nL_00D4:\n\tgoto L_00DD;\n\tv213 = v200;\n\tv214 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v213, v143);\nL_00DD:\n\tgoto L_00E4;\n\tv225 = v217;\n\tv226 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v225, v143);\nL_00E4:\n\tv232 = v228.info + 0x10;\n\tv234 = new Morpeh.ComponentsCleaner+RemoveDelegate();\n\tgoto L_00F5;\n\tv252 = v240;\n\tv253 = System.Collections.Generic.Queue`1<System.Int32>::.ctor(v252, v143);\nL_00F5:\n\tMorpeh.ComponentsCleaner+RemoveDelegate::.ctor(v234, 0, Il2CppMethodInfo);\n\tgoto L_010B;\n\tv270 = *([v266 @ X0_v27+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_010B;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v266, v257, v259, v258, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_010B:\n\tv285 = Morpeh.ComponentsCleaner::Register(v232, v234);\n\treturn;\n// 165 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		unsafe static CacheComponents()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X20_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr2 = (IntPtr)0;
			_ = 2048;
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr4 = (IntPtr)0;
			_ = 0;
			IntPtr intPtr5 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr6 = (IntPtr)0;
			T[] components = null;
			Components = components;
			Queue<int> queue = new Queue<int>();
			IntPtr intPtr7 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr8 = (IntPtr)0;
			IntPtr intPtr9 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X20_v12 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr10 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ X20_v19 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ref int typeId = ref *(int*)((long)(IntPtr)CacheTypeIdentifier<T>.info + 16L);
			ComponentsCleaner.RemoveDelegate func = Remove;
			bool flag = ComponentsCleaner.Register(in typeId, func);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600005A")]
		[Address(RVA = "0xD96634", Offset = "0xD96634", Length = "0x5BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ECA448]);\n\tv27 = *([v26 @ X8_v106]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20240D5]) = v46;\nL_001C:\n\tgoto L_0020;\n\tv52 = v47;\n\tv53 = System.Array::Resize(v52, v29, v30);\nL_0020:\n\tv56 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0029;\n\tv61 = v56;\n\tv62 = System.Array::Resize(v61, v29, v30);\n\tv65 = *([v56 @ X20_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0029:\n\tv66 = *([v56 @ X20_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv67 = v66 == 0;\n\tif (v67) goto L_0059;\n\tgoto L_0035;\n\tv90 = v68;\n\tv91 = System.Array::Resize(v90, v29, v30);\nL_0035:\n\tv84 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_003E;\n\tv107 = v84;\n\tv108 = System.Array::Resize(v107, v29, v30);\nL_003E:\n\tv109 = *([v84 @ X20_v51 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv78 = ~v109;\n\tif (v78) goto L_0059;\n\tgoto L_004F;\n\tv135 = v121;\n\tv136 = System.Array::Resize(v135, v29, v30);\nL_004F:\n\tgoto L_0059;\n\tv157 = v83;\n\tv158 = System.Array::Resize(v157, v29, v30);\nL_0059:\n\tgoto L_005D;\n\tv98 = v85;\n\tv99 = System.Array::Resize(v98, v29, v30);\nL_005D:\n\tv102 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0065;\n\tv110 = v102;\n\tv111 = System.Array::Resize(v110, v29, v30);\nL_0065:\n\tv113 = *([v102 @ X20_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tv115 = *([v113 @ X8_v11 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]);\n\tgoto L_0071;\n\tv126 = v114;\n\tv127 = System.Array::Resize(v126, v29, v30);\nL_0071:\n\tv130 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0084;\n\tv141 = v130;\n\tv142 = System.Array::Resize(v141, v29, v30);\n\tv145 = *([v130 @ X20_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0084:\n\tv156 = *([v115 @ X8_v12+20]) < 1;\n\tif (v156) goto L_00D2;\n\tv161 = *([v130 @ X20_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv162 = v161 == 0;\n\tif (v162) goto L_00B6;\n\tgoto L_0092;\n\tv209 = v165;\n\tv210 = System.Array::Resize(v209, v29, v30);\nL_0092:\n\tv181 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_009B;\n\tv243 = v181;\n\tv244 = System.Array::Resize(v243, v29, v30);\nL_009B:\n\tv245 = *([v181 @ X20_v46 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv175 = ~v245;\n\tif (v175) goto L_00B6;\n\tgoto L_00AC;\n\tv295 = v276;\n\tv296 = System.Array::Resize(v295, v29, v30);\nL_00AC:\n\tgoto L_00B6;\n\tv363 = v180;\n\tv364 = System.Array::Resize(v363, v29, v30);\nL_00B6:\n\tgoto L_00BA;\n\tv217 = v182;\n\tv218 = System.Array::Resize(v217, v29, v30);\nL_00BA:\n\tv221 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00C3;\n\tv246 = v221;\n\tv247 = System.Array::Resize(v246, v29, v30);\nL_00C3:\n\tv250 = *([v221 @ X19_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\treturnVal1 = System.Collections.Generic.Queue`1<System.Int32>::Dequeue(*([v250 @ X8_v87 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]));\n\treturn returnVal1;\nL_00D2:\n\tv163 = *([v130 @ X20_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv164 = v163 == 0;\n\tif (v164) goto L_0102;\n\tgoto L_00DE;\n\tv226 = v187;\n\tv227 = System.Array::Resize(v226, v29, v30);\nL_00DE:\n\tv203 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00E7;\n\tv263 = v203;\n\tv264 = System.Array::Resize(v263, v29, v30);\nL_00E7:\n\tv265 = *([v203 @ X20_v40 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv197 = ~v265;\n\tif (v197) goto L_0102;\n\tgoto L_00F8;\n\tv350 = v281;\n\tv351 = System.Array::Resize(v350, v29, v30);\nL_00F8:\n\tgoto L_0102;\n\tv367 = v202;\n\tv368 = System.Array::Resize(v367, v29, v30);\nL_0102:\n\tgoto L_0106;\n\tv234 = v204;\n\tv235 = System.Array::Resize(v234, v29, v30);\nL_0106:\n\tv238 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_010F;\n\tv266 = v238;\n\tv267 = System.Array::Resize(v266, v29, v30);\nL_010F:\n\tv270 = *([v238 @ X20_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tgoto L_0119;\n\tv286 = v269;\n\tv287 = System.Array::Resize(v286, v29, v30);\nL_0119:\n\tv290 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0121;\n\tv356 = v290;\n\tv357 = System.Array::Resize(v356, v29, v30);\nL_0121:\n\tv359 = *([v290 @ X20_v12 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tv307 = *([v270 @ X8_v20 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+8]) > *([v359 @ X8_v23 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+C]);\n\tif (v307) goto L_01C4;\n\tgoto L_0139;\n\tv401 = v371;\n\tv402 = System.Array::Resize(v401, v29, v30);\nL_0139:\n\tv405 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0142;\n\tv419 = v405;\n\tv420 = System.Array::Resize(v419, v29, v30);\n\tv423 = *([v405 @ X20_v26 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0142:\n\tv424 = *([v405 @ X20_v26 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv425 = v424 == 0;\n\tif (v425) goto L_0172;\n\tgoto L_014E;\n\tv477 = v433;\n\tv478 = System.Array::Resize(v477, v29, v30);\nL_014E:\n\tv449 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0157;\n\tv511 = v449;\n\tv512 = System.Array::Resize(v511, v29, v30);\nL_0157:\n\tv513 = *([v449 @ X20_v36 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv443 = ~v513;\n\tif (v443) goto L_0172;\n\tgoto L_0168;\n\tv567 = v537;\n\tv568 = System.Array::Resize(v567, v29, v30);\nL_0168:\n\tgoto L_0172;\n\tv598 = v448;\n\tv599 = System.Array::Resize(v598, v29, v30);\nL_0172:\n\tgoto L_0176;\n\tv485 = v450;\n\tv486 = System.Array::Resize(v485, v29, v30);\nL_0176:\n\tv489 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_017E;\n\tv514 = v489;\n\tv515 = System.Array::Resize(v514, v29, v30);\nL_017E:\n\tv517 = Il2CppClass<Morpeh.CacheComponents`1>;\n\tv518 = *([v489 @ X20_v29 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tgoto L_018E;\n\tv542 = v517;\n\tv543 = System.Array::Resize(v542, v29, v30);\n\tv548 = Il2CppClass<Morpeh.CacheComponents`1>;\n\tv546 = *([v548 @ X20_v34 (Il2CppClass<Morpeh.CacheComponents`1>)+12E]);\nL_018E:\n\tv550 = *([v517 @ X21_v8 (Il2CppClass<Morpeh.CacheComponents`1>)+12E]) & 1;\n\tv551 = v550 == 0;\n\tv552 = ~v551;\n\tif (v552) goto L_0195;\n\tv574 = System.Array::Resize(Il2CppClass<Morpeh.CacheComponents`1>, v29);\nL_0195:\n\tv577 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_019F;\n\tv602 = v577;\n\tv603 = System.Array::Resize(v602, v29, v30);\nL_019F:\n\tv395 = *([v518 @ X9_v7 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+8]) << 1;\n\tgoto L_01AB;\n\tv622 = v382;\n\tv623 = System.Array::Resize(v622, v29, v30);\nL_01AB:\n\tv627 = System.Array::Resize(*([v577 @ X20_v32 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]), v395);\n\tgoto L_01B5;\n\tv636 = v628;\n\tv637 = System.Array::Resize(v636, v383, v376);\nL_01B5:\n\tv385 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_01BD;\n\tv643 = v385;\n\tv644 = System.Array::Resize(v643, v383, v376);\nL_01BD:\n\tv393 = *([v385 @ X21_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\t*([v393 @ X8_v66 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+8]) = v395;\nL_01C4:\n\tgoto L_01C8;\n\tv410 = v396;\n\tv411 = System.Array::Resize(v410, v331, v302);\nL_01C8:\n\tv414 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_01D1;\n\tv426 = v414;\n\tv427 = System.Array::Resize(v426, v331, v302);\n\tv430 = *([v414 @ X20_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_01D1:\n\tv431 = *([v414 @ X20_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv432 = v431 == 0;\n\tif (v432) goto L_0201;\n\tgoto L_01DD;\n\tv494 = v455;\n\tv495 = System.Array::Resize(v494, v331, v302);\nL_01DD:\n\tv471 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_01E6;\n\tv524 = v471;\n\tv525 = System.Array::Resize(v524, v331, v302);\nL_01E6:\n\tv526 = *([v471 @ X20_v22 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv465 = ~v526;\n\tif (v465) goto L_0201;\n\tgoto L_01F7;\n\tv582 = v553;\n\tv583 = System.Array::Resize(v582, v331, v302);\nL_01F7:\n\tgoto L_0201;\n\tv610 = v470;\n\tv611 = System.Array::Resize(v610, v331, v302);\nL_0201:\n\tgoto L_0205;\n\tv502 = v472;\n\tv503 = System.Array::Resize(v502, v331, v302);\nL_0205:\n\tv506 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_020E;\n\tv527 = v506;\n\tv528 = System.Array::Resize(v527, v331, v302);\nL_020E:\n\tv531 = *([v506 @ X20_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tgoto L_0218;\n\tv558 = v530;\n\tv559 = System.Array::Resize(v558, v331, v302);\nL_0218:\n\tv562 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0221;\n\tv588 \n// ... truncated")]
		public unsafe static int Add()
		{
			//IL_008a: Expected O, but got I
			//IL_0148: Expected O, but got I
			//IL_03ff: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X20_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X20_v51 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X20_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v11 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]");
			object obj = 0;
			IntPtr intPtr5 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X8_v12+20]");
			if (0L >= 1L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X20_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X20_v46 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X19_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ X8_v87 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]");
				return ((Queue<int>)0).Dequeue();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X20_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X20_v40 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr10 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X20_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr11 = (IntPtr)0;
			IntPtr intPtr12 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ X20_v12 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr13 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ X8_v20 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+8]");
			IntPtr intPtr14 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ X8_v23 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+C]");
			if ((long)intPtr14 <= 0L)
			{
				IntPtr intPtr15 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X20_v26 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr16 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ X20_v36 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr17 = (IntPtr)0;
				IntPtr intPtr18 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ X20_v29 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
				IntPtr intPtr19 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ X21_v8 (Il2CppClass<Morpeh.CacheComponents`1>)+12E]");
				if (0 == 0)
				{
					int newSize = default(int);
					Array.Resize(ref *(T[]*)null, newSize);
				}
				IntPtr intPtr20 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ X9_v7 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+8]");
				int newSize2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ X20_v32 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
				Array.Resize(ref *(T[]*)null, newSize2);
				IntPtr intPtr21 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ X21_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
				IntPtr intPtr22 = (IntPtr)0;
			}
			IntPtr intPtr23 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ X20_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr24 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X20_v22 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr25 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ X20_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr26 = (IntPtr)0;
			IntPtr intPtr27 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ X21_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr28 = (IntPtr)0;
			IntPtr intPtr29 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ X19_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr30 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X8_v37 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+C]");
			object obj2 = 0L + 1L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ X8_v34 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+C]");
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600005B")]
		[Address(RVA = "0xD96BF0", Offset = "0xD96BF0", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv21 = v14;\n\tv22 = 0x8907BC(v21, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0012:\n\tv39 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_001B;\n\tv44 = v39;\n\tv45 = 0x8907BC(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv48 = *([v39 @ X21_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_001B:\n\tv49 = *([v39 @ X21_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv50 = v49 == 0;\n\tif (v50) goto L_004B;\n\tgoto L_0027;\n\tv73 = v51;\n\tv74 = 0x8907BC(v73, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0027:\n\tv67 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0030;\n\tv90 = v67;\n\tv91 = 0x8907BC(v90, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0030:\n\tv92 = *([v67 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv61 = ~v92;\n\tif (v61) goto L_004B;\n\tgoto L_0041;\n\tv113 = v108;\n\tv114 = 0x8907BC(v113, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0041:\n\tgoto L_004B;\n\tv119 = v66;\n\tv120 = 0x8907BC(v119, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_004B:\n\tgoto L_0054;\n\tv81 = v68;\n\tv82 = 0x8907BC(v81, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0054:\n\tgoto L_005F;\n\tv93 = v85;\n\tv94 = 0x8907BC(v93, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_005F:\n\tv104 = *([id @ X0 (System.Int32&)]) * 0x28;\n\tv105 = v96.Components + v104;\n\treturnVal1 = v105 + 0x20;\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ref T Get(in int id)
		{
			//IL_0077: Expected O, but got I4
			//IL_0087: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X21_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			object obj = id * 40;
			object obj2 = (long)(IntPtr)Components + (long)(IntPtr)obj;
			return ref *(T*)((long)(IntPtr)obj2 + 32L);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600005C")]
		[Address(RVA = "0xD96CF8", Offset = "0xD96CF8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv25 = v16;\n\tv26 = 0x8907BC(v25, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0014:\n\tv42 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_001D;\n\tv47 = v42;\n\tv48 = 0x8907BC(v47, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = *([v42 @ X22_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_001D:\n\tv52 = *([v42 @ X22_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv53 = v52 == 0;\n\tif (v53) goto L_004D;\n\tgoto L_0029;\n\tv76 = v54;\n\tv77 = 0x8907BC(v76, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tv70 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0032;\n\tv93 = v70;\n\tv94 = 0x8907BC(v93, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0032:\n\tv95 = *([v70 @ X22_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv64 = ~v95;\n\tif (v64) goto L_004D;\n\tgoto L_0043;\n\tv119 = v114;\n\tv120 = 0x8907BC(v119, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0043:\n\tgoto L_004D;\n\tv125 = v69;\n\tv126 = 0x8907BC(v125, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004D:\n\tgoto L_0056;\n\tv84 = v71;\n\tv85 = 0x8907BC(v84, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0056:\n\tgoto L_0060;\n\tv96 = v88;\n\tv97 = 0x8907BC(v96, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tv106 = *([id @ X0 (System.Int32&)]) * 0x28;\n\tv107 = v99.Components + v106;\n\t*([v107 @ X8_v11+40]) = *([value @ X1 (T&)+20]);\n\tvalue->klass = value->klass;\n\t*([v107 @ X8_v11+30]) = *([value @ X1 (T&)+10]);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Set(in int id, in T value)
		{
			//IL_0077: Expected O, but got I4
			//IL_0087: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X22_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X22_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			object obj = id * 40;
			object obj2 = (long)(IntPtr)Components + (long)(IntPtr)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X1 (T&)+20]");
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.As<T, object>(ref value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X1 (T&)+10]");
			_ = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600005D")]
		[Address(RVA = "0xD96E10", Offset = "0xD96E10", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv17 = v12;\n\tv18 = 0x8907BC(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0010:\n\tv36 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0019;\n\tv41 = v36;\n\tv42 = 0x8907BC(v41, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv45 = *([v36 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0019:\n\tv46 = *([v36 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv47 = v46 == 0;\n\tif (v47) goto L_0049;\n\tgoto L_0025;\n\tv70 = v48;\n\tv71 = 0x8907BC(v70, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0025:\n\tv64 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_002E;\n\tv87 = v64;\n\tv88 = 0x8907BC(v87, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002E:\n\tv89 = *([v64 @ X20_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv58 = ~v89;\n\tif (v58) goto L_0049;\n\tgoto L_003F;\n\tv104 = v99;\n\tv105 = 0x8907BC(v104, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003F:\n\tgoto L_0049;\n\tv110 = v63;\n\tv111 = 0x8907BC(v110, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0049:\n\tgoto L_004D;\n\tv78 = v65;\n\tv79 = 0x8907BC(v78, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_004D:\n\tv82 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0058;\n\tv90 = v82;\n\tv91 = 0x8907BC(v90, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0058:\n\treturnVal1 = *([v82 @ X19_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]) + 0x10;\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ref T Empty()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X20_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X19_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			return ref *(T*)(0L + 16L);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600005E")]
		[Address(RVA = "0xD96EFC", Offset = "0xD96EFC", Length = "0x350")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EFC1E8]);\n\tv23 = *([v22 @ X8_v64]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20240D6]) = v41;\nL_001A:\n\tgoto L_001E;\n\tv47 = v42;\n\tv48 = 0x8907BC(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001E:\n\tv51 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0027;\n\tv56 = v51;\n\tv57 = 0x8907BC(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = *([v51 @ X21_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0027:\n\tv61 = *([v51 @ X21_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv62 = v61 == 0;\n\tif (v62) goto L_0057;\n\tgoto L_0033;\n\tv85 = v63;\n\tv86 = 0x8907BC(v85, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0033:\n\tv79 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_003C;\n\tv102 = v79;\n\tv103 = 0x8907BC(v102, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003C:\n\tv104 = *([v79 @ X21_v29 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv73 = ~v104;\n\tif (v73) goto L_0057;\n\tgoto L_004D;\n\tv134 = v120;\n\tv135 = 0x8907BC(v134, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004D:\n\tgoto L_0057;\n\tv157 = v78;\n\tv158 = 0x8907BC(v157, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0057:\n\tgoto L_0060;\n\tv93 = v80;\n\tv94 = 0x8907BC(v93, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0060:\n\tgoto L_0069;\n\tv105 = v97;\n\tv106 = 0x8907BC(v105, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0069:\n\tv113 = *([id @ X0 (System.Int32&)]) * 0x28;\n\tv114 = v108.Components + v113;\n\t*([v114 @ X8_v13+40]) = 0;\n\t*([v114 @ X8_v13+20]) = 0;\n\t*([v114 @ X8_v13+30]) = 0;\n\tgoto L_0077;\n\tv125 = v115;\n\tv126 = 0x8907BC(v125, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_0077:\n\tv129 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_007F;\n\tv140 = v129;\n\tv141 = 0x8907BC(v140, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_007F:\n\tv143 = *([v129 @ X21_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tv156 = *([v143 @ X8_v17 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+C]) < *([id @ X0 (System.Int32&)]);\n\tif (v156) goto L_FFFFFFFF;\n\tgoto L_0097;\n\tv181 = v161;\n\tv182 = 0x8907BC(v181, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_0097:\n\tv185 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00A0;\n\tv211 = v185;\n\tv212 = 0x8907BC(v211, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\n\tv215 = *([v185 @ X21_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_00A0:\n\tv216 = *([v185 @ X21_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv217 = v216 == 0;\n\tif (v217) goto L_00D0;\n\tgoto L_00AC;\n\tv240 = v218;\n\tv241 = 0x8907BC(v240, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_00AC:\n\tv234 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00B5;\n\tv256 = v234;\n\tv257 = 0x8907BC(v256, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_00B5:\n\tv258 = *([v234 @ X21_v25 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv228 = ~v258;\n\tif (v228) goto L_00D0;\n\tgoto L_00C6;\n\tv270 = v264;\n\tv271 = 0x8907BC(v270, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_00C6:\n\tgoto L_00D0;\n\tv281 = v233;\n\tv282 = 0x8907BC(v281, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_00D0:\n\tgoto L_00D4;\n\tv248 = v235;\n\tv249 = 0x8907BC(v248, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_00D4:\n\tv179 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00DD;\n\tv259 = v179;\n\tv260 = 0x8907BC(v259, methodInfo, v25, v26, v27, v28, v29, v30, v111, v32, v33, v34, v35, v36, v37, v38);\nL_00DD:\n\tv177 = *([v179 @ X21_v16 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tv173 = System.Collections.Generic.Queue`1<System.Int32>::Contains(*([v177 @ X8_v29 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]), *([id @ X0 (System.Int32&)]));\n\tv175 = v173 == 0;\n\tif (v175) goto L_00ED;\n\tgoto L_0144;\nL_00ED:\n\tgoto L_00F1;\n\tv285 = v276;\n\tv286 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v285, v169, v167);\nL_00F1:\n\tv289 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00FA;\n\tv294 = v289;\n\tv295 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v294, v169, v167);\n\tv298 = *([v289 @ X21_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_00FA:\n\tv299 = *([v289 @ X21_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv300 = v299 == 0;\n\tif (v300) goto L_012A;\n\tgoto L_0106;\n\tv322 = v301;\n\tv323 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v322, v169, v167);\nL_0106:\n\tv316 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_010F;\n\tv337 = v316;\n\tv338 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v337, v169, v167);\nL_010F:\n\tv339 = *([v316 @ X21_v21 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv311 = ~v339;\n\tif (v311) goto L_012A;\n\tgoto L_0120;\n\tv350 = v345;\n\tv351 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v350, v169, v167);\nL_0120:\n\tgoto L_012A;\n\tv356 = v315;\n\tv357 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v356, v169, v167);\nL_012A:\n\tgoto L_012E;\n\tv330 = v317;\n\tv331 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v330, v169, v167);\nL_012E:\n\tv201 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0137;\n\tv340 = v201;\n\tv341 = System.Collections.Generic.Queue`1<System.Int32>::Contains(v340, v169, v167);\nL_0137:\n\tv203 = *([v201 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]);\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Enqueue(*([v203 @ X8_v38 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]), *([id @ X0 (System.Int32&)]));\nL_0144:\n\treturn returnVal1;\n// 195 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Remove(in int id)
		{
			//IL_0077: Expected O, but got I4
			//IL_0087: Expected O, but got I
			//IL_0176: Expected O, but got I
			//IL_0239: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X21_v3 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X21_v29 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			object obj = id * 40;
			object obj2 = (long)(IntPtr)Components + (long)(IntPtr)obj;
			_ = 0;
			_ = 0;
			_ = 0;
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X21_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v17 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+C]");
			if (0L >= (long)id)
			{
				IntPtr intPtr5 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ X21_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X21_v25 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X21_v16 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X8_v29 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]");
				if (!((Queue<int>)0).Contains(id))
				{
					IntPtr intPtr9 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X21_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr10 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ X21_v21 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					IntPtr intPtr11 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+B8]");
					IntPtr intPtr12 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X8_v38 (Il2CppStaticFields<Morpeh.CacheComponents`1<T>>)+38]");
					((Queue<int>)0).Enqueue(id);
					return true;
				}
			}
			return false;
		}
	}
}
