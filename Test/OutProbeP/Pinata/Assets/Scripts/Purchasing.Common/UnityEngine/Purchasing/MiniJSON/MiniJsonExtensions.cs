using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.MiniJSON
{
	[Token(Token = "0x2000009")]
	public static class MiniJsonExtensions
	{
		[Token(Token = "0x6000022")]
		[Address(RVA = "0x166EDB8", Offset = "0x166EDB8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EDE980]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, key, defaultValue, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202B23D]) = v44;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dic, key);\n\tv54 = v51 == 0;\n\tif (v54) goto L_003D;\n\tv60 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dic, key);\n\tv90 = *([v60 @ X0_v9]);\n\tv78 = *([v90 @ X8_v8+160]);\n\tv80 = *([v90 @ X8_v8+168]);\n\t// 52 IndirectJump v78 @ X2_v4, v60 @ X0_v9, v60 @ X0_v9, v80 @ X1_v4, v78 @ X2_v4, methodInfo @ X3 (Il2CppMethodInfo), v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\nL_003D:\n\treturn defaultValue;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetString(this Dictionary<string, object> dic, string key, string defaultValue = "")
		{
			//IL_0061: Expected O, but got I
			//IL_0071: Expected O, but got I
			if (dic.ContainsKey(key))
			{
				object obj = dic.get_Item(key);
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v8+160]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v8+168]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v78 @ X2_v4 (should have been resolved before IL gen)");
			}
			return defaultValue;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x166EE68", Offset = "0x166EE68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Purchasing.MiniJSON.Json+Serializer::Serialize(obj);\n\treturn returnVal1;\n")]
		public static string toJson(this Dictionary<string, object> obj)
		{
			return Json.Serializer.Serialize(obj);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x166EE70", Offset = "0x166EE70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Purchasing.MiniJSON.Json+Serializer::Serialize(obj);\n\treturn returnVal1;\n")]
		public static string toJson(this Dictionary<string, string> obj)
		{
			return Json.Serializer.Serialize(obj);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x166EE74", Offset = "0x166EE74", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EADB08]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B23E]) = v38;\nL_0013:\n\tv39 = json == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv41 = UnityEngine.Purchasing.MiniJSON.Json+Parser::Parse(json);\n\tv77 = v41 == 0;\n\tif (v77) goto L_0043;\n\tgoto L_FFFFFFFF;\n\tgoto L_0043;\n\tv83 = v83_asT == 0;\n\tif (v83) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Dictionary<string, object> HashtableFromJson(this string json)
		{
			Dictionary<string, object> result;
			if (json != null)
			{
				object obj = Json.Parser.Parse(json);
				bool flag = obj == null;
				result = (Dictionary<string, object>)obj;
				if (!flag)
				{
					Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
					result = (Dictionary<string, object>)((dictionary == null) ? null : obj);
				}
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
