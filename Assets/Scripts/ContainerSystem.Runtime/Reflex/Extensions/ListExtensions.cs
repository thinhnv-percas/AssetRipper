using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Extensions
{
	[Token(Token = "0x2000027")]
	internal static class ListExtensions
	{
		[Token(Token = "0x6000070")]
		[Address(RVA = "0x4A0F3D4", Offset = "0x4A0F3D4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = *([A4731E0]);\n\tgoto L_001A;\n\tv30 = 0x220C2B8(methodInfo, v43, il2cppRetVal, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_004B:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_001A:\n\tv51 = Il2CppClass<TSource>;\n\tv55 = *([v51 @ X9_v1 (Il2CppClass<TSource>)+FC]) + 0xF;\n\tv56 = v55 & 0x1FFFFFFF0;\n\t// 31 StackAlloc v57 @ X22_v2 (System.Byte*), v56 @ X10_v2 (System.Int32)\n\tv61 = System.Linq.Enumerable::OrderByDescending(v46, v43);\n\tv63 = Il2CppMethodInfo;\n\tv65 = v61;\n\tv66 = v57;\n\t*([v63 @ X1_v2 (Il2CppMethodInfo)+10])(v72, *([v63 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, 0, &v65 @ stack_-48_v1 (System.Linq.IOrderedEnumerable`1<TSource>), v57, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturnVal1 = 0x8BF6A1C(il2cppRetVal, v57, *([v51 @ X9_v1 (Il2CppClass<TSource>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv79 = *([A4731E0]);\n\tv90 = *([v79 @ X9_v5]) != *([v19 @ X8_v2]);\n\tif (v90) goto L_004B;\n")]
		internal unsafe static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			//IL_0010: Expected O, but got I
			//IL_005e: Expected O, but got I
			//IL_0071: Expected I4, but got I8
			//IL_00cc: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X9_v1 (Il2CppClass<TSource>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			IEnumerable<TSource> source2 = default(IEnumerable<TSource>);
			Func<TSource, TKey> keySelector = default(Func<TSource, TKey>);
			IOrderedEnumerable<TSource> orderedEnumerable = source2.OrderByDescending(keySelector);
			nint num3 = 0;
			IOrderedEnumerable<TSource> orderedEnumerable2 = orderedEnumerable;
			byte* ptr2 = ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v63 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			TSource result = default(TSource);
			if (obj3 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			TSource result2 = default(TSource);
			return result2;
		}
	}
}
