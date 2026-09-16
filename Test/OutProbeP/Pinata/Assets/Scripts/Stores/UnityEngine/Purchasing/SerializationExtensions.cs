using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000008")]
	internal static class SerializationExtensions
	{
		[Token(Token = "0x6000022")]
		[Address(RVA = "0xC62E10", Offset = "0xC62E10", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EAB138]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, key, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233C1]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dic, key);\n\tv51 = v48 == 0;\n\tif (v51) goto L_003F;\n\tv68 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dic, key);\n\tv73 = v68 == 0;\n\tif (v73) goto L_003F;\n\tv57 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dic, key);\n\tv94 = *([v57 @ X0_v12]);\n\tv84 = *([v94 @ X8_v6+160]);\n\tv86 = *([v94 @ X8_v6+168]);\n\t// 55 IndirectJump v84 @ X2_v6, v57 @ X0_v12, v57 @ X0_v12, v86 @ X1_v6, v84 @ X2_v6, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_003F:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string TryGetString(this Dictionary<string, object> dic, string key)
		{
			//IL_008f: Expected O, but got I
			//IL_009f: Expected O, but got I
			if (dic.ContainsKey(key))
			{
				object obj = dic.get_Item(key);
				if (obj != null)
				{
					object obj2 = dic.get_Item(key);
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X8_v6+160]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X8_v6+168]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v84 @ X2_v6 (should have been resolved before IL gen)");
				}
			}
			return null;
		}
	}
}
