using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.Utility
{
	[Token(Token = "0x2000084")]
	public static class Lists<T>
	{
		[Token(Token = "0x400035F")]
		public static readonly List<T> Empty;

		[Token(Token = "0x600067B")]
		[Address(RVA = "0xD95808", Offset = "0xD95808", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv21 = v16;\n\tv22 = 0x8907BC(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0017:\n\tgoto L_001B;\n\tv45 = v40;\n\tv46 = 0x8907BC(v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001B:\n\tv49 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv50 = Il2CppClass<HutongGames.Utility.Lists`1>;\n\tgoto L_002B;\n\tv57 = v50;\n\tv58 = 0x8907BC(v57, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv60 = Il2CppClass<HutongGames.Utility.Lists`1>;\n\tv63 = *([v60 @ X21_v4 (Il2CppClass<HutongGames.Utility.Lists`1>)+12E]);\nL_002B:\n\tv67 = *([v50 @ X22_v1 (Il2CppClass<HutongGames.Utility.Lists`1>)+12E]) & 1;\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0034;\n\tv71 = 0x8907BC(Il2CppClass<HutongGames.Utility.Lists`1>, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv76 = System.Collections.Generic.List`1<T>::.ctor(v49);\n\tgoto L_0043;\n\tv82 = v77;\n\tv83 = System.Collections.Generic.List`1<T>::.ctor(v82, v75);\nL_0043:\n\tgoto L_0047;\n\tv91 = v86;\n\tv92 = System.Collections.Generic.List`1<T>::.ctor(v91, v75);\nL_0047:\n\tv94.Empty = v49;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Lists()
		{
			List<T> empty = new List<T>();
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X22_v1 (Il2CppClass<HutongGames.Utility.Lists`1>)+12E]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
			}
			Empty = empty;
		}
	}
}
