using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000D1")]
	internal static class InteropObjectFactory<T> where T : InteropObject
	{
		[Token(Token = "0x40003BF")]
		private static StrongToWeakDictionary<IntPtr, T> mBinders;

		[Token(Token = "0x6000795")]
		[Address(RVA = "0xD8C9C0", Offset = "0xD8C9C0", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = EasyMobile.Internal.PInvokeUtil::IsNull(pointer);\n\tv26 = v23 == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_00EB;\n\tgoto L_001C;\n\tv71 = v28;\n\tv72 = 0x8907BC(v71, v18, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\nL_001C:\n\tv88 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_0025;\n\tv108 = v88;\n\tv109 = 0x8907BC(v108, v18, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tv111 = *([v88 @ X22_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]);\nL_0025:\n\tv113 = *([v88 @ X22_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]) & 0x200;\n\tv114 = v113 == 0;\n\tif (v114) goto L_0050;\n\tgoto L_0031;\n\tv138 = v115;\n\tv139 = 0x8907BC(v138, v18, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\nL_0031:\n\tv128 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_003A;\n\tv157 = v128;\n\tv158 = 0x8907BC(v157, v18, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\nL_003A:\n\tv159 = *([v128 @ X22_v16 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]) == 0;\n\tv125 = ~v159;\n\tif (v125) goto L_0050;\n\tgoto L_004B;\n\tv173 = v166;\n\tv174 = 0x8907BC(v173, v18, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\nL_004B:\n\tgoto L_0050;\n\tv179 = v127;\n\tv180 = 0x8907BC(v179, v18, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\nL_0050:\n\tv132 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_005E;\n\tv146 = v132;\n\tv147 = 0x8907BC(v146, v18, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tv151 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv149 = *([v151 @ X22_v14 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_005E:\n\tv154 = *([v132 @ X23_v3 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0067;\n\tv161 = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, 0, methodInfo, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\nL_0067:\n\tv165 = EasyMobile.Internal.InteropObjectFactory`1<T>::FindExistingBinder(pointer);\n\tv55 = EasyMobile.Internal.InteropObject::op_Inequality(v165, 0);\n\tv172 = v55 == 0;\n\tv49 = ~v172;\n\tif (v49) goto L_00EB;\n\tv183 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_0080;\n\tv190 = v183;\n\tv191 = 0x8907BC(v190, v60, v39, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tv195 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv193 = *([v195 @ X22_v13 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_0080:\n\tv200 = *([v183 @ X23_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv201 = v200 == 0;\n\tv202 = ~v201;\n\tif (v202) goto L_008A;\n\tv204 = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, 0, 0, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\nL_008A:\n\tv210 = System.Func`2<System.IntPtr, T>::Invoke(constructor, pointer);\n\tgoto L_0095;\n\tv216 = v211;\n\tv217 = System.Func`2<System.IntPtr, T>::Invoke(v216, v208, v209);\nL_0095:\n\tv220 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_009E;\n\tv225 = v220;\n\tv226 = System.Func`2<System.IntPtr, T>::Invoke(v225, v208, v209);\n\tv228 = *([v220 @ X21_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]);\nL_009E:\n\tv230 = *([v220 @ X21_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]) & 0x200;\n\tv231 = v230 == 0;\n\tif (v231) goto L_00C9;\n\tgoto L_00AA;\n\tv254 = v232;\n\tv255 = System.Func`2<System.IntPtr, T>::Invoke(v254, v208, v209);\nL_00AA:\n\tv248 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_00B3;\n\tv271 = v248;\n\tv272 = System.Func`2<System.IntPtr, T>::Invoke(v271, v208, v209);\nL_00B3:\n\tv273 = *([v248 @ X21_v11 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]) == 0;\n\tv242 = ~v273;\n\tif (v242) goto L_00C9;\n\tgoto L_00C4;\n\tv283 = v278;\n\tv284 = System.Func`2<System.IntPtr, T>::Invoke(v283, v208, v209);\nL_00C4:\n\tgoto L_00C9;\n\tv289 = v247;\n\tv290 = System.Func`2<System.IntPtr, T>::Invoke(v289, v208, v209);\nL_00C9:\n\tv41 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_00D7;\n\tv262 = v41;\n\tv263 = System.Func`2<System.IntPtr, T>::Invoke(v262, v208, v209);\n\tv267 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv265 = *([v267 @ X21_v9 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_00D7:\n\tv269 = *([v41 @ X23_v7 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv270 = v269 == 0;\n\tv48 = ~v270;\n\tif (v48) goto L_00E1;\n\tv275 = System.Func`2<System.IntPtr, T>::Invoke(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, pointer);\nL_00E1:\n\tv54 = EasyMobile.Internal.InteropObjectFactory`1<T>::RegisterNewBinder(pointer, v210);\nL_00EB:\n\treturn v50;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T FromPointer(IntPtr pointer, Func<IntPtr, T> constructor)
		{
			//IL_019e: Expected O, but got I
			bool flag = PInvokeUtil.IsNull(pointer);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			T result = null;
			if (!flag3)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X22_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X22_v16 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X23_v3 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
				if (0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
				}
				InteropObject interopObject = FindExistingBinder(pointer);
				bool flag4 = interopObject != null;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = (T)interopObject;
				if (!flag6)
				{
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X23_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
					if (0 == 0)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
					}
					T val = constructor(pointer);
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X21_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr6 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X21_v11 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X23_v7 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
					if (0 == 0)
					{
						T val2 = ((Func<IntPtr, T>)0)(pointer);
					}
					RegisterNewBinder(pointer, val);
					result = val;
				}
			}
			return result;
		}

		[Token(Token = "0x6000796")]
		[Address(RVA = "0xD8CC44", Offset = "0xD8CC44", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F10070]);\n\tv29 = *([v28 @ X8_v55]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, ToPointer, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20240A6]) = v46;\nL_001B:\n\tv49 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_0029;\n\tv74 = v49;\n\tv75 = 0x8907BC(v74, ToPointer, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv79 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv78 = *([v79 @ X22_v30 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_0029:\n\tv81 = *([v49 @ X23_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0032;\n\tconstructor = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, ToPointer, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv63 = System.Func`1<T>::Invoke(constructor);\n\tv118 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_0044;\n\tv124 = v118;\n\tv125 = 0x8907BC(v124, v59, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv130 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv128 = *([v130 @ X22_v29 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_0044:\n\tv134 = *([v118 @ X23_v4 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_004E;\n\tconstructor = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_004E:\n\tv144 = System.Func`2<T, System.IntPtr>::Invoke(ToPointer, v63);\n\tgoto L_005A;\n\tv151 = v146;\n\tv152 = System.Func`2<T, System.IntPtr>::Invoke(v151, v142, v143);\nL_005A:\n\tv155 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_0063;\n\tv160 = v155;\n\tv161 = System.Func`2<T, System.IntPtr>::Invoke(v160, v142, v143);\n\tv164 = *([v155 @ X22_v8 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]);\nL_0063:\n\tv165 = *([v155 @ X22_v8 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]) & 0x200;\n\tv166 = v165 == 0;\n\tif (v166) goto L_008E;\n\tgoto L_006F;\n\tv190 = v167;\n\tv191 = System.Func`2<T, System.IntPtr>::Invoke(v190, v142, v143);\nL_006F:\n\tv183 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_0078;\n\tv211 = v183;\n\tv212 = System.Func`2<T, System.IntPtr>::Invoke(v211, v142, v143);\nL_0078:\n\tv213 = *([v183 @ X22_v26 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]) == 0;\n\tv177 = ~v213;\n\tif (v177) goto L_008E;\n\tgoto L_0089;\n\tv231 = v224;\n\tv232 = System.Func`2<T, System.IntPtr>::Invoke(v231, v142, v143);\nL_0089:\n\tgoto L_008E;\n\tv245 = v182;\n\tv246 = System.Func`2<T, System.IntPtr>::Invoke(v245, v142, v143);\nL_008E:\n\tv184 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_009C;\n\tv198 = v184;\n\tv199 = System.Func`2<T, System.IntPtr>::Invoke(v198, v142, v143);\n\tv204 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv202 = *([v204 @ X22_v24 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_009C:\n\tv208 = *([v184 @ X23_v6 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_00A5;\n\tv215 = System.Func`2<T, System.IntPtr>::Invoke(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, v63);\nL_00A5:\n\tv220 = EasyMobile.Internal.InteropObjectFactory`1<T>::FindExistingBinder(v144);\n\tv223 = EasyMobile.Internal.InteropObject::op_Equality(v220, 0);\n\tv230 = v223 == 0;\n\tif (v230) goto L_0105;\n\tgoto L_00B5;\n\tv249 = v237;\n\tv250 = 0x8907BC(v249, v221, v222, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B5:\n\tv253 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_00BE;\n\tv268 = v253;\n\tv269 = 0x8907BC(v268, v221, v222, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv272 = *([v253 @ X22_v15 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]);\nL_00BE:\n\tv273 = *([v253 @ X22_v15 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]) & 0x200;\n\tv274 = v273 == 0;\n\tif (v274) goto L_00E9;\n\tgoto L_00CA;\n\tv314 = v282;\n\tv315 = 0x8907BC(v314, v221, v222, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00CA:\n\tv298 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_00D3;\n\tv344 = v298;\n\tv345 = 0x8907BC(v344, v221, v222, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00D3:\n\tv346 = *([v298 @ X22_v21 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]) == 0;\n\tv292 = ~v346;\n\tif (v292) goto L_00E9;\n\tgoto L_00E4;\n\tv356 = v351;\n\tv357 = 0x8907BC(v356, v221, v222, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00E4:\n\tgoto L_00E9;\n\tv362 = v297;\n\tv363 = 0x8907BC(v362, v221, v222, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00E9:\n\tv299 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_00F7;\n\tv322 = v299;\n\tv323 = 0x8907BC(v322, v221, v222, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv328 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv326 = *([v328 @ X22_v19 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_00F7:\n\tv332 = *([v299 @ X23_v10 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv333 = v332 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_0101;\n\tconstructor = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0101:\n\tconstructor = EasyMobile.Internal.InteropObjectFactory`1<T>::RegisterNewBinder(v144, v63);\n\tgoto L_012A;\nL_0105:\n\tv244 = 0xDC4DD4(&v144 @ X0_v12 (System.IntPtr), 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv267 = System.String::Concat(\"A binder for pointer \", v244, \" already exists. Consider using FromPointer() instead.\");\n\tgoto L_0120;\n\tv305 = *([v278 @ X8_v24+E0]);\n\tv306 = v305 == 0;\n\tv307 = ~v306;\n\tif (v307) goto L_0120;\n\tv335 = v278;\n\tv310 = \"il2cpp_codegen_runtime_class_init\"(v335, v262, v265, v264, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0120:\n\tUnityEngine.Debug::LogWarning(v267);\nL_012A:\n\treturn v63;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Create(Func<T> constructor, Func<T, IntPtr> ToPointer)
		{
			//IL_00d6: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X23_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
			}
			T val = constructor();
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X23_v4 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
			}
			IntPtr pointer = ToPointer(val);
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X22_v8 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X22_v26 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr5 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X23_v6 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
			if (0 == 0)
			{
				IntPtr intPtr6 = ((Func<T, IntPtr>)0)(val);
			}
			InteropObject interopObject = FindExistingBinder(pointer);
			if (interopObject == null)
			{
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X22_v15 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr8 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X22_v21 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ X23_v10 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
				if (0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
				}
				RegisterNewBinder(pointer, val);
			}
			else
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC4DD4 (inside System.IntPtr::get_Size +0x158)");
				string text = default(string);
				string message = "A binder for pointer " + text + " already exists. Consider using FromPointer() instead.";
				Debug.LogWarning(message);
			}
			return val;
		}

		[Token(Token = "0x6000797")]
		[Address(RVA = "0xD8CF9C", Offset = "0xD8CF9C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv26 = v19;\n\tv27 = 0x8907BC(v26, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0015:\n\tv44 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_001E;\n\tv49 = v44;\n\tv50 = 0x8907BC(v49, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv53 = *([v44 @ X21_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]);\nL_001E:\n\tv54 = *([v44 @ X21_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]) & 0x200;\n\tv55 = v54 == 0;\n\tif (v55) goto L_004E;\n\tgoto L_002A;\n\tv78 = v56;\n\tv79 = 0x8907BC(v78, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002A:\n\tv72 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_0033;\n\tv95 = v72;\n\tv96 = 0x8907BC(v95, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\tv97 = *([v72 @ X21_v10 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]) == 0;\n\tv66 = ~v97;\n\tif (v66) goto L_004E;\n\tgoto L_0044;\n\tv139 = v104;\n\tv140 = 0x8907BC(v139, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0044:\n\tgoto L_004E;\n\tv155 = v71;\n\tv156 = 0x8907BC(v155, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004E:\n\tgoto L_0057;\n\tv86 = v73;\n\tv87 = 0x8907BC(v86, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0057:\n\tgoto L_005E;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005E:\n\tv109 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_006C;\n\tv145 = v109;\n\tv146 = 0x8907BC(v145, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv147 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv150 = *([v147 @ X22_v5 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_006C:\n\tv152 = *([v109 @ X23_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_0077;\n\tv160 = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0077:\n\tv128 = EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>::TryGetValue(v101.mBinders, pointer, &v134 @ stack_-38_v3 (T));\n\tv165 = v128 == 0;\n\tif (v165) goto L_FFFFFFFF;\n\tv228 = *([v134 @ stack_-38_v3 (T)+28]) == 0;\n\tv233 = ~v228;\n\tv234 = ~v233;\n\tif (v234) goto L_FFFFFFFF;\n\tgoto L_008F;\nL_008F:\n\tgoto L_0099;\nL_0099:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static T FindExistingBinder(IntPtr pointer)
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X21_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X21_v10 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X23_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
			}
			if (mBinders.TryGetValue(pointer, out var value))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ stack_-38_v3 (T)+28]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					return null;
				}
				return value;
			}
			return null;
		}

		[Token(Token = "0x6000798")]
		[Address(RVA = "0xD8D11C", Offset = "0xD8D11C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv29 = v20;\n\tv30 = 0x8907BC(v29, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0016:\n\tv46 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_001F;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = *([v46 @ X22_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]);\nL_001F:\n\tv56 = *([v46 @ X22_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_004F;\n\tgoto L_002B;\n\tv80 = v58;\n\tv81 = 0x8907BC(v80, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002B:\n\tv74 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>;\n\tgoto L_0034;\n\tv97 = v74;\n\tv98 = 0x8907BC(v97, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0034:\n\tv99 = *([v74 @ X22_v10 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]) == 0;\n\tv68 = ~v99;\n\tif (v68) goto L_004F;\n\tgoto L_0045;\n\tv119 = v106;\n\tv120 = 0x8907BC(v119, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0045:\n\tgoto L_004F;\n\tv138 = v73;\n\tv139 = 0x8907BC(v138, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_004F:\n\tgoto L_0058;\n\tv88 = v75;\n\tv89 = 0x8907BC(v88, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0058:\n\tgoto L_005F;\n\tv100 = v92;\n\tv101 = 0x8907BC(v100, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005F:\n\tv111 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_006B;\n\tv125 = v111;\n\tv126 = 0x8907BC(v125, newBinder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv128 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv131 = *([v128 @ X23_v4 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_006B:\n\tv133 = Il2CppMethodInfo;\n\tv135 = *([v111 @ X24_v1 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0083;\n\tv144 = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, newBinder, methodInfo, v31, *([v133 @ X9_v2 (Il2CppMethodInfo)]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0083:\n\t// 131 IndirectJump [v133 @ X9_v2 (Il2CppMethodInfo)], v103.mBinders (EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>), v103.mBinders (EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>), pointer @ X0 (System.IntPtr), newBinder @ X1 (T), methodof(EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>::Put), [v133 @ X9_v2 (Il2CppMethodInfo)], v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void RegisterNewBinder(IntPtr pointer, T newBinder)
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X22_v2 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X22_v10 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr3 = (IntPtr)0;
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X24_v1 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v133 @ X9_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000799")]
		[Address(RVA = "0xD8D288", Offset = "0xD8D288", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv21 = v16;\n\tv22 = 0x8907BC(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0017:\n\tgoto L_001B;\n\tv45 = v40;\n\tv46 = 0x8907BC(v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001B:\n\tv49 = new Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>>();\n\tv50 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tgoto L_002B;\n\tv57 = v50;\n\tv58 = 0x8907BC(v57, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv60 = Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>;\n\tv63 = *([v60 @ X21_v4 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]);\nL_002B:\n\tv67 = *([v50 @ X22_v1 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]) & 1;\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0034;\n\tv71 = 0x8907BC(Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv76 = EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>::.ctor(v49);\n\tgoto L_0043;\n\tv82 = v77;\n\tv83 = EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>::.ctor(v82, v75);\nL_0043:\n\tgoto L_0047;\n\tv91 = v86;\n\tv92 = EasyMobile.Internal.StrongToWeakDictionary`2<System.IntPtr, T>::.ctor(v91, v75);\nL_0047:\n\tv94.mBinders = v49;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static InteropObjectFactory()
		{
			StrongToWeakDictionary<IntPtr, T> strongToWeakDictionary = new StrongToWeakDictionary<IntPtr, T>();
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X22_v1 (Il2CppClass<EasyMobile.Internal.InteropObjectFactory`1>)+12E]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
			}
			mBinders = strongToWeakDictionary;
		}
	}
}
