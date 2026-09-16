using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.MiniJSON;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000002")]
	public class MiniJson
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x166EE6C", Offset = "0x166EE6C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Purchasing.MiniJSON.Json+Serializer::Serialize(json);\n\treturn returnVal1;\n")]
		public static string JsonEncode(object json)
		{
			return Json.Serializer.Serialize(json);
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x166EF00", Offset = "0x166EF00", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = json == 0;\n\tif (v0) goto L_0004;\n\treturnVal2 = UnityEngine.Purchasing.MiniJSON.Json+Parser::Parse(json);\n\treturn returnVal2;\nL_0004:\n\treturn json;\n")]
		public static object JsonDecode(string json)
		{
			if (json != null)
			{
				return Json.Parser.Parse(json);
			}
			return json;
		}
	}
}
