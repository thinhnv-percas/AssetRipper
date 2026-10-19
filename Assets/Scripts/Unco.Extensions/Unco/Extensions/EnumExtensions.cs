using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.Extensions
{
	[Token(Token = "0x2000010")]
	public class EnumExtensions
	{
		[Token(Token = "0x6000051")]
		[Address(RVA = "0x4922C78", Offset = "0x4922C78", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tgoto L_0020;\n\tgoto L_0020;\n\tv48 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_002F:\n\tv71 = new Il2CppClass<Unco.Extensions.EnumExtensions+<>c__DisplayClass0_0`1<T>>();\n\tv77 = Unco.Extensions.EnumExtensions+<>c__DisplayClass0_0`1<T>::.ctor(v71);\n\tv81 = System.Linq.Enumerable::Any(v60, enumValue);\n\t// 60 Box v95 @ X0_v10 (System.Object), typeof(Il2CppClass<T>), v60 @ X24_v1 (System.Byte*)\n\tgoto L_0049;\n\tv71.value = v99;\n\tgoto L_0056;\nL_0056:\n\tv111 = new Il2CppClass<System.Func`2<T, System.Boolean>>();\n\tv159 = System.Func`2<T, System.Boolean>::.ctor(v111, v71, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::Any(flags, v111);\n\tv164 = *([A4731E0]);\n\tv114 = *([v164 @ X9_v7]) != *([v25 @ X8_v2]);\n\tif (v114) goto L_007F;\n\treturn returnVal2;\nL_007F:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0020:\n\tv54 = Il2CppClass<T>;\n\tv58 = *([v54 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv59 = v58 & 0x1FFFFFFF0;\n\t// 37 StackAlloc v60 @ X24_v1 (System.Byte*), v59 @ X10_v2 (System.Int32)\n\tgoto L_002F;\nL_0049:\n\tv99 = System.Convert::ToInt32(v95);\n")]
		public unsafe static bool IsContains<T>(T enumValue, params T[] flags) where T : Enum
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnumExtensions::IsContains");
			return default;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x81A9AD0", Offset = "0x81A9AD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public EnumExtensions()
		{
		}
	}
}
