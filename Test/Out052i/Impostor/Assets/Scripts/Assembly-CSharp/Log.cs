using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200000D")]
public class Log
{
	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000051")]
	[Address(RVA = "0xBF8A9C", Offset = "0xBF8A9C", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = \"Info : \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355C5]) = v38;\nL_0019:\n\tv42 = message == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv49 = System.Object::ToString(message);\n\tgoto L_0025;\nL_0025:\n\tv59 = System.String::Concat(\"Info : \", v52);\n\tgoto L_0035;\n\tv65 = v60;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v65, v52, v58, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0035:\n\tUnityEngine.Debug::Log(v59);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Info(object message)
	{
		string text2;
		if (message != null)
		{
			string text = message.ToString();
			text2 = text;
		}
		else
		{
			text2 = null;
		}
		string message2 = "Info : " + text2;
		Debug.Log(message2);
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000052")]
	[Address(RVA = "0xBF8B40", Offset = "0xBF8B40", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = \"Warning : \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355C6]) = v38;\nL_0019:\n\tv42 = message == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv49 = System.Object::ToString(message);\n\tgoto L_0025;\nL_0025:\n\tv59 = System.String::Concat(\"Warning : \", v52);\n\tgoto L_0035;\n\tv65 = v60;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v65, v52, v58, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0035:\n\tUnityEngine.Debug::LogWarning(v59);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Warning(object message)
	{
		string text2;
		if (message != null)
		{
			string text = message.ToString();
			text2 = text;
		}
		else
		{
			text2 = null;
		}
		string message2 = "Warning : " + text2;
		Debug.LogWarning(message2);
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000053")]
	[Address(RVA = "0xBF8BE4", Offset = "0xBF8BE4", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = \"Error : \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355C7]) = v38;\nL_0019:\n\tv42 = message == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv49 = System.Object::ToString(message);\n\tgoto L_0025;\nL_0025:\n\tv59 = System.String::Concat(\"Error : \", v52);\n\tgoto L_0035;\n\tv65 = v60;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v65, v52, v58, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0035:\n\tUnityEngine.Debug::LogError(v59);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Error(object message)
	{
		string text2;
		if (message != null)
		{
			string text = message.ToString();
			text2 = text;
		}
		else
		{
			text2 = null;
		}
		string message2 = "Error : " + text2;
		Debug.LogError(message2);
	}

	[Token(Token = "0x6000054")]
	[Address(RVA = "0xBF8C88", Offset = "0xBF8C88", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Log()
	{
	}
}
