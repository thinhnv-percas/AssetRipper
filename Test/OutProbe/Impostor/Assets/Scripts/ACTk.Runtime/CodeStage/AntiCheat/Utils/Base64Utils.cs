using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Utils
{
	[Token(Token = "0x2000004")]
	internal static class Base64Utils
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0xBD3E5C", Offset = "0xBD3E5C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = System.Convert;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A353D2]) = v38;\nL_001C:\n\tgoto L_0020;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = System.Convert::FromBase64String(value);\n\tgoto L_002F;\n\tv57 = v52;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v57, v50, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\treturnVal1 = CodeStage.AntiCheat.Utils.StringUtils::BytesToString(v51);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string FromBase64ToString(string value)
		{
			byte[] input = Convert.FromBase64String(value);
			return StringUtils.BytesToString(input);
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0xBD3F18", Offset = "0xBD3F18", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = System.Convert;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A353D3]) = v38;\nL_001C:\n\tgoto L_0020;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = System.Convert::FromBase64String(value);\n\tgoto L_002F;\n\tv57 = v52;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v57, v50, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\treturnVal1 = CodeStage.AntiCheat.Utils.StringUtils::BytesToChars(v51);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static char[] FromBase64ToChars(string value)
		{
			byte[] input = Convert.FromBase64String(value);
			return StringUtils.BytesToChars(input);
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0xBD3FD4", Offset = "0xBD3FD4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = System.Convert;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A353D4]) = v38;\nL_001C:\n\tgoto L_001F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = CodeStage.AntiCheat.Utils.StringUtils::StringToBytes(value);\n\tgoto L_002F;\n\tv56 = v51;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\treturnVal1 = System.Convert::ToBase64String(v50);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToBase64(string value)
		{
			byte[] inArray = StringUtils.StringToBytes(value);
			return Convert.ToBase64String(inArray);
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0xBD4090", Offset = "0xBD4090", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = System.Convert;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A353D5]) = v38;\nL_001C:\n\tgoto L_001F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = CodeStage.AntiCheat.Utils.StringUtils::CharsToBytes(value);\n\tgoto L_002F;\n\tv56 = v51;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\treturnVal1 = System.Convert::ToBase64String(v50);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToBase64(char[] value)
		{
			byte[] inArray = StringUtils.CharsToBytes(value);
			return Convert.ToBase64String(inArray);
		}
	}
}
