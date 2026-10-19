using System;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Extensions
{
	[Token(Token = "0x2000018")]
	public static class StringExtensions
	{
		[Token(Token = "0x400004E")]
		private static readonly Regex SnakeCaseRegex;

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x81AA760", Offset = "0x81AA760", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = System.String::IsNullOrWhiteSpace(str);\n\tv60 = v51 == 0;\n\tif (v60) goto L_003C;\n\treturn str;\nL_003C:\n\tgoto L_0048;\nL_0048:\n\tv126 = System.Text.RegularExpressions.Regex::Replace(v121.SnakeCaseRegex, str, \"_$1\");\n\tv129 = System.String::ToLower(v126);\n\treturnVal3 = System.String::ToLower(v129);\n\treturn returnVal3;\n")]
		public static string ToSnakeCase(this string str)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				return str;
			}
			string text = SnakeCaseRegex.Replace(str, "_$1");
			string text2 = text.ToLower();
			return text2.ToLower();
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x81AA860", Offset = "0x81AA860", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturn str;\nL_0033:\n\tgoto L_0040;\nL_0040:\n\treturnVal2 = System.Text.RegularExpressions.Regex::Replace(str, \"(?<!^)([A-Z])\", \" $1\");\n\treturn returnVal2;\nL_001C:\n\tv45 = System.String::IsNullOrWhiteSpace(str);\n\tv50 = v45 == 0;\n\tif (v50) goto L_0033;\n")]
		public static string SplitCamelCase(this string str)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				return str;
			}
			return Regex.Replace(str, "(?<!^)([A-Z])", " $1");
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x81AA918", Offset = "0x81AA918", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::IsNullOrEmpty(str);\n\treturn returnVal1;\n")]
		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x81AA858", Offset = "0x81AA858", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::IsNullOrWhiteSpace(str);\n\treturn returnVal1;\n")]
		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrWhiteSpace(str);
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x81AA920", Offset = "0x81AA920", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\nL_0041:\n\tv161 = UnityEngine.ColorUtility::ToHtmlStringRGBA(color);\n\t// 44 NewArr v59 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv59[0] = \"<color=#\";\n\tv59[1] = v161;\n\tv59[2] = \">\";\n\tv59[3] = input;\n\tv59[4] = \"</color>\";\n\treturnVal2 = System.String::Concat(v59);\n\treturn returnVal2;\n")]
		public static string SetTextColor(this string input, Color color)
		{
			string text = ColorUtility.ToHtmlStringRGBA(color);
			return "<color=#" + text + ">" + input + "</color>";
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x81AAA9C", Offset = "0x81AAA9C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tgoto L_0023;\nL_0023:\n\tv63 = System.Math::Min(str.Length, maxLength);\n\treturnVal2 = System.String::Substring(str, 0, v63);\n\treturn returnVal2;\nL_0039:\n\treturn 0;\nL_0015:\n\tv43 = str == 0;\n\tif (v43) goto L_0039;\n")]
		public static string TruncateLongString(this string str, int maxLength)
		{
			if (str != null)
			{
				int length = Math.Min(str.Length, maxLength);
				return str.Substring(0, length);
			}
			return null;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x81AAB38", Offset = "0x81AAB38", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Text.RegularExpressions.Regex();\n\tSystem.Text.RegularExpressions.Regex::.ctor(v49, \"(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])\", 8);\n\tv60.SnakeCaseRegex = v49;\n")]
		static StringExtensions()
		{
			Regex snakeCaseRegex = new Regex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled);
			SnakeCaseRegex = snakeCaseRegex;
		}
	}
}
