using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000086")]
	public static class EEACountriesExtension
	{
		[Token(Token = "0x60005E4")]
		[Address(RVA = "0xA55614", Offset = "0xA55614", Length = "0x3C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_0018;\n\tv28 = *([1F093E0]);\n\tv29 = *([v28 @ X8_v42]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021FA8]) = v48;\nL_0018:\n\tv49 = &v50 @ stack_-60;\n\t*([v18 @ X29_v1-34]) = 0;\n\tv54 = System.String::IsNullOrEmpty(countryCode);\n\tv57 = v54 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0174;\n\tv158 = System.String::ToUpper(countryCode);\n\tgoto L_003B;\n\tv304 = *([v266 @ X8_v17+E0]);\n\tv305 = v304 == 0;\n\tv306 = ~v305;\n\tif (v306) goto L_003B;\n\tv343 = v266;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v343, v157, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_003B:\n\tv313 = System.Type::GetTypeFromHandle(EasyMobile.EEACountries);\n\tgoto L_004C;\n\tv349 = *([v301 @ X8_v20+E0]);\n\tv350 = v349 == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_004C;\n\tv366 = v301;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v366, v312, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_004C:\n\tv295 = System.Enum::GetValues(v313);\n\tv336 = System.Array::GetEnumerator(v295);\n\tv338 = v336 == 0;\n\tif (v338) goto L_00F7;\nL_005C:\n\tgoto L_0083;\n\tv478 = *([v473 @ X8_v22+B0]);\n\tv479 = 0;\n\tv480 = v478 + 8;\n\tv482 = *([v545 @ X11_v25-8]);\n\tv551 = v482 == v474;\n\tif (v551) goto L_007C;\n\tv504 = v546 + 1;\n\tv588 = v504 < v475;\n\tv500 = ~v588;\n\tv502 = v545 + 0x10;\n\tv484 = ~v500;\n\tif (v484) goto L_FFFFFFFF;\n\tv505 = v204;\n\tv506 = 0;\n\tv507 = 0x8909C4(v505, v474, v506, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0083;\nL_007C:\n\tv589 = *([v545 @ X11_v25]);\n\tv590 = v589 << 4;\n\tv591 = v473 + v590;\n\tv592 = v591 + 0x130;\nL_0083:\n\tv430 = System.Collections.IEnumerator::MoveNext(v336);\n\tv433 = v430 == 0;\n\tif (v433) goto L_00ED;\n\tv619 = *([v336 @ X0_v36 (System.Collections.IEnumerator)]);\n\tv622 = *([v619 @ X8_v26 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v622) goto L_00A9;\n\tv672 = *([v619 @ X8_v26 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0094:\n\tv678 = *([v672 @ X11_v20-8]) == System.Collections.IEnumerator;\n\tif (v678) goto L_00AC;\n\tv673 = v673 + 1;\n\tv683 = v673 < *([v619 @ X8_v26 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv654 = ~v683;\n\tv672 = v672 + 0x10;\n\tv638 = ~v654;\n\tif (v638) goto L_0094;\nL_00A9:\n\tv699 = 0x8909C4(v336, System.Collections.IEnumerator, 1, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00B3;\nL_00AC:\n\tv685 = *([v672 @ X11_v20]) + 1;\n\tv686 = v685 << 4;\n\tv687 = v619 + v686;\n\tv699 = v687 + 0x130;\nL_00B3:\n\t*([v699 @ X0_v41])(v704, v336, *([v699 @ X0_v41+8]), v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv389 = v389_asT == 0;\n\tif (v389) goto L_00F0;\n\tv467 = \"il2cpp_vm_object_unbox\"(v704, EasyMobile.EEACountries, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([v18 @ X29_v1-34]) = *([v467 @ X0_v53]);\n\tv469 = *([v467 @ X0_v53]) == 0;\n\tif (v469) goto L_005C;\n\tv736 = &v19 @ stack_-10_v2 - 0x34;\n\t// 204 Box v738 @ X0_v55, typeof(EasyMobile.EEACountries), v736 @ X1_v26 (Il2CppClass<EasyMobile.EEACountries>)\n\tv750 = *([v738 @ X0_v55]);\n\t*([v750 @ X8_v35+160])(v752, v738, *([v750 @ X8_v35+168]), v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv747 = \"il2cpp_vm_object_unbox\"(v738, *([v750 @ X8_v35+168]), v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([v18 @ X29_v1-34]) = *([v747 @ X0_v59]);\n\tv429 = System.String::Equals(v158, v752);\n\tv432 = v429 == 0;\n\tif (v432) goto L_005C;\n\t*([v49 @ X23_v1]) = 0x70;\n\tgoto L_0115;\nL_00ED:\n\t*([v49 @ X23_v1]) = 0x6E;\n\tgoto L_0115;\n\tv709 = new System.NullReferenceException();\nL_00F0:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv303 = new System.NullReferenceException();\nL_00F7:\n\tv342 = new System.NullReferenceException();\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\nL_010A:\n\tv365 = 0 != 1;\n\tif (v365) goto L_0175;\n\tv367 = 0x6D2BC0(v342, 0, v317, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv144 = *([v367 @ X0_v24]);\n\tv370 = 0x6D2490(v367, 0, v317, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0115:\n\t// 277 IsInst v443 @ X0_v8 (System.IDisposable), typeof(System.IDisposable), v434 @ X19_v4 (System.Collections.IEnumerator)\n\tv477 = v443 == 0;\n\tif (v477) goto L_0145;\n\tgoto L_0144;\n\tv556 = *([v508 @ X8_v7+B0]);\n\tv557 = 0;\n\tv558 = v556 + 8;\n\tv560 = *([v608 @ X11_v8-8]);\n\tv614 = v560 == v509;\n\tif (v614) goto L_013D;\n\tv582 = v609 + 1;\n\tv623 = v582 < v510;\n\tv578 = ~v623;\n\tv580 = v608 + 0x10;\n\tv562 = ~v578;\n\tif (v562) goto L_FFFFFFFF;\n\tv583 = v139;\n\tv584 = 0;\n\tv585 = 0x8909C4(v583, v509, v584, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0144;\nL_013D:\n\tv624 = *([v608 @ X11_v8]);\n\tv625 = v624 << 4;\n\tv626 = v508 + v625;\n\tv627 = v626 + 0x130;\nL_0144:\n\tSystem.IDisposable::Dispose(v443);\nL_0145:\n\tv136 = v64 + 1;\n\tv94 = v136 == 0;\n\tif (v94) goto L_0164;\n\tv96 = *([v49 @ X23_v1+v64 @ X22_v3 (System.Int32)*4]) == 0x70;\n\tif (v96) goto L_0174;\n\tv137 = v144 == 0;\n\tif (v137) goto L_0174;\n\tv97 = *([v49 @ X23_v1+v64 @ X22_v3 (System.Int32)*4]) == 0x6E;\n\tif (v97) goto L_0174;\n\tgoto L_0179;\nL_0164:\n\tv587 = v144 == 0;\n\tv135 = ~v587;\n\tif (v135) goto L_0179;\nL_0174:\n\treturn v128;\nL_0175:\n\tv368 = 0x6D2380(v342, 0, v317, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0179:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 222 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool IsEEACountry(this string countryCode)
		{
			//IL_03f6: Expected I4, but got O
			//IL_02f2: Expected I4, but got O
			//IL_0283: Expected O, but got I4
			//IL_007e: Expected I, but got O
			//IL_00b9: Expected O, but got I
			//IL_018b: Expected I4, but got O
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_0161: Expected O, but got I
			//IL_0170: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_0252: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			object obj4 = default(object);
			object obj3 = obj4;
			_ = 0;
			bool flag = string.IsNullOrEmpty(countryCode);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			bool result = false;
			if (!flag3)
			{
				string text = countryCode.ToUpper();
				Type typeFromHandle = typeof(EEACountries);
				Array values = Enum.GetValues(typeFromHandle);
				IEnumerator enumerator = values.GetEnumerator();
				bool flag4 = enumerator == null;
				IEnumerator enumerator2 = enumerator;
				int num;
				int num2;
				int num3;
				if (flag4)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						goto IL_03e8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj5 = default(object);
					num = (int)obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					num2 = -1;
					num3 = 0;
				}
				else
				{
					object obj10 = default(object);
					object obj11 = default(object);
					string value = default(string);
					while (true)
					{
						int num7;
						if (enumerator.MoveNext())
						{
							IntPtr intPtr = (IntPtr)enumerator;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ X8_v26 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_011e;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ X8_v26 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
							object obj6 = 0L + 8L;
							int num4 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ X11_v20-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
								{
									break;
								}
								num4++;
								int num5 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ X8_v26 (Il2CppClass<System.Collections.IEnumerator>)+126]");
								bool flag5 = (long)num5 < 0L;
								bool flag6 = !flag5;
								obj6 = (long)(IntPtr)obj6 + 16L;
								if (!flag6)
								{
									continue;
								}
								goto IL_011e;
							}
							object obj7 = obj6 + 1;
							int num6 = (int)((long)(IntPtr)obj7 << 4);
							object obj8 = (long)intPtr + (long)num6;
							object obj9 = (long)(IntPtr)obj8 + 304L;
							num7 = 0;
							goto IL_049b;
						}
						obj3 = 110;
						num2 = 0;
						num3 = 0;
						enumerator2 = enumerator;
						num = 0;
						break;
						IL_049b:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v699 @ X0_v41] (should have been resolved before IL gen)");
						if ((int)((obj10 is EEACountries) ? obj10 : null) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							if (obj11 != null)
							{
								IntPtr intPtr2 = (IntPtr)(void*)((long)(IntPtr)obj2 - 52L);
								object obj12 = (EEACountries)(long)intPtr2;
								object obj13 = obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v750 @ X8_v35+160] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								if (text.Equals(value))
								{
									obj3 = 112;
									num2 = 0;
									num3 = 1;
									enumerator2 = enumerator;
									num = 0;
									break;
								}
							}
							continue;
						}
						throw new InvalidCastException();
						IL_011e:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						num7 = 1;
						goto IL_049b;
					}
				}
				(enumerator2 as IDisposable)?.Dispose();
				if (num2 + 1 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X23_v1+v64 @ X22_v3 (System.Int32)*4]");
					bool flag7 = (IntPtr)0 == (IntPtr)112;
					result = (byte)num3 != 0;
					if (!flag7)
					{
						bool flag8 = num == 0;
						result = false;
						if (!flag8)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X23_v1+v64 @ X22_v3 (System.Int32)*4]");
							bool flag9 = (IntPtr)0 == (IntPtr)110;
							result = false;
							if (!flag9)
							{
								goto IL_03e8;
							}
						}
					}
				}
				else
				{
					if (num != 0)
					{
						goto IL_03e8;
					}
					result = false;
				}
			}
			return result;
			IL_03e8:
			TypeLoadException ex2 = new TypeLoadException();
			return (byte)(int)ex2 != 0;
		}

		[Token(Token = "0x60005E5")]
		[Address(RVA = "0xA559D4", Offset = "0xA559D4", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA8B80]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FA9]) = v38;\nL_0014:\n\tv40 = EasyMobile.EEACountriesExtension::IsEEACountry(countryCode);\n\tv42 = v40 == 0;\n\tif (v42) goto L_001E;\n\tgoto L_005D;\nL_001E:\n\tv129 = System.String::ToUpper(countryCode);\n\tgoto L_0031;\n\tv179 = *([v160 @ X0_v26+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0031;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v160, v128, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0031:\n\tv188 = System.Type::GetTypeFromHandle(EasyMobile.EEACountries);\n\tgoto L_0042;\n\tv211 = *([v207 @ X0_v30+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_0042;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v207, v187, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0042:\n\tv172 = System.Enum::Parse(v188, v129);\n\tv90 = v90_asT == 0;\n\tif (v90) goto L_0061;\n\tv237 = \"il2cpp_vm_object_unbox\"(v172, EasyMobile.EEACountries, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturnVal1 = *([v237 @ X0_v34]);\nL_005D:\n\treturn returnVal1;\n\tv131 = new System.NullReferenceException();\n\tv178 = new System.NullReferenceException();\nL_0061:\n\tv204 = new System.InvalidCastException();\n\tgoto L_006F;\n\tgoto L_006F;\n\tgoto L_006F;\nL_006F:\n\tv45 = v147 != 1;\n\tif (v45) goto L_008A;\n\tv221 = 0x6D2BC0(v204, v147, v143, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv84 = *([v221 @ X0_v12]);\n\tv236 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v84 @ X8_v6]), v143, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv238 = v236 & 1;\n\tv80 = v238 == 0;\n\tif (v80) goto L_0080;\n\tv78 = 0x6D2490(v236, *([v84 @ X8_v6]), v143, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_FFFFFFFF;\nL_0080:\n\tv240 = 0x6D1E60(8, *([v84 @ X8_v6]), v143, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v240 @ X0_v16]) = *([v221 @ X0_v12]);\n\tv147 = 0x1E8A000 + 0x870;\n\tv242 = 0x6D2A00(v240, v147, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv225 = 0x6D2490(v242, v147, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_008A:\n\tv229 = 0x6D2380(v153, v147, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturnVal2 = 0x846AA4(v229, v147, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static EEACountries ToEEACountry(this string countryCode)
		{
			//IL_005c: Expected I4, but got O
			//IL_008b: Expected I4, but got O
			if (!countryCode.IsEEACountry())
			{
				string value = countryCode.ToUpper();
				Type typeFromHandle = typeof(EEACountries);
				object obj = Enum.Parse(typeFromHandle, value);
				if ((int)((obj is EEACountries) ? obj : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					return (EEACountries)obj2;
				}
				InvalidCastException ex = new InvalidCastException();
				IntPtr intPtr = default(IntPtr);
				bool flag = intPtr != (IntPtr)1;
				InvalidCastException ex2 = ex;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj4 = default(object);
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj5 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						goto IL_0005;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj6 = obj4;
					intPtr = (IntPtr)(32022528 + 2160);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					InvalidCastException ex3 = default(InvalidCastException);
					ex2 = ex3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				EEACountries result = default(EEACountries);
				return result;
			}
			goto IL_0005;
			IL_0005:
			return default(EEACountries);
		}
	}
}
