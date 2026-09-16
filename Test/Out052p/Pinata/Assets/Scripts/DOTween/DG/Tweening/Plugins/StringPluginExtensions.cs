using System;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x200002C")]
	internal static class StringPluginExtensions
	{
		[Token(Token = "0x40000D4")]
		public static readonly char[] ScrambledCharsAll;

		[Token(Token = "0x40000D5")]
		public static readonly char[] ScrambledCharsUppercase;

		[Token(Token = "0x40000D6")]
		public static readonly char[] ScrambledCharsLowercase;

		[Token(Token = "0x40000D7")]
		public static readonly char[] ScrambledCharsNumerals;

		[Token(Token = "0x40000D8")]
		private static int _lastRndSeed;

		[Token(Token = "0x600020C")]
		[Address(RVA = "0x10DD4B8", Offset = "0x10DD4B8", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED6780]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20274D3]) = v39;\nL_0017:\n\t// 23 NewArr v44 @ X0_v3 (System.Char[]), typeof(System.Char[]), 60\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v44, Il2CppFieldInfo);\n\tv54.ScrambledCharsAll = v44;\n\t// 37 NewArr v56 @ X0_v5 (System.Char[]), typeof(System.Char[]), 25\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v56, Il2CppFieldInfo);\n\tv64.ScrambledCharsUppercase = v56;\n\t// 49 NewArr v66 @ X0_v7 (System.Char[]), typeof(System.Char[]), 25\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v66, Il2CppFieldInfo);\n\tv74.ScrambledCharsLowercase = v66;\n\t// 61 NewArr v76 @ X0_v9 (System.Char[]), typeof(System.Char[]), 10\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v76, Il2CppFieldInfo);\n\tv83.ScrambledCharsNumerals = v76;\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v84.ScrambledCharsAll);\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v87.ScrambledCharsUppercase);\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v90.ScrambledCharsLowercase);\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v97.ScrambledCharsNumerals);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static StringPluginExtensions()
		{
			ScrambledCharsAll = new char[60]
			{
				'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
				'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
				'U', 'V', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e',
				'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
				'p', 'q', 'r', 's', 't', 'u', 'v', 'x', 'y', 'z',
				'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
			};
			ScrambledCharsUppercase = new char[25]
			{
				'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
				'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
				'U', 'V', 'X', 'Y', 'Z'
			};
			ScrambledCharsLowercase = new char[25]
			{
				'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
				'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
				'u', 'v', 'x', 'y', 'z'
			};
			ScrambledCharsNumerals = new char[10] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
			ScrambledCharsAll.ScrambleChars();
			ScrambledCharsUppercase.ScrambleChars();
			ScrambledCharsLowercase.ScrambleChars();
			ScrambledCharsNumerals.ScrambleChars();
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x10DD604", Offset = "0x10DD604", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = chars.Length < 1;\n\tif (v32) goto L_0071;\n\tv49 = chars.Length & 0xFFFFFFFF;\n\tv50 = v49 == 0;\n\tif (v50) goto L_0064;\nL_0024:\n\tv62 = UnityEngine.Random::Range(v126, chars.Length);\n\tv212 = v62 < chars.Length;\n\tv161 = ~v212;\n\tif (v161) goto L_0064;\n\tv129 = chars.Length & 0xFFFFFFFF;\n\tv213 = v126 < v129;\n\tv162 = ~v213;\n\tif (v162) goto L_0064;\n\tv70 = v62 << 1;\n\tv214 = chars + v70;\n\tv83 = v214 + 0x20;\n\tchars[v126 @ X21_v5 (System.Int32)] = *([v83 @ X8_v8]);\n\tv216 = v62 < chars.Length;\n\tv163 = ~v216;\n\tif (v163) goto L_0064;\n\tv79 = v126 + 1;\n\t*([v83 @ X8_v8]) = chars[v126 @ X21_v5 (System.Int32)];\n\tv86 = v79 >= v49;\n\tif (v86) goto L_0071;\n\tv218 = v79 < chars.Length;\n\tv160 = ~v218;\n\tv130 = ~v160;\n\tif (v130) goto L_0024;\nL_0064:\n\tv164 = new System.IndexOutOfRangeException();\n\tthrow v164;\nL_0071:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ScrambleChars(this char[] chars)
		{
			//IL_0033: Expected I4, but got I8
			//IL_0072: Expected I4, but got I8
			//IL_00b5: Expected O, but got I
			//IL_00c4: Expected O, but got I
			//IL_00d5: Expected I4, but got O
			//IL_011d: Expected O, but got I4
			if (chars.Length < 1)
			{
				return;
			}
			int num = (int)(chars.Length & 0xFFFFFFFFL);
			if (num != 0)
			{
				int num2 = 0;
				bool flag3;
				do
				{
					int num3 = UnityEngine.Random.Range(num2, chars.Length);
					if (num3 >= chars.Length)
					{
						break;
					}
					int num4 = (int)(chars.Length & 0xFFFFFFFFL);
					if (num2 >= num4)
					{
						break;
					}
					int num5 = num3 << 1;
					object obj = (long)(IntPtr)chars + (long)num5;
					object obj2 = (long)(IntPtr)obj + 32L;
					chars[num2] = (char)(int)obj2;
					if (num3 >= chars.Length)
					{
						break;
					}
					int num6 = num2 + 1;
					obj2 = chars[num2];
					if (num6 < num)
					{
						bool flag = num6 < chars.Length;
						bool flag2 = !flag;
						flag3 = !flag2;
						num2 = num6;
						continue;
					}
					return;
				}
				while (flag3);
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0x10DD26C", Offset = "0x10DD26C", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = *([1EC2E98]);\n\tv31 = *([v30 @ X8_v19]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, length, chars, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20274D4]) = v48;\nL_0023:\n\tv59 = length < 1;\n\tif (v59) goto L_00A0;\n\tgoto L_0037;\n\tv191 = *([v118 @ X8_v5 (Il2CppClass<DG.Tweening.Plugins.StringPluginExtensions>)+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0037;\n\tv202 = v118;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v202, length, chars, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv199 = DG.Tweening.Plugins.StringPluginExtensions;\nL_0037:\n\tv145 = v200._lastRndSeed;\n\tgoto L_0042;\nL_003C:\n\tv230 = UnityEngine.Random::Range(0, chars.Length);\nL_0042:\n\tgoto L_0050;\n\tv238 = *([v233 @ X8_v7 (Il2CppClass<DG.Tweening.Plugins.StringPluginExtensions>)+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tgoto L_0050;\n\tv247 = v233;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v247, v225, v223, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv245 = DG.Tweening.Plugins.StringPluginExtensions;\nL_0050:\n\tv212 = v145 == v228._lastRndSeed;\n\tif (v212) goto L_003C;\n\tgoto L_0063;\n\tv252 = *([v244 @ X8_v8 (Il2CppClass<DG.Tweening.Plugins.StringPluginExtensions>)+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\tif (v254) goto L_0063;\n\tv262 = v244;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v262, v225, v223, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv260 = DG.Tweening.Plugins.StringPluginExtensions;\n\tv255 = *([v260 @ X8_v13+B8]);\nL_0063:\n\tv95._lastRndSeed = v145;\nL_0067:\n\tv277 = v145 - chars.Length;\n\tv278 = v277 < 0;\n\tv280 = v145 ^ chars.Length;\n\tv281 = v145 ^ v277;\n\tv282 = v280 & v281;\n\tv283 = v282 < 0;\n\tv284 = v278 == v283;\n\tv124 = ~v284;\n\tv62 = ~v124;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_0076;\nL_0076:\n\tv287 = v145 < chars.Length;\n\tv140 = ~v287;\n\tif (v140) goto L_00A1;\n\tv100 = System.Text.StringBuilder::Append(buffer, chars[v145 @ X23_v7 (System.Int32)]);\n\tv154 = v154 + 1;\n\tv145 = v145 + 1;\n\tv65 = v154 < length;\n\tif (v65) goto L_0067;\nL_00A0:\n\treturn buffer;\nL_00A1:\n\tv288 = new System.IndexOutOfRangeException();\n\tthrow v288;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static StringBuilder AppendScrambledChars(this StringBuilder buffer, int length, char[] chars)
		{
			if (length >= 1)
			{
				int num = _lastRndSeed;
				while (num == _lastRndSeed)
				{
					int num2 = UnityEngine.Random.Range(0, chars.Length);
					num = num2;
				}
				_lastRndSeed = num;
				int num3 = 0;
				do
				{
					int num4 = num - chars.Length;
					bool flag = num4 < 0;
					int num5 = num ^ chars.Length;
					int num6 = num ^ num4;
					int num7 = num5 & num6;
					bool flag2 = num7 < 0;
					if (flag == flag2)
					{
						num = 0;
					}
					if (num < chars.Length)
					{
						StringBuilder stringBuilder = buffer.Append(chars[num]);
						num3++;
						num++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num3 < length);
			}
			return buffer;
		}
	}
}
