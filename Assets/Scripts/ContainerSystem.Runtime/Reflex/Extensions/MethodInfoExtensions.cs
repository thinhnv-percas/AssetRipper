using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Extensions
{
	[Token(Token = "0x2000028")]
	internal static class MethodInfoExtensions
	{
		[Token(Token = "0x6000071")]
		[Address(RVA = "0x4ADEA80", Offset = "0x4ADEA80", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000F;\nL_000F:\n\tv22 = 0xB7D5000 + 0x538;\n\tv23 = *([v22 @ X8_v16 (System.Int32)+E0]);\n\tv25 = *([v23 @ X0_v25+E4]) == 0;\n\tv44 = Il2CppClass<T>;\n\tv54 = Il2CppClass<T>;\n\tif (v25) goto L_0048;\nL_0016:\n\tv67 = System.Type::GetTypeFromHandle(v44);\nL_001E:\n\tv77 = System.Reflection.MethodInfo::CreateDelegate(methodInfo, v67);\n\tgoto L_002B;\n\treturnVal2 = 0x21C11D0(v77, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv132 = returnVal2 == 0;\n\tif (v132) goto L_0058;\n\treturn returnVal2;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv60 = 0xB7D5000 + 0x538;\n\tv43 = *([v60 @ X8_v7 (System.Int32)+E0]);\n\tv61 = *([v43 @ X0_v11+E4]) == 0;\n\tv47 = ~v61;\n\tv44 = Il2CppClass<T>;\n\tv54 = Il2CppClass<T>;\n\tif (v47) goto L_0016;\nL_0048:\n\tv67 = System.Type::GetTypeFromHandle(v54);\n\tv92 = methodInfo == 0;\n\tv70 = ~v92;\n\tif (v70) goto L_001E;\n\tthrow System.NullReferenceException;\nL_0055:\n\treturn 0;\nL_0058:\n\treturnVal3 = new System.InvalidCastException();\n\treturn returnVal3;\nL_002B:\n\tv98 = v77 == 0;\n\tif (v98) goto L_0055;\n")]
		public static T CreateDelegate<T>(this MethodInfo methodInfo) where T : Delegate
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MethodInfoExtensions::CreateDelegate");
			return default;
		}
	}
}
