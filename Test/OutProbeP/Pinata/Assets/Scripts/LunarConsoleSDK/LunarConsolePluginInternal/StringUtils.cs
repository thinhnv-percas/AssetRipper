using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x200002E")]
	public static class StringUtils
	{
		[Token(Token = "0x400007F")]
		private static readonly char[] kSpaceSplitChars;

		[Token(Token = "0x4000080")]
		private static readonly Regex kRichTagRegex;

		[Token(Token = "0x4000081")]
		private static List<string> s_tempList;

		[Token(Token = "0x4000082")]
		private static readonly string Quote;

		[Token(Token = "0x4000083")]
		private static readonly string SingleQuote;

		[Token(Token = "0x4000084")]
		private static readonly string EscapedQuote;

		[Token(Token = "0x4000085")]
		private static readonly string EscapedSingleQuote;

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x13E0160", Offset = "0x13E0160", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F04320]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AFC]) = v41;\nL_0015:\n\tv42 = format == 0;\n\tif (v42) goto L_0028;\n\tv43 = args == 0;\n\tif (v43) goto L_0028;\n\tv51 = args.Length == 0;\n\tif (v51) goto L_0028;\n\tv49 = System.String::Format(format, args);\nL_0028:\n\treturn v52;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_006E;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0062;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_006A;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EC0E38]);\n\tX1 = X0;\n\tX2 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX8 = *([1EBC820]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_005E;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005E;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005E:\n\tX0 = X20;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\n\tgoto L_0028;\nL_0062:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006A:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006E:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string TryFormat(string format, params object[] args)
		{
			bool flag = format == null;
			string result = format;
			if (!flag)
			{
				bool flag2 = args == null;
				result = format;
				if (!flag2)
				{
					bool flag3 = args.Length == 0;
					result = format;
					if (!flag3)
					{
						string text = string.Format(format, args);
						result = text;
					}
				}
			}
			return result;
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x13DDDF8", Offset = "0x13DDDF8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = str == 0;\n\tif (v0) goto L_0009;\n\tv2 = prefix == 0;\n\tif (v2) goto L_0009;\n\treturnVal2 = System.String::StartsWith(str, prefix, 5);\n\treturn returnVal2;\nL_0009:\n\treturn 0;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool StartsWithIgnoreCase(string str, string prefix)
		{
			if (str != null && prefix != null)
			{
				return str.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x13E58FC", Offset = "0x13E58FC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::Equals(a, b, 5);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool EqualsIgnoreCase(string a, string b)
		{
			return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x13E5908", Offset = "0x13E5908", Length = "0x37C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EA9128]);\n\tv33 = *([v32 @ X8_v39]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, prefix, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2028AFD]) = v51;\nL_001C:\n\tv54 = System.String::IsNullOrEmpty(prefix);\n\tv56 = v54 == 0;\n\tif (v56) goto L_0025;\n\tgoto L_016E;\nL_0025:\n\tv61 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v61);\n\tgoto L_005A;\n\tv265 = *([v206 @ X8_v17+B0]);\n\tv266 = 0;\n\tv267 = v265 + 8;\n\tv269 = *([v351 @ X11_v36-8]);\n\tv357 = v269 == v209;\n\tif (v357) goto L_0053;\n\tv291 = v352 + 1;\n\tv362 = v291 < v208;\n\tv287 = ~v362;\n\tv289 = v351 + 0x10;\n\tv271 = ~v287;\n\tif (v271) goto L_FFFFFFFF;\n\tv292 = v26;\n\tv293 = 0;\n\tv294 = 0x8909C4(v292, v209, v293, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_005A;\nL_0053:\n\tv363 = *([v351 @ X11_v36]);\n\tv364 = v363 << 4;\n\tv365 = v206 + v364;\n\tv366 = v365 + 0x130;\nL_005A:\n\tv334 = System.Collections.Generic.IEnumerable`1<System.String>::GetEnumerator(strings);\n\tv336 = v334 == 0;\n\tif (v336) goto L_0113;\nL_006A:\n\tgoto L_0091;\n\tv442 = *([v436 @ X8_v21+B0]);\n\tv443 = 0;\n\tv444 = v442 + 8;\n\tv446 = *([v484 @ X11_v31-8]);\n\tv490 = v446 == v437;\n\tif (v490) goto L_008A;\n\tv468 = v485 + 1;\n\tv573 = v468 < v438;\n\tv464 = ~v573;\n\tv466 = v484 + 0x10;\n\tv448 = ~v464;\n\tif (v448) goto L_FFFFFFFF;\n\tv469 = v260;\n\tv470 = 0;\n\tv471 = 0x8909C4(v469, v437, v470, v392, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0091;\nL_008A:\n\tv574 = *([v484 @ X11_v31]);\n\tv575 = v574 << 4;\n\tv576 = v436 + v575;\n\tv577 = v576 + 0x130;\nL_0091:\n\tv535 = System.Collections.IEnumerator::MoveNext(v334);\n\tv582 = v535 == 0;\n\tif (v582) goto L_010B;\n\tgoto L_00C0;\n\tv641 = *([v614 @ X8_v24+B0]);\n\tv642 = 0;\n\tv643 = v641 + 8;\n\tv645 = *([v689 @ X11_v26-8]);\n\tv695 = v645 == v615;\n\tif (v695) goto L_00B9;\n\tv667 = v690 + 1;\n\tv700 = v667 < v616;\n\tv663 = ~v700;\n\tv665 = v689 + 0x10;\n\tv647 = ~v663;\n\tif (v647) goto L_FFFFFFFF;\n\tv668 = v260;\n\tv669 = 0;\n\tv670 = 0x8909C4(v668, v615, v669, v392, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00C0;\nL_00B9:\n\tv701 = *([v689 @ X11_v26]);\n\tv702 = v701 << 4;\n\tv703 = v614 + v702;\n\tv704 = v703 + 0x130;\nL_00C0:\n\tv709 = System.Collections.Generic.IEnumerator`1<System.String>::get_Current(v334);\n\tgoto L_00CC;\n\tv714 = *([v710 @ X0_v37+E0]);\n\tv715 = v714 == 0;\n\tv716 = ~v715;\n\tgoto L_00CC;\n\tv717 = \"il2cpp_codegen_runtime_class_init\"(v710, v423, v396, v392, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00CC:\n\tv430 = prefix == 0;\n\tif (v430) goto L_006A;\n\tv431 = v709 == 0;\n\tif (v431) goto L_006A;\n\tv427 = System.String::StartsWith(v709, prefix, 5);\n\tv432 = v427 == 0;\n\tif (v432) goto L_006A;\n\tv721 = *([v61 @ X0_v7 (System.Collections.Generic.List`1<System.String>)]);\n\tv433 = *([v721 @ X8_v29 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+126]) == 0;\n\tif (v433) goto L_00FC;\n\tv765 = *([v721 @ X8_v29 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+B0]) + 8;\nL_00E7:\n\tv771 = *([v765 @ X11_v21-8]) == System.Collections.Generic.ICollection`1<System.String>;\n\tif (v771) goto L_00FF;\n\tv766 = v766 + 1;\n\tv776 = v766 < *([v721 @ X8_v29 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+126]);\n\tv747 = ~v776;\n\tv765 = v765 + 0x10;\n\tv731 = ~v747;\n\tif (v731) goto L_00E7;\nL_00FC:\n\tv783 = 0x8909C4(v61, System.Collections.Generic.ICollection`1<System.String>, 2, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0107;\nL_00FF:\n\tv778 = *([v765 @ X11_v21]) + 2;\n\tv779 = v778 << 4;\n\tv780 = v721 + v779;\n\tv783 = v780 + 0x130;\nL_0107:\n\t*([v783 @ X0_v43])(v428, v61, v709, *([v783 @ X0_v43+8]), 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_006A;\nL_010B:\n\tv618 = v334 == 0;\n\tv537 = ~v618;\n\tif (v537) goto L_0130;\n\tgoto L_0158;\n\tthrow System.NullReferenceException;\n\tv264 = new System.NullReferenceException();\nL_0113:\n\tv340 = new System.NullReferenceException();\n\tgoto L_0122;\n\tgoto L_0122;\n\tgoto L_0122;\n\tgoto L_0122;\n\tgoto L_0122;\nL_0122:\n\tv379 = v191 != 1;\n\tif (v379) goto L_0173;\n\tv384 = 0x6D2BC0(v340, v191, v165, v68, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv539 = *([v384 @ X0_v22]);\n\tv441 = 0x6D2490(v384, v191, v165, v68, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv473 = v538 == 0;\n\tif (v473) goto L_0158;\nL_0130:\n\tgoto L_0157;\n\tv583 = *([v544 @ X8_v11+B0]);\n\tv584 = 0;\n\tv585 = v583 + 8;\n\tv587 = *([v629 @ X11_v9-8]);\n\tv635 = v587 == v547;\n\tif (v635) goto L_0150;\n\tv609 = v630 + 1;\n\tv671 = v609 < v546;\n\tv605 = ~v671;\n\tv607 = v629 + 0x10;\n\tv589 = ~v605;\n\tif (v589) goto L_FFFFFFFF;\n\tv610 = v538;\n\tv611 = 0;\n\tv612 = 0x8909C4(v610, v547, v611, v499, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0157;\nL_0150:\n\tv672 = *([v629 @ X11_v9]);\n\tv673 = v672 << 4;\n\tv674 = v544 + v673;\n\tv675 = v674 + 0x130;\nL_0157:\n\tSystem.IDisposable::Dispose(v334);\nL_0158:\n\tv124 = v66 + 1;\n\tv98 = v124 == 0;\n\tv83 = ~v98;\n\tif (v83) goto L_016E;\n\tv613 = v128 == 0;\n\tv123 = ~v613;\n\tif (v123) goto L_0172;\nL_016E:\n\treturn v131;\nL_0172:\n\tv388 = new System.TypeLoadException();\nL_0173:\n\treturnVal2 = 0x6D2380(v340, 0, 0, v68, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn returnVal2;\n// 206 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IList<string> Filter(IList<string> strings, string prefix)
		{
			//IL_023a: Expected I4, but got O
			//IL_027f: Expected I4, but got O
			//IL_0093: Expected O, but got I4
			//IL_00a9: Expected I, but got O
			//IL_03c3: Expected O, but got I4
			//IL_00e4: Expected O, but got I
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0188: Expected O, but got I
			//IL_0197: Expected O, but got I
			//IL_0130: Expected O, but got I
			IList<string> result;
			if (string.IsNullOrEmpty(prefix))
			{
				result = strings;
				goto IL_02c2;
			}
			List<string> list = new List<string>();
			IEnumerator<string> enumerator = strings.GetEnumerator();
			int num2;
			int num3;
			object obj2 = default(object);
			int num4;
			int num5;
			object obj3 = default(object);
			if (enumerator == null)
			{
				NullReferenceException ex = new NullReferenceException();
				int num = default(int);
				if (num != 1)
				{
					goto IL_02dd;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num2 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator<string> enumerator2 = default(IEnumerator<string>);
				bool flag = enumerator2 == null;
				num3 = -1;
				obj2 = obj3;
				num4 = -1;
				num5 = (int)obj;
				if (flag)
				{
					goto IL_03c8;
				}
			}
			else
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (prefix == null || current == null)
					{
						continue;
					}
					bool flag2 = current.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
					bool flag3 = !flag2;
					obj2 = 0;
					if (flag3)
					{
						continue;
					}
					IntPtr intPtr = (IntPtr)list;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ X8_v29 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0149;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ X8_v29 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+B0]");
					object obj4 = 0L + 8L;
					int num6 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ X11_v21-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ICollection<string>))
						{
							break;
						}
						num6++;
						int num7 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ X8_v29 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+126]");
						bool flag4 = (long)num7 < 0L;
						bool flag5 = !flag4;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_0149;
					}
					object obj5 = obj4 + 2;
					int num8 = (int)((long)(IntPtr)obj5 << 4);
					object obj6 = (long)intPtr + (long)num8;
					object obj7 = (long)(IntPtr)obj6 + 304L;
					goto IL_03b0;
					IL_03b0:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v783 @ X0_v43] (should have been resolved before IL gen)");
					obj2 = 0;
					continue;
					IL_0149:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_03b0;
				}
				bool flag6 = enumerator == null;
				bool flag7 = !flag6;
				num3 = 0;
				num2 = 0;
				if (!flag7)
				{
					num4 = 0;
					obj3 = obj2;
					num5 = 0;
					goto IL_03c8;
				}
			}
			enumerator.Dispose();
			num4 = num3;
			obj3 = obj2;
			num5 = num2;
			goto IL_03c8;
			IL_02c2:
			return result;
			IL_03c8:
			int num9 = num4 + 1;
			bool flag8 = num9 == 0;
			bool flag9 = !flag8;
			result = list;
			if (!flag9)
			{
				bool flag10 = num5 == 0;
				bool flag11 = !flag10;
				result = list;
				if (flag11)
				{
					TypeLoadException ex2 = new TypeLoadException();
					NullReferenceException ex = (NullReferenceException)(object)ex2;
					goto IL_02dd;
				}
			}
			goto IL_02c2;
			IL_02dd:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			IList<string> result2 = default(IList<string>);
			return result2;
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x13E5C84", Offset = "0x13E5C84", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBA0F8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AFE]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::ParseInt(str, 0);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ParseInt(string str)
		{
			return ParseInt(str, 0);
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x13E5CEC", Offset = "0x13E5CEC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(str);\n\tv18 = v16 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0026;\n\tv24 = System.Int32::TryParse(str, &v21 @ stack_-24_v3 (System.Int32));\n\tv39 = v24 == 0;\n\tv30 = ~v39;\n\tv27 = ~v30;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\treturn v53;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ParseInt(string str, int defValue)
		{
			bool flag = string.IsNullOrEmpty(str);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			int result = defValue;
			if (!flag3)
			{
				result = ((!int.TryParse(str, out var result2)) ? defValue : result2);
			}
			return result;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x13E5D44", Offset = "0x13E5D44", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(str);\n\tv18 = v16 == 0;\n\tif (v18) goto L_0014;\n\t*([succeed @ X1 (System.Boolean&)]) = 0;\n\tgoto L_0029;\nL_0014:\n\tv24 = System.Int32::TryParse(str, &v21 @ stack_-24_v3 (System.Int32));\n\t*([succeed @ X1 (System.Boolean&)]) = v24;\n\tv39 = v24 == 0;\n\tv30 = ~v39;\n\tv27 = ~v30;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_0029;\nL_0029:\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static int ParseInt(string str, out bool succeed)
		{
			succeed = default(bool);
			ref bool reference;
			if (string.IsNullOrEmpty(str))
			{
				reference = ref *(bool*)null;
				return 0;
			}
			bool flag = int.TryParse(str, out var result);
			reference = ref *(flag ? ((bool*)1) : ((bool*)null));
			if (flag)
			{
				return result;
			}
			return 0;
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0x13E5DAC", Offset = "0x13E5DAC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDBDF0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AFF]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::ParseFloat(str, 0f);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ParseFloat(string str)
		{
			return ParseFloat(str, 0f);
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0x13D4B28", Offset = "0x13D4B28", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(str);\n\tv18 = v16 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0026;\n\tv24 = System.Single::TryParse(str, &v21 @ stack_-24_v3 (System.Single));\n\tv39 = v24 == 0;\n\tv30 = ~v39;\n\tv27 = ~v30;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\treturn v51;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ParseFloat(string str, float defValue)
		{
			bool flag = string.IsNullOrEmpty(str);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			float result = defValue;
			if (!flag3)
			{
				result = ((!float.TryParse(str, out var result2)) ? defValue : result2);
			}
			return result;
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0x13E5E14", Offset = "0x13E5E14", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(str);\n\tv18 = v16 == 0;\n\tif (v18) goto L_0014;\n\t*([succeed @ X1 (System.Boolean&)]) = 0;\n\tgoto L_002A;\nL_0014:\n\tv24 = System.Single::TryParse(str, &v21 @ stack_-24_v3 (System.Single));\n\t*([succeed @ X1 (System.Boolean&)]) = v24;\n\tv42 = v24 == 0;\n\tv30 = ~v42;\n\tv27 = ~v30;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static float ParseFloat(string str, out bool succeed)
		{
			succeed = default(bool);
			ref bool reference;
			if (string.IsNullOrEmpty(str))
			{
				reference = ref *(bool*)null;
				return 0f;
			}
			bool flag = float.TryParse(str, out var result);
			reference = ref *(flag ? ((bool*)1) : ((bool*)null));
			if (flag)
			{
				return result;
			}
			return 0f;
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0x13E5E80", Offset = "0x13E5E80", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EECA88]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028B00]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::ParseBool(str, 0);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ParseBool(string str)
		{
			return ParseBool(str, defValue: false);
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x13E5EE8", Offset = "0x13E5EE8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB4910]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, defValue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B01]) = v41;\nL_0018:\n\tv45 = System.String::IsNullOrEmpty(str);\n\tv47 = v45 == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0043;\n\tgoto L_002C;\n\tv103 = *([v51 @ X0_v6+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_002C;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v51, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv89 = System.Boolean::TryParse(str, &v85 @ stack_-24_v3 (System.Boolean));\n\tv91 = v89 == 0;\n\tif (v91) goto L_0043;\n\tv71 = v85 == 0;\n\tv56 = ~v71;\nL_0043:\n\treturn v92;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ParseBool(string str, bool defValue)
		{
			bool flag = string.IsNullOrEmpty(str);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			bool result = defValue;
			if (!flag3)
			{
				bool flag4 = bool.TryParse(str, out var result2);
				bool flag5 = !flag4;
				result = defValue;
				if (!flag5)
				{
					bool flag6 = !result2;
					bool flag7 = !flag6;
					result = flag7;
				}
			}
			return result;
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x13E5F8C", Offset = "0x13E5F8C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF79A0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, succeed, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B02]) = v41;\nL_0018:\n\tv45 = System.String::IsNullOrEmpty(str);\n\tv47 = v45 == 0;\n\tif (v47) goto L_0025;\n\t*([succeed @ X1 (System.Boolean&)]) = 0;\n\tgoto L_0048;\nL_0025:\n\tgoto L_002E;\n\tv101 = *([v51 @ X0_v5+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_002E;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v51, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tv109 = System.Boolean::TryParse(str, &v85 @ stack_-24_v3 (System.Boolean));\n\t*([succeed @ X1 (System.Boolean&)]) = v109;\n\tv92 = v109 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\tv72 = v85 == 0;\n\tv57 = ~v72;\n\tgoto L_0048;\nL_0048:\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool ParseBool(string str, out bool succeed)
		{
			succeed = default(bool);
			ref bool reference;
			if (string.IsNullOrEmpty(str))
			{
				reference = ref *(bool*)null;
				return false;
			}
			bool flag = bool.TryParse(str, out var result);
			reference = ref *(flag ? ((bool*)1) : ((bool*)null));
			if (flag)
			{
				bool flag2 = !result;
				return !flag2;
			}
			return false;
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x13E6048", Offset = "0x13E6048", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC5C30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028B03]) = v38;\nL_0013:\n\tv39 = str == 0;\n\tif (v39) goto L_0035;\n\tgoto L_0027;\n\tv51 = *([v42 @ X0_v3 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0027;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv55 = LunarConsolePluginInternal.StringUtils;\nL_0027:\n\tv63 = System.String::Split(str, v58.kSpaceSplitChars, 1);\n\treturnVal2 = LunarConsolePluginInternal.StringUtils::ParseFloats(v63);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float[] ParseFloats(string str)
		{
			if (str == null)
			{
				return null;
			}
			string[] args = str.Split(kSpaceSplitChars, StringSplitOptions.RemoveEmptyEntries);
			return ParseFloats(args);
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x13E60D8", Offset = "0x13E60D8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ED1AB8]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028B04]) = v40;\nL_0014:\n\tv41 = args == 0;\n\tif (v41) goto L_FFFFFFFF;\n\t// 26 NewArr v46 @ X0_v6 (System.Single[]), typeof(System.Single[]), args.Length\n\tv190 = args.Length;\n\tv106 = args.Length < 1;\n\tif (v106) goto L_0064;\nL_002A:\n\tv194 = v177 < v190;\n\tv195 = ~v194;\n\tif (v195) goto L_0065;\n\tv216 = v177 < v46.Length;\n\tv79 = ~v216;\n\tif (v79) goto L_0065;\n\tv50 = v177 << 2;\n\tv91 = v46 + v50;\n\tv85 = v91 + 0x20;\n\tv87 = System.Single::TryParse(args[v177 @ X8_v8 (System.Int32)], v85);\n\tv89 = v87 == 0;\n\tif (v89) goto L_FFFFFFFF;\n\tv190 = args.Length;\n\tv177 = v177 + 1;\n\tv111 = v177 < args.Length;\n\tif (v111) goto L_002A;\n\tgoto L_0064;\nL_0064:\n\treturn v135;\nL_0065:\n\tv215 = new System.IndexOutOfRangeException();\n\tthrow v215;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static float[] ParseFloats(string[] args)
		{
			//IL_0098: Expected O, but got I
			float[] array;
			float[] result;
			if (args != null)
			{
				array = new float[args.Length];
				int num = args.Length;
				bool flag = args.Length < 1;
				result = array;
				if (flag)
				{
					goto IL_0156;
				}
				int num2 = 0;
				while (true)
				{
					if (num2 < num && num2 < array.Length)
					{
						int num3 = num2 << 2;
						object obj = (long)(IntPtr)array + (long)num3;
						if (!float.TryParse(args[num2], out *(float*)((long)(IntPtr)obj + 32L)))
						{
							break;
						}
						num = args.Length;
						num2++;
						if (num2 < args.Length)
						{
							continue;
						}
						goto IL_0114;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			result = null;
			goto IL_0156;
			IL_0156:
			return result;
			IL_0114:
			result = array;
			goto IL_0156;
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0x13E61B8", Offset = "0x13E61B8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF6A28]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028B05]) = v38;\nL_0015:\n\tv41 = 0;\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = System.Double::TryParse(str, &v41 @ stack_-28_v1 (System.Double));\n\treturn v56;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsNumeric(string str)
		{
			double result = 0.0;
			return double.TryParse(str, out result);
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0x13E6238", Offset = "0x13E6238", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\tv6 = &v5 @ stack_-10_v2 - 4;\n\t*([v4 @ X29_v1-4]) = 0;\n\tv8 = System.Int32::TryParse(str, v6);\n\treturn v8;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool IsInteger(string str)
		{
			object obj2 = default(object);
			object obj = obj2;
			ref int result = ref *(int*)((long)(IntPtr)obj2 - 4L);
			_ = 0;
			return int.TryParse(str, out result);
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0x13E6264", Offset = "0x13E6264", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA6600]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B06]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::StartOfTheWord(value, index);\n\treturnVal1 = v57 - index;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int StartOfTheWordOffset(string value, int index)
		{
			int num = StartOfTheWord(value, index);
			return num - index;
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0x13E62E0", Offset = "0x13E62E0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv24 = *([1EC3BE0]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, index, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028B07]) = v43;\nL_0018:\n\tv57 = v57 - 1;\n\tv63 = v57 & 0x80000000;\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0057;\n\tv128 = System.String::get_Chars(value, v57);\n\tgoto L_0030;\n\tv155 = *([v60 @ X8_v5+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0030;\n\tv162 = v60;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v162, v52, v50, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0030:\n\tv54 = LunarConsolePluginInternal.StringUtils::IsSeparator(v128);\n\tv164 = v54 == 0;\n\tv56 = ~v164;\n\tif (v56) goto L_0018;\nL_0038:\n\tv173 = System.String::get_Chars(value, v115);\n\tgoto L_0046;\n\tv177 = *([v117 @ X8_v7+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_0046;\n\tv184 = v117;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v184, v108, v106, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0046:\n\tv110 = LunarConsolePluginInternal.StringUtils::IsSeparator(v173);\n\tv186 = v110 == 0;\n\tv112 = ~v186;\n\tif (v112) goto L_0057;\n\tv57 = v115 - 1;\n\tv68 = v115 >= 1;\n\tif (v68) goto L_0038;\nL_0057:\n\treturnVal1 = v57 + 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int StartOfTheWord(string value, int index)
		{
			//IL_0121: Expected I4, but got I8
			int num = index;
			while (true)
			{
				num--;
				if ((int)(num & 0x80000000L) != 0)
				{
					break;
				}
				char ch = value.get_Chars(num);
				bool flag = IsSeparator(ch);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				int num2 = num;
				if (flag3)
				{
					continue;
				}
				bool flag7;
				do
				{
					char ch2 = value.get_Chars(num2);
					bool flag4 = IsSeparator(ch2);
					bool flag5 = !flag4;
					bool flag6 = !flag5;
					num = num2;
					if (flag6)
					{
						break;
					}
					num = num2 - 1;
					flag7 = num2 >= 1;
					num2 = num;
				}
				while (flag7);
				break;
			}
			return num + 1;
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0x13E6470", Offset = "0x13E6470", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC67C0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B08]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::EndOfTheWord(value, index);\n\treturnVal1 = v57 - index;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int EndOfTheWordOffset(string value, int index)
		{
			int num = EndOfTheWord(value, index);
			return num - index;
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0x13E64EC", Offset = "0x13E64EC", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF9CD8]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, index, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028B09]) = v43;\nL_0018:\n\tv104 = value.m_stringLength;\n\tv57 = value.m_stringLength <= index;\n\tif (v57) goto L_0056;\nL_002B:\n\tv127 = System.String::get_Chars(value, v168);\n\tgoto L_0039;\n\tv226 = *([v213 @ X8_v10+E0]);\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tgoto L_0039;\n\tv236 = v213;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v236, v65, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0039:\n\tv98 = LunarConsolePluginInternal.StringUtils::IsSeparator(v127);\n\tv100 = v98 == 0;\n\tif (v100) goto L_004C;\n\tv104 = value.m_stringLength;\n\tv168 = v168 + 1;\n\tv72 = v168 < value.m_stringLength;\n\tif (v72) goto L_002B;\n\tgoto L_0056;\nL_004C:\n\tv104 = value.m_stringLength;\nL_0056:\n\tv118 = v168 >= v104;\n\tif (v118) goto L_0086;\nL_005D:\n\tv225 = System.String::get_Chars(value, v170);\n\tgoto L_006B;\n\tv238 = *([v173 @ X8_v7+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tgoto L_006B;\n\tv247 = v173;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v247, v133, v131, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_006B:\n\tv165 = LunarConsolePluginInternal.StringUtils::IsSeparator(v225);\n\tv249 = v165 == 0;\n\tv167 = ~v249;\n\tif (v167) goto L_0086;\n\tv168 = v170 + 1;\n\tv138 = v168 < value.m_stringLength;\n\tif (v138) goto L_005D;\nL_0086:\n\treturn v168;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int EndOfTheWord(string value, int index)
		{
			int length = value.Length;
			bool flag = value.Length <= index;
			int num = index;
			if (!flag)
			{
				num = index;
				do
				{
					char ch = value.get_Chars(num);
					if (IsSeparator(ch))
					{
						length = value.Length;
						num++;
						continue;
					}
					length = value.Length;
					break;
				}
				while (num < value.Length);
			}
			if (num < length)
			{
				int num2 = num;
				bool flag5;
				do
				{
					char ch2 = value.get_Chars(num2);
					bool flag2 = IsSeparator(ch2);
					bool flag3 = !flag2;
					bool flag4 = !flag3;
					num = num2;
					if (flag4)
					{
						break;
					}
					num = num2 + 1;
					flag5 = num < value.Length;
					num2 = num;
				}
				while (flag5);
			}
			return num;
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0x13E63CC", Offset = "0x13E63CC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED0470]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028B0A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = System.Char::IsLetter(ch);\n\tv56 = v54 == 0;\n\tif (v56) goto L_002B;\n\tgoto L_0037;\nL_002B:\n\tgoto L_0033;\n\tv75 = *([v58 @ X0_v8+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0033;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v58, v53, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0033:\n\tv65 = System.Char::IsDigit(ch);\n\tv68 = v65 ^ 1;\nL_0037:\n\treturnVal1 = v68 & 1;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsSeparator(char ch)
		{
			int num;
			if (char.IsLetter(ch))
			{
				num = 0;
			}
			else
			{
				bool flag = char.IsDigit(ch);
				num = (flag ? 1 : 0) ^ 1;
			}
			return (byte)(num & 1) != 0;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0x13E660C", Offset = "0x13E660C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv24 = *([1F0DF88]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, index, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028B0B]) = v43;\nL_0020:\n\tv54 = index < 1;\n\tif (v54) goto L_007A;\n\tv61 = value.m_stringLength < index;\n\tif (v61) goto L_007A;\n\tgoto L_003F;\n\tv141 = *([v137 @ X0_v6+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_003F;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, index, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003F:\n\tv83 = LunarConsolePluginInternal.StringUtils::StartOfPrevLineIndex(value, index);\n\tv85 = v83 + 1;\n\tv73 = v85 == 0;\n\tif (v73) goto L_007A;\n\tgoto L_0053;\n\tv152 = *([v148 @ X0_v10+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_0053;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v148, v57, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0053:\n\tv161 = LunarConsolePluginInternal.StringUtils::OffsetInLine(value, index);\n\tv165 = LunarConsolePluginInternal.StringUtils::EndOfPrevLineIndex(value, index);\n\tgoto L_006B;\n\tv172 = *([v131 @ X8_v11+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_006B;\n\tv178 = v131;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v178, v164, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_006B:\n\tv177 = v161 + v83;\n\treturnVal3 = UnityEngine.Mathf::Min(v177, v165);\n\treturn returnVal3;\nL_007A:\n\treturn index;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int MoveLineUp(string value, int index)
		{
			if (index >= 1 && value.Length >= index)
			{
				int num = StartOfPrevLineIndex(value, index);
				if (num + 1 != 0)
				{
					int num2 = OffsetInLine(value, index);
					int b = EndOfPrevLineIndex(value, index);
					int a = num2 + num;
					return Mathf.Min(a, b);
				}
			}
			return index;
		}

		[Token(Token = "0x600014B")]
		[Address(RVA = "0x13E68D8", Offset = "0x13E68D8", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1ED2400]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, index, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028B0C]) = v43;\nL_0016:\n\tv44 = index & 0x80000000;\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0073;\n\tv53 = value.m_stringLength <= index;\n\tif (v53) goto L_0073;\n\tgoto L_0038;\n\tv143 = *([v139 @ X0_v6+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0038;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v139, index, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0038:\n\tv84 = LunarConsolePluginInternal.StringUtils::StartOfNextLineIndex(value, index);\n\tv86 = v84 + 1;\n\tv70 = v86 == 0;\n\tif (v70) goto L_0073;\n\tgoto L_004C;\n\tv154 = *([v150 @ X0_v10+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_004C;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v150, v49, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004C:\n\tv163 = LunarConsolePluginInternal.StringUtils::OffsetInLine(value, index);\n\tv167 = LunarConsolePluginInternal.StringUtils::EndOfNextLineIndex(value, index);\n\tgoto L_0064;\n\tv174 = *([v133 @ X8_v11+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_0064;\n\tv180 = v133;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v180, v166, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0064:\n\tv179 = v163 + v84;\n\treturnVal3 = UnityEngine.Mathf::Min(v179, v167);\n\treturn returnVal3;\nL_0073:\n\treturn index;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int MoveLineDown(string value, int index)
		{
			//IL_00d5: Expected I4, but got I8
			if ((int)(index & 0x80000000L) == 0 && value.Length > index)
			{
				int num = StartOfNextLineIndex(value, index);
				if (num + 1 != 0)
				{
					int num2 = OffsetInLine(value, index);
					int b = EndOfNextLineIndex(value, index);
					int a = num2 + num;
					return Mathf.Min(a, b);
				}
			}
			return index;
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0x13E6B3C", Offset = "0x13E6B3C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB4840]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B0D]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::StartOfLineIndex(value, index);\n\treturnVal1 = v57 - index;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int StartOfLineOffset(string value, int index)
		{
			int num = StartOfLineIndex(value, index);
			return num - index;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0x13E6BB8", Offset = "0x13E6BB8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = index - 1;\n\tv18 = index < 1;\n\tif (v18) goto L_FFFFFFFF;\n\tv24 = System.String::LastIndexOf(value, 0xA, v16);\n\treturnVal1 = v24 + 1;\n\tgoto L_001C;\nL_001C:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int StartOfLineIndex(string value, int index)
		{
			int startIndex = index - 1;
			if (index >= 1)
			{
				int num = value.LastIndexOf('\n', startIndex);
				return num + 1;
			}
			return 0;
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0x13E6BF0", Offset = "0x13E6BF0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECC000]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B0E]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::EndOfLineIndex(value, index);\n\treturnVal1 = v57 - index;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int EndOfLineOffset(string value, int index)
		{
			int num = EndOfLineIndex(value, index);
			return num - index;
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0x13E6C6C", Offset = "0x13E6C6C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = value.m_stringLength;\n\tv25 = value.m_stringLength <= index;\n\tif (v25) goto L_0028;\n\treturnVal1 = System.String::IndexOf(value, 0xA, index);\n\tv62 = returnVal1 + 1;\n\tv54 = v62 == 0;\n\tv50 = ~v54;\n\tif (v50) goto L_0028;\n\treturnVal1 = value.m_stringLength;\nL_0028:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int EndOfLineIndex(string value, int index)
		{
			int num = value.Length;
			if (value.Length > index)
			{
				num = value.IndexOf('\n', index);
				if (num + 1 == 0)
				{
					num = value.Length;
				}
			}
			return num;
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0x13E67E0", Offset = "0x13E67E0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFB230]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B0F]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::StartOfLineIndex(value, index);\n\treturnVal1 = index - v57;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int OffsetInLine(string value, int index)
		{
			int num = StartOfLineIndex(value, index);
			return index - num;
		}

		[Token(Token = "0x6000151")]
		[Address(RVA = "0x13E672C", Offset = "0x13E672C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAF480]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B10]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::EndOfPrevLineIndex(value, index);\n\tv59 = returnVal1 + 1;\n\tv61 = v59 == 0;\n\tif (v61) goto L_0045;\n\tgoto L_003D;\n\tv73 = *([v64 @ X0_v6+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_003D;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v64, v56, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\treturnVal2 = LunarConsolePluginInternal.StringUtils::StartOfLineIndex(value, returnVal1);\n\treturn returnVal2;\nL_0045:\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int StartOfPrevLineIndex(string value, int index)
		{
			int num = EndOfPrevLineIndex(value, index);
			if (num + 1 != 0)
			{
				return StartOfLineIndex(value, num);
			}
			return num;
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0x13E685C", Offset = "0x13E685C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE7968]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B11]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::StartOfLineIndex(value, index);\n\treturnVal1 = v57 - 1;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int EndOfPrevLineIndex(string value, int index)
		{
			int num = StartOfLineIndex(value, index);
			return num - 1;
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0x13E69F4", Offset = "0x13E69F4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFE748]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B12]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::EndOfLineIndex(value, index);\n\tv75 = v57 < value.m_stringLength;\n\tif (v75) goto L_003A;\n\tgoto L_003E;\nL_003A:\n\treturnVal2 = v57 + 1;\nL_003E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int StartOfNextLineIndex(string value, int index)
		{
			int num = EndOfLineIndex(value, index);
			if (num >= value.Length)
			{
				return -1;
			}
			return num + 1;
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0x13E6A88", Offset = "0x13E6A88", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDB1E0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B13]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::StartOfNextLineIndex(value, index);\n\tv59 = returnVal1 + 1;\n\tv61 = v59 == 0;\n\tif (v61) goto L_0045;\n\tgoto L_003D;\n\tv73 = *([v64 @ X0_v6+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_003D;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v64, v56, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\treturnVal2 = LunarConsolePluginInternal.StringUtils::EndOfLineIndex(value, returnVal1);\n\treturn returnVal2;\nL_0045:\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int EndOfNextLineIndex(string value, int index)
		{
			int num = StartOfNextLineIndex(value, index);
			if (num + 1 != 0)
			{
				return EndOfLineIndex(value, num);
			}
			return num;
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0x13E6CC0", Offset = "0x13E6CC0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = value == 0;\n\tif (v14) goto L_FFFFFFFF;\n\tv26 = value.m_stringLength < 1;\n\tif (v26) goto L_FFFFFFFF;\nL_001C:\n\tv57 = System.String::get_Chars(value, v99);\n\tv87 = v57 & 0xFFFF;\n\tv99 = v99 + 1;\n\tv60 = v87 != 0xA;\n\tif (v60) goto L_0039;\n\tv66 = v66 + 1;\n\tgoto L_0039;\nL_0039:\n\tv69 = v99 < value.m_stringLength;\n\tif (v69) goto L_001C;\n\tgoto L_0044;\nL_0044:\n\treturn v66;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int LinesBreaksCount(string value)
		{
			int num2;
			if (value != null && value.Length >= 1)
			{
				int num = 0;
				num2 = 0;
				do
				{
					char c = value.get_Chars(num);
					int num3 = c & 0xFFFF;
					num++;
					if (num3 == 10)
					{
						num2++;
					}
				}
				while (num < value.Length);
			}
			else
			{
				num2 = 0;
			}
			return num2;
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0x13E6D34", Offset = "0x13E6D34", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = str == 0;\n\tif (v0) goto L_0003;\n\treturnVal1 = str.m_stringLength;\nL_0003:\n\treturn returnVal1;\n")]
		internal static int Strlen(string str)
		{
			//IL_0017: Expected I4, but got O
			bool flag = str == null;
			int result = (int)str;
			if (!flag)
			{
				result = str.Length;
			}
			return result;
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0x13D8E7C", Offset = "0x13D8E7C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFEC60]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028B14]) = v38;\nL_0019:\n\tgoto L_0030;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b13\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = LunarConsolePluginInternal.StringUtils;\nL_0030:\n\treturnVal1 = System.Text.RegularExpressions.Regex::Replace(v52.kRichTagRegex, line, v63.Empty);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string RemoveRichTextTags(string line)
		{
			return kRichTagRegex.Replace(line, string.Empty);
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0x13E6D40", Offset = "0x13E6D40", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE53B0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, strings, removeTags, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B15]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, strings, removeTags, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::GetSuggestedText0(token, strings, 0);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string GetSuggestedText(string token, string[] strings, bool removeTags = false)
		{
			return GetSuggestedText0(token, strings, removeTags: false);
		}

		[Token(Token = "0x6000159")]
		[Address(RVA = "0x13E71E4", Offset = "0x13E71E4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EC1AE0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, strings, removeTags, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B16]) = v41;\nL_0017:\n\tv44 = LunarConsolePluginInternal.StringUtils;\n\tv46 = *([v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_001F;\n\tv49 = *([v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]) == 0;\n\tif (v49) goto L_002F;\nL_001F:\n\tv52 = strings == 0;\n\tif (v52) goto L_FFFFFFFF;\nL_0026:\n\t// 38 IsInst v73 @ X0_v11 (System.Collections.IList), typeof(System.Collections.IList), strings @ X1 (System.Collections.Generic.IList`1<System.String>)\n\tv82 = v73 == 0;\n\tv58 = ~v82;\n\tif (v58) goto L_003B;\n\tv56 = new System.InvalidCastException();\nL_002F:\n\tv80 = strings == 0;\n\tv67 = ~v80;\n\tif (v67) goto L_0026;\nL_003B:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::GetSuggestedText0(token, v83, 0);\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string GetSuggestedText(string token, IList<string> strings, bool removeTags = false)
		{
			//IL_00d2: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(StringUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0092;
				}
			}
			if (strings != null)
			{
				goto IL_0047;
			}
			goto IL_00ba;
			IL_00ba:
			IList strings2 = null;
			goto IL_0105;
			IL_0092:
			if (strings != null)
			{
				goto IL_0047;
			}
			goto IL_00ba;
			IL_0047:
			IList list = strings as IList;
			bool flag = list == null;
			bool flag2 = !flag;
			strings2 = list;
			if (!flag2)
			{
				InvalidCastException ex = new InvalidCastException();
				goto IL_0092;
			}
			goto IL_0105;
			IL_0105:
			return GetSuggestedText0(token, strings2, removeTags: false);
		}

		[Token(Token = "0x600015A")]
		[Address(RVA = "0x13E6DB8", Offset = "0x13E6DB8", Length = "0x42C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EF3DF0]);\n\tv31 = *([v30 @ X8_v62]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, strings, removeTags, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2028B17]) = v49;\nL_0019:\n\tv50 = token == 0;\n\tif (v50) goto L_0072;\n\tgoto L_002A;\n\tv67 = *([v53 @ X0_v3 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v53, strings, removeTags, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv71 = LunarConsolePluginInternal.StringUtils;\nL_002A:\n\tv76 = v74.s_tempList == 0;\n\tif (v76) goto L_0076;\n\tgoto L_003E;\n\tv182 = *([v70 @ X0_v4 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_003E;\n\tv205 = LunarConsolePluginInternal.StringUtils;\n\tv206 = *([v205 @ X8_v56 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+B8]);\n\tv191 = v206.s_tempList;\nL_003E:\n\tSystem.Collections.Generic.List`1<System.String>::Clear(v74.s_tempList);\nL_0042:\n\tv217 = strings->klass;\n\tv221 = *([v217 @ X8_v54 (Il2CppClass<System.Collections.IList>)+126]) == 0;\n\tif (v221) goto L_0065;\n\tv286 = *([v217 @ X8_v54 (Il2CppClass<System.Collections.IList>)+B0]) + 8;\nL_0050:\n\tv279 = *([v286 @ X11_v25-8]) == System.Collections.IEnumerable;\n\tif (v279) goto L_008F;\n\tv289 = v289 + 1;\n\tv337 = v289 < *([v217 @ X8_v54 (Il2CppClass<System.Collections.IList>)+126]);\n\tv259 = ~v337;\n\tv286 = v286 + 0x10;\n\tv243 = ~v259;\n\tif (v243) goto L_0050;\nL_0065:\n\tv327 = 0x8909C4(strings, System.Collections.IEnumerable, 0, v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0093;\nL_0072:\n\treturn 0;\nL_0076:\n\tv181 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v181);\n\tgoto L_0087;\n\tv230 = *([v201 @ X0_v67 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_0087;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v201, v199, removeTags, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv233 = LunarConsolePluginInternal.StringUtils;\nL_0087:\n\t;\n\tv214.s_tempList = v181;\n\tv236 = strings == 0;\n\tv212 = ~v236;\n\tif (v212) goto L_0042;\n\tthrow System.NullReferenceException;\nL_008F:\n\tv297 = *([v286 @ X11_v25]) << 4;\n\tv298 = v217 + v297;\n\tv327 = v298 + 0x130;\nL_0093:\n\tv148 = *([v327 @ X0_v5+8]);\n\t*([v327 @ X0_v5])(v334, strings, *([v327 @ X0_v5+8]), v100, v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv336 = v334 == 0;\n\tif (v336) goto L_013B;\nL_00A3:\n\tgoto L_00CA;\n\tv440 = *([v436 @ X8_v22+B0]);\n\tv441 = 0;\n\tv442 = v440 + 8;\n\tv444 = *([v490 @ X11_v23-8]);\n\tv496 = v444 == v437;\n\tif (v496) goto L_00C3;\n\tv466 = v491 + 1;\n\tv513 = v466 < v438;\n\tv462 = ~v513;\n\tv464 = v490 + 0x10;\n\tv446 = ~v462;\n\tif (v446) goto L_FFFFFFFF;\n\tv467 = v335;\n\tv468 = 0;\n\tv469 = 0x8909C4(v467, v437, v468, v391, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00CA;\nL_00C3:\n\tv514 = *([v490 @ X11_v23]);\n\tv515 = v514 << 4;\n\tv516 = v436 + v515;\n\tv517 = v516 + 0x130;\nL_00CA:\n\tv538 = System.Collections.IEnumerator::MoveNext(v334);\n\tv540 = v538 == 0;\n\tif (v540) goto L_FFFFFFFF;\n\tv543 = *([v334 @ X0_v7 (System.Collections.IEnumerator)]);\n\tv546 = *([v543 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v546) goto L_00F0;\n\tv614 = *([v543 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00DB:\n\tv620 = *([v614 @ X11_v18-8]) == System.Collections.IEnumerator;\n\tif (v620) goto L_00F3;\n\tv615 = v615 + 1;\n\tv626 = v615 < *([v543 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv572 = ~v626;\n\tv614 = v614 + 0x10;\n\tv556 = ~v572;\n\tif (v556) goto L_00DB;\nL_00F0:\n\tv641 = 0x8909C4(v334, System.Collections.IEnumerator, 1, v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00FA;\nL_00F3:\n\tv628 = *([v614 @ X11_v18]) + 1;\n\tv629 = v628 << 4;\n\tv630 = v543 + v629;\n\tv641 = v630 + 0x130;\nL_00FA:\n\t*([v641 @ X0_v36])(v646, v334, *([v641 @ X0_v36+8]), v354, v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv647 = v646 == 0;\n\tif (v647) goto L_010C;\n\tv690 = *([v646 @ X0_v38 (System.String)]) != System.String;\n\tif (v690) goto L_0139;\nL_010C:\n\tv693 = token.m_stringLength == 0;\n\tif (v693) goto L_0126;\n\tgoto L_0118;\n\tv775 = *([v732 @ X0_v47+E0]);\n\tv776 = v775 == 0;\n\tv777 = ~v776;\n\tif (v777) goto L_0118;\n\tv778 = \"il2cpp_codegen_runtime_class_init\"(v732, v420, v396, v391, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0118:\n\tv429 = v646 == 0;\n\tif (v429) goto L_00A3;\n\tv426 = System.String::StartsWith(v646, token, 5);\n\tv430 = v426 == 0;\n\tif (v430) goto L_00A3;\nL_0126:\n\tgoto L_0133;\n\tv780 = *([v741 @ X0_v42 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv781 = v780 == 0;\n\tv782 = ~v781;\n\t// 298 ConditionalJump @b96, v782 @ TEMP_v40\n\tv797 = \"il2cpp_codegen_runtime_class_init\"(v741, v737, v736, v393, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv784 = LunarConsolePluginInternal.StringUtils;\nL_0133:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v434.s_tempList, v646);\n\tgoto L_00A3;\n\tgoto L_0156;\nL_0139:\n\tv731 = new System.InvalidCastException();\n\tv382 = new System.NullReferenceException();\nL_013B:\n\tv389 = new System.NullReferenceException();\n\tgoto L_014C;\n\tgoto L_014C;\n\tgoto L_014C;\n\tgoto L_014C;\n\tgoto L_014C;\n\tgoto L_014C;\n\tgoto L_014C;\nL_014C:\n\tv479 = v148 != 1;\n\tif (v479) goto L_01AE;\n\tv501 = 0x6D2BC0(v389, v148, v100, v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv512 = *([v501 @ X0_v30]);\n\tv542 = 0x6D2490(v501, v148, v100, v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0156:\n\t// 342 IsInst v603 @ X0_v10 (System.IDisposable), typeof(System.IDisposable), v334 @ X0_v7 (System.Collections.IEnumerator)\n\tv625 = v603 == 0;\n\tif (v625) goto L_0186;\n\tgoto L_0185;\n\tv694 = *([v648 @ X8_v15+B0]);\n\tv695 = 0;\n\tv696 = v694 + 8;\n\tv698 = *([v755 @ X11_v8-8]);\n\tv761 = v698 == v649;\n\tif (v761) goto L_017E;\n\tv720 = v756 + 1;\n\tv787 = v720 < v650;\n\tv716 = ~v787;\n\tv718 = v755 + 0x10;\n\tv700 = ~v716;\n\tif (v700) goto L_FFFFFFFF;\n\tv721 = v510;\n\tv722 = 0;\n\tv723 = 0x8909C4(v721, v649, v722, v82, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0185;\nL_017E:\n\tv788 = *([v755 @ X11_v8]);\n\tv789 = v788 << 4;\n\tv790 = v648 + v789;\n\tv791 = v790 + 0x130;\nL_0185:\n\tSystem.IDisposable::Dispose(v603);\nL_0186:\n\tv678 = v503 + 1;\n\tv124 = v678 == 0;\n\tv104 = ~v124;\n\tif (v104) goto L_0194;\n\tv724 = v512 == 0;\n\tv509 = ~v724;\n\tif (v509) goto L_01AD;\nL_0194:\n\tgoto L_01A8;\n\tv767 = *([v726 @ X0_v12 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv768 = v767 == 0;\n\tv769 = ~v768;\n\tif (v769) goto L_01A8;\n\tv795 = \"il2cpp_codegen_runtime_class_init\"(v726, v671, v100, v82, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv771 = LunarConsolePluginInternal.StringUtils;\nL_01A8:\n\treturnVal3 = LunarConsolePluginInternal.StringUtils::GetSuggestedTextFiltered0(token, v167.s_tempList);\n\treturn returnVal3;\nL_01AD:\n\tv508 = new System.TypeLoadException();\nL_01AE:\n\treturnVal2 = 0x6D2380(v389, v148, v100, v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal2;\n// 240 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetSuggestedText0(string token, IList strings, bool removeTags)
		{
			//IL_0026: Expected I, but got O
			//IL_0061: Expected O, but got I
			//IL_010e: Expected I4, but got O
			//IL_011c: Expected O, but got I
			//IL_012b: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_03a7: Expected I4, but got O
			//IL_0138: Expected I, but got O
			//IL_0173: Expected O, but got I
			//IL_0412: Expected I, but got O
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Expected O, but got Unknown
			//IL_0220: Expected O, but got I
			//IL_022f: Expected O, but got I
			//IL_0347: Expected I, but got O
			//IL_01bf: Expected O, but got I
			//IL_02dd: Expected I, but got O
			//IL_02e2: Expected I, but got O
			if (token == null)
			{
				return null;
			}
			if (s_tempList != null)
			{
				s_tempList.Clear();
			}
			else
			{
				List<string> list = new List<string>();
				s_tempList = list;
				if (strings == null)
				{
					throw new NullReferenceException();
				}
			}
			IntPtr intPtr = (IntPtr)strings;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v54 (Il2CppClass<System.Collections.IList>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v54 (Il2CppClass<System.Collections.IList>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ X11_v25-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IEnumerable))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v54 (Il2CppClass<System.Collections.IList>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c6;
			}
			int num3 = obj << 4;
			object obj2 = (long)intPtr + (long)num3;
			object obj3 = (long)(IntPtr)obj2 + 304L;
			goto IL_0498;
			IL_0330:
			InvalidCastException ex = new InvalidCastException();
			IntPtr intPtr2 = (IntPtr)typeof(string);
			NullReferenceException ex2 = new NullReferenceException();
			int num4;
			bool flag3 = (byte)num4 != 0;
			goto IL_0362;
			IL_041f:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			string result = default(string);
			return result;
			IL_00c6:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			flag3 = false;
			goto IL_0498;
			IL_0498:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ X0_v5+8]");
			intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v327 @ X0_v5] (should have been resolved before IL gen)");
			IEnumerator enumerator = default(IEnumerator);
			if (enumerator == null)
			{
				goto IL_0362;
			}
			string text = default(string);
			IntPtr intPtr5 = default(IntPtr);
			while (enumerator.MoveNext())
			{
				IntPtr intPtr3 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01d8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj4 = 0L + 8L;
				int num5 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
					{
						break;
					}
					num5++;
					int num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					bool flag4 = (long)num6 < 0L;
					bool flag5 = !flag4;
					obj4 = (long)(IntPtr)obj4 + 16L;
					if (!flag5)
					{
						continue;
					}
					goto IL_01d8;
				}
				object obj5 = obj4 + 1;
				int num7 = (int)((long)(IntPtr)obj5 << 4);
				object obj6 = (long)intPtr3 + (long)num7;
				object obj7 = (long)(IntPtr)obj6 + 304L;
				num4 = 0;
				goto IL_0555;
				IL_01d8:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num4 = 1;
				goto IL_0555;
				IL_0555:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v641 @ X0_v36] (should have been resolved before IL gen)");
				if (text == null || (object)text.GetType() == typeof(string))
				{
					bool flag6 = token.Length == 0;
					IntPtr intPtr4 = intPtr5;
					if (!flag6)
					{
						if (text == null)
						{
							continue;
						}
						bool flag7 = text.StartsWith(token, StringComparison.OrdinalIgnoreCase);
						bool flag8 = !flag7;
						intPtr4 = (IntPtr)null;
						intPtr5 = (IntPtr)null;
						if (flag8)
						{
							continue;
						}
					}
					s_tempList.Add(text);
					intPtr5 = intPtr4;
					continue;
				}
				goto IL_0330;
			}
			int num8 = 0;
			flag3 = false;
			int num9 = 0;
			goto IL_0581;
			IL_0362:
			NullReferenceException ex3 = new NullReferenceException();
			if (intPtr2 != (IntPtr)1)
			{
				goto IL_041f;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj8 = default(object);
			num9 = (int)obj8;
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			num8 = -1;
			goto IL_0581;
			IL_0581:
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
				flag3 = false;
			}
			if (num8 + 1 == 0 && num9 != 0)
			{
				TypeLoadException ex4 = new TypeLoadException();
				flag3 = false;
				intPtr2 = (IntPtr)null;
				ex3 = (NullReferenceException)(object)ex4;
				goto IL_041f;
			}
			return GetSuggestedTextFiltered0(token, s_tempList);
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x13E76C8", Offset = "0x13E76C8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EAB7D8]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, strings, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B18]) = v41;\nL_0017:\n\tv44 = LunarConsolePluginInternal.StringUtils;\n\tv46 = *([v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_001F;\n\tv49 = *([v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]) == 0;\n\tif (v49) goto L_002F;\nL_001F:\n\tv52 = strings == 0;\n\tif (v52) goto L_FFFFFFFF;\nL_0026:\n\t// 38 IsInst v73 @ X0_v11 (System.Collections.IList), typeof(System.Collections.IList), strings @ X1 (System.Collections.Generic.IList`1<System.String>)\n\tv82 = v73 == 0;\n\tv58 = ~v82;\n\tif (v58) goto L_003A;\n\tv56 = new System.InvalidCastException();\nL_002F:\n\tv80 = strings == 0;\n\tv67 = ~v80;\n\tif (v67) goto L_0026;\nL_003A:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::GetSuggestedTextFiltered0(token, v83);\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string GetSuggestedTextFiltered(string token, IList<string> strings)
		{
			//IL_00d2: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(StringUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0092;
				}
			}
			if (strings != null)
			{
				goto IL_0047;
			}
			goto IL_00ba;
			IL_00ba:
			IList strings2 = null;
			goto IL_0105;
			IL_0092:
			if (strings != null)
			{
				goto IL_0047;
			}
			goto IL_00ba;
			IL_0047:
			IList list = strings as IList;
			bool flag = list == null;
			bool flag2 = !flag;
			strings2 = list;
			if (!flag2)
			{
				InvalidCastException ex = new InvalidCastException();
				goto IL_0092;
			}
			goto IL_0105;
			IL_0105:
			return GetSuggestedTextFiltered0(token, strings2);
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x13E7770", Offset = "0x13E7770", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC91B8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, strings, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B19]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, strings, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\treturnVal1 = LunarConsolePluginInternal.StringUtils::GetSuggestedTextFiltered0(token, strings);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string GetSuggestedTextFiltered(string token, string[] strings)
		{
			return GetSuggestedTextFiltered0(token, strings);
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x13E7290", Offset = "0x13E7290", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv36 = *([1EE91E0]);\n\tv37 = *([v36 @ X8_v50]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, strings, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2028B1A]) = v55;\nL_001C:\n\tv56 = token == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tv155 = strings->klass;\n\tv158 = *([v155 @ X8_v7 (Il2CppClass<System.Collections.IList>)+126]) == 0;\n\tif (v158) goto L_0044;\n\tv469 = *([v155 @ X8_v7 (Il2CppClass<System.Collections.IList>)+B0]) + 8;\nL_002F:\n\tv474 = *([v469 @ X11_v38-8]) == System.Collections.ICollection;\n\tif (v474) goto L_0047;\n\tv468 = v468 + 1;\n\tv479 = v468 < *([v155 @ X8_v7 (Il2CppClass<System.Collections.IList>)+126]);\n\tv358 = ~v479;\n\tv469 = v469 + 0x10;\n\tv342 = ~v358;\n\tif (v342) goto L_002F;\nL_0044:\n\tv485 = 0x8909C4(strings, System.Collections.ICollection, 1, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_004E;\nL_0047:\n\tv481 = *([v469 @ X11_v38]) + 1;\n\tv482 = v481 << 4;\n\tv483 = v155 + v482;\n\tv485 = v483 + 0x130;\nL_004E:\n\t*([v485 @ X0_v11])(v142, strings, *([v485 @ X0_v11+8]), v551, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv145 = v142 == 0;\n\tif (v145) goto L_FFFFFFFF;\n\tv488 = strings->klass;\n\tv491 = *([v488 @ X8_v10 (Il2CppClass<System.Collections.IList>)+126]) == 0;\n\tif (v491) goto L_0073;\n\tv533 = *([v488 @ X8_v10 (Il2CppClass<System.Collections.IList>)+B0]) + 8;\nL_005E:\n\tv538 = *([v533 @ X11_v33-8]) == System.Collections.ICollection;\n\tif (v538) goto L_0076;\n\tv532 = v532 + 1;\n\tv543 = v532 < *([v488 @ X8_v10 (Il2CppClass<System.Collections.IList>)+126]);\n\tv514 = ~v543;\n\tv533 = v533 + 0x10;\n\tv498 = ~v514;\n\tif (v498) goto L_005E;\nL_0073:\n\tv564 = 0x8909C4(strings, System.Collections.ICollection, 1, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_007D;\nL_0076:\n\tv545 = *([v533 @ X11_v33]) + 1;\n\tv546 = v545 << 4;\n\tv547 = v488 + v546;\n\tv564 = v547 + 0x130;\nL_007D:\n\t*([v564 @ X0_v14])(v569, strings, *([v564 @ X0_v14+8]), v551, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00AD;\n\tv575 = *([v571 @ X8_v13+B0]);\n\tv576 = 0;\n\tv577 = v575 + 8;\n\tv579 = *([v616 @ X11_v28-8]);\n\tv621 = v579 == v573;\n\tif (v621) goto L_00A5;\n\tv599 = v615 + 1;\n\tv626 = v599 < v572;\n\tv597 = ~v626;\n\tv601 = v616 + 0x10;\n\tv581 = ~v597;\n\tif (v581) goto L_FFFFFFFF;\n\tv602 = v28;\n\tv603 = 0;\n\tv604 = 0x8909C4(v602, v573, v603, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00AD;\nL_00A5:\n\tv627 = *([v616 @ X11_v28]);\n\tv628 = v627 << 4;\n\tv629 = v571 + v628;\n\tv630 = v629 + 0x130;\nL_00AD:\n\tv316 = System.Collections.IList::get_Item(strings, 0);\n\tv318 = v316 == 0;\n\tif (v318) goto L_00C4;\n\tv378 = *([v316 @ X0_v19 (System.Object)]) != System.String;\n\tif (v378) goto L_01EC;\nL_00C4:\n\tv229 = v569 == 1;\n\tif (v229) goto L_01E6;\n\tv270 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v270);\n\tv670 = *([v316 @ X0_v19 (System.Object)+10]) < 1;\n\tif (v670) goto L_01B8;\nL_00E8:\n\tv716 = System.String::get_Chars(v693, v184);\n\tgoto L_00F7;\n\tv735 = *([v729 @ X8_v24+E0]);\n\tv736 = v735 == 0;\n\tv737 = ~v736;\n\tgoto L_00F7;\n\tv745 = v729;\n\tv740 = \"il2cpp_codegen_runtime_class_init\"(v745, v714, v715, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00F7:\n\tv744 = System.Char::ToLower(v716);\nL_00FA:\n\tv783 = strings->klass;\n\tv786 = *([v783 @ X8_v26 (Il2CppClass<System.Collections.IList>)+126]) == 0;\n\tif (v786) goto L_011C;\n\tv828 = *([v783 @ X8_v26 (Il2CppClass<System.Collections.IList>)+B0]) + 8;\nL_0107:\n\tv833 = *([v828 @ X11_v23-8]) == System.Collections.ICollection;\n\tif (v833) goto L_011F;\n\tv827 = v827 + 1;\n\tv838 = v827 < *([v783 @ X8_v26 (Il2CppClass<System.Collections.IList>)+126]);\n\tv809 = ~v838;\n\tv828 = v828 + 0x10;\n\tv793 = ~v809;\n\tif (v793) goto L_0107;\nL_011C:\n\tv859 = 0x8909C4(strings, System.Collections.ICollection, 1, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0126;\nL_011F:\n\tv840 = *([v828 @ X11_v23]) + 1;\n\tv841 = v840 << 4;\n\tv842 = v783 + v841;\n\tv859 = v842 + 0x130;\nL_0126:\n\t*([v859 @ X0_v34])(v864, strings, *([v859 @ X0_v34+8]), v846, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv874 = v170 >= v864;\n\tif (v874) goto L_FFFFFFFF;\n\tgoto L_015E;\n\tv880 = *([v875 @ X8_v32+B0]);\n\tv881 = 0;\n\tv882 = v880 + 8;\n\tv884 = *([v938 @ X11_v18-8]);\n\tv943 = v884 == v876;\n\tif (v943) goto L_0156;\n\tv904 = v937 + 1;\n\tv949 = v904 < v877;\n\tv902 = ~v949;\n\tv906 = v938 + 0x10;\n\tv886 = ~v902;\n\tif (v886) goto L_FFFFFFFF;\n\tv907 = v28;\n\tv908 = 0;\n\tv909 = 0x8909C4(v907, v876, v908, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_015E;\nL_0156:\n\tv950 = *([v938 @ X11_v18]);\n\tv951 = v950 << 4;\n\tv952 = v875 + v951;\n\tv953 = v952 + 0x130;\nL_015E:\n\tv969 = System.Collections.IList::get_Item(strings, v170);\n\tv982 = *([v969 @ X0_v42 (System.Object)]) != System.String;\n\tif (v982) goto L_01E8;\n\tv754 = v184 >= *([v969 @ X0_v42 (System.Object)+10]);\n\tif (v754) goto L_FFFFFFFF;\n\tv998 = System.String::get_Chars(v969, v184);\n\tgoto L_018B;\n\tv1004 = *([v1000 @ X8_v40+E0]);\n\tv1005 = v1004 == 0;\n\tv1006 = ~v1005;\n\tif (v1006) goto L_018B;\n\tv1010 = v1000;\n\tv1008 = \"il2cpp_codegen_runtime_class_init\"(v1010, v997, v752, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_018B:\n\tv778 = System.Char::ToLower(v998);\n\tv782 = v778 & 0xFFFF;\n\tv764 = v782 == v744;\n\tv170 = v170 + 1;\n\tif (v764) goto L_00FA;\n\tgoto L_019E;\nL_019E:\n\tv948 = v285 == 0;\n\tv688 = ~v948;\n\tif (v688) goto L_01B8;\n\tv686 = System.Text.StringBuilder::Append(v270, v716);\n\tv184 = v184 + 1;\n\tv676 = v184 < *([v316 @ X0_v19 (System.Object)+10]);\n\tif (v676) goto L_00E8;\nL_01B8:\n\tv141 = System.Text.StringBuilder::get_Length(v79);\n\tv88 = v141 < 1;\n\tif (v88) goto L_FFFFFFFF;\n\tv453 = *([v79 @ X24_v7 (System.Text.StringBuilder)]);\n\tv428 = *([v453 @ X8_v21 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv441 = *([v453 @ X8_v21 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 470 IndirectJump v428 @ X2_v10, v79 @ X24_v7 (System.Text.StringBuilder), v79 @ X24_v7 (System.Text.StringBuilder), v441 @ X1_v15, v428 @ X2_v10, v40 @ X3, v41 @ X4, v42 @ X5, v43 @ X6, v44 @ X7, v45 @ V0, v46 @ V1, v47 @ V2, v48 @ V3, v49 @ V4, v50 @ V5, v51 @ V6, v52 @ V7\nL_01E6:\n\treturn v293;\n\tv983 = new System.NullReferenceException();\nL_01E8:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_01EC:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 324 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetSuggestedTextFiltered0(string token, IList strings)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0119: Expected I, but got O
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0154: Expected O, but got I
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Expected O, but got Unknown
			//IL_0201: Expected O, but got I
			//IL_0210: Expected O, but got I
			//IL_01a0: Expected O, but got I
			//IL_053d: Expected I, but got O
			//IL_054d: Expected O, but got I
			//IL_055d: Expected O, but got I
			//IL_06d1: Expected I, but got O
			//IL_02f0: Expected O, but got I
			//IL_037b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Expected O, but got Unknown
			//IL_039d: Expected O, but got I
			//IL_03ac: Expected O, but got I
			//IL_033c: Expected O, but got I
			if (token == null)
			{
				goto IL_0567;
			}
			IntPtr intPtr = (IntPtr)strings;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v7 (Il2CppClass<System.Collections.IList>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v7 (Il2CppClass<System.Collections.IList>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ X11_v38-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICollection))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v7 (Il2CppClass<System.Collections.IList>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			IntPtr intPtr2 = default(IntPtr);
			int num4 = (int)(long)intPtr2;
			goto IL_05cc;
			IL_05cc:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v485 @ X0_v11] (should have been resolved before IL gen)");
			object obj5 = default(object);
			if (obj5 == null)
			{
				goto IL_0567;
			}
			IntPtr intPtr3 = (IntPtr)strings;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v10 (Il2CppClass<System.Collections.IList>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01b9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v10 (Il2CppClass<System.Collections.IList>)+B0]");
			object obj6 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ X11_v33-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICollection))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v10 (Il2CppClass<System.Collections.IList>)+126]");
				bool flag3 = (long)num6 < 0L;
				bool flag4 = !flag3;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_01b9;
			}
			object obj7 = obj6 + 1;
			int num7 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr3 + (long)num7;
			object obj9 = (long)(IntPtr)obj8 + 304L;
			goto IL_061d;
			IL_061d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v564 @ X0_v14] (should have been resolved before IL gen)");
			object obj10 = strings.get_Item(0);
			string result;
			if (obj10 == null || (object)obj10.GetType() == typeof(string))
			{
				object obj11 = default(object);
				bool flag5 = (IntPtr)obj11 == (IntPtr)1;
				result = (string)obj10;
				if (!flag5)
				{
					StringBuilder stringBuilder = new StringBuilder();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ X0_v19 (System.Object)+10]");
					bool flag6 = 0L < 1L;
					StringBuilder stringBuilder2 = stringBuilder;
					if (!flag6)
					{
						object obj12 = obj10;
						int num8 = 0;
						int num14 = default(int);
						bool flag12;
						do
						{
							char c = ((string)obj12).get_Chars(num8);
							char c2 = char.ToLower(c);
							int num9 = 1;
							int num10 = 0;
							int num15;
							while (true)
							{
								IntPtr intPtr4 = (IntPtr)strings;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ X8_v26 (Il2CppClass<System.Collections.IList>)+126]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									goto IL_0355;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ X8_v26 (Il2CppClass<System.Collections.IList>)+B0]");
								object obj13 = 0L + 8L;
								int num11 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ X11_v23-8]");
									if ((IntPtr)0 == (IntPtr)typeof(ICollection))
									{
										break;
									}
									num11++;
									int num12 = num11;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ X8_v26 (Il2CppClass<System.Collections.IList>)+126]");
									bool flag7 = (long)num12 < 0L;
									bool flag8 = !flag7;
									obj13 = (long)(IntPtr)obj13 + 16L;
									if (!flag8)
									{
										continue;
									}
									goto IL_0355;
								}
								object obj14 = obj13 + 1;
								int num13 = (int)((long)(IntPtr)obj14 << 4);
								object obj15 = (long)intPtr4 + (long)num13;
								object obj16 = (long)(IntPtr)obj15 + 304L;
								goto IL_068a;
								IL_068a:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v859 @ X0_v34] (should have been resolved before IL gen)");
								if (num9 >= num14)
								{
									num15 = 0;
									break;
								}
								object obj17 = strings.get_Item(num9);
								if ((object)obj17.GetType() == typeof(string))
								{
									int num16 = num8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ X0_v42 (System.Object)+10]");
									if ((long)num16 < 0L)
									{
										char c3 = ((string)obj17).get_Chars(num8);
										char c4 = char.ToLower(c3);
										int num17 = c4 & 0xFFFF;
										bool flag9 = num17 == c2;
										num9++;
										num10 = 0;
										if (flag9)
										{
											continue;
										}
									}
									num15 = 1;
									break;
								}
								throw new InvalidCastException();
								IL_0355:
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
								num10 = 1;
								goto IL_068a;
							}
							bool flag10 = num15 == 0;
							bool flag11 = !flag10;
							stringBuilder2 = stringBuilder;
							if (flag11)
							{
								break;
							}
							StringBuilder stringBuilder3 = stringBuilder.Append(c);
							num8++;
							int num18 = num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ X0_v19 (System.Object)+10]");
							flag12 = (long)num18 < 0L;
							stringBuilder2 = stringBuilder;
							obj12 = obj10;
						}
						while (flag12);
					}
					int length = stringBuilder2.Length;
					if (length >= 1)
					{
						IntPtr intPtr5 = (IntPtr)stringBuilder2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ X8_v21 (Il2CppClass<System.Text.StringBuilder>)+160]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ X8_v21 (Il2CppClass<System.Text.StringBuilder>)+168]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v428 @ X2_v10 (should have been resolved before IL gen)");
					}
					goto IL_0567;
				}
				goto IL_065b;
			}
			return (string)(object)new InvalidCastException();
			IL_065b:
			return result;
			IL_01b9:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num4 = 1;
			goto IL_061d;
			IL_0567:
			result = null;
			goto IL_065b;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num4 = 1;
			goto IL_05cc;
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x13E77E4", Offset = "0x13E77E4", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF5848]);\n\tv21 = *([v20 @ X8_v28]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028B1B]) = v40;\nL_0014:\n\tv41 = value == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tv53 = value.m_stringLength < 1;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_0035;\n\tv116 = *([v78 @ X0_v4 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_0035;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v78, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv120 = LunarConsolePluginInternal.StringUtils;\nL_0035:\n\tv128 = System.String::Replace(value, v123.Quote, v123.EscapedQuote);\n\tv175 = System.String::Replace(v128, v109.SingleQuote, v109.EscapedSingleQuote);\n\tv103 = System.String::IndexOf(v175, 0x20);\n\tv105 = v103 + 1;\n\tv96 = v105 == 0;\n\tif (v96) goto L_007D;\n\t// 79 NewArr v185 @ X0_v18 (System.Object[]), typeof(System.Object[]), 1\n\t// 86 IsInst v204 @ X0_v20, typeof(System.Object), v175 @ X0_v14 (System.String)\n\tv206 = v204 == 0;\n\tif (v206) goto L_007F;\n\tv185[0] = v175;\n\tgoto L_0071;\n\tv226 = *([v222 @ X0_v22+E0]);\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_0071;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v222, v196, v85, v87, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0071:\n\treturnVal3 = LunarConsolePluginInternal.StringUtils::TryFormat(\"\\\"{0}\\\"\", v185);\n\treturn returnVal3;\nL_007D:\n\treturn v106;\n\tv194 = new System.NullReferenceException();\nL_007F:\n\tv211 = new System.ArrayTypeMismatchException();\n\tgoto L_0084;\n\tv216 = new System.IndexOutOfRangeException();\nL_0084:\n\tthrow v215;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string Arg(string value)
		{
			string result;
			if (value != null && value.Length >= 1)
			{
				string text = value.Replace(Quote, EscapedQuote);
				string text2 = text.Replace(SingleQuote, EscapedSingleQuote);
				int num = text2.IndexOf(' ');
				int num2 = num + 1;
				bool flag = num2 == 0;
				result = text2;
				if (!flag)
				{
					object[] array = new object[1];
					object obj = text2 as object;
					if (obj != null)
					{
						array[0] = text2;
						return TryFormat("\"{0}\"", array);
					}
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
					throw ex2;
				}
			}
			else
			{
				result = "\"\"";
			}
			return result;
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x13E4F9C", Offset = "0x13E4F9C", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC5048]);\n\tv19 = *([v18 @ X8_v36]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028B1C]) = v38;\nL_0013:\n\tv39 = value == 0;\n\tif (v39) goto L_00A1;\n\tv51 = value.m_stringLength < 1;\n\tif (v51) goto L_00A1;\n\tgoto L_0033;\n\tv120 = *([v80 @ X0_v3 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0033;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v80, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv124 = LunarConsolePluginInternal.StringUtils;\nL_0033:\n\tv131 = System.String::StartsWith(value, v127.Quote);\n\tv134 = v131 == 0;\n\tif (v134) goto L_004F;\n\tgoto L_0046;\n\tv153 = *([v135 @ X0_v34 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_0046;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v135, v130, v129, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv157 = LunarConsolePluginInternal.StringUtils;\nL_0046:\n\tv144 = System.String::EndsWith(value, v148.Quote);\n\tv175 = v144 == 0;\n\tv146 = ~v175;\n\tif (v146) goto L_0075;\nL_004F:\n\tgoto L_005A;\n\tv161 = *([v149 @ X0_v22 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_005A;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v149, v141, v139, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv165 = LunarConsolePluginInternal.StringUtils;\nL_005A:\n\tv172 = System.String::StartsWith(value, v168.SingleQuote);\n\tv178 = v172 == 0;\n\tif (v178) goto L_007C;\n\tgoto L_006D;\n\tv210 = *([v195 @ X0_v26 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_006D;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v195, v171, v170, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv214 = LunarConsolePluginInternal.StringUtils;\nL_006D:\n\tv184 = System.String::EndsWith(value, v188.SingleQuote);\n\tv186 = v184 == 0;\n\tif (v186) goto L_007C;\nL_0075:\n\tv193 = value.m_stringLength - 2;\n\tv194 = System.String::Substring(value, 1, v193);\nL_007C:\n\tgoto L_008A;\n\tv218 = *([v206 @ X0_v8 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\t// 128 Jump @b44\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v206, v201, v199, v200, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv222 = LunarConsolePluginInternal.StringUtils;\nL_008A:\n\tv234 = System.String::Replace(v112, v229.EscapedQuote, v229.Quote);\n\treturnVal3 = System.String::Replace(v234, v114.EscapedSingleQuote, v114.SingleQuote);\n\treturn returnVal3;\nL_00A1:\n\treturn \"\";\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string UnArg(string value)
		{
			if (value == null || value.Length < 1)
			{
				return "";
			}
			if (value.StartsWith(Quote) && value.EndsWith(Quote))
			{
				goto IL_003b;
			}
			bool flag = value.StartsWith(SingleQuote);
			bool flag2 = !flag;
			string text = value;
			if (!flag2)
			{
				bool flag3 = value.EndsWith(SingleQuote);
				bool flag4 = !flag3;
				text = value;
				if (!flag4)
				{
					goto IL_003b;
				}
			}
			goto IL_0071;
			IL_003b:
			int length = value.Length - 2;
			string text2 = value.Substring(1, length);
			text = text2;
			goto IL_0071;
			IL_0071:
			string text3 = text.Replace(EscapedQuote, Quote);
			return text3.Replace(EscapedSingleQuote, SingleQuote);
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0x13E7954", Offset = "0x13E7954", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = *([1F042B0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028B1D]) = v38;\nL_0021:\n\tv53 = returnVal1 != 0;\n\tif (v53) goto L_002A;\n\tgoto L_002A;\nL_002A:\n\treturn \"\";\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string NonNullOrEmpty(string str)
		{
			string text = default(string);
			if (text == null)
			{
			}
			return "";
		}

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x13D4BF8", Offset = "0x13D4BF8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-4]) = value;\n\tv7 = &v5 @ stack_-10_v2 - 4;\n\treturnVal1 = 0xDC3560(v7, 0, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string ToString(int value)
		{
			//IL_001c: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0x13D4C20", Offset = "0x13D4C20", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-4]) = value;\n\tgoto L_0014;\n\tv15 = *([1EBA350]);\n\tv16 = *([v15 @ X8_v6]);\n\tv17 = \"il2cpp_codegen_initialize_method\"(v16, v18, v19, v20, v21, v22, v23, v24, value, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028B1E]) = v35;\nL_0014:\n\tv38 = &v7 @ stack_-10_v2 - 4;\n\treturnVal1 = 0xBCCF34(v38, \"G\", 0, v20, v21, v22, v23, v24, value, v25, v26, v27, v28, v29, v30, v31);\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string ToString(float value)
		{
			//IL_0021: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0x13E79A8", Offset = "0x13E79A8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\tv8 = &v5 @ stack_-10_v2 - 4;\n\t*([v4 @ X29_v1-4]) = value;\n\treturnVal1 = 0xE8F14C(v8, 0, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string ToString(bool value)
		{
			//IL_0017: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x13E79D4", Offset = "0x13E79D4", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED8140]);\n\tv25 = *([v24 @ X8_v28]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2028B1F]) = v44;\nL_0017:\n\tv46 = value + 0xC;\n\tv59 = *([value @ X0 (UnityEngine.Color&)+C]) <= 0;\n\tif (v59) goto L_00A6;\n\t// 42 NewArr v64 @ X0_v11 (System.Object[]), typeof(System.Object[]), 4\n\tv77 = 0xBCCF34(value, \"G\", 0, v29, v30, v31, v32, v33, *([value @ X0 (UnityEngine.Color&)+C]), v35, v36, v37, v38, v39, v40, v41);\n\tv90 = v77 == 0;\n\tif (v90) goto L_003E;\n\t// 58 IsInst v144 @ X0_v42, typeof(System.Object), v77 @ X0_v13\nL_003E:\n\tv151 = v64.Length == 0;\n\tif (v151) goto L_00C3;\n\tv64[0] = v77;\n\tv153 = value + 4;\n\tv155 = 0xBCCF34(v153, \"G\", 0, v29, v30, v31, v32, v33, *([value @ X0 (UnityEngine.Color&)+C]), v35, v36, v37, v38, v39, v40, v41);\n\tv280 = v155 == 0;\n\tif (v280) goto L_004F;\n\t// 75 IsInst v267 @ X0_v40, typeof(System.Object), v155 @ X0_v25\nL_004F:\n\tv286 = v64.Length < 1;\n\tv189 = ~v286;\n\tv185 = v64.Length - 1;\n\tv177 = v185 == 0;\n\tv287 = ~v189;\n\tv157 = v287 | v177;\n\tif (v157) goto L_00C3;\n\tv64[1] = v155;\n\tv289 = value + 8;\n\tv290 = 0xBCCF34(v289, \"G\", 0, v29, v30, v31, v32, v33, *([value @ X0 (UnityEngine.Color&)+C]), v35, v36, v37, v38, v39, v40, v41);\n\tv291 = v290 == 0;\n\tif (v291) goto L_006A;\n\t// 102 IsInst v268 @ X0_v38, typeof(System.Object), v290 @ X0_v28\nL_006A:\n\tv294 = v64.Length < 2;\n\tv190 = ~v294;\n\tv186 = v64.Length - 2;\n\tv178 = v186 == 0;\n\tv295 = ~v190;\n\tv158 = v295 | v178;\n\tif (v158) goto L_00C3;\n\tv64[2] = v290;\n\tv298 = 0xBCCF34(v46, \"G\", 0, v29, v30, v31, v32, v33, *([value @ X0 (UnityEngine.Color&)+C]), v35, v36, v37, v38, v39, v40, v41);\n\tv299 = v298 == 0;\n\tif (v299) goto L_0085;\n\t// 129 IsInst v269 @ X0_v36, typeof(System.Object), v298 @ X0_v31\nL_0085:\n\tv302 = v64.Length < 3;\n\tv191 = ~v302;\n\tv187 = v64.Length - 3;\n\tv179 = v187 == 0;\n\tv303 = ~v191;\n\tv159 = v303 | v179;\n\tif (v159) goto L_00C3;\n\tv64[3] = v298;\n\treturnVal3 = System.String::Format(\"{0} {1} {2} {3}\", v64);\n\treturn returnVal3;\nL_00A6:\n\tv70 = 0xBCCF34(value, \"G\", 0, v29, v30, v31, v32, v33, *([value @ X0 (UnityEngine.Color&)+C]), v35, v36, v37, v38, v39, v40, v41);\n\tv80 = value + 4;\n\tv82 = 0xBCCF34(v80, \"G\", 0, v29, v30, v31, v32, v33, *([value @ X0 (UnityEngine.Color&)+C]), v35, v36, v37, v38, v39, v40, v41);\n\tv87 = value + 8;\n\tv89 = 0xBCCF34(v87, \"G\", 0, v29, v30, v31, v32, v33, *([value @ X0 (UnityEngine.Color&)+C]), v35, v36, v37, v38, v39, v40, v41);\n\treturnVal2 = System.String::Format(\"{0} {1} {2}\", v70, v82, v89);\n\treturn returnVal2;\nL_00C3:\n\tv216 = new System.IndexOutOfRangeException();\n\tgoto L_00C8;\n\tv279 = new System.ArrayTypeMismatchException();\nL_00C8:\n\tthrow v283;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static string ToString(ref Color value)
		{
			//IL_0365: Expected O, but got I
			//IL_02ed: Expected O, but got I
			//IL_0310: Expected O, but got I
			//IL_0096: Expected O, but got I
			//IL_0100: Expected O, but got I4
			//IL_0156: Expected O, but got I
			//IL_01c0: Expected O, but got I4
			//IL_0271: Expected O, but got I4
			object obj = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 12);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X0 (UnityEngine.Color&)+C]");
			if (0L > 0L)
			{
				object[] array = new object[4];
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
				object obj2 = default(object);
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				if (array.Length != 0)
				{
					array[0] = obj2;
					object obj4 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 4);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
					object obj5 = default(object);
					if (obj5 != null)
					{
						object obj6 = obj5 as object;
					}
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj7 = array.Length - 1;
					bool flag3 = obj7 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = obj5;
						object obj8 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 8);
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
						object obj9 = default(object);
						if (obj9 != null)
						{
							object obj10 = obj9 as object;
						}
						bool flag5 = array.Length < 2;
						bool flag6 = !flag5;
						object obj11 = array.Length - 2;
						bool flag7 = obj11 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							array[2] = obj9;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
							object obj12 = default(object);
							if (obj12 != null)
							{
								object obj13 = obj12 as object;
							}
							bool flag9 = array.Length < 3;
							bool flag10 = !flag9;
							object obj14 = array.Length - 3;
							bool flag11 = obj14 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								array[3] = obj12;
								return string.Format("{0} {1} {2} {3}", array);
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object obj15 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 4);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object obj16 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 8);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object arg = default(object);
			object arg2 = default(object);
			object arg3 = default(object);
			return $"{arg} {arg2} {arg3}";
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x13E7BEC", Offset = "0x13E7BEC", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EBC7C0]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2028B20]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 4\n\tv51 = 0x10CCFB4(value, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv58 = 0xBCCF34(&v32 @ V0, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv61 = v58 == 0;\n\tif (v61) goto L_0031;\n\t// 45 IsInst v110 @ X0_v42, typeof(System.Object), v58 @ X0_v7\nL_0031:\n\tv117 = v47.Length == 0;\n\tif (v117) goto L_009F;\n\tv47[0] = v58;\n\tv120 = 0x10CCFC4(value, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv250 = 0xBCCF34(&v32 @ V0, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv254 = v250 == 0;\n\tif (v254) goto L_0046;\n\t// 66 IsInst v235 @ X0_v40, typeof(System.Object), v250 @ X0_v21\nL_0046:\n\tv257 = v47.Length < 1;\n\tv154 = ~v257;\n\tv150 = v47.Length - 1;\n\tv142 = v150 == 0;\n\tv258 = ~v154;\n\tv122 = v258 | v142;\n\tif (v122) goto L_009F;\n\tv47[1] = v250;\n\tv261 = 0x10CD178(value, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv264 = 0xBCCF34(&v32 @ V0, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv265 = v264 == 0;\n\tif (v265) goto L_0065;\n\t// 97 IsInst v236 @ X0_v38, typeof(System.Object), v264 @ X0_v26\nL_0065:\n\tv268 = v47.Length < 2;\n\tv155 = ~v268;\n\tv151 = v47.Length - 2;\n\tv143 = v151 == 0;\n\tv269 = ~v155;\n\tv123 = v269 | v143;\n\tif (v123) goto L_009F;\n\tv47[2] = v264;\n\tv272 = 0x10CD188(value, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv275 = 0xBCCF34(&v32 @ V0, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv276 = v275 == 0;\n\tif (v276) goto L_0084;\n\t// 128 IsInst v237 @ X0_v36, typeof(System.Object), v275 @ X0_v31\nL_0084:\n\tv279 = v47.Length < 3;\n\tv156 = ~v279;\n\tv152 = v47.Length - 3;\n\tv144 = v152 == 0;\n\tv280 = ~v156;\n\tv124 = v280 | v144;\n\tif (v124) goto L_009F;\n\tv47[3] = v275;\n\treturnVal2 = System.String::Format(\"{0} {1} {2} {3}\", v47);\n\treturn returnVal2;\nL_009F:\n\tv186 = new System.IndexOutOfRangeException();\n\tgoto L_00A4;\n\tv247 = new System.ArrayTypeMismatchException();\nL_00A4:\n\tthrow v253;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string ToString(ref Rect value)
		{
			//IL_00e3: Expected O, but got I4
			//IL_01a8: Expected O, but got I4
			//IL_026d: Expected O, but got I4
			object[] array = new object[4];
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object obj = default(object);
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
				object obj3 = default(object);
				if (obj3 != null)
				{
					object obj4 = obj3 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj5 = array.Length - 1;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj3;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
					object obj6 = default(object);
					if (obj6 != null)
					{
						object obj7 = obj6 as object;
					}
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj8 = array.Length - 2;
					bool flag7 = obj8 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = obj6;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
						object obj9 = default(object);
						if (obj9 != null)
						{
							object obj10 = obj9 as object;
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj11 = array.Length - 3;
						bool flag11 = obj11 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = obj9;
							return string.Format("{0} {1} {2} {3}", array);
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x13E7DC4", Offset = "0x13E7DC4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0F668]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028B21]) = v40;\nL_0019:\n\tv46 = 0xBCCF34(value, \"G\", 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = value + 4;\n\tv51 = 0xBCCF34(v49, \"G\", 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal1 = System.String::Format(\"{0} {1}\", v46, v51);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static string ToString(ref Vector2 value)
		{
			//IL_0028: Expected O, but got I
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object obj = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 4);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object arg = default(object);
			object arg2 = default(object);
			return $"{arg} {arg2}";
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x13E7E54", Offset = "0x13E7E54", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EDF918]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2028B22]) = v42;\nL_001A:\n\tv48 = 0xBCCF34(value, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = value + 4;\n\tv53 = 0xBCCF34(v51, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = value + 8;\n\tv58 = 0xBCCF34(v56, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturnVal1 = System.String::Format(\"{0} {1} {2}\", v48, v53, v58);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static string ToString(ref Vector3 value)
		{
			//IL_0042: Expected O, but got I
			//IL_0060: Expected O, but got I
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object obj = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 4);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object obj2 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 8);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object arg = default(object);
			object arg2 = default(object);
			object arg3 = default(object);
			return $"{arg} {arg2} {arg3}";
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x13E7EFC", Offset = "0x13E7EFC", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1F02FC0]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2028B23]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 4\n\tv54 = 0xBCCF34(value, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv57 = v54 == 0;\n\tif (v57) goto L_002D;\n\t// 41 IsInst v104 @ X0_v34, typeof(System.Object), v54 @ X0_v5\nL_002D:\n\tv111 = v47.Length == 0;\n\tif (v111) goto L_008F;\n\tv47[0] = v54;\n\tv113 = value + 4;\n\tv115 = 0xBCCF34(v113, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv236 = v115 == 0;\n\tif (v236) goto L_003E;\n\t// 58 IsInst v223 @ X0_v32, typeof(System.Object), v115 @ X0_v17\nL_003E:\n\tv242 = v47.Length < 1;\n\tv149 = ~v242;\n\tv145 = v47.Length - 1;\n\tv137 = v145 == 0;\n\tv243 = ~v149;\n\tv117 = v243 | v137;\n\tif (v117) goto L_008F;\n\tv47[1] = v115;\n\tv245 = value + 8;\n\tv246 = 0xBCCF34(v245, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv247 = v246 == 0;\n\tif (v247) goto L_0059;\n\t// 85 IsInst v224 @ X0_v30, typeof(System.Object), v246 @ X0_v20\nL_0059:\n\tv250 = v47.Length < 2;\n\tv150 = ~v250;\n\tv146 = v47.Length - 2;\n\tv138 = v146 == 0;\n\tv251 = ~v150;\n\tv118 = v251 | v138;\n\tif (v118) goto L_008F;\n\tv47[2] = v246;\n\tv253 = value + 0xC;\n\tv254 = 0xBCCF34(v253, \"G\", 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv255 = v254 == 0;\n\tif (v255) goto L_0074;\n\t// 112 IsInst v225 @ X0_v28, typeof(System.Object), v254 @ X0_v23\nL_0074:\n\tv258 = v47.Length < 3;\n\tv151 = ~v258;\n\tv147 = v47.Length - 3;\n\tv139 = v147 == 0;\n\tv259 = ~v151;\n\tv119 = v259 | v139;\n\tif (v119) goto L_008F;\n\tv47[3] = v254;\n\treturnVal2 = System.String::Format(\"{0} {1} {2} {3}\", v47);\n\treturn returnVal2;\nL_008F:\n\tv176 = new System.IndexOutOfRangeException();\n\tgoto L_0094;\n\tv235 = new System.ArrayTypeMismatchException();\nL_0094:\n\tthrow v239;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static string ToString(ref Vector4 value)
		{
			//IL_0074: Expected O, but got I
			//IL_00de: Expected O, but got I4
			//IL_0134: Expected O, but got I
			//IL_019e: Expected O, but got I4
			//IL_01f4: Expected O, but got I
			//IL_025e: Expected O, but got I4
			object[] array = new object[4];
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			object obj = default(object);
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				object obj3 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 4);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
				object obj4 = default(object);
				if (obj4 != null)
				{
					object obj5 = obj4 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj6 = array.Length - 1;
				bool flag3 = obj6 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj4;
					object obj7 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 8);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
					object obj8 = default(object);
					if (obj8 != null)
					{
						object obj9 = obj8 as object;
					}
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj10 = array.Length - 2;
					bool flag7 = obj10 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = obj8;
						object obj11 = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value) + 12);
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
						object obj12 = default(object);
						if (obj12 != null)
						{
							object obj13 = obj12 as object;
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj14 = array.Length - 3;
						bool flag11 = obj14 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = obj12;
							return string.Format("{0} {1} {2} {3}", array);
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0xBAE8B0", Offset = "0xBAE8B0", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EC0B80]);\n\tv31 = *([v30 @ X8_v29]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, separator, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022C29]) = v48;\nL_001C:\n\tv52 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v52);\n\tgoto L_00AC;\nL_002A:\n\tgoto L_002D;\n\tv303 = v118;\n\tv304 = 0x8907BC(v303, v122, v66, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_002D:\n\tv306 = list->klass;\n\tv308 = *([v306 @ X8_v15 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v308) goto L_FFFFFFFF;\n\tv351 = *([v306 @ X8_v15 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0039:\n\tv356 = *([v351 @ X11_v14-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v356) goto L_0052;\n\tv350 = v350 + 1;\n\tv361 = v350 < *([v306 @ X8_v15 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv331 = ~v361;\n\tv351 = v351 + 0x10;\n\tv315 = ~v331;\n\tif (v315) goto L_0039;\n\tgoto L_0059;\nL_0052:\n\t;\nL_0059:\n\tv126 = System.Collections.Generic.IList`1<T>::get_Item(list, v120);\n\tv374 = System.Text.StringBuilder::Append(v52, v126);\n\tgoto L_0069;\n\tv380 = v166;\n\tv381 = 0x8907BC(v380, v123, v373, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0069:\n\tv383 = list->klass;\n\tv173 = *([v383 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v173) goto L_FFFFFFFF;\n\tv427 = *([v383 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0075:\n\tv432 = *([v427 @ X11_v9-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v432) goto L_008E;\n\tv426 = v426 + 1;\n\tv437 = v426 < *([v383 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv407 = ~v437;\n\tv427 = v427 + 0x10;\n\tv391 = ~v407;\n\tif (v391) goto L_0075;\n\tgoto L_0094;\nL_008E:\n\t;\nL_0094:\n\tv458 = System.Collections.Generic.ICollection`1<T>::get_Count(list);\n\tv175 = v458 - 1;\n\tv142 = v120 >= v175;\n\tif (v142) goto L_00A5;\n\tv463 = System.Text.StringBuilder::Append(v52, separator);\nL_00A5:\n\tv120 = v120 + 1;\nL_00AC:\n\tgoto L_00AF;\n\tv181 = v117;\n\tv182 = 0x8907BC(v181, v168, v139, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00AF:\n\tv184 = list->klass;\n\tv186 = *([v184 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v186) goto L_FFFFFFFF;\n\tv268 = *([v184 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_00BB:\n\tv273 = *([v268 @ X11_v19-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v273) goto L_00D4;\n\tv267 = v267 + 1;\n\tv278 = v267 < *([v184 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv248 = ~v278;\n\tv268 = v268 + 0x10;\n\tv232 = ~v248;\n\tif (v232) goto L_00BB;\n\tgoto L_00DA;\nL_00D4:\n\t;\nL_00DA:\n\tv125 = System.Collections.Generic.ICollection`1<T>::get_Count(list);\n\tv70 = v120 < v125;\n\tif (v70) goto L_002A;\n\tv221 = *([v52 @ X0_v3 (System.Text.StringBuilder)]);\n\tv192 = *([v221 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv210 = *([v221 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 246 IndirectJump v192 @ X2_v4, v52 @ X0_v3 (System.Text.StringBuilder), v52 @ X0_v3 (System.Text.StringBuilder), v210 @ X1_v6, v192 @ X2_v4, v33 @ X3, v34 @ X4, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string Join<T>(IList<T> list, string separator = ",")
		{
			//IL_01cb: Expected I, but got O
			//IL_0206: Expected O, but got I
			//IL_0020: Expected I, but got O
			//IL_0281: Expected I, but got O
			//IL_0291: Expected O, but got I
			//IL_02a1: Expected O, but got I
			//IL_0252: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_00ec: Expected I, but got O
			//IL_00a7: Expected O, but got I
			//IL_0326: Expected O, but got I4
			//IL_0127: Expected O, but got I
			//IL_0173: Expected O, but got I
			while (true)
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				while (true)
				{
					IntPtr intPtr = (IntPtr)list;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
						object obj = 0L + 8L;
						int num2 = 0;
						bool flag2;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ X11_v19-8]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								num2++;
								int num3 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
								bool flag = (long)num3 < 0L;
								flag2 = !flag;
								obj = (long)(IntPtr)obj + 16L;
								continue;
							}
							break;
						}
						while (!flag2);
					}
					int count = list.Count;
					if (num >= count)
					{
						break;
					}
					IntPtr intPtr2 = (IntPtr)list;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ X8_v15 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ X8_v15 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
						object obj2 = 0L + 8L;
						int num4 = 0;
						bool flag4;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X11_v14-8]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								num4++;
								int num5 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ X8_v15 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
								bool flag3 = (long)num5 < 0L;
								flag4 = !flag3;
								obj2 = (long)(IntPtr)obj2 + 16L;
								continue;
							}
							break;
						}
						while (!flag4);
					}
					object value = list.get_Item(num);
					StringBuilder stringBuilder2 = stringBuilder.Append(value);
					IntPtr intPtr3 = (IntPtr)list;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
						object obj3 = 0L + 8L;
						int num6 = 0;
						bool flag6;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ X11_v9-8]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								num6++;
								int num7 = num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
								bool flag5 = (long)num7 < 0L;
								flag6 = !flag5;
								obj3 = (long)(IntPtr)obj3 + 16L;
								continue;
							}
							break;
						}
						while (!flag6);
					}
					object obj4 = list.Count;
					int num8 = (int)((long)(IntPtr)obj4 - 1L);
					if (num < num8)
					{
						StringBuilder stringBuilder3 = stringBuilder.Append(separator);
					}
					num++;
				}
				IntPtr intPtr4 = (IntPtr)stringBuilder;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+160]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+168]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v192 @ X2_v4 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x13E8088", Offset = "0x13E8088", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE74F8]);\n\tv27 = *([v26 @ X8_v23]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2028B24]) = v46;\nL_0019:\n\tv49 = System.String::IsNullOrEmpty(value);\n\tv51 = v49 == 0;\n\tif (v51) goto L_002B;\n\treturn value;\nL_002B:\n\tv64 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v64);\n\tv154 = value.m_stringLength < 1;\n\tif (v154) goto L_00B6;\nL_0045:\n\tv221 = System.String::get_Chars(value, v175);\n\tv224 = v175 == 0;\n\tif (v224) goto L_0094;\n\tgoto L_0056;\n\tv229 = *([v222 @ X8_v10+E0]);\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_0056;\n\tv248 = v222;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v248, v220, v155, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0056:\n\tv237 = System.Char::IsUpper(v221);\n\tv250 = v237 == 0;\n\tv251 = ~v250;\n\tif (v251) goto L_0080;\n\tgoto L_0067;\n\tv268 = *([v254 @ X0_v31+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0067;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v254, v236, v155, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0067:\n\tv264 = System.Char::IsDigit(v221);\n\tv266 = v264 == 0;\n\tif (v266) goto L_00A4;\n\tgoto L_0077;\n\tv314 = *([v309 @ X0_v35+E0]);\n\tv315 = v314 == 0;\n\tv316 = ~v315;\n\tif (v316) goto L_0077;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v309, v263, v155, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0077:\n\tv259 = System.Char::IsDigit(v171);\n\tv322 = v259 == 0;\n\tv261 = ~v322;\n\tif (v261) goto L_00A4;\nL_0080:\n\tv277 = System.Text.StringBuilder::get_Length(v64);\n\tv281 = v277 < 1;\n\tif (v281) goto L_00A4;\n\tv301 = System.Text.StringBuilder::Append(v64, 0x20);\n\tgoto L_00A4;\nL_0094:\n\tgoto L_009D;\n\tv238 = *([v222 @ X8_v10+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_009D;\n\tv252 = v222;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v252, v220, v155, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_009D:\n\tv247 = System.Char::ToUpper(v221);\nL_00A4:\n\tv208 = System.Text.StringBuilder::Append(v64, v207);\n\tv175 = v175 + 1;\n\tv195 = v175 < value.m_stringLength;\n\tif (v195) goto L_0045;\nL_00B6:\n\tv134 = *([v64 @ X0_v5 (System.Text.StringBuilder)]);\n\tv66 = *([v134 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv109 = *([v134 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 195 IndirectJump v66 @ X2_v3, v64 @ X0_v5 (System.Text.StringBuilder), v64 @ X0_v5 (System.Text.StringBuilder), v109 @ X1_v5, v66 @ X2_v3, v31 @ X3, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToDisplayName(string value)
		{
			//IL_01c5: Expected I, but got O
			//IL_01d5: Expected O, but got I
			//IL_01e5: Expected O, but got I
			while (!string.IsNullOrEmpty(value))
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (value.Length >= 1)
				{
					char c = '\0';
					int num = 0;
					bool flag7;
					do
					{
						char c2 = value.get_Chars(num);
						char c3;
						if (num != 0)
						{
							if (char.IsUpper(c2))
							{
								goto IL_0105;
							}
							bool flag = char.IsDigit(c2);
							bool flag2 = !flag;
							c3 = c2;
							if (!flag2)
							{
								bool flag3 = char.IsDigit(c);
								bool flag4 = !flag3;
								bool flag5 = !flag4;
								c3 = c2;
								if (!flag5)
								{
									goto IL_0105;
								}
							}
						}
						else
						{
							char c4 = char.ToUpper(c2);
							c3 = c4;
						}
						goto IL_0175;
						IL_0105:
						int length = stringBuilder.Length;
						bool flag6 = length < 1;
						c3 = c2;
						if (!flag6)
						{
							StringBuilder stringBuilder2 = stringBuilder.Append(' ');
							c3 = c2;
						}
						goto IL_0175;
						IL_0175:
						StringBuilder stringBuilder3 = stringBuilder.Append(c3);
						num++;
						flag7 = num < value.Length;
						c = c3;
					}
					while (flag7);
				}
				IntPtr intPtr = (IntPtr)stringBuilder;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+160]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+168]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v66 @ X2_v3 (should have been resolved before IL gen)");
			}
			return value;
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0x13D923C", Offset = "0x13D923C", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EFED88]);\n\tv33 = *([v32 @ X8_v26]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2028B25]) = v52;\nL_001E:\n\t// 30 NewArr v57 @ X0_v3 (System.Char[]), typeof(System.Char[]), 1\n\tv61 = v57.Length == 0;\n\tif (v61) goto L_00C4;\n\tv57[0] = 0xA;\n\tv212 = System.String::Split(data, v57);\n\tv219 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v219);\n\tv206 = v212.Length;\n\tv305 = v212.Length < 1;\n\tif (v305) goto L_00C1;\nL_004E:\n\tv347 = v92 < v206;\n\tv137 = ~v347;\n\tif (v137) goto L_00C4;\n\tv85 = v212[v92 @ X24_v7 (System.Int32)];\n\tv351 = System.String::IndexOf(v212[v92 @ X24_v7 (System.Int32)], 0x3A);\n\tv356 = System.String::Substring(v212[v92 @ X24_v7 (System.Int32)], 0, v351);\n\tv143 = v351 + 1;\n\tv140 = v85.m_stringLength - v143;\n\tv150 = System.String::Substring(v212[v92 @ X24_v7 (System.Int32)], v143, v140);\n\tv220 = System.String::Replace(v150, \"\\\\n\", \"\\n\");\n\tv358 = *([v219 @ X0_v15 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]);\n\tv337 = *([v358 @ X8_v19 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.String>>)+126]) == 0;\n\tif (v337) goto L_0099;\n\tv393 = *([v358 @ X8_v19 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.String>>)+B0]) + 8;\nL_0084:\n\tv407 = *([v393 @ X11_v10-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v407) goto L_009C;\n\tv392 = v392 + 1;\n\tv412 = v392 < *([v358 @ X8_v19 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.String>>)+126]);\n\tv387 = ~v412;\n\tv393 = v393 + 0x10;\n\tv371 = ~v387;\n\tif (v371) goto L_0084;\nL_0099:\n\tv428 = 0x8909C4(v219, System.Collections.Generic.IDictionary`2<System.String, System.String>, 1, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00A5;\nL_009C:\n\tv414 = *([v393 @ X11_v10]) + 1;\n\tv415 = v414 << 4;\n\tv416 = v358 + v415;\n\tv428 = v416 + 0x130;\nL_00A5:\n\t*([v428 @ X0_v26])(v336, v219, v356, v220, *([v428 @ X0_v26+8]), v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv206 = v212.Length;\n\tv92 = v92 + 1;\n\tv323 = v92 < v212.Length;\n\tif (v323) goto L_004E;\nL_00C1:\n\treturn v219;\n\tv200 = new System.NullReferenceException();\nL_00C4:\n\tv208 = new System.IndexOutOfRangeException();\n\tthrow v208;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IDictionary<string, string> DeserializeString(string data)
		{
			//IL_0154: Expected I, but got O
			//IL_018f: Expected O, but got I
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected O, but got Unknown
			//IL_0233: Expected O, but got I
			//IL_0242: Expected O, but got I
			//IL_01db: Expected O, but got I
			char[] array = new char[1];
			Dictionary<string, string> dictionary;
			if (array.Length != 0)
			{
				array[0] = '\n';
				string[] array2 = data.Split(array);
				dictionary = new Dictionary<string, string>();
				int num = array2.Length;
				if (array2.Length < 1)
				{
					goto IL_0247;
				}
				int num2 = 0;
				while (num2 < num)
				{
					string text = array2[num2];
					int num3 = array2[num2].IndexOf(':');
					string text2 = array2[num2].Substring(0, num3);
					int num4 = num3 + 1;
					int length = text.Length - num4;
					string text3 = array2[num2].Substring(num4, length);
					string text4 = text3.Replace("\\n", "\n");
					IntPtr intPtr = (IntPtr)dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v19 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.String>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01f4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v19 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.String>>)+B0]");
					object obj = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ X11_v10-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v19 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.String>>)+126]");
						bool flag = (long)num6 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_01f4;
					}
					object obj2 = obj + 1;
					int num7 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num7;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_0297;
					IL_01f4:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0297;
					IL_0297:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v428 @ X0_v26] (should have been resolved before IL gen)");
					num = array2.Length;
					num2++;
					if (num2 < array2.Length)
					{
						continue;
					}
					goto IL_0247;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0247:
			return dictionary;
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x13E8260", Offset = "0x13E8260", Length = "0x1110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EF1440]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2028B26]) = v37;\nL_0016:\n\t// 22 NewArr v42 @ X0_v3 (System.Char[]), typeof(System.Char[]), 1\n\tv45 = v42.Length == 0;\n\tif (v45) goto L_004B;\n\tv42[0] = 0x20;\n\tv51.kSpaceSplitChars = v42;\n\tv55 = new System.Text.RegularExpressions.Regex();\n\tSystem.Text.RegularExpressions.Regex::.ctor(v55, \"(<color=.*?>)|(<b>)|(<i>)|(</color>)|(</b>)|(</i>)\");\n\tv69.kRichTagRegex = v55;\n\tv72.Quote = \"\\\"\";\n\tv76.SingleQuote = \"'\";\n\tv80.EscapedQuote = \"\\\\\\\"\";\n\tv84.EscapedSingleQuote = \"\\\\'\";\n\treturn;\n\tv46 = new System.NullReferenceException();\nL_004B:\n\tv59 = new System.IndexOutOfRangeException();\n\tthrow v59;\n\t<>__AnonType0`3::.ctor /* +2 sharing this address */(v67, 0, 0, v21, v22);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x13DA008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX9 = *([X9+7C0]);\n\tX0 = 0x13E3008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1076 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static StringUtils()
		{
			char[] array = new char[1];
			if (array.Length != 0)
			{
				array[0] = ' ';
				kSpaceSplitChars = array;
				Regex regex = new Regex("(<color=.*?>)|(<b>)|(<i>)|(</color>)|(</b>)|(</i>)");
				kRichTagRegex = regex;
				Quote = "\"";
				SingleQuote = "'";
				EscapedQuote = "\\\"";
				EscapedSingleQuote = "\\'";
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
