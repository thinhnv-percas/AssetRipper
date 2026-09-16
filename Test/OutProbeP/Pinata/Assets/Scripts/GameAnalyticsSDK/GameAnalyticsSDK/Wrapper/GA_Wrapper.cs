using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Setup;
using GameAnalyticsSDK.State;
using GameAnalyticsSDK.Utilities;
using UnityEngine;

namespace GameAnalyticsSDK.Wrapper
{
	[Token(Token = "0x200000A")]
	public class GA_Wrapper
	{
		[Token(Token = "0x4000031")]
		private static readonly AndroidJavaClass GA;

		[Token(Token = "0x4000032")]
		private static readonly AndroidJavaClass UNITY_GA;

		[Token(Token = "0x4000033")]
		private static readonly AndroidJavaClass GA_IMEI;

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x15A9A40", Offset = "0x15A9A40", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EED0F8]);\n\tv23 = *([v22 @ X8_v48]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029857]) = v42;\nL_0015:\n\tv43 = list == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Parser::Parse(list);\n\tgoto L_001F;\nL_001F:\n\tv53 = new System.Collections.ArrayList();\n\tSystem.Collections.ArrayList::.ctor(v53);\n\t// 39 IsInst v60 @ X0_v6, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tv61 = v60 == 0;\n\tif (v61) goto L_00D2;\n\t// 47 IsInst v67 @ X0_v48, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tgoto L_005C;\n\tv131 = *([v128 @ X8_v31+B0]);\n\tv132 = 0;\n\tv133 = v131 + 8;\n\tv135 = *([v183 @ X11_v30-8]);\n\tv188 = v135 == v66;\n\tif (v188) goto L_0055;\n\tv155 = v182 + 1;\n\tv195 = v155 < v129;\n\tv153 = ~v195;\n\tv157 = v183 + 0x10;\n\tv137 = ~v153;\n\tif (v137) goto L_FFFFFFFF;\n\tv158 = v127;\n\tv159 = v66;\n\tv160 = 0;\n\tv161 = 0x8909C4(v158, v159, v160, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_005C;\nL_0055:\n\tv196 = *([v183 @ X11_v30]);\n\tv197 = v196 << 4;\n\tv198 = v128 + v197;\n\tv199 = v198 + 0x130;\nL_005C:\n\tv221 = System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator(v67);\nL_0068:\n\tgoto L_008F;\n\tv444 = *([v355 @ X8_v36+B0]);\n\tv445 = 0;\n\tv446 = v444 + 8;\n\tv448 = *([v568 @ X11_v25-8]);\n\tv573 = v448 == v356;\n\tif (v573) goto L_0088;\n\tv468 = v567 + 1;\n\tv620 = v468 < v357;\n\tv466 = ~v620;\n\tv470 = v568 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_FFFFFFFF;\n\tv471 = v125;\n\tv472 = 0;\n\tv473 = 0x8909C4(v471, v356, v472, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_008F;\nL_0088:\n\tv621 = *([v568 @ X11_v25]);\n\tv622 = v621 << 4;\n\tv623 = v355 + v622;\n\tv624 = v623 + 0x130;\nL_008F:\n\tv398 = System.Collections.IEnumerator::MoveNext(v221);\n\tv629 = v398 == 0;\n\tif (v629) goto L_00CA;\n\tgoto L_00BE;\n\tv661 = *([v646 @ X8_v39+B0]);\n\tv662 = 0;\n\tv663 = v661 + 8;\n\tv665 = *([v705 @ X11_v20-8]);\n\tv710 = v665 == v647;\n\tif (v710) goto L_00B7;\n\tv685 = v704 + 1;\n\tv722 = v685 < v648;\n\tv683 = ~v722;\n\tv687 = v705 + 0x10;\n\tv667 = ~v683;\n\tif (v667) goto L_FFFFFFFF;\n\tv688 = v125;\n\tv689 = 0;\n\tv690 = 0x8909C4(v688, v647, v689, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00BE;\nL_00B7:\n\tv723 = *([v705 @ X11_v20]);\n\tv724 = v723 << 4;\n\tv725 = v646 + v724;\n\tv726 = v725 + 0x130;\nL_00BE:\n\tv477 = System.Collections.Generic.IEnumerator`1<System.Object>::get_Current(v221);\n\tv306 = System.Collections.ArrayList::Add(v53, v477);\n\tgoto L_0068;\nL_00CA:\n\tv650 = v221 == 0;\n\tv400 = ~v650;\n\tif (v400) goto L_00EE;\n\tgoto L_0116;\n\tthrow System.NullReferenceException;\n\tv119 = new System.NullReferenceException();\nL_00D2:\n\tv126 = new System.NullReferenceException();\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\nL_00E0:\n\tv171 = v116 != 1;\n\tif (v171) goto L_0176;\n\tv193 = 0x6D2BC0(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv391 = *([v193 @ X0_v45]);\n\tv225 = 0x6D2490(v193, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv313 = v221 == 0;\n\tif (v313) goto L_0116;\nL_00EE:\n\tgoto L_0115;\n\tv480 = *([v405 @ X8_v24+B0]);\n\tv481 = 0;\n\tv482 = v480 + 8;\n\tv484 = *([v589 @ X11_v9-8]);\n\tv594 = v484 == v408;\n\tif (v594) goto L_010E;\n\tv504 = v588 + 1;\n\tv630 = v504 < v407;\n\tv502 = ~v630;\n\tv506 = v589 + 0x10;\n\tv486 = ~v502;\n\tif (v486) goto L_FFFFFFFF;\n\tv507 = v403;\n\tv508 = 0;\n\tv509 = 0x8909C4(v507, v408, v508, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0115;\nL_010E:\n\tv631 = *([v589 @ X11_v9]);\n\tv632 = v631 << 4;\n\tv633 = v405 + v632;\n\tv634 = v633 + 0x130;\nL_0115:\n\tSystem.IDisposable::Dispose(v403);\nL_0116:\n\tv443 = v434 + 1;\n\tv243 = v443 == 0;\n\tv233 = ~v243;\n\tif (v233) goto L_0126;\n\tv510 = v433 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_0173;\nL_0126:\n\tgoto L_0133;\n\tv607 = *([v515 @ X0_v10 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_0133;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v515, v435, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv611 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0133:\n\t// 307 NewArr v619 @ X0_v13 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_0147;\n\tv651 = *([v642 @ X8_v12+E0]);\n\tv652 = v651 == 0;\n\tv653 = ~v652;\n\tgoto L_0147;\n\tv691 = v642;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v691, v617, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0147:\n\tv660 = System.Type::GetTypeFromHandle(System.String);\n\tv717 = System.Collections.ArrayList::ToArray(v53, v660);\n\tv731 = v717 == 0;\n\tif (v731) goto L_015C;\n\t// 344 IsInst v263 @ X0_v26, typeof(System.Object), v717 @ X0_v21 (System.Array)\nL_015C:\n\tv344 = v619.Length == 0;\n\tif (v344) goto L_0174;\n\tv619[0] = v717;\n\tUnityEngine.AndroidJavaObject::CallStatic(v615.GA, \"configureAvailableCustomDimensions01\", v619);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0173:\n\tgoto L_017A;\nL_0174:\n\tv341 = new System.IndexOutOfRangeException();\n\tgoto L_017A;\nL_0176:\n\tv194 = 0x6D2380(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv272 = new System.ArrayTypeMismatchException();\nL_017A:\n\tthrow System.TypeLoadException;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureAvailableCustomDimensions01(string list)
		{
			//IL_011f: Expected I4, but got O
			//IL_015b: Expected I4, but got O
			object obj2;
			if (list != null)
			{
				object obj = GA_MiniJSON.Parser.Parse(list);
				obj2 = obj;
			}
			else
			{
				obj2 = null;
			}
			ArrayList arrayList = new ArrayList();
			object obj3 = obj2 as IList<object>;
			int num2;
			int num3;
			IDisposable disposable;
			int num5;
			int num6;
			int num4;
			if (obj3 != null)
			{
				object obj4 = obj2 as IList<object>;
				IEnumerator enumerator = ((IEnumerable<object>)obj4).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = ((IEnumerator<object>)enumerator).Current;
					int num = arrayList.Add(current);
				}
				bool flag = enumerator == null;
				bool flag2 = !flag;
				num2 = 0;
				num3 = 0;
				disposable = (IDisposable)enumerator;
				if (!flag2)
				{
					num4 = 0;
					num5 = 0;
					num6 = 0;
					goto IL_0308;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					goto IL_027b;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num2 = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator enumerator = default(IEnumerator);
				bool flag3 = enumerator == null;
				num3 = -1;
				disposable = (IDisposable)enumerator;
				num5 = (int)obj5;
				num6 = -1;
				if (flag3)
				{
					goto IL_0308;
				}
			}
			disposable.Dispose();
			num4 = 0;
			num5 = num2;
			num6 = num3;
			goto IL_0308;
			IL_027b:
			throw new TypeLoadException();
			IL_0308:
			if (num6 + 1 != 0 || num5 == 0)
			{
				object[] array = new object[1];
				Type typeFromHandle = typeof(string);
				Array array2 = arrayList.ToArray(typeFromHandle);
				if (array2 != null)
				{
					object obj6 = array2 as object;
				}
				if (array.Length != 0)
				{
					array[0] = array2;
					GA.CallStatic("configureAvailableCustomDimensions01", array);
					return;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			}
			goto IL_027b;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x15A9E20", Offset = "0x15A9E20", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC4400]);\n\tv23 = *([v22 @ X8_v48]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029858]) = v42;\nL_0015:\n\tv43 = list == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Parser::Parse(list);\n\tgoto L_001F;\nL_001F:\n\tv53 = new System.Collections.ArrayList();\n\tSystem.Collections.ArrayList::.ctor(v53);\n\t// 39 IsInst v60 @ X0_v6, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tv61 = v60 == 0;\n\tif (v61) goto L_00D2;\n\t// 47 IsInst v67 @ X0_v48, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tgoto L_005C;\n\tv131 = *([v128 @ X8_v31+B0]);\n\tv132 = 0;\n\tv133 = v131 + 8;\n\tv135 = *([v183 @ X11_v30-8]);\n\tv188 = v135 == v66;\n\tif (v188) goto L_0055;\n\tv155 = v182 + 1;\n\tv195 = v155 < v129;\n\tv153 = ~v195;\n\tv157 = v183 + 0x10;\n\tv137 = ~v153;\n\tif (v137) goto L_FFFFFFFF;\n\tv158 = v127;\n\tv159 = v66;\n\tv160 = 0;\n\tv161 = 0x8909C4(v158, v159, v160, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_005C;\nL_0055:\n\tv196 = *([v183 @ X11_v30]);\n\tv197 = v196 << 4;\n\tv198 = v128 + v197;\n\tv199 = v198 + 0x130;\nL_005C:\n\tv221 = System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator(v67);\nL_0068:\n\tgoto L_008F;\n\tv444 = *([v355 @ X8_v36+B0]);\n\tv445 = 0;\n\tv446 = v444 + 8;\n\tv448 = *([v568 @ X11_v25-8]);\n\tv573 = v448 == v356;\n\tif (v573) goto L_0088;\n\tv468 = v567 + 1;\n\tv620 = v468 < v357;\n\tv466 = ~v620;\n\tv470 = v568 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_FFFFFFFF;\n\tv471 = v125;\n\tv472 = 0;\n\tv473 = 0x8909C4(v471, v356, v472, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_008F;\nL_0088:\n\tv621 = *([v568 @ X11_v25]);\n\tv622 = v621 << 4;\n\tv623 = v355 + v622;\n\tv624 = v623 + 0x130;\nL_008F:\n\tv398 = System.Collections.IEnumerator::MoveNext(v221);\n\tv629 = v398 == 0;\n\tif (v629) goto L_00CA;\n\tgoto L_00BE;\n\tv661 = *([v646 @ X8_v39+B0]);\n\tv662 = 0;\n\tv663 = v661 + 8;\n\tv665 = *([v705 @ X11_v20-8]);\n\tv710 = v665 == v647;\n\tif (v710) goto L_00B7;\n\tv685 = v704 + 1;\n\tv722 = v685 < v648;\n\tv683 = ~v722;\n\tv687 = v705 + 0x10;\n\tv667 = ~v683;\n\tif (v667) goto L_FFFFFFFF;\n\tv688 = v125;\n\tv689 = 0;\n\tv690 = 0x8909C4(v688, v647, v689, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00BE;\nL_00B7:\n\tv723 = *([v705 @ X11_v20]);\n\tv724 = v723 << 4;\n\tv725 = v646 + v724;\n\tv726 = v725 + 0x130;\nL_00BE:\n\tv477 = System.Collections.Generic.IEnumerator`1<System.Object>::get_Current(v221);\n\tv306 = System.Collections.ArrayList::Add(v53, v477);\n\tgoto L_0068;\nL_00CA:\n\tv650 = v221 == 0;\n\tv400 = ~v650;\n\tif (v400) goto L_00EE;\n\tgoto L_0116;\n\tthrow System.NullReferenceException;\n\tv119 = new System.NullReferenceException();\nL_00D2:\n\tv126 = new System.NullReferenceException();\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\nL_00E0:\n\tv171 = v116 != 1;\n\tif (v171) goto L_0176;\n\tv193 = 0x6D2BC0(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv391 = *([v193 @ X0_v45]);\n\tv225 = 0x6D2490(v193, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv313 = v221 == 0;\n\tif (v313) goto L_0116;\nL_00EE:\n\tgoto L_0115;\n\tv480 = *([v405 @ X8_v24+B0]);\n\tv481 = 0;\n\tv482 = v480 + 8;\n\tv484 = *([v589 @ X11_v9-8]);\n\tv594 = v484 == v408;\n\tif (v594) goto L_010E;\n\tv504 = v588 + 1;\n\tv630 = v504 < v407;\n\tv502 = ~v630;\n\tv506 = v589 + 0x10;\n\tv486 = ~v502;\n\tif (v486) goto L_FFFFFFFF;\n\tv507 = v403;\n\tv508 = 0;\n\tv509 = 0x8909C4(v507, v408, v508, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0115;\nL_010E:\n\tv631 = *([v589 @ X11_v9]);\n\tv632 = v631 << 4;\n\tv633 = v405 + v632;\n\tv634 = v633 + 0x130;\nL_0115:\n\tSystem.IDisposable::Dispose(v403);\nL_0116:\n\tv443 = v434 + 1;\n\tv243 = v443 == 0;\n\tv233 = ~v243;\n\tif (v233) goto L_0126;\n\tv510 = v433 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_0173;\nL_0126:\n\tgoto L_0133;\n\tv607 = *([v515 @ X0_v10 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_0133;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v515, v435, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv611 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0133:\n\t// 307 NewArr v619 @ X0_v13 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_0147;\n\tv651 = *([v642 @ X8_v12+E0]);\n\tv652 = v651 == 0;\n\tv653 = ~v652;\n\tgoto L_0147;\n\tv691 = v642;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v691, v617, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0147:\n\tv660 = System.Type::GetTypeFromHandle(System.String);\n\tv717 = System.Collections.ArrayList::ToArray(v53, v660);\n\tv731 = v717 == 0;\n\tif (v731) goto L_015C;\n\t// 344 IsInst v263 @ X0_v26, typeof(System.Object), v717 @ X0_v21 (System.Array)\nL_015C:\n\tv344 = v619.Length == 0;\n\tif (v344) goto L_0174;\n\tv619[0] = v717;\n\tUnityEngine.AndroidJavaObject::CallStatic(v615.GA, \"configureAvailableCustomDimensions02\", v619);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0173:\n\tgoto L_017A;\nL_0174:\n\tv341 = new System.IndexOutOfRangeException();\n\tgoto L_017A;\nL_0176:\n\tv194 = 0x6D2380(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv272 = new System.ArrayTypeMismatchException();\nL_017A:\n\tthrow System.TypeLoadException;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureAvailableCustomDimensions02(string list)
		{
			//IL_011f: Expected I4, but got O
			//IL_015b: Expected I4, but got O
			object obj2;
			if (list != null)
			{
				object obj = GA_MiniJSON.Parser.Parse(list);
				obj2 = obj;
			}
			else
			{
				obj2 = null;
			}
			ArrayList arrayList = new ArrayList();
			object obj3 = obj2 as IList<object>;
			int num2;
			int num3;
			IDisposable disposable;
			int num5;
			int num6;
			int num4;
			if (obj3 != null)
			{
				object obj4 = obj2 as IList<object>;
				IEnumerator enumerator = ((IEnumerable<object>)obj4).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = ((IEnumerator<object>)enumerator).Current;
					int num = arrayList.Add(current);
				}
				bool flag = enumerator == null;
				bool flag2 = !flag;
				num2 = 0;
				num3 = 0;
				disposable = (IDisposable)enumerator;
				if (!flag2)
				{
					num4 = 0;
					num5 = 0;
					num6 = 0;
					goto IL_0308;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					goto IL_027b;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num2 = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator enumerator = default(IEnumerator);
				bool flag3 = enumerator == null;
				num3 = -1;
				disposable = (IDisposable)enumerator;
				num5 = (int)obj5;
				num6 = -1;
				if (flag3)
				{
					goto IL_0308;
				}
			}
			disposable.Dispose();
			num4 = 0;
			num5 = num2;
			num6 = num3;
			goto IL_0308;
			IL_027b:
			throw new TypeLoadException();
			IL_0308:
			if (num6 + 1 != 0 || num5 == 0)
			{
				object[] array = new object[1];
				Type typeFromHandle = typeof(string);
				Array array2 = arrayList.ToArray(typeFromHandle);
				if (array2 != null)
				{
					object obj6 = array2 as object;
				}
				if (array.Length != 0)
				{
					array[0] = array2;
					GA.CallStatic("configureAvailableCustomDimensions02", array);
					return;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			}
			goto IL_027b;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x15AA200", Offset = "0x15AA200", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECBE18]);\n\tv23 = *([v22 @ X8_v48]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029859]) = v42;\nL_0015:\n\tv43 = list == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Parser::Parse(list);\n\tgoto L_001F;\nL_001F:\n\tv53 = new System.Collections.ArrayList();\n\tSystem.Collections.ArrayList::.ctor(v53);\n\t// 39 IsInst v60 @ X0_v6, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tv61 = v60 == 0;\n\tif (v61) goto L_00D2;\n\t// 47 IsInst v67 @ X0_v48, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tgoto L_005C;\n\tv131 = *([v128 @ X8_v31+B0]);\n\tv132 = 0;\n\tv133 = v131 + 8;\n\tv135 = *([v183 @ X11_v30-8]);\n\tv188 = v135 == v66;\n\tif (v188) goto L_0055;\n\tv155 = v182 + 1;\n\tv195 = v155 < v129;\n\tv153 = ~v195;\n\tv157 = v183 + 0x10;\n\tv137 = ~v153;\n\tif (v137) goto L_FFFFFFFF;\n\tv158 = v127;\n\tv159 = v66;\n\tv160 = 0;\n\tv161 = 0x8909C4(v158, v159, v160, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_005C;\nL_0055:\n\tv196 = *([v183 @ X11_v30]);\n\tv197 = v196 << 4;\n\tv198 = v128 + v197;\n\tv199 = v198 + 0x130;\nL_005C:\n\tv221 = System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator(v67);\nL_0068:\n\tgoto L_008F;\n\tv444 = *([v355 @ X8_v36+B0]);\n\tv445 = 0;\n\tv446 = v444 + 8;\n\tv448 = *([v568 @ X11_v25-8]);\n\tv573 = v448 == v356;\n\tif (v573) goto L_0088;\n\tv468 = v567 + 1;\n\tv620 = v468 < v357;\n\tv466 = ~v620;\n\tv470 = v568 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_FFFFFFFF;\n\tv471 = v125;\n\tv472 = 0;\n\tv473 = 0x8909C4(v471, v356, v472, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_008F;\nL_0088:\n\tv621 = *([v568 @ X11_v25]);\n\tv622 = v621 << 4;\n\tv623 = v355 + v622;\n\tv624 = v623 + 0x130;\nL_008F:\n\tv398 = System.Collections.IEnumerator::MoveNext(v221);\n\tv629 = v398 == 0;\n\tif (v629) goto L_00CA;\n\tgoto L_00BE;\n\tv661 = *([v646 @ X8_v39+B0]);\n\tv662 = 0;\n\tv663 = v661 + 8;\n\tv665 = *([v705 @ X11_v20-8]);\n\tv710 = v665 == v647;\n\tif (v710) goto L_00B7;\n\tv685 = v704 + 1;\n\tv722 = v685 < v648;\n\tv683 = ~v722;\n\tv687 = v705 + 0x10;\n\tv667 = ~v683;\n\tif (v667) goto L_FFFFFFFF;\n\tv688 = v125;\n\tv689 = 0;\n\tv690 = 0x8909C4(v688, v647, v689, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00BE;\nL_00B7:\n\tv723 = *([v705 @ X11_v20]);\n\tv724 = v723 << 4;\n\tv725 = v646 + v724;\n\tv726 = v725 + 0x130;\nL_00BE:\n\tv477 = System.Collections.Generic.IEnumerator`1<System.Object>::get_Current(v221);\n\tv306 = System.Collections.ArrayList::Add(v53, v477);\n\tgoto L_0068;\nL_00CA:\n\tv650 = v221 == 0;\n\tv400 = ~v650;\n\tif (v400) goto L_00EE;\n\tgoto L_0116;\n\tthrow System.NullReferenceException;\n\tv119 = new System.NullReferenceException();\nL_00D2:\n\tv126 = new System.NullReferenceException();\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\nL_00E0:\n\tv171 = v116 != 1;\n\tif (v171) goto L_0176;\n\tv193 = 0x6D2BC0(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv391 = *([v193 @ X0_v45]);\n\tv225 = 0x6D2490(v193, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv313 = v221 == 0;\n\tif (v313) goto L_0116;\nL_00EE:\n\tgoto L_0115;\n\tv480 = *([v405 @ X8_v24+B0]);\n\tv481 = 0;\n\tv482 = v480 + 8;\n\tv484 = *([v589 @ X11_v9-8]);\n\tv594 = v484 == v408;\n\tif (v594) goto L_010E;\n\tv504 = v588 + 1;\n\tv630 = v504 < v407;\n\tv502 = ~v630;\n\tv506 = v589 + 0x10;\n\tv486 = ~v502;\n\tif (v486) goto L_FFFFFFFF;\n\tv507 = v403;\n\tv508 = 0;\n\tv509 = 0x8909C4(v507, v408, v508, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0115;\nL_010E:\n\tv631 = *([v589 @ X11_v9]);\n\tv632 = v631 << 4;\n\tv633 = v405 + v632;\n\tv634 = v633 + 0x130;\nL_0115:\n\tSystem.IDisposable::Dispose(v403);\nL_0116:\n\tv443 = v434 + 1;\n\tv243 = v443 == 0;\n\tv233 = ~v243;\n\tif (v233) goto L_0126;\n\tv510 = v433 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_0173;\nL_0126:\n\tgoto L_0133;\n\tv607 = *([v515 @ X0_v10 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_0133;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v515, v435, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv611 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0133:\n\t// 307 NewArr v619 @ X0_v13 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_0147;\n\tv651 = *([v642 @ X8_v12+E0]);\n\tv652 = v651 == 0;\n\tv653 = ~v652;\n\tgoto L_0147;\n\tv691 = v642;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v691, v617, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0147:\n\tv660 = System.Type::GetTypeFromHandle(System.String);\n\tv717 = System.Collections.ArrayList::ToArray(v53, v660);\n\tv731 = v717 == 0;\n\tif (v731) goto L_015C;\n\t// 344 IsInst v263 @ X0_v26, typeof(System.Object), v717 @ X0_v21 (System.Array)\nL_015C:\n\tv344 = v619.Length == 0;\n\tif (v344) goto L_0174;\n\tv619[0] = v717;\n\tUnityEngine.AndroidJavaObject::CallStatic(v615.GA, \"configureAvailableCustomDimensions03\", v619);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0173:\n\tgoto L_017A;\nL_0174:\n\tv341 = new System.IndexOutOfRangeException();\n\tgoto L_017A;\nL_0176:\n\tv194 = 0x6D2380(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv272 = new System.ArrayTypeMismatchException();\nL_017A:\n\tthrow System.TypeLoadException;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureAvailableCustomDimensions03(string list)
		{
			//IL_011f: Expected I4, but got O
			//IL_015b: Expected I4, but got O
			object obj2;
			if (list != null)
			{
				object obj = GA_MiniJSON.Parser.Parse(list);
				obj2 = obj;
			}
			else
			{
				obj2 = null;
			}
			ArrayList arrayList = new ArrayList();
			object obj3 = obj2 as IList<object>;
			int num2;
			int num3;
			IDisposable disposable;
			int num5;
			int num6;
			int num4;
			if (obj3 != null)
			{
				object obj4 = obj2 as IList<object>;
				IEnumerator enumerator = ((IEnumerable<object>)obj4).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = ((IEnumerator<object>)enumerator).Current;
					int num = arrayList.Add(current);
				}
				bool flag = enumerator == null;
				bool flag2 = !flag;
				num2 = 0;
				num3 = 0;
				disposable = (IDisposable)enumerator;
				if (!flag2)
				{
					num4 = 0;
					num5 = 0;
					num6 = 0;
					goto IL_0308;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					goto IL_027b;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num2 = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator enumerator = default(IEnumerator);
				bool flag3 = enumerator == null;
				num3 = -1;
				disposable = (IDisposable)enumerator;
				num5 = (int)obj5;
				num6 = -1;
				if (flag3)
				{
					goto IL_0308;
				}
			}
			disposable.Dispose();
			num4 = 0;
			num5 = num2;
			num6 = num3;
			goto IL_0308;
			IL_027b:
			throw new TypeLoadException();
			IL_0308:
			if (num6 + 1 != 0 || num5 == 0)
			{
				object[] array = new object[1];
				Type typeFromHandle = typeof(string);
				Array array2 = arrayList.ToArray(typeFromHandle);
				if (array2 != null)
				{
					object obj6 = array2 as object;
				}
				if (array.Length != 0)
				{
					array[0] = array2;
					GA.CallStatic("configureAvailableCustomDimensions03", array);
					return;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			}
			goto IL_027b;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x15AA5E0", Offset = "0x15AA5E0", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F044D8]);\n\tv23 = *([v22 @ X8_v48]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202985A]) = v42;\nL_0015:\n\tv43 = list == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Parser::Parse(list);\n\tgoto L_001F;\nL_001F:\n\tv53 = new System.Collections.ArrayList();\n\tSystem.Collections.ArrayList::.ctor(v53);\n\t// 39 IsInst v60 @ X0_v6, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tv61 = v60 == 0;\n\tif (v61) goto L_00D2;\n\t// 47 IsInst v67 @ X0_v48, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tgoto L_005C;\n\tv131 = *([v128 @ X8_v31+B0]);\n\tv132 = 0;\n\tv133 = v131 + 8;\n\tv135 = *([v183 @ X11_v30-8]);\n\tv188 = v135 == v66;\n\tif (v188) goto L_0055;\n\tv155 = v182 + 1;\n\tv195 = v155 < v129;\n\tv153 = ~v195;\n\tv157 = v183 + 0x10;\n\tv137 = ~v153;\n\tif (v137) goto L_FFFFFFFF;\n\tv158 = v127;\n\tv159 = v66;\n\tv160 = 0;\n\tv161 = 0x8909C4(v158, v159, v160, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_005C;\nL_0055:\n\tv196 = *([v183 @ X11_v30]);\n\tv197 = v196 << 4;\n\tv198 = v128 + v197;\n\tv199 = v198 + 0x130;\nL_005C:\n\tv221 = System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator(v67);\nL_0068:\n\tgoto L_008F;\n\tv444 = *([v355 @ X8_v36+B0]);\n\tv445 = 0;\n\tv446 = v444 + 8;\n\tv448 = *([v568 @ X11_v25-8]);\n\tv573 = v448 == v356;\n\tif (v573) goto L_0088;\n\tv468 = v567 + 1;\n\tv620 = v468 < v357;\n\tv466 = ~v620;\n\tv470 = v568 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_FFFFFFFF;\n\tv471 = v125;\n\tv472 = 0;\n\tv473 = 0x8909C4(v471, v356, v472, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_008F;\nL_0088:\n\tv621 = *([v568 @ X11_v25]);\n\tv622 = v621 << 4;\n\tv623 = v355 + v622;\n\tv624 = v623 + 0x130;\nL_008F:\n\tv398 = System.Collections.IEnumerator::MoveNext(v221);\n\tv629 = v398 == 0;\n\tif (v629) goto L_00CA;\n\tgoto L_00BE;\n\tv661 = *([v646 @ X8_v39+B0]);\n\tv662 = 0;\n\tv663 = v661 + 8;\n\tv665 = *([v705 @ X11_v20-8]);\n\tv710 = v665 == v647;\n\tif (v710) goto L_00B7;\n\tv685 = v704 + 1;\n\tv722 = v685 < v648;\n\tv683 = ~v722;\n\tv687 = v705 + 0x10;\n\tv667 = ~v683;\n\tif (v667) goto L_FFFFFFFF;\n\tv688 = v125;\n\tv689 = 0;\n\tv690 = 0x8909C4(v688, v647, v689, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00BE;\nL_00B7:\n\tv723 = *([v705 @ X11_v20]);\n\tv724 = v723 << 4;\n\tv725 = v646 + v724;\n\tv726 = v725 + 0x130;\nL_00BE:\n\tv477 = System.Collections.Generic.IEnumerator`1<System.Object>::get_Current(v221);\n\tv306 = System.Collections.ArrayList::Add(v53, v477);\n\tgoto L_0068;\nL_00CA:\n\tv650 = v221 == 0;\n\tv400 = ~v650;\n\tif (v400) goto L_00EE;\n\tgoto L_0116;\n\tthrow System.NullReferenceException;\n\tv119 = new System.NullReferenceException();\nL_00D2:\n\tv126 = new System.NullReferenceException();\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\nL_00E0:\n\tv171 = v116 != 1;\n\tif (v171) goto L_0176;\n\tv193 = 0x6D2BC0(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv391 = *([v193 @ X0_v45]);\n\tv225 = 0x6D2490(v193, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv313 = v221 == 0;\n\tif (v313) goto L_0116;\nL_00EE:\n\tgoto L_0115;\n\tv480 = *([v405 @ X8_v24+B0]);\n\tv481 = 0;\n\tv482 = v480 + 8;\n\tv484 = *([v589 @ X11_v9-8]);\n\tv594 = v484 == v408;\n\tif (v594) goto L_010E;\n\tv504 = v588 + 1;\n\tv630 = v504 < v407;\n\tv502 = ~v630;\n\tv506 = v589 + 0x10;\n\tv486 = ~v502;\n\tif (v486) goto L_FFFFFFFF;\n\tv507 = v403;\n\tv508 = 0;\n\tv509 = 0x8909C4(v507, v408, v508, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0115;\nL_010E:\n\tv631 = *([v589 @ X11_v9]);\n\tv632 = v631 << 4;\n\tv633 = v405 + v632;\n\tv634 = v633 + 0x130;\nL_0115:\n\tSystem.IDisposable::Dispose(v403);\nL_0116:\n\tv443 = v434 + 1;\n\tv243 = v443 == 0;\n\tv233 = ~v243;\n\tif (v233) goto L_0126;\n\tv510 = v433 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_0173;\nL_0126:\n\tgoto L_0133;\n\tv607 = *([v515 @ X0_v10 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_0133;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v515, v435, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv611 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0133:\n\t// 307 NewArr v619 @ X0_v13 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_0147;\n\tv651 = *([v642 @ X8_v12+E0]);\n\tv652 = v651 == 0;\n\tv653 = ~v652;\n\tgoto L_0147;\n\tv691 = v642;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v691, v617, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0147:\n\tv660 = System.Type::GetTypeFromHandle(System.String);\n\tv717 = System.Collections.ArrayList::ToArray(v53, v660);\n\tv731 = v717 == 0;\n\tif (v731) goto L_015C;\n\t// 344 IsInst v263 @ X0_v26, typeof(System.Object), v717 @ X0_v21 (System.Array)\nL_015C:\n\tv344 = v619.Length == 0;\n\tif (v344) goto L_0174;\n\tv619[0] = v717;\n\tUnityEngine.AndroidJavaObject::CallStatic(v615.GA, \"configureAvailableResourceCurrencies\", v619);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0173:\n\tgoto L_017A;\nL_0174:\n\tv341 = new System.IndexOutOfRangeException();\n\tgoto L_017A;\nL_0176:\n\tv194 = 0x6D2380(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv272 = new System.ArrayTypeMismatchException();\nL_017A:\n\tthrow System.TypeLoadException;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureAvailableResourceCurrencies(string list)
		{
			//IL_011f: Expected I4, but got O
			//IL_015b: Expected I4, but got O
			object obj2;
			if (list != null)
			{
				object obj = GA_MiniJSON.Parser.Parse(list);
				obj2 = obj;
			}
			else
			{
				obj2 = null;
			}
			ArrayList arrayList = new ArrayList();
			object obj3 = obj2 as IList<object>;
			int num2;
			int num3;
			IDisposable disposable;
			int num5;
			int num6;
			int num4;
			if (obj3 != null)
			{
				object obj4 = obj2 as IList<object>;
				IEnumerator enumerator = ((IEnumerable<object>)obj4).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = ((IEnumerator<object>)enumerator).Current;
					int num = arrayList.Add(current);
				}
				bool flag = enumerator == null;
				bool flag2 = !flag;
				num2 = 0;
				num3 = 0;
				disposable = (IDisposable)enumerator;
				if (!flag2)
				{
					num4 = 0;
					num5 = 0;
					num6 = 0;
					goto IL_0308;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					goto IL_027b;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num2 = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator enumerator = default(IEnumerator);
				bool flag3 = enumerator == null;
				num3 = -1;
				disposable = (IDisposable)enumerator;
				num5 = (int)obj5;
				num6 = -1;
				if (flag3)
				{
					goto IL_0308;
				}
			}
			disposable.Dispose();
			num4 = 0;
			num5 = num2;
			num6 = num3;
			goto IL_0308;
			IL_027b:
			throw new TypeLoadException();
			IL_0308:
			if (num6 + 1 != 0 || num5 == 0)
			{
				object[] array = new object[1];
				Type typeFromHandle = typeof(string);
				Array array2 = arrayList.ToArray(typeFromHandle);
				if (array2 != null)
				{
					object obj6 = array2 as object;
				}
				if (array.Length != 0)
				{
					array[0] = array2;
					GA.CallStatic("configureAvailableResourceCurrencies", array);
					return;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			}
			goto IL_027b;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x15AA9C0", Offset = "0x15AA9C0", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EACC78]);\n\tv23 = *([v22 @ X8_v48]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202985B]) = v42;\nL_0015:\n\tv43 = list == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Parser::Parse(list);\n\tgoto L_001F;\nL_001F:\n\tv53 = new System.Collections.ArrayList();\n\tSystem.Collections.ArrayList::.ctor(v53);\n\t// 39 IsInst v60 @ X0_v6, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tv61 = v60 == 0;\n\tif (v61) goto L_00D2;\n\t// 47 IsInst v67 @ X0_v48, typeof(System.Collections.Generic.IList`1<System.Object>), v49 @ X20_v2 (System.Object)\n\tgoto L_005C;\n\tv131 = *([v128 @ X8_v31+B0]);\n\tv132 = 0;\n\tv133 = v131 + 8;\n\tv135 = *([v183 @ X11_v30-8]);\n\tv188 = v135 == v66;\n\tif (v188) goto L_0055;\n\tv155 = v182 + 1;\n\tv195 = v155 < v129;\n\tv153 = ~v195;\n\tv157 = v183 + 0x10;\n\tv137 = ~v153;\n\tif (v137) goto L_FFFFFFFF;\n\tv158 = v127;\n\tv159 = v66;\n\tv160 = 0;\n\tv161 = 0x8909C4(v158, v159, v160, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_005C;\nL_0055:\n\tv196 = *([v183 @ X11_v30]);\n\tv197 = v196 << 4;\n\tv198 = v128 + v197;\n\tv199 = v198 + 0x130;\nL_005C:\n\tv221 = System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator(v67);\nL_0068:\n\tgoto L_008F;\n\tv444 = *([v355 @ X8_v36+B0]);\n\tv445 = 0;\n\tv446 = v444 + 8;\n\tv448 = *([v568 @ X11_v25-8]);\n\tv573 = v448 == v356;\n\tif (v573) goto L_0088;\n\tv468 = v567 + 1;\n\tv620 = v468 < v357;\n\tv466 = ~v620;\n\tv470 = v568 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_FFFFFFFF;\n\tv471 = v125;\n\tv472 = 0;\n\tv473 = 0x8909C4(v471, v356, v472, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_008F;\nL_0088:\n\tv621 = *([v568 @ X11_v25]);\n\tv622 = v621 << 4;\n\tv623 = v355 + v622;\n\tv624 = v623 + 0x130;\nL_008F:\n\tv398 = System.Collections.IEnumerator::MoveNext(v221);\n\tv629 = v398 == 0;\n\tif (v629) goto L_00CA;\n\tgoto L_00BE;\n\tv661 = *([v646 @ X8_v39+B0]);\n\tv662 = 0;\n\tv663 = v661 + 8;\n\tv665 = *([v705 @ X11_v20-8]);\n\tv710 = v665 == v647;\n\tif (v710) goto L_00B7;\n\tv685 = v704 + 1;\n\tv722 = v685 < v648;\n\tv683 = ~v722;\n\tv687 = v705 + 0x10;\n\tv667 = ~v683;\n\tif (v667) goto L_FFFFFFFF;\n\tv688 = v125;\n\tv689 = 0;\n\tv690 = 0x8909C4(v688, v647, v689, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00BE;\nL_00B7:\n\tv723 = *([v705 @ X11_v20]);\n\tv724 = v723 << 4;\n\tv725 = v646 + v724;\n\tv726 = v725 + 0x130;\nL_00BE:\n\tv477 = System.Collections.Generic.IEnumerator`1<System.Object>::get_Current(v221);\n\tv306 = System.Collections.ArrayList::Add(v53, v477);\n\tgoto L_0068;\nL_00CA:\n\tv650 = v221 == 0;\n\tv400 = ~v650;\n\tif (v400) goto L_00EE;\n\tgoto L_0116;\n\tthrow System.NullReferenceException;\n\tv119 = new System.NullReferenceException();\nL_00D2:\n\tv126 = new System.NullReferenceException();\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\nL_00E0:\n\tv171 = v116 != 1;\n\tif (v171) goto L_0176;\n\tv193 = 0x6D2BC0(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv391 = *([v193 @ X0_v45]);\n\tv225 = 0x6D2490(v193, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv313 = v221 == 0;\n\tif (v313) goto L_0116;\nL_00EE:\n\tgoto L_0115;\n\tv480 = *([v405 @ X8_v24+B0]);\n\tv481 = 0;\n\tv482 = v480 + 8;\n\tv484 = *([v589 @ X11_v9-8]);\n\tv594 = v484 == v408;\n\tif (v594) goto L_010E;\n\tv504 = v588 + 1;\n\tv630 = v504 < v407;\n\tv502 = ~v630;\n\tv506 = v589 + 0x10;\n\tv486 = ~v502;\n\tif (v486) goto L_FFFFFFFF;\n\tv507 = v403;\n\tv508 = 0;\n\tv509 = 0x8909C4(v507, v408, v508, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0115;\nL_010E:\n\tv631 = *([v589 @ X11_v9]);\n\tv632 = v631 << 4;\n\tv633 = v405 + v632;\n\tv634 = v633 + 0x130;\nL_0115:\n\tSystem.IDisposable::Dispose(v403);\nL_0116:\n\tv443 = v434 + 1;\n\tv243 = v443 == 0;\n\tv233 = ~v243;\n\tif (v233) goto L_0126;\n\tv510 = v433 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_0173;\nL_0126:\n\tgoto L_0133;\n\tv607 = *([v515 @ X0_v10 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_0133;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v515, v435, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv611 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0133:\n\t// 307 NewArr v619 @ X0_v13 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_0147;\n\tv651 = *([v642 @ X8_v12+E0]);\n\tv652 = v651 == 0;\n\tv653 = ~v652;\n\tgoto L_0147;\n\tv691 = v642;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v691, v617, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0147:\n\tv660 = System.Type::GetTypeFromHandle(System.String);\n\tv717 = System.Collections.ArrayList::ToArray(v53, v660);\n\tv731 = v717 == 0;\n\tif (v731) goto L_015C;\n\t// 344 IsInst v263 @ X0_v26, typeof(System.Object), v717 @ X0_v21 (System.Array)\nL_015C:\n\tv344 = v619.Length == 0;\n\tif (v344) goto L_0174;\n\tv619[0] = v717;\n\tUnityEngine.AndroidJavaObject::CallStatic(v615.GA, \"configureAvailableResourceItemTypes\", v619);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0173:\n\tgoto L_017A;\nL_0174:\n\tv341 = new System.IndexOutOfRangeException();\n\tgoto L_017A;\nL_0176:\n\tv194 = 0x6D2380(v126, v116, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv272 = new System.ArrayTypeMismatchException();\nL_017A:\n\tthrow System.TypeLoadException;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureAvailableResourceItemTypes(string list)
		{
			//IL_011f: Expected I4, but got O
			//IL_015b: Expected I4, but got O
			object obj2;
			if (list != null)
			{
				object obj = GA_MiniJSON.Parser.Parse(list);
				obj2 = obj;
			}
			else
			{
				obj2 = null;
			}
			ArrayList arrayList = new ArrayList();
			object obj3 = obj2 as IList<object>;
			int num2;
			int num3;
			IDisposable disposable;
			int num5;
			int num6;
			int num4;
			if (obj3 != null)
			{
				object obj4 = obj2 as IList<object>;
				IEnumerator enumerator = ((IEnumerable<object>)obj4).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = ((IEnumerator<object>)enumerator).Current;
					int num = arrayList.Add(current);
				}
				bool flag = enumerator == null;
				bool flag2 = !flag;
				num2 = 0;
				num3 = 0;
				disposable = (IDisposable)enumerator;
				if (!flag2)
				{
					num4 = 0;
					num5 = 0;
					num6 = 0;
					goto IL_0308;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					goto IL_027b;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num2 = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator enumerator = default(IEnumerator);
				bool flag3 = enumerator == null;
				num3 = -1;
				disposable = (IDisposable)enumerator;
				num5 = (int)obj5;
				num6 = -1;
				if (flag3)
				{
					goto IL_0308;
				}
			}
			disposable.Dispose();
			num4 = 0;
			num5 = num2;
			num6 = num3;
			goto IL_0308;
			IL_027b:
			throw new TypeLoadException();
			IL_0308:
			if (num6 + 1 != 0 || num5 == 0)
			{
				object[] array = new object[1];
				Type typeFromHandle = typeof(string);
				Array array2 = arrayList.ToArray(typeFromHandle);
				if (array2 != null)
				{
					object obj6 = array2 as object;
				}
				if (array.Length != 0)
				{
					array[0] = array2;
					GA.CallStatic("configureAvailableResourceItemTypes", array);
					return;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			}
			goto IL_027b;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x15AADA0", Offset = "0x15AADA0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA4788]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202985C]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = unitySdkVersion == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), unitySdkVersion @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = unitySdkVersion;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"configureSdkGameEngineVersion\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureSdkGameEngineVersion(string unitySdkVersion)
		{
			object[] array = new object[1];
			if (unitySdkVersion != null)
			{
				object obj = unitySdkVersion as object;
			}
			if (array.Length != 0)
			{
				array[0] = unitySdkVersion;
				GA.CallStatic("configureSdkGameEngineVersion", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x15AAE94", Offset = "0x15AAE94", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC3CE8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202985D]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = unityEngineVersion == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), unityEngineVersion @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = unityEngineVersion;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"configureGameEngineVersion\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureGameEngineVersion(string unityEngineVersion)
		{
			object[] array = new object[1];
			if (unityEngineVersion != null)
			{
				object obj = unityEngineVersion as object;
			}
			if (array.Length != 0)
			{
				array[0] = unityEngineVersion;
				GA.CallStatic("configureGameEngineVersion", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x15AAF88", Offset = "0x15AAF88", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EDA4F8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202985E]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = build == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), build @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = build;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"configureBuild\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureBuild(string build)
		{
			object[] array = new object[1];
			if (build != null)
			{
				object obj = build as object;
			}
			if (array.Length != 0)
			{
				array[0] = build;
				GA.CallStatic("configureBuild", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x15AB07C", Offset = "0x15AB07C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED5760]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202985F]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = userId == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), userId @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = userId;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"configureUserId\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void configureUserId(string userId)
		{
			object[] array = new object[1];
			if (userId != null)
			{
				object obj = userId as object;
			}
			if (array.Length != 0)
			{
				array[0] = userId;
				GA.CallStatic("configureUserId", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x15AB170", Offset = "0x15AB170", Length = "0x4A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1ED6CE8]);\n\tv35 = *([v34 @ X8_v83]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, gamesecret, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2029860]) = v53;\nL_001B:\n\tv54 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv57 = ~v54.UseIMEI;\n\tif (v57) goto L_0071;\n\tgoto L_0034;\n\tv231 = *([v128 @ X0_v80 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0034;\n\tv315 = \"il2cpp_codegen_runtime_class_init\"(v128, gamesecret, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv235 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0034:\n\tv242 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003D;\n\tv316 = v242;\n\tv317 = 0x8907BC(v316, gamesecret, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv320 = *([v242 @ X22_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003D:\n\tv321 = *([v242 @ X22_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv322 = v321 == 0;\n\tif (v322) goto L_005E;\n\tv351 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004A;\n\tv394 = v351;\n\tv395 = 0x8907BC(v394, gamesecret, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_004A:\n\tv396 = *([v351 @ X22_v20 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv363 = ~v396;\n\tif (v363) goto L_005E;\n\tgoto L_005E;\n\tv493 = v357;\n\tv494 = 0x8907BC(v493, gamesecret, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_005E:\n\tgoto L_0061;\n\tv397 = v167;\n\tv398 = 0x8907BC(v397, gamesecret, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0061:\n\tv173 = v240.GA_IMEI == 0;\n\tif (v173) goto L_0160;\n\tUnityEngine.AndroidJavaObject::CallStatic(v240.GA_IMEI, \"readImei\", v176.Value);\nL_0071:\n\tgoto L_007E;\n\tv247 = *([v182 @ X0_v26 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv248 = v247 == 0;\n\tv249 = ~v248;\n\tif (v249) goto L_007E;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v182, v157, v160, v154, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv251 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_007E:\n\tv260 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0087;\n\tv324 = v260;\n\tv325 = 0x8907BC(v324, v157, v160, v154, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv328 = *([v260 @ X22_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0087:\n\tv329 = *([v260 @ X22_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv330 = v329 == 0;\n\tif (v330) goto L_00A8;\n\tv372 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0094;\n\tv399 = v372;\n\tv400 = 0x8907BC(v399, v157, v160, v154, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0094:\n\tv401 = *([v372 @ X22_v15 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv384 = ~v401;\n\tif (v384) goto L_00A8;\n\tgoto L_00A8;\n\tv497 = v378;\n\tv498 = 0x8907BC(v497, v157, v160, v154, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00A8:\n\tgoto L_00B4;\n\tv402 = v389;\n\tv403 = 0x8907BC(v402, v157, v160, v154, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00B4:\n\tUnityEngine.AndroidJavaObject::CallStatic(v256.UNITY_GA, \"initialize\", v416.Value);\n\tv456 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v456, \"com.unity3d.player.UnityPlayer\");\n\tv568 = UnityEngine.AndroidJavaObject::GetStatic(v456, \"currentActivity\");\n\t// 210 NewArr v577 @ X0_v42 (System.Object[]), typeof(System.Object[]), 1\n\tv89 = 0;\n\t// 217 Box v457 @ X0_v44, typeof(System.Boolean), &v89 @ stack_-54_v8\n\tv580 = v457 == 0;\n\tif (v580) goto L_00E6;\n\t// 226 IsInst v215 @ X0_v65, typeof(System.Object), v457 @ X0_v44\nL_00E6:\n\tv506 = v577.Length == 0;\n\tif (v506) goto L_0158;\n\tv577[0] = v457;\n\tUnityEngine.AndroidJavaObject::CallStatic(v574.GA, \"setEnabledErrorReporting\", v577);\n\tv590 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v590, \"com.gameanalytics.sdk.GAPlatform\");\n\t// 252 NewArr v114 @ X0_v50 (System.Object[]), typeof(System.Object[]), 1\n\tv594 = v568 == 0;\n\tif (v594) goto L_0109;\n\t// 261 IsInst v216 @ X0_v63, typeof(System.Object), v568 @ X0_v40 (UnityEngine.AndroidJavaObject)\nL_0109:\n\tv507 = v114.Length == 0;\n\tif (v507) goto L_0158;\n\tv114[0] = v568;\n\tUnityEngine.AndroidJavaObject::CallStatic(v590, \"initializeWithActivity\", v114);\n\t// 282 NewArr v115 @ X0_v54 (System.Object[]), typeof(System.Object[]), 2\n\tv604 = v51 == 0;\n\tif (v604) goto L_0126;\n\t// 291 IsInst v217 @ X0_v61, typeof(System.Object), v51 @ X0_v1 (System.String)\nL_0126:\n\tv472 = v115.Length;\n\tv508 = v115.Length == 0;\n\tif (v508) goto L_0158;\n\tv115[0] = v51;\n\tv608 = v340 == 0;\n\tif (v608) goto L_0133;\n\t// 303 IsInst v218 @ X0_v59, typeof(System.Object), v340 @ X1_v1 (System.String)\n\tv472 = v115.Length;\nL_0133:\n\tv611 = v472 < 1;\n\tv438 = ~v611;\n\tv436 = v472 - 1;\n\tv432 = v436 == 0;\n\tv612 = ~v438;\n\tv422 = v612 | v432;\n\tif (v422) goto L_0158;\n\tv115[1] = v340;\n\tUnityEngine.AndroidJavaObject::CallStatic(v121.GA, \"initializeWithGameKey\", v115);\n\treturn;\n\tv476 = new System.NullReferenceException();\nL_0158:\n\tv305 = new System.IndexOutOfRangeException();\n\tgoto L_FFFFFFFF;\n\tv125 = new System.NullReferenceException();\n\tv230 = new System.ArrayTypeMismatchException();\n\tthrow v304;\nL_0160:\n\tv349 = new System.NullReferenceException();\n\tgoto L_016D;\n\tgoto L_016D;\nL_016D:\n\tv132 = v340 != 1;\n\tif (v132) goto L_0188;\n\tv478 = 0x6D2BC0(v349, v340, v481, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv177 = *([v478 @ X0_v11]);\n\tv513 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v177 @ X8_v5]), v481, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv516 = v513 & 1;\n\tv174 = v516 == 0;\n\tif (v174) goto L_017E;\n\tv171 = 0x6D2490(v513, *([v177 @ X8_v5]), v481, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0071;\nL_017E:\n\tv518 = 0x6D1E60(8, *([v177 @ X8_v5]), v481, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([v518 @ X0_v15]) = *([v478 @ X0_v11]);\n\tv479 = 0x1E8A000 + 0x870;\n\tv570 = 0x6D2A00(v518, v479, 0, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv485 = 0x6D2490(v570, v479, 0, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0188:\n\tv492 = 0x6D2380(v489, v479, v481, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv514 = 0x846AA4(v492, v479, v481, v156, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\n// 254 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void initialize(string gamekey, string gamesecret)
		{
			//IL_0149: Expected O, but got I4
			//IL_0152: Expected I4, but got O
			//IL_036f: Expected I, but got O
			//IL_0443: Expected O, but got I4
			//IL_046b: Expected I, but got O
			//IL_02bd: Expected O, but got I4
			//IL_04e9: Expected O, but got I
			//IL_0327: Expected O, but got I4
			Settings settingsGA = GameAnalytics.SettingsGA;
			string text = default(string);
			IntPtr intPtr3;
			if (settingsGA.UseIMEI)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ X22_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X22_v20 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				if (GA_IMEI == null)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag = (IntPtr)text != (IntPtr)1;
					string text2 = text;
					NullReferenceException ex2 = ex;
					if (!flag)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj2 = default(object);
						object obj = obj2;
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj3 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							goto IL_04b5;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj4 = obj2;
						text2 = (string)(32022528 + 2160);
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						intPtr3 = (IntPtr)null;
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					return;
				}
				GA_IMEI.CallStatic("readImei");
			}
			goto IL_04b5;
			IL_04b5:
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X22_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr5 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ X22_v15 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			UNITY_GA.CallStatic("initialize");
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			object[] array = new object[1];
			object obj5 = 0;
			object obj6 = (byte)(int)obj5 != 0;
			if (obj6 != null)
			{
				object obj7 = obj6 as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj6;
				GA.CallStatic("setEnabledErrorReporting", array);
				AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.gameanalytics.sdk.GAPlatform");
				object[] array2 = new object[1];
				if (androidJavaObject != null)
				{
					object obj8 = androidJavaObject as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = androidJavaObject;
					androidJavaClass2.CallStatic("initializeWithActivity", array2);
					object[] array3 = new object[2];
					string text3 = default(string);
					if (text3 != null)
					{
						object obj9 = text3 as object;
					}
					object obj10 = array3.Length;
					if (array3.Length != 0)
					{
						array3[0] = text3;
						if (text != null)
						{
							object obj11 = text as object;
							obj10 = array3.Length;
						}
						bool flag2 = (long)(IntPtr)obj10 < 1L;
						bool flag3 = !flag2;
						object obj12 = (long)(IntPtr)obj10 - 1L;
						bool flag4 = obj12 == null;
						bool flag5 = !flag3;
						if (!(flag5 || flag4))
						{
							array3[1] = text;
							GA.CallStatic("initializeWithGameKey", array3);
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
			text = null;
			intPtr3 = (IntPtr)null;
			IndexOutOfRangeException ex5 = default(IndexOutOfRangeException);
			throw ex5;
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x15AB610", Offset = "0x15AB610", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF9FD8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029861]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = customDimension == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), customDimension @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = customDimension;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setCustomDimension01\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setCustomDimension01(string customDimension)
		{
			object[] array = new object[1];
			if (customDimension != null)
			{
				object obj = customDimension as object;
			}
			if (array.Length != 0)
			{
				array[0] = customDimension;
				GA.CallStatic("setCustomDimension01", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x15AB704", Offset = "0x15AB704", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC8F68]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029862]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = customDimension == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), customDimension @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = customDimension;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setCustomDimension02\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setCustomDimension02(string customDimension)
		{
			object[] array = new object[1];
			if (customDimension != null)
			{
				object obj = customDimension as object;
			}
			if (array.Length != 0)
			{
				array[0] = customDimension;
				GA.CallStatic("setCustomDimension02", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x15AB7F8", Offset = "0x15AB7F8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F08438]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029863]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = customDimension == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), customDimension @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = customDimension;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setCustomDimension03\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setCustomDimension03(string customDimension)
		{
			object[] array = new object[1];
			if (customDimension != null)
			{
				object obj = customDimension as object;
			}
			if (array.Length != 0)
			{
				array[0] = customDimension;
				GA.CallStatic("setCustomDimension03", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x15AB8EC", Offset = "0x15AB8EC", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EAC7E8]);\n\tv37 = *([v36 @ X8_v33]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, amount, itemType, itemId, cartType, fields, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029864]) = v52;\nL_0022:\n\tgoto L_002F;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002F;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v55, amount, itemType, itemId, cartType, fields, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv63 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_002F:\n\t// 47 NewArr v72 @ X0_v5 (System.Object[]), typeof(System.Object[]), 5\n\tv76 = currency == 0;\n\tif (v76) goto L_003C;\n\t// 56 IsInst v123 @ X0_v34, typeof(System.Object), currency @ X0 (System.String)\nL_003C:\n\tv130 = v72.Length == 0;\n\tif (v130) goto L_00B2;\n\tv72[0] = currency;\n\t// 68 Box v168 @ X0_v19, typeof(System.Int32), &amount @ X1 (System.Int32)\n\tv257 = v168 == 0;\n\tif (v257) goto L_004E;\n\t// 75 IsInst v241 @ X0_v32, typeof(System.Object), v168 @ X0_v19\nL_004E:\n\tv161 = v72.Length;\n\tv301 = v72.Length < 1;\n\tv202 = ~v301;\n\tv198 = v72.Length - 1;\n\tv190 = v198 == 0;\n\tv302 = ~v202;\n\tv170 = v302 | v190;\n\tif (v170) goto L_00B2;\n\tv72[1] = v168;\n\tv303 = itemType == 0;\n\tif (v303) goto L_0065;\n\t// 97 IsInst v242 @ X0_v30, typeof(System.Object), itemType @ X2 (System.String)\n\tv161 = v72.Length;\nL_0065:\n\tv306 = v161 < 2;\n\tv203 = ~v306;\n\tv199 = v161 - 2;\n\tv191 = v199 == 0;\n\tv307 = ~v203;\n\tv171 = v307 | v191;\n\tif (v171) goto L_00B2;\n\tv72[2] = itemType;\n\tv308 = itemId == 0;\n\tif (v308) goto L_007B;\n\t// 119 IsInst v243 @ X0_v28, typeof(System.Object), itemId @ X3 (System.String)\n\tv161 = v72.Length;\nL_007B:\n\tv311 = v161 < 3;\n\tv204 = ~v311;\n\tv200 = v161 - 3;\n\tv192 = v200 == 0;\n\tv312 = ~v204;\n\tv172 = v312 | v192;\n\tif (v172) goto L_00B2;\n\tv72[3] = itemId;\n\tv313 = cartType == 0;\n\tif (v313) goto L_0091;\n\t// 141 IsInst v244 @ X0_v26, typeof(System.Object), cartType @ X4 (System.String)\n\tv161 = v72.Length;\nL_0091:\n\tv316 = v161 < 4;\n\tv149 = ~v316;\n\tv147 = v161 - 4;\n\tv143 = v147 == 0;\n\tv317 = ~v149;\n\tv133 = v317 | v143;\n\tif (v133) goto L_00B2;\n\tv72[4] = cartType;\n\tUnityEngine.AndroidJavaObject::CallStatic(v67.GA, \"addBusinessEventWithCurrency\", v72);\n\treturn;\nL_00B2:\n\tv224 = new System.IndexOutOfRangeException();\n\tgoto L_00B7;\n\tv256 = new System.ArrayTypeMismatchException();\nL_00B7:\n\tthrow v298;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, string fields)
		{
			//IL_00ab: Expected O, but got I4
			//IL_00d7: Expected O, but got I4
			//IL_027b: Expected O, but got I
			//IL_0157: Expected O, but got I4
			//IL_02d9: Expected O, but got I
			//IL_01a7: Expected O, but got I4
			//IL_0337: Expected O, but got I
			//IL_01f7: Expected O, but got I4
			object[] array = new object[5];
			if (currency != null)
			{
				object obj = currency as object;
			}
			if (array.Length != 0)
			{
				array[0] = currency;
				object obj2 = amount;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				object obj4 = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj5 = array.Length - 1;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj2;
					if (itemType != null)
					{
						object obj6 = itemType as object;
						obj4 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj4 < 2L;
					bool flag6 = !flag5;
					object obj7 = (long)(IntPtr)obj4 - 2L;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = itemType;
						if (itemId != null)
						{
							object obj8 = itemId as object;
							obj4 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj4 < 3L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj4 - 3L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = itemId;
							if (cartType != null)
							{
								object obj10 = cartType as object;
								obj4 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj4 < 4L;
							bool flag14 = !flag13;
							object obj11 = (long)(IntPtr)obj4 - 4L;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = cartType;
								GA.CallStatic("addBusinessEventWithCurrency", array);
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x15ABAC0", Offset = "0x15ABAC0", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv48 = *([1EB2828]);\n\tv49 = *([v48 @ X8_v42]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, amount, itemType, itemId, cartType, receipt, store, signature, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2029865]) = v61;\nL_0028:\n\tgoto L_0035;\n\tv68 = *([v64 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_0035;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v64, amount, itemType, itemId, cartType, receipt, store, signature, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv72 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0035:\n\t// 53 NewArr v81 @ X0_v5 (System.Object[]), typeof(System.Object[]), 8\n\tv85 = currency == 0;\n\tif (v85) goto L_0042;\n\t// 62 IsInst v132 @ X0_v43, typeof(System.Object), currency @ X0 (System.String)\nL_0042:\n\tv139 = v81.Length == 0;\n\tif (v139) goto L_00FD;\n\tv81[0] = currency;\n\t// 74 Box v177 @ X0_v19, typeof(System.Int32), &amount @ X1 (System.Int32)\n\tv317 = v177 == 0;\n\tif (v317) goto L_0054;\n\t// 81 IsInst v292 @ X0_v41, typeof(System.Object), v177 @ X0_v19\nL_0054:\n\tv170 = v81.Length;\n\tv367 = v81.Length < 1;\n\tv235 = ~v367;\n\tv228 = v81.Length - 1;\n\tv214 = v228 == 0;\n\tv368 = ~v235;\n\tv179 = v368 | v214;\n\tif (v179) goto L_00FD;\n\tv81[1] = v177;\n\tv369 = itemType == 0;\n\tif (v369) goto L_006B;\n\t// 103 IsInst v293 @ X0_v39, typeof(System.Object), itemType @ X2 (System.String)\n\tv170 = v81.Length;\nL_006B:\n\tv372 = v170 < 2;\n\tv236 = ~v372;\n\tv229 = v170 - 2;\n\tv215 = v229 == 0;\n\tv373 = ~v236;\n\tv180 = v373 | v215;\n\tif (v180) goto L_00FD;\n\tv81[2] = itemType;\n\tv374 = itemId == 0;\n\tif (v374) goto L_0081;\n\t// 125 IsInst v294 @ X0_v37, typeof(System.Object), itemId @ X3 (System.String)\n\tv170 = v81.Length;\nL_0081:\n\tv377 = v170 < 3;\n\tv237 = ~v377;\n\tv230 = v170 - 3;\n\tv216 = v230 == 0;\n\tv378 = ~v237;\n\tv181 = v378 | v216;\n\tif (v181) goto L_00FD;\n\tv81[3] = itemId;\n\tv379 = cartType == 0;\n\tif (v379) goto L_0097;\n\t// 147 IsInst v295 @ X0_v35, typeof(System.Object), cartType @ X4 (System.String)\n\tv170 = v81.Length;\nL_0097:\n\tv382 = v170 < 4;\n\tv238 = ~v382;\n\tv231 = v170 - 4;\n\tv217 = v231 == 0;\n\tv383 = ~v238;\n\tv182 = v383 | v217;\n\tif (v182) goto L_00FD;\n\tv81[4] = cartType;\n\tv384 = receipt == 0;\n\tif (v384) goto L_00AD;\n\t// 169 IsInst v296 @ X0_v33, typeof(System.Object), receipt @ X5 (System.String)\n\tv170 = v81.Length;\nL_00AD:\n\tv387 = v170 < 5;\n\tv239 = ~v387;\n\tv232 = v170 - 5;\n\tv218 = v232 == 0;\n\tv388 = ~v239;\n\tv183 = v388 | v218;\n\tif (v183) goto L_00FD;\n\tv81[5] = receipt;\n\tv389 = store == 0;\n\tif (v389) goto L_00C3;\n\t// 191 IsInst v297 @ X0_v31, typeof(System.Object), store @ X6 (System.String)\n\tv170 = v81.Length;\nL_00C3:\n\tv392 = v170 < 6;\n\tv240 = ~v392;\n\tv233 = v170 - 6;\n\tv219 = v233 == 0;\n\tv393 = ~v240;\n\tv184 = v393 | v219;\n\tif (v184) goto L_00FD;\n\tv81[6] = store;\n\tv394 = signature == 0;\n\tif (v394) goto L_00D9;\n\t// 213 IsInst v298 @ X0_v29, typeof(System.Object), signature @ X7 (System.String)\n\tv170 = v81.Length;\nL_00D9:\n\tv397 = v170 < 7;\n\tv158 = ~v397;\n\tv156 = v170 - 7;\n\tv152 = v156 == 0;\n\tv398 = ~v158;\n\tv142 = v398 | v152;\n\tif (v142) goto L_00FD;\n\tv81[7] = signature;\n\tUnityEngine.AndroidJavaObject::CallStatic(v76.GA, \"addBusinessEventWithCurrency\", v81);\n\treturn;\nL_00FD:\n\tv272 = new System.IndexOutOfRangeException();\n\tgoto L_0102;\n\tv316 = new System.ArrayTypeMismatchException();\nL_0102:\n\tthrow v364;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addBusinessEventWithReceipt(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string store, string signature, string fields)
		{
			//IL_00ab: Expected O, but got I4
			//IL_00d7: Expected O, but got I4
			//IL_036b: Expected O, but got I
			//IL_0157: Expected O, but got I4
			//IL_03c9: Expected O, but got I
			//IL_01a7: Expected O, but got I4
			//IL_0427: Expected O, but got I
			//IL_01f7: Expected O, but got I4
			//IL_0485: Expected O, but got I
			//IL_0247: Expected O, but got I4
			//IL_04e3: Expected O, but got I
			//IL_0297: Expected O, but got I4
			//IL_0541: Expected O, but got I
			//IL_02e7: Expected O, but got I4
			object[] array = new object[8];
			if (currency != null)
			{
				object obj = currency as object;
			}
			if (array.Length != 0)
			{
				array[0] = currency;
				object obj2 = amount;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				object obj4 = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj5 = array.Length - 1;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj2;
					if (itemType != null)
					{
						object obj6 = itemType as object;
						obj4 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj4 < 2L;
					bool flag6 = !flag5;
					object obj7 = (long)(IntPtr)obj4 - 2L;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = itemType;
						if (itemId != null)
						{
							object obj8 = itemId as object;
							obj4 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj4 < 3L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj4 - 3L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = itemId;
							if (cartType != null)
							{
								object obj10 = cartType as object;
								obj4 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj4 < 4L;
							bool flag14 = !flag13;
							object obj11 = (long)(IntPtr)obj4 - 4L;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = cartType;
								if (receipt != null)
								{
									object obj12 = receipt as object;
									obj4 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj4 < 5L;
								bool flag18 = !flag17;
								object obj13 = (long)(IntPtr)obj4 - 5L;
								bool flag19 = obj13 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = receipt;
									if (store != null)
									{
										object obj14 = store as object;
										obj4 = array.Length;
									}
									bool flag21 = (long)(IntPtr)obj4 < 6L;
									bool flag22 = !flag21;
									object obj15 = (long)(IntPtr)obj4 - 6L;
									bool flag23 = obj15 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[6] = store;
										if (signature != null)
										{
											object obj16 = signature as object;
											obj4 = array.Length;
										}
										bool flag25 = (long)(IntPtr)obj4 < 7L;
										bool flag26 = !flag25;
										object obj17 = (long)(IntPtr)obj4 - 7L;
										bool flag27 = obj17 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											array[7] = signature;
											GA.CallStatic("addBusinessEventWithCurrency", array);
											return;
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

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x15ABD28", Offset = "0x15ABD28", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EFA160]);\n\tv37 = *([v36 @ X8_v34]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, currency, itemType, itemId, fields, methodInfo, v41, v42, amount, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029866]) = v52;\nL_0022:\n\tgoto L_002F;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002F;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v55, currency, itemType, itemId, fields, methodInfo, v41, v42, amount, v43, v44, v45, v46, v47, v48, v49);\n\tv63 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_002F:\n\t// 47 NewArr v72 @ X0_v5 (System.Object[]), typeof(System.Object[]), 5\n\t// 54 Box v72 @ X0_v5 (System.Object[]), typeof(System.Int32), &flowType @ X0 (System.Int32)\n\tv83 = v72 == 0;\n\tif (v83) goto L_0042;\n\t// 63 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), v72 @ X0_v5 (System.Object[])\nL_0042:\n\tv208 = v72.Length;\n\tv153 = v72.Length == 0;\n\tif (v153) goto L_00B9;\n\tv72[0] = v72;\n\tv154 = currency == 0;\n\tif (v154) goto L_004F;\n\t// 75 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), currency @ X1 (System.String)\n\tv208 = v72.Length;\nL_004F:\n\tv284 = v208 < 1;\n\tv189 = ~v284;\n\tv185 = v208 - 1;\n\tv177 = v185 == 0;\n\tv285 = ~v189;\n\tv157 = v285 | v177;\n\tif (v157) goto L_00B9;\n\tv72[1] = currency;\n\t// 97 Box v72 @ X0_v5 (System.Object[]), typeof(System.Single), &amount @ V0 (System.Single)\n\tv293 = v72 == 0;\n\tif (v293) goto L_006B;\n\t// 104 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), v72 @ X0_v5 (System.Object[])\nL_006B:\n\tv140 = v72.Length;\n\tv296 = v72.Length < 2;\n\tv188 = ~v296;\n\tv184 = v72.Length - 2;\n\tv176 = v184 == 0;\n\tv297 = ~v188;\n\tv156 = v297 | v176;\n\tif (v156) goto L_00B9;\n\tv72[2] = v72;\n\tv298 = itemType == 0;\n\tif (v298) goto L_0082;\n\t// 126 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), itemType @ X2 (System.String)\n\tv140 = v72.Length;\nL_0082:\n\tv301 = v140 < 3;\n\tv190 = ~v301;\n\tv186 = v140 - 3;\n\tv178 = v186 == 0;\n\tv302 = ~v190;\n\tv158 = v302 | v178;\n\tif (v158) goto L_00B9;\n\tv72[3] = itemType;\n\tv303 = itemId == 0;\n\tif (v303) goto L_0098;\n\t// 148 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), itemId @ X3 (System.String)\n\tv140 = v72.Length;\nL_0098:\n\tv306 = v140 < 4;\n\tv121 = ~v306;\n\tv117 = v140 - 4;\n\tv109 = v117 == 0;\n\tv307 = ~v121;\n\tv89 = v307 | v109;\n\tif (v89) goto L_00B9;\n\tv72[4] = itemId;\n\tUnityEngine.AndroidJavaObject::CallStatic(v67.GA, \"addResourceEventWithFlowType\", v72);\n\treturn;\nL_00B9:\n\tv210 = new System.IndexOutOfRangeException();\n\tgoto L_00BE;\n\tv281 = new System.ArrayTypeMismatchException();\nL_00BE:\n\tthrow v287;\n\tthrow System.NullReferenceException;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addResourceEvent(int flowType, string currency, float amount, string itemType, string itemId, string fields)
		{
			//IL_003e: Expected O, but got I4
			//IL_0292: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_0105: Expected O, but got I4
			//IL_0131: Expected O, but got I4
			//IL_02f0: Expected O, but got I
			//IL_01b1: Expected O, but got I4
			//IL_034e: Expected O, but got I
			//IL_0201: Expected O, but got I4
			object[] array = new object[5];
			array = (object[])(object)flowType;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			object obj = array.Length;
			if (array.Length != 0)
			{
				array[0] = array;
				if (currency != null)
				{
					array = (object[])(currency as object);
					obj = array.Length;
				}
				bool flag = (long)(IntPtr)obj < 1L;
				bool flag2 = !flag;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = currency;
					array = (object[])(object)amount;
					if (array != null)
					{
						array = (object[])(array as object);
					}
					object obj3 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj4 = array.Length - 2;
					bool flag7 = obj4 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = array;
						if (itemType != null)
						{
							array = (object[])(itemType as object);
							obj3 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj3 < 3L;
						bool flag10 = !flag9;
						object obj5 = (long)(IntPtr)obj3 - 3L;
						bool flag11 = obj5 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = itemType;
							if (itemId != null)
							{
								array = (object[])(itemId as object);
								obj3 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj3 < 4L;
							bool flag14 = !flag13;
							object obj6 = (long)(IntPtr)obj3 - 4L;
							bool flag15 = obj6 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = itemId;
								GA.CallStatic("addResourceEventWithFlowType", array);
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x15ABF14", Offset = "0x15ABF14", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EC1F00]);\n\tv33 = *([v32 @ X8_v29]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, progression01, progression02, progression03, fields, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029867]) = v49;\nL_0020:\n\tgoto L_002D;\n\tv56 = *([v52 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v52, progression01, progression02, progression03, fields, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_002D:\n\t// 45 NewArr v69 @ X0_v5 (System.Object[]), typeof(System.Object[]), 4\n\t// 52 Box v69 @ X0_v5 (System.Object[]), typeof(System.Int32), &progressionStatus @ X0 (System.Int32)\n\tv80 = v69 == 0;\n\tif (v80) goto L_0040;\n\t// 61 IsInst v69 @ X0_v5 (System.Object[]), typeof(System.Object), v69 @ X0_v5 (System.Object[])\nL_0040:\n\tv130 = v69.Length;\n\tv143 = v69.Length == 0;\n\tif (v143) goto L_0099;\n\tv69[0] = v69;\n\tv144 = progression01 == 0;\n\tif (v144) goto L_004D;\n\t// 73 IsInst v69 @ X0_v5 (System.Object[]), typeof(System.Object), progression01 @ X1 (System.String)\n\tv130 = v69.Length;\nL_004D:\n\tv250 = v130 < 1;\n\tv170 = ~v250;\n\tv167 = v130 - 1;\n\tv161 = v167 == 0;\n\tv251 = ~v170;\n\tv146 = v251 | v161;\n\tif (v146) goto L_0099;\n\tv69[1] = progression01;\n\tv254 = progression02 == 0;\n\tif (v254) goto L_0063;\n\t// 95 IsInst v69 @ X0_v5 (System.Object[]), typeof(System.Object), progression02 @ X2 (System.String)\n\tv130 = v69.Length;\nL_0063:\n\tv257 = v130 < 2;\n\tv171 = ~v257;\n\tv168 = v130 - 2;\n\tv162 = v168 == 0;\n\tv258 = ~v171;\n\tv147 = v258 | v162;\n\tif (v147) goto L_0099;\n\tv69[2] = progression02;\n\tv259 = progression03 == 0;\n\tif (v259) goto L_0079;\n\t// 117 IsInst v69 @ X0_v5 (System.Object[]), typeof(System.Object), progression03 @ X3 (System.String)\n\tv130 = v69.Length;\nL_0079:\n\tv262 = v130 < 3;\n\tv116 = ~v262;\n\tv112 = v130 - 3;\n\tv104 = v112 == 0;\n\tv263 = ~v116;\n\tv84 = v263 | v104;\n\tif (v84) goto L_0099;\n\tv69[3] = progression03;\n\tUnityEngine.AndroidJavaObject::CallStatic(v64.GA, \"addProgressionEventWithProgressionStatus\", v69);\n\treturn;\nL_0099:\n\tv185 = new System.IndexOutOfRangeException();\n\tgoto L_009E;\n\tv247 = new System.ArrayTypeMismatchException();\nL_009E:\n\tthrow v253;\n\tthrow System.NullReferenceException;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addProgressionEvent(int progressionStatus, string progression01, string progression02, string progression03, string fields)
		{
			//IL_003e: Expected O, but got I4
			//IL_01d9: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_0237: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			//IL_0295: Expected O, but got I
			//IL_0148: Expected O, but got I4
			object[] array = new object[4];
			array = (object[])(object)progressionStatus;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			object obj = array.Length;
			if (array.Length != 0)
			{
				array[0] = array;
				if (progression01 != null)
				{
					array = (object[])(progression01 as object);
					obj = array.Length;
				}
				bool flag = (long)(IntPtr)obj < 1L;
				bool flag2 = !flag;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = progression01;
					if (progression02 != null)
					{
						array = (object[])(progression02 as object);
						obj = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj < 2L;
					bool flag6 = !flag5;
					object obj3 = (long)(IntPtr)obj - 2L;
					bool flag7 = obj3 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = progression02;
						if (progression03 != null)
						{
							array = (object[])(progression03 as object);
							obj = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj < 3L;
						bool flag10 = !flag9;
						object obj4 = (long)(IntPtr)obj - 3L;
						bool flag11 = obj4 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = progression03;
							GA.CallStatic("addProgressionEventWithProgressionStatus", array);
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x15AC0B8", Offset = "0x15AC0B8", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EF2200]);\n\tv37 = *([v36 @ X8_v34]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, progression01, progression02, progression03, score, fields, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029868]) = v52;\nL_0022:\n\tgoto L_002F;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002F;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v55, progression01, progression02, progression03, score, fields, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv63 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_002F:\n\t// 47 NewArr v72 @ X0_v5 (System.Object[]), typeof(System.Object[]), 5\n\t// 54 Box v72 @ X0_v5 (System.Object[]), typeof(System.Int32), &progressionStatus @ X0 (System.Int32)\n\tv83 = v72 == 0;\n\tif (v83) goto L_0042;\n\t// 63 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), v72 @ X0_v5 (System.Object[])\nL_0042:\n\tv213 = v72.Length;\n\tv156 = v72.Length == 0;\n\tif (v156) goto L_00BA;\n\tv72[0] = v72;\n\tv157 = progression01 == 0;\n\tif (v157) goto L_004F;\n\t// 75 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), progression01 @ X1 (System.String)\n\tv213 = v72.Length;\nL_004F:\n\tv290 = v213 < 1;\n\tv191 = ~v290;\n\tv187 = v213 - 1;\n\tv179 = v187 == 0;\n\tv291 = ~v191;\n\tv159 = v291 | v179;\n\tif (v159) goto L_00BA;\n\tv72[1] = progression01;\n\tv294 = progression02 == 0;\n\tif (v294) goto L_0065;\n\t// 97 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), progression02 @ X2 (System.String)\n\tv213 = v72.Length;\nL_0065:\n\tv297 = v213 < 2;\n\tv192 = ~v297;\n\tv188 = v213 - 2;\n\tv180 = v188 == 0;\n\tv298 = ~v192;\n\tv160 = v298 | v180;\n\tif (v160) goto L_00BA;\n\tv72[2] = progression02;\n\tv299 = progression03 == 0;\n\tif (v299) goto L_007B;\n\t// 119 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), progression03 @ X3 (System.String)\n\tv213 = v72.Length;\nL_007B:\n\tv302 = v213 < 3;\n\tv193 = ~v302;\n\tv189 = v213 - 3;\n\tv181 = v189 == 0;\n\tv303 = ~v193;\n\tv161 = v303 | v181;\n\tif (v161) goto L_00BA;\n\tv72[3] = progression03;\n\t// 142 Box v72 @ X0_v5 (System.Object[]), typeof(System.Double), &score @ X4 (System.Int32)\n\tv309 = v72 == 0;\n\tif (v309) goto L_0099;\n\t// 149 IsInst v72 @ X0_v5 (System.Object[]), typeof(System.Object), v72 @ X0_v5 (System.Object[])\nL_0099:\n\tv312 = v72.Length < 4;\n\tv121 = ~v312;\n\tv117 = v72.Length - 4;\n\tv109 = v117 == 0;\n\tv313 = ~v121;\n\tv89 = v313 | v109;\n\tif (v89) goto L_00BA;\n\tv72[4] = v72;\n\tUnityEngine.AndroidJavaObject::CallStatic(v67.GA, \"addProgressionEventWithProgressionStatus\", v72);\n\treturn;\nL_00BA:\n\tv214 = new System.IndexOutOfRangeException();\n\tgoto L_00BF;\n\tv287 = new System.ArrayTypeMismatchException();\nL_00BF:\n\tthrow v293;\n\tthrow System.NullReferenceException;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addProgressionEventWithScore(int progressionStatus, string progression01, string progression02, string progression03, int score, string fields)
		{
			//IL_003e: Expected O, but got I4
			//IL_0289: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_02e7: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			//IL_0345: Expected O, but got I
			//IL_0148: Expected O, but got I4
			//IL_01c8: Expected O, but got I4
			object[] array = new object[5];
			array = (object[])(object)progressionStatus;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			object obj = array.Length;
			if (array.Length != 0)
			{
				array[0] = array;
				if (progression01 != null)
				{
					array = (object[])(progression01 as object);
					obj = array.Length;
				}
				bool flag = (long)(IntPtr)obj < 1L;
				bool flag2 = !flag;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = progression01;
					if (progression02 != null)
					{
						array = (object[])(progression02 as object);
						obj = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj < 2L;
					bool flag6 = !flag5;
					object obj3 = (long)(IntPtr)obj - 2L;
					bool flag7 = obj3 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = progression02;
						if (progression03 != null)
						{
							array = (object[])(progression03 as object);
							obj = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj < 3L;
						bool flag10 = !flag9;
						object obj4 = (long)(IntPtr)obj - 3L;
						bool flag11 = obj4 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = progression03;
							array = (object[])(object)(double)score;
							if (array != null)
							{
								array = (object[])(array as object);
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj5 = array.Length - 4;
							bool flag15 = obj5 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = array;
								GA.CallStatic("addProgressionEventWithProgressionStatus", array);
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x15AC2B0", Offset = "0x15AC2B0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECAFA0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, fields, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029869]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, fields, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = eventId == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), eventId @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = eventId;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"addDesignEventWithEventId\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addDesignEvent(string eventId, string fields)
		{
			object[] array = new object[1];
			if (eventId != null)
			{
				object obj = eventId as object;
			}
			if (array.Length != 0)
			{
				array[0] = eventId;
				GA.CallStatic("addDesignEventWithEventId", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x15AC3A4", Offset = "0x15AC3A4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EEEE78]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, fields, methodInfo, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202986A]) = v43;\nL_001C:\n\tgoto L_0029;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v46, fields, methodInfo, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0029:\n\t// 41 NewArr v63 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv67 = eventId == 0;\n\tif (v67) goto L_0036;\n\t// 50 IsInst v116 @ X0_v25, typeof(System.Object), eventId @ X0 (System.String)\nL_0036:\n\tv123 = v63.Length == 0;\n\tif (v123) goto L_0068;\n\tv63[0] = eventId;\n\t// 63 Box v163 @ X0_v19, typeof(System.Double), &value @ V0 (System.Single)\n\tv194 = v163 == 0;\n\tif (v194) goto L_004A;\n\t// 70 IsInst v187 @ X0_v23, typeof(System.Object), v163 @ X0_v19\nL_004A:\n\tv233 = v63.Length < 1;\n\tv142 = ~v233;\n\tv140 = v63.Length - 1;\n\tv136 = v140 == 0;\n\tv234 = ~v142;\n\tv126 = v234 | v136;\n\tif (v126) goto L_0068;\n\tv63[1] = v163;\n\tUnityEngine.AndroidJavaObject::CallStatic(v58.GA, \"addDesignEventWithEventId\", v63);\n\treturn;\nL_0068:\n\tv181 = new System.IndexOutOfRangeException();\n\tgoto L_006D;\n\tv193 = new System.ArrayTypeMismatchException();\nL_006D:\n\tthrow v230;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addDesignEventWithValue(string eventId, float value, string fields)
		{
			//IL_00cd: Expected O, but got I4
			object[] array = new object[2];
			if (eventId != null)
			{
				object obj = eventId as object;
			}
			if (array.Length != 0)
			{
				array[0] = eventId;
				object obj2 = (double)value;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj4 = array.Length - 1;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj2;
					GA.CallStatic("addDesignEventWithEventId", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x15AC4F8", Offset = "0x15AC4F8", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF3838]);\n\tv25 = *([v24 @ X8_v23]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, message, fields, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202986B]) = v43;\nL_001C:\n\tgoto L_0029;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v46, message, fields, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0029:\n\t// 41 NewArr v63 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\t// 48 Box v63 @ X0_v5 (System.Object[]), typeof(System.Int32), &severity @ X0 (System.Int32)\n\tv74 = v63 == 0;\n\tif (v74) goto L_003C;\n\t// 57 IsInst v63 @ X0_v5 (System.Object[]), typeof(System.Object), v63 @ X0_v5 (System.Object[])\nL_003C:\n\tv109 = v63.Length;\n\tv122 = v63.Length == 0;\n\tif (v122) goto L_0067;\n\tv63[0] = v63;\n\tv141 = message == 0;\n\tif (v141) goto L_0049;\n\t// 69 IsInst v63 @ X0_v5 (System.Object[]), typeof(System.Object), message @ X1 (System.String)\n\tv109 = v63.Length;\nL_0049:\n\tv175 = v109 < 1;\n\tv101 = ~v175;\n\tv98 = v109 - 1;\n\tv92 = v98 == 0;\n\tv176 = ~v101;\n\tv77 = v176 | v92;\n\tif (v77) goto L_0067;\n\tv63[1] = message;\n\tUnityEngine.AndroidJavaObject::CallStatic(v58.GA, \"addErrorEventWithSeverity\", v63);\n\treturn;\nL_0067:\n\tv156 = new System.IndexOutOfRangeException();\n\tgoto L_006E;\n\tv111 = new System.NullReferenceException();\n\tv140 = new System.ArrayTypeMismatchException();\nL_006E:\n\tthrow v167;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addErrorEvent(int severity, string message, string fields)
		{
			//IL_003e: Expected O, but got I4
			//IL_0139: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			array = (object[])(object)severity;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			object obj = array.Length;
			if (array.Length != 0)
			{
				array[0] = array;
				if (message != null)
				{
					array = (object[])(message as object);
					obj = array.Length;
				}
				bool flag = (long)(IntPtr)obj < 1L;
				bool flag2 = !flag;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = message;
					GA.CallStatic("addErrorEventWithSeverity", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x15AC63C", Offset = "0x15AC63C", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1F08508]);\n\tv39 = *([v38 @ X8_v32]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, adType, adSdkName, adPlacement, duration, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202986C]) = v54;\nL_0023:\n\tgoto L_0030;\n\tv61 = *([v57 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0030;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v57, adType, adSdkName, adPlacement, duration, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv65 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0030:\n\t// 48 NewArr v74 @ X0_v5 (System.Object[]), typeof(System.Object[]), 5\n\t// 55 Box v74 @ X0_v5 (System.Object[]), typeof(System.Int32), &adAction @ X0 (System.Int32)\n\tv85 = v74 == 0;\n\tif (v85) goto L_0044;\n\t// 64 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), v74 @ X0_v5 (System.Object[])\nL_0044:\n\tv162 = v74.Length == 0;\n\tif (v162) goto L_00C0;\n\tv74[0] = v74;\n\t// 74 Box v74 @ X0_v5 (System.Object[]), typeof(System.Int32), &adType @ X1 (System.Int32)\n\tv300 = v74 == 0;\n\tif (v300) goto L_0054;\n\t// 81 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), v74 @ X0_v5 (System.Object[])\nL_0054:\n\tv222 = v74.Length;\n\tv305 = v74.Length < 1;\n\tv200 = ~v305;\n\tv196 = v74.Length - 1;\n\tv188 = v196 == 0;\n\tv306 = ~v200;\n\tv168 = v306 | v188;\n\tif (v168) goto L_00C0;\n\tv74[1] = v74;\n\tv307 = adSdkName == 0;\n\tif (v307) goto L_006B;\n\t// 103 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), adSdkName @ X2 (System.String)\n\tv222 = v74.Length;\nL_006B:\n\tv310 = v222 < 2;\n\tv201 = ~v310;\n\tv197 = v222 - 2;\n\tv189 = v197 == 0;\n\tv311 = ~v201;\n\tv169 = v311 | v189;\n\tif (v169) goto L_00C0;\n\tv74[2] = adSdkName;\n\tv312 = adPlacement == 0;\n\tif (v312) goto L_0081;\n\t// 125 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), adPlacement @ X3 (System.String)\n\tv222 = v74.Length;\nL_0081:\n\tv315 = v222 < 3;\n\tv202 = ~v315;\n\tv198 = v222 - 3;\n\tv190 = v198 == 0;\n\tv316 = ~v202;\n\tv170 = v316 | v190;\n\tif (v170) goto L_00C0;\n\tv74[3] = adPlacement;\n\t// 147 Box v74 @ X0_v5 (System.Object[]), typeof(System.Int64), &duration @ X4 (System.Int64)\n\tv322 = v74 == 0;\n\tif (v322) goto L_009E;\n\t// 154 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), v74 @ X0_v5 (System.Object[])\nL_009E:\n\tv325 = v74.Length < 4;\n\tv127 = ~v325;\n\tv123 = v74.Length - 4;\n\tv115 = v123 == 0;\n\tv326 = ~v127;\n\tv95 = v326 | v115;\n\tif (v95) goto L_00C0;\n\tv74[4] = v74;\n\tUnityEngine.AndroidJavaObject::CallStatic(v69.GA, \"addAdEvent\", v74);\n\treturn;\nL_00C0:\n\tv223 = new System.IndexOutOfRangeException();\n\tgoto L_00C5;\n\tv299 = new System.ArrayTypeMismatchException();\nL_00C5:\n\tthrow v302;\n\tthrow System.NullReferenceException;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addAdEventWithDuration(int adAction, int adType, string adSdkName, string adPlacement, long duration)
		{
			//IL_00ab: Expected O, but got I4
			//IL_00d7: Expected O, but got I4
			//IL_02e7: Expected O, but got I
			//IL_0157: Expected O, but got I4
			//IL_0345: Expected O, but got I
			//IL_01a7: Expected O, but got I4
			//IL_0226: Expected O, but got I4
			object[] array = new object[5];
			array = (object[])(object)adAction;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				array = (object[])(object)adType;
				if (array != null)
				{
					array = (object[])(array as object);
				}
				object obj = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj2 = array.Length - 1;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = array;
					if (adSdkName != null)
					{
						array = (object[])(adSdkName as object);
						obj = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj < 2L;
					bool flag6 = !flag5;
					object obj3 = (long)(IntPtr)obj - 2L;
					bool flag7 = obj3 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = adSdkName;
						if (adPlacement != null)
						{
							array = (object[])(adPlacement as object);
							obj = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj < 3L;
						bool flag10 = !flag9;
						object obj4 = (long)(IntPtr)obj - 3L;
						bool flag11 = obj4 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = adPlacement;
							array = (object[])(object)duration;
							if (array != null)
							{
								array = (object[])(array as object);
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj5 = array.Length - 4;
							bool flag15 = obj5 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = array;
								GA.CallStatic("addAdEvent", array);
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x15AC844", Offset = "0x15AC844", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EBF6D8]);\n\tv39 = *([v38 @ X8_v30]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, adType, adSdkName, adPlacement, noAdReason, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202986D]) = v54;\nL_0023:\n\tgoto L_0030;\n\tv61 = *([v57 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0030;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v57, adType, adSdkName, adPlacement, noAdReason, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv65 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0030:\n\t// 48 NewArr v74 @ X0_v5 (System.Object[]), typeof(System.Object[]), 5\n\t// 55 Box v74 @ X0_v5 (System.Object[]), typeof(System.Int32), &adAction @ X0 (System.Int32)\n\tv85 = v74 == 0;\n\tif (v85) goto L_0044;\n\t// 64 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), v74 @ X0_v5 (System.Object[])\nL_0044:\n\tv162 = v74.Length == 0;\n\tif (v162) goto L_00BE;\n\tv74[0] = v74;\n\t// 74 Box v74 @ X0_v5 (System.Object[]), typeof(System.Int32), &adType @ X1 (System.Int32)\n\tv300 = v74 == 0;\n\tif (v300) goto L_0054;\n\t// 81 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), v74 @ X0_v5 (System.Object[])\nL_0054:\n\tv222 = v74.Length;\n\tv305 = v74.Length < 1;\n\tv200 = ~v305;\n\tv196 = v74.Length - 1;\n\tv188 = v196 == 0;\n\tv306 = ~v200;\n\tv168 = v306 | v188;\n\tif (v168) goto L_00BE;\n\tv74[1] = v74;\n\tv307 = adSdkName == 0;\n\tif (v307) goto L_006B;\n\t// 103 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), adSdkName @ X2 (System.String)\n\tv222 = v74.Length;\nL_006B:\n\tv310 = v222 < 2;\n\tv201 = ~v310;\n\tv197 = v222 - 2;\n\tv189 = v197 == 0;\n\tv311 = ~v201;\n\tv169 = v311 | v189;\n\tif (v169) goto L_00BE;\n\tv74[2] = adSdkName;\n\tv312 = adPlacement == 0;\n\tif (v312) goto L_0081;\n\t// 125 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), adPlacement @ X3 (System.String)\n\tv222 = v74.Length;\nL_0081:\n\tv315 = v222 < 3;\n\tv202 = ~v315;\n\tv198 = v222 - 3;\n\tv190 = v198 == 0;\n\tv316 = ~v202;\n\tv170 = v316 | v190;\n\tif (v170) goto L_00BE;\n\tv74[3] = adPlacement;\n\t// 145 Box v74 @ X0_v5 (System.Object[]), typeof(System.Int32), &noAdReason @ X4 (System.Int32)\n\tv320 = v74 == 0;\n\tif (v320) goto L_009C;\n\t// 152 IsInst v74 @ X0_v5 (System.Object[]), typeof(System.Object), v74 @ X0_v5 (System.Object[])\nL_009C:\n\tv323 = v74.Length < 4;\n\tv127 = ~v323;\n\tv123 = v74.Length - 4;\n\tv115 = v123 == 0;\n\tv324 = ~v127;\n\tv95 = v324 | v115;\n\tif (v95) goto L_00BE;\n\tv74[4] = v74;\n\tUnityEngine.AndroidJavaObject::CallStatic(v69.GA, \"addAdEvent\", v74);\n\treturn;\nL_00BE:\n\tv223 = new System.IndexOutOfRangeException();\n\tgoto L_00C3;\n\tv299 = new System.ArrayTypeMismatchException();\nL_00C3:\n\tthrow v302;\n\tthrow System.NullReferenceException;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addAdEventWithReason(int adAction, int adType, string adSdkName, string adPlacement, int noAdReason)
		{
			//IL_00ab: Expected O, but got I4
			//IL_00d7: Expected O, but got I4
			//IL_02e7: Expected O, but got I
			//IL_0157: Expected O, but got I4
			//IL_0345: Expected O, but got I
			//IL_01a7: Expected O, but got I4
			//IL_0226: Expected O, but got I4
			object[] array = new object[5];
			array = (object[])(object)adAction;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				array = (object[])(object)adType;
				if (array != null)
				{
					array = (object[])(array as object);
				}
				object obj = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj2 = array.Length - 1;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = array;
					if (adSdkName != null)
					{
						array = (object[])(adSdkName as object);
						obj = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj < 2L;
					bool flag6 = !flag5;
					object obj3 = (long)(IntPtr)obj - 2L;
					bool flag7 = obj3 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = adSdkName;
						if (adPlacement != null)
						{
							array = (object[])(adPlacement as object);
							obj = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj < 3L;
						bool flag10 = !flag9;
						object obj4 = (long)(IntPtr)obj - 3L;
						bool flag11 = obj4 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = adPlacement;
							array = (object[])(object)noAdReason;
							if (array != null)
							{
								array = (object[])(array as object);
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj5 = array.Length - 4;
							bool flag15 = obj5 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = array;
								GA.CallStatic("addAdEvent", array);
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x15ACA44", Offset = "0x15ACA44", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1F081A8]);\n\tv35 = *([v34 @ X8_v27]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, adType, adSdkName, adPlacement, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202986E]) = v51;\nL_0021:\n\tgoto L_002E;\n\tv58 = *([v54 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002E;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v54, adType, adSdkName, adPlacement, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv62 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_002E:\n\t// 46 NewArr v71 @ X0_v5 (System.Object[]), typeof(System.Object[]), 4\n\t// 53 Box v71 @ X0_v5 (System.Object[]), typeof(System.Int32), &adAction @ X0 (System.Int32)\n\tv82 = v71 == 0;\n\tif (v82) goto L_0042;\n\t// 62 IsInst v71 @ X0_v5 (System.Object[]), typeof(System.Object), v71 @ X0_v5 (System.Object[])\nL_0042:\n\tv152 = v71.Length == 0;\n\tif (v152) goto L_00A0;\n\tv71[0] = v71;\n\t// 72 Box v71 @ X0_v5 (System.Object[]), typeof(System.Int32), &adType @ X1 (System.Int32)\n\tv266 = v71 == 0;\n\tif (v266) goto L_0052;\n\t// 79 IsInst v71 @ X0_v5 (System.Object[]), typeof(System.Object), v71 @ X0_v5 (System.Object[])\nL_0052:\n\tv139 = v71.Length;\n\tv271 = v71.Length < 1;\n\tv181 = ~v271;\n\tv178 = v71.Length - 1;\n\tv172 = v178 == 0;\n\tv272 = ~v181;\n\tv157 = v272 | v172;\n\tif (v157) goto L_00A0;\n\tv71[1] = v71;\n\tv273 = adSdkName == 0;\n\tif (v273) goto L_0069;\n\t// 101 IsInst v71 @ X0_v5 (System.Object[]), typeof(System.Object), adSdkName @ X2 (System.String)\n\tv139 = v71.Length;\nL_0069:\n\tv276 = v139 < 2;\n\tv182 = ~v276;\n\tv179 = v139 - 2;\n\tv173 = v179 == 0;\n\tv277 = ~v182;\n\tv158 = v277 | v173;\n\tif (v158) goto L_00A0;\n\tv71[2] = adSdkName;\n\tv278 = adPlacement == 0;\n\tif (v278) goto L_007F;\n\t// 123 IsInst v71 @ X0_v5 (System.Object[]), typeof(System.Object), adPlacement @ X3 (System.String)\n\tv139 = v71.Length;\nL_007F:\n\tv281 = v139 < 3;\n\tv120 = ~v281;\n\tv116 = v139 - 3;\n\tv108 = v116 == 0;\n\tv282 = ~v120;\n\tv88 = v282 | v108;\n\tif (v88) goto L_00A0;\n\tv71[3] = adPlacement;\n\tUnityEngine.AndroidJavaObject::CallStatic(v66.GA, \"addAdEvent\", v71);\n\treturn;\nL_00A0:\n\tv198 = new System.IndexOutOfRangeException();\n\tgoto L_00A5;\n\tv265 = new System.ArrayTypeMismatchException();\nL_00A5:\n\tthrow v268;\n\tthrow System.NullReferenceException;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void addAdEvent(int adAction, int adType, string adSdkName, string adPlacement)
		{
			//IL_00ab: Expected O, but got I4
			//IL_00d7: Expected O, but got I4
			//IL_0238: Expected O, but got I
			//IL_0157: Expected O, but got I4
			//IL_0296: Expected O, but got I
			//IL_01a7: Expected O, but got I4
			object[] array = new object[4];
			array = (object[])(object)adAction;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				array = (object[])(object)adType;
				if (array != null)
				{
					array = (object[])(array as object);
				}
				object obj = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj2 = array.Length - 1;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = array;
					if (adSdkName != null)
					{
						array = (object[])(adSdkName as object);
						obj = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj < 2L;
					bool flag6 = !flag5;
					object obj3 = (long)(IntPtr)obj - 2L;
					bool flag7 = obj3 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = adSdkName;
						if (adPlacement != null)
						{
							array = (object[])(adPlacement as object);
							obj = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj < 3L;
						bool flag10 = !flag9;
						object obj4 = (long)(IntPtr)obj - 3L;
						bool flag11 = obj4 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = adPlacement;
							GA.CallStatic("addAdEvent", array);
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x15ACBFC", Offset = "0x15ACBFC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EE7C68]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202986F]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &enabled @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setEnabledInfoLog\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setEnabledInfoLog(bool enabled)
		{
			object[] array = new object[1];
			array = (object[])(object)enabled;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				GA.CallStatic("setEnabledInfoLog", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x15ACD0C", Offset = "0x15ACD0C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EDB468]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029870]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &enabled @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setEnabledVerboseLog\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setEnabledVerboseLog(bool enabled)
		{
			object[] array = new object[1];
			array = (object[])(object)enabled;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				GA.CallStatic("setEnabledVerboseLog", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x15ACE1C", Offset = "0x15ACE1C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EE87C8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029871]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = facebookId == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), facebookId @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = facebookId;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setFacebookId\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setFacebookId(string facebookId)
		{
			object[] array = new object[1];
			if (facebookId != null)
			{
				object obj = facebookId as object;
			}
			if (array.Length != 0)
			{
				array[0] = facebookId;
				GA.CallStatic("setFacebookId", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x15ACF10", Offset = "0x15ACF10", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECA7B0]);\n\tv21 = *([v20 @ X8_v32]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029872]) = v40;\nL_0019:\n\tv46 = System.String::op_Equality(gender, \"male\");\n\tv48 = v46 == 0;\n\tif (v48) goto L_003E;\n\tgoto L_002E;\n\tv61 = *([v51 @ X0_v28 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_002E;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v51, v45, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv65 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_002E:\n\tv72 = 1;\n\t// 49 NewArr v75 @ X0_v31 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_005D;\nL_003E:\n\tv60 = System.String::op_Equality(gender, \"female\");\n\tv77 = v60 == 0;\n\tif (v77) goto L_007C;\n\tgoto L_0055;\n\tv138 = *([v87 @ X0_v21 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0055;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v87, v59, v58, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv142 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0055:\n\t// 85 NewArr v148 @ X0_v24 (System.Object[]), typeof(System.Object[]), 1\n\tv135 = 2;\nL_005D:\n\tv137 = \"il2cpp_vm_object_box\"(v129, v127, v126, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv172 = v137 == 0;\n\tif (v172) goto L_006A;\n\t// 102 IsInst v185 @ X0_v16, typeof(System.Object), v137 @ X0_v5\nL_006A:\n\tv189 = v117.Length == 0;\n\tif (v189) goto L_007F;\n\tv117[0] = v137;\n\tUnityEngine.AndroidJavaObject::CallStatic(v113, \"setGender\", v117);\nL_007C:\n\treturn;\n\tv181 = new System.NullReferenceException();\nL_007F:\n\tv194 = new System.IndexOutOfRangeException();\n\tgoto L_0084;\n\tv195 = new System.ArrayTypeMismatchException();\nL_0084:\n\tthrow v198;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setGender(string gender)
		{
			//IL_011d: Expected O, but got I4
			//IL_0125: Expected O, but got I4
			//IL_0133: Expected I, but got O
			//IL_017d: Expected O, but got I4
			//IL_0185: Expected O, but got I4
			//IL_0193: Expected I, but got O
			AndroidJavaObject gA;
			object[] array2;
			if (!(gender == "male"))
			{
				if (!(gender == "female"))
				{
					return;
				}
				object[] array = new object[1];
				int num = 2;
				object obj = 0;
				object obj2 = num;
				IntPtr intPtr = (IntPtr)typeof(int);
				gA = GA;
				array2 = array;
			}
			else
			{
				int num2 = 1;
				object[] array3 = new object[1];
				object obj = 0;
				object obj2 = num2;
				IntPtr intPtr = (IntPtr)typeof(int);
				gA = GA;
				array2 = array3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
			}
			if (array2.Length != 0)
			{
				array2[0] = obj3;
				gA.CallStatic("setGender", array2);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x15AD0BC", Offset = "0x15AD0BC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA89A8]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029873]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Int32), &birthYear @ X0 (System.Int32)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setBirthYear\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setBirthYear(int birthYear)
		{
			object[] array = new object[1];
			array = (object[])(object)birthYear;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				GA.CallStatic("setBirthYear", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x15AD1CC", Offset = "0x15AD1CC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF3410]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029874]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &enabled @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setEnabledManualSessionHandling\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setManualSessionHandling(bool enabled)
		{
			object[] array = new object[1];
			array = (object[])(object)enabled;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				GA.CallStatic("setEnabledManualSessionHandling", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x15AD2DC", Offset = "0x15AD2DC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC3FB8]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029875]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &enabled @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"setEnabledEventSubmission\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void setEventSubmission(bool enabled)
		{
			object[] array = new object[1];
			array = (object[])(object)enabled;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				GA.CallStatic("setEnabledEventSubmission", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x15AD3EC", Offset = "0x15AD3EC", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA9530]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029876]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv119 = v79;\n\tv120 = 0x8907BC(v119, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0062;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"startSession\", v106.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void gameAnalyticsStartSession()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GA.CallStatic("startSession");
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x15AD508", Offset = "0x15AD508", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECD050]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029877]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv119 = v79;\n\tv120 = 0x8907BC(v119, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0062;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"endSession\", v106.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void gameAnalyticsEndSession()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GA.CallStatic("endSession");
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x15AD624", Offset = "0x15AD624", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EBB4F8]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, defaultValue, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029878]) = v43;\nL_001C:\n\tgoto L_0029;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v46, defaultValue, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0029:\n\t// 41 NewArr v63 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv67 = key == 0;\n\tif (v67) goto L_0035;\n\t// 50 IsInst v109 @ X0_v24, typeof(System.Object), key @ X0 (System.String)\nL_0035:\n\tv143 = v63.Length;\n\tv116 = v63.Length == 0;\n\tif (v116) goto L_0062;\n\tv63[0] = key;\n\tv146 = defaultValue == 0;\n\tif (v146) goto L_0042;\n\t// 62 IsInst v165 @ X0_v22, typeof(System.Object), defaultValue @ X1 (System.String)\n\tv143 = v63.Length;\nL_0042:\n\tv173 = v143 < 1;\n\tv134 = ~v173;\n\tv132 = v143 - 1;\n\tv128 = v132 == 0;\n\tv174 = ~v134;\n\tv118 = v174 | v128;\n\tif (v118) goto L_0062;\n\tv63[1] = defaultValue;\n\treturnVal2 = UnityEngine.AndroidJavaObject::CallStatic(v58.GA, \"getRemoteConfigsValueAsString\", v63);\n\treturn returnVal2;\nL_0062:\n\tv161 = new System.IndexOutOfRangeException();\n\tgoto L_0067;\n\tv170 = new System.ArrayTypeMismatchException();\nL_0067:\n\tthrow v210;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string getRemoteConfigsValueAsString(string key, string defaultValue)
		{
			//IL_003e: Expected O, but got I4
			//IL_0134: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			if (key != null)
			{
				object obj = key as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = key;
				if (defaultValue != null)
				{
					object obj3 = defaultValue as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = defaultValue;
					return GA.CallStatic<string>("getRemoteConfigsValueAsString", array);
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x15AD74C", Offset = "0x15AD74C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDF2C8]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029879]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv122 = v79;\n\tv123 = 0x8907BC(v122, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0064;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"isRemoteConfigsReady\", v107.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool isRemoteConfigsReady()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return GA.CallStatic<bool>("isRemoteConfigsReady", Array.Empty<object>());
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x15AD870", Offset = "0x15AD870", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED4C50]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202987A]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv122 = v79;\n\tv123 = 0x8907BC(v122, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0064;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"getRemoteConfigsContentAsString\", v107.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string getRemoteConfigsContentAsString()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return GA.CallStatic<string>("getRemoteConfigsContentAsString", Array.Empty<object>());
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x15AD994", Offset = "0x15AD994", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EFAAF8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202987B]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = key == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), key @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = key;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"startTimer\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void startTimer(string key)
		{
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
			}
			if (array.Length != 0)
			{
				array[0] = key;
				GA.CallStatic("startTimer", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x15ADA88", Offset = "0x15ADA88", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB00A8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202987C]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = key == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), key @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = key;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"pauseTimer\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void pauseTimer(string key)
		{
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
			}
			if (array.Length != 0)
			{
				array[0] = key;
				GA.CallStatic("pauseTimer", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x15ADB7C", Offset = "0x15ADB7C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB0E78]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202987D]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = key == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), key @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = key;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"resumeTimer\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void resumeTimer(string key)
		{
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
			}
			if (array.Length != 0)
			{
				array[0] = key;
				GA.CallStatic("resumeTimer", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x15ADC70", Offset = "0x15ADC70", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECCB60]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202987E]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = GameAnalyticsSDK.Wrapper.GA_Wrapper;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = key == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v19, typeof(System.Object), key @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_004A;\n\tv60[0] = key;\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v55.GA, \"stopTimer\", v60);\n\treturn returnVal1;\n\tv65 = new System.NullReferenceException();\nL_004A:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0051;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_0051:\n\tthrow v105;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static long stopTimer(string key)
		{
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
			}
			if (array.Length != 0)
			{
				array[0] = key;
				return GA.CallStatic<long>("stopTimer", array);
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x15A104C", Offset = "0x15A104C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB0BD0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202987F]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureAvailableCustomDimensions01(list);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableCustomDimensions01(string list)
		{
			configureAvailableCustomDimensions01(list);
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x15A1158", Offset = "0x15A1158", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE3EB0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029880]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureAvailableCustomDimensions02(list);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableCustomDimensions02(string list)
		{
			configureAvailableCustomDimensions02(list);
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x15A1264", Offset = "0x15A1264", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0B9C8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029881]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureAvailableCustomDimensions03(list);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableCustomDimensions03(string list)
		{
			configureAvailableCustomDimensions03(list);
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x15A14A0", Offset = "0x15A14A0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F07E30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029882]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureAvailableResourceCurrencies(list);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableResourceCurrencies(string list)
		{
			configureAvailableResourceCurrencies(list);
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x15A16D0", Offset = "0x15A16D0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBB668]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029883]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureAvailableResourceItemTypes(list);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableResourceItemTypes(string list)
		{
			configureAvailableResourceItemTypes(list);
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x15A3314", Offset = "0x15A3314", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF2DC8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029884]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureSdkGameEngineVersion(unitySdkVersion);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetUnitySdkVersion(string unitySdkVersion)
		{
			configureSdkGameEngineVersion(unitySdkVersion);
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x15A3540", Offset = "0x15A3540", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEEBE8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029885]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureGameEngineVersion(unityEngineVersion);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetUnityEngineVersion(string unityEngineVersion)
		{
			configureGameEngineVersion(unityEngineVersion);
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x15A35A4", Offset = "0x15A35A4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFD518]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029886]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureBuild(build);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetBuild(string build)
		{
			configureBuild(build);
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x15A44FC", Offset = "0x15A44FC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC4C98]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029887]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::configureUserId(userId);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomUserId(string userId)
		{
			configureUserId(userId);
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x15A4560", Offset = "0x15A4560", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB5358]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029888]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setManualSessionHandling(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetEnabledManualSessionHandling(bool enabled)
		{
			setManualSessionHandling(enabled);
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x15A4628", Offset = "0x15A4628", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA76D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029889]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setEventSubmission(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetEnabledEventSubmission(bool enabled)
		{
			setEventSubmission(enabled);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x15A46E8", Offset = "0x15A46E8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EEB370]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202988A]) = v35;\nL_0011:\n\tv36 = GameAnalyticsSDK.State.GAState::IsManualSessionHandlingEnabled();\n\tv38 = v36 == 0;\n\tif (v38) goto L_002D;\n\tgoto L_0025;\n\tv51 = *([v41 @ X0_v7 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::gameAnalyticsStartSession();\n\treturn;\nL_002D:\n\tgoto L_003B;\n\tv61 = *([v47 @ X0_v3+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_003B;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v47, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_003B:\n\tUnityEngine.Debug::Log(\"Manual session handling is not enabled. \\nPlease check the \\\"Use manual session handling\\\" option in the \\\"Advanced\\\" section of the Settings object.\");\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartSession()
		{
			if (GAState.IsManualSessionHandlingEnabled())
			{
				gameAnalyticsStartSession();
			}
			else
			{
				Debug.Log("Manual session handling is not enabled. \nPlease check the \"Use manual session handling\" option in the \"Advanced\" section of the Settings object.");
			}
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x15A47E4", Offset = "0x15A47E4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EC6060]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202988B]) = v35;\nL_0011:\n\tv36 = GameAnalyticsSDK.State.GAState::IsManualSessionHandlingEnabled();\n\tv38 = v36 == 0;\n\tif (v38) goto L_002D;\n\tgoto L_0025;\n\tv51 = *([v41 @ X0_v7 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::gameAnalyticsEndSession();\n\treturn;\nL_002D:\n\tgoto L_003B;\n\tv61 = *([v47 @ X0_v3+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_003B;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v47, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_003B:\n\tUnityEngine.Debug::Log(\"Manual session handling is not enabled. \\nPlease check the \\\"Use manual session handling\\\" option in the \\\"Advanced\\\" section of the Settings object.\");\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EndSession()
		{
			if (GAState.IsManualSessionHandlingEnabled())
			{
				gameAnalyticsEndSession();
			}
			else
			{
				Debug.Log("Manual session handling is not enabled. \nPlease check the \"Use manual session handling\" option in the \"Advanced\" section of the Settings object.");
			}
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x15A38BC", Offset = "0x15A38BC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA7EF0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, gamesecret, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202988C]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, gamesecret, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::initialize(gamekey, gamesecret);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize(string gamekey, string gamesecret)
		{
			initialize(gamekey, gamesecret);
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x15A1C00", Offset = "0x15A1C00", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF5788]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202988D]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setCustomDimension01(customDimension);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomDimension01(string customDimension)
		{
			setCustomDimension01(customDimension);
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x15A1CC8", Offset = "0x15A1CC8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEF7D8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202988E]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setCustomDimension02(customDimension);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomDimension02(string customDimension)
		{
			setCustomDimension02(customDimension);
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x15A1D90", Offset = "0x15A1D90", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F06188]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202988F]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setCustomDimension03(customDimension);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomDimension03(string customDimension)
		{
			setCustomDimension03(customDimension);
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x159FF54", Offset = "0x159FF54", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0029;\n\tv49 = *([1EBD4A8]);\n\tv50 = *([v49 @ X8_v9]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, amount, itemType, itemId, cartType, receipt, store, signature, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2029890]) = v62;\nL_0029:\n\tgoto L_0030;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0030;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, amount, itemType, itemId, cartType, receipt, store, signature, v52, v53, v54, v55, v56, v57, v58, v59);\nL_0030:\n\tv77 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(*([v24 @ X29_v1+10]));\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addBusinessEventWithReceipt(currency, amount, itemType, itemId, cartType, receipt, store, signature, fields);\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddBusinessEventWithReceipt(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string store, string signature, IDictionary<string, object> fields)
		{
			//IL_001e: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			string text = DictionaryToJsonString((IDictionary<string, object>)0);
			addBusinessEventWithReceipt(currency, amount, itemType, itemId, cartType, receipt, store, signature, (string)(object)fields);
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x15A00C0", Offset = "0x15A00C0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EE6D68]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, amount, itemType, itemId, cartType, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2029891]) = v53;\nL_0023:\n\tgoto L_002A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, amount, itemType, itemId, cartType, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_002A:\n\tv68 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(fields);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addBusinessEvent(currency, amount, itemType, itemId, cartType, fields);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, IDictionary<string, object> fields)
		{
			string text = DictionaryToJsonString(fields);
			addBusinessEvent(currency, amount, itemType, itemId, cartType, (string)(object)fields);
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x15A0E9C", Offset = "0x15A0E9C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EB0310]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, currency, itemType, itemId, fields, methodInfo, v42, v43, amount, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2029892]) = v53;\nL_0023:\n\tgoto L_002A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, currency, itemType, itemId, fields, methodInfo, v42, v43, amount, v44, v45, v46, v47, v48, v49, v50);\nL_002A:\n\tv68 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(fields);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addResourceEvent(flowType, currency, amount, itemType, itemId, fields);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId, IDictionary<string, object> fields)
		{
			string text = DictionaryToJsonString(fields);
			addResourceEvent((int)flowType, currency, amount, itemType, itemId, (string)(object)fields);
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x15A0D60", Offset = "0x15A0D60", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1ED90B0]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, progression01, progression02, progression03, fields, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029893]) = v50;\nL_0021:\n\tgoto L_0028;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, progression01, progression02, progression03, fields, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0028:\n\tv65 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(fields);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addProgressionEvent(progressionStatus, progression01, progression02, progression03, fields);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, IDictionary<string, object> fields)
		{
			string text = DictionaryToJsonString(fields);
			addProgressionEvent((int)progressionStatus, progression01, progression02, progression03, (string)(object)fields);
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x15A0CB8", Offset = "0x15A0CB8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1ECBCF0]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, progression01, progression02, progression03, score, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2029894]) = v53;\nL_0023:\n\tgoto L_002A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, progression01, progression02, progression03, score, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_002A:\n\tv68 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(fields);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addProgressionEventWithScore(progressionStatus, progression01, progression02, progression03, score, fields);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddProgressionEventWithScore(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> fields)
		{
			string text = DictionaryToJsonString(fields);
			addProgressionEventWithScore((int)progressionStatus, progression01, progression02, progression03, score, (string)(object)fields);
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x15A078C", Offset = "0x15A078C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF40A8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fields, methodInfo, v30, v31, v32, v33, v34, eventValue, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029895]) = v44;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, fields, methodInfo, v30, v31, v32, v33, v34, eventValue, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tv59 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(fields);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addDesignEventWithValue(eventID, eventValue, fields);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddDesignEvent(string eventID, float eventValue, IDictionary<string, object> fields)
		{
			string text = DictionaryToJsonString(fields);
			addDesignEventWithValue(eventID, eventValue, (string)(object)fields);
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x15A0814", Offset = "0x15A0814", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC28E8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fields, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029896]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, fields, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(fields);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addDesignEvent(eventID, fields);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddDesignEvent(string eventID, IDictionary<string, object> fields)
		{
			string text = DictionaryToJsonString(fields);
			addDesignEvent(eventID, (string)(object)fields);
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15A0908", Offset = "0x15A0908", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC9F98]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, message, fields, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029897]) = v44;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, message, fields, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tv59 = GameAnalyticsSDK.Wrapper.GA_Wrapper::DictionaryToJsonString(fields);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addErrorEvent(severity, message, fields);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddErrorEvent(GAErrorSeverity severity, string message, IDictionary<string, object> fields)
		{
			string text = DictionaryToJsonString(fields);
			addErrorEvent((int)severity, message, (string)(object)fields);
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x159FBAC", Offset = "0x159FBAC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EBA430]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, adType, adSdkName, adPlacement, duration, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029898]) = v50;\nL_0021:\n\tgoto L_0035;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0035;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, adType, adSdkName, adPlacement, duration, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0035:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addAdEventWithDuration(adAction, adType, adSdkName, adPlacement, duration);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddAdEventWithDuration(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration)
		{
			addAdEventWithDuration((int)adAction, (int)adType, adSdkName, adPlacement, duration);
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x159FCD4", Offset = "0x159FCD4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1F09C50]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, adType, adSdkName, adPlacement, noAdReason, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029899]) = v50;\nL_0021:\n\tgoto L_0035;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0035;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, adType, adSdkName, adPlacement, noAdReason, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0035:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addAdEventWithReason(adAction, adType, adSdkName, adPlacement, noAdReason);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddAdEventWithReason(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason)
		{
			addAdEventWithReason((int)adAction, (int)adType, adSdkName, adPlacement, (int)noAdReason);
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x159FDF4", Offset = "0x159FDF4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EF9798]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202989A]) = v47;\nL_001F:\n\tgoto L_0031;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0031;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0031:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::addAdEvent(adAction, adType, adSdkName, adPlacement);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement)
		{
			addAdEvent((int)adAction, (int)adType, adSdkName, adPlacement);
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x15A1798", Offset = "0x15A1798", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0EA28]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202989B]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setEnabledInfoLog(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetInfoLog(bool enabled)
		{
			setEnabledInfoLog(enabled);
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x15A1860", Offset = "0x15A1860", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF8390]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202989C]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setEnabledVerboseLog(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetVerboseLog(bool enabled)
		{
			setEnabledVerboseLog(enabled);
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x15A1928", Offset = "0x15A1928", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF30A0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202989D]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setFacebookId(facebookId);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetFacebookId(string facebookId)
		{
			setFacebookId(facebookId);
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x15A1A70", Offset = "0x15A1A70", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED6EE0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202989E]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setGender(gender);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetGender(string gender)
		{
			setGender(gender);
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x15A1B38", Offset = "0x15A1B38", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC6C30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202989F]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::setBirthYear(birthYear);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetBirthYear(int birthYear)
		{
			setBirthYear(birthYear);
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x15A4B44", Offset = "0x15A4B44", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFBDB0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, defaultValue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298A0]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, defaultValue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::getRemoteConfigsValueAsString(key, defaultValue);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetRemoteConfigsValueAsString(string key, string defaultValue)
		{
			return getRemoteConfigsValueAsString(key, defaultValue);
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x15A4C14", Offset = "0x15A4C14", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB9230]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20298A1]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::isRemoteConfigsReady();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRemoteConfigsReady()
		{
			return isRemoteConfigsReady();
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x15A4CCC", Offset = "0x15A4CCC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED9CF8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20298A2]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::getRemoteConfigsContentAsString();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetRemoteConfigsContentAsString()
		{
			return getRemoteConfigsContentAsString();
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x15ADD6C", Offset = "0x15ADD6C", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EAA550]);\n\tv23 = *([v22 @ X8_v30]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20298A3]) = v42;\nL_0018:\n\tv46 = new System.Collections.Hashtable();\n\tSystem.Collections.Hashtable::.ctor(v46);\n\tv49 = dict == 0;\n\tif (v49) goto L_0119;\n\tgoto L_004B;\n\tv127 = *([v51 @ X8_v6+B0]);\n\tv128 = 0;\n\tv129 = v127 + 8;\n\tv131 = *([v167 @ X11_v29-8]);\n\tv173 = v131 == v54;\n\tif (v173) goto L_0044;\n\tv153 = v168 + 1;\n\tv227 = v153 < v53;\n\tv149 = ~v227;\n\tv151 = v167 + 0x10;\n\tv133 = ~v149;\n\tif (v133) goto L_FFFFFFFF;\n\tv154 = v16;\n\tv155 = 0;\n\tv156 = 0x8909C4(v154, v54, v155, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_004B;\nL_0044:\n\tv228 = *([v167 @ X11_v29]);\n\tv229 = v228 << 4;\n\tv230 = v51 + v229;\n\tv231 = v230 + 0x130;\nL_004B:\n\tv252 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>>::GetEnumerator(dict);\nL_0057:\n\tgoto L_007E;\n\tv305 = *([v299 @ X8_v18+B0]);\n\tv306 = 0;\n\tv307 = v305 + 8;\n\tv309 = *([v372 @ X11_v24-8]);\n\tv378 = v309 == v300;\n\tif (v378) goto L_0077;\n\tv331 = v373 + 1;\n\tv383 = v331 < v301;\n\tv327 = ~v383;\n\tv329 = v372 + 0x10;\n\tv311 = ~v327;\n\tif (v311) goto L_FFFFFFFF;\n\tv332 = v116;\n\tv333 = 0;\n\tv334 = 0x8909C4(v332, v300, v333, v66, v257, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_007E;\nL_0077:\n\tv384 = *([v372 @ X11_v24]);\n\tv385 = v384 << 4;\n\tv386 = v299 + v385;\n\tv387 = v386 + 0x130;\nL_007E:\n\tv408 = System.Collections.IEnumerator::MoveNext(v252);\n\tv410 = v408 == 0;\n\tif (v410) goto L_00BC;\n\tgoto L_00AD;\n\tv434 = *([v421 @ X8_v21+B0]);\n\tv435 = 0;\n\tv436 = v434 + 8;\n\tv438 = *([v506 @ X11_v19-8]);\n\tv512 = v438 == v422;\n\tif (v512) goto L_00A6;\n\tv460 = v507 + 1;\n\tv571 = v460 < v423;\n\tv456 = ~v571;\n\tv458 = v506 + 0x10;\n\tv440 = ~v456;\n\tif (v440) goto L_FFFFFFFF;\n\tv461 = v116;\n\tv462 = 0;\n\tv463 = 0x8909C4(v461, v422, v462, v66, v257, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00AD;\nL_00A6:\n\tv572 = *([v506 @ X11_v19]);\n\tv573 = v572 << 4;\n\tv574 = v421 + v573;\n\tv575 = v574 + 0x130;\nL_00AD:\n\tv356 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>>::get_Current(v252);\n\tv295 = v46 == 0;\n\tif (v295) goto L_00C3;\n\tv297 = *([v46 @ X0_v3 (System.Collections.Hashtable)]);\n\tv293 = System.Collections.Hashtable::Add(v46, v356, 0);\n\tgoto L_0057;\nL_00BC:\n\tv427 = v252 == 0;\n\tv428 = ~v427;\n\tif (v428) goto L_00DF;\n\tgoto L_0107;\n\tthrow System.NullReferenceException;\nL_00C3:\n\tv361 = new System.NullReferenceException();\n\tgoto L_00D1;\n\tgoto L_00D1;\n\tgoto L_00D1;\n\tgoto L_00D1;\nL_00D1:\n\tv420 = v108 != 1;\n\tif (v420) goto L_011F;\n\tv429 = 0x6D2BC0(v361, v108, v264, *([v297 @ X8_v24 (Il2CppClass<System.Collections.Hashtable>)+218]), v179, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv466 = *([v429 @ X0_v26]);\n\tv486 = 0x6D2490(v429, v108, v264, *([v297 @ X8_v24 (Il2CppClass<System.Collections.Hashtable>)+218]), v179, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv488 = v252 == 0;\n\tif (v488) goto L_0107;\nL_00DF:\n\tgoto L_0106;\n\tv541 = *([v491 @ X8_v13+B0]);\n\tv542 = 0;\n\tv543 = v541 + 8;\n\tv545 = *([v591 @ X11_v11-8]);\n\tv597 = v545 == v494;\n\tif (v597) goto L_00FF;\n\tv567 = v592 + 1;\n\tv604 = v567 < v493;\n\tv563 = ~v604;\n\tv565 = v591 + 0x10;\n\tv547 = ~v563;\n\tif (v547) goto L_FFFFFFFF;\n\tv568 = v116;\n\tv569 = 0;\n\tv570 = 0x8909C4(v568, v494, v569, v66, v464, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0106;\nL_00FF:\n\tv605 = *([v591 @ X11_v11]);\n\tv606 = v605 << 4;\n\tv607 = v491 + v606;\n\tv608 = v607 + 0x130;\nL_0106:\n\tSystem.IDisposable::Dispose(v252);\nL_0107:\n\tv114 = v64 + 1;\n\tv88 = v114 == 0;\n\tv73 = ~v88;\n\tif (v73) goto L_0119;\n\tv580 = v62 == 0;\n\tv113 = ~v580;\n\tif (v113) goto L_011E;\nL_0119:\n\treturnVal1 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Serializer::Serialize(v46);\n\treturn returnVal1;\nL_011E:\n\tv433 = new System.TypeLoadException();\nL_011F:\n\treturnVal2 = 0x6D2380(v361, v108, v191, *([v297 @ X8_v24 (Il2CppClass<System.Collections.Hashtable>)+218]), v179, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 155 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string DictionaryToJsonString(IDictionary<string, object> dict)
		{
			//IL_001c: Expected I, but got O
			//IL_00ea: Expected I4, but got O
			//IL_0126: Expected I4, but got O
			Hashtable hashtable = new Hashtable();
			bool flag = dict == null;
			KeyValuePair<string, object> keyValuePair = default(KeyValuePair<string, object>);
			if (!flag)
			{
				IEnumerator<KeyValuePair<string, object>> enumerator = dict.GetEnumerator();
				object obj = null;
				keyValuePair = default(KeyValuePair<string, object>);
				object obj4 = default(object);
				object obj3 = default(object);
				string result = default(string);
				while (true)
				{
					int num;
					int num2;
					object obj2;
					int num3;
					int num4;
					KeyValuePair<string, object> keyValuePair2;
					NullReferenceException ex;
					if (!enumerator.MoveNext())
					{
						bool flag2 = enumerator == null;
						bool flag3 = !flag2;
						num = 0;
						num2 = 0;
						if (!flag3)
						{
							obj2 = obj3;
							num3 = 0;
							num4 = 0;
							keyValuePair = default(KeyValuePair<string, object>);
							goto IL_0270;
						}
					}
					else
					{
						KeyValuePair<string, object> current = enumerator.Current;
						bool flag4 = hashtable == null;
						keyValuePair2 = (KeyValuePair<string, object>)obj;
						if (!flag4)
						{
							IntPtr intPtr = (IntPtr)hashtable;
							hashtable.Add(current, null);
							obj3 = null;
							obj = null;
							keyValuePair = current;
							continue;
						}
						ex = new NullReferenceException();
						if ((IntPtr)keyValuePair != (IntPtr)1)
						{
							goto IL_01ae;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						num = (int)obj4;
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						bool flag5 = enumerator == null;
						num2 = -1;
						obj2 = obj3;
						num3 = (int)obj4;
						num4 = -1;
						if (flag5)
						{
							goto IL_0270;
						}
					}
					enumerator.Dispose();
					obj2 = obj3;
					num3 = num;
					num4 = num2;
					keyValuePair = default(KeyValuePair<string, object>);
					goto IL_0270;
					IL_0270:
					if (num4 + 1 != 0 || num3 == 0)
					{
						break;
					}
					TypeLoadException ex2 = new TypeLoadException();
					obj3 = obj2;
					keyValuePair2 = default(KeyValuePair<string, object>);
					keyValuePair = default(KeyValuePair<string, object>);
					ex = (NullReferenceException)(object)ex2;
					goto IL_01ae;
					IL_01ae:
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					return result;
				}
			}
			return GA_MiniJSON.Serializer.Serialize(hashtable);
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x15A4D8C", Offset = "0x15A4D8C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED06B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298A4]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::startTimer(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartTimer(string key)
		{
			startTimer(key);
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x15A4E54", Offset = "0x15A4E54", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EACF50]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298A5]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::pauseTimer(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PauseTimer(string key)
		{
			pauseTimer(key);
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x15A4F1C", Offset = "0x15A4F1C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDEE78]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298A6]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::resumeTimer(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ResumeTimer(string key)
		{
			resumeTimer(key);
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x15A4FE4", Offset = "0x15A4FE4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE9660]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298A7]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::stopTimer(key);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long StopTimer(string key)
		{
			return stopTimer(key);
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x15AE01C", Offset = "0x15AE01C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GA_Wrapper()
		{
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x15AE024", Offset = "0x15AE024", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBA9D8]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20298A8]) = v39;\nL_0016:\n\tv43 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v43, \"com.gameanalytics.sdk.GameAnalytics\");\n\tv52.GA = v43;\n\tv54 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v54, \"com.gameanalytics.sdk.unity.UnityGameAnalytics\");\n\tv61.UNITY_GA = v54;\n\tv63 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v63, \"com.gameanalytics.sdk.imei.GAImei\");\n\tv70.GA_IMEI = v63;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static GA_Wrapper()
		{
			AndroidJavaClass gA = new AndroidJavaClass("com.gameanalytics.sdk.GameAnalytics");
			GA = gA;
			AndroidJavaClass uNITY_GA = new AndroidJavaClass("com.gameanalytics.sdk.unity.UnityGameAnalytics");
			UNITY_GA = uNITY_GA;
			AndroidJavaClass gA_IMEI = new AndroidJavaClass("com.gameanalytics.sdk.imei.GAImei");
			GA_IMEI = gA_IMEI;
		}
	}
}
