using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Tayx.Graphy.Utils.NumString
{
	[Token(Token = "0x2000031")]
	public static class G_FloatString
	{
		[Token(Token = "0x4000152")]
		private const string floatFormat = "0.0";

		[Token(Token = "0x4000153")]
		private static float decimalMultiplier = 1f;

		[Token(Token = "0x4000154")]
		private static string[] negativeBuffer;

		[Token(Token = "0x4000155")]
		private static string[] positiveBuffer;

		[Token(Token = "0x17000034")]
		public static bool Inited
		{
			[Token(Token = "0x600015F")]
			[Address(RVA = "0x1643A78", Offset = "0x1643A78", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA7778]);\n\tv15 = *([v14 @ X8_v16]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AB13]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_001F:\n\tv50 = v49.negativeBuffer;\n\tv54 = v50.Length == 0;\n\tif (v54) goto L_002A;\n\tgoto L_0045;\nL_002A:\n\tgoto L_0032;\n\tv105 = *([v45 @ X0_v3 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0032;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv129 = Tayx.Graphy.Utils.NumString.G_FloatString;\n\tv111 = *([v129 @ X8_v11+B8]);\nL_0032:\n\tv62 = v110.positiveBuffer;\n\tv85 = v62.Length == 0;\n\tv70 = ~v85;\nL_0045:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string[] array = negativeBuffer;
				if (array.Length != 0)
				{
					return true;
				}
				string[] array2 = positiveBuffer;
				bool flag = array2.Length == 0;
				return !flag;
			}
		}

		[Token(Token = "0x17000035")]
		public static float MinValue
		{
			[Token(Token = "0x6000160")]
			[Address(RVA = "0x1643B2C", Offset = "0x1643B2C", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF0188]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AB14]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_001F:\n\tv50 = v49.negativeBuffer;\n\tv54 = v50.Length - 1;\n\tv55 = Tayx.Graphy.Utils.NumString.G_FloatString::FromIndex(v54);\n\treturnVal1 = -v55;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string[] array = negativeBuffer;
				int i = array.Length - 1;
				float num = i.FromIndex();
				return 0f - num;
			}
		}

		[Token(Token = "0x17000036")]
		public static float MaxValue
		{
			[Token(Token = "0x6000161")]
			[Address(RVA = "0x1643BB0", Offset = "0x1643BB0", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB7468]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AB15]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_001F:\n\tv50 = v49.positiveBuffer;\n\tv56 = v50.Length - 1;\n\treturnVal1 = Tayx.Graphy.Utils.NumString.G_FloatString::FromIndex(v56);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string[] array = positiveBuffer;
				int i = array.Length - 1;
				return i.FromIndex();
			}
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0x1643C2C", Offset = "0x1643C2C", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv38 = *([1EC80D0]);\n\tv39 = *([v38 @ X8_v51]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, minNegativeValue, maxPositiveValue, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([202AB16]) = v56;\nL_0024:\n\tgoto L_002E;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_002E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v42, v43, v44, v45, v46, v47, minNegativeValue, maxPositiveValue, v48, v49, v50, v51, v52, v53);\nL_002E:\n\tv87 = UnityEngine.Mathf::Clamp(decimals, 1, 5);\n\tgoto L_0047;\n\tv83 = *([v79 @ X8_v7+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0047;\n\tv101 = v79;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v101, v71, v72, v74, v44, v45, v46, v47, minNegativeValue, maxPositiveValue, v48, v49, v50, v51, v52, v53);\nL_0047:\n\tv100 = v87 < 2;\n\tif (v100) goto L_FFFFFFFF;\n\tv105 = v87 - 1;\nL_004B:\n\tv107 = v105 - 1;\n\tv111 = v111 * v111;\n\tv110 = v105 != 1;\n\tif (v110) goto L_004B;\n\tgoto L_0055;\nL_0055:\n\tv121.decimalMultiplier = v115;\n\tv123 = Tayx.Graphy.Utils.NumString.G_FloatString::ToIndex(v115);\n\tv126 = Tayx.Graphy.Utils.NumString.G_FloatString::ToIndex(maxPositiveValue);\n\tv128 = v123 & 0x80000000;\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_00C2;\n\t// 100 NewArr v135 @ X0_v36 (System.String[]), typeof(System.String[]), v123 @ X0_v7 (System.Int32)\n\tgoto L_007C;\n\tv283 = *([v202 @ X8_v33 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_007C;\n\tv350 = v202;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v350, v133, v72, v74, v44, v45, v46, v47, v124, maxPositiveValue, v48, v49, v50, v51, v52, v53);\n\tv288 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_007C:\n\tv182.negativeBuffer = v135;\n\tv155 = v123 < 1;\n\tif (v155) goto L_00C2;\n\tgoto L_008B;\nL_0087:\n\tv197 = v197 - 1;\nL_008B:\n\tgoto L_0095;\n\tv391 = *([v382 @ X8_v35 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv392 = v391 == 0;\n\tv393 = ~v392;\n\tgoto L_0095;\n\tv426 = v382;\n\tv395 = \"il2cpp_codegen_runtime_class_init\"(v426, v379, v378, v74, v44, v45, v46, v47, v367, maxPositiveValue, v48, v49, v50, v51, v52, v53);\n\tv398 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_0095:\n\tv137 = v399.negativeBuffer;\n\tv115 = Tayx.Graphy.Utils.NumString.G_FloatString::FromIndex(v197);\n\tv429 = 0xBCCF34(&v115 @ V0_v1 (System.Single), \"0.0\", 0, 0, v44, v45, v46, v47, v115, maxPositiveValue, v48, v49, v50, v51, v52, v53);\n\tv445 = v429 == 0;\n\tif (v445) goto L_00A8;\n\t// 164 IsInst v477 @ X0_v45, typeof(System.String), v429 @ X0_v42\nL_00A8:\n\tv481 = v365 < v137.Length;\n\tv482 = ~v481;\n\tif (v482) goto L_0136;\n\tv146 = v365 + 1;\n\tv137[v365 @ X23_v11 (System.Int32)] = v429;\n\tv154 = v146 < v123;\n\tif (v154) goto L_0087;\nL_00C2:\n\tv199 = v126 & 0x80000000;\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0133;\n\t// 202 NewArr v210 @ X0_v21 (System.String[]), typeof(System.String[]), v126 @ X0_v8 (System.Int32)\n\tgoto L_00E2;\n\tv354 = *([v291 @ X8_v19 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv355 = v354 == 0;\n\tv356 = ~v355;\n\tif (v356) goto L_00E2;\n\tv388 = v291;\n\tv358 = \"il2cpp_codegen_runtime_class_init\"(v388, v208, v183, v74, v44, v45, v46, v47, v151, maxPositiveValue, v48, v49, v50, v51, v52, v53);\n\tv359 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_00E2:\n\tv252.positiveBuffer = v210;\n\tv225 = v126 < 1;\n\tif (v225) goto L_0133;\n\tgoto L_00EF;\nL_00EF:\n\tgoto L_00F9;\n\tv430 = *([v420 @ X8_v21 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv431 = v430 == 0;\n\tv432 = ~v431;\n\tgoto L_00F9;\n\tv441 = v420;\n\tv434 = \"il2cpp_codegen_runtime_class_init\"(v441, v416, v415, v74, v44, v45, v46, v47, v404, maxPositiveValue, v48, v49, v50, v51, v52, v53);\n\tv437 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_00F9:\n\tv216 = v438.positiveBuffer;\n\tv115 = Tayx.Graphy.Utils.NumString.G_FloatString::FromIndex(v422);\n\tv444 = 0xBCCF34(&v115 @ V0_v1 (System.Single), \"0.0\", 0, 0, v44, v45, v46, v47, v115, maxPositiveValue, v48, v49, v50, v51, v52, v53);\n\tv525 = v444 == 0;\n\tif (v525) goto L_010C;\n\t// 264 IsInst v531 @ X0_v30, typeof(System.String), v444 @ X0_v27\nL_010C:\n\tv534 = v422 < v216.Length;\n\tv514 = ~v534;\n\tif (v514) goto L_0136;\n\tv269 = v422 + 1;\n\tv216[v422 @ X20_v11 (System.Int32)] = v444;\n\tv224 = v269 < v126;\n\tif (v224) goto L_FFFFFFFF;\nL_0133:\n\treturn;\n\tv473 = new System.NullReferenceException();\nL_0136:\n\tv524 = new System.IndexOutOfRangeException();\n\tgoto L_013B;\n\tv560 = new System.ArrayTypeMismatchException();\nL_013B:\n\tthrow v563;\n// 203 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init(float minNegativeValue, float maxPositiveValue, int decimals = 1)
		{
			//IL_02f2: Expected I4, but got I8
			//IL_0173: Expected I4, but got I8
			int num = Mathf.Clamp(decimals, 1, 5);
			float f;
			if (num >= 2)
			{
				int num2 = num - 1;
				float num3 = 1.4E-44f;
				int num4 = default(int);
				num2 = num4;
				float num5 = default(float);
				num3 = num5;
				bool flag;
				do
				{
					int num6 = num2 - 1;
					num3 *= num3;
					flag = num2 != 1;
					num2 = num6;
				}
				while (flag);
				f = num3;
			}
			else
			{
				f = 10f;
			}
			decimalMultiplier = f;
			int num7 = f.ToIndex();
			int num8 = maxPositiveValue.ToIndex();
			int num9 = (int)(num7 & 0x80000000L);
			bool flag2 = num9 == 0;
			bool flag3 = !flag2;
			f = maxPositiveValue;
			if (!flag3)
			{
				string[] array = new string[num7];
				negativeBuffer = array;
				bool flag4 = num7 < 1;
				f = maxPositiveValue;
				if (!flag4)
				{
					int num10 = 0;
					int num11 = 0;
					object obj = default(object);
					while (true)
					{
						string[] array2 = negativeBuffer;
						f = num11.FromIndex();
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
						if (obj != null)
						{
							object obj2 = obj as string;
						}
						if (num10 >= array2.Length)
						{
							break;
						}
						int num12 = num10 + 1;
						array2[num10] = (string)obj;
						if (num12 < num7)
						{
							num11--;
							num10 = num12;
							continue;
						}
						goto IL_0161;
					}
					goto IL_0260;
				}
			}
			goto IL_0161;
			IL_0161:
			if ((int)(num8 & 0x80000000L) != 0)
			{
				return;
			}
			string[] array3 = new string[num8];
			positiveBuffer = array3;
			if (num8 < 1)
			{
				return;
			}
			int num13 = 0;
			object obj3 = default(object);
			while (true)
			{
				string[] array4 = positiveBuffer;
				f = num13.FromIndex();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
				if (obj3 != null)
				{
					object obj4 = obj3 as string;
				}
				if (num13 >= array4.Length)
				{
					break;
				}
				int num14 = num13 + 1;
				array4[num13] = (string)obj3;
				if (num14 < num8)
				{
					num13 = num14;
					continue;
				}
				return;
			}
			goto IL_0260;
			IL_0260:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0x16440CC", Offset = "0x16440CC", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv21 = *([1EE2228]);\n\tv22 = *([v21 @ X8_v31]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, v24, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202AB17]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v24, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\nL_0022:\n\tv56 = Tayx.Graphy.Utils.NumString.G_FloatString::ToIndex(value);\n\tv67 = value >= 0;\n\tif (v67) goto L_0064;\n\tgoto L_003B;\n\tv110 = *([v68 @ X0_v23 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_003B;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v68, v24, v25, v26, v27, v28, v29, v30, v55, v31, v32, v33, v34, v35, v36, v37);\n\tv113 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_003B:\n\tv234 = v116.negativeBuffer;\n\tv76 = v56 >= v234.Length;\n\tif (v76) goto L_0064;\n\tv218 = *([v94 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+12F]) & 2;\n\tv219 = v218 == 0;\n\tif (v219) goto L_0090;\n\tv262 = *([v94 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]) == 0;\n\tv263 = ~v262;\n\tif (v263) goto L_0090;\n\tv234 = v280.negativeBuffer;\n\tv281 = v280.negativeBuffer == 0;\n\tv168 = ~v281;\n\tif (v168) goto L_0090;\n\tgoto L_00A9;\nL_0064:\n\tv109 = value < 0;\n\tif (v109) goto L_00A0;\n\tgoto L_0072;\n\tv175 = *([v117 @ X0_v18 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0072;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v117, v24, v25, v26, v27, v28, v29, v30, v55, v31, v32, v33, v34, v35, v36, v37);\n\tv178 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_0072:\n\tv234 = v181.positiveBuffer;\n\tv124 = v56 >= v234.Length;\n\tif (v124) goto L_00A0;\n\tgoto L_0090;\n\tv154 = *([v142 @ X0_v19 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv278 = v154 == 0;\n\tv275 = ~v278;\n\tif (v275) goto L_0090;\n\tv282 = Tayx.Graphy.Utils.NumString.G_FloatString;\n\tv283 = *([v282 @ X8_v16 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+B8]);\n\tv172 = v283.positiveBuffer;\nL_0090:\n\tv276 = v56 < v234.Length;\n\tv205 = ~v276;\n\tif (v205) goto L_00AA;\n\tgoto L_00A7;\nL_00A0:\n\treturnVal1 = 0xBCCEC8(&value @ V0 (System.Single), 0, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\nL_00A7:\n\treturn returnVal1;\nL_00A9:\n\tv174 = new System.NullReferenceException();\nL_00AA:\n\tv235 = new System.IndexOutOfRangeException();\n\tthrow v235;\n\treturn returnVal2;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToStringNonAlloc(this float value)
		{
			//IL_0042: Expected I, but got O
			int num = value.ToIndex();
			string[] array;
			if (value < 0f)
			{
				IntPtr intPtr = (IntPtr)typeof(G_FloatString);
				array = negativeBuffer;
				if (num < array.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+12F]");
					if (0u != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							array = negativeBuffer;
							if (negativeBuffer == null)
							{
								NullReferenceException ex = new NullReferenceException();
								goto IL_01b2;
							}
						}
					}
					goto IL_014c;
				}
			}
			if (!(value < 0f))
			{
				array = positiveBuffer;
				if (num < array.Length)
				{
					goto IL_014c;
				}
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
			string result = default(string);
			return result;
			IL_01b2:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
			IL_014c:
			if (num < array.Length)
			{
				return array[num];
			}
			goto IL_01b2;
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x16438E8", Offset = "0x16438E8", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv25 = *([1ECD3A0]);\n\tv26 = *([v25 @ X8_v31]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, value, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AB18]) = v44;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v29, v30, v31, v32, v33, v34, value, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tv59 = Tayx.Graphy.Utils.NumString.G_FloatString::ToIndex(value);\n\tv70 = value >= 0;\n\tif (v70) goto L_0066;\n\tgoto L_003D;\n\tv113 = *([v71 @ X0_v23 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_003D;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v29, v30, v31, v32, v33, v34, v58, v35, v36, v37, v38, v39, v40, v41);\n\tv116 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_003D:\n\tv240 = v119.negativeBuffer;\n\tv79 = v59 >= v240.Length;\n\tif (v79) goto L_0066;\n\tv224 = *([v97 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+12F]) & 2;\n\tv225 = v224 == 0;\n\tif (v225) goto L_0092;\n\tv269 = *([v97 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]) == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0092;\n\tv240 = v287.negativeBuffer;\n\tv288 = v287.negativeBuffer == 0;\n\tv172 = ~v288;\n\tif (v172) goto L_0092;\n\tgoto L_00AD;\nL_0066:\n\tv112 = value < 0;\n\tif (v112) goto L_00A3;\n\tgoto L_0074;\n\tv179 = *([v120 @ X0_v18 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0074;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v120, methodInfo, v29, v30, v31, v32, v33, v34, v58, v35, v36, v37, v38, v39, v40, v41);\n\tv182 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_0074:\n\tv240 = v185.positiveBuffer;\n\tv127 = v59 >= v240.Length;\n\tif (v127) goto L_00A3;\n\tgoto L_0092;\n\tv158 = *([v145 @ X0_v19 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv285 = v158 == 0;\n\tv282 = ~v285;\n\tif (v282) goto L_0092;\n\tv289 = Tayx.Graphy.Utils.NumString.G_FloatString;\n\tv290 = *([v289 @ X8_v16 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+B8]);\n\tv176 = v290.positiveBuffer;\nL_0092:\n\tv283 = v59 < v240.Length;\n\tv210 = ~v283;\n\tif (v210) goto L_00AE;\n\tgoto L_00AB;\nL_00A3:\n\treturnVal1 = 0xBCCF34(&value @ V0 (System.Single), format, 0, v30, v31, v32, v33, v34, value, v35, v36, v37, v38, v39, v40, v41);\nL_00AB:\n\treturn returnVal1;\nL_00AD:\n\tv178 = new System.NullReferenceException();\nL_00AE:\n\tv241 = new System.IndexOutOfRangeException();\n\tthrow v241;\n\treturn returnVal2;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToStringNonAlloc(this float value, string format)
		{
			//IL_0042: Expected I, but got O
			int num = value.ToIndex();
			string[] array;
			if (value < 0f)
			{
				IntPtr intPtr = (IntPtr)typeof(G_FloatString);
				array = negativeBuffer;
				if (num < array.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+12F]");
					if (0u != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X0_v24 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							array = negativeBuffer;
							if (negativeBuffer == null)
							{
								NullReferenceException ex = new NullReferenceException();
								goto IL_01b2;
							}
						}
					}
					goto IL_014c;
				}
			}
			if (!(value < 0f))
			{
				array = positiveBuffer;
				if (num < array.Length)
				{
					goto IL_014c;
				}
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
			string result = default(string);
			return result;
			IL_01b2:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
			IL_014c:
			if (num < array.Length)
			{
				return array[num];
			}
			goto IL_01b2;
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x1644244", Offset = "0x1644244", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn f;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ToInt(this float f)
		{
			//IL_0005: Expected I4, but got F4
			return (int)f;
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x164424C", Offset = "0x164424C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn i;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ToFloat(this int i)
		{
			return i;
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x164400C", Offset = "0x164400C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = p < 2;\n\tif (v11) goto L_0012;\n\tv24 = p - 1;\nL_000D:\n\tv20 = v24 - 1;\n\treturnVal1 = v23 * v23;\n\tv14 = v24 != 1;\n\tif (v14) goto L_000D;\nL_0012:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int Pow(int f, int p)
		{
			int num3 = default(int);
			if (p >= 2)
			{
				int num = p - 1;
				int num2 = num3;
				num2 = num3;
				int num4 = default(int);
				num = num4;
				bool flag;
				do
				{
					int num5 = num - 1;
					num3 = num2 * num2;
					flag = num != 1;
					num2 = num3;
					num = num5;
				}
				while (flag);
			}
			return num3;
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x1644028", Offset = "0x1644028", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAE040]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, f, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AB19]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, v21, v22, v23, v24, v25, v26, v27, f, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_0025:\n\tv57 = v53.decimalMultiplier * f;\n\tgoto L_0037;\n\tv63 = *([v56 @ X0_v4+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0037;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v56, v21, v22, v23, v24, v25, v26, v27, v57, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\treturnVal1 = UnityEngine.Mathf::Abs(v57);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int ToIndex(this float f)
		{
			//IL_000e: Expected I4, but got F4
			float num = decimalMultiplier * f;
			return Mathf.Abs((int)num);
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0x1643F98", Offset = "0x1643F98", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC3E38]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB1A]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Tayx.Graphy.Utils.NumString.G_FloatString;\nL_0025:\n\treturnVal1 = i / v52.decimalMultiplier;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float FromIndex(this int i)
		{
			return (float)i / decimalMultiplier;
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x1644254", Offset = "0x1644254", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv16 = *([1EEEDC8]);\n\tv17 = *([v16 @ X8_v10]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202AB1B]) = v37;\nL_0019:\n\tv44.decimalMultiplier = 1f;\n\t// 28 NewArr v47 @ X0_v3 (System.String[]), typeof(System.String[]), 0\n\tv50.negativeBuffer = v47;\n\t// 34 NewArr v52 @ X0_v5 (System.String[]), typeof(System.String[]), 0\n\tv54.positiveBuffer = v52;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static G_FloatString()
		{
			string[] array = new string[0];
			negativeBuffer = array;
			string[] array2 = new string[0];
			positiveBuffer = array2;
		}
	}
}
