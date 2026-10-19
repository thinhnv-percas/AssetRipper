using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Extensions
{
	[Token(Token = "0x2000026")]
	internal static class IntExtensions
	{
		[Token(Token = "0x600006F")]
		[Address(RVA = "0x3F33EC8", Offset = "0x3F33EC8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_0028;\nL_0028:\n\tv68 = x - 1;\n\tv72 = System.Math::Log(v68, 2d);\n\tv113 = v72 + 1;\n\tv118 = v72 == 0x7FF0000000000000;\n\tv128 = ~v118;\n\tif (v128) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv98 = 0xC1DFFFFFFFC00000;\n\tgoto L_0045;\nL_FFFFFFFF:\n\tv98 = v113;\nL_FFFFFFFF:\n\treturnVal2 = 0xFFFFFFFF80000000;\n\tgoto L_005D;\nL_FFFFFFFF:\n\treturnVal2 = v100;\nL_0066:\n\treturn 1;\nL_001E:\n\tv52 = x < 2;\n\tif (v52) goto L_0066;\nL_0045:\n\tv100 = System.Math::Pow(2d, v98);\n\tv92 = v100 == 0x7FF0000000000000;\n\tv81 = ~v92;\n\tif (v81) goto L_FFFFFFFF;\nL_005D:\n\treturn returnVal2;\n")]
		public static int CeilPowerOf2(this int x)
		{
			//IL_007e: Expected F8, but got I8
			//IL_00a6: Expected I4, but got F8
			if (x >= 2)
			{
				int num = x - 1;
				double num2 = Math.Log(num, 2.0);
				double num3 = num2 + 5E-324;
				double y = ((num2 != 9.218868437227405E+18) ? num3 : (-4.4765780296104673E+18));
				double num4 = Math.Pow(2.0, y);
				if (num4 == 9.218868437227405E+18)
				{
					return -2147483648;
				}
				return (int)num4;
			}
			return 1;
		}
	}
}
