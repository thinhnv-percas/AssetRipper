using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Tayx.Graphy.Utils.NumString
{
	[Token(Token = "0x2000032")]
	public static class G_IntString
	{
		[Token(Token = "0x4000156")]
		private static string[] negativeBuffer;

		[Token(Token = "0x4000157")]
		private static string[] positiveBuffer;

		[Token(Token = "0x17000037")]
		public static bool Inited
		{
			[Token(Token = "0x600016B")]
			[Address(RVA = "0x16442E0", Offset = "0x16442E0", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB06F0]);\n\tv15 = *([v14 @ X8_v16]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AB1C]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_001F:\n\tv50 = v49.negativeBuffer;\n\tv54 = v50.Length == 0;\n\tif (v54) goto L_002A;\n\tgoto L_0045;\nL_002A:\n\tgoto L_0032;\n\tv105 = *([v45 @ X0_v3 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0032;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv129 = Tayx.Graphy.Utils.NumString.G_IntString;\n\tv111 = *([v129 @ X8_v11+B8]);\nL_0032:\n\tv62 = v110.positiveBuffer;\n\tv85 = v62.Length == 0;\n\tv70 = ~v85;\nL_0045:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x17000038")]
		public static int MinValue
		{
			[Token(Token = "0x600016C")]
			[Address(RVA = "0x1644394", Offset = "0x1644394", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF95A8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AB1D]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_001F:\n\tv50 = v49.negativeBuffer;\n\treturnVal1 = 1 - v50.Length;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string[] array = negativeBuffer;
				return 1 - array.Length;
			}
		}

		[Token(Token = "0x17000039")]
		public static int MaxValue
		{
			[Token(Token = "0x600016D")]
			[Address(RVA = "0x1644414", Offset = "0x1644414", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAD278]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AB1E]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_001F:\n\tv50 = v49.positiveBuffer;\n\treturnVal1 = v50.Length - 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string[] array = positiveBuffer;
				return array.Length - 1;
			}
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x1644490", Offset = "0x1644490", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv30 = *([1EA9C00]);\n\tv31 = *([v30 @ X8_v47]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, maxPositiveValue, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202AB1F]) = v49;\nL_0025:\n\tv62 = minNegativeValue > 0;\n\tif (v62) goto L_0095;\n\tgoto L_0035;\n\tv134 = *([v65 @ X0_v27+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_0035;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v65, maxPositiveValue, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0035:\n\tv143 = UnityEngine.Mathf::Abs(minNegativeValue);\n\t// 60 NewArr v217 @ X0_v32 (System.String[]), typeof(System.String[]), v143 @ X0_v30 (System.Int32)\n\tgoto L_0056;\n\tv287 = *([v275 @ X8_v31 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_0056;\n\tv297 = v275;\n\tv290 = \"il2cpp_codegen_runtime_class_init\"(v297, v115, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv292 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_0056:\n\tv127.negativeBuffer = v217;\n\tv76 = v143 < 1;\n\tif (v76) goto L_0095;\nL_0061:\n\tgoto L_006B;\n\tv361 = *([v342 @ X0_v35 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv362 = v361 == 0;\n\tv363 = ~v362;\n\tgoto L_006B;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v342, v336, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv365 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_006B:\n\tv73 = v368.negativeBuffer;\n\tv371 = 0xDC3560(&v341 @ X21_v13 (System.Int32), 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv402 = v371 == 0;\n\tif (v402) goto L_007A;\n\t// 118 IsInst v455 @ X0_v41, typeof(System.String), v371 @ X0_v38\nL_007A:\n\tv458 = v335 < v73.Length;\n\tv439 = ~v458;\n\tif (v439) goto L_0105;\n\tv107 = v335 + 1;\n\tv341 = v341 - 1;\n\tv73[v335 @ X23_v11 (System.Int32)] = v371;\n\tv75 = v107 < v143;\n\tif (v75) goto L_0061;\nL_0095:\n\tv131 = maxPositiveValue & 0x80000000;\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_0102;\n\t// 157 NewArr v148 @ X0_v14 (System.String[]), typeof(System.String[]), maxPositiveValue @ X1 (System.Int32)\n\tgoto L_00B7;\n\tv279 = *([v219 @ X8_v11 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv280 = v279 == 0;\n\tv281 = ~v280;\n\tif (v281) goto L_00B7;\n\tv295 = v219;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v295, v146, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv284 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_00B7:\n\tv185.positiveBuffer = v148;\n\tv154 = maxPositiveValue < 1;\n\tif (v154) goto L_0102;\n\tgoto L_00C2;\nL_00C2:\n\tgoto L_00CE;\n\tv346 = *([v318 @ X8_v13 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv347 = v346 == 0;\n\tv348 = ~v347;\n\tgoto L_00CE;\n\tv372 = v318;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v372, v314, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv355 = Tayx.Graphy.Utils.NumString.G_IntString;\n\tv350 = v300;\nL_00CE:\n\tv182 = v356.positiveBuffer;\n\tv360 = 0xDC3560(&v358 @ stack_-48_v9, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv376 = v360 == 0;\n\tif (v376) goto L_00DC;\n\t// 216 IsInst v406 @ X0_v22, typeof(System.String), v360 @ X0_v19\nL_00DC:\n\tv410 = v349 < v182.Length;\n\tv411 = ~v410;\n\tif (v411) goto L_0105;\n\tv182[v349 @ X22_v10 (System.Int32)] = v360;\n\tv349 = v358 + 1;\n\tv153 = v349 < maxPositiveValue;\n\tif (v153) goto L_00C2;\nL_0102:\n\treturn;\n\tv401 = new System.NullReferenceException();\nL_0105:\n\tv451 = new System.IndexOutOfRangeException();\n\tgoto L_010A;\n\tv487 = new System.ArrayTypeMismatchException();\nL_010A:\n\tthrow v489;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init(int minNegativeValue, int maxPositiveValue)
		{
			//IL_0100: Expected I4, but got I8
			if (minNegativeValue <= 0)
			{
				int num = Mathf.Abs(minNegativeValue);
				string[] array = new string[num];
				negativeBuffer = array;
				if (num >= 1)
				{
					int num2 = 0;
					int num3 = 0;
					object obj = default(object);
					while (true)
					{
						string[] array2 = negativeBuffer;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						if (obj != null)
						{
							object obj2 = obj as string;
						}
						if (num2 >= array2.Length)
						{
							break;
						}
						int num4 = num2 + 1;
						num3--;
						array2[num2] = (string)obj;
						bool flag = num4 < num;
						num2 = num4;
						if (!flag)
						{
							goto IL_00ee;
						}
					}
					goto IL_01dd;
				}
			}
			goto IL_00ee;
			IL_00ee:
			if ((int)(maxPositiveValue & 0x80000000L) != 0)
			{
				return;
			}
			string[] array3 = new string[maxPositiveValue];
			positiveBuffer = array3;
			if (maxPositiveValue < 1)
			{
				return;
			}
			int num5 = 0;
			object obj3 = default(object);
			object obj5 = default(object);
			while (true)
			{
				string[] array4 = positiveBuffer;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				if (obj3 != null)
				{
					object obj4 = obj3 as string;
				}
				if (num5 >= array4.Length)
				{
					break;
				}
				array4[num5] = (string)obj3;
				num5 = (int)((long)(IntPtr)obj5 + 1L);
				if (num5 >= maxPositiveValue)
				{
					return;
				}
			}
			goto IL_01dd;
			IL_01dd:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x1644700", Offset = "0x1644700", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv19 = *([1EC1468]);\n\tv20 = *([v19 @ X8_v28]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([202AB20]) = v39;\nL_0018:\n\tv44 = value & 0x80000000;\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0058;\n\tgoto L_0026;\n\tv51 = *([v42 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0026;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv55 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_0026:\n\tv266 = v58.positiveBuffer;\n\tv84 = v266.Length <= value;\n\tif (v84) goto L_0090;\n\tgoto L_0046;\n\tv113 = *([v54 @ X0_v20 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv173 = v113 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_0046;\n\tv269 = Tayx.Graphy.Utils.NumString.G_IntString;\n\tv270 = *([v269 @ X8_v22 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+B8]);\n\tv125 = v270.positiveBuffer;\nL_0046:\n\tv180 = v266.Length < value;\n\tv181 = ~v180;\n\tv182 = v266.Length - value;\n\tv184 = v182 == 0;\n\tv189 = ~v181;\n\tv190 = v189 | v184;\n\tif (v190) goto L_008A;\n\tgoto L_0096;\nL_0058:\n\tgoto L_0060;\n\tv61 = *([v42 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0060;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv65 = Tayx.Graphy.Utils.NumString.G_IntString;\nL_0060:\n\tv266 = v68.negativeBuffer;\n\tv221 = 0 - value;\n\tv86 = v221 >= v266.Length;\n\tif (v86) goto L_0090;\n\tgoto L_007F;\n\tv114 = *([v64 @ X0_v13 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+E0]);\n\tv248 = v114 == 0;\n\tv249 = ~v248;\n\tif (v249) goto L_007F;\n\tv271 = Tayx.Graphy.Utils.NumString.G_IntString;\n\tv272 = *([v271 @ X8_v12 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_IntString>)+B8]);\n\tv126 = v272.negativeBuffer;\nL_007F:\n\tv255 = v221 < v266.Length;\n\tv256 = ~v255;\n\tv264 = ~v256;\n\tif (v264) goto L_FFFFFFFF;\nL_008A:\n\tv268 = new System.IndexOutOfRangeException();\n\tthrow v268;\nL_0090:\n\treturnVal2 = 0xDC3560(&value @ X0 (System.Int32), 0, v135, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0096:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToStringNonAlloc(this int value)
		{
			//IL_0157: Expected I4, but got I8
			string[] array;
			int num2;
			if ((int)(value & 0x80000000L) == 0)
			{
				array = positiveBuffer;
				if (array.Length > value)
				{
					bool flag = array.Length < value;
					bool flag2 = !flag;
					int num = array.Length - value;
					bool flag3 = num == 0;
					bool flag4 = !flag2;
					bool flag5 = flag4 || flag3;
					num2 = value;
					if (!flag5)
					{
						goto IL_0097;
					}
					goto IL_011a;
				}
			}
			else
			{
				array = negativeBuffer;
				num2 = -value;
				if (num2 < array.Length)
				{
					if (num2 < array.Length)
					{
						goto IL_0097;
					}
					goto IL_011a;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string result = default(string);
			return result;
			IL_011a:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			int num3 = 0;
			throw ex;
			IL_0097:
			return array[num2];
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x164484C", Offset = "0x164484C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EB7F60]);\n\tv17 = *([v16 @ X8_v8]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202AB21]) = v37;\nL_0016:\n\t// 22 NewArr v42 @ X0_v3 (System.String[]), typeof(System.String[]), 0\n\tv47.negativeBuffer = v42;\n\t// 30 NewArr v49 @ X0_v5 (System.String[]), typeof(System.String[]), 0\n\tv51.positiveBuffer = v49;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static G_IntString()
		{
			string[] array = new string[0];
			negativeBuffer = array;
			string[] array2 = new string[0];
			positiveBuffer = array2;
		}
	}
}
