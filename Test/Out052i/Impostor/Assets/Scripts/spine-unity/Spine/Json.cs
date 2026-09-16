using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using SharpJson;

namespace Spine
{
	[Token(Token = "0x2000049")]
	public static class Json
	{
		[Token(Token = "0x60002E7")]
		[Address(RVA = "0x15330B8", Offset = "0x15330B8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = SharpJson.JsonDecoder;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B5E]) = v37;\nL_0014:\n\tv39 = new SharpJson.JsonDecoder();\n\tSharpJson.JsonDecoder::.ctor(v39);\n\tv39.<parseNumbersAsFloat>k__BackingField = 1;\n\tv52 = System.IO.TextReader::ReadToEnd(text);\n\treturnVal2 = SharpJson.JsonDecoder::Decode(v39, v52);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static object Deserialize(TextReader text)
		{
			JsonDecoder jsonDecoder = new JsonDecoder();
			jsonDecoder.parseNumbersAsFloat = true;
			string text2 = text.ReadToEnd();
			return jsonDecoder.Decode(text2);
		}
	}
}
