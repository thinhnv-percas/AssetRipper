using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.Utilities
{
	[Token(Token = "0x2000003")]
	public static class StringExtensions
	{
		[Token(Token = "0x6000002")]
		[Address(RVA = "0x1658D44", Offset = "0x1658D44", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = System.String::IndexOf(source, toCheck, comparisonType);\n\tv26 = v9 >> 0x1F;\n\treturnVal1 = v26 ^ 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Contains(this string source, string toCheck, StringComparison comparisonType)
		{
			int num = source.IndexOf(toCheck, comparisonType);
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}
	}
}
