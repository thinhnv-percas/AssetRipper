using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.Utilities
{
	[Token(Token = "0x2000002")]
	public static class LinqExtensions
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x11BE9D0", Offset = "0x11BE9D0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = list == 0;\n\tif (v12) goto L_FFFFFFFF;\n\tgoto L_0012;\n\tv21 = v15;\n\tv22 = 0x8907BC(v21, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0012:\n\tv38 = list->klass;\n\tv40 = *([v38 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v40) goto L_0035;\n\tv140 = *([v38 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_001E:\n\tv145 = *([v140 @ X11_v6-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v145) goto L_0039;\n\tv139 = v139 + 1;\n\tv150 = v139 < *([v38 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv120 = ~v150;\n\tv140 = v140 + 0x10;\n\tv104 = ~v120;\n\tif (v104) goto L_001E;\nL_0035:\n\tgoto L_003F;\n\tgoto L_004F;\nL_0039:\n\t;\nL_003F:\n\tv167 = System.Collections.Generic.ICollection`1<T>::get_Count(list);\n\tv67 = v167 == 0;\nL_004F:\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsNullOrEmpty<T>(this IList<T> list)
		{
			//IL_002a: Expected I, but got O
			//IL_0114: Expected O, but got I4
			//IL_0065: Expected O, but got I
			//IL_00b1: Expected O, but got I
			if (list != null)
			{
				IntPtr intPtr = (IntPtr)list;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X11_v6-8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
							bool flag = (long)num2 < 0L;
							flag2 = !flag;
							obj = (long)(IntPtr)obj + 16L;
							continue;
						}
						break;
					}
					while (!flag2);
				}
				object obj2 = list.Count;
				return obj2 == null;
			}
			return true;
		}
	}
}
