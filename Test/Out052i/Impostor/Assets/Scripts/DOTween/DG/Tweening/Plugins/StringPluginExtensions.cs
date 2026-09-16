using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000084")]
	internal static class StringPluginExtensions
	{
		[Token(Token = "0x4000164")]
		public static readonly char[] ScrambledCharsAll;

		[Token(Token = "0x4000165")]
		public static readonly char[] ScrambledCharsUppercase;

		[Token(Token = "0x4000166")]
		public static readonly char[] ScrambledCharsLowercase;

		[Token(Token = "0x4000167")]
		public static readonly char[] ScrambledCharsNumerals;

		[Token(Token = "0x4000168")]
		private static int _lastRndSeed;

		[Token(Token = "0x6000355")]
		[Address(RVA = "0xC26DA0", Offset = "0xC26DA0", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv34 = System.Char[];\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv60 = DG.Tweening.Plugins.StringPluginExtensions;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv66 = Il2CppFieldInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv74 = Il2CppFieldInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv80 = Il2CppFieldInfo;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv88 = Il2CppFieldInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv55 = 1;\n\t*([1A3578F]) = v55;\nL_0031:\n\t// 49 NewArr v58 @ X0_v3 (System.Char[]), typeof(System.Char[]), 60\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v58, Il2CppFieldInfo);\n\tv70.ScrambledCharsAll = v58;\n\t// 59 NewArr v72 @ X0_v5 (System.Char[]), typeof(System.Char[]), 25\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v72, Il2CppFieldInfo);\n\tv84.ScrambledCharsUppercase = v72;\n\t// 69 NewArr v86 @ X0_v7 (System.Char[]), typeof(System.Char[]), 25\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v86, Il2CppFieldInfo);\n\tv94.ScrambledCharsLowercase = v86;\n\t// 79 NewArr v96 @ X0_v9 (System.Char[]), typeof(System.Char[]), 10\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v96, Il2CppFieldInfo);\n\tv101.ScrambledCharsNumerals = v96;\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v101.ScrambledCharsAll);\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v104.ScrambledCharsUppercase);\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v107.ScrambledCharsLowercase);\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v116.ScrambledCharsNumerals);\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000356")]
		[Address(RVA = "0xC26F24", Offset = "0xC26F24", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = chars.Length < 1;\n\tif (v28) goto L_005B;\n\tv56 = chars.Length & 0xFFFFFFFF;\nL_002A:\n\tv113 = UnityEngine.Random::Range(v54, chars.Length);\n\tv107 = v113 << 1;\n\tv213 = chars + v107;\n\tv105 = v213 + 0x20;\n\tchars[v54 @ X21_v5 (System.Int32)] = *([v105 @ X9_v5]);\n\tv120 = v54 + 1;\n\t*([v105 @ X9_v5]) = chars[v54 @ X21_v5 (System.Int32)];\n\tv123 = v56 != v120;\n\tif (v123) goto L_002A;\nL_005B:\n\treturn;\n\tv45 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ScrambleChars(this char[] chars)
		{
			//IL_0033: Expected I4, but got I8
			//IL_0075: Expected O, but got I
			//IL_0084: Expected O, but got I
			//IL_0095: Expected I4, but got O
			//IL_00b4: Expected O, but got I4
			if (chars.Length >= 1)
			{
				int num = (int)(chars.Length & 0xFFFFFFFFL);
				int num2 = 0;
				bool flag;
				do
				{
					int num3 = Random.Range(num2, chars.Length);
					int num4 = num3 << 1;
					object obj = (nint)chars + num4;
					object obj2 = (nint)obj + 32;
					chars[num2] = (char)(int)obj2;
					int num5 = num2 + 1;
					obj2 = chars[num2];
					flag = num != num5;
					num2 = num5;
				}
				while (flag);
			}
		}

		[Token(Token = "0x6000357")]
		[Address(RVA = "0xC26B70", Offset = "0xC26B70", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = DG.Tweening.Plugins.StringPluginExtensions;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, length, chars, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35790]) = v43;\nL_0020:\n\tv54 = length < 1;\n\tif (v54) goto L_008F;\n\tgoto L_0030;\n\tv183 = v113;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v183, length, chars, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv187 = DG.Tweening.Plugins.StringPluginExtensions;\nL_0030:\n\tv140 = v188._lastRndSeed;\nL_0034:\n\tgoto L_0043;\n\tv226 = v222;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v226, v214, v212, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv230 = DG.Tweening.Plugins.StringPluginExtensions;\nL_0043:\n\tv191 = v140 != v217._lastRndSeed;\n\tif (v191) goto L_004F;\n\tv219 = UnityEngine.Random::Range(0, chars.Length);\n\tgoto L_0034;\nL_004F:\n\tgoto L_0054;\n\tv235 = v229;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v235, v214, v212, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv240 = DG.Tweening.Plugins.StringPluginExtensions;\n\tv237 = *([v240 @ X8_v13+B8]);\nL_0054:\n\tv90._lastRndSeed = v140;\nL_0058:\n\tv255 = v140 - chars.Length;\n\tv256 = v255 < 0;\n\tv258 = v140 ^ chars.Length;\n\tv259 = v140 ^ v255;\n\tv260 = v258 & v259;\n\tv261 = v260 < 0;\n\tv262 = v256 == v261;\n\tv119 = ~v262;\n\tv57 = ~v119;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_0078;\nL_0078:\n\tv95 = System.Text.StringBuilder::Append(buffer, chars[v140 @ X23_v7 (System.Int32)]);\n\tv99 = v153 - 1;\n\tv140 = v140 + 1;\n\tv60 = v153 != 1;\n\tif (v60) goto L_0058;\nL_008F:\n\treturn buffer;\n\tv148 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static StringBuilder AppendScrambledChars(this StringBuilder buffer, int length, char[] chars)
		{
			if (length >= 1)
			{
				int num = _lastRndSeed;
				while (num == _lastRndSeed)
				{
					int num2 = Random.Range(0, chars.Length);
					num = num2;
				}
				_lastRndSeed = num;
				int num3 = length;
				bool flag3;
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
					StringBuilder stringBuilder = buffer.Append(chars[num]);
					int num8 = num3 - 1;
					num++;
					flag3 = num3 != 1;
					num3 = num8;
				}
				while (flag3);
			}
			return buffer;
		}
	}
}
