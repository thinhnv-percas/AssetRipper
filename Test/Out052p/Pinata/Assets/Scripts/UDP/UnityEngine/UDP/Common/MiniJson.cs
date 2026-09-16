using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Common.MiniJSON;

namespace UnityEngine.UDP.Common
{
	[Token(Token = "0x200001C")]
	public class MiniJson
	{
		[Token(Token = "0x6000082")]
		[Address(RVA = "0x15C6530", Offset = "0x15C6530", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Common.MiniJSON.Json+Serializer::Serialize(json);\n\treturn returnVal1;\n")]
		public static string JsonEncode(object json)
		{
			return Json.Serializer.Serialize(json);
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x15C8A20", Offset = "0x15C8A20", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBFB58]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299C0]) = v38;\nL_0013:\n\tv39 = json == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv41 = UnityEngine.UDP.Common.MiniJSON.Json+Parser::Parse(json);\n\tv83 = v41 == 0;\n\tif (v83) goto L_003F;\n\tgoto L_FFFFFFFF;\n\tv99 = v99_asT != 0;\n\tif (v99) goto L_003F;\n\tthrow System.InvalidCastException;\nL_003F:\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Dictionary<string, object> JsonDecode(string json)
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
					bool flag2 = dictionary != null;
					result = (Dictionary<string, object>)obj;
					if (!flag2)
					{
						throw new InvalidCastException();
					}
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
